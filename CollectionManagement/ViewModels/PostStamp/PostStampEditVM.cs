namespace CollectionManagement.ViewModels.PostStamp
{
    public class PostStampEditVM
    {
        public PostStampEditVM()
        {
        }

        public PostStampEditVM(Models.PostStamp postStamp)
        {
            Id = postStamp.Id;
            Name = postStamp.Name;
            Description = postStamp.Description;
            Country = postStamp.Country;
            CollectionId = postStamp.CollectionId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public Guid CollectionId { get; set; }
        public IFormFile ImageFile { get; set; }

        public Models.PostStamp MapToModel(Models.PostStamp postStamp)
        {
            postStamp.Id = Id;
            postStamp.CollectionId = CollectionId;
            postStamp.Name = Name;
            postStamp.Description = Description;
            postStamp.Country = Country;

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