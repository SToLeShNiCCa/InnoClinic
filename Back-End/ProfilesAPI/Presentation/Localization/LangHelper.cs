using System.Globalization;
using System.Reflection; 
using System.Resources;

namespace Application.Localization
{
    public class LangHelper
    {
        private static ResourceManager _rm;

        static LangHelper()
        {
            _rm = new ResourceManager("Application.Localization.Lang", Assembly.GetExecutingAssembly());
        }
        public static string? GetString(string name)
        {
            return _rm.GetString(name);
        }

        public static void ChangeLanguage(string language)
        {
            CultureInfo culture = new CultureInfo(language);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
    }
}
