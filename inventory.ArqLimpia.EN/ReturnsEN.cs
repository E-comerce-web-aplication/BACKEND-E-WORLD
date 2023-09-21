namespace inventory.ArqLimpia.EN
{
    public class ReturnsEN
    {
        public int Id { get; set; }

        public DateTime ReturnDate { get; set; }

        public int IdStore { get; set; }

        public int IdUser { get; set; }

        public virtual StoreEN Store { get; set; }

        public virtual UserStoreEN User { get; set; }

        public virtual ICollection<ProductsReturnEN> EspecifiReturn { get; set; }
 
    }
}