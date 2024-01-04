using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoDbAndAjaxProject.DAL.Entities
{
    public class MessageCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MessageCategoryID { get; set; }
        public string MessageCategoryName { get; set; }
        public List<Contact>? Contacts { get; set; }

    }

}
