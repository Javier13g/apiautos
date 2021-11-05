using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace apiautos.Entities
{
    public class Marca
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Marcas { get; set; }
        public ICollection<Modelo> Modelos { get; set; }
    }
}