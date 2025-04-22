using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSerach_MVC.Models
{
    public class CheckBoxListBind
    {
        public string Values { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class UserInsert
    {
        public int uId { get; set; }
        [Required(ErrorMessage = "Enter The Name")]
        public string uName { get; set; }
        [Required(ErrorMessage = "Enter The Address")]
        public string uAddress { get; set; }
        [Required(ErrorMessage = "Enter User Number")]
        [RegularExpression(@"([0]|\+91)?[789]\d{9}$", ErrorMessage = "Enter Valid Number ")]
        public long? uPhone { get; set; }
            
        [Required(ErrorMessage = "Enter The Email")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid email address")]
        public string uEmail { get; set; }
        [Required(ErrorMessage = "Enter The Skills")]
        public string uSkills { get; set; }
        [Required(ErrorMessage = "Enter The Experience in Years")]
        public int? uExp { get; set; }
        public List<CheckBoxListBind> MyQual { get; set; }
        public string[] selectedQual { get; set; }
        public string uQulfication { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime uDOB { get; set; }
        [Required(ErrorMessage = "Enter Your Country")]
        public string uCountry { get; set; }
        [Required(ErrorMessage = "Enter Your State")]
        public string uState { get; set; }
        [Required(ErrorMessage = "Enter Your City")]
        public string uCity { get; set; }
        [Required(ErrorMessage = "Enter Select your Gender ")]
        public string uGender { get; set; }
        
        public string uPhoto { get; set; }
        [Required(ErrorMessage = "Enter Your Pincode")]
        public string uPincode { get; set; }
        
        public string uLinkedIn_Profile { get; set; }
        [Required(ErrorMessage = "Enter Username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string password { get; set; }
        [Compare("password", ErrorMessage = "Password Not Match")]
        public string cPassword { get; set; }
        public string usermsg { get; set; }
    }
}