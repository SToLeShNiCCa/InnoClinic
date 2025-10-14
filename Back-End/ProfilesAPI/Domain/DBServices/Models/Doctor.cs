namespace Domain.DBServices.Models
{
    /// <summary>
    /// Model class for Doctors table.
    /// </summary>
    public class Doctor : Entity
    {
        /// <summary>
        /// Identifier of the doctor's specialization (foreign key).
        /// </summary>
        public int SpecializationId { get; set; }

        /// <summary>
        /// Identifier of the doctor's office (foreign key).
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// Year when the doctor started his career.
        /// </summary>
        public int CareerStartYear { get; set; }

        /// <summary>
        /// Base date of birth for all entities.
        /// </summary>
        public DateOnly DateOfBirth { get; set; }

        /// <summary>
        /// Doctor's status (e.g., Active, Inactive).
        /// </summary>
        public required string Status { get; set; }
    }
}
