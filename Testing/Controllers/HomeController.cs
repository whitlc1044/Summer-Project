using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Testing.Models;
using DataLibrary;
using static DataLibrary.BusinessLogic.OppurtunityProccesor;
using DataLibrary.Models;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateOpp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOpp(Models.OppurtunityModel model)
        {
            if (ModelState.IsValid)
            {
                int recordCreated = CreateOppurtunity(model.ID, model.Name, model.Date, model.Center);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ViewOppurtunity()
        {
            var data = LoadOppurtunity();
            List<Models.OppurtunityModel> oppurtunities = new List<Models.OppurtunityModel>();
            foreach (var row in data)
            {
                oppurtunities.Add(new Models.OppurtunityModel
                {
                    ID = row.Opp_ID,
                    Name = row.Opp_Name,
                    Date = row.Opp_Date,
                    Center = row.Opp_Center

                }); ;

            }

            return View(oppurtunities);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult EditOpp(int ID)
        {

            return View();

        }
          [HttpPost]
        public IActionResult EditOpp(int ID, Models.OppurtunityModel model)
        {
            try
            {
                int recordCreated = EditOppurtunity(ID, model.Name, model.Date, model.Center);
                return RedirectToAction("ViewOppurtunity");
            }
            catch
            {
                return View();
            }
           
        }

  
        public IActionResult DelOpp(int ID, Models.OppurtunityModel model)
        {
            try
            {
                int recordCreated = DelOppurtunity(ID);
                return RedirectToAction("ViewOppurtunity");
            }
            catch
            {
                return View();
            }
            
        }
    }
}
