using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoDbAndAjaxProject.DAL.Entities
{
    public class Statistic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StatisticID { get; set; }
        public string StatisticName { get; set; }
        public int StatisticValue { get; set; }
        public string StatisticDescription { get; set; }
    }
}
