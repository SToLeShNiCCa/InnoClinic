namespace Domain.DBServices.Models
{
    /// <summary>
    /// Class representing the Patients table in the database.
    /// </summary>
    public class Patient : Entity
    {
        /// <summary>
        /// Is the patient linked to an account.
        /// </summary>
        public bool IsLinkedToAccount { get; set; }

        /// <summary>
        /// Base date of birth for all entities.
        /// </summary>
        public DateOnly DateOfBirth { get; set; }
    }
}
