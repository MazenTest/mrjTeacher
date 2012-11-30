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

public partial class GUI_AdminPages_AddNews : AdminBasePage
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

    private int SelectedNewsId
    {
        set
        {
            ViewState["SelectedNewsId"] = value;
        }
        get
        {
            int selectedNewsId = -1;
            if (ViewState["SelectedNewsId"] != null)
                selectedNewsId = Convert.ToInt32(ViewState["SelectedNewsId"]);

            return selectedNewsId;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSaveNews.Click += new EventHandler(btnSaveNews_Click);
        this.ddlAllNewss.SelectedIndexChanged += new EventHandler(ddlAllNewss_SelectedIndexChanged);
        this.btnAddNew.Click += new EventHandler(btnAddNew_Click);
        base.OnInit(e);
    }

    void btnAddNew_Click(object sender, EventArgs e)
    {
        BeginAddMode();
        upnlAddNews.Update();
    }

    void ddlAllNewss_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedNewsId = Convert.ToInt32(ddlAllNewss.SelectedValue);
        BeginNewsEditMode();
        upnlAddNews.Update();
    }

    void btnSaveNews_Click(object sender, EventArgs e)
    {
        if (IsAddMode)
        {
            SaveNewNews();
            BeginAddMode();
        }
        else
        {
            UpdateNews();
            FillNewsDropDown();
            BeginNewsEditMode();
            
        }

        FillNewsDropDown(); 
        upnlAddNews.Update();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BeginAddMode();
            FillNewsDropDown();
        }
    }

    private void UpdateNews()
    {
        bool isSizePassed = true;

        if (SelectedNewsId > 0)
        {
            News news = BLL.GetNewsById(SelectedNewsId);
            if (news != null)
            {
                news.Title = TextNewsTitle.Text;
                news.Body = newsBody.Text;

                if (fUploadNewsImage.PostedFile != null && fUploadNewsImage.PostedFile.ContentLength > 0)
                {
                    int maxFileSize = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFileSize"].ToString());
                    if (fUploadNewsImage.PostedFile.ContentLength < maxFileSize)
                    {
                        string extension = Path.GetExtension(fUploadNewsImage.PostedFile.FileName);
                        string imageName = Guid.NewGuid().ToString() + extension;
                        string path = Server.MapPath("~/NewsImages/");
                        fUploadNewsImage.SaveAs(path + imageName);
                        news.ImageName = imageName;
                    }
                    else
                        isSizePassed = false;
                }
                if (isSizePassed)
                {
                    BLL.UpdateNews(news);
                    SetAlert(operationMessage);
                }
                else
                    SetAlert(maxFileSizeExceeds);
            }
        }
    }

    private void SaveNewNews()
    {
        if (fUploadNewsImage.PostedFile != null)
        {
            int maxFileSize = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFileSize"].ToString());
            if (fUploadNewsImage.PostedFile.ContentLength < maxFileSize)
            {
                string extension = Path.GetExtension(fUploadNewsImage.PostedFile.FileName);
                string imageName = Guid.NewGuid().ToString() + extension;
                string path = Server.MapPath("~/NewsImages/");
                fUploadNewsImage.SaveAs(path + imageName);

                News news = new News();
                news.Title = TextNewsTitle.Text;
                news.PublishDate = DateTime.Now;
                news.Body = newsBody.Text;
                news.ImageName = imageName;

                BLL.AddNews(news);
                SetAlert(operationMessage);
            }
            else
                SetAlert(maxFileSizeExceeds);
        }
    }

    private void BeginAddMode()
    {
        SelectedNewsId = -1;
        imgNEwsImage.Visible = false;
        IsAddMode = true;
        TextNewsTitle.Text = string.Empty;
        newsBody.Text = string.Empty;
        rfvUploadNeasImage.Enabled = true;
    }

    private void BeginNewsEditMode()
    {
        IsAddMode = false;

        if (SelectedNewsId > 0)
        {
            News news = BLL.GetNewsById(SelectedNewsId);
            if (news != null)
            {
                TextNewsTitle.Text = news.Title;
                newsBody.Text = news.Body;
                imgNEwsImage.ImageUrl = "~/NewsImages/" + news.ImageName;
                imgNEwsImage.Visible = true;
                rfvUploadNeasImage.Enabled = false;

                ddlAllNewss.SelectedValue = SelectedNewsId.ToString();
            }
        }
        else
            BeginAddMode();
    }

    private void FillNewsDropDown()
    {
        DataTable allNews = BLL.GetAllNews();
        ddlAllNewss.DataSource = allNews;
        ddlAllNewss.DataTextField = "TITLE";
        ddlAllNewss.DataValueField = "NEWS_ID";
        ddlAllNewss.DataBind();
    }
}
