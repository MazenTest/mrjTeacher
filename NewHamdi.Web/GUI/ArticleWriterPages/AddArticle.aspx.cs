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

public partial class GUI_AdminPages_AddArticle : ArticleWriterBasePage
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
        this.btnSaveArticle.Click += new EventHandler(btnSaveArticle_Click);
        this.ddlAllArticles.SelectedIndexChanged += new EventHandler(ddlAllArticles_SelectedIndexChanged);
        this.btnAddNew.Click += new EventHandler(btnAddNew_Click);
        base.OnInit(e);
    }

    void btnAddNew_Click(object sender, EventArgs e)
    {
        FillWriterArticles();
        BeginAddMode();
    }

    void ddlAllArticles_SelectedIndexChanged(object sender, EventArgs e)
    {
        IsAddMode = false;
        int articleId = -1;
        if (int.TryParse(ddlAllArticles.SelectedValue, out articleId))
            if (articleId > 0)
            {
                Article article = BLL.GetArticleById(articleId);
                if (article != null)
                {
                    txtArticleTitle.Text = article.Title;
                    ArticleBody.Text = article.Body;
                }
            }
    }

    void btnSaveArticle_Click(object sender, EventArgs e)
    {
        if (IsAddMode)
        {
            Article article = new Article();
            article.Title = txtArticleTitle.Text;
            article.PublishDate = DateTime.Now;
            article.Body = ArticleBody.Text;
            article.WriterId = Convert.ToInt32(Session["ArticleWriterId"]);

            BLL.AddNewArticle(article);
            SetAlert(operationMessage);
        }
        else
        {
            int articleId = -1;
            if (int.TryParse(ddlAllArticles.SelectedValue, out articleId))
                if (articleId > 0)
                {
                    Article article = BLL.GetArticleById(articleId);
                    if (article != null)
                    {
                        article.Title = txtArticleTitle.Text;
                        article.Body = ArticleBody.Text;
                        BLL.UpdateArticle(article);
                        SetAlert(operationMessage);
                    }
                }
        }
        FillWriterArticles();
        upnlAddArticle.Update();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillWriterArticles();
        }
    }

    private void FillWriterArticles()
    {
        BeginAddMode();
        DataTable dtWriterArticles = BLL.GetArticlesByWriterId(Convert.ToInt32(Session["ArticleWriterId"]));
        ddlAllArticles.DataSource = dtWriterArticles;
        ddlAllArticles.DataTextField = "ARTICLE_TITLE";
        ddlAllArticles.DataValueField = "ARTICLE_ID";
        ddlAllArticles.DataBind();
    }

    private void BeginAddMode()
    {
        IsAddMode = true;
        txtArticleTitle.Text = string.Empty;
        ArticleBody.Text = string.Empty;
    }
}
