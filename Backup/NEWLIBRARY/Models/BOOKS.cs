using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NEWLIBRARY.Models
{

    [MetadataType(typeof(BOOKSd))]
    public partial class BOOKS { 

    } 

    public partial class BOOKS : MultipleUser 
    {


        [Required]
        [Display(Name = "Front Image")]
        public HttpPostedFileBase imgFile { set; get; }

        [Required]
        [Display(Name = "back Image")]
        public HttpPostedFileBase imgFile2 { set; get; }


        [Required]
        [Display(Name = "Other Image")]
        public HttpPostedFileBase imgFile3 { set; get; }


        public int BookID { set; get; }

        public string AuthorName { set; get; }

        [Required] 
        [Display(Name = "BOOK NAME ")]
        public string BOOK_NAME { set; get; }

      //  [Required]
        [Display(Name = "IMAGE ")]
        public string book_img { set; get; }

       // [Required]
        [Display(Name = "IMAGE ")]
        public string book_img2 { set; get; }

        [Display(Name = "IMAGE ")]
       // [Required]
        public string book_img3 { set; get; }


        [Required]
        [Display(Name = "Made In ")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime MadeIn { set; get; }

        [Required]
        [Display(Name = "Publisher Year ")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime PublisherYear { set; get; }

        [Required]
        [Display(Name = "Copy Right Year ")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CopyRightYear { set; get; }

        [Required]
        [Display(Name = "VERSION ")]
        public string VERSION { set; get; }

        [Required]
        [Display(Name = "Copies ")]
        public int Copies { set; get; }

        [Required]
        [Display(Name = "Comment ")]
        public string Comment { set; get; }

        [Required]
        [Display(Name = "PREVIEW ")]
        public string PREVIEW { set; get; }

    }



    public partial class BOOKSd {
        [Required]
        [Display(Name = "Book ID")]
        public int BookID { set; get; }


        [Required]
        [Display(Name = "Author Name ")]
        public string AuthorName { set; get; }

    }
}