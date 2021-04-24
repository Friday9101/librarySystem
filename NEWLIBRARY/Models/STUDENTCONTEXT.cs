using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace NEWLIBRARY.Models
{
    // table name=  STUDENTS

    public class STUDENTCONTEXT
    {
        private string css = ConfigurationManager.ConnectionStrings["MYDB"].ConnectionString;




        public void DeleteStuedent(STUDENTS deleteStuedent)
        {
             
            string cms = @"DELETE FROM STUDENTS  WHERE ID = @ID";

            using (OleDbConnection con = new OleDbConnection(css))
            {
                OleDbCommand cmd = new OleDbCommand(cms, con);

                cmd.Parameters.AddWithValue("ID", "@ID").Value = deleteStuedent.ID;

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
         
        public void EditStudent(STUDENTS editStudents)
        {
            string scmd = @"UPDATE STUDENTS SET FirstName = @FirstName,  LastName = @LastName,  ClassLevel = @ClassLevel, DateOfBirth = @DateOfBirth,  DEPARTMENT = @DEPARTMENT,  ST_Email = @ST_Email,  MatricNumber = @MatricNumber,  ST_Password = @ST_Password,  Phone = @Phone,  Sex = @Sex WHERE ID = @ID";


            using (OleDbConnection con = new OleDbConnection(css)) 
            {
                OleDbCommand cmd = new OleDbCommand(scmd, con);

                cmd.Parameters.AddWithValue("FirstName", "@FirstName").Value = editStudents.FirstName;
                cmd.Parameters.AddWithValue("LastName", "@LastName").Value = editStudents.LastName;
                cmd.Parameters.AddWithValue("ClassLevel", "@ClassLevel").Value = editStudents.ClassLevel;
                cmd.Parameters.AddWithValue("DateOfBirth", "@DateOfBirth").Value = editStudents.DateOfBirth;
                cmd.Parameters.AddWithValue("DEPARTMENT", "@DEPARTMENT").Value = editStudents.DEPARTMENT;
                cmd.Parameters.AddWithValue("ST_Email", "@ST_Email").Value = editStudents.ST_Email;
                cmd.Parameters.AddWithValue("MatricNumber", "@MatricNumber").Value = editStudents.MatricNumber;
                cmd.Parameters.AddWithValue("ST_Password", "@ST_Password").Value = editStudents.ST_Password;
                cmd.Parameters.AddWithValue("Phone", "@Phone").Value = editStudents.Phone;
                cmd.Parameters.AddWithValue("Sex", "@Sex").Value = editStudents.Sex;
               // cmd.Parameters.AddWithValue("ST_IMAGE", "@ST_IMAGE").Value = editStudents.ST_IMAGE;
                cmd.Parameters.AddWithValue("ID", "@ID").Value = editStudents.ID;

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void AddStudent(STUDENTS AddsTUDENT)
        {
            string scmd = "insert into STUDENTS(FirstName, LastName, ClassLevel, DateOfBirth, DEPARTMENT, ST_Email, MatricNumber, ST_Password, Phone, Sex, ST_IMAGE)    VALUES(@FirstName,  @LastName,  @ClassLevel, @DateOfBirth,  @DEPARTMENT,  @ST_Email,  @MatricNumber,  @ST_Password,  @Phone,  @Sex, @ST_IMAGE)";


            using (OleDbConnection con = new OleDbConnection(css))
            {
                OleDbCommand cmd = new OleDbCommand(scmd, con);

                cmd.Parameters.AddWithValue("FirstName", "@FirstName").Value = AddsTUDENT.FirstName;
                cmd.Parameters.AddWithValue("LastName", "@LastName").Value = AddsTUDENT.LastName;
                cmd.Parameters.AddWithValue("ClassLevel", "@ClassLevel").Value = AddsTUDENT.ClassLevel;
                cmd.Parameters.AddWithValue("DateOfBirth", "@DateOfBirth").Value = AddsTUDENT.DateOfBirth;
                cmd.Parameters.AddWithValue("DEPARTMENT", "@DEPARTMENT").Value = AddsTUDENT.DEPARTMENT;
                cmd.Parameters.AddWithValue("ST_Email", "@ST_Email").Value = AddsTUDENT.ST_Email;
                cmd.Parameters.AddWithValue("MatricNumber", "@MatricNumber").Value = AddsTUDENT.MatricNumber;
                cmd.Parameters.AddWithValue("ST_Password", "@ST_Password").Value = AddsTUDENT.ST_Password;
                cmd.Parameters.AddWithValue("Phone", "@Phone").Value = AddsTUDENT.Phone;
                cmd.Parameters.AddWithValue("Sex", "@Sex").Value = AddsTUDENT.Sex;
                cmd.Parameters.AddWithValue("ST_IMAGE", "@ST_IMAGE").Value = AddsTUDENT.ST_IMAGE;

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public IEnumerable<STUDENTS> AllStudent
        {
            get
            {
                List<STUDENTS> sTUDENTS = new List<STUDENTS>();
                string scmd = "select * from STUDENTS";

                using (OleDbConnection con = new OleDbConnection(css))
                {
                    OleDbCommand cmd = new OleDbCommand(scmd, con);

                    con.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        STUDENTS sTUDENT = new STUDENTS()
                        {
                            ClassLevel = dr["ClassLevel"].ToString(),
                            ID = Convert.ToInt32(dr["ID"]),
                            Sex = dr["Sex"].ToString(),
                            DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                            DEPARTMENT = dr["DEPARTMENT"].ToString(),
                            ST_Email = dr["ST_Email"].ToString(),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            MatricNumber = dr["MatricNumber"].ToString(),
                            ST_Password = dr["ST_Password"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            ST_IMAGE = dr["ST_IMAGE"].ToString(),
                        };
                        sTUDENTS.Add(sTUDENT);
                    }
                }
                return sTUDENTS;
            }
        }
    }

}