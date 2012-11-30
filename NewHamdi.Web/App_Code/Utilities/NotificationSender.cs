using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for NotificationSender
/// </summary>
public static class NotificationSender
{
    public static void SendEmailNotification(string mailFrom, string mailTo, string mailSubject, string mailBody)
    {
        SmtpClient smtpClient = new SmtpClient("65.98.33.194", 26);// mail.mrjteacher.com : Port:26
        smtpClient.Credentials = new NetworkCredential("feedback@mrjteacher.com", "122333");

        smtpClient.EnableSsl = false;
        MailMessage mail = new MailMessage(mailFrom, mailTo, mailSubject, mailBody);
        smtpClient.Send(mail);
    }
}
