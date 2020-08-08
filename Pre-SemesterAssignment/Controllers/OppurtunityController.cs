using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pre_SemesterAssignment.Models;
using DataLibrary;
using static DataLibrary.BusinessLogic.OppurtunityProccesor;
using DataLibrary.Models;
using System.Data.SqlClient;

namespace Pre_SemesterAssignment.Controllers
{
    public class OppurtunityController : Controller
    {
        private readonly ILogger<OppurtunityController> _logger;

        public OppurtunityController(ILogger<OppurtunityController> logger)
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
                int recordCreated = CreateOppurtunity(model.Name, model.Date, model.Center, model.Description);
                return RedirectToAction("ViewOppurtunity");
            }
            return View();
        }
        public IActionResult ViewOppurtunity(string searchString, string Sort, string filter)
        {


            ViewBag.CurrentSearch = searchString;
            var data = LoadOppurtunity();

            List<Models.OppurtunityModel> oppurtunities = new List<Models.OppurtunityModel>();

            switch (Sort)
            {
                case "Center":
                    data = CenterAsc();
                    break;
                case "Recent":
                    data = Recent();
                    break;
                default:

                    break;
            }
            switch (filter)
            {
                case "Center":
                    data = CenterAsc();
                    break;
                case "60Recent":
                    data = RecentFilter();
                    break;
                default:

                    break;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                data = FindOpp(searchString);

            }


            foreach (var row in data)
            {
                oppurtunities.Add(new Models.OppurtunityModel
                {
                    ID = row.Opp_ID,
                    Name = row.Opp_Name,
                    Date = row.Opp_Date,
                    Center = row.Opp_Center,
                    Description = row.Opp_Desc

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
                int recordCreated = EditOppurtunity(ID, model.Name, model.Date, model.Center, model.Description);
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
