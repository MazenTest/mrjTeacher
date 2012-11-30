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

public partial class GUI_AdminPages_AddBanners : AdminBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSaveBanner.Click += new EventHandler(btnSaveBanner_Click);
        base.OnInit(e);
    }

    void btnSaveBanner_Click(object sender, EventArgs e)
    {
        if (fUploadBannersImage.PostedFile != null)
        {
            int maxFileSize = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFileSize"].ToString());
            if (fUploadBannersImage.PostedFile.ContentLength < maxFileSize)
            {
                string extension = Path.GetExtension(fUploadBannersImage.PostedFile.FileName);
                string imageName = Guid.NewGuid().ToString() + extension;
                string path = Server.MapPath("~/BannersImages/");
                fUploadBannersImage.SaveAs(path + imageName);

                Banner banner = new Banner
                {
                    Title = TextBannersTitle.Text,
                    RedirectUrl = txtBannerRedirectUrl.Text,
                    ImageName = imageName,
                    IsActive = Convert.ToBoolean(0),
                    Position = Convert.ToInt32(ddlBannerPositions.SelectedValue),
                };
                BLL.AddBanner(banner);
                SetAlert(operationMessage);
            }
            else
                SetAlert(maxFileSizeExceeds);
        }
    }
    void Page_Load(object sender, EventArgs e)
    {

    }
}
