using MaterialSkin;
using View;

public static class ThemeManager
{
    public static MaterialSkinManager.Themes CurrentTheme { get; set; } = MaterialSkinManager.Themes.LIGHT;

    public static void ApplyTheme(BaseMaterialForm form)
    {
        form.materialSkinManager.Theme = CurrentTheme;
        if (CurrentTheme == MaterialSkinManager.Themes.LIGHT)
        {
            form.ApplyLightTheme();
        }
        else
        {
            form.ApplyDarkTheme();
        }
    }

    public static void ToggleTheme(BaseMaterialForm form)
    {
        if (CurrentTheme == MaterialSkinManager.Themes.LIGHT)
        {
            CurrentTheme = MaterialSkinManager.Themes.DARK;
        }
        else
        {
            CurrentTheme = MaterialSkinManager.Themes.LIGHT;
        }
        ApplyTheme(form);
    }
}
