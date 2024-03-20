namespace CollectionManagement.ViewModels.Coin
{
    public class CoinEditVM
    {
        public CoinEditVM()
        {
            
        }
        public CoinEditVM(Models.Coin coin)
        {
            Id = coin.Id;
            Name = coin.Name;
            Description = coin.Description;
            Country = coin.Country;
            ValueInUSD = coin.ValueInUSD;
            CollectionId = coin.CollectionId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public decimal ValueInUSD { get; set; }
        public Guid CollectionId { get; set; }
        public IFormFile ImageFile { get; set; }

        public Models.Coin MapToModel(Models.Coin coin)
        {
            coin.Id = this.Id;
            coin.Name = this.Name;
            coin.Description = this.Description;
            coin.Country = this.Country;
            coin.ValueInUSD = this.ValueInUSD;
            coin.CollectionId = this.CollectionId;

            if (ImageFile != null && ImageFile.Length > 0)
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
