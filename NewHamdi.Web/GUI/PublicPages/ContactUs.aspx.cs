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

public partial class GUI_PublicPages_ContactUs : PublicBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSend.Click += new EventHandler(btnSend_Click);
        base.OnInit(e);
    }
    void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string metaTags = "اتصل بنا موقع المعلم الاردني الأردني ";
            string description = "feedback@mrjteacher.com";
            AddMetaTagsAndPageDescription(metaTags, description);
        }
    }
    void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            NotificationSender.SendEmailNotification(txtSenderemail.Text.Trim(),
                "feedback@mrjteacher.com", txtEmailSubject.Text.Trim(), txtEmailBody.Text);

            lblEmailSent.Visible = true;
            ClearEmailForm();
            SetAlert("تم إرسال الرسالة بنجاح ، شكراً لكـ");
        }
        catch (Exception ex)
        {
            ErrorLogger.WriteError(ex);
        }
    }

    private void ClearEmailForm()
    {
        txtSenderemail.Text = string.Empty;
        txtSenderName.Text = string.Empty;
        txtEmailSubject.Text = string.Empty;
        txtEmailBody.Text = string.Empty;
    }
}
