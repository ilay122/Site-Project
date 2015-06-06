using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace PEGS
{
    public partial class insertnews : System.Web.UI.Page
    {
        public string done = "";
        public void insert(string header,string writer, string cdate, string content)
        {
        XmlElement reportEle, headerEle, dateEle, contentEle,writerEle;
        XmlDocument doc = new XmlDocument();
        string XMLfile = Server.MapPath("news.xml"); 

        doc.Load(XMLfile); 
        headerEle = doc.CreateElement("header"); 
        dateEle = doc.CreateElement("date");
        writerEle = doc.CreateElement("writer");
        contentEle = doc.CreateElement("content"); 
        reportEle = doc.CreateElement("report"); 
        headerEle.InnerText = header; 
        dateEle.InnerText = cdate;
        writerEle.InnerText = writer;
        contentEle.InnerText = content; 
        reportEle.AppendChild(headerEle); 
        reportEle.AppendChild(dateEle);
        reportEle.AppendChild(writerEle);
        reportEle.AppendChild(contentEle); 
        doc.DocumentElement.InsertBefore(reportEle, doc.DocumentElement.FirstChild);
        FileStream fsxml = new FileStream(XMLfile, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
                                  
                                  
        doc.Save(fsxml);
        fsxml.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isAdmin"] == null)
                Response.Redirect("notallowed.aspx");

            if (Request.Form["submit"] != null)
            {
                string header = Request.Form["header"];
                string content= Request.Form["content"];
                string writer = Session["user"].ToString();

                DateTime time = DateTime.Now;
                string current = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                insert(header,writer,current,content);
                done = "News added successfully";
            }
        }
    }
}