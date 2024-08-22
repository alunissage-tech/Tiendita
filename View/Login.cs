using System;
using System.Windows.Forms;
using View.UserControls;

namespace View
{
    /// <summary>
    /// Represents the login form of the application.
    /// Allows the user to enter credentials and access the system.
    /// </summary>
    public partial class Login : BaseMaterialForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// Configures the header, centers the controls, and sets the initial window position.
        /// </summary>
        public Login()
        {
            InitializeComponent();

            Header header = new Header(this);
            this.Controls.Add(header);
            header.Dock = DockStyle.Top;
            ThemeManager.ApplyTheme(this);

            CenterControls();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Handles the Click event of the login button.
        /// Validates the user credentials and navigates to the MainForm if they are correct.
        /// If the credentials are invalid, an error message is displayed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate credentials
            if (username == "admin" && password == "1234")
            {
                // Create an instance of MainForm
                MainForm mainForm = new MainForm();

                // Show the MainForm
                mainForm.Show();

                // Hide the Login form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }


        /// <summary>
        /// Handles the Resize event of the login form.
        /// Ensures the controls remain centered when the window is resized.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Login_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        /// <summary>
        /// Centers the controls within the form, both horizontally and vertically.
        /// </summary>
        private void CenterControls()
        {
            int formCenterX = this.ClientSize.Width / 2;
            int formCenterY = this.ClientSize.Height / 2;

            int txtUsernameY = formCenterY - (txtUsername.Height + txtPassword.Height + btnLogin.Height + 30) / 2;
            int txtPasswordY = txtUsernameY + txtUsername.Height + 10;
            int btnLoginY = txtPasswordY + txtPassword.Height + 20;

            txtUsername.Left = formCenterX - txtUsername.Width / 2;
            txtUsername.Top = txtUsernameY;

            txtPassword.Left = formCenterX - txtPassword.Width / 2;
            txtPassword.Top = txtPasswordY;

            btnLogin.Left = formCenterX - btnLogin.Width / 2;
            btnLogin.Top = btnLoginY;

            lblUsername.Left = txtUsername.Left - lblUsername.Width - 10;
            lblUsername.Top = txtUsername.Top + (txtUsername.Height - lblUsername.Height) / 2;

            lblPassword.Left = txtPassword.Left - lblPassword.Width - 10;
            lblPassword.Top = txtPassword.Top + (txtPassword.Height - lblPassword.Height) / 2;
        }
    }
}
