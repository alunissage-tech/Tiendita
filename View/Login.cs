using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string password = textBox2.Text;

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
    }
}
