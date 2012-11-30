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
using System.IO;
using MyComponent.Business;
using MyComponent.Entities;

public partial class GUI_AdminPages_AddUsefulInfo : AdminBasePage
{
    private bool IsAddMode
    {
        set
        {
            ViewState["AddMode"] = value;
        }
        get
        {
            bool isAddMode = false;
            if (ViewState["AddMode"] != null)
                isAddMode = Convert.ToBoolean(ViewState["AddMode"]);

            return isAddMode;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSaveUsefulInfo.Click += new EventHandler(btnSaveUsefulInfo_Click);
        this.ddlAllUsefulInfos.SelectedIndexChanged += new EventHandler(ddlAllUsefulInfos_SelectedIndexChanged);
        this.btnAddNew.Click += new EventHandler(btnAddNew_Click);
        base.OnInit(e);
    }

    void btnAddNew_Click(object sender, EventArgs e)
    {
        FillAllUsefulInfos();
        BeginAddMode();
    }

    void ddlAllUsefulInfos_SelectedIndexChanged(object sender, EventArgs e)
    {
        IsAddMode = false;
        int UsefulInfoId = -1;
        if (int.TryParse(ddlAllUsefulInfos.SelectedValue, out UsefulInfoId))
            if (UsefulInfoId > 0)
            {
                UsefulInfo UsefulInfo = BLL.GetUsefulInfoById(UsefulInfoId);
                if (UsefulInfo != null)
                {
                    txtUsefulInfoTitle.Text = UsefulInfo.Title;
                    UsefulInfoBody.Text = UsefulInfo.Body;
                }
            }
    }

    void btnSaveUsefulInfo_Click(object sender, EventArgs e)
    {
        if (IsAddMode)
        {
            UsefulInfo UsefulInfo = new UsefulInfo();
            UsefulInfo.Title = txtUsefulInfoTitle.Text;
            UsefulInfo.PublishDate = DateTime.Now;
            UsefulInfo.Body = UsefulInfoBody.Text;

            BLL.AddNewUsefulInfo(UsefulInfo);
            SetAlert(operationMessage);
        }
        else
        {
            int UsefulInfoId = -1;
            if (int.TryParse(ddlAllUsefulInfos.SelectedValue, out UsefulInfoId))
                if (UsefulInfoId > 0)
                {
                    UsefulInfo UsefulInfo = BLL.GetUsefulInfoById(UsefulInfoId);
                    if (UsefulInfo != null)
                    {
                        UsefulInfo.Title = txtUsefulInfoTitle.Text;
                        UsefulInfo.Body = UsefulInfoBody.Text;
                        BLL.UpdateUsefulInfo(UsefulInfo);
                        SetAlert(operationMessage);
                    }
                }
        }
        FillAllUsefulInfos();
        upnlAddUsefulInfo.Update();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAllUsefulInfos();
        }
    }

    private void FillAllUsefulInfos()
    {
        BeginAddMode();
        DataTable dtWriterUsefulInfos = BLL.GetAllUsefulInfo();
        ddlAllUsefulInfos.DataSource = dtWriterUsefulInfos;
        ddlAllUsefulInfos.DataTextField = "Useful_Info_TITLE";
        ddlAllUsefulInfos.DataValueField = "Useful_Info_ID";
        ddlAllUsefulInfos.DataBind();
    }

    private void BeginAddMode()
    {
        IsAddMode = true;
        txtUsefulInfoTitle.Text = string.Empty;
        UsefulInfoBody.Text = string.Empty;
    }
}
