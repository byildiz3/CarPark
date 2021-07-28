using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarPark.Entities.Concrete
{
    public class FloorInformation : BaseModel
    { 

        public int Number { get; set; }
        public ICollection<SlotInformation> Slots { get; set; }
    }
}