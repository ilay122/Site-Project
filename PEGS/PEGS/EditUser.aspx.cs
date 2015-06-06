using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PEGS
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["isAdmin"] ==null)
                Response.Redirect("notallowed.aspx");

            string filename="MySqlDB.mdf";
            string sql = "";
            if (Request.Form["delete"] == null)//update
            {
                sql += "UPDATE supportt SET password='"+Request.Form["password"]+"' ";
                sql += ", firstName='" + Request.Form["firstName"] + "'";
                sql += ", lastName='" + Request.Form["lastName"] + "'";
                sql += ", idNum='" + Request.Form["idNum"] + "'";
                sql += ", gender='" + Request.Form["gender"] + "'";
                sql += ", phone='" + Request.Form["phone"] + "'";
                sql += ", email='" + Request.Form["email"] + "'";
                sql += ", adress='" + Request.Form["adress"] + "'";
                if (Request.Form["isadmin"] != null) 
                    sql += ", adminorno='true'";
                else
                {
                    sql += ", adminorno='false'";
                }
                sql += "WHERE idNum like '"+Request.Form["update"]+"'";
            }
            else//delete
            {
                sql+="DELETE FROM supportt WHERE idNum like '"+Request.Form["delete"]+"'";
                
            }
            Session["change"] = " <br /> <br /> Change was completed ";
            SqlHelper.DoQuery(filename,sql);
            Response.Redirect("adminstuff.aspx");
        }
    }
}