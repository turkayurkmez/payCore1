namespace eshop.Messages
{
    public class ProductPriceChanged
    {
        public int ProductId { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }

    }
}
