using MongoDB.Bson.Serialization.Attributes;

namespace Blazor_FoodAppWeb.Data
{
    public class Order
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        
        [BsonElement("date")]
        public string Date { get; set; } = "";

        [BsonElement("address")]
        public string Address { get; set; } = "";

        [BsonElement("amount")]
        public double Amount { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } = "";
    }
}
