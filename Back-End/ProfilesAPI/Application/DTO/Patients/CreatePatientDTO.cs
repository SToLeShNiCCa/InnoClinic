namespace Application.DTO.Patients
{
    /// <summary>
    /// DTO class for Patients table.
    /// </summary>
    public class CreatePatientDTO
    {
        /// <summary>
        /// Patient's first name.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Patient's last name.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Patient's middle name.
        /// </summary>
        public required string MiddleName { get; set; }

        /// <summary>
        /// Patient's date of birthday.
        /// </summary>
        public DateOnly DateOfBirth { get; set; }
    }
}
