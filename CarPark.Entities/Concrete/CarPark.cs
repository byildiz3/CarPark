using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarPark.Entities.Concrete
{
   public class CarPark : BaseModel
    {
       

        public string Name { get; set; }
        public string[] PhoneNumbers { get; set; }
        public Adress Adress { get; set; }
        public string[] Personels { get; set; }
        public string WebSite { get; set; }
        public string[] EmailAddreses { get; set; }
        public ICollection<WorkingDay> WorkingDays  { get; set; }
        public ICollection<FloorInformation> Floors { get; set; }
    }
}
