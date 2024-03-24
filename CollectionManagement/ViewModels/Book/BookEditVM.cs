namespace CollectionManagement.ViewModels.Book
{
    public class BookEditVM
    {
        public BookEditVM()
        {
        }

        public BookEditVM(Models.Book book)
        {
            Id = book.Id;
            Name = book.Name;
            Author = book.Author;
            Tag = book.Tag;
            PublicationYear = book.PublicationYear;
            CollectionId = book.CollectionId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public int PublicationYear { get; set; }
        public Guid CollectionId { get; set; }
        public IFormFile ImageFile { get; set; }

        public Models.Book MapToModel(Models.Book book)
        {
            book.CollectionId = this.CollectionId;
            book.Id = this.Id;
            book.Name = this.Name;
            book.Author = this.Author;
            book.Tag = this.Tag;
            book.PublicationYear = this.PublicationYear;

            if (ImageFile != null && ImageFile.Length > 0)
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