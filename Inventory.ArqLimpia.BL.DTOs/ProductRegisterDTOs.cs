namespace Inventory.ArqLimpia.BL.DTOs
{
    public class ProductRegisterDTOs
    {
        public string Id { get; set; }
        public UserDto User { get; set; }
        public string Company_name { get; set; }
        public ProductType Type { get; set; }
        public int CompanyId { get; set; }
        public DateTime Date { get; set; }

        public class UserDto
        {
            public string name { get; set; }
            public string role { get; set; }
        }
        public enum ProductType
        {
            NewProduct,
            ProductDeletion,
            ProductUpdate
        }
    }
}
