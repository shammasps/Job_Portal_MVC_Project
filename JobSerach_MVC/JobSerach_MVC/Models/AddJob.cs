using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSerach_MVC.Models
{
    public class AddJob
    {
        public int Company_Id { get; set; }

        [Required(ErrorMessage = "Job Title is required")]
        public string Job_Title { get; set; }

        [Required(ErrorMessage = "Job Description is required")]
        public string Job_Description { get; set; }

        [Required(ErrorMessage = "Job Skills are required")]
        public string Job_Skills { get; set; }

        [Required(ErrorMessage = "Experience in years is required")]
        public int Jobexp_Year { get; set; }

        [Required(ErrorMessage = "Minimum qualification is required")]
        public string Min_Qulification { get; set; }
        public string Job_Status { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        public DateTime Job_EndDate { get; set; }

        public string msg { get; set; }
    }
}