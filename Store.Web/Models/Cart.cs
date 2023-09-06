namespace Store.Web.Models
{
	public class Cart
	{
		public int OrderId { get; }
		public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }

        public Cart(int orderId) => (OrderId, TotalCount, TotalPrice) = (orderId, 0, 0m);
    }
}
