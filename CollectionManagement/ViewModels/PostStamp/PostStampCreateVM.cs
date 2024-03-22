namespace CollectionManagement.ViewModels.PostStamp
{
    public class PostStampCreateVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public Guid CollectionId { get; set; }
        public IFormFile ImageFile { get; set; }

        public Models.PostStamp MapToModel()
        {
            var postStamp = new Models.PostStamp()
            {
                Name = Name,
                Description = Description,
                Country = Country,
                CollectionId = CollectionId
            };

            if (ImageFile != null && ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    this.ImageFile.CopyTo(memoryStream);
                    postStamp.ImageData = memoryStream.ToArray();
                    postStamp.ImageMimeType = this.ImageFile.ContentType;
                }
            }

            return postStamp;
        }
    }
}
