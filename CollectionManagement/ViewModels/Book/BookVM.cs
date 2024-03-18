namespace CollectionManagement.ViewModels.Book
{
    public class BookVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public int PublicationYear { get; set; }
        public Guid CollectionId { get; set; }
        public string ImageSrc { get; set; } // Base64-encoded image source
    }
}
