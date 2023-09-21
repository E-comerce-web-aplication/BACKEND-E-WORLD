
namespace inventory.ArqLimpia.EN
{
    public enum ROLE
    {
        InventoryManager,
        StoreManager,
        WarehouseManager
    }
    public class UserEN
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ROLE RoleUser { get; set; }
    }
}
