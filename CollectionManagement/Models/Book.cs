using CollectionManagement.Enums;

namespace CollectionManagement.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; } //Description of the Book
        public string ImageUrl { get; set; }
        public int PublicationYear { get; set; }
        public Guid CollectionId { get; set; }
        public virtual MyCollection Collection { get; set; }
    }
}