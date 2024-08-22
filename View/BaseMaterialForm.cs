using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace View
{
    public class BaseMaterialForm : MaterialForm
    {
        protected MaterialSkinManager materialSkinManager;

        public BaseMaterialForm()
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ApplyLightTheme(); // Tema por defecto
        }

        public void ApplyLightTheme()
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

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
