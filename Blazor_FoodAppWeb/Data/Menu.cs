using MongoDB.Bson.Serialization.Attributes;

namespace Blazor_FoodAppWeb.Data
{
    public class Menu
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

        
        [BsonElement("name")]
        public string Name { get; set; } = "";

        [BsonElement("description")]
        public string Description { get; set; } = "";
        
        [BsonElement("price")]
        public int Price { get; set; }

        [BsonElement("category")]
        public string Category { get; set; } = "";

        [BsonElement("photo")]
        public byte[] Photo { get; set; }

        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; } = "";

    }
}
