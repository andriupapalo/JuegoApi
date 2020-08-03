using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoApi.Entities
{
    public class Apuesta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public String Cliente { get; set; }
        public String Ruleta { get; set; }
        public IEnumerable<Color> Colores { get; set; }
        public IEnumerable<Numero> Numeros { get; set; }
        public int ValorApostado { get; set; }
    }
}
