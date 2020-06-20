using FifthAve.Core.BaseEntities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FifthAve.Services.AccountIdentityService.DomainModels.Account
{
    public class Account : IBaseEntity
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("fName")]
        public string FirstName { get; set; } = string.Empty;
        
        [BsonIgnoreIfDefault]
        [BsonElement("mName")]
        public string MiddleName { get; set; } = string.Empty;

        [BsonElement("lName")]
        public string LastName { get; set; } = string.Empty;

        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [BsonIgnoreIfDefault]
        [BsonElement("postsNum")]
        public int PostsNumber { get; set; } = 0;

    }
}