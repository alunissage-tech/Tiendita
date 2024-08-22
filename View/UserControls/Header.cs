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
            btnThemeSwitch = new ToolStripButton("Cambiar tema");
            btnSettings = new ToolStripButton("Configuraciones");
            btnProducts = new ToolStripButton("Productos");
            btnSales = new ToolStripButton("Ventas");
            btnInvoices = new ToolStripButton("Facturas");

            // Add event handlers for buttons
            btnThemeSwitch.Click += BtnThemeSwitch_Click;
            btnSettings.Click += BtnSettings_Click;
            btnProducts.Click += (s, e) => ShowMessage("Products View");
            btnSales.Click += (s, e) => ShowMessage("Sales View");
            btnInvoices.Click += (s, e) => ShowMessage("Invoices View");

            // Initially, only add the theme switch button
            toolStrip.Items.Add(btnThemeSwitch);

            // Add ToolStrip to the Header control
            this.Controls.Add(toolStrip);
            toolStrip.Dock = DockStyle.Top;
        }

        /// <summary>
        /// Sets the visibility of the buttons based on the current screen.
        /// </summary>
        /// <param name="isLoginScreen">True if the current screen is the login screen; otherwise, false.</param>
        public void SetButtonVisibility(bool isLoginScreen)
        {
            if (isLoginScreen)
            {
                // Solo muestra el botón de cambio de tema durante el login
                btnThemeSwitch.Visible = true;
                btnSettings.Visible = false;
                btnProducts.Visible = false;
                btnSales.Visible = false;
                btnInvoices.Visible = false;
            }
            else
            {
                // Si no estamos en la pantalla de login, asegúrate de que los botones se agreguen y se hagan visibles
                if (!toolStrip.Items.Contains(btnSettings))
                {
                    toolStrip.Items.AddRange(new ToolStripItem[] { btnProducts, btnSales, btnInvoices, btnSettings });
                }

                btnSettings.Visible = true;
                btnProducts.Visible = true;
                btnSales.Visible = true;
                btnInvoices.Visible = true;
            }
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
