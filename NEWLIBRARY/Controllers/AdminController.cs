using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEWLIBRARY.Models;
using System.IO;

namespace NEWLIBRARY.Controllers
{
    public class AdminController : Controller
    {



        //  Delete  STUDENTS
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

                return RedirectToAction("Deletelist", "admin");

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




        //  Details  STUDENTS
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

            if (Session["matricn"] != null && Session["passw"] != null)
            {

                STUDENTCONTEXT sc = new STUDENTCONTEXT();

                STUDENTS stn = sc.AllStudent.Single(s => s.ID == id);
                return View(stn);


            }
            return RedirectToAction("Login", "admin");

        }

        #endregion

        //  Edit STUDENTS
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


                    //STUDENTS usm = sc.AllStudent.Where(u => u.ST_Password == stEdit.password && u.MatricNumber.ToUpper() == matricNumber.ToUpper()).Single();

                    //Session["matricn"] = usm.MatricNumber.ToUpper();
                    //Session["passw"] = usm.ST_Password;
                    //Session["uID"] = usm.ID;
                    //Session["Userprofil"] = usm.FirstName.ToUpper() + " " + usm.LastName.ToUpper();



                    return RedirectToAction("Editlist", "admin");
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



        //  Create STUDENTS
        #region

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Createget()
        {
            if (Session["matricn"] != null && Session["passw"] != null)
            { return View(); }
            return RedirectToAction("Login", "admin");
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(STUDENTS STUDENt)
        {
            if (Session["matricn"] != null && Session["passw"] != null)
            {

                if (ModelState.IsValid)
                {
                    STUDENTCONTEXT sc = new STUDENTCONTEXT();

                    string fileName = Path.GetFileNameWithoutExtension(STUDENt.imgFile.FileName);
                    string exetensionx = Path.GetExtension(STUDENt.imgFile.FileName);

                    fileName += DateTime.Now.ToString("symff") + exetensionx;
                    STUDENt.ST_IMAGE = "~/imagesUploads/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName);
                    STUDENt.imgFile.SaveAs(fileName);


                    sc.AddStudent(STUDENt);
                    return RedirectToAction("index", "Admin");


                }
                return View();


            }
            return RedirectToAction("Login", "admin");

        }

        #endregion

        #region

        [HttpGet]
        [ActionName("Logout")]
        public ActionResult LogOut_get()
        {
            Session.Abandon();
            return RedirectToAction("Login", "admin");
        }
        [HttpGet]
        [ActionName("Login")]
        public ActionResult Login_get()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login(string matricNumber, string password)
        {
            if (ModelState.IsValid)
            {
                STUDENTCONTEXT uc = new STUDENTCONTEXT();
                int zcount = uc.AllStudent.Where(u => u.ST_Password == password && u.MatricNumber.ToUpper() == matricNumber.ToUpper()).Count();

                if (zcount > 0)
                {
                    STUDENTS usm = uc.AllStudent.Where(u => u.ST_Password == password && u.MatricNumber.ToUpper() == matricNumber.ToUpper()).Single();

                    Session["matricn"] = usm.MatricNumber.ToUpper();
                    Session["passw"] = usm.ST_Password;
                    Session["uID"] = usm.ID;
                    Session["Userprofil"] = usm.FirstName.ToUpper() + " " + usm.LastName.ToUpper();

                    return RedirectToAction("index", "Admin");
                }
            }
            if (password == "" || matricNumber == "")
            {
                if (matricNumber == null || matricNumber == "")
                {
                    ViewBag.matri = "require matricNumber";
                }
                if (password == null || password == "")
                {
                    ViewBag.passer = "require password";
                }
            }

            else
            {
                ViewBag.loginerror = "WRONG LOGIN";
            }
            return View();

        }
        #endregion
        public ActionResult Index(string Search_Data = "")
        {
            if (Session["matricn"] != null && Session["passw"] != null)
            {
                STUDENTCONTEXT stc = new STUDENTCONTEXT();
                List<STUDENTS> alst = stc.AllStudent.ToList();

                ViewBag.allstudentz = alst;

                BOOKCONTEXT bkc = new BOOKCONTEXT();

                List<BOOKS> bk = bkc.allBook.ToList();

                return View(bk);
            }
            return RedirectToAction("Login", "admin");
        }

    }
}
