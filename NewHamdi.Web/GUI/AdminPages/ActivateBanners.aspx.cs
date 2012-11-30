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

public partial class GUI_AdminPages_ActivateBanners : AdminBasePage
{
    private const string _Active = "~/GUI/Icons/check.png";
    private const string _InActive = "~/GUI/Icons/button_cancel.png";

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.ibtnDeleteBanner.Click += new ImageClickEventHandler(ibtnDeleteBanner_Click);
        this.gvBanner.PageIndexChanging += new GridViewPageEventHandler(gvBanner_PageIndexChanging);
        this.ibtnActivateBanner.Click += new ImageClickEventHandler(ibtnActivateBanner_Click);
        this.ibtnDeActivateBanner.Click += new ImageClickEventHandler(ibtnDeActivateBanner_Click);
        base.OnInit(e);
    }

    void ibtnDeActivateBanner_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvBanner.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnBannerId = (HiddenField)row.FindControl("hdnBannerId");
                CheckBox cbSelectedBanner = (CheckBox)row.FindControl("cbSelect");
                if (hdnBannerId != null && (cbSelectedBanner != null && cbSelectedBanner.Checked))
                {
                    BLL.DeActivateBanner(Convert.ToInt32(hdnBannerId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        GetAllBanners();
    }

    void ibtnActivateBanner_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvBanner.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnBannerId = (HiddenField)row.FindControl("hdnBannerId");
                CheckBox cbSelectedBanner = (CheckBox)row.FindControl("cbSelect");
                if (hdnBannerId != null && (cbSelectedBanner != null && cbSelectedBanner.Checked))
                {
                    BLL.ActivateBanner(Convert.ToInt32(hdnBannerId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        GetAllBanners();
    }

    void gvBanner_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBanner.PageIndex = e.NewPageIndex;
        GetAllBanners();
        upnlBanner.Update();
    }

    void ibtnDeleteBanner_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvBanner.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnBannerId = (HiddenField)row.FindControl("hdnBannerId");
                CheckBox cbSelectedBanner = (CheckBox)row.FindControl("cbSelect");
                if (hdnBannerId != null && (cbSelectedBanner != null && cbSelectedBanner.Checked))
                {
                    BLL.DeleteBanner(Convert.ToInt32(hdnBannerId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        GetAllBanners();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAllBanners();
            upnlBanner.Update();
        }
    }

    private void GetAllBanners()
    {
        DataTable dtAllBanner = BLL.GetAllBanners();
        gvBanner.DataSource = dtAllBanner;
        gvBanner.DataBind();
    }

    public string GetBannerStatus(bool isActive)
    {
        if (isActive)
            return _Active;
        else
            return _InActive;
    }

    public string GetPositionName(string position)
    {
        switch (position)
        {
            case "1": { return "يمين"; }
            case "2": { return "متوسط"; }
            case "3": { return "يسار"; }
            default: { return string.Empty; }
        }
    }
}
