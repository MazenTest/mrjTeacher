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
using System.Text;
using System.Net;
using MyComponent.Business;

public partial class GUI_TeacherPages_Download : TeacherBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.lbtnDownload.Click += new EventHandler(lbtnDownload_Click);
        base.OnInit(e);

    }

    void Page_Load(object sender, EventArgs e)
    {

    }

    void lbtnDownload_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Cid"]))
        {
            int contentId = 0;

            if (int.TryParse(Request.QueryString["Cid"], out contentId))
            {
                if (contentId > 0)
                {
                    MyComponent.Entities.Content content = BLL.GetContentById(contentId);

                    if (content != null)
                    {
                        string filePath = Server.MapPath("~/Questions/" + content.FileNamePath);
                        // string strURL = txtFileName.Text;
                        WebClient req = new WebClient();
                        HttpResponse response = HttpContext.Current.Response;
                        response.Clear();
                        response.ClearContent();
                        response.ClearHeaders();
                        response.Buffer = true;
                        response.AddHeader("Content-Disposition", "attachment;filename=\"" + content.FileName +
                            Path.GetExtension(content.FileNamePath) + "\"");
                        byte[] data = req.DownloadData(Server.MapPath("../../Questions/" + content.FileNamePath));
                        response.BinaryWrite(data);
                        BLL.IncreaseContentDownLoadCount(contentId);
                        response.End();
                    }
                }
            }
        }
    }

}
