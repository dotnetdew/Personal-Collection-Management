using CollectionManagement.Models;

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
            ImageUrl = book.ImageUrl;
            PublicationYear = book.PublicationYear;
            CollectionId = book.CollectionId;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public string ImageUrl { get; set; }
        public int PublicationYear { get; set; }
        public Guid CollectionId { get; set; }
        public Models.Book MapToModel(Models.Book book)
        {
            book.Id = this.Id;
            book.Name = this.Name;
            book.Author = this.Author;
            book.Tag = this.Tag;
            book.ImageUrl = this.ImageUrl;
            book.PublicationYear = this.PublicationYear;
            return book;
        }
    }
}
