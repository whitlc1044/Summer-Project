using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class VolunteerModel
    {
        public int Vol_Id { get; set; }
   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Center { get; set; }
        public string Skills { get; set; }
        public string Availability { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Education { get; set; }
        public string Licenses { get; set; }
        public string ECName { get; set; }
        public string ECPhone { get; set; }
        public string ECEmail { get; set; }
        public string ECAddress { get; set; }
        public string ApprovalStatus { get; set; }
        public bool DriversLicenseOnFile { get; set; }
        public bool SSCardOnFile { get; set; }

    }
}