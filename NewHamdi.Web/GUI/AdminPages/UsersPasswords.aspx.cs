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
using MyComponent.Enums;

public partial class GUI_AdminPages_UsersPasswords : AdminBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.ddlTeachers.SelectedIndexChanged += new EventHandler(ddlTeachers_SelectedIndexChanged);
        this.rblstUserType.SelectedIndexChanged += new EventHandler(rblstUserType_SelectedIndexChanged);
        base.OnInit(e);
    }

    void rblstUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int roleId = -1;
        ddlTeachers.DataSource = new DataTable();

        if (int.TryParse(rblstUserType.SelectedValue, out roleId))
            if (roleId > 0)
            {
                DataTable dtUsers = BLL.GetUsersByRoleId(roleId);

                ddlTeachers.DataSource = dtUsers;
                ddlTeachers.DataTextField = "FULL_NAME";
                ddlTeachers.DataValueField = "USER_ID";

            }

        ddlTeachers.DataBind();
        upnlChangePassword.Update();
    }

    void ddlTeachers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlTeachers.SelectedValue))
        {
            MyComponent.Entities.User teacher = BLL.GetUserById(Convert.ToInt32(ddlTeachers.SelectedValue));
            if (teacher != null)
            {
                txtUserName.Text = teacher.Email;

                txtPassword.Text = teacher.Password;
                upnlChangePassword.Update();
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtUsers = BLL.GetUsersByRoleId((int)UserRoles.Teacher);

            ddlTeachers.DataSource = dtUsers;
            ddlTeachers.DataTextField = "FULL_NAME";
            ddlTeachers.DataValueField = "USER_ID";
            ddlTeachers.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string errorMessage = string.Empty;
        BLL.ChangeUserUserName(Convert.ToInt32(ddlTeachers.SelectedValue), txtUserName.Text.Trim(), ref errorMessage);
        if (string.IsNullOrEmpty(errorMessage))
        {
            BLL.ChangeUserPassword(Convert.ToInt32(ddlTeachers.SelectedValue), txtPassword.Text);
            SetAlert(operationMessage);
        }
        else
            SetAlert(errorMessage);
    }

}
