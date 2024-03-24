using CollectionManagement.Enums;

namespace CollectionManagement.ViewModels.MyCollection
{
    public class MyCollectionEditVM
    {
        public MyCollectionEditVM()
        {
        }

        public MyCollectionEditVM(Models.MyCollection collection)
        {
            Id = collection.Id;
            Name = collection.Name;
            Description = collection.Description;
            Topic = collection.Topic;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Topic Topic { get; set; }
        public IFormFile ImageFile { get; set; }

        public Models.MyCollection MapToModel(Models.MyCollection collection)
        {
            collection.Id = this.Id;
            collection.Name = this.Name;
            collection.Description = this.Description;
            collection.Topic = this.Topic;

            if (ImageFile != null && ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    this.ImageFile.CopyTo(memoryStream);
                    collection.ImageData = memoryStream.ToArray();
                    collection.ImageMimeType = this.ImageFile.ContentType;
                }
            }

            return collection;
        }
    }
}