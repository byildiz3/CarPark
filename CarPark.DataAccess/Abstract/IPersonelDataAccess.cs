using System;
using System.Collections.Generic;
using System.Text;
using CarPark.Core.Repository.Abstract;
using CarPark.Entities.Concrete;

namespace CarPark.DataAccess.Abstract
{
   public interface IPersonelDataAccess : IRepository<Personel>
   {
       List<Personel> GetPersonelsWithRoles();
   }
}
