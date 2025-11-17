using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public class Result
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public required string Id { get; set; }
        public string Complaints { get; set; } = default!;
        public string Conclusion { get; set; } = default!;
        public string Recommendations { get; set; } = default!;
        public int AppointmentId { get; set; }
    }
}
