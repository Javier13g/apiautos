using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace apiautos.Entities
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Modelos { get; set; }
    }
}

