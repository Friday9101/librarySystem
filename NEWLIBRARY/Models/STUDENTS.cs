using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NEWLIBRARY.Models
{

    // table name=  ELIBRARY_STUDENT
    public class STUDENTS : MultipleUser
    {


        [Display(Name = "Front Image")]
        public HttpPostedFileBase imgFile { set; get; }


        [Display(Name = "First Name")]
        [Required] 
        public string FirstName { set; get; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { set; get; }

        [Display(Name = " Matric Number")]
        [Required]
        public string MatricNumber { set; get; }

        [Display(Name = "Phone Number")]
        [Required]
        public string Phone { set; get; }

        [Display(Name = "Email")]
        [Required]
        public string ST_Email { set; get; }

        [Display(Name = "Password")]
        [Required]
        public string ST_Password { set; get; }

        [Display(Name = " Class Level")]
        [Required]
        public string ClassLevel { set; get; }

        [Display(Name = " Sex")]
        [Required]
        public string Sex { set; get; }

        [Display(Name = " Date Of Birth")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { set; get; }

        [Display(Name = "picture")]
        public string ST_IMAGE { set; get; }
    }

}