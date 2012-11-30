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
using MyComponent.Entities;
using MyComponent.Business;
using System.Collections.Generic;

public partial class GUI_PublicPages_UsefulInfoDetails : PublicBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSaveComment.Click += new EventHandler(btnSaveComment_Click);
        base.OnInit(e);
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillUsefulInfoDetails();
            ClearCommentTextBox();
            upnlAllComments.Update();
            upnlAddComments.Update();
        }
    }

    void btnSaveComment_Click(object sender, EventArgs e)
    {
        try
        {
            int UsefulInfoId = 0;
            if (int.TryParse(Request.QueryString["Uid"], out UsefulInfoId))
            {
                if (UsefulInfoId > 0)
                {
                    Comment comment = new Comment
                    {
                        WriterName = txtWriterNameComment.Text,
                        UsefulInfoId = UsefulInfoId,
                        CommentBody = txtComment.Text,
                        PublishDate = DateTime.Now,
                    };

                    BLL.AddComment(comment);
                    ClearCommentTextBox();
                    SetAlert("تم إضافة التعليق بنجاح، سيتم نشر التعليق بعد موافقة الإدارة");
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogger.WriteError(ex);
        }
    }

    private void FillUsefulInfoDetails()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Uid"]))
        {
            int UsefulInfoId = 0;
            if (int.TryParse(Request.QueryString["Uid"].ToString(), out UsefulInfoId))
                if (UsefulInfoId > 0)
                {
                    UsefulInfo UsefulInfo = BLL.GetUsefulInfoById(UsefulInfoId);
                    if (UsefulInfo != null)
                    {
                        dvUsefulInfoDetails.InnerHtml += "<center>";
                        dvUsefulInfoDetails.InnerHtml += UsefulInfo.Body;
                        dvUsefulInfoDetails.InnerHtml += "</center>";

                        this.Title = UsefulInfo.Title;
                        lblUsefulInfoTitle.Text = UsefulInfo.Title;
                        lblUsefulInfoPublishDate.Text = UsefulInfo.PublishDate.ToShortDateString();

                        btnSaveComment.Enabled = true;

                        string metaTags = UsefulInfo.Title;
                        string description = UsefulInfo.Title;
                        AddMetaTagsAndPageDescription(metaTags, description);

                        FillComments();
                        upnlAddComments.Update();
                    }
                }
        }
    }

    private void ClearCommentTextBox()
    {
        txtComment.Text = string.Empty;
        txtWriterNameComment.Text = string.Empty;
    }

    private void FillComments()
    {
        int UsefulInfoId = 0;
        if (int.TryParse(Request.QueryString["Uid"], out UsefulInfoId))
        {
            if (UsefulInfoId > 0)
            {
                List<Comment> comments = BLL.GetCommentsByUsefulInfoId(UsefulInfoId);

                if (comments != null && comments.Count > 0)
                    dlstUsefulInfoComments.DataSource = comments.Where(c => c.IsActive).ToList();
                else
                    dlstUsefulInfoComments.DataSource = new List<Comment>();

                dlstUsefulInfoComments.DataBind();
            }
        }
    }
}
