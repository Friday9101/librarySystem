using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEWLIBRARY.Models;
using System.IO;

namespace NEWLIBRARY.Controllers
{
    public class STUDENTSController : Controller
    {


        //  Delete
        #region


        [ActionName("Deletelist")]
        public ActionResult Deletelist()
        {

            if (Session["matricn"] != null && Session["passw"] != null)
            {
            STUDENTCONTEXT sc = new STUDENTCONTEXT();
            List<STUDENTS> stn = sc.AllStudent.ToList();
            return View(stn);
            }
            return RedirectToAction("Login", "admin");

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_post(STUDENTS studentDelete)
        {

                if (Session["matricn"] != null && Session["passw"] != null)
                {
                STUDENTCONTEXT st = new STUDENTCONTEXT();
                st.DeleteStuedent(studentDelete);

                return RedirectToAction("Index", "students");
                }
                return RedirectToAction("Login", "admin");




        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Deleted(int id)
        {

                if (Session["matricn"] != null && Session["passw"] != null)
                {
                STUDENTCONTEXT sc = new STUDENTCONTEXT();
                STUDENTS stn = sc.AllStudent.Single(s => s.ID == id);
                return View(stn);
                }
                return RedirectToAction("Login", "admin");


        }

        #endregion


        //  Details
        #region

        [ActionName("Detailslist")]
        public ActionResult Detailslist()
        {

            if (Session["matricn"] != null && Session["passw"] != null)
            {
            STUDENTCONTEXT sc = new STUDENTCONTEXT();
            List<STUDENTS> stn = sc.AllStudent.ToList();
            return View(stn);
            }
            return RedirectToAction("Login", "admin");

        }

        [ActionName("Details")]
        public ActionResult Details(int id)
        {

            if (Session["Password"] != null && Session["userName"] != null || Session["matricn"] != null && Session["passw"] != null )
            {
                    STUDENTCONTEXT sc = new STUDENTCONTEXT();

                    STUDENTS stn = sc.AllStudent.Single(s => s.ID == id);
                    return View(stn);


                }


            return RedirectToAction("Login", "Home");


        }

        #endregion



        //  Edit
        #region

        [ActionName("Editlist")]
        public ActionResult Editlist()
        {

            if (Session["matricn"] != null && Session["passw"] != null)
            {
            STUDENTCONTEXT sc = new STUDENTCONTEXT();
            List<STUDENTS> stn = sc.AllStudent.ToList();
            return View(stn);
            }
            return RedirectToAction("Login", "admin");

        }


        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(STUDENTS stEdit)
        {

            if (Session["matricn"] != null && Session["passw"] != null)
            {
            STUDENTCONTEXT sc = new STUDENTCONTEXT();
            if (ModelState.IsValid)
            {
                sc.EditStudent(stEdit);
                return RedirectToAction("index");
            }

            STUDENTS s = sc.AllStudent.Single(als => als.ID == stEdit.ID);
            ViewBag.ima = s.ST_IMAGE.ToString();
            return View(s);

            }
            return RedirectToAction("Login", "admin");

        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditGet(int id)
        {
            if (Session["matricn"] != null && Session["passw"] != null)
            {
            STUDENTCONTEXT sc = new STUDENTCONTEXT();
            STUDENTS s = sc.AllStudent.Single(als => als.ID == id);
            ViewBag.ima = s.ST_IMAGE.ToString();
            return View(s);

            }
            return RedirectToAction("Login", "admin");

        }

        #endregion


        //  Create
        #region

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Createget()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(STUDENTS STUDENt)
        {

            if (Session["Password"] != null && Session["userName"] != null)
            {
                if (ModelState.IsValid)//STUDENt
                {
                    STUDENTCONTEXT sc = new STUDENTCONTEXT();

                    string fileName = Path.GetFileNameWithoutExtension(STUDENt.imgFile.FileName);
                    string exetensionx = Path.GetExtension(STUDENt.imgFile.FileName);

                    fileName += DateTime.Now.ToString("symff") + exetensionx;
                    STUDENt.ST_IMAGE = "~/imagesUploads/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName);
                    STUDENt.imgFile.SaveAs(fileName);


                    sc.AddStudent(STUDENt);
                    return RedirectToAction("index");


                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }






        }

        #endregion



        public ActionResult Index(string searching = "")
        {

            if (Session["Password"] != null && Session["userName"] != null)
            {
                if (ModelState.IsValid)
                {
                    STUDENTCONTEXT sc = new STUDENTCONTEXT();
                    List<STUDENTS> stu = sc.AllStudent.Where(h => h.LastName.ToUpper().Contains(searching.ToUpper()) || h.FirstName.ToUpper().Contains(searching.ToUpper())).ToList();
                    return View(stu);
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }



            return RedirectToAction("Login", "Home");




        }

    }
}
