using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace NEWLIBRARY.Models
{

    // table name=  ELIBRARYBOOKS
    public class BOOKCONTEXT
    {
        private string cs = ConfigurationManager.ConnectionStrings["MYDB"].ConnectionString;


        public void Delete_book(BOOKS bookDelete)
        {
            string cms = @"DELETE FROM ELIBRARYBOOKS  WHERE ID = @ID";

            using (OleDbConnection con = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand(cms, con);

                cmd.Parameters.AddWithValue("ID", "@ID").Value = bookDelete.ID;

                con.Open();
                cmd.ExecuteNonQuery();

            }

        }
         
        public void Edit_book(BOOKS bookEdit)
        {
            string cms = @"UPDATE ELIBRARYBOOKS SET DEPARTMENT = @DEPARTMENT ,AuthorName=@AuthorName ,VERSION=@VERSION ,BOOK_NAME=@BOOK_NAME ,BookID=@BookID ,Comment=@Comment ,Copies=@Copies ,CopyRightYear=@CopyRightYear ,MadeIn=@MadeIn ,PREVIEW=@PREVIEW ,PublisherYear=@PublisherYear, book_img = @book_img , book_img2 = @book_img2 , book_img3 = @book_img3   WHERE ID = @ID";

            using (OleDbConnection con = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand(cms, con);
                
                cmd.Parameters.AddWithValue("DEPARTMENT", "@DEPARTMENT").Value = bookEdit.DEPARTMENT;
                cmd.Parameters.AddWithValue("AuthorName", "@AuthorName").Value = bookEdit.AuthorName;
                cmd.Parameters.AddWithValue("VERSION", "@VERSION").Value = bookEdit.VERSION;
                cmd.Parameters.AddWithValue("BOOK_NAME", "@BOOK_NAME").Value = bookEdit.BOOK_NAME;
                cmd.Parameters.AddWithValue("BookID", "@BookID").Value = bookEdit.BookID;
                cmd.Parameters.AddWithValue("Comment", "@Comment").Value = bookEdit.Comment;
                cmd.Parameters.AddWithValue("Copies", "@Copies").Value = bookEdit.Copies;
                cmd.Parameters.AddWithValue("CopyRightYear", "@CopyRightYear").Value = bookEdit.CopyRightYear;
                cmd.Parameters.AddWithValue("MadeIn", "@MadeIn").Value = bookEdit.MadeIn;
                cmd.Parameters.AddWithValue("PREVIEW", "@PREVIEW").Value = bookEdit.PREVIEW;
                cmd.Parameters.AddWithValue("PublisherYear", "@PublisherYear").Value = bookEdit.PublisherYear;
                cmd.Parameters.AddWithValue("book_img", "@book_img").Value =  bookEdit.book_img;
                cmd.Parameters.AddWithValue("book_img3", "@book_img3").Value =  bookEdit.book_img2;
                cmd.Parameters.AddWithValue("book_img3", "@book_img3").Value = bookEdit.book_img3;
                cmd.Parameters.AddWithValue("ID", "@ID").Value = bookEdit.ID;

                con.Open();
                cmd.ExecuteNonQuery();


            }

        }
         

        public void AddBook(BOOKS bookadd)
        {
            string cms = @"insert into ELIBRARYBOOKS(AuthorName,VERSION,BOOK_NAME,BookID,Comment,Copies,CopyRightYear,MadeIn,PREVIEW,PublisherYear,DEPARTMENT,book_img,book_img2,book_img3)        VALUES(@AuthorName, @VERSION, @BOOK_NAME, @BookID, @Comment, @Copies, @CopyRightYear, @MadeIn, @PREVIEW, @PublisherYear, @DEPARTMENT, @book_img , @book_img2 , @book_img3 )";

            using (OleDbConnection con = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand(cms, con);



                cmd.Parameters.AddWithValue("AuthorName", "@AuthorName").Value = bookadd.AuthorName;
                cmd.Parameters.AddWithValue("VERSION", "@VERSION").Value = bookadd.VERSION;
                cmd.Parameters.AddWithValue("BOOK_NAME", "@BOOK_NAME").Value = bookadd.BOOK_NAME;
                cmd.Parameters.AddWithValue("BookID", "@BookID").Value = bookadd.BookID;
                cmd.Parameters.AddWithValue("Comment", "@Comment").Value = bookadd.Comment;
                cmd.Parameters.AddWithValue("Copies", "@Copies").Value = bookadd.Copies;
                cmd.Parameters.AddWithValue("CopyRightYear", "@CopyRightYear").Value = bookadd.CopyRightYear;
                cmd.Parameters.AddWithValue("MadeIn", "@MadeIn").Value = bookadd.MadeIn;
                cmd.Parameters.AddWithValue("PREVIEW", "@PREVIEW").Value = bookadd.PREVIEW;
                cmd.Parameters.AddWithValue("PublisherYear", "@PublisherYear").Value = bookadd.PublisherYear;
                cmd.Parameters.AddWithValue("DEPARTMENT", "@DEPARTMENT").Value = bookadd.DEPARTMENT;
                cmd.Parameters.AddWithValue("book_img", "@book_img").Value = bookadd.book_img;
                cmd.Parameters.AddWithValue("book_img2", "@book_img2").Value = bookadd.book_img2;
                cmd.Parameters.AddWithValue("book_img3", "@book_img3").Value = bookadd.book_img3;

                con.Open();
                cmd.ExecuteNonQuery();
            }





        }



        public IEnumerable<BOOKS> allBook
        {

            get
            {
                string cms = "select * from ELIBRARYBOOKS";

                List<BOOKS> bOOKS = new List<BOOKS>();

                using (OleDbConnection con = new OleDbConnection(cs))
                {
                    OleDbCommand cmd = new OleDbCommand(cms, con);

                    con.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BOOKS bOOK = new BOOKS()
                        {
                            ID = Convert.ToInt16(dr["ID"]),
                            AuthorName = dr["AuthorName"].ToString(),
                            VERSION = dr["VERSION"].ToString(),
                            BOOK_NAME = dr["BOOK_NAME"].ToString(),
                            DEPARTMENT = dr["DEPARTMENT"].ToString(),
                            BookID = Convert.ToInt16(dr["BookID"]),
                            Comment = dr["Comment"].ToString(),
                            Copies = Convert.ToInt16(dr["Copies"]),
                            CopyRightYear = Convert.ToDateTime(dr["CopyRightYear"]),
                            MadeIn = Convert.ToDateTime(dr["MadeIn"]),
                            PREVIEW = dr["PREVIEW"].ToString(),
                            PublisherYear = Convert.ToDateTime(dr["PublisherYear"]),
                            book_img = dr["book_img"].ToString(),
                            book_img2 = dr["book_img2"].ToString(),
                            book_img3 = dr["book_img3"].ToString(),
                        };

                        bOOKS.Add(bOOK);
                    }


                }



                return bOOKS;
            }
        }


    }


}