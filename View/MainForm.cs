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

            // Enable custom drawing for tabs to add close buttons
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += new DrawItemEventHandler(tabControl_DrawItem);
            tabControl.MouseDown += new MouseEventHandler(tabControl_MouseDown);

            // Suscribe to events from Header
            header.ProductsClicked += (s, e) => OpenTab("Productos      ", new ProductsView());
            header.SalesClicked += (s, e) => OpenTab("Ventas       ", new SalesView());
            header.InvoicesClicked += (s, e) => OpenTab("Facturas      ", new InvoicesView());

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
            TabPage newTab = new TabPage(tabName);

            view.Dock = DockStyle.Fill;
            newTab.Controls.Add(view);
            tabControl.TabPages.Add(newTab);
            tabControl.SelectedTab = newTab;
        }

        /// <summary>
        /// Custom drawing of tabs to include a close button.
        /// </summary>
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);

            // Define the padding for the close button
            int closeButtonSize = 15;
            int textPadding = closeButtonSize + 10; // Adding extra space for the close button

            // Draw the tab text with some padding
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                new Rectangle(tabRect.X, tabRect.Y, tabRect.Width - textPadding, tabRect.Height),
                Color.Black, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

            // Calculate the rectangle for the close button
            Rectangle closeButtonRect = new Rectangle(
                tabRect.Right - closeButtonSize - 5,
                tabRect.Top + (tabRect.Height - closeButtonSize) / 2,
                closeButtonSize,
                closeButtonSize);

            // Draw the close button ("x")
            TextRenderer.DrawText(e.Graphics, "x", tabPage.Font, closeButtonRect, Color.Red);

            // Store the rectangle in the Tag property of the TabPage
            tabPage.Tag = closeButtonRect;
        }

        /// <summary>
        /// Handles the MouseDown event to close the tab when the close button is clicked.
        /// </summary>
        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                Rectangle closeButtonRect = (Rectangle)tabControl.TabPages[i].Tag;
                if (closeButtonRect.Contains(e.Location))
                {
                    tabControl.TabPages.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
