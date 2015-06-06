using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PEGS
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string panel = "";
        public string userMsg;
        public string ProtectedLink = "";
        public string FooterLink = "";
        public string counter;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Application["chatlist"] == null)
            {
                ArrayList list = new ArrayList();
                Application["chatlist"] = list;

            }
            if (Session["change"] == null)
                Session["change"] = "";

            if (Session["user"] == null) /* not connected 'or||and' not registered*/
            {

                ProtectedLink += ("<li> <a href='login.aspx'> Login</a> </li>");
                ProtectedLink += ("<li> <a href='contact.aspx'> Register </a> </li>");

                FooterLink += ("<td> <a href='login.aspx'> Login </a> </td>");
                FooterLink += ("<td> <a href='contact.aspx'> Register </a> </td>");

            }
            else /* connected */
            {
                ProtectedLink += ("<li> <a href='logout.aspx'> Logout </a> </li>");
                ProtectedLink += ("<li> <a href='upload.aspx'> Upload Pics </a> </li>");
                panel += "<li><a href='#' onclick='myFunction()'> Chat</a> </li>";

                FooterLink += ("<td> <a href='logout.aspx'> Logout </a> </td>");
                FooterLink += ("<td> <a href='upload.aspx'> Upload Pics </a> </td>");



            }



            if (Application["mycount"] == null)
            {
                Application["mycount"] = 0;
            }
            if (Session["firstLog"] == null)
            {
                Application["mycount"] = (int)Application["mycount"] + 1;
                Session["firstLog"]="done";

            }
            counter = Application["mycount"].ToString();



            if (Session["user"] == null)
            {
                userMsg = ("You are not logged in");
            }
            else
            {
                userMsg = ("you are connected to <b>" + Session["user"] + " </b>");
            }
            if (Session["isAdmin"] != null)
            {
                userMsg += "(You are an admin)";
                panel += "<li> <a href='insertnews.aspx'>Adding News </a> </li>";
                panel += "<li><a href='adminstuff.aspx'>Admin Panel </a> </li>";
                
            }

        }
    }
}