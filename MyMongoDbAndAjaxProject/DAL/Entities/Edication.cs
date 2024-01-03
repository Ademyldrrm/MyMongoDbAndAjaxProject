using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoDbAndAjaxProject.DAL.Entities
{
    public class Edication
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EdicationID { get; set; }
        public string EdicationTitle { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public string School { get; set; }

    }
}
