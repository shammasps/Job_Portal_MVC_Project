using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSerach_MVC.Models
{
    public class CompanyInsert
    {
        public int Cmp_Id { get; set; }
        [Required(ErrorMessage = "Enter Company Name")]
        public string Cmp_Name { get; set; }
        [Required(ErrorMessage = "Enter Company Address")]
        public string Cmp_Address { get; set; }
        [Required(ErrorMessage = "Enter Company Email")]
        [RegularExpression (@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid email address")]
        public string Cmp_Email { get; set; }
        [Required(ErrorMessage = "Enter Company Website Address")]
        public string Cmp_WebAddress { get; set; }
        [Required(ErrorMessage = "Enter Company Email")]
        [RegularExpression(@"([0]|\+91)?[789]\d{9}$", ErrorMessage = "Enter Valid Number ")]
        public long Cmp_Phone { get; set; }
        [Required (ErrorMessage ="Enter User Name")]
        public string username { get; set; }
        public string password { get; set; }
        [Compare("password", ErrorMessage = "Password Not Match")]
        public string cpassword { get; set; }
        public string Cmp_msg { get; set; }
    }
}