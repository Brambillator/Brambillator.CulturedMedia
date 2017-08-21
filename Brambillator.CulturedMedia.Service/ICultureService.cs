using Brambillator.CulturedMedia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brambillator.CulturedMedia.Service
{
    public interface ICultureService : IDisposable
    {
        CultureModel[] GetValidCultures();
        CultureModel GetCultureByName(string cultureName);
        CultureModel[] FindCultureNames(string language);
    }
}
