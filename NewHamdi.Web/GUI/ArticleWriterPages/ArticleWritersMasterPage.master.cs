using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;
using MyComponent.Entities;
using MyComponent.Business;
using MyComponent.Enums;

public partial class ArticleWritersMasterPage : System.Web.UI.MasterPage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnLogin.Click += new EventHandler(btnLogin_Click);
        base.OnInit(e);
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (Session["ArticleWriterId"] != null && Session["ArticleWriterName"] != null)
        {
            trLogin.Visible = false;
            lbtnLogOut.Visible = true;

            lblWelcome.Text = "أهلاً و سهلاً يا: " + Session["ArticleWriterName"].ToString();

            trWelcome.Visible = true;
            dvMenu.Visible = true;
        }
    }

    void btnLogin_Click(object sender, EventArgs e)
    {
        DataTable allUsers = BLL.GetUsersByRoleId((int)UserRoles.ArticleWriter);

        bool IsAuthenticated = false;
        if (allUsers != null && allUsers.Rows != null && allUsers.Rows.Count > 0)
            foreach (DataRow userRow in allUsers.Rows)
            {
                if (txtUserName.Text.Trim().ToUpper() == userRow["EMAIL"].ToString().ToUpper() &&
                    txtPassword.Text.Trim() == userRow["PASSWORD"].ToString())
                {
                    Session["ArticleWriterId"] = Convert.ToInt32(userRow["USER_ID"]);
                    Session["ArticleWriterName"] = userRow["FIRST_NAME"].ToString();

                    IsAuthenticated = true;

                    Response.Redirect("ArticleWriterHome.aspx?x=" +
                        Session["ArticleWriterId"].ToString() + "&Name=" +
                        Session["ArticleWriterName"].ToString());

                    break;
                }
            }
        if (!IsAuthenticated)
        {
            lblWarning.Visible = true;
            upnlLogin.Update();
        }
    }

    public void SetAlert(string istrMessage)
    {
        string s = "<SCRIPT language=\"javascript\">" +

           "alert('" + istrMessage + "') ;</SCRIPT>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowAlert" + istrMessage, s, false);
    }

    protected void lbtnLogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("ArticleWriterHome.aspx");
    }
}
