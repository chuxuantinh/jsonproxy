using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for publication
/// </summary>
public class publication
{
    private int _ID;
    private string _Author;
    private string _Title;
    private string _Remarks;
    private string _Category;
    private string _Link;

    public publication()
    {
        this._ID = 0;
        this._Author = "";
        this._Title = "";
        this._Remarks = "";
        this._Category = "";
        this._Link = "";
    }

    public publication(int ID, string Author, string Title,  string Remarks, string Category, string Link)
    {
        this._ID = ID;
        this._Author = Author;
        this._Title = Title;
        this._Remarks = Remarks;
        this._Category = Category;
        this._Link = Link;
    }


    #region Properties

    public int ID
    {
        get
        {
            return this._ID;
        }
        set
        {
            this._ID = value;
        }
    }

    public string Author
    {
        get
        {
            return this._Author;
        }
        set
        {
            this._Author = value;
        }
    }

    public string Title
    {
        get
        {
            return this._Title;
        }
        set
        {
            this._Title = value;
        }
    }

    public string Remarks
    {
        get
        {
            return this._Remarks;
        }
        set
        {
            this._Remarks = value;
        }
    }

    public string Category
    {
        get
        {
            return this._Category;
        }
        set
        {
            this._Category = value;
        }
    }

    public string Link
    {
        get
        {
            return this._Link;
        }
        set
        {
            this._Link = value;
        }
    }


    #endregion

}
