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

public partial class GUI_ArticleWriterPages_MyProfile : ArticleWriterBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.ibtnDeleteContent.Click += new ImageClickEventHandler(ibtnDeleteContent_Click);
        this.gvContents.PageIndexChanging += new GridViewPageEventHandler(gvContents_PageIndexChanging);
        this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        this.btnUpdateImage.Click += new EventHandler(btnUpdateImage_Click);
        base.OnInit(e);
    }

    void btnUpdateImage_Click(object sender, EventArgs e)
    {
        if (fupArticleWriterImage.PostedFile != null)
        {
            if (fupArticleWriterImage.PostedFile != null)
            {
                string extension = Path.GetExtension(fupArticleWriterImage.PostedFile.FileName);
                string imageName = Guid.NewGuid().ToString() + extension;
                string path = Server.MapPath("~/UsersImages/");
                fupArticleWriterImage.SaveAs(path + imageName);

                BLL.UpdateUserImage(Convert.ToInt32(Session["ArticleWriterId"]), imageName);

                FillArticleWriterInfo();
                SetAlert(operationMessage);
                upnlMyProfile.Update();
            }
        }
    }

    void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["ArticleWriterId"] != null)
        {
            MyComponent.Entities.User ArticleWriter = BLL.GetUserById(Convert.ToInt32(Session["ArticleWriterId"]));
            if (ArticleWriter != null)
            {
                ArticleWriter.FirstName = txtArticleWriterFirstName.Text;
                ArticleWriter.LastName = txtArticleWriterLastName.Text;
                ArticleWriter.Cv = txtMyCv.Text;

                BLL.UpdateUser(ArticleWriter);

                SetAlert(operationMessage);
                upnlMyProfile.Update();
            }
        }
    }

    void gvContents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvContents.PageIndex = e.NewPageIndex;
        FillContentGrid();
        upnlMyProfile.Update();
    }

    void ibtnDeleteContent_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gvContents.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnContentId = (HiddenField)row.FindControl("hdnContentId");
                    CheckBox cbSelectedContent = (CheckBox)row.FindControl("cbSelect");
                    if (hdnContentId != null && (cbSelectedContent != null && cbSelectedContent.Checked))
                    {
                        BLL.DeleteArticle(Convert.ToInt32(hdnContentId.Value));
                        SetAlert(operationMessage);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SetAlert("لا يمكن حذف المحتوى بسبب الارتباط بتعليقات");
        }
        FillContentGrid();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillArticleWriterInfo();
            upnlMyProfile.Update();
        }
    }

    private void FillArticleWriterInfo()
    {
        MyComponent.Entities.User ArticleWriter = BLL.GetUserById(Convert.ToInt32(Session["ArticleWriterId"]));
        if (ArticleWriter != null)
        {
            txtArticleWriterFirstName.Text = ArticleWriter.FirstName;
            txtArticleWriterLastName.Text = ArticleWriter.LastName;

            if (File.Exists(Server.MapPath("~/UsersImages/" + ArticleWriter.ImageName)))
                imgArticleWriter.ImageUrl = ResolveUrl("~/UsersImages/" + ArticleWriter.ImageName);

            txtMyCv.Text = ArticleWriter.Cv;
        }
        FillContentGrid();
    }

    private void FillContentGrid()
    {
        DataTable dtContetns = BLL.GetArticlesByWriterId(Convert.ToInt32(Session["ArticleWriterId"]));

        if (dtContetns != null && dtContetns.Rows.Count > 0)
            gvContents.DataSource = dtContetns;
        else
            gvContents.DataSource = new DataTable();

        gvContents.DataBind();

    }
}
