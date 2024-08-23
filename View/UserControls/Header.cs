using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace View.UserControls
{
    /// <summary>
    /// Represents a header control that includes a ToolStrip with multiple buttons,
    /// providing persistent navigation and functionality across the application.
    /// </summary>
    public partial class Header : UserControl
    {
        private BaseMaterialForm parentForm;

        public event EventHandler ProductsClicked;
        public event EventHandler SalesClicked;
        public event EventHandler InvoicesClicked;

        /// <summary>
        /// Initializes a new instance of the <see cref="Header"/> class.
        /// Configures the ToolStrip with various buttons and adds it to the header.
        /// </summary>
        /// <param name="parent">The parent form to which this header belongs.</param>
        public Header(BaseMaterialForm parent)
        {
            InitializeComponent();
            parentForm = parent;

            // Add event handlers for buttons
            btnThemeSwitch.Click += BtnThemeSwitch_Click;
            btnSettings.Click += BtnSettings_Click;
            btnProducts.Click += (s, e) => ProductsClicked?.Invoke(this, EventArgs.Empty);
            btnSales.Click += (s, e) => SalesClicked?.Invoke(this, EventArgs.Empty);
            btnInvoices.Click += (s, e) => InvoicesClicked?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Sets the visibility of the buttons based on the current screen.
        /// </summary>
        /// <param name="isLoginScreen">True if the current screen is the login screen; otherwise, false.</param>
        public void SetButtonVisibility(bool isLoginScreen)
        {
            btnThemeSwitch.Visible = true;
            btnSettings.Visible = !isLoginScreen;
            btnProducts.Visible = !isLoginScreen;
            btnSales.Visible = !isLoginScreen;
            btnInvoices.Visible = !isLoginScreen;
        }

        /// <summary>
        /// Handles the Click event of the theme switch button.
        /// Toggles between the light and dark themes in the parent form.
        /// </summary>
        private void BtnThemeSwitch_Click(object sender, EventArgs e)
        {
            ThemeManager.ToggleTheme(parentForm);
        }

        /// <summary>
        /// Handles the Click event of the settings button.
        /// Opens the settings form or performs another action.
        /// </summary>
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings clicked");
        }
    }
}
