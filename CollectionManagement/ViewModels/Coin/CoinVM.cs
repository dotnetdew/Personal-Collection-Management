namespace CollectionManagement.ViewModels.Coin
{
    public class CoinVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }
        public decimal ValueInUSD { get; set; }
        public Guid CollectionId { get; set; }
        public string ImageSrc { get; set; }
    }
}
