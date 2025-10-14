namespace Domain.DBServices.Models
{
    /// <summary>
    /// Receptionists entity class inheriting from the base Entity class.
    /// </summary>
    public class Receptionist : Entity
    {
        /// <summary>
        /// Foreign key referencing the office associated with the receptionist.
        /// </summary>
        public int OfficeId { get; set; }
    }
}
