using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;
using System.Net;

namespace PEGS
{
    public partial class upload : System.Web.UI.Page
    {
        public string done = "";
        public string done2 = "";
        public static String randomStr()
        {
            string name = "";
            Random dice = new Random();
            string chars = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < chars.Length; i++)
            {
                name += chars[dice.Next(0, chars.Length)];
            }
            return name;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("notallowed.aspx");
            }

            if (Request.Form["submiturl"] != null)
            {

                String name = randomStr();
                string tosave = Request.Form["url"];
                string ext=tosave.Substring((tosave.LastIndexOf(".")+1));
                if(ext.Equals("jpg") || ext.Equals("png")){
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/pegs"), name);
                    path += ".jpg";
                    System.Net.WebClient webclient = new WebClient();
                    try
                    {
                        webclient.DownloadFile(@tosave, path);
                        done2 += "Picture added successfully";
                    }
                    catch (Exception E)
                    {
                        done2 += "could not be downloaded";
                    }
                }
                else{
                    done2+="i said pics only !";
                }
            }
        }
           
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload1.PostedFile != null)
            {
                string extension = System.IO.Path.GetExtension(fileUpload1.FileName);
                if (extension.Equals(".gif") || extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals("jpeg"))
                {
                    string fileName = Path.GetFileName(fileUpload1.PostedFile.FileName);
                    fileUpload1.SaveAs(Server.MapPath("Images/pegs/") + (randomStr()+""+extension));
                    done += "Picture added successfully to the main page";
                }
                else
                {
                    done += "stop trying to hack me pls";
                }
            }
        }
    }
}