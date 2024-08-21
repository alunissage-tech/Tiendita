using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace View
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();

            // Configuración de MaterialSkin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // Puedes cambiar a DARK si lo prefieres
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );

            // Asegurar que los controles estén centrados al iniciar
            CenterControls();

            // Establecer la ventana en el centro de la pantalla al iniciar
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsername.Text;
            string password = txtPassword.Text;

            // Aquí iría la lógica para validar el login.
            if (usuario == "admin" && password == "1234")
            {
                MessageBox.Show("Login exitoso");
                // Aquí podrías redirigir al usuario al menú principal, por ejemplo:
                // var mainMenu = new MainMenu();
                // mainMenu.Show();
                // this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            // Calcular la posición centrada para cada control, tanto horizontal como verticalmente
            int formCenterX = this.ClientSize.Width / 2;
            int formCenterY = this.ClientSize.Height / 2;

            // Posiciones calculadas para centrar los controles verticalmente
            int txtUsernameY = formCenterY - (txtUsername.Height + txtPassword.Height + chkRememberMe.Height + btnLogin.Height + 40) / 2; // 40 es la suma de los márgenes entre los controles
            int txtPasswordY = txtUsernameY + txtUsername.Height + 10; // 10 es el margen entre txtUsername y txtPassword
            int chkRememberMeY = txtPasswordY + txtPassword.Height + 10;
            int btnLoginY = chkRememberMeY + chkRememberMe.Height + 20;

            // Centrando los controles horizontalmente
            txtUsername.Left = formCenterX - txtUsername.Width / 2;
            txtUsername.Top = txtUsernameY;

            txtPassword.Left = formCenterX - txtPassword.Width / 2;
            txtPassword.Top = txtPasswordY;

            chkRememberMe.Left = formCenterX - chkRememberMe.Width / 2;
            chkRememberMe.Top = chkRememberMeY;

            btnLogin.Left = formCenterX - btnLogin.Width / 2;
            btnLogin.Top = btnLoginY;

            // Alinear las etiquetas con los campos de texto
            lblUsername.Left = txtUsername.Left - lblUsername.Width - 10; // 10 es un margen
            lblUsername.Top = txtUsername.Top + (txtUsername.Height - lblUsername.Height) / 2;

            lblPassword.Left = txtPassword.Left - lblPassword.Width - 10;
            lblPassword.Top = txtPassword.Top + (txtPassword.Height - lblPassword.Height) / 2;
        }
    }
}