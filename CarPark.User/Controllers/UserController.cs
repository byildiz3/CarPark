using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPark.Core.Repository.Abstract;
using CarPark.Entities.Concrete;
using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CarPark.User.Controllers
{
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> _localizer;
        private readonly IRepository<Personel> _personelRepository;

        public UserController(IStringLocalizer<UserController> localizer, IRepository<Personel> personelRepository)
        {
            _localizer = localizer;
            _personelRepository = personelRepository;
        }
        public IActionResult Index()
        {
           var nameSurnamsse= _localizer["NameSurname"]; 
            return View();
        }

        public IActionResult Create()
        {
            //var result = _personelRepository.InsertOne(new Personel()
            //{
            //    Email = "burakyildizwork@gmail.com",
            //    Password = "1234",
            //    CreatedDate = DateTime.Now,
            //    UserName = "byildiz",

            //});
            //var resultAsync = _personelRepository.InsertOneAsync(new Personel()
            //{
            //    Email = "burakyildizwork1@gmail.com",
            //    Password = "12341",
            //    CreatedDate = DateTime.Now,
            //    UserName = "byildiz1",

            //});




            //var resultMany = _personelRepository.InsertMany(new List<Personel>() 
            //{
            //    new Personel()
            //    {
            //        Email = "burakyildizwork3@gmail.com",
            //        Password = "1234",
            //        CreatedDate = DateTime.Now,
            //        UserName = "byildiz",
            //    },
            //    new Personel()
            //    {
            //        Email = "burakyildizwork4@gmail.com",
            //        Password = "1234",
            //        CreatedDate = DateTime.Now,
            //        UserName = "byildiz",
            //    },
            //    new Personel()
            //    {
            //        Email = "burakyildizwork5@gmail.com",
            //        Password = "1234",
            //        CreatedDate = DateTime.Now,
            //        UserName = "byildiz",
            //    }


            //});


            //var resultManyAsync = _personelRepository.InsertManyAsync(new List<Personel>()
            //{
            //    new Personel()
            //    {
            //        Email = "burakyildizwork6@gmail.com",
            //        Password = "1234",
            //        CreatedDate = DateTime.Now,
            //        UserName = "byildiz",
            //    },
            //    new Personel()
            //    {
            //        Email = "burakyildizwork7@gmail.com",
            //        Password = "1234",
            //        CreatedDate = DateTime.Now,
            //        UserName = "byildiz",
            //    },
            //    new Personel()
            //    {
            //        Email = "burakyildizwork8@gmail.com",
            //        Password = "1234",
            //        CreatedDate = DateTime.Now,
            //        UserName = "byildiz",
            //    }


            //});


           // var resultGetAll = _personelRepository.AsQuarable();
            //var result = _personelRepository.GetById("61011bd3b8772650da4cc02e");
            //result.Entity.Email = "yldzburak.36@gmail.com";
            //result.Entity.Password = "343434";
            //result.Entity.UserName = "byildiz.sys";

            //var resultReplace = _personelRepository.ReplaceOne(result.Entity, result.Entity.Id.ToString());
            //var results = _personelRepository.DeleteOne(x => x.Email.Contains("5"));

            return View();

        }

        [HttpPost]
        public IActionResult Create(UserCreateRequestModel request)
        {

            return View(request);

        }
    }
}
