using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarPark.Entities.Concrete
{
    public class County : BaseModel
    { 
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PostCode { get; set; }
    }
}