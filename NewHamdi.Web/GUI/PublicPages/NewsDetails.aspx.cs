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

public partial class GUI_PublicPages_NewsDetails : PublicBasePage
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
            FillNewsDetails();
            ClearCommentTextBox();
            upnlAllComments.Update();
            upnlAddComments.Update();
        }
    }

    void btnSaveComment_Click(object sender, EventArgs e)
    {
        try
        {
            int newsId = 0;
            if (int.TryParse(Request.QueryString["Nid"], out newsId))
            {
                if (newsId > 0)
                {
                    Comment comment = new Comment
                    {
                        WriterName = txtWriterNameComment.Text,
                        NewsId = newsId,
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

    private void FillNewsDetails()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Nid"]))
        {
            int newsId = 0;
            if (int.TryParse(Request.QueryString["Nid"].ToString(), out newsId))
                if (newsId > 0)
                {
                    News news = BLL.GetNewsById(newsId);
                    if (news != null)
                    {
                        dvNewsDetails.InnerHtml += "<center>";
                        dvNewsDetails.InnerHtml += news.Body;
                        dvNewsDetails.InnerHtml += "</center>";

                        this.Title = news.Title;
                        lblNewsTitle.Text = news.Title;
                        lblNewsPublishDate.Text = news.PublishDate.ToShortDateString();

                        btnSaveComment.Enabled = true;

                        string metaTags = news.Title;
                        string description = news.Title;
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
        int newsId = 0;
        if (int.TryParse(Request.QueryString["Nid"], out newsId))
        {
            if (newsId > 0)
            {
                List<Comment> comments = BLL.GetCommentsByNewsId(newsId);

                if (comments != null && comments.Count > 0)
                    dlstNewsComments.DataSource = comments.Where(c => c.IsActive).ToList();
                else
                    dlstNewsComments.DataSource = new List<Comment>();

                dlstNewsComments.DataBind();
            }
        }
    }
}
