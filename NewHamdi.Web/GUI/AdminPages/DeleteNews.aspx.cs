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
using System.Collections.Generic;

public partial class GUI_AdminPages_DeleteNews : AdminBasePage
{
    private const string _Active = "~/GUI/Icons/check.png";
    private const string _InActive = "~/GUI/Icons/button_cancel.png";

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.ibtnDeleteNews.Click += new ImageClickEventHandler(ibtnDeleteNews_Click);
        this.gvNews.PageIndexChanging += new GridViewPageEventHandler(gvNews_PageIndexChanging);
        this.ibtnActivateNews.Click += new ImageClickEventHandler(ibtnActivateNews_Click);
        this.ibtnDeactivateNews.Click += new ImageClickEventHandler(ibtnDeactivateNews_Click);
        base.OnInit(e);
    }

    void ibtnDeactivateNews_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvNews.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnNewsId = (HiddenField)row.FindControl("hdnNewsId");
                CheckBox cbSelectedNews = (CheckBox)row.FindControl("cbSelect");
                if (hdnNewsId != null && (cbSelectedNews != null && cbSelectedNews.Checked))
                {
                    BLL.UnPuplishNewsOnSlider(Convert.ToInt32(hdnNewsId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        SearchNews();
    }

    void ibtnActivateNews_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvNews.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnNewsId = (HiddenField)row.FindControl("hdnNewsId");
                CheckBox cbSelectedNews = (CheckBox)row.FindControl("cbSelect");
                if (hdnNewsId != null && (cbSelectedNews != null && cbSelectedNews.Checked))
                {
                    BLL.PuplishNewsOnSlider(Convert.ToInt32(hdnNewsId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        SearchNews();
    }

    void gvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNews.PageIndex = e.NewPageIndex;
        SearchNews();
        upnlNews.Update();
    }

    void ibtnDeleteNews_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            List<Comment> newsComments = null;
            string failedNews = string.Empty;

            foreach (GridViewRow row in gvNews.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnNewsId = (HiddenField)row.FindControl("hdnNewsId");
                    CheckBox cbSelectedNews = (CheckBox)row.FindControl("cbSelect");
                    if (hdnNewsId != null && (cbSelectedNews != null && cbSelectedNews.Checked))
                    {
                        newsComments = BLL.GetCommentsByNewsId(Convert.ToInt32(hdnNewsId.Value));
                        if (newsComments == null || newsComments.Count <= 0)
                        {
                            BLL.DeleteNews(Convert.ToInt32(hdnNewsId.Value));
                            SetAlert(operationMessage);
                        }
                        else
                        {
                            News news = BLL.GetNewsById(Convert.ToInt32(hdnNewsId.Value));
                            if (news != null)
                                failedNews += " " + news.Title;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(failedNews))
                SetAlert("لا يمكن حذف الأخبار التالية بسبب ارتباطها بتعليقات" + failedNews);
        }
        catch (Exception ex)
        {

        }

        SearchNews();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SearchNews();
            upnlNews.Update();
        }
    }

    private void SearchNews()
    {
        DataTable dtAllNews = BLL.GetAllNews();
        gvNews.DataSource = dtAllNews;
        gvNews.DataBind();
    }

    public string GetNewsStatus(bool isActive)
    {
        if (isActive)
            return _Active;
        else
            return _InActive;
    }
}
