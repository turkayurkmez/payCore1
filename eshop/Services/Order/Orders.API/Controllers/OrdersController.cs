using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public IActionResult CreateOrder(string customerId, )
        {

        }
    }
}
