using System;
using System.Collections.Generic;
using System.Text;
using CarPark.Core.Settings;
using CarPark.DataAccess.Abstract;
using CarPark.DataAccess.Context;
using CarPark.DataAccess.Repository;
using CarPark.Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CarPark.DataAccess.Concrete
{
   public class PersonelDataAccess : MongoRepositoryBase<Personel>,IPersonelDataAccess
   {
       private readonly MongoDbContext _context;
       private readonly IMongoCollection<Personel> _collectionPersonel;
        public PersonelDataAccess(IOptions<MongoSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collectionPersonel = _context.GetCollection<Personel>();
        }

        public List<Personel> GetPersonelsWithRoles()
        {
            var personels = _collectionPersonel.AsQueryable().Where(x=>x.Password=="1234").ToList();
            return personels;
        }
    }
}
