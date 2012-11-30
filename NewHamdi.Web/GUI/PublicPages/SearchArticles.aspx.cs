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
using MyComponent.Enums;

public partial class SearchArticles : PublicBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSearch.Click += new EventHandler(btnSearch_Click);
        this.gvArticles.PageIndexChanging += new GridViewPageEventHandler(gvArticles_PageIndexChanging);
        base.OnInit(e);
    }

    void gvArticles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvArticles.PageIndex = e.NewPageIndex;
        SearchSelectedTest();
        upnlSearchArticles.Update();
    }
    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillWritersDropDown();

            string metaTags = "  المقالات الكتاب الكتّاب المعلم الاردني معلمو المواد المعلمين المعلمون السنوات الدراسية التخصصات التربية الاسلامية نظم المعلومات الرياضيات اللغة العربية اللغة الانجليزية الادبي العلمي التمريض برمجة الحاسوب الاخبار الأخبار التعليمية المواقع المفيدة";
            string description = "feedback@mrjteacher.com";
            AddMetaTagsAndPageDescription(metaTags, description);
        }
    }

    void btnSearch_Click(object sender, EventArgs e)
    {
        SearchSelectedTest();
        upnlSearchArticles.Update();
    }

    private void SearchSelectedTest()
    {
        int writerId = -1;
        string articleTitle = string.Empty;

        if (Convert.ToInt32(ddlWriters.SelectedValue) > 0)
            writerId = Convert.ToInt32(ddlWriters.SelectedValue);

        if (!string.IsNullOrEmpty(txtArticleTitle.Text))
            articleTitle = txtArticleTitle.Text.Trim();

        DataTable dtArticles = BLL.SearchArticles(writerId, articleTitle);

        if (dtArticles != null && dtArticles.Rows.Count > 0)
            gvArticles.DataSource = dtArticles;
        else
            gvArticles.DataSource = new DataTable();

        gvArticles.DataBind();
    }

    private void FillWritersDropDown()
    {
        DataTable dtAllWriters = BLL.GetUsersByRoleId((int)UserRoles.ArticleWriter);
        ddlWriters.DataSource = dtAllWriters;
        ddlWriters.DataTextField = "FULL_NAME";
        ddlWriters.DataValueField = "USER_ID";
        ddlWriters.DataBind();
    }

}
