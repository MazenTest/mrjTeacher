using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Base
/// </summary>
public class AdminBasePage : System.Web.UI.Page
{
    protected const string operationMessage = "تمت العملية بنجاح";

    protected const string maxFileSizeExceeds = "تجاوز حجم الملف";

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        base.OnInit(e);
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (Session["SecureAdminSite"] == null || Session["AdminName"] == null)
        {
            Response.Redirect("LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            // Response.Cache.SetAllowResponseInBrowserHistory(false);
        }
    }

    public void SetAlert(string istrMessage)
    {
        string s = "<SCRIPT language=\"javascript\">" +

           "alert('" + istrMessage + "') ;</SCRIPT>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowAlert" + istrMessage, s, false);
    }
}
