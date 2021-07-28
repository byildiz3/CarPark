using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarPark.Entities.Concrete
{
    public class WorkingDay : BaseModel
    { 

        public ICollection<Translation> Translation { get; set; }
        public ICollection<WorkingDayHours> WorkingDayHour{ get; set; }
    }
}