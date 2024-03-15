namespace CollectionManagement.Models
{
    public class PostStamp
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }
        public Guid CollectionId { get; set; }
        public virtual MyCollection Collection { get; set; }
    }
}