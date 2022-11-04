namespace Orders.API.Services
{
    public interface IOrderService
    {
        void CreateOrder();
        void GetOrdersByCustomer();
        void UpdateOrder();
        void ChangeOrderAddress();

    }


}
