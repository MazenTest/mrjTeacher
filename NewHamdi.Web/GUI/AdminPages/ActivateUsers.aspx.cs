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

public partial class GUI_AdminPages_ActivateUsers : AdminBasePage
{
    private const string _Active = "~/GUI/Icons/check.png";
    private const string _InActive = "~/GUI/Icons/button_cancel.png";

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.gvUser.PageIndexChanging += new GridViewPageEventHandler(gvUser_PageIndexChanging);
        this.ibtnActivateUser.Click += new ImageClickEventHandler(ibtnActivateUser_Click);
        this.ibtnDeActivateUser.Click += new ImageClickEventHandler(ibtnDeActivateUser_Click);
        base.OnInit(e);
    }

    void ibtnDeActivateUser_Click(object sender, ImageClickEventArgs e)
    {
        bool isTryToDeleteWebsiteAdmin = false;
        bool isUserActivationPassed = false;
        foreach (GridViewRow row in gvUser.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnUserId = (HiddenField)row.FindControl("hdnUserId");
                CheckBox cbSelectedUser = (CheckBox)row.FindControl("cbSelect");
                HiddenField hdnUseRoleId = (HiddenField)row.FindControl("hdnUseRoleId");
                if (hdnUserId != null && (cbSelectedUser != null && cbSelectedUser.Checked) && hdnUseRoleId != null)
                {
                    if (!string.IsNullOrEmpty(hdnUseRoleId.Value) &&
                        hdnUseRoleId.Value != ((int)UserRoles.Admin).ToString())
                    {
                        BLL.DeActivateUser(Convert.ToInt32(hdnUserId.Value));
                        isUserActivationPassed = true;
                    }
                    else
                        isTryToDeleteWebsiteAdmin = true;
                }
            }
        }
        if (isUserActivationPassed)
            SetAlert("تم تفعيل المستخدمين الذين تم اختيارهم");

        if (isTryToDeleteWebsiteAdmin)
            SetAlert("لا يمكن إلغاء تفعيل مدير الموقع");

        GetAllUsers();
    }

    void ibtnActivateUser_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvUser.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnUserId = (HiddenField)row.FindControl("hdnUserId");
                CheckBox cbSelectedUser = (CheckBox)row.FindControl("cbSelect");

                if (hdnUserId != null && (cbSelectedUser != null && cbSelectedUser.Checked))
                {
                    BLL.ActivateUser(Convert.ToInt32(hdnUserId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        GetAllUsers();
    }

    void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUser.PageIndex = e.NewPageIndex;
        GetAllUsers();
        upnlUser.Update();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAllUsers();
            upnlUser.Update();
        }
    }

    private void GetAllUsers()
    {
        DataTable dtAllUser = BLL.GetAllUsers();
        gvUser.DataSource = dtAllUser;
        gvUser.DataBind();
    }

    public string GetNewsStatus(bool isActive)
    {
        if (isActive)
            return _Active;
        else
            return _InActive;
    }

    public string GetUserRoleString(int roleId)
    {
        UserRoles userRole = (UserRoles)roleId;
        string strRole = string.Empty;
        switch (userRole)
        {
            case UserRoles.Admin: { strRole = "مدير الموقع"; break; }
            case UserRoles.Teacher: { strRole = "معلم"; break; }
            case UserRoles.ArticleWriter: { strRole = "كاتب"; break; }
            case UserRoles.Student: { strRole = "طالب"; break; }
        }
        return strRole;
    }
}
