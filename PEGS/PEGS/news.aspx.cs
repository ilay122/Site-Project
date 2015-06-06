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
using System.Xml;

namespace PEGS
{
    public partial class news : System.Web.UI.Page
    {
        public string allnews = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string XMLfile = Server.MapPath("news.xml"); 
            XmlDocument doc = new XmlDocument(); 
            doc.Load(XMLfile); 
            XmlNodeList header = doc.GetElementsByTagName("header"); 
            XmlNodeList date = doc.GetElementsByTagName("date"); 
            XmlNodeList content = doc.GetElementsByTagName("content"); 
            XmlNodeList writer=doc.GetElementsByTagName("writer");

            
            int reports = content.Count; 
            allnews+="<div id='news'>";
            for (int i = 0; i < reports; i++)
            { 

                allnews += "<p>";
                allnews += "<h1>" + header[i].InnerText + "</h1>";
                allnews += "<h2>Upload date : " + date[i].InnerText + "<br />";
                allnews += "written by " + writer[i].InnerText + ". </h2></br> </br>";
                allnews += content[i].InnerText + "<br />";
                allnews += "</p>";

            }
            allnews += "</div>";
        }
    }
}