using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RestaurantTemplate.DataAccessLayer.Entities
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Text { get; set; }
        public int Star { get; set; }
    }
}
