namespace BlazorSaleOrderApp.Server.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Item { get; set; }
        public decimal Amount { get; set; } 
        public ICollection<OrderProduct> OrderProducts { get; set; }  

    }
}
