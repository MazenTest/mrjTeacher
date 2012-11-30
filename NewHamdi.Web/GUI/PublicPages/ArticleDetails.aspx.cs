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

public partial class GUI_PublicPages_ArticleDetails : PublicBasePage
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
            FillArticleDetails();
            ClearCommentTextBox();
            upnlAllComments.Update();
            upnlAddComments.Update();
        }
    }

    void btnSaveComment_Click(object sender, EventArgs e)
    {
        try
        {
            int articleId = 0;
            if (int.TryParse(Request.QueryString["Aid"], out articleId))
            {
                if (articleId > 0)
                {
                    Comment comment = new Comment
                    {
                        WriterName = txtWriterNameComment.Text,
                        ArticleId = articleId,
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

    private void FillArticleDetails()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Aid"]))
        {
            int ArticleId = 0;
            if (int.TryParse(Request.QueryString["Aid"].ToString(), out ArticleId))
                if (ArticleId > 0)
                {
                    Article Article = BLL.GetArticleById(ArticleId);
                    if (Article != null)
                    {
                        dvArticleDetails.InnerHtml += "<center>";
                        dvArticleDetails.InnerHtml += Article.Body;
                        dvArticleDetails.InnerHtml += "</center>";

                        this.Title = Article.Title;
                        lblArticleTitle.Text = Article.Title;
                        lblArticlePublishDate.Text = Article.PublishDate.ToShortDateString();

                        btnSaveComment.Enabled = true;


                        string metaTags = Article.Title;
                        string description = Article.Title;
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
        int ArticleId = 0;
        if (int.TryParse(Request.QueryString["Aid"], out ArticleId))
        {
            if (ArticleId > 0)
            {
                List<Comment> comments = BLL.GetCommentsByArticleId(ArticleId);

                if (comments != null && comments.Count > 0)
                    dlstArticleComments.DataSource = comments.Where(c => c.IsActive).ToList();
                else
                    dlstArticleComments.DataSource = new List<Comment>();

                dlstArticleComments.DataBind();
            }
        }
    }
}
