using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PEGS
{
    public partial class contact : System.Web.UI.Page
    {
        public string serverMsg = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            string fileName = "MySqlDB.mdf";
            string tableName = "supportt";
            if (Request.Form["submit"] != null)
            {
                string selectQuary;
                selectQuary = "SELECT * FROM supportt WHERE CONVERT(NVARCHAR(MAX), idNum) ='" + Request.Form["idNum"] + "'";
                if (SqlHelper.IsExist(fileName, selectQuary))
                {
                    serverMsg = "<p style='color:red'>ID already taken. Choose another one.</p> <br />";
                }
                else
                {
                    string adminornoo = "false";
                    if (Request.Form["password"].Equals("iamadmin"))
                        adminornoo = "true";
                    string sql="";
                    sql += "INSERT INTO supportt";
                    sql += "(idNum, [password], firstName, lastName, gender,";
                    sql += "phone, email,adress,adminorno)";
                    sql += "VALUES (";
                    sql += "'"  + Request.Form["idNum"] + "'";
                    sql += ",'" + Request.Form["password"] + "'";
                    sql += ",'" + Request.Form["firstName"] + "'";
                    sql += ",'" + Request.Form["lastName"] + "'";
                    sql += ",'" + Request.Form["gender"] + "'";
                    sql += ",'" + Request.Form["phone"] + "'";
                    sql += ",'" + Request.Form["email"] + "'";
                    sql += ",'" + Request.Form["adress"] + "'";
                    sql += ",'" + adminornoo + "'";
                    sql += ")";

                    SqlHelper.DoQuery(fileName, sql);
                    Response.Redirect("welcome.aspx");

                }

            }

        }
        
    }
}