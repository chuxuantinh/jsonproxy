using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Json;

public partial class jsonProxy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strResult = "";
        string strSearch = "";
        try
        {
            if (Request.QueryString.Count != 0 && Request.QueryString["q"] != string.Empty)
            {
                strSearch = Request.QueryString["q"];
            }
            strResult = performSearch(strSearch);
        }
        catch
        {
            strResult = performSearch("");
        }


        Response.Clear(); //optional: if we've sent anything before
        Response.ContentType = "text/html"; //must be 'text/xml'
        Response.ContentEncoding = System.Text.Encoding.UTF8; //we'd like UTF-8

        Response.Write("jsonData =" + strResult + "");
        Response.End(); //optional: will end processing

    }


    private string performSearch(string strSearch)
    {

       string returnStr = "";

        System.Collections.Generic.List<publication> returnList = new System.Collections.Generic.List<publication>();

        /*This is our data access method. Supposed to fill our publication list from database
        We fill it using the below for loop for simplicity. 
        Here we can also call a web-service. Fetch the records. and fill our publications list. */
        for (int tmp1 = 1; tmp1 <= 10; tmp1++)
        {
            //Some customized data - according to query string.
            if ((strSearch.ToUpper() == "ODD") && (tmp1 % 2 == 0))
                continue;
            else if ((strSearch.ToUpper() == "EVEN") && (tmp1 % 2 != 0))
                continue;

            returnList.Add(new publication(tmp1, "Author" + tmp1.ToString(), "Title" + tmp1.ToString(), "Remarks" + tmp1.ToString(), "Category" + tmp1.ToString(), "Link" + tmp1.ToString()));
        }

        //Serialize of generic list inot Json using JavaScriptSerializer
        System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
        returnStr = ser.Serialize(returnList);


        /* Here we can also convert any xml response to json using
        the XMLtoJson class provided. Taken from http://www.phdcc.com/xml2json.htm */
        //For Example
        //XmlDocument docXml = new XmlDocument();
        //docXml.Load("someLocation");
        //returnStr = XmlToJson.XmlToJSON(docXml);
        

        return (returnStr);
    }



}
