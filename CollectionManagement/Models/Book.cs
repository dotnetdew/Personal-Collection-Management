namespace CollectionManagement.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; } //Description of the Book
        public int PublicationYear { get; set; }
        public virtual Guid CollectionId { get; set; }
        public virtual MyCollection Collection { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}