using CollectionManagement.Enums;

namespace CollectionManagement.ViewModels.MyCollection
{
    public class MyCollectionCreateVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Topic Topic { get; set; }
        public IFormFile ImageFile { get; set; }
        public string? AppUserId { get; set; }

        public Models.MyCollection MapToModel()
        {
            var collection = new Models.MyCollection()
            {
                Name = this.Name,
                Description = this.Description,
                Topic = this.Topic,
                AppUserId = this.AppUserId
            };

            if (this.ImageFile != null && this.ImageFile.Length > 0)
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