using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PEGS
{
    public partial class thechat : System.Web.UI.Page
    {
        public string logged = "";
        public string foruser = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("notallowed.aspx");

            ArrayList a = (ArrayList)Application["chatlist"];
            logged += "logged : ";
            for (int i = 0; i < a.Count; i++)
            {
                if (i != a.Count - 1)
                {
                    logged += a[i].ToString() + " , ";
                }
                else
                {
                    logged += a[i].ToString();
                }
            }
            logged += "<br/>";

            if (Request.Form["msg"] != null)
            { 
               
                try
                {
                    String text = Request.Form["msg"];

                    if (text.Length < 40)
                    {


                        string[] filesindirectory = System.IO.Directory.GetFiles(Server.MapPath("~/Images/icons/"));

                        foreach (String item in filesindirectory)
                        {
                            Console.WriteLine(item);
                            string temp = item;
                            //temp = temp.Replace("D:\\Users\\ilayu\\documents\\visual studio 2013\\Projects\\PEGS\\PEGS\\Images\\icons\\", "");
                            temp = temp.Replace(Server.MapPath("Images/icons/"), "");
                            text = text.Replace(temp.Replace(".png", ""), "<img src='/Images/icons/" + temp + "'/>");
                        }

                        for (int i = 0; i < a.Count; i++)
                        {
                            Application[a[i].ToString()] += " [" + Session["user"] + "]" + "[" + DateTime.Now.ToString("h:mm:ss") + "]" + text + "<br/>";

                        }
                        Response.Redirect("chat.aspx");
                    }
                    else
                    {
                        foruser += "<b> Message length is over 40 letters. Change it</b> <br />";
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