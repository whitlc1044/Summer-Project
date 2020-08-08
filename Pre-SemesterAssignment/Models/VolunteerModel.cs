using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_SemesterAssignment.Models
{
    public class VolunteerModel
    {
 
        public int Vol_ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter last name.")]
        public string LastName { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Enter user name.")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter a password.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "You need to provide a long enough password.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Preferred Center")]
        [Required(ErrorMessage = "Enter in a center.")]
        public string Center { get; set; }

        [Display(Name = "Skills/Interest")]
        [Required(ErrorMessage = "Enter in skills.")]
        public string Skills { get; set; }

        [Display(Name = "Availability Times")]
        [Required(ErrorMessage = "Enter in availability.")]
        public string Availability { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter in address.")]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Enter in a valid phone number.")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Enter email address.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("EmailAddress", ErrorMessage = "The Email and Confirm Email must match.")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Education")]
        [Required(ErrorMessage = "Enter in education.")]
        public string Education { get; set; }

        [Display(Name = "Current Licenses")]
        [Required(ErrorMessage = "Enter in licenses.")]
        public string Licenses { get; set; }

        [Display(Name = "Emergency Contact Name")]
        [Required(ErrorMessage = "Enter in emergency contact name.")]
        public string ECName { get; set; }

        [Display(Name = "Emergency Contact Phone Number")]
        [Required(ErrorMessage = "Enter in emergency contacy phone number.")]
        [DataType(DataType.PhoneNumber)]
        public int ECPhone { get; set; }

        [Display(Name = "Emergency Contact Email")]
        [Required(ErrorMessage = "Enter in emergency contact email.")]
        public string ECEmail { get; set; }

        [Display(Name = "Emergency Contact Address")]
        [Required(ErrorMessage = "Enter in emergency contact address.")]
        public string ECAddress { get; set; }

        [Display(Name = "Volunteer Approval Status")]
        [Required(ErrorMessage = "Enter in approval.")]
        public string ApprovalStatus { get; set; }

        [Display(Name = "Driver's License on File")]
        public bool DriversLicenseOnFile { get; set; }

        [Display(Name = "Social Security Card on File")]
        public bool SSCardOnFile { get; set; }


   
    }
}
