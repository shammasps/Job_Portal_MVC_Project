using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSerach_MVC.Models
{
    public class CVInsert
    {
        public int User_id { get; set; }
        public int Job_id { get; set; }
        public int Company_id { get; set; }
        
        public string Resume { get; set; }
        public DateTime Sub_date { get; set; }
        public string status { get; set; }
        public string msg { get; set; }
    }
}