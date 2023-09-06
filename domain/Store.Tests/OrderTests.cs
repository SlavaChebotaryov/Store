namespace Store.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }
        [Fact]
        public void TotalCount_WithEmptyItems_returnZero()
        {
            var order = new Order(1, Array.Empty<OrderItem>());
            Assert.Equal(0, order.TotalCount);
        }
        [Fact]
        public void TotalPrice_WithEmptyItems_returnZero()
        {
            var order = new Order(1, Array.Empty<OrderItem>());
            Assert.Equal(0m, order.TotalPrice);
        }

        [Fact]
        public void TotalCount_WithNonEmptyItems_calculatesTotalCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });
            Assert.Equal(3+5,order.TotalCount);
            Assert.Equal(3*10m+5*100m, order.TotalPrice);
        }

      
    }
}
