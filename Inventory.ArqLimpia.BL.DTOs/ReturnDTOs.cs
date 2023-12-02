
using System.ComponentModel.DataAnnotations;

namespace Inventory.ArqLimpia.BL.DTOs
{
    public class ReturnDTOs

    {
        public class ReturnProductsInputDTOs
        {
            public int Returns { get; set; }
            public int Quantity { get; set; }
            public string ProductId { get; set; }
        }
        public class CreateReturnInputDTO
        {
            public DateTime Date { get; set; }
            public int UserId { get; set; }
            public string Reason { get; set; }
            public int StoreId { get; set; }
            public decimal Total { get; set; }
            public List<ReturnProductsInputDTOs> Products { get; set; }
            public string Status { get; set; }          
        }

        public class CreateReturnOutputDTO
        {
            public string Id { get; set; }
            public DateTime Date { get; set; }
            public int UserId { get; set; }
            public string Reason { get; set; }
            public int StoreId { get; set; }
            public decimal Total { get; set; }
            public List<ReturnProductsInputDTOs> Products { get; set; }
            public string Status { get; set; }
        }

        public class FindReturnOutputDTOs
        {
            public string Id { get; set; }
            public DateTime Date { get; set; }
            public int UserId { get; set; }
            public string Reason { get; set; }
            public int StoreId { get; set; }
            public decimal Total { get; set; }
            public List<ReturnProductsInputDTOs> Products { get; set; }
            public string Status { get; set; }
        }

            // DTO para buscar datos de un retorno
            public class FindReturnInputDTO
        {
            public string Id { get; set; }
        }

        // Datos que devolverá un retorno
        public class FindByIdReturnOutputDTOs
        {
            public string Id { get; set; }
            public DateTime Date { get; set; }
            public int UserId { get; set; }
            public string Reason { get; set; }
            public int StoreId { get; set; }
            public decimal Total { get; set; }
            public List<ReturnProductsInputDTOs> Products { get; set; }
            public string Status { get; set; }
        }
        
    }
}
