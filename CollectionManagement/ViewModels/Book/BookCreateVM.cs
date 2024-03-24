namespace CollectionManagement.ViewModels.Book
{
    public class BookCreateVM
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public int PublicationYear { get; set; }
        public Guid CollectionId { get; set; }
        public IFormFile ImageFile { get; set; }

        public Models.Book MapToModel()
        {
            var book = new Models.Book()
            {
                Name = this.Name,
                Author = this.Author,
                Tag = this.Tag,
                PublicationYear = this.PublicationYear,
                CollectionId = this.CollectionId
            };

            if (this.ImageFile != null && this.ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    this.ImageFile.CopyTo(memoryStream);
                    book.ImageData = memoryStream.ToArray();
                    book.ImageMimeType = this.ImageFile.ContentType;
                }
            }

            return book;
        }
    }
}