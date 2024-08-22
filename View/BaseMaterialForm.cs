using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Represents a base form that integrates MaterialSkin for consistent theming across all derived forms.
    /// </summary>
    public class BaseMaterialForm : MaterialForm
    {
        /// <summary>
        /// The instance of the MaterialSkinManager that manages the theming and color scheme of the form.
        /// </summary>
        public MaterialSkinManager materialSkinManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMaterialForm"/> class.
        /// Configures the default theme and adds the form to the MaterialSkinManager.
        /// </summary>
        public BaseMaterialForm()
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ApplyLightTheme(); // Default theme
        }

        /// <summary>
        /// Applies the light theme to the form, including color scheme settings.
        /// </summary>
        public void ApplyLightTheme()
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        /// <summary>
        /// Applies the dark theme to the form, including color scheme settings.
        /// </summary>
        public void ApplyDarkTheme()
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey800, Primary.Grey900,
                Primary.Grey500, Accent.LightBlue200,
                TextShade.WHITE
            );
        }
    }
}
