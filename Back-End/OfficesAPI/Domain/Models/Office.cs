namespace Domain.Models
{
    public class Office : Entity
    {
        public string Address { get; set; }
        public int PhotoID { get; set; }
        public string RegistryPhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
