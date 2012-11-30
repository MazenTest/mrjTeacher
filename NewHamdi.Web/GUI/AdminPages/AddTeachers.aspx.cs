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

using System.Xml.Linq;
using System.IO;
using MyComponent.Entities;
using MyComponent.Business;
using MyComponent.Enums;

public partial class GUI_AdminPages_AddTeachers : AdminBasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        User newUser = new User();
        bool fileSizePassed = true;

        if (fUploadTeacherImage.PostedFile != null)
        {
            int maxFileSize = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFileSize"].ToString());
            if (fUploadTeacherImage.PostedFile.ContentLength < maxFileSize)
            {
                string extension = Path.GetExtension(fUploadTeacherImage.PostedFile.FileName);
                string imageName = Guid.NewGuid().ToString() + extension;
                string path = Server.MapPath("~/UsersImages/");
                fUploadTeacherImage.SaveAs(path + imageName);
                newUser.ImageName = imageName;
            }
            else
                fileSizePassed = false;
        }

        if (fileSizePassed)
        {
            string userName = GenerateUniqueUserName(8);
            string password = GeneratePassword(8);

            newUser.Email = userName;
            newUser.Password = password;
            newUser.RoleId = (int)UserRoles.Teacher; ;
            newUser.FirstName = txtFirstName.Text;
            newUser.LastName = txtLastName.Text;
            newUser.Cv = txtCv.Text;

            BLL.AddNewUser(newUser);

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCv.Text = "";

            SetAlert(operationMessage);
            SetAlert("اسم المستخدم :" + userName + " " + "كلمة السر :" + password);
        }
        else
            SetAlert(maxFileSizeExceeds);

    }


    #region Functions

    private static string GeneratePassword(int passwordLength)
    {
        string allowedChars = "abcdefghijkmnpqrstuvwxyz123456789";
        char[] chars = new char[passwordLength];
        Random rd = new Random();

        for (int i = 0; i < passwordLength; i++)
        {
            chars[i] = allowedChars[rd.Next(1, allowedChars.Length)];
        }

        return new string(chars);
    }

    private string GenerateUniqueUserName(int passwordLength)
    {
        string userName = BuildRandomUserName(passwordLength);
        DataTable dtAllUsers = BLL.GetAllUsers();
        if (dtAllUsers != null && (dtAllUsers.Rows != null && dtAllUsers.Rows.Count > 0))
        {
            foreach (DataRow row in dtAllUsers.Rows)
            {
                if (string.Equals(row["EMAIL"].ToString(), userName, StringComparison.InvariantCultureIgnoreCase))
                {
                    userName = BuildRandomUserName(passwordLength);
                    continue;
                }
                else
                    break;
            }
        }

        return userName;

    }

    private string BuildRandomUserName(int passwordLength)
    {
        string allowedChars = "abcdefghijkmnpqrstuvwxyz123456789";
        char[] chars = new char[passwordLength];
        Random rd = new Random();

        for (int i = 0; i < passwordLength; i++)
        {
            chars[i] = allowedChars[rd.Next(1, allowedChars.Length)];
        }

        return new string(chars);
    }

    #endregion
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtCv.Text = "";
    }
}
