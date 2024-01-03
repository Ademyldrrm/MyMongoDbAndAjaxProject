using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoDbAndAjaxProject.DAL.Entities
{
    public class Experience
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ExperienceID { get; set; }
        public string ExperienceTitle { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Task { get; set; }
    }
}
