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
public class PublicBasePage : System.Web.UI.Page
{
    protected const string operationMessage = "تمت العملية بنجاح";

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void SetAlert(string istrMessage)
    {
        string s = "<SCRIPT language=\"javascript\">" +

           "alert('" + istrMessage + "') ;</SCRIPT>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowAlert" + istrMessage, s, false);
    }

    protected void AddMetaTagsAndPageDescription(string metaKeyWords, string description)
    {
        this.Header.Controls.Add(new LiteralControl("\n"));
        HtmlMeta metaKeyWord = new HtmlMeta();
        metaKeyWord.Name = "keywords";
        metaKeyWord.Content = metaKeyWords;

        this.Header.Controls.Add(metaKeyWord);
        this.Header.Controls.Add(new LiteralControl("\n"));

        HtmlMeta metaDescription = new HtmlMeta();
        metaDescription.Name = "description";
        metaDescription.Content = description;

        this.Header.Controls.Add(metaDescription);
        this.Header.Controls.Add(new LiteralControl("\n"));
    }
}
