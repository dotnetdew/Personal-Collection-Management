using CollectionManagement.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionManagement.Models
{
    public class MyCollection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Topic Topic { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
        public virtual ICollection<Coin>? Coins { get; set; }
        public virtual ICollection<PostStamp>? PostStamps { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }

        public virtual AppUser? AppUser { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}