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

public partial class GUI_AdminPages_AddUsefullWebsites : AdminBasePage
{
    private int SelectedWebsiteId
    {
        set
        {
            ViewState["SelectedWebsiteId"] = value;
        }
        get
        {
            int selectedWebsiteId = -1;
            if (ViewState["SelectedWebsiteId"] != null)
                selectedWebsiteId = Convert.ToInt32(ViewState["SelectedWebsiteId"]);

            return selectedWebsiteId;
        }
    }

    int maxFileSize = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFileSize"].ToString());

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSaveWebsite.Click += new EventHandler(btnSaveWebsite_Click);
        this.ddlAllUsefulWebsites.SelectedIndexChanged += new EventHandler(ddlAllUsefulWebsites_SelectedIndexChanged);
        this.btnAddNew.Click += new EventHandler(btnAddNew_Click);
        base.OnInit(e);
    }

    void btnAddNew_Click(object sender, EventArgs e)
    {
        BeginAddMode();
        upnlAddUsefullWebsites.Update();
    }

    void ddlAllUsefulWebsites_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedWebsiteId = -1;
        int.TryParse(ddlAllUsefulWebsites.SelectedValue, out selectedWebsiteId);

        BeginAddMode();

        if (selectedWebsiteId > 0)
        {
            BeginEditMode(selectedWebsiteId);
        }
        upnlAddUsefullWebsites.Update();
    }

    void btnSaveWebsite_Click(object sender, EventArgs e)
    {
        try
        {
            if (SelectedWebsiteId > 0)
            {
                UpdateWebsite();
                BeginEditMode(SelectedWebsiteId);
            }
            else
            {
                SaveNewUsefullWebsite();
                BeginAddMode();
            }
            FillAllUSefulWebsites();
            upnlAddUsefullWebsites.Update();
        }
        catch (Exception ex)
        {
            ErrorLogger.WriteError(ex);
        }
    }

    private void UpdateWebsite()
    {
        UsefulWebsite website = BLL.GetlUsefulWebsiteById(SelectedWebsiteId);
        if (website != null)
        {
            website.Name = txtWebsiteName.Text;
            website.RedirectUrl = txtRedirectUrl.Text;
            if (fupWebsiteImage.PostedFile != null && fupWebsiteImage.PostedFile.ContentLength > 0)
            {
                if (fupWebsiteImage.PostedFile.ContentLength < maxFileSize)
                {
                    string extension = Path.GetExtension(fupWebsiteImage.PostedFile.FileName);
                    string imageName = Guid.NewGuid().ToString() + extension;
                    string path = Server.MapPath("~/WebsitesImages/");
                    fupWebsiteImage.SaveAs(path + imageName);
                    website.ImageName = imageName;
                }
                else
                {
                    SetAlert(maxFileSizeExceeds);
                }
            }
            BLL.UpdateUsefulWebsite(website);
            SetAlert(operationMessage);
        }
    }

    private void SaveNewUsefullWebsite()
    {
        if (fupWebsiteImage.PostedFile.ContentLength < maxFileSize)
        {
            string extension = Path.GetExtension(fupWebsiteImage.PostedFile.FileName);
            string imageName = Guid.NewGuid().ToString() + extension;
            string path = Server.MapPath("~/WebsitesImages/");
            fupWebsiteImage.SaveAs(path + imageName);

            UsefulWebsite website = new UsefulWebsite
            {
                Name = txtWebsiteName.Text,
                RedirectUrl = txtRedirectUrl.Text,
                ImageName = imageName
            };

            BLL.AddUsefulWebsite(website);

            SetAlert(operationMessage);
        }
        else
            SetAlert(maxFileSizeExceeds);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAllUSefulWebsites();
        }
    }

    private void FillAllUSefulWebsites()
    {
        DataTable dtAllUsefulWebsites = BLL.GetAllUsefulWebsites();
        ddlAllUsefulWebsites.DataSource = dtAllUsefulWebsites;
        ddlAllUsefulWebsites.DataTextField = "WEBSITE_NAME";
        ddlAllUsefulWebsites.DataValueField = "WEBSITE_ID";
        ddlAllUsefulWebsites.DataBind();
    }

    private void BeginAddMode()
    {
        SelectedWebsiteId = -1;
        txtWebsiteName.Text = string.Empty;
        txtRedirectUrl.Text = string.Empty;
        imgUsefulWebsite.Visible = false;
        trImage.Visible = false;
        rfvWebsiteImage.Enabled = true;
    }

    private void BeginEditMode(int selectedWebsiteId)
    {
        SelectedWebsiteId = selectedWebsiteId;
        UsefulWebsite website = BLL.GetlUsefulWebsiteById(selectedWebsiteId);
        if (website != null)
        {
            txtWebsiteName.Text = website.Name;
            txtRedirectUrl.Text = website.RedirectUrl;
            imgUsefulWebsite.ImageUrl = "~/WebsitesImages/" + website.ImageName;
            trImage.Visible = true;
            imgUsefulWebsite.Visible = true;
            rfvWebsiteImage.Enabled = false;
        }
    }
}
