using System;
using FifthAve.Core.BaseEntities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FifthAve.Services.AccountIdentityService.DomainModels.AccountIdentity
{
    public class AccountIdentity : IBaseEntity
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [BsonElement("hashedPassword")]
        public byte[] HashedPassword { get; set; } = Array.Empty<byte>();
    }
}
