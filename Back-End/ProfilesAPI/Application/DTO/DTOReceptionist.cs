using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for Receptionist entity.
    /// </summary>
    public class DTOReceptionist
    {
        /// <summary>
        /// Receptionist's first name.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Receptionist's last name.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Receptionist's middle name.
        /// </summary>
        public required string MiddleName { get; set; }

        /// <summary>
        /// Office identifier associated with the receptionist(foreign key).
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// Account identifier associated with the receptionist(foreign key).
        /// </summary>
        public int AccountId { get; set; }
    }
}
