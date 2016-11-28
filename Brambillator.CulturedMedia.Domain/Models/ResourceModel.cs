using Brambillator.CulturedMedia.Domain.Lookups;
using Brambillator.Infrastructure.Domain.Models;

namespace Brambillator.CulturedMedia.Domain.Models
{
    /// <summary>
    /// Represents a resource. Text or media, related to a specific culture.
    /// </summary>
    internal class ResourceModel : Entity
    {
        /// <summary>
        /// Alternate key, CultureName, Language part. Ex: "en" in "en-US" or "Cy-az" for "Cy-az-AZ" (Azeri Cyrillic Azerbaijan).
        /// </summary>
        public string CultureName_Language { get; set; }

        /// <summary>
        /// Alternate key, CultureName, Localization part. Ex: "US" in "en-US" or "AZ" for "Cy-az-AZ" (Azeri Cyrillic Azerbaijan).
        /// </summary>
        public string CultureName_Local { get; set; }

        /// <summary>
        /// Unique key, provided by user or client application, for identifying a resource.
        /// </summary>
        /// <value>String identifying the resource.</value>
        public string Key { get; set; }

        /// <summary>
        /// Title, identifying a text, or alternate to an image.
        /// </summary>
        /// <value>Small text representing resource title or image alternative text.</value>
        public string Title { get; set; }

        /// <summary>
        /// Path for media related to this resource. 
        /// </summary>
        /// <value>Path to a folder or url containing the media file.</value>
        public string MediaPath { get; set; }

        /// <summary>
        /// Enumerator that defines the type of resource.
        /// </summary>
        /// <value>Type of this resource.</value>
        public ResourceType ResourceType { get; set; }

        /// <summary>
        /// Resource text.
        /// </summary>
        /// <value>Text for this resource. Can be as big as a whole text.</value>
        public string Text { get; set; }

        /// <summary>
        /// Convert this to ViewModel object.
        /// </summary>
        /// <returns>Related ViewModel.</returns>
        public Views.Resource ToViewModel()
        {
            Views.Resource vm = new Views.Resource();

            vm.Key = this.Key;
            vm.Title = this.Title;
            vm.MediaPath = this.MediaPath;
            vm.ResourceType = this.ResourceType;
            vm.Text = this.Text;

            return vm;
        }
    }
}
