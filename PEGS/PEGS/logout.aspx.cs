using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PEGS
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Application[Session["user"].ToString()] = "";
            ArrayList a = (ArrayList)Application["chatlist"];
            a.Remove(Session["user"].ToString());
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}