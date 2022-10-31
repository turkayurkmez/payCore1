namespace eshop.Messages
{
	public class StockReserved
	{
		public int CustomerId { get; set; }
		public int OrderId { get; set; }
		public decimal? TotalPrice { get; set; }

		public List<OrderItemMessage> OrderItemMessages { get; set; }

	}

	public class StockNotReserved
	{
		public int CustomerId { get; set; }
		public int OrderId { get; set; }
		public string Message { get; set; }
	}
}
