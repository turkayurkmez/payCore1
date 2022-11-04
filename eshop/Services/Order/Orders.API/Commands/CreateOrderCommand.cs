namespace Orders.API.Commands
{
    public class CreateOrderCommand : ICommand
    {
        public DateTime? OrderDate { get; set; }
        public int CustomerId { get; set; }



    }
}
