namespace CollectionManagement.ViewModels.Coin
{
    public class CoinCreateVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public decimal ValueInUSD { get; set; }
        public Guid CollectionId { get; set; }
        public IFormFile ImageFile { get; set; }

        public Models.Coin MapToModel()
        {
            var coin = new Models.Coin()
            {
                Name = this.Name,
                Description = this.Description,
                Country = this.Country,
                CollectionId = this.CollectionId,
                ValueInUSD = this.ValueInUSD
            };

            if (this.ImageFile != null && this.ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    this.ImageFile.CopyTo(memoryStream);
                    coin.ImageData = memoryStream.ToArray();
                    coin.ImageMimeType = this.ImageFile.ContentType;
                }
            }

            return coin;
        }
    }
}