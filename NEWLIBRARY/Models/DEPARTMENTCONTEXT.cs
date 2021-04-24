using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace NEWLIBRARY.Models
{
    public class DEPARTMENTCONTEXT
    {
        private string css = ConfigurationManager.ConnectionStrings["MYDB"].ConnectionString;


        public IEnumerable<DEPARTMENTS> AllStudent
        {
            get
            {
                List<DEPARTMENTS> sTUDENTS = new List<DEPARTMENTS>();
                string scmd = "select * from ELIBRARYDEPARTMENT";

                using (OleDbConnection con = new OleDbConnection(css))
                {
                    OleDbCommand cmd = new OleDbCommand(scmd, con);

                    con.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        DEPARTMENTS sTUDENT = new DEPARTMENTS()
                        { 
                            DEPARTMENT = dr["DEPARTMENT"].ToString(),
                            ID = Convert.ToInt32(dr["ID"]),
                        };
                        sTUDENTS.Add(sTUDENT);
                    }
                }
                return sTUDENTS;
            }
        }



    }

}