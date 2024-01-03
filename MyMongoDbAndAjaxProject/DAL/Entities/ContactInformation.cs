using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoDbAndAjaxProject.DAL.Entities
{
    public class ContactInformation
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactInformationID { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

    }
}
