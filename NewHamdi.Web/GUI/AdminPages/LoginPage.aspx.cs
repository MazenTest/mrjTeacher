using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using MyComponent.Entities;
using MyComponent.Business;
using MyComponent.Enums;

public partial class AdminCMS_LoginPage : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.btnLogin.Click += new EventHandler(btnLogin_Click);
        base.OnInit(e);
    }

    void btnLogin_Click(object sender, EventArgs e)
    {
        DataTable allUsers = BLL.GetUsersByRoleId((int)UserRoles.Admin);

        bool IsAuthenticated = false;
        if (allUsers != null && allUsers.Rows != null && allUsers.Rows.Count > 0)
            foreach (DataRow userRow in allUsers.Rows)
            {
                if (txtUserName.Text.Trim().ToUpper() == userRow["EMAIL"].ToString().ToUpper() &&
                    txtPassword.Text.Trim() == userRow["PASSWORD"].ToString())
                {
                    Session["SecureAdminSite"] = Convert.ToInt32(userRow["USER_ID"]);
                    Session["AdminName"] = userRow["FIRST_NAME"].ToString();

                    IsAuthenticated = true;
                    Response.Redirect("AdminHome.aspx?x=" +
                        Session["SecureAdminSite"].ToString() +
                        "&Name=" + Session["AdminName"].ToString());

                    break;
                }
            }

        if (!IsAuthenticated)
        {
            lblInvalidUserNamePassword.Visible = true;
            lblInvalidUserNamePassword.ForeColor = Color.Red;
        }
    }
}
