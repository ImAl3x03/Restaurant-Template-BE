using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace RestaurantTemplate.DataAccessLayer.Entities
{
    public class Menu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }

        public List<string> Ingrediants { get; set; }
        public List<string> Allergens { get; set; }

        public double Price { get; set; }
    }
}
