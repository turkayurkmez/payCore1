﻿namespace Orders.API.Models
{
    public class OrderItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

    }
}
