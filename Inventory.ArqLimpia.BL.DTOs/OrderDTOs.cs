
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
        public string StoreId { get; set; }
        public string CustomerId { get; set; }
        public string Status { get; set; }
        public List<OrderProductInputDTO> products { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Total { get; set; }
    }

    public class CreateOrderOutputDTOs
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string StoreId { get; set; }
        public string CustomerId { get; set; }
        public string Status { get; set; }
        public List<string> products { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Total { get; set; }
    }

    public class FindOrderOutputDTOs
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string StoreId { get; set; }
        public string Status { get; set; }
        public List<string> products { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Total { get; set; }
    }

     public class FindByIdOrderInputDTOs
    {
        public string Id { get; set; }
    }

     public class FindByIdOrderOutputDTOs
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string StoreId { get; set; }
        public string Status { get; set; }
        public List<string> products { get; set; }
        public DateTime DeliveryDate { get; set; }
    }


}