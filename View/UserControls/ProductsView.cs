using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            this.Dock = DockStyle.Fill;
            Label lbl = new Label
            {
                Text = "Productos View",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lbl);
        }
    }
}
