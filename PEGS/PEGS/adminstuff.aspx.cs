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
    public partial class adminstuff : System.Web.UI.Page
    {

        public string tablestring = "";
        public string change = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string filename = "MySqlDB.mdf";
            string tablename = "supportt";
            string sqlc = "SELECT * FROM supportt";

            DataTable table = SqlHelper.ExecuteDataTable(filename, sqlc);
            
            if(table.Rows.Count !=0) //crashed at first ...
            {
                tablestring += "<table border='1'>";
                tablestring += "<tr>";
                tablestring += "<th>Id Num</th>";
                tablestring += "<th>Password </th>";
                tablestring += "<th>First Name</th>";
                tablestring += "<th>Last Name</th>";
                tablestring += "<th>Gender</th>";
                tablestring += "<th>Phone Number</th>";
                tablestring += "<th>Email</th>";
                tablestring += "<th>Adress</th>";
                tablestring += "<th>Admin ?</th>";
                tablestring += "<th>Update col</th>";
                tablestring += "<th>Delete col</th>";
                tablestring += "</tr>";

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    tablestring += "<tr>";
                    tablestring += "<form action='EditUser.aspx' method='post' >";
                    tablestring += "<td><input type='text' name='idNum' value='" + table.Rows[i]["IdNum"] + "' /> </td>";
                    tablestring += "<td><input type='text' name='password' value='" + table.Rows[i]["password"] + "' /> </td>";
                    tablestring += "<td><input type='text' name='firstName' value='" + table.Rows[i]["firstName"] + "' /> </td>";
                    tablestring += "<td><input type='text' name='lastName' value='" + table.Rows[i]["lastName"] + "' /> </td>";
                    tablestring += "<td><input type='text' name='gender' value='" + table.Rows[i]["gender"] + "' /> </td>";
                    tablestring += "<td><input type='text' name='phone' value='" + table.Rows[i]["phone"] + "' /> </td>";
                    tablestring += "<td><input type='text' name='email' value='" + table.Rows[i]["email"] + "' /> </td>";
                    tablestring += "<td><input type='text' name='adress' value='" + table.Rows[i]["adress"] + "' /> </td>";
                    if(table.Rows[i]["adminorno"].Equals("true"))
                        tablestring += "<td><input type='checkbox' name='isadmin' value='true' checked /> </td>";
                    else
                    {
                        tablestring += "<td><input type='checkbox' name='isadmin' value='true' /> </td>";
                    }
                    //buttons can have text on them but a different value 
                    tablestring += " <td><button name='update' value='" + table.Rows[i]["IdNum"] + "' type='submit' class='tfbutton'>Update</button> </td>";
                    tablestring += " <td><button name='delete' value='" + table.Rows[i]["IdNum"] + "' type='submit' class='tfbutton'>Delete</button> </td>";
                    tablestring += "</form>";
                    tablestring += "</tr>";
                }
                tablestring += "</table>";
            }
            if (Session["change"].ToString().Length != 0)
            {
                change = Session["change"].ToString();
                Session["change"] = "";
            }
        }

    }
}
