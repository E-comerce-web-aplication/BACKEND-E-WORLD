namespace Inventory.ArqLimpia.BL.DTOs
{
    public class OrderProductInputDTO
    { 
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateOrderInputDTOs
    {
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public List<OrderProductInputDTO> Products { get; set; }
    }

    public class CreateOrderOutputDTOs
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public List<string> Products { get; set; }
    }

    public class FindOrderOutputDTOs
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public List<OrderProductInputDTO> Products { get; set; }
    }

    public class FindByIdOrderInputDTO
    {
        public string Id { get; set; }
    }

    public class FindByIdOrderOutputDTO
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public List<string> Products { get; set; }
    }
}
