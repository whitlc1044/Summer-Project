using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_SemesterAssignment.Models
{
    public class OppurtunityModel
    {
        
        public int ID { get; set; }

        [Display(Name = "Oppurtunity Name")]
        [Required(ErrorMessage = "Please enter the name of the oppurtunity")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the date of the oppurtunity")]
        [Display(Name = "Oppurtunity Date")]
        [DataType(DataType.Date)]
        public string Date { get; set; }


        [Display(Name = "Center")]
        [Required(ErrorMessage = "Please enter the center the oppurtunity is located in")]
        public string Center { get; set; }

        [Display(Name = "Oppurtunity Description")]
        public string Description { get; set; }

    }
}
