using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoDbAndAjaxProject.DAL.Entities
{
    public class Register
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RegisterID { get; set; }
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
