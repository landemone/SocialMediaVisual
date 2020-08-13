namespace SocialMedia.Core.DTOs
{
    using System;

    /// <summary>
    /// Defines the <see cref="PostDto" />.
    /// </summary>
    public class PostDto
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the Date.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public string Image { get; set; }
    }
}
