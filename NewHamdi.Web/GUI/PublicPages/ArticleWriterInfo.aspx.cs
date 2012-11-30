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
using System.Collections.Generic;
using MyComponent.Entities;

public partial class ArticleWriterInfo : PublicBasePage
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
            if (!string.IsNullOrEmpty(Request.QueryString["Arid"]))
            {
                FillArticleWriterInfo();
                FillComments();
                ClearCommentTextBox();

                upnlAllComments.Update();
                upnlAddComments.Update();
            }
        }
    }

    void btnSaveComment_Click(object sender, EventArgs e)
    {
        try
        {
            int articleWriterId = 0;
            if (int.TryParse(Request.QueryString["Arid"], out articleWriterId))
            {
                if (articleWriterId > 0)
                {
                    Comment comment = new Comment
                    {
                        WriterName = txtWriterNameComment.Text,
                        ArticleWriterId = articleWriterId,
                        CommentBody = txtComment.Text,
                        IsActive = false,
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

    private void FillArticleWriterInfo()
    {
        int ArticleWriterId = 0;
        if (int.TryParse(Request.QueryString["Arid"], out ArticleWriterId))
        {
            if (ArticleWriterId > 0)
            {
                MyComponent.Entities.User ArticleWriter = BLL.GetUserById(ArticleWriterId);
                if (ArticleWriter != null)
                {
                    lblArticleWriterName.Text = ArticleWriter.FirstName + " " + ArticleWriter.LastName;
                    if (File.Exists(Server.MapPath("~/UsersImages/" + ArticleWriter.ImageName)))
                        imgArticleWriter.ImageUrl = ResolveUrl("~/UsersImages/" + ArticleWriter.ImageName);

                    dvCv.InnerHtml = ArticleWriter.Cv;
                    this.Title = "معلومات الكاتب " + ArticleWriter.FirstName + " " + ArticleWriter.LastName;
                    lblArticleWriterInfoTitle.Text = "معلومات الكاتب " + ArticleWriter.FirstName + " " + ArticleWriter.LastName;

                    btnSaveComment.Enabled = true;

                    string metaTags = ArticleWriter.FirstName + " " + ArticleWriter.LastName;
                    string description = "معلومات الكاتب";
                    AddMetaTagsAndPageDescription(metaTags, description);
                }

                FillContentGrid(ArticleWriterId);
                FillComments();
            }
        }
    }

    private void FillContentGrid(int writerId)
    {
        DataTable dtContetns = BLL.GetArticlesByWriterId(writerId);

        if (dtContetns != null && dtContetns.Rows.Count > 0)
            gvContents.DataSource = dtContetns;
        else
            gvContents.DataSource = new DataTable();

        gvContents.DataBind();
    }

    private void ClearCommentTextBox()
    {
        txtComment.Text = string.Empty;
        txtWriterNameComment.Text = string.Empty;
    }

    private void FillComments()
    {
        int articleWriterId = 0;
        if (int.TryParse(Request.QueryString["Arid"], out articleWriterId))
        {
            if (articleWriterId > 0)
            {
                List<Comment> comments = BLL.GetCommentsByArticleWriterId(articleWriterId);

                if (comments != null && comments.Count > 0)
                    dlstArticleWriterComments.DataSource = comments.Where(c => c.IsActive).ToList();
                else
                    dlstArticleWriterComments.DataSource = new List<Comment>();

                dlstArticleWriterComments.DataBind();
            }
        }
    }
}
