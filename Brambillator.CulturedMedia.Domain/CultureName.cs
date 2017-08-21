using Brambillator.CulturedMedia.Domain.Exceptions;
using Brambillator.CulturedMedia.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Brambillator.CulturedMedia.Domain
{
    /// <summary>
    /// Class for dealing with culture names.
    /// </summary>
    public class CultureName
    {
        #region Constants
        public const string Afrikaans_SouthAfrica = "af-ZA";
        public const string Albanian_Albania = "sq-AL";
        public const string Arabic_Algeria = "ar-DZ";
        public const string Arabic_Bahrain = "ar-BH";
        public const string Arabic_Egypt = "ar-EG";
        public const string Arabic_Iraq = "ar-IQ";
        public const string Arabic_Jordan = "ar-JO";
        public const string Arabic_Kuwait = "ar-KW";
        public const string Arabic_Lebanon = "ar-LB";
        public const string Arabic_Libya = "ar-LY";
        public const string Arabic_Morocco = "ar-MA";
        public const string Arabic_Oman = "ar-OM";
        public const string Arabic_Qatar = "ar-QA";
        public const string Arabic_SaudiArabia = "ar-SA";
        public const string Arabic_Syria = "ar-SY";
        public const string Arabic_Tunisia = "ar-TN";
        public const string Arabic_UnitedArabEmirates = "ar-AE";
        public const string Arabic_Yemen = "ar-YE";
        public const string Armenian_Armenia = "hy-AM";
        public const string Azeri_Cyrillic_Azerbaijan = "Cy-az-AZ";
        public const string Azeri_Latin_Azerbaijan = "Lt-az-AZ";
        public const string Basque_Basque = "eu-ES";
        public const string Belarusian_Belarus = "be-BY";
        public const string Bulgarian_Bulgaria = "bg-BG";
        public const string Catalan_Catalan = "ca-ES";
        public const string Chinese_China = "zh-CN";
        public const string Chinese_HongKong_SAR = "zh-HK";
        public const string Chinese_MacauSAR = "zh-MO";
        public const string Chinese_Singapore = "zh-SG";
        public const string Chinese_Taiwan = "zh-TW";
        public const string Chinese_Simplified = "zh-CHS";
        public const string Chinese_Traditional = "zh-CHT";
        public const string Croatian_Croatia = "hr-HR";
        public const string Czech_CzechRepublic = "cs-CZ";
        public const string Danish_Denmark = "da-DK";
        public const string Dhivehi_Maldives = "div-MV";
        public const string Dutch_Belgium = "nl-BE";
        public const string Dutch_TheNetherlands = "nl-NL";
        public const string English_Australia = "en-AU";
        public const string English_Belize = "en-BZ";
        public const string English_Canada = "en-CA";
        public const string English_Caribbean = "en-CB";
        public const string English_Ireland = "en-IE";
        public const string English_Jamaica = "en-JM";
        public const string English_NewZealand = "en-NZ";
        public const string English_Philippines = "en-PH";
        public const string English_SouthAfrica = "en-ZA";
        public const string English_TrinidadAndTobago = "en-TT";
        public const string English_UnitedKingdom = "en-GB";
        public const string English_UnitedStates = "en-US";
        public const string English_Zimbabwe = "en-ZW";
        public const string Estonian_Estonia = "et-EE";
        public const string Faroese_FaroeIslands = "fo-FO";
        public const string Farsi_Iran = "fa-IR";
        public const string Finnish_Finland = "fi-FI";
        public const string French_Belgium = "fr-BE";
        public const string French_Canada = "fr-CA";
        public const string French_France = "fr-FR";
        public const string French_Luxembourg = "fr-LU";
        public const string French_Monaco = "fr-MC";
        public const string French_Switzerland = "fr-CH";
        public const string Galician_Galician = "gl-ES";
        public const string Georgian_Georgia = "ka-GE";
        public const string German_Austria = "de-AT";
        public const string German_Germany = "de-DE";
        public const string German_Liechtenstein = "de-LI";
        public const string German_Luxembourg = "de-LU";
        public const string German_Switzerland = "de-CH";
        public const string Greek_Greece = "el-GR";
        public const string Gujarati_India = "gu-IN";
        public const string Hebrew_Israel = "he-IL";
        public const string Hindi_India = "hi-IN";
        public const string Hungarian_Hungary = "hu-HU";
        public const string Icelandic_Iceland = "is-IS";
        public const string Indonesian_Indonesia = "id-ID";
        public const string Italian_Italy = "it-IT";
        public const string Italian_Switzerland = "it-CH";
        public const string Japanese_Japan = "ja-JP";
        public const string Kannada_India = "kn-IN";
        public const string Kazakh_Kazakhstan = "kk-KZ";
        public const string Konkani_India = "kok-IN";
        public const string Korean_Korea = "ko-KR";
        public const string Kyrgyz_Kazakhstan = "ky-KZ";
        public const string Latvian_Latvia = "lv-LV";
        public const string Lithuanian_Lithuania = "lt-LT";
        public const string Macedonian_FYROM = "mk-MK";
        public const string Malay_Brunei = "ms-BN";
        public const string Malay_Malaysia = "ms-MY";
        public const string Marathi_India = "mr-IN";
        public const string Mongolian_Mongolia = "mn-MN";
        public const string Norwegian_Bokmal_Norway = "nb-NO";
        public const string Norwegian_Nynorsk_Norway = "nn-NO";
        public const string Polish_Poland = "pl-PL";
        public const string Portuguese_Brazil = "pt-BR";
        public const string Portuguese_Portugal = "pt-PT";
        public const string Punjabi_India = "pa-IN";
        public const string Romanian_Romania = "ro-RO";
        public const string Russian_Russia = "ru-RU";
        public const string Sanskrit_India = "sa-IN";
        public const string Serbian_Cyrillic_Serbia = "Cy-sr-SP";
        public const string Serbian_Latin_Serbia = "Lt-sr-SP";
        public const string Slovak_Slovakia = "sk-SK";
        public const string Slovenian_Slovenia = "sl-SI";
        public const string Spanish_Argentina = "es-AR";
        public const string Spanish_Bolivia = "es-BO";
        public const string Spanish_Chile = "es-CL";
        public const string Spanish_Colombia = "es-CO";
        public const string Spanish_CostaRica = "es-CR";
        public const string Spanish_DominicanRepublic = "es-DO";
        public const string Spanish_Ecuador = "es-EC";
        public const string Spanish_ElSalvador = "es-SV";
        public const string Spanish_Guatemala = "es-GT";
        public const string Spanish_Honduras = "es-HN";
        public const string Spanish_Mexico = "es-MX";
        public const string Spanish_Nicaragua = "es-NI";
        public const string Spanish_Panama = "es-PA";
        public const string Spanish_Paraguay = "es-PY";
        public const string Spanish_Peru = "es-PE";
        public const string Spanish_PuertoRico = "es-PR";
        public const string Spanish_Spain = "es-ES";
        public const string Spanish_Uruguay = "es-UY";
        public const string Spanish_Venezuela = "es-VE";
        public const string Swahili_Kenya = "sw-KE";
        public const string Swedish_Finland = "sv-FI";
        public const string Swedish_Sweden = "sv-SE";
        public const string Syriac_Syria = "syr-SY";
        public const string Tamil_India = "ta-IN";
        public const string Tatar_Russia = "tt-RU";
        public const string Telugu_India = "te-IN";
        public const string Thai_Thailand = "th-TH";
        public const string Turkish_Turkey = "tr-TR";
        public const string Ukrainian_Ukraine = "uk-UA";
        public const string Urdu_Pakistan = "ur-PK";
        public const string Uzbek_Cyrillic_Uzbekistan = "Cy-uz-UZ";
        public const string Uzbek_Latin_Uzbekistan = "Lt-uz-UZ";
        public const string Vietnamese_Vietnam = "vi-VN";
        #endregion

        private static CultureModel[] allCultures;

        static CultureName()
        {
            List<CultureModel> cultures = new List<CultureModel>();
            

            #region Initialize dictionary
            cultures.Add(new CultureModel("af", "ZA", "af-ZA", "Afrikaans - South Africa"));
            cultures.Add(new CultureModel("sq", "AL", "sq-AL", "Albanian - Albania"));
            cultures.Add(new CultureModel("ar", "DZ", "ar-DZ", "Arabic - Algeria"));
            cultures.Add(new CultureModel("ar", "BH", "ar-BH", "Arabic - Bahrain"));
            cultures.Add(new CultureModel("ar", "EG", "ar-EG", "Arabic - Egypt"));
            cultures.Add(new CultureModel("ar", "IQ", "ar-IQ", "Arabic - Iraq"));
            cultures.Add(new CultureModel("ar", "JO", "ar-JO", "Arabic - Jordan"));
            cultures.Add(new CultureModel("ar", "KW", "ar-KW", "Arabic - Kuwait"));
            cultures.Add(new CultureModel("ar", "LB", "ar-LB", "Arabic - Lebanon"));
            cultures.Add(new CultureModel("ar", "LY", "ar-LY", "Arabic - Libya"));
            cultures.Add(new CultureModel("ar", "MA", "ar-MA", "Arabic - Morocco"));
            cultures.Add(new CultureModel("ar", "OM", "ar-OM", "Arabic - Oman"));
            cultures.Add(new CultureModel("ar", "QA", "ar-QA", "Arabic - Qatar"));
            cultures.Add(new CultureModel("ar", "SA", "ar-SA", "Arabic - Saudi Arabia"));
            cultures.Add(new CultureModel("ar", "SY", "ar-SY", "Arabic - Syria"));
            cultures.Add(new CultureModel("ar", "TN", "ar-TN", "Arabic - Tunisia"));
            cultures.Add(new CultureModel("ar", "AE", "ar-AE", "Arabic - United Arab Emirates"));
            cultures.Add(new CultureModel("ar", "YE", "ar-YE", "Arabic - Yemen"));
            cultures.Add(new CultureModel("hy", "AM", "hy-AM", "Armenian - Armenia"));
            cultures.Add(new CultureModel("Cy-az", "AZ", "Cy-az-AZ", "Azeri (Cyrillic) - Azerbaijan"));
            cultures.Add(new CultureModel("Lt-az", "AZ", "Lt-az-AZ", "Azeri (Latin) - Azerbaijan"));
            cultures.Add(new CultureModel("eu", "ES", "eu-ES", "Basque - Basque"));
            cultures.Add(new CultureModel("be", "BY", "be-BY", "Belarusian - Belarus"));
            cultures.Add(new CultureModel("bg", "BG", "bg-BG", "Bulgarian - Bulgaria"));
            cultures.Add(new CultureModel("ca", "ES", "ca-ES", "Catalan - Catalan"));
            cultures.Add(new CultureModel("zh", "CN", "zh-CN", "Chinese - China"));
            cultures.Add(new CultureModel("zh", "HK", "zh-HK", "Chinese - Hong Kong SAR"));
            cultures.Add(new CultureModel("zh", "MO", "zh-MO", "Chinese - Macau SAR"));
            cultures.Add(new CultureModel("zh", "SG", "zh-SG", "Chinese - Singapore"));
            cultures.Add(new CultureModel("zh", "TW", "zh-TW", "Chinese - Taiwan"));
            cultures.Add(new CultureModel("zh", "CHS", "zh-CHS", "Chinese (Simplified)"));
            cultures.Add(new CultureModel("zh", "CHT", "zh-CHT", "Chinese (Traditional)"));
            cultures.Add(new CultureModel("hr", "HR", "hr-HR", "Croatian - Croatia"));
            cultures.Add(new CultureModel("cs", "CZ", "cs-CZ", "Czech - Czech Republic"));
            cultures.Add(new CultureModel("da", "DK", "da-DK", "Danish - Denmark"));
            cultures.Add(new CultureModel("div", "MV", "div-MV", "Dhivehi - Maldives"));
            cultures.Add(new CultureModel("nl", "BE", "nl-BE", "Dutch - Belgium"));
            cultures.Add(new CultureModel("nl", "NL", "nl-NL", "Dutch - The Netherlands"));
            cultures.Add(new CultureModel("en", "AU", "en-AU", "English - Australia"));
            cultures.Add(new CultureModel("en", "BZ", "en-BZ", "English - Belize"));
            cultures.Add(new CultureModel("en", "CA", "en-CA", "English - Canada"));
            cultures.Add(new CultureModel("en", "CB", "en-CB", "English - Caribbean"));
            cultures.Add(new CultureModel("en", "IE", "en-IE", "English - Ireland"));
            cultures.Add(new CultureModel("en", "JM", "en-JM", "English - Jamaica"));
            cultures.Add(new CultureModel("en", "NZ", "en-NZ", "English - New Zealand"));
            cultures.Add(new CultureModel("en", "PH", "en-PH", "English - Philippines"));
            cultures.Add(new CultureModel("en", "ZA", "en-ZA", "English - South Africa"));
            cultures.Add(new CultureModel("en", "TT", "en-TT", "English - Trinidad and Tobago"));
            cultures.Add(new CultureModel("en", "GB", "en-GB", "English - United Kingdom"));
            cultures.Add(new CultureModel("en", "US", "en-US", "English - United States"));
            cultures.Add(new CultureModel("en", "ZW", "en-ZW", "English - Zimbabwe"));
            cultures.Add(new CultureModel("et", "EE", "et-EE", "Estonian - Estonia"));
            cultures.Add(new CultureModel("fo", "FO", "fo-FO", "Faroese - Faroe Islands"));
            cultures.Add(new CultureModel("fa", "IR", "fa-IR", "Farsi - Iran"));
            cultures.Add(new CultureModel("fi", "FI", "fi-FI", "Finnish - Finland"));
            cultures.Add(new CultureModel("fr", "BE", "fr-BE", "French - Belgium"));
            cultures.Add(new CultureModel("fr", "CA", "fr-CA", "French - Canada"));
            cultures.Add(new CultureModel("fr", "FR", "fr-FR", "French - France"));
            cultures.Add(new CultureModel("fr", "LU", "fr-LU", "French - Luxembourg"));
            cultures.Add(new CultureModel("fr", "MC", "fr-MC", "French - Monaco"));
            cultures.Add(new CultureModel("fr", "CH", "fr-CH", "French - Switzerland"));
            cultures.Add(new CultureModel("gl", "ES", "gl-ES", "Galician - Galician"));
            cultures.Add(new CultureModel("ka", "GE", "ka-GE", "Georgian - Georgia"));
            cultures.Add(new CultureModel("de", "AT", "de-AT", "German - Austria"));
            cultures.Add(new CultureModel("de", "DE", "de-DE", "German - Germany"));
            cultures.Add(new CultureModel("de", "LI", "de-LI", "German - Liechtenstein"));
            cultures.Add(new CultureModel("de", "LU", "de-LU", "German - Luxembourg"));
            cultures.Add(new CultureModel("de", "CH", "de-CH", "German - Switzerland"));
            cultures.Add(new CultureModel("el", "GR", "el-GR", "Greek - Greece"));
            cultures.Add(new CultureModel("gu", "IN", "gu-IN", "Gujarati - India"));
            cultures.Add(new CultureModel("he", "IL", "he-IL", "Hebrew - Israel"));
            cultures.Add(new CultureModel("hi", "IN", "hi-IN", "Hindi - India"));
            cultures.Add(new CultureModel("hu", "HU", "hu-HU", "Hungarian - Hungary"));
            cultures.Add(new CultureModel("is", "IS", "is-IS", "Icelandic - Iceland"));
            cultures.Add(new CultureModel("id", "ID", "id-ID", "Indonesian - Indonesia"));
            cultures.Add(new CultureModel("it", "IT", "it-IT", "Italian - Italy"));
            cultures.Add(new CultureModel("it", "CH", "it-CH", "Italian - Switzerland"));
            cultures.Add(new CultureModel("ja", "JP", "ja-JP", "Japanese - Japan"));
            cultures.Add(new CultureModel("kn", "IN", "kn-IN", "Kannada - India"));
            cultures.Add(new CultureModel("kk", "KZ", "kk-KZ", "Kazakh - Kazakhstan"));
            cultures.Add(new CultureModel("oko", "IN", "kok-IN", "Konkani - India"));
            cultures.Add(new CultureModel("ko", "KR", "ko-KR", "Korean - Korea"));
            cultures.Add(new CultureModel("ky", "KZ", "ky-KZ", "Kyrgyz - Kazakhstan"));
            cultures.Add(new CultureModel("lv", "LV", "lv-LV", "Latvian - Latvia"));
            cultures.Add(new CultureModel("lt", "LT", "lt-LT", "Lithuanian - Lithuania"));
            cultures.Add(new CultureModel("mk", "MK", "mk-MK", "Macedonian (FYROM)"));
            cultures.Add(new CultureModel("ms", "BN", "ms-BN", "Malay - Brunei"));
            cultures.Add(new CultureModel("ms", "MY", "ms-MY", "Malay - Malaysia"));
            cultures.Add(new CultureModel("mr", "IN", "mr-IN", "Marathi - India"));
            cultures.Add(new CultureModel("mn", "MN", "mn-MN", "Mongolian - Mongolia"));
            cultures.Add(new CultureModel("nb", "NO", "nb-NO", "Norwegian (Bokmål) - Norway"));
            cultures.Add(new CultureModel("nn", "NO", "nn-NO", "Norwegian (Nynorsk) - Norway"));
            cultures.Add(new CultureModel("pl", "PL", "pl-PL", "Polish - Poland"));
            cultures.Add(new CultureModel("pt", "BR", "pt-BR", "Portuguese - Brazil"));
            cultures.Add(new CultureModel("pt", "PT", "pt-PT", "Portuguese - Portugal"));
            cultures.Add(new CultureModel("pa", "IN", "pa-IN", "Punjabi - India"));
            cultures.Add(new CultureModel("ro", "RO", "ro-RO", "Romanian - Romania"));
            cultures.Add(new CultureModel("ru", "RU", "ru-RU", "Russian - Russia"));
            cultures.Add(new CultureModel("sa", "IN", "sa-IN", "Sanskrit - India"));
            cultures.Add(new CultureModel("Cy-sr", "SP", "Cy-sr-SP", "Serbian (Cyrillic) - Serbia"));
            cultures.Add(new CultureModel("Lt-sr", "SP", "Lt-sr-SP", "Serbian (Latin) - Serbia"));
            cultures.Add(new CultureModel("sk", "SK", "sk-SK", "Slovak - Slovakia"));
            cultures.Add(new CultureModel("sl", "SI", "sl-SI", "Slovenian - Slovenia"));
            cultures.Add(new CultureModel("es", "AR", "es-AR", "Spanish - Argentina"));
            cultures.Add(new CultureModel("es", "BO", "es-BO", "Spanish - Bolivia"));
            cultures.Add(new CultureModel("es", "CL", "es-CL", "Spanish - Chile"));
            cultures.Add(new CultureModel("es", "CO", "es-CO", "Spanish - Colombia"));
            cultures.Add(new CultureModel("es", "CR", "es-CR", "Spanish - Costa Rica"));
            cultures.Add(new CultureModel("es", "DO", "es-DO", "Spanish - Dominican Republic"));
            cultures.Add(new CultureModel("es", "EC", "es-EC", "Spanish - Ecuador"));
            cultures.Add(new CultureModel("es", "SV", "es-SV", "Spanish - El Salvador"));
            cultures.Add(new CultureModel("es", "GT", "es-GT", "Spanish - Guatemala"));
            cultures.Add(new CultureModel("es", "HN", "es-HN", "Spanish - Honduras"));
            cultures.Add(new CultureModel("es", "MX", "es-MX", "Spanish - Mexico"));
            cultures.Add(new CultureModel("es", "NI", "es-NI", "Spanish - Nicaragua"));
            cultures.Add(new CultureModel("es", "PA", "es-PA", "Spanish - Panama"));
            cultures.Add(new CultureModel("es", "PY", "es-PY", "Spanish - Paraguay"));
            cultures.Add(new CultureModel("es", "PE", "es-PE", "Spanish - Peru"));
            cultures.Add(new CultureModel("es", "PR", "es-PR", "Spanish - Puerto Rico"));
            cultures.Add(new CultureModel("es", "ES", "es-ES", "Spanish - Spain"));
            cultures.Add(new CultureModel("es", "UY", "es-UY", "Spanish - Uruguay"));
            cultures.Add(new CultureModel("es", "VE", "es-VE", "Spanish - Venezuela"));
            cultures.Add(new CultureModel("sw", "KE", "sw-KE", "Swahili - Kenya"));
            cultures.Add(new CultureModel("sv", "FI", "sv-FI", "Swedish - Finland"));
            cultures.Add(new CultureModel("sv", "SE", "sv-SE", "Swedish - Sweden"));
            cultures.Add(new CultureModel("syr", "SY", "syr-SY", "Syriac - Syria"));
            cultures.Add(new CultureModel("ta", "IN", "ta-IN", "Tamil - India"));
            cultures.Add(new CultureModel("tt", "RU", "tt-RU", "Tatar - Russia"));
            cultures.Add(new CultureModel("te", "IN", "te-IN", "Telugu - India"));
            cultures.Add(new CultureModel("th", "TH", "th-TH", "Thai - Thailand"));
            cultures.Add(new CultureModel("tr", "TR", "tr-TR", "Turkish - Turkey"));
            cultures.Add(new CultureModel("uk", "UA", "uk-UA", "Ukrainian - Ukraine"));
            cultures.Add(new CultureModel("ur", "PK", "ur-PK", "Urdu - Pakistan"));
            cultures.Add(new CultureModel("Cy-uz", "UZ", "Cy-uz-UZ", "Uzbek (Cyrillic) - Uzbekistan"));
            cultures.Add(new CultureModel("Lt-uz", "UZ", "Lt-uz-UZ", "Uzbek (Latin) - Uzbekistan"));
            cultures.Add(new CultureModel("vi", "VN", "vi-VN", "Vietnamese - Vietnam"));
            #endregion

            allCultures = cultures.ToArray();
        }


        /// <summary>
        /// Get all valid cultures.
        /// </summary>
        /// <returns>Array of CultureModel.</returns>
        public static CultureModel[] GetValidCultures()
        {
            return allCultures;
        }

        /// <summary>
        /// Get a culture by CultureName.
        /// </summary>
        /// <param name="cultureName">Culture name. Ex: "en-US"</param>
        /// <returns>Description. Ex: "English - United States"</returns>
        public static CultureModel GetCultureByName(string cultureName)
        {
            return allCultures.Where(n => n.CultureName.Equals(cultureName)).FirstOrDefault();
        }

        /// <summary>
        /// Get all cultures for a given language.
        /// </summary>
        /// <param name="language">language part of a culture. Ex: "en"</param>
        /// <returns>All culture related. ex: "en-US", "en-CA", "en-UK" ... </returns>
        public static CultureModel[] FindCultureNames(string language)
        {
            return allCultures.Where(n => n.Language.Equals(language)).ToArray();
        }

        /// <summary>
        /// Retrieves the language part of a culture name.
        /// </summary>
        /// <param name="cultureName">Culture name. Ex: "en-US"</param>
        /// <returns>Language part. Ex: "en"</returns>
        public static string GetLanguagePart(string cultureName)
        {
            if (string.IsNullOrWhiteSpace(cultureName))
            {
                return string.Empty;
            }
            else
            {
                int lastSeparatorIndex = cultureName.LastIndexOf('-');
                if (lastSeparatorIndex < 1)
                {
                    return cultureName;
                }
                else
                {
                    return cultureName.Substring(0, lastSeparatorIndex);
                }
            }
        }

        /// <summary>
        /// Retrieves the local part of the culture name.
        /// </summary>
        /// <param name="cultureName">Culture name. Ex: "en-US"</param>
        /// <returns>Locarl part. Ex: "US"</returns>
        public static string GetLocalPart(string cultureName)
        {
            if (string.IsNullOrWhiteSpace(cultureName))
            {
                return string.Empty;
            }
            else
            {
                string localPart = string.Empty;

                int lastSeparatorIndex = cultureName.LastIndexOf('-');
                if (lastSeparatorIndex < 1)
                {
                    localPart = string.Empty;
                }
                else
                {
                    localPart = cultureName.Substring(lastSeparatorIndex+1);
                }

                // Check if local part exists


                return localPart;
            }
        }

        /// <summary>
        /// Validate culture name or language.
        /// Raises: UnsupportedCultureException
        /// </summary>
        /// <param name="cultureNameOrLanguage">Culture name (ex: "en-US") or language (ex: "en")</param>
        /// <returns>Language (Key) / local or string.Empty (value)</returns>
        public static KeyValuePair<string, string> ValidateCulture(string cultureNameOrLanguage)
        {
            string language = CultureName.GetLanguagePart(cultureNameOrLanguage);
            string local = CultureName.GetLocalPart(cultureNameOrLanguage);

            bool supportedCulture;
            if (string.IsNullOrWhiteSpace(local))
                supportedCulture = (CultureName.FindCultureNames(language).Length > 0);
            else
                supportedCulture = (CultureName.GetCultureByName(cultureNameOrLanguage) != null);

            if (!supportedCulture)
                throw new UnsupportedCultureException(language, local);

            return new KeyValuePair<string, string>(language, local);
        }

    }
}
