using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PEGS
{
    public partial class chat : System.Web.UI.Page
    {
        public string foruser = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("notallowed.aspx");

            if (Application["chat"] == null)
                Application["chat"] = "";

            if (Request.Form["submit"] != null)
            {
                    try
                    {
                        String text = Request.Form["text"];
                        string[] filesindirectory = System.IO.Directory.GetFiles(Server.MapPath("~/Images/icons/"));

                        foreach (String item in filesindirectory)
                        {
                            Console.WriteLine(item);
                            string temp = item;
                            //temp = temp.Replace("D:\\Users\\ilayu\\documents\\visual studio 2013\\Projects\\PEGS\\PEGS\\Images\\icons\\", "");
                            temp = temp.Replace(Server.MapPath("Images/icons/"), "");
                            text = text.Replace(temp.Replace(".png", ""), "<img src='/Images/icons/" + temp + "'");
                        }
                        if (text.Length != 0)
                        {
                            Application["chat"] += "<p> [" + Session["user"] + "]" + "[" + DateTime.Now.ToString("h:mm:ss") + "]" + text + "</p> <br />";
                        }
                        else
                        {
                            foruser += "dont send empty message";
                        }
                    }
                    
                catch (Exception E)
                {
                    foruser += "<b> Nice try <img src='/Images/icons/Kappa.png' /> </b> <br />";
                }
            
                    
            }
        }

    }
}