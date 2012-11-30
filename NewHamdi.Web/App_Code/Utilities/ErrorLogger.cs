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
using System.IO;
using System.Globalization;

/// <summary>
/// Summary description for ErrorLogger
/// </summary>
public static class ErrorLogger
{
    public static void WriteError(Exception ex)
    {
        try
        {
            string fileName = DateTime.Now.ToShortDateString().Replace("/", "-");

            string path = "~/ErrorLogs/" + fileName + ".txt";
            if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
            }
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                w.WriteLine("\r\nLog Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                string err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString() +
                              " Error Message: " + ex.Message + " Inner Exception : " + ex.InnerException;
                w.WriteLine(err);
                w.WriteLine("Trace: " + ex.StackTrace);
                w.WriteLine("__________________________");
                w.Flush();
                w.Close();

                // Notify Support Team :
                NotificationSender.SendEmailNotification("crash@mrjteacher.com",
                "ma_abushehab@hotmail.com", "mrjteacher Crash", err);
            }
        }
        catch (Exception exception)
        {


        }
    }
}
