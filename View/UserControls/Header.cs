using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace View.UserControls
{
    /// <summary>
    /// Represents a header control that provides a button to switch between light and dark themes.
    /// </summary>
    public partial class Header : UserControl
    {
        /// <summary>
        /// The parent form that contains this header control.
        /// </summary>
        private BaseMaterialForm parentForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="Header"/> class.
        /// Configures the header with a reference to the parent form.
        /// </summary>
        /// <param name="parent">The parent form to which this header belongs.</param>
        public Header(BaseMaterialForm parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        /// <summary>
        /// Handles the Click event of the theme switch button.
        /// Toggles between the light and dark themes in the parent form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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
