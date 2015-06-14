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
        /// The Picture.
        /// </param>
        /// <param name="Url">
        /// The url.
        /// </param>
        /// <param name="description">
        /// The Description.
        /// </param>
        public Advert(int id, string picture, string Url, string description)
        {
            this.ID = id;
            this.Picture = picture;
            this.Url = Url;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Picture.
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }
    }
}