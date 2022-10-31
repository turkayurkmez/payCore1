namespace eshop.Messages
{
	public class PaymentCompleted
	{
		public int OrderId { get; set; }

	}

	public class PaymentFailed
	{
		public int OrderId { get; set; }
		public string Message { get; set; }
	}

}
