namespace Domain.DBServices.Models
{
    /// <summary>
    /// Base class for all entities.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Base identifier for all entities.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Base first name for all entities.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Base last name for all entities.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Base middle name for all entities.
        /// </summary>
        public required string MiddleName { get; set; }

        /// <summary>
        /// Base foreign key for all entities.
        /// </summary>
        public int AccountId { get; set; }
    }
}
