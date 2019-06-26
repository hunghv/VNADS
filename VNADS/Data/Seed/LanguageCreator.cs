using System;
using System.Collections.Generic;
using Data.Entities;

namespace Data.Seed
{
    public class LanguageCreator
    {
        public static List<ApplicationLanguage> GetInitialLanguages()
        {
            return new List<ApplicationLanguage>
            {
                new ApplicationLanguage
                {
                    Id = 1,
                    Name = "en",
                    DisplayName = "English",
                    Icon = "famfamfam-flags gb",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 2,
                    Name = "ar",
                    DisplayName = "العربية",
                    Icon = "famfamfam-flags sa",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 3,
                    Name = "de",
                    DisplayName = "German",
                    Icon = "famfamfam-flags de",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 4,
                    Name = "it",
                    DisplayName = "Italiano",
                    Icon = "famfamfam-flags it",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 5,
                    Name = "fr",
                    DisplayName = "Français",
                    Icon = "famfamfam-flags fr",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 6,
                    Name = "pt-BR",
                    DisplayName = "Português",
                    Icon = "famfamfam-flags br",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 7,
                    Name = "tr",
                    DisplayName = "Türkçe",
                    Icon = "famfamfam-flags tr",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 8,
                    Name = "ru",
                    DisplayName = "Русский",
                    Icon = "famfamfam-flags ru",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 9,
                    Name = "zh-Hans",
                    DisplayName = "简体中文",
                    Icon = "famfamfam-flags cn",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 10,
                    Name = "es-MX",
                    DisplayName = "Español México",
                    Icon = "famfamfam-flags mx",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 11,
                    Name = "nl",
                    DisplayName = "Nederlands",
                    Icon = "famfamfam-flags nl",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 12,
                    Name = "ja",
                    DisplayName = "日本語",
                    Icon = "famfamfam-flags jp",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                },
                new ApplicationLanguage
                {
                    Id = 13,
                    Name = "vn",
                    DisplayName = "Viet Nam",
                    Icon = "famfamfam-flags vn",
                    CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false
                }
            };
        }
    }
}