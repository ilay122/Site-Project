using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PEGS
{
    public partial class notallowed : System.Web.UI.Page
    {
        
        public string towrite = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["user"] == null)
                towrite += "<p>You need to register to get there </p>";
            else
                towrite += "<p>You need to be the admin to get in there </p>";
        }
    }
}