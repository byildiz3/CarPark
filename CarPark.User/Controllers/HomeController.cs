using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarPark.User.Models;
using Microsoft.Extensions.Localization;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarPark.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(ILogger<HomeController> logger , IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {




            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://byildiz:06112017Gss@carparkcluster.ucsbn.mongodb.net/CarParkDb?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("CarParkDb");
            var collection = database.GetCollection<Test>("Test");
            var test = new Test()
            {
                _id = ObjectId.GenerateNewId(),
                NameSurname = "Burak Yıldız",
                Age = 26,
                AddressList = new List<Address>()
                {
                    new Address()
                    {
                        Description = "Başıbüyül",
                        Title = "Maltepe"
                    },
                    new Address()
                    {
                        Description = "Çekmeköy",
                        Title = "İst/Çekmeköy"
                    }
                }
            };
            collection.InsertOne(test);
            var customer = new Customer()
            {
                NameSurname = "Burak Yıldız",
                Age = 26,
                Id = 2
            };
            _logger.LogError("Bu ilk Log :{@customer}",customer);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
