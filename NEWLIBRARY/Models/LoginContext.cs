using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace NEWLIBRARY.Models
{
    public class LoginContext
    {
        private string cs = ConfigurationManager.ConnectionStrings["MYDB"].ConnectionString;


        public IEnumerable<Login> allBook
        {

            get
            {
                string cms = "select * from LoginTb";

                List<Login> bOOKS = new List<Login>();

                using (OleDbConnection con = new OleDbConnection(cs))
                {
                    OleDbCommand cmd = new OleDbCommand(cms, con);

                    con.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Login bOOK = new Login()
                        {
                            ID = Convert.ToInt16(dr["ID"]),
                            _Password = dr["_Password"].ToString(),
                            _userName = dr["_userName"].ToString()
                            
                        };

                        bOOKS.Add(bOOK);
                    }


                }



                return bOOKS;
            }
        }

    }
}