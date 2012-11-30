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

public partial class GUI_ArticleWriterPages_CommnetsManagement : ArticleWriterBasePage
{
    private const string _Active = "~/GUI/Icons/check.png";
    private const string _InActive = "~/GUI/Icons/button_cancel.png";

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.ibtnDeleteComment.Click += new ImageClickEventHandler(ibtnDeleteComment_Click);
        this.gvComment.PageIndexChanging += new GridViewPageEventHandler(gvComment_PageIndexChanging);
        this.ibtnActivateComment.Click += new ImageClickEventHandler(ibtnActivateComment_Click);
        this.ibtnDeActivateComment.Click += new ImageClickEventHandler(ibtnDeActivateComment_Click);
        base.OnInit(e);
    }

    void ibtnDeActivateComment_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvComment.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnCommentId = (HiddenField)row.FindControl("hdnCommentId");
                CheckBox cbSelectedComment = (CheckBox)row.FindControl("cbSelect");
                if (hdnCommentId != null && (cbSelectedComment != null && cbSelectedComment.Checked))
                {
                    BLL.DeActivateComment(Convert.ToInt32(hdnCommentId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        GetAllComments();
    }

    void ibtnActivateComment_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvComment.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnCommentId = (HiddenField)row.FindControl("hdnCommentId");
                CheckBox cbSelectedComment = (CheckBox)row.FindControl("cbSelect");
                if (hdnCommentId != null && (cbSelectedComment != null && cbSelectedComment.Checked))
                {
                    BLL.ActivateComment(Convert.ToInt32(hdnCommentId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        GetAllComments();
    }

    void gvComment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvComment.PageIndex = e.NewPageIndex;
        GetAllComments();
        upnlComment.Update();
    }

    void ibtnDeleteComment_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvComment.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnCommentId = (HiddenField)row.FindControl("hdnCommentId");
                CheckBox cbSelectedComment = (CheckBox)row.FindControl("cbSelect");
                if (hdnCommentId != null && (cbSelectedComment != null && cbSelectedComment.Checked))
                {
                    BLL.DeleteComment(Convert.ToInt32(hdnCommentId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        GetAllComments();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAllComments();
            upnlComment.Update();
        }
    }

    private void GetAllComments()
    {
        if (Session["ArticleWriterId"] != null)
        {
            List<Comment> allComment = BLL.GetCommentsByTeacherId(Convert.ToInt32(Session["ArticleWriterId"]));
            gvComment.DataSource = allComment;
            gvComment.DataBind();
        }
    }

    public string GetNewsStatus(bool isActive)
    {
        if (isActive)
            return _Active;
        else
            return _InActive;
    }
}
