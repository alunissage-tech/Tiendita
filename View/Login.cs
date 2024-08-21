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
            int textBox1Y = formCenterY - (textBox1.Height + textBox2.Height + checkBox1.Height + button1.Height + 40) / 2; // 40 es la suma de los márgenes entre los controles
            int textBox2Y = textBox1Y + textBox1.Height + 10; // 10 es el margen entre textBox1 y textBox2
            int checkBox1Y = textBox2Y + textBox2.Height + 10;
            int button1Y = checkBox1Y + checkBox1.Height + 20;

            // Centrando los controles horizontalmente
            textBox1.Left = formCenterX - textBox1.Width / 2;
            textBox1.Top = textBox1Y;

            textBox2.Left = formCenterX - textBox2.Width / 2;
            textBox2.Top = textBox2Y;

            checkBox1.Left = formCenterX - checkBox1.Width / 2;
            checkBox1.Top = checkBox1Y;

            button1.Left = formCenterX - button1.Width / 2;
            button1.Top = button1Y;

            // Alinear las etiquetas con los campos de texto
            label1.Left = textBox1.Left - label1.Width - 10; // 10 es un margen
            label1.Top = textBox1.Top + (textBox1.Height - label1.Height) / 2;

            label2.Left = textBox2.Left - label2.Width - 10;
            label2.Top = textBox2.Top + (textBox2.Height - label2.Height) / 2;
        }
    }
}
