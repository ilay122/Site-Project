using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PEGS
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] filesindirectory = System.IO.Directory.GetFiles(Server.MapPath("~/Images/pegs/"));
            List<String> images = new List<string>(filesindirectory.Count());

            foreach (string item in filesindirectory)
            {
                images.Add(String.Format("~/Images/pegs/{0}", System.IO.Path.GetFileName(item)));
            }

            RepeaterImages.DataSource = images;
            RepeaterImages.DataBind();
        }
    }
}