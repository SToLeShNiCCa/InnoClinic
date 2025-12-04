namespace Domain.Models
{
    public class Office : Entity
    {
        public string Address { get; set; } = default!;
        public string PhotoID { get; set; } = default!;
        public string RegistryPhoneNumber { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}
