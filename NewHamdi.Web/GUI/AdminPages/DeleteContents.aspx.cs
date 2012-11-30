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

public partial class GUI_AdminPages_DeleteContents : AdminBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.gvContents.PageIndexChanging += new GridViewPageEventHandler(gvContents_PageIndexChanging);
        this.ibtnDeleteContents.Click += new ImageClickEventHandler(ibtnDeleteContents_Click);
        base.OnInit(e);
    }

    void ibtnDeleteContents_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvContents.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnContentsId = (HiddenField)row.FindControl("hdnContentsId");
                CheckBox cbSelectedContents = (CheckBox)row.FindControl("cbSelect");
                if (hdnContentsId != null && (cbSelectedContents != null && cbSelectedContents.Checked))
                {
                    BLL.DeleteContent(Convert.ToInt32(hdnContentsId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        SearchContents();
    }

    void gvContents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvContents.PageIndex = e.NewPageIndex;
        SearchContents();
        upnlContents.Update();
    }
    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SearchContents();
        }
    }

    private void SearchContents()
    {
        DataTable dtAllContents = BLL.GetAllContent();
        gvContents.DataSource = dtAllContents;
        gvContents.DataBind();
    }
}
