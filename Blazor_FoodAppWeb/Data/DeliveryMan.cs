using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blazor_FoodAppWeb.Data
{
    public class DeliveryMan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("firstName")]
        public string FirstName { get; set; } = "";

        [BsonElement("lastName")]
        public string LastName { get; set; } = "";

        [BsonElement("secondLastName")]
        public string SecondLastName { get; set; } = "";

        [BsonElement("email")]
        public string Email { get; set; } = "";

        [BsonElement("password")]
        public string Password { get; set; } = "";

        [BsonElement("phoneNumber")]
        public int PhoneNumber { get; set; }
        
        [BsonElement("shift")]
        public string Shift { get; set; } = "";
    }
}
