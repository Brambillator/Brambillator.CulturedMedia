using Brambillator.CulturedMedia.Domain.Models;
using Brambillator.CulturedMedia.Domain.Views;
using System;

namespace Brambillator.CulturedMedia.Service
{
    public interface IResourceService : IDisposable
    {
        void AddTextResource(string cultureNameOrLanguage, string key, string title, string text);
        void CreateOrUpdateResource(string cultureNameOrLanguage, Domain.Views.Resource resource);
        void RemoveResource(string cultureName, string key);
        void RemoveResource(CultureModel culture, string key);
        void RemoveResourceForAllCultures(string key);
        Resource GetResource(string cultureName, string key);
        Resource GetResourceExactCulture(string cultureName, string key);
        Resource[] GetResourceForAllCultures(string key);
        bool ExistKey(string language, string local, string key);
    }
}
