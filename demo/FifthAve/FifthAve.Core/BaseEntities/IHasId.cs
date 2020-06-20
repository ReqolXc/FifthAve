using MongoDB.Bson;

namespace FifthAve.Core.BaseEntities
{
    public interface IHasId
    {
        ObjectId Id { get; set; }
    }
}
