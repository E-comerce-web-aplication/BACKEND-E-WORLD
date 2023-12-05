namespace Inventory.ArqLimpia.BL.DTOs
{
    public class OrderProductInputDTOs
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateOrderInputDTOs
    {
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public List<OrderProductInputDTOs> Products { get; set; }
        public string Status { get; set; }
    }

    public class CreateOrderOutputDTOs
    {
        public string _id { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public List<OrderProductInputDTOs> Products { get; set; }
        public string Status { get; set; }
    }

    public class FindOrderOutputDTOs
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public List<OrderProductInputDTOs> Products { get; set; }
        public string Status { get; set; }
    }

    public class FindByIdOrderInputDTOs
    {
        public string Id { get; set; }
    }

    public class FindByIdOrderOutputDTOs
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public List<OrderProductInputDTOs> Products { get; set; }
        public string Status { get; set; }
    }
}
