using System;
using System.Drawing;
using System.IO;
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
        /// <summary>
        /// Panel that is displayed when no tabs are open.
        /// </summary>
        private Panel defaultPanel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// Configures the main UI components and initializes event handlers.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            ThemeManager.ApplyTheme(this);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 600);

            // Initialize the default panel
            InitializeDefaultPanel();

            // Enable custom drawing for tabs to add close buttons
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += tabControl_DrawItem;
            tabControl.MouseDown += tabControl_MouseDown;

            // Subscribe to events from Header
            header.ProductsClicked += (s, e) => OpenTab("Productos      ", new ProductsView());
            header.SalesClicked += (s, e) => OpenTab("Ventas       ", new SalesView());
            header.InvoicesClicked += (s, e) => OpenTab("Facturas      ", new InvoicesView());

            header.SetButtonVisibility(isLoginScreen: false);
        }

        /// <summary>
        /// Initializes the default panel that is displayed when no tabs are open.
        /// Attempts to load a background image from a predefined path.
        /// </summary>
        private void InitializeDefaultPanel()
        {
            defaultPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = true
            };

            // Get the path of the background image
            //string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "mainform_background.png");

            //if (File.Exists(imagePath))
            //{
            //    defaultPanel.BackgroundImage = Image.FromFile(imagePath);
            //    defaultPanel.BackgroundImageLayout = ImageLayout.Stretch; // Supports resizing
            //}
            //else
            //{
            //    MessageBox.Show($"Background image not found at:\n{imagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            this.Controls.Add(defaultPanel);
            defaultPanel.BringToFront();
        }

        /// <summary>
        /// Opens a new tab or selects an existing one.
        /// If the tab is already open, it brings the existing tab to the front.
        /// </summary>
        /// <param name="tabName">The name of the tab to open.</param>
        /// <param name="view">The <see cref="UserControl"/> to display in the tab.</param>
        private void OpenTab(string tabName, UserControl view)
        {
            // Hide the default panel when a tab is opened
            defaultPanel.Visible = false;

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
        /// Adds a red "x" at the end of the tab title.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data that provides information about the drawing.</param>
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
        /// Handles the <see cref="MouseDown"/> event to close the tab when the close button is clicked.
        /// If no tabs remain, the default panel is shown.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data that provides information about the mouse click.</param>
        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                Rectangle closeButtonRect = (Rectangle)tabControl.TabPages[i].Tag;
                if (closeButtonRect.Contains(e.Location))
                {
                    tabControl.TabPages.RemoveAt(i);

                    // Show the default panel if no tabs are open
                    if (tabControl.TabPages.Count == 0)
                    {
                        defaultPanel.Visible = true;
                    }
                    break;
                }
            }
        }
    }
}
