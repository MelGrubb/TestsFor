namespace TestsFor.Tests.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }

    public class Order
    {
        public Guid Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}