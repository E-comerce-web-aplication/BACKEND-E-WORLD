namespace inventory.ArqLimpia.EN
{
    public class ProductRegisterEN
    {
        public int Id { get; set; }

        public int IdProduct { get; set; }

        public int IdRegister { get; set; }

        public int Quantity { get; set; }

        public virtual  ProductEN Product { get; set; }

        public virtual ReturnsEN Register { get; set; }  
    }
}