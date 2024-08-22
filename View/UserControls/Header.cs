using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace View.UserControls
{
    public partial class Header : UserControl
    {
        private BaseMaterialForm parentForm;

        public Header(BaseMaterialForm parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void btnThemeSwitch_Click(object sender, EventArgs e)
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
    }
}
