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
    public class SqlHelper
    {
        public static SqlConnection ConnectToDb(string fileName)
        {
            string path = HttpContext.Current.Server.MapPath("App_Data/");
            path += fileName;
            //string path = HttpContext.Current.Server.MapPath("App_Data/" + fileName);
            string connString = @"Data Source=(localdb)\v11.0;AttachDbFilename=" + path + ";Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            return conn;

        }

        public static bool IsExist(string fileName, string sql)
        {

            SqlConnection conn = ConnectToDb(fileName);
            conn.Open();
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader data = com.ExecuteReader();
            Console.WriteLine(data);
            bool found = (bool)data.Read();
            conn.Close();
            return found;

        }

        public static void DoQuery(string fileName, string sql)
        {

            SqlConnection conn = ConnectToDb(fileName);
            conn.Open();
            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();
            com.Dispose();
            conn.Close();

        }

        public static DataTable ExecuteDataTable(string fileName, string sql)
        {
            SqlConnection conn = ConnectToDb(fileName);
            conn.Open();
            SqlDataAdapter tableAdapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            tableAdapter.Fill(dt);
            return dt;
        }


        public static string printDataTable(string fileName, string sql)
        {


            DataTable dt = ExecuteDataTable(fileName, sql);

            string printStr = "<table border='1'>";
            printStr += "<tr> <th> Id Number </th><th>Password </th><th> First Name</th> <th>Last Name</th><th>Gender</th><th>Phone</th><th>Email</th><th>Adress</th><th>Admin or Not</th></tr>";
            foreach (DataRow row in dt.Rows)
            {
                printStr += "<tr>";
                foreach (object myItemArray in row.ItemArray)
                {
                    printStr += "<td>" + myItemArray.ToString() + "</td>";
                }
                printStr += "</tr>";
            }
            printStr += "</table>";

            return printStr;
        }
    }
}