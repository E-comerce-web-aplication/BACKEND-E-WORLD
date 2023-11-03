
using System.ComponentModel.DataAnnotations;


namespace Inventory.ArqLimpia.BL.DTOs
{
    public class ProductHistoryDTOs
    {
      
        public class FindAllInputDTOs
        {
            [Required(ErrorMessage = "You must enter a title for the search")]
            public string CompanyId { get; set; }
        }

 

        public class FindAllOutputDTOs
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
