using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using View.UserControls;

namespace View
{
    public partial class Login : BaseMaterialForm
    {
        public Login()
        {
            InitializeComponent();

            // Agregar el Header para el cambio de tema
            Header header = new Header(this);
            this.Controls.Add(header);
            header.Dock = DockStyle.Top;

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
            int formCenterX = this.ClientSize.Width / 2;
            int formCenterY = this.ClientSize.Height / 2;

            int txtUsernameY = formCenterY - (txtUsername.Height + txtPassword.Height + chkRememberMe.Height + btnLogin.Height + 40) / 2;
            int txtPasswordY = txtUsernameY + txtUsername.Height + 10;
            int chkRememberMeY = txtPasswordY + txtPassword.Height + 10;
            int btnLoginY = chkRememberMeY + chkRememberMe.Height + 20;

            txtUsername.Left = formCenterX - txtUsername.Width / 2;
            txtUsername.Top = txtUsernameY;

            txtPassword.Left = formCenterX - txtPassword.Width / 2;
            txtPassword.Top = txtPasswordY;

            chkRememberMe.Left = formCenterX - chkRememberMe.Width / 2;
            chkRememberMe.Top = chkRememberMeY;

            btnLogin.Left = formCenterX - btnLogin.Width / 2;
            btnLogin.Top = btnLoginY;

            lblUsername.Left = txtUsername.Left - lblUsername.Width - 10;
            lblUsername.Top = txtUsername.Top + (txtUsername.Height - lblUsername.Height) / 2;

            lblPassword.Left = txtPassword.Left - lblPassword.Width - 10;
            lblPassword.Top = txtPassword.Top + (txtPassword.Height - lblPassword.Height) / 2;
        }
    }
}
