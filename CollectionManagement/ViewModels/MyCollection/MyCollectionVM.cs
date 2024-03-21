using CollectionManagement.Enums;

namespace CollectionManagement.ViewModels.MyCollection
{
    public class MyCollectionVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Topic Topic { get; set; }
        public string ImageSrc { get; set; }
    }
}
