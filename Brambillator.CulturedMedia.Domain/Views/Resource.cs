using Brambillator.CulturedMedia.Domain.Lookups;

namespace Brambillator.CulturedMedia.Domain.Views
{
    /// <summary>
    /// View for ResourceModel.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Resource" /> class.
        /// </summary>
        public Resource()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource" /> class where Title and Text will be initialized with key value.
        /// </summary>
        /// <param name="key">Value for unique key.</param>
        public Resource(string key)
        {
            Key = key;
            Title = key;
            Text = key;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource" /> with specified values.
        /// </summary>
        /// <param name="key">Value for unique key.</param>
        /// <param name="title">Title text.</param>
        /// <param name="text">Text content.</param>
        public Resource(string key, string title, string text)
        {
            Key = key;
            Title = title;
            Text = text;
        }

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
    }
}
