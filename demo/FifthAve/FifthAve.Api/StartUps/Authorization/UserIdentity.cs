using System;
using MongoDB.Bson;

namespace FifthAve.Api.StartUps.Authorization
{
    public interface IUserIdentity
    {
        ObjectId Id { get; set; }
        bool? IsAuthenticated { get; set; }
    }

    public class UserIdentity : IUserIdentity
    {
        private ObjectId? _id;

        public ObjectId Id
        {
            get => _id ?? ObjectId.Empty;

            set
            {
                if (!_id.HasValue)
                    _id = value;
                else
                    throw new Exception("Can not be redefined");
            }
        }

        private bool? _isAuthenticated = null;

        public bool? IsAuthenticated
        {
            get => _isAuthenticated;

            set
            {
                if (_isAuthenticated == null)
                    _isAuthenticated = value;
                else
                    throw new Exception("Can not be redefined");
            }
        }
    }
}