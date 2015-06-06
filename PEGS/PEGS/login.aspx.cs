using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PEGS
{
    /* dear self 
     SQL INJECTION WORKS FOR
     RESEARCHING PURPOSES*/
    public partial class login : System.Web.UI.Page
    {
        /*
        static string paath=HttpContext.Current.Server.MapPath("App_Data/MySqlDB.mdf");
        static string bla = @"Data Source=(localdb)\v11.0;AttachDbFilename=" + paath + ";Integrated Security=True";
        SqlConnection con = new SqlConnection(bla);
         */
        public string errors = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //con.Open();
            if (Session["user"] != null)
                Response.Redirect("notallowed.aspx");


            string fileName = "MySqlDB.mdf";
            string tableName = "supportt";
            if (Request.Form["submit"] != null)
            {
                string idNum = Request.Form["idNum"];
                string pass = Request.Form["password"];
                string selectQuary = "SELECT * FROM supportt WHERE CONVERT(NVARCHAR(MAX), idNum)='";
                selectQuary += idNum + "' AND CONVERT(NVARCHAR(MAX), password) ='" + pass + "'";
                /*
                SqlCommand search=new SqlCommand(selectQuary,con);
                SqlDataReader data = search.ExecuteReader();
                bool there = (bool)data.Read();*/
                if (!(idNum.Contains('\'') || pass.Contains('\'')))
                {
                    if (SqlHelper.IsExist(fileName, selectQuary))
                    {
                        DataTable table = SqlHelper.ExecuteDataTable(fileName, selectQuary);
                        Session["idNum"] = table.Rows[0]["idNum"];
                        Session["user"] = (string)(table.Rows[0]["firstName"]) + " " + (string)(table.Rows[0]["lastName"]);

                        ArrayList a = (ArrayList)Application["chatlist"];
                        a.Add(Session["user"]);

                        Session["isAdmin"] = null;
                        if (table.Rows[0]["adminorno"].Equals("true"))
                            Session["isAdmin"] = "si";

                        Response.Redirect("index.aspx");

                    }
                    else
                        errors += "username or password does not exist";
                }
                else
                {
                    errors += "stop trying to hack to my site ( ͡° ͜ʖ ͡°)";
                }

            }

        }
        
    }
}

