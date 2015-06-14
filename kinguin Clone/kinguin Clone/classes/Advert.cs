// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Advert.cs" company="">
//   
// </copyright>
// <summary>
//   The advert.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace kinguin_Clone.classes
{
    /// <summary>
    /// The advert.
    /// </summary>
    public class Advert
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Advert"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="picture">
        /// The picture.
        /// </param>
        /// <param name="Url">
        /// The url.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        public Advert(int id, string picture, string Url, string description)
        {
            this.ID = id;
            this.picture = picture;
            this.Url = Url;
            this.description = description;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        public string picture { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string description { get; set; }
    }
}