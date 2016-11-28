namespace Brambillator.CulturedMedia.Domain.Lookups
{
    /// <summary>
    /// Resource type enumerator.
    /// </summary>
    public enum ResourceType : short
    {
        /// <summary>
        /// Resource represents a string text.
        /// </summary>
        Text = 0,

        /// <summary>
        /// Resource media path points to an image file.
        /// </summary>
        Image = 1,

        /// <summary>
        /// Resource media path points to a video file or stream.
        /// </summary>
        Video = 2
    }
}
