namespace Brambillator.CulturedMedia.Domain.Views
{
    /// <summary>
    /// Small class for text resource data.
    /// </summary>
    public class TextResource
    {
        /// <summary>
        /// Resource identifier.
        /// </summary>
        /// <value>Unique identifier.</value>
        public string Key { get; set; }

        /// <summary>
        /// Title, identifying a text, or alternate to an image.
        /// </summary>
        /// <value>Small text representing resource title or image alternative text.</value>
        public string Title { get; set; }

        /// <summary>
        /// Resource text.
        /// </summary>
        /// <value>Text for this resource. Can be as big as a whole text.</value>
        public string Text { get; set; }
    }
}
