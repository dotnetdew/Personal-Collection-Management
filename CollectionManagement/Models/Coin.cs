﻿namespace CollectionManagement.Models
{
    public class Coin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public decimal ValueInUSD { get; set; }
        public Guid CollectionId { get; set; }
        public virtual MyCollection Collection { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}