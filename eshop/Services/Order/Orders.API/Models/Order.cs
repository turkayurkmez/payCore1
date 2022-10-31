namespace Orders.API.Models
{

    public enum OrderStatus
    {
        Pending,
        Canceled,
        Failed,
        Completed
    }
    public class Order
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public OrderStatus State { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }

    /*
     * Orders.API'nin oluşturduğu her sipariş; Pending olarak kaydedilir.
     * Stock'da varsa, ödeme yapıldıysa ve kargoya verildi ise Completed....
     * Herhangi biri başarısız olduğunda Failed....
     * Kullanıcı iptal ederse Canceled
     */


}
