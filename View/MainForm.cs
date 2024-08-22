using System;
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

            Header header = new Header(this);
            this.Controls.Add(header);
            header.Dock = DockStyle.Top;

            // Initialize navigation buttons
            Button btnProducts = new Button { Text = "Products" };
            Button btnSales = new Button { Text = "Sales" };
            Button btnInvoices = new Button { Text = "Invoices" };

            // Add event handlers for navigation
            btnProducts.Click += (s, e) => ShowMessage("Products View");
            btnSales.Click += (s, e) => ShowMessage("Sales View");
            btnInvoices.Click += (s, e) => ShowMessage("Invoices View");

            // Add buttons to a panel or directly to the form
            FlowLayoutPanel panel = new FlowLayoutPanel { Dock = DockStyle.Top };
            panel.Controls.AddRange(new Control[] { btnProducts, btnSales, btnInvoices });
            this.Controls.Add(panel);
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
