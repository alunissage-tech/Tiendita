using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Represents the main form of the application after a successful login.
    /// Provides navigation to other screens like Products, Sales, and Invoices.
    /// </summary>
    public partial class MainForm : BaseMaterialForm
    {
        public MainForm()
        {
            InitializeComponent();

            ThemeManager.ApplyTheme(this);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 600);

            header.SetButtonVisibility(isLoginScreen: false);
        }

        /// <summary>
        /// Displays a message indicating the view that has been selected.
        /// </summary>
        /// <param name="message">The message to display.</param>
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
