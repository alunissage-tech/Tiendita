using System;
using System.Windows.Forms;
using Controller;
using View.UserControls;

namespace View
{
    /// <summary>
    /// Represents the login form of the application.
    /// Allows the user to enter credentials and access the system.
    /// </summary>
    public partial class Login : BaseMaterialForm
    {
        private readonly AuthController authController;

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// Configures the header, centers the controls, and sets the initial window position.
        /// </summary>
        public Login()
        {
            InitializeComponent();
            authController = new AuthController();

            Header header = new Header(this);
            header.SetButtonVisibility(true);
            this.Controls.Add(header);
            header.Dock = DockStyle.Top;

            CenterControls();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Handles the Click event of the login button.
        /// Validates the user credentials by calling the <see cref="AuthController.AuthenticateUser"/> method.
        /// If the credentials are valid, the MainForm is displayed; otherwise, an error message is shown.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Authenticate user through the controller
            var (isAuthenticated, _) = await authController.AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                // Proceed to the main form if authentication is successful
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the showPasswordCheckbox.
        /// Toggles the visibility of the password in the password text box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ShowPasswordCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Password = !checkBox_ShowPassword.Checked;
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

            int txtUsernameY = formCenterY - (txtUsername.Height + txtPassword.Height + checkBox_ShowPassword.Height + btnLogin.Height + 50) / 2;
            int txtPasswordY = txtUsernameY + txtUsername.Height + 10;
            int checkBoxY = txtPasswordY + txtPassword.Height + 10;
            int btnLoginY = checkBoxY + checkBox_ShowPassword.Height + 20;

            txtUsername.Left = formCenterX - txtUsername.Width / 2;
            txtUsername.Top = txtUsernameY;

            txtPassword.Left = formCenterX - txtPassword.Width / 2;
            txtPassword.Top = txtPasswordY;

            checkBox_ShowPassword.Left = formCenterX - checkBox_ShowPassword.Width / 2;
            checkBox_ShowPassword.Top = checkBoxY;

            btnLogin.Left = formCenterX - btnLogin.Width / 2;
            btnLogin.Top = btnLoginY;

            lblUsername.Left = txtUsername.Left - lblUsername.Width - 10;
            lblUsername.Top = txtUsername.Top + (txtUsername.Height - lblUsername.Height) / 2;

            lblPassword.Left = txtPassword.Left - lblPassword.Width - 10;
            lblPassword.Top = txtPassword.Top + (txtPassword.Height - lblPassword.Height) / 2;
        }

    }
}
