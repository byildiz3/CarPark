using System;
using System.Collections.Generic;
using System.Text;
using CarPark.Core.Models;
using CarPark.DataAccess.Abstract;
using CarPark.Entities.Concrete;

namespace CarPark.Business.Abstract
{
   public interface IPersonelService
   {
       GetManyResult<Personel> GetListByAge();
   }
}
