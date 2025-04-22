using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSerach_MVC.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter The user Name")]
        public string username { get; set; }
        [Required(ErrorMessage = "Enter The Password")]
        public string password { get; set; }
        public string msg { get; set; }
        public string loginType { get; set; }
    }
}