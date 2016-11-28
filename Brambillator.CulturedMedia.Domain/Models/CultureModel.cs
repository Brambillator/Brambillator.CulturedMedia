using Brambillator.Infrastructure.Domain.Models;

namespace Brambillator.CulturedMedia.Domain.Models
{
    /// <summary>
    /// Small class for use as a culture identifier.
    /// </summary>
    public class CultureModel : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CultureModel" /> class.
        /// </summary>
        public CultureModel()
        {
            CultureName = string.Empty;
            Language = string.Empty;
            Local = string.Empty;
            Description = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CultureModel" /> class.
        /// </summary>
        /// <param name="language">Language part of CultureName.</param>
        /// <param name="local">Local part of CultureName.</param>
        /// <param name="cultureName">Standard culture name.</param>
        /// <param name="description">Culture description.</param>
        public CultureModel(string language, string local, string cultureName, string description)
        {
            CultureName = cultureName;
            Language = language;
            Local = local;
            Description = description;
        }

        /// <summary>
        /// Culture name.
        /// </summary>
        /// <value>Ex: "en-US".</value>
        public string CultureName { get; set; }

        /// <summary>
        /// Language part of the culture.
        /// </summary>
        /// <value>Ex.: "en".</value>
        public string Language { get; set; }

        /// <summary>
        /// Local part of the culture.
        /// </summary>
        /// <value>Ex.: "US".</value>
        public string Local { get; set; }

        /// <summary>
        /// Language descritption.
        /// </summary>
        /// <value>Ex.: "English (United States)".</value>
        public string Description { get; set; }
    }
}
