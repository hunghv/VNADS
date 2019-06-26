using System.Collections.Generic;
using Data.Entities.Host;

namespace Data.Seed
{
    public class LanguageCreator
    {
        public static List<ApplicationLanguage> GetInitialLanguages()
        {
            return new List<ApplicationLanguage>
            {
                new ApplicationLanguage(null, "en", "English", "famfamfam-flags gb"),
                new ApplicationLanguage(null, "ar", "العربية", "famfamfam-flags sa"),
                new ApplicationLanguage(null, "de", "German", "famfamfam-flags de"),
                new ApplicationLanguage(null, "it", "Italiano", "famfamfam-flags it"),
                new ApplicationLanguage(null, "fr", "Français", "famfamfam-flags fr"),
                new ApplicationLanguage(null, "pt-BR", "Português", "famfamfam-flags br"),
                new ApplicationLanguage(null, "tr", "Türkçe", "famfamfam-flags tr"),
                new ApplicationLanguage(null, "ru", "Русский", "famfamfam-flags ru"),
                new ApplicationLanguage(null, "zh-Hans", "简体中文", "famfamfam-flags cn"),
                new ApplicationLanguage(null, "es-MX", "Español México", "famfamfam-flags mx"),
                new ApplicationLanguage(null, "nl", "Nederlands", "famfamfam-flags nl"),
                new ApplicationLanguage(null, "ja", "日本語", "famfamfam-flags jp")
            };
        }
    }
}
