using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMongoDbAndAjaxProject.DAL.Entities
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceTitle { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal ServicePrice { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceImage { get; set; }
    }
}
