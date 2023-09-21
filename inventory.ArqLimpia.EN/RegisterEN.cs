namespace inventory.ArqLimpia.EN
{
    public class RegisterEN
    {
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; }

        public int IdUser { get; set; }

        public virtual UserEN User { get; set; }

        public virtual ICollection<ProductRegisterEN> EspecifiRegister { get; set; }
    }
}