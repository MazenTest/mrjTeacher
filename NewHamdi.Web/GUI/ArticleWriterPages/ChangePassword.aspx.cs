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
using MyComponent.Business;
using MyComponent.Entities;

public partial class GUI_ArticleWriterPages_ChangePassword : ArticleWriterBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnChangePassword.Click += new EventHandler(btnChangePassword_Click);
        base.OnInit(e);
    }

    void btnChangePassword_Click(object sender, EventArgs e)
    {
        if (Session["ArticleWriterId"] != null)
        {
            string errorMessage = string.Empty;
            BLL.ChangeUserUserName(Convert.ToInt32(Session["ArticleWriterId"]), txtUserName.Text.Trim(), ref errorMessage);
            if (string.IsNullOrEmpty(errorMessage))
            {
                BLL.ChangeUserPassword(Convert.ToInt32(Session["ArticleWriterId"]), txtPassword.Text);
                SetAlert(operationMessage);
            }
            else
                SetAlert(errorMessage);
        }
    }
    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            User user = BLL.GetUserById(Convert.ToInt32(Session["ArticleWriterId"]));
            if (user != null)
            {
                txtUserName.Text = user.Email;
                txtPassword.Text = user.Password;
            }
        }

    }
}
