using System;
using System.Collections.Generic;
using System.Text;
using Brambillator.CulturedMedia.Domain.Models;
using Brambillator.CulturedMedia.Domain;

namespace Brambillator.CulturedMedia.Service
{
    public class CultureService : ICultureService
    {
        public void Dispose() { }

        public CultureModel[] FindCultureNames(string language)
        {
            return CultureName.FindCultureNames(language);
        }

        public CultureModel GetCultureByName(string cultureName)
        {
            return CultureName.GetCultureByName(cultureName);
        }

        public CultureModel[] GetValidCultures()
        {
            return CultureName.GetValidCultures();
        }
    }
}
