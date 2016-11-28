using System;

namespace Brambillator.CulturedMedia.Domain.Exceptions
{
    /// <summary>
    /// Indicates that a resource with a pair of Languages/Key or Language-Local/Key is already in use.
    /// </summary>
    public class DuplicateKeyException : Exception
    {
        /// <summary>
        /// Key identifying a resource.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Language code.
        /// </summary>
        public string Language { get; private set; }

        /// <summary>
        /// Local or string.Empty.
        /// </summary>
        public string Local { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateKeyException" /> class.
        /// </summary>
        /// <param name="key">Related Key;</param>
        /// <param name="language">Related language code;</param>
        /// <param name="local">Related local code or string.Empty;</param>
        public DuplicateKeyException(string key, string language, string local) : base("Duplicated key for this culture code.") //base(StringResource.DuplicatedKeyForKeyOrCultureSet)
        {
            Key = key;
            Language = language;
            Local = local;
        }
    }
}
