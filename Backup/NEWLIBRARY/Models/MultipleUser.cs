using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NEWLIBRARY.Models
{

    public class MultipleUser
    {

        //   private string css = ConfigurationManager.ConnectionStrings["MYDB"].ConnectionString;

        [Display(Name = " ID:")]
        public int ID { set; get; }

        [Required]
        [Display(Name = "DEPARTMENT ")] // 
        public string DEPARTMENT { set; get; }

    }
}