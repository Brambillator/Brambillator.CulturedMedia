﻿using Brambillator.CulturedMedia.Domain;
using Brambillator.CulturedMedia.Domain.Exceptions;
using Brambillator.CulturedMedia.Domain.Lookups;
using Brambillator.CulturedMedia.Domain.Models;
using Brambillator.CulturedMedia.Domain.UnitOfWork;
using Brambillator.CulturedMedia.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Brambillator.CulturedMedia.Service
{
    /// <summary>
    /// Service for resource management.
    /// </summary>
    public class ResourceService : IResourceService
    {
        public ICulturedMediaUnitOfWork UnitOfWork { get; set; }

        public ResourceService(DbContextOptions options)
        {
            UnitOfWork = new EFCulturedMediaUnitOfWork(options);
        }

        public ResourceService(ICulturedMediaUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates a new text resource with given key for given CultureName or Language.
        /// </summary>
        /// <param name="cultureNameOrLanguage">Culture name OR Language. Ex.: 'en-US' for english specific for U.S. or 'en' for all locations that speaks english.</param>
        /// <param name="key">Unique identifier for this resource.</param>
        /// <param name="title">Resource Title.</param>
        /// <param name="text">Text body of resource.</param>
        public void AddTextResource(string cultureNameOrLanguage, string key, string title, string text)
        {
            // Culture validation
            KeyValuePair<string, string> pair = CultureName.ValidateCulture(cultureNameOrLanguage);
            string language = pair.Key;
            string local = pair.Value;

            // Validates the existence of this key for the Culture or the Language Set
            if (ExistKey(language, local, key))
                throw new DuplicateKeyException(key, language, local);

            ResourceModel newEntity = new ResourceModel();
            newEntity.Key = key;
            newEntity.CultureName_Language = language;
            newEntity.CultureName_Local = local;
            if (title != string.Empty) newEntity.Title = title;
            newEntity.Text = text;
            newEntity.ResourceType = ResourceType.Text;

            UnitOfWork.Resources.Add(newEntity);
        }

        /// <summary>
        /// Adds a resource or update existing one.
        /// </summary>
        /// <param name="cultureNameOrLanguage">Related culture code. Ex: en-US</param>
        /// <param name="resource">Ressource to add or update.</param>
        public void CreateOrUpdateResource(string cultureNameOrLanguage, Domain.Views.Resource resource)
        {
            // Culture validation
            KeyValuePair<string, string> pair = CultureName.ValidateCulture(cultureNameOrLanguage);
            string language = pair.Key;
            string local = pair.Value;

            ResourceModel e;
            e = UnitOfWork.Resources.AsQueryable()
                                    .Where(r => r.Key == resource.Key
                                        && r.CultureName_Language == language
                                        && r.CultureName_Local == local).FirstOrDefault();

            if (e == null)
            {
                e = new ResourceModel(local, language, resource);
                UnitOfWork.Resources.Add(e);
                e.State = Infrastructure.Domain.Models.EntityState.Added;
            }
            else
            {
                UnitOfWork.Resources.Attach(e);
                e.State = Infrastructure.Domain.Models.EntityState.Modified;
            }

            e.MediaPath = resource.MediaPath;
            e.ResourceType = resource.ResourceType;
            e.Text = resource.Text;
            e.Title = resource.Title;
        }

        /// <summary>
        /// Removes a resource from a specified culture.
        /// </summary>
        /// <param name="culture">Culture that "owns" the resource.</param>
        /// <param name="key">Resource key.</param>
        public void RemoveResource(string cultureName, string key)
        {
            CultureModel culture = CultureName.GetCultureByName(cultureName);

            ResourceModel res = UnitOfWork.Resources.AsQueryable()
                                    .Where(r => r.Key == key
                                        && r.CultureName_Language == culture.Language
                                        && r.CultureName_Local == culture.Local).FirstOrDefault();
            if (res != null)
                UnitOfWork.Resources.Remove(res);
        }

        /// <summary>
        /// Removes a resource from a specified culture.
        /// </summary>
        /// <param name="culture">Culture that "owns" the resource.</param>
        /// <param name="key">Resource key.</param>
        public void RemoveResource(CultureModel culture, string key)
        {
            ResourceModel res = UnitOfWork.Resources.AsQueryable()
                                    .Where(r => r.Key == key
                                        && r.CultureName_Language == culture.Language
                                        && r.CultureName_Local == culture.Local).FirstOrDefault();
            if (res != null)
                UnitOfWork.Resources.Remove(res);
        }

        /// <summary>
        /// Removes recources with specific key from all cultures.
        /// </summary>
        /// <param name="key">Resource key.</param>
        public void RemoveResourceForAllCultures(string key)
        {
            ResourceModel[] resourceList = UnitOfWork.Resources.AsQueryable().Where(r => r.Key == key).ToArray();

            foreach (var res in resourceList)
                UnitOfWork.Resources.Remove(res);
        }

        /// <summary>
        /// Get a resource by Key and CultureName.
        /// </summary>
        /// <param name="key">Resource Key.</param>
        /// <param name="cultureName">Full culture name.</param>
        /// <returns>Resource object.</returns>
        public Domain.Views.Resource GetResource(string cultureName, string key)
        {
            // Culture validation
            CultureModel culture = CultureName.GetCultureByName(cultureName);

            if (culture == null)
                throw new UnsupportedCultureException(cultureName);

            // Retrive by culture name
            ResourceModel res = UnitOfWork.Resources.AsQueryable()
                                    .Where(r => r.Key == key
                                        && r.CultureName_Language == culture.Language
                                        && r.CultureName_Local == culture.Local).FirstOrDefault();
            if (res != null)
                return res.ToViewModel();

            // If not found by culture name, get by language
            res = UnitOfWork.Resources.AsQueryable()
                                    .Where(r => r.Key == key
                                        && r.CultureName_Language == culture.Language
                                        && (r.CultureName_Local == string.Empty || r.CultureName_Local == culture.Local)).FirstOrDefault();
            if (res != null)
                return res.ToViewModel();
            else
                return new Domain.Views.Resource(cultureName, key);
        }

        /// <summary>
        /// Get a resource by Key and CultureName.
        /// </summary>
        /// <param name="key">Resource Key.</param>
        /// <param name="cultureName">Full culture name.</param>
        /// <returns>Resource object.</returns>
        public Domain.Views.Resource GetResourceExactCulture(string cultureName, string key)
        {
            // Culture validation
            CultureModel culture = CultureName.GetCultureByName(cultureName);

            if (culture == null)
                throw new UnsupportedCultureException(cultureName);

            // Retrive by culture name
            ResourceModel res = UnitOfWork.Resources.AsQueryable()
                                    .Where(r => r.Key == key
                                        && r.CultureName_Language == culture.Language
                                        && r.CultureName_Local == culture.Local).FirstOrDefault();
            if (res != null)
                return res.ToViewModel();
            else
                return new Domain.Views.Resource(cultureName, key);
        }

        /// <summary>
        /// Get the resource with given key for all languages.
        /// </summary>
        /// <param name="key">Resource Key.</param>
        /// <returns>Array of resources with same key.</returns>
        public Domain.Views.Resource[] GetResourceForAllCultures(string key)
        {
            Domain.Views.Resource[] resources =
                        UnitOfWork.Resources.AsQueryable()
                            .Where(r => r.Key == key)
                            .Select(v => new Domain.Views.Resource()
                            {
                                Key = v.Key,
                                MediaPath = v.MediaPath,
                                ResourceType = v.ResourceType,
                                Text = v.Text,
                                Title = v.Title
                            }).ToArray();

            return resources;
        }

        /// <summary>
        /// Checks the existence of the key by language or by language/local.
        /// </summary>
        /// <param name="language">Language part of culture name.</param>
        /// <param name="local">Local part of language name or string.empty for all locals.</param>
        /// <param name="context">Current context.</param>
        /// <param name="key">Key to verify.</param>
        /// <returns>Boolean indicator.</returns>
        public bool ExistKey(string language, string local, string key)
        {
            if (string.IsNullOrWhiteSpace(local))
                return UnitOfWork.Resources.AsQueryable().Any(r => r.Key == key);
            else
                return UnitOfWork.Resources.AsQueryable().Any(r => r.Key == key && r.CultureName_Language == language && r.CultureName_Local == local);
        }

        public void Dispose()
        {
            UnitOfWork = null;
        }
    }
}
