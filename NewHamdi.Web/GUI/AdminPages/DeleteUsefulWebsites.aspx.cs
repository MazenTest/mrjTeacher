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

public partial class GUI_AdminPages_DeleteUsefulWebsites : AdminBasePage
{
    private const string _Active = "~/GUI/Icons/check.png";
    private const string _InActive = "~/GUI/Icons/button_cancel.png";

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.ibtnDeleteUsefulWebsites.Click += new ImageClickEventHandler(ibtnDeleteUsefulWebsites_Click);
        this.gvUsefulWebsites.PageIndexChanging += new GridViewPageEventHandler(gvUsefulWebsites_PageIndexChanging);
        this.ibtnActivateUsefulWebsites.Click += new ImageClickEventHandler(ibtnActivateUsefulWebsites_Click);
        this.ibtnDeactivateUsefulWebsites.Click += new ImageClickEventHandler(ibtnDeactivateUsefulWebsites_Click);
        this.gvUsefulWebsites.PageIndexChanging+=new GridViewPageEventHandler(gvUsefulWebsites_PageIndexChanging);
        base.OnInit(e);
    }

    void ibtnDeactivateUsefulWebsites_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvUsefulWebsites.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnUsefulWebsitesId = (HiddenField)row.FindControl("hdnUsefulWebsitesId");
                CheckBox cbSelectedUsefulWebsites = (CheckBox)row.FindControl("cbSelect");
                if (hdnUsefulWebsitesId != null && (cbSelectedUsefulWebsites != null && cbSelectedUsefulWebsites.Checked))
                {
                    BLL.DectivateUsefulWebsite(Convert.ToInt32(hdnUsefulWebsitesId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        SearchUsefulWebsites();
    }

    void ibtnActivateUsefulWebsites_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvUsefulWebsites.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnUsefulWebsitesId = (HiddenField)row.FindControl("hdnUsefulWebsitesId");
                CheckBox cbSelectedUsefulWebsites = (CheckBox)row.FindControl("cbSelect");
                if (hdnUsefulWebsitesId != null && (cbSelectedUsefulWebsites != null && cbSelectedUsefulWebsites.Checked))
                {
                    BLL.ActivateUsefulWebsite(Convert.ToInt32(hdnUsefulWebsitesId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        SearchUsefulWebsites();

    }

    void gvUsefulWebsites_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUsefulWebsites.PageIndex = e.NewPageIndex;
        SearchUsefulWebsites();
        upnlUsefulWebsites.Update();
    }

    void ibtnDeleteUsefulWebsites_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvUsefulWebsites.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnUsefulWebsitesId = (HiddenField)row.FindControl("hdnUsefulWebsitesId");
                CheckBox cbSelectedUsefulWebsites = (CheckBox)row.FindControl("cbSelect");
                if (hdnUsefulWebsitesId != null && (cbSelectedUsefulWebsites != null && cbSelectedUsefulWebsites.Checked))
                {
                    BLL.DeleteUsefulWebsite(Convert.ToInt32(hdnUsefulWebsitesId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        SearchUsefulWebsites();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SearchUsefulWebsites();
            upnlUsefulWebsites.Update();
        }
    }

    private void SearchUsefulWebsites()
    {
        DataTable dtAllUsefulWebsites = BLL.GetAllUsefulWebsites();
        gvUsefulWebsites.DataSource = dtAllUsefulWebsites;
        gvUsefulWebsites.DataBind();
    }

    public string GetWebsiteStatus(bool isActive)
    {
        if (isActive)
            return _Active;
        else
            return _InActive;
    }
}
