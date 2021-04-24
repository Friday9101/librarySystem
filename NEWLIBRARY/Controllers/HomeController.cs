using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NEWLIBRARY.Models;
using System.IO;

namespace NEWLIBRARY.Controllers
{

    [OutputCache(CacheProfile = "ssdss")]
    public class HomeController : Controller
    {


          
         

        //    DELETE  

        #region

        [ActionName("Deletelist")]
        public ActionResult Deletpost()
        {


            if (Session["matricn"] != null && Session["passw"] != null)
            {

                BOOKCONTEXT bck = new BOOKCONTEXT();

                return View(bck.allBook.ToList());

            }
            return RedirectToAction("Login", "admin");

        }



        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_post(BOOKS bookdel)
        {
            if (Session["matricn"] != null && Session["passw"] != null)
            {
                BOOKCONTEXT cldc = new BOOKCONTEXT();
                cldc.Delete_book(bookdel);

                return RedirectToAction("Deletelist", "ADMIN");
            }
            return RedirectToAction("Login", "admin");


        }


        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_get(int id)
        {


            if (Session["matricn"] != null && Session["passw"] != null)
            {

                BOOKCONTEXT bct = new BOOKCONTEXT();
                BOOKS bk = bct.allBook.Where(alb => alb.ID == id).Single();
                return View(bk);


            }
            return RedirectToAction("Login", "admin");

        }

        #endregion



        // DETAILS
        #region

        [ActionName("Detaillist")]
        public ActionResult Detailpost()
        {


            if (Session["matricn"] != null && Session["passw"] != null)
            {

                BOOKCONTEXT bck = new BOOKCONTEXT();

                return View(bck.allBook.ToList());
            }
            return RedirectToAction("Login", "admin");

        }


        [HttpGet]
        [ActionName("Details")]
        public ActionResult Details(int id)
        {

            if (Session["Password"] != null && Session["userName"] != null || Session["matricn"] != null && Session["passw"] != null)
            {
                if (ModelState.IsValid)
                {
                    BOOKCONTEXT bct = new BOOKCONTEXT();
                    BOOKS bk = bct.allBook.Where(alb => alb.ID == id).Single();
                    return View(bk);
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

            return View();


        }

        #endregion





        //  Edit  
        #region


        [ActionName("Editlist")]
        public ActionResult Edit_post()
        {
            if (Session["matricn"] != null && Session["passw"] != null)
            {
                BOOKCONTEXT bck = new BOOKCONTEXT();

                return View(bck.allBook.ToList());
            }
            return RedirectToAction("Login", "admin");
        }



        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_post(BOOKS bookedit)
        {
            if (ModelState.IsValid)
            {



                string fileName = Path.GetFileNameWithoutExtension(bookedit.imgFile.FileName);
                string exetensionx = Path.GetExtension(bookedit.imgFile.FileName);

                string fileName2 = Path.GetFileNameWithoutExtension(bookedit.imgFile2.FileName);
                string exetensionx2 = Path.GetExtension(bookedit.imgFile2.FileName);


                string fileName3 = Path.GetFileNameWithoutExtension(bookedit.imgFile3.FileName);
                string exetensionx3 = Path.GetExtension(bookedit.imgFile3.FileName);



                if (fileName.Length <= 0 && fileName3.Length > 0 && fileName2.Length > 0)
                {
                    #region
                    if (ModelState.IsValid)
                    {

                        fileName2 += DateTime.Now.ToString("symff") + exetensionx2;
                        bookedit.book_img2 = "~/imagesUploads/" + fileName2;
                        fileName2 = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName2);
                        bookedit.imgFile2.SaveAs(fileName2);



                        fileName3 += DateTime.Now.ToString("symff") + exetensionx3;
                        bookedit.book_img3 = "~/imagesUploads/" + fileName3;
                        fileName3 = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName3);
                        bookedit.imgFile3.SaveAs(fileName3);

                        BOOKCONTEXT bcadd = new BOOKCONTEXT();
                        bcadd.Edit_book(bookedit);

                        return RedirectToAction("AllBook");
                    }
                    else
                    {

                        BOOKCONTEXT bct = new BOOKCONTEXT();
                        BOOKS bk = bct.allBook.Where(alb => alb.ID == bookedit.ID).Single();
                        return View(bk);

                    }
                    #endregion
                }
                else if (fileName2.Length <= 0 && fileName3.Length > 0 && fileName.Length > 0)
                {
                    #region

                    if (ModelState.IsValid)
                    {

                        fileName += DateTime.Now.ToString("symff") + exetensionx;
                        bookedit.book_img = "~/imagesUploads/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName);
                        bookedit.imgFile.SaveAs(fileName);



                        fileName3 += DateTime.Now.ToString("symff") + exetensionx3;
                        bookedit.book_img3 = "~/imagesUploads/" + fileName3;
                        fileName3 = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName3);
                        bookedit.imgFile3.SaveAs(fileName3);

                        BOOKCONTEXT bcadd = new BOOKCONTEXT();
                        bcadd.Edit_book(bookedit);

                        return RedirectToAction("AllBook");
                    }
                    else
                    {

                        BOOKCONTEXT bct = new BOOKCONTEXT();
                        BOOKS bk = bct.allBook.Where(alb => alb.ID == bookedit.ID).Single();
                        return View(bk);

                    }
                    #endregion
                }

                else if (fileName3.Length <= 0 && fileName2.Length > 0 && fileName.Length > 0)
                {
                    #region

                    if (ModelState.IsValid)
                    {

                        fileName += DateTime.Now.ToString("symff") + exetensionx;
                        bookedit.book_img = "~/imagesUploads/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName);
                        bookedit.imgFile.SaveAs(fileName);



                        fileName2 += DateTime.Now.ToString("symff") + exetensionx2;
                        bookedit.book_img2 = "~/imagesUploads/" + fileName2;
                        fileName2 = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName2);
                        bookedit.imgFile2.SaveAs(fileName2);

                        BOOKCONTEXT bcadd = new BOOKCONTEXT();
                        bcadd.Edit_book(bookedit);

                        return RedirectToAction("AllBook");
                    }
                    else
                    {

                        BOOKCONTEXT bct = new BOOKCONTEXT();
                        BOOKS bk = bct.allBook.Where(alb => alb.ID == bookedit.ID).Single();
                        return View(bk);

                    }
                    #endregion
                }
                else if (fileName2.Length <= 0 && fileName3.Length <= 0 && fileName.Length > 0)
                {
                    #region

                    if (ModelState.IsValid)
                    {

                        fileName += DateTime.Now.ToString("symff") + exetensionx;
                        bookedit.book_img = "~/imagesUploads/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName);
                        bookedit.imgFile.SaveAs(fileName);


                        BOOKCONTEXT bcadd = new BOOKCONTEXT();
                        bcadd.Edit_book(bookedit);

                        return RedirectToAction("AllBook");
                    }
                    else
                    {

                        BOOKCONTEXT bct = new BOOKCONTEXT();
                        BOOKS bk = bct.allBook.Where(alb => alb.ID == bookedit.ID).Single();
                        return View(bk);

                    }
                    #endregion
                }


                else if (fileName.Length <= 0 && fileName3.Length <= 0 && fileName2.Length > 0)
                {
                    #region

                    if (ModelState.IsValid)
                    {

                        fileName2 += DateTime.Now.ToString("symff") + exetensionx2;
                        bookedit.book_img2 = "~/imagesUploads/" + fileName2;
                        fileName2 = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName2);
                        bookedit.imgFile2.SaveAs(fileName2);


                        BOOKCONTEXT bcadd = new BOOKCONTEXT();
                        bcadd.Edit_book(bookedit);

                        return RedirectToAction("AllBook");
                    }
                    else
                    {

                        BOOKCONTEXT bct = new BOOKCONTEXT();
                        BOOKS bk = bct.allBook.Where(alb => alb.ID == bookedit.ID).Single();
                        return View(bk);

                    }
                    #endregion
                }

                else if (fileName.Length <= 0 && fileName2.Length <= 0 && fileName3.Length > 0)
                {
                    #region

                    if (ModelState.IsValid)
                    {
                        fileName3 += DateTime.Now.ToString("symff") + exetensionx3;
                        bookedit.book_img3 = "~/imagesUploads/" + fileName3;
                        fileName3 = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName3);
                        bookedit.imgFile3.SaveAs(fileName3);

                        BOOKCONTEXT bcadd = new BOOKCONTEXT();
                        bcadd.Edit_book(bookedit);

                        return RedirectToAction("AllBook");
                    }
                    else
                    {

                        BOOKCONTEXT bct = new BOOKCONTEXT();
                        BOOKS bk = bct.allBook.Where(alb => alb.ID == bookedit.ID).Single();
                        return View(bk);

                    }
                    #endregion
                }
                else
                {
                    #region

                    if (ModelState.IsValid)
                    {
                        #region
                        fileName += DateTime.Now.ToString("symff") + exetensionx;
                        bookedit.book_img = "~/imagesUploads/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName);
                        bookedit.imgFile.SaveAs(fileName);


                        fileName2 += DateTime.Now.ToString("symff") + exetensionx2;
                        bookedit.book_img2 = "~/imagesUploads/" + fileName2;
                        fileName2 = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName2);
                        bookedit.imgFile2.SaveAs(fileName2);




                        fileName3 += DateTime.Now.ToString("symff") + exetensionx3;
                        bookedit.book_img3 = "~/imagesUploads/" + fileName3;
                        fileName3 = Path.Combine(Server.MapPath("~/imagesUploads/"), fileName3);
                        bookedit.imgFile3.SaveAs(fileName3);

                        #endregion

                        BOOKCONTEXT bcadd = new BOOKCONTEXT();
                        bcadd.Edit_book(bookedit);

                        return RedirectToAction("index", "admin");
                    }

                    else
                    {

                        BOOKCONTEXT bct = new BOOKCONTEXT();
                        BOOKS bk = bct.allBook.Where(alb => alb.ID == bookedit.ID).Single();
                        return View(bk);

                    }
                    #endregion


                }


            }
            BOOKCONTEXT bct2 = new BOOKCONTEXT();
            BOOKS bk2 = bct2.allBook.Where(alb => alb.ID == bookedit.ID).Single();
            return View(bk2);

        }


        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            if (Session["matricn"] != null && Session["passw"] != null)
            {

                BOOKCONTEXT bct = new BOOKCONTEXT();
                BOOKS bk = bct.allBook.Where(alb => alb.ID == id).Single();


                return View(bk);

            }
            return RedirectToAction("Login", "admin");



        }
        #endregion



        // Create
        #region
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_book_POST(BOOKS bOOk)
        {
            if (Session["matricn"] != null && Session["passw"] != null)
            {
                if (ModelState.IsValid)
                {

                    string filename = Path.GetFileNameWithoutExtension(bOOk.imgFile.FileName);
                    string fileextension = Path.GetExtension(bOOk.imgFile.FileName);


                    filename += DateTime.Now.ToString("smyff") + fileextension;
                    bOOk.book_img = "~/imagesUploads/" + filename;

                    filename = Path.Combine(Server.MapPath("~/imagesUploads/"), filename);
                    bOOk.imgFile.SaveAs(filename);





                    string filename3 = Path.GetFileNameWithoutExtension(bOOk.imgFile3.FileName);
                    string fileextension3 = Path.GetExtension(bOOk.imgFile3.FileName);


                    filename3 += DateTime.Now.ToString("smyff") + fileextension3;
                    bOOk.book_img3 = "~/imagesUploads/" + filename3;

                    filename3 = Path.Combine(Server.MapPath("~/imagesUploads/"), filename3);
                    bOOk.imgFile3.SaveAs(filename3);





                    string filename2 = Path.GetFileNameWithoutExtension(bOOk.imgFile2.FileName);
                    string fileextension2 = Path.GetExtension(bOOk.imgFile2.FileName);


                    filename2 += DateTime.Now.ToString("smyff") + fileextension2;
                    bOOk.book_img2 = "~/imagesUploads/" + filename2;

                    filename2 = Path.Combine(Server.MapPath("~/imagesUploads/"), filename2);
                    bOOk.imgFile2.SaveAs(filename2);








                    BOOKCONTEXT bkc = new BOOKCONTEXT();

                    bkc.AddBook(bOOk);

                    return RedirectToAction("index", "admin");

                }

                return View();

            }



            return RedirectToAction("Login", "admin");

        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_book_GET()
        {

            if (Session["matricn"] != null && Session["passw"] != null)
            {

                return View();

            }
            return RedirectToAction("Login", "admin");





        }

        #endregion




        // log in and out
        #region

        [HttpGet]
        [ActionName("Logout")]
        public ActionResult LogOut_get()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }



        [HttpGet]
        [ActionName("Login")]
        public ActionResult Login_get()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login(string nam, string pass)
        {
            STUDENTCONTEXT bc = new STUDENTCONTEXT();
            #region
            try
            {


                if (ModelState.IsValid)
                {

                    STUDENTS lg = bc.AllStudent.Where(k => k.MatricNumber.ToUpper() == nam.ToUpper() && k.ST_Password == pass).Single();

                    Session["Password"] = lg.ST_Password;
                    Session["userName"] = lg.MatricNumber;
                    Session["userprofile"] = lg.FirstName + " " + lg.LastName;
                    Session["id"] = lg.ID;

                    if (Session["userName"] != null && Session["Password"] != null)
                    {
                        return RedirectToAction("index");
                    }

                }
            }
            catch (Exception)
            {
            }

            #endregion

            if (nam == "" || nam == null || pass == "" || pass == null)
            {

                if (nam == "" || nam == null)
                {
                    ViewBag.ErrorMessagename = "NAME IS REQUIRE";
                }
                if (pass == "" || pass == null)
                {
                    ViewBag.ErrorMessagepass = "PASSWORD IS REQUIRE";
                }

            }
            else
            {

                ViewBag.ErrorMessage = "WRONG LOGIN";
            }

            return View();
        }



        #endregion


        [ActionName("AllBook")]
        public ActionResult AllBook(string Search_Data = "")
        {




            if (Session["Password"] != null && Session["userName"] != null)
            {
                if (ModelState.IsValid)
                {

                    BOOKCONTEXT bc = new BOOKCONTEXT();
                    List<BOOKS> allb = bc.allBook.Where(bn => bn.BOOK_NAME.ToUpper().Contains(Search_Data.ToUpper())).ToList();

                    return View(allb);
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

            // Response.Write(sessionstatez);

            return View();
        }


        public ActionResult Index()
        {


            if (Session["Password"] != null && Session["userName"] != null)
            {
                if (ModelState.IsValid)
                {

                    BOOKCONTEXT ncc = new BOOKCONTEXT();
                    int lastbookId = ncc.allBook.Last().ID;

                    BOOKS b = ncc.allBook.Single(n => n.ID == lastbookId);
                    ViewBag.titlezA = b.BOOK_NAME;
                    ViewBag.messagezA = b.PREVIEW;
                    ViewBag.datezA = b.PublisherYear.ToShortDateString();
                    ViewBag.timezA = b.PublisherYear.ToShortTimeString();
                    ViewBag.idzA = b.ID;


                   List< BOOKS> LASTFIVE = ncc.allBook.Where(M => M.ID > lastbookId - 2).ToList();


                    List<BOOKS> F = ncc.allBook.ToList();
                    return View(F);

                }
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();


        }

    }

}
