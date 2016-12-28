using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using FluentAssertions;




namespace Napp.Controllers
{
    public class HomeController : Controller
    {
       public MongoDatabase Database;
         public HomeController()
        {
            var port = 27017;
            var theConnectionString = "mongodb://localhost:"+port;
            var dbName = "restaurants";
 
            var client = new MongoClient(theConnectionString);
            var server = client.GetServer();
            Database = server.GetDatabase(dbName);
            //database.
        }

        public IActionResult Index()
        {
           
             //The driver won't connect without a first command so..
            //I will trigger that by calling GetStats. Only required
            //for purposes of this demo.
          
             
            //Get access to server from database Controller Field
            //and then access the build information property & 
            //specify AllowGet to test in the browser
            return Json(Database.Server.BuildInfo);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
