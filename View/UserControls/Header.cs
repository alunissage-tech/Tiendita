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
        private ToolStrip toolStrip;
        private ToolStripButton btnThemeSwitch;
        private ToolStripButton btnSettings;
        private ToolStripButton btnProducts;
        private ToolStripButton btnSales;
        private ToolStripButton btnInvoices;

        /// <summary>
        /// Initializes a new instance of the <see cref="Header"/> class.
        /// Configures the ToolStrip with various buttons and adds it to the header.
        /// </summary>
        /// <param name="parent">The parent form to which this header belongs.</param>
        public Header(BaseMaterialForm parent)
        {
            InitializeComponent();
            parentForm = parent;

            // Initialize ToolStrip and buttons
            toolStrip = new ToolStrip();
            btnThemeSwitch = new ToolStripButton("Change Theme");
            btnSettings = new ToolStripButton("Settings");
            btnProducts = new ToolStripButton("Products");
            btnSales = new ToolStripButton("Sales");
            btnInvoices = new ToolStripButton("Invoices");

            // Add event handlers for buttons
            btnThemeSwitch.Click += BtnThemeSwitch_Click;
            btnSettings.Click += BtnSettings_Click;
            btnProducts.Click += (s, e) => ShowMessage("Products View");
            btnSales.Click += (s, e) => ShowMessage("Sales View");
            btnInvoices.Click += (s, e) => ShowMessage("Invoices View");

            // Add buttons to ToolStrip
            toolStrip.Items.AddRange(new ToolStripItem[] { btnThemeSwitch, btnSettings, btnProducts, btnSales, btnInvoices });

            // Add ToolStrip to the Header control
            this.Controls.Add(toolStrip);
            toolStrip.Dock = DockStyle.Top;

            // Default visibility configuration
            SetButtonVisibility(isLoginScreen: true);
        }

        /// <summary>
        /// Sets the visibility of the buttons based on the current screen.
        /// </summary>
        /// <param name="isLoginScreen">True if the current screen is the login screen; otherwise, false.</param>
        public void SetButtonVisibility(bool isLoginScreen)
        {
            btnThemeSwitch.Visible = true;  // Always visible
            btnSettings.Visible = !isLoginScreen;  // Only visible after login
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
            if (parentForm.materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT)
            {
                parentForm.ApplyDarkTheme();
            }
            else
            {
                parentForm.ApplyLightTheme();
            }
        }

        /// <summary>
        /// Handles the Click event of the settings button.
        /// Opens the settings form or performs another action.
        /// </summary>
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings clicked");
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
