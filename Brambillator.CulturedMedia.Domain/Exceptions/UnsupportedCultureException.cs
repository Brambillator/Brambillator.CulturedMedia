using System;

namespace Brambillator.CulturedMedia.Domain.Exceptions
{
    /// <summary>
    /// Indicates that a culture unsupported by the system was used.
    /// Probably by a incorrect Language or Local code.
    /// </summary>
    public class UnsupportedCultureException : Exception
    {
        /// <summary>
        /// CultureName used.
        /// </summary>
        public string CultureName { get; private set; }
        
        /// <summary>
        /// Language code used.
        /// </summary>
        public string Language { get; private set; }

        /// <summary>
        /// Local code used (or string.Empty)
        /// </summary>
        public string Local { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsupportedCultureException" /> class.
        /// </summary>
        /// <param name="language">Related language code.</param>
        /// <param name="local">Related local code or string.Empty.</param>
        public UnsupportedCultureException(string language, string local) : base("Culture or language not supported.") //base(StringResource.CultureOrLanguageNotSupported)
        {
            Language = language;
            Local = local;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsupportedCultureException" /> class.
        /// </summary>
        /// <param name="cultureName">Related culture name.</param>
        public UnsupportedCultureException(string cultureName) : base("Culture or language not supported.") //base(StringResource.CultureOrLanguageNotSupported)
        {
            CultureName = cultureName;
            Language = string.Empty;
            Local = string.Empty;
        }
    }
}
