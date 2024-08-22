using System;
using System.Drawing;
using System.Windows.Forms;
using View.UserControls;

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

            // Suscribe to events from Header
            header.ProductsClicked += (s, e) => OpenTab("Productos", new ProductsView());
            header.SalesClicked += (s, e) => OpenTab("Ventas", new SalesView());
            header.InvoicesClicked += (s, e) => OpenTab("facturas", new InvoicesView());

            header.SetButtonVisibility(isLoginScreen: false);
        }

        /// <summary>
        /// Opens a new tab or selects an existing one.
        /// </summary>
        /// <param name="tabName">The name of the tab to open.</param>
        /// <param name="view">The UserControl to display in the tab.</param>
        private void OpenTab(string tabName, UserControl view)
        {
            // Check if the tab already exists
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Text == tabName)
                {
                    tabControl.SelectedTab = tab;
                    return;
                }
            }

            // Create a new tab page if it doesn't exist
            TabPage newTab = new TabPage(tabName)
            {
                Dock = DockStyle.Fill
            };

            view.Dock = DockStyle.Fill;
            newTab.Controls.Add(view);
            tabControl.TabPages.Add(newTab);
            tabControl.SelectedTab = newTab;
        }
    }
}
