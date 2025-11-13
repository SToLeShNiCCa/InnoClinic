namespace Domain.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string Complaints { get; set; } = default!;
        public string Conclusion { get; set; } = default!;
        public string Recommendations { get; set; } = default!;
        public int AppointmentId { get; set; }
    }
}
