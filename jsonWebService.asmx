<%@ WebService Language="C#" Class="jsonWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for search
/// </summary>
[WebService(Namespace = "http://jsonproxy.codeproject.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class jsonWebService : System.Web.Services.WebService
{

    public jsonWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(Description = "This method returns JSON Result. Searches publications on the basis of Search Keyword(q)")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public publication[] PerformSearch(string q)
    {
        return (performSearch(q));
    }

    private publication[] performSearch(string strSearch)
    {

        System.Collections.Generic.List<publication> returnList = new System.Collections.Generic.List<publication>();

        //This is our data access method. Supposed to fill our publication list from database
        //We fill it using the below "for loop" for simplicity.
        for (int tmp1 = 1; tmp1 <= 10; tmp1++)
        {
            //Some customized data - according to query string.
            if ((strSearch.ToUpper() == "ODD") && (tmp1 % 2 == 0))
                continue;
            else if ((strSearch.ToUpper() == "EVEN") && (tmp1 % 2 != 0))
                continue;

            returnList.Add(new publication(tmp1, "Author" + tmp1.ToString(), "Title" + tmp1.ToString(), "Remarks" + tmp1.ToString(), "Category" + tmp1.ToString(), "Link" + tmp1.ToString()));
        }
        return ((publication[])returnList.ToArray());
    }

}
