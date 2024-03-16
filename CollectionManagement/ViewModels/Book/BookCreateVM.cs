using CollectionManagement.Models;

namespace CollectionManagement.ViewModels.Book
{
    public class BookCreateVM
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public string ImageUrl { get; set; }
        public int PublicationYear { get; set; }
        public Guid CollectionId { get; set; }

        public Models.Book MapToModel()
        {
            return new Models.Book()
            {
                Name = this.Name,
                Author = this.Author,
                Tag = this.Tag,
                ImageUrl = this.ImageUrl,
                PublicationYear = this.PublicationYear,
                CollectionId = this.CollectionId
            };
        }
    }
}
