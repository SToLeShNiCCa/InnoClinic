using Domain.Enums;

namespace Application.DTO.ServiceDTO
{
    public class ReadServiceDTO
    {
        public required string ServiceName { get; set; }
        public required decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
