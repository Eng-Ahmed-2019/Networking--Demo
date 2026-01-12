namespace NetworkingDemo.API.DTOs
{
    public class OrderDto
    {
        public int Id { set; get; }
        public string Name { set; get; } = null!;
        public decimal Price { set; get; }
    }
}