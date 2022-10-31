using eshop.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Orders.API.Models;

namespace Orders.API.Controllers
{

    /*
1. Sipariş Ekleme eventi fırlar. (OrderCreated)
2. Stocks API’si OrderCreated eventini consume eder.
3. Eğer yeterli stok varsa StockReserved event’i fırlar.
4. Eğer yeterli stok yoksa StockNotReserved event’i fırlar
5.  Payment API’si StockReserved event’ini consume eder.
6.  Eğer ödeme alabiliyorsa PaymentCompleted event’i fırlar.
7. Eğer ödeme alamıyorsa PaymentFailed event’i fırlar
8. Orders API PaymentCompleted eventini dinler ve işlem kapanır
9. Order API’si StockNotReserved eventini consume eder ve fırlarsa OrderFailed olarak db’de günceller.
10. Stocks API’si PaymentFailed eventini consume eder ve fırlarsa  stock’ları değiştirir.
11. Order API’si PaymentFailed eventini consume eder ve fırlarsa OrderFailed olarak db’de güncellenir.
     */
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrdersController(ILogger<OrdersController> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public IActionResult CreateOrder(int customerId, List<OrderItem> orderItems)
        {
            Order order = new Order
            {
                OrderDate = DateTime.Now,
                State = OrderStatus.Pending,
                OrderItems = orderItems,
                CustomerId = customerId

            };
            var totalPrice = orderItems.Sum(od => od.Quantity * od.Price);
            _logger.LogInformation($"{order.OrderDate} tarihinde, sipariş oluşturuldu. Bu siparişte; {totalPrice} tutarında ürün alındı. Sipariş durumu: {order.State}");


            var orderItemMessages = orderItems.Select(x => new OrderItemMessage
            {
                Price = x.Price,
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList();



            OrderCreated orderCreated = new OrderCreated
            {
                CustomerId = customerId,
                OrderId = 8,
                OrderItems = orderItemMessages,
                TotalPrice = totalPrice
            };

            _publishEndpoint.Publish(orderCreated);

            return Ok();
        }
    }
}
