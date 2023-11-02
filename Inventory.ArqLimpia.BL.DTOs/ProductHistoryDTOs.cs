
using System.ComponentModel.DataAnnotations;


namespace Inventory.ArqLimpia.BL.DTOs
{
    public class ProductHistoryDTOs
    {
        public class DeleteHistoryInputDTOs
        {
            [Required]
            public string IdProduct { get; set; }
        }

        public class DeleteHistoryOutputDTOs
        {
            public bool IsDeleted { get; set; }
        }

        public class FindOneHistoryInputDTOs
        {
            [Required(ErrorMessage = "You must enter a title for the search")]
            public string ProductName { get; set; }
        }

        public class FindByIdDTO
        {
            [Required(ErrorMessage = "You must enter a id for the search")]
            public string Id { get; set; }
        }

        public class FindOneHistoryOutputDTOs
        {
            public string Id { get; set; }
            public string ProductName { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public List<string> Images { get; set; }
            public int Stock { get; set; }
            public double Price { get; set; }
            public string CompanyId { get; set; }
            public string SendConditions { get; set; }
            public List<string> Tags { get; set; }
        }

        public class FindHistoryOutputDTOs
        {
            public string Id { get; set; }
            public string ProductName { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public List<string> Images { get; set; }
            public int Stock { get; set; }
            public double Price { get; set; }
            public string CompanyId { get; set; }
            public string SendConditions { get; set; }
            public List<string> Tags { get; set; }
        }
    }
}
