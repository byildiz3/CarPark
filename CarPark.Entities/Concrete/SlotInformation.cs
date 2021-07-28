using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarPark.Entities.Concrete
{
    public class SlotInformation : BaseModel
    { 

        public ICollection<Translation> Translations { get; set; }

    }
}