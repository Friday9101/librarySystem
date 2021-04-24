using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NEWLIBRARY.Models
{
    public class Login 
    {
        [Display(Name="USER NAME")]
        public string _userName { set; get; }

        [Display(Name = "PASSWORD")]
        public string _Password { set; get; }


        public int ID { set; get;  }
        
      //  public string _Email  { set; get; }  


    }
}