using Pre_SemesterAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataLibrary;
using DataLibrary.Models;
using static DataLibrary.BussinessLogic.VolunteerProcessor;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Pre_SemesterAssignment.Controllers
{
    public class VolunteersController : Controller
    {
        private readonly ILogger<VolunteersController> _logger;

        public VolunteersController(ILogger<VolunteersController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult ViewVolunteer(string searchString, string filter)
        {
            ViewBag.Message = "Volunteers List";
            ViewBag.CurrentSearch = searchString;

            var data = LoadVolunteer();
            List<Models.VolunteerModel> volunteers = new List<Models.VolunteerModel>();
            if (!string.IsNullOrEmpty(filter))
            {
                switch (filter)
                {
                    case "Approved/Pending Approval":
                        data = AP();
                        break;
                    default:
                        data = ApprovalStatus(filter);
                        break;
                }

            }


            if (!string.IsNullOrEmpty(searchString))
            {
                data = FindVol(searchString);

            }
            foreach (var row in data)
            {
                volunteers.Add(new Models.VolunteerModel
                {
                    Vol_ID = row.Vol_Id,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    UserName = row.UserName,
                    Password = row.Password,
                    Center = row.Center,
                    Skills = row.Skills,
                    Availability = row.Availability,
                    Address = row.Address,
                    PhoneNumber = row.PhoneNumber,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmail = row.EmailAddress,
                    Education = row.Education,
                    Licenses = row.Licenses,
                    ECName = row.ECName,
                    ECPhone = row.ECPhone,
                    ECEmail = row.ECEmail,
                    ECAddress = row.ECAddress,
                    ApprovalStatus = row.ApprovalStatus,
                    DriversLicenseOnFile = row.DriversLicenseOnFile,
                    SSCardOnFile = row.SSCardOnFile,

                });
            }

            return View(volunteers);
        }
        public IActionResult ManageVolunteers()
        {
            ViewBag.Message = "Manage Volunteers";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManageVolunteers(Models.VolunteerModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateVolunteer(

                                      model.FirstName,
                                      model.LastName,
                                      model.UserName,
                                      model.Password,
                                      model.Center,
                                      model.Skills,
                                      model.Availability,
                                      model.Address,
                                      model.PhoneNumber,
                                      model.EmailAddress,
                                      model.Education,
                                      model.Licenses,
                                      model.ECName,
                                      model.ECPhone,
                                      model.ECEmail,
                                      model.ECAddress,
                                      model.ApprovalStatus,
                                      model.DriversLicenseOnFile,
                                      model.SSCardOnFile);
                return RedirectToAction("viewvolunteer");
            }

            return View();
        }
        public IActionResult EditVol(int Vol_ID)
        {

            return View();

        }
        [HttpPost]
        public IActionResult EditVol(int Vol_ID, Models.VolunteerModel model)
        {
            try
            {
                int recordCreated = EditVolunteer(Vol_ID, model.FirstName,
                                      model.LastName,
                                      model.UserName,
                                      model.Password,
                                      model.Center,
                                      model.Skills,
                                      model.Availability,
                                      model.Address,
                                      model.PhoneNumber,
                                      model.EmailAddress,
                                      model.Education,
                                      model.Licenses,
                                      model.ECName,
                                      model.ECPhone,
                                      model.ECEmail,
                                      model.ECAddress,
                                      model.ApprovalStatus,
                                      model.DriversLicenseOnFile,
                                      model.SSCardOnFile );
                return RedirectToAction("ViewVolunteer");
            }
            catch
            {
                return View();
            }

            

        }
        public IActionResult DelVol(int Vol_ID, Models.VolunteerModel model)
        {
            try
            {
                int recordCreated = DelVolunteer(Vol_ID);
                return RedirectToAction("ViewVolunteer");
            }
            catch
            {
                return View();
            }

        }


    }
}