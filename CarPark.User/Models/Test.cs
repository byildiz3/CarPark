using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace CarPark.User.Models
{
    public class Test
    {
        public ObjectId _id  { get; set; }
        public string NameSurname{ get; set; }
        public int Age { get; set; }
        public ICollection<Address> AddressList{ get; set; }



    }

    public class Address
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
