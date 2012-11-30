
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
using System.Net.Mail;
using System.Net;
using MyComponent.Business;

public partial class Default22 : System.Web.UI.Page
{
    const string operationMessage = "تمت العملية بنجاح";

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.ddlSpecialties.SelectedIndexChanged += new EventHandler(ddlSpecialties_SelectedIndexChanged);
        this.ddlCourses.SelectedIndexChanged += new EventHandler(ddlCourses_SelectedIndexChanged);
        this.btnSave.Click += new EventHandler(btnSave_Click);
        base.OnInit(e);
    }

    void btnSave_Click(object sender, EventArgs e)
    {
        bool isValid = true;
        try
        {
            MyComponent.Entities.Content content = BLL.GetContentById(Convert.ToInt32(ddlAllContents.SelectedValue));
            if (content != null)
            {
                content.CourseId = Convert.ToInt32(ddlCourses.SelectedValue);
                content.LevelId = Convert.ToInt32(ddlLevel.SelectedValue);
                content.AcademicYear = ddlAcademicYear.SelectedValue;
                content.Semester = Convert.ToInt32(ddlSemester.SelectedValue);
            }
            BLL.UpdateContent(content);
            FillContent();
            SetAlert(operationMessage);
        }
        catch (Exception ex)
        {
            isValid = false;
            Response.Write(ex.ToString());
        }
        finally
        {
            if (!isValid)
                SetAlert("حدث خطأ لا يمكن المتابعة");
        }
    }

    void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtLevels = BLL.GetCourseLevelsByCourseId(Convert.ToInt32(ddlCourses.SelectedValue));
        ddlLevel.DataSource = dtLevels;
        ddlLevel.DataTextField = "LEVEL_NAME";
        ddlLevel.DataValueField = "LEVEL_ID";
        ddlLevel.DataBind();
    }

    void ddlSpecialties_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtSpecialtyCourses = BLL.GetSpecialtyCoursesBySpecialtyId(Convert.ToInt32(ddlSpecialties.SelectedValue));
        ddlCourses.DataSource = dtSpecialtyCourses;
        ddlCourses.DataTextField = "COURSE_NAME";
        ddlCourses.DataValueField = "COURSE_ID";
        ddlCourses.DataBind();

    }
    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtAllspecialties = BLL.GetAllSpecialties();
            ddlSpecialties.DataSource = dtAllspecialties;
            ddlSpecialties.DataTextField = "SPECIALTY_NAME";
            ddlSpecialties.DataValueField = "SPECIALTY_ID";
            ddlSpecialties.DataBind();

            DataTable dtAllAcademicYears = BLL.GetAllAcademicYears();
            ddlAcademicYear.DataSource = dtAllAcademicYears;
            ddlAcademicYear.DataTextField = "ACADEMIC_YEAR_NAME";
            ddlAcademicYear.DataValueField = "ACADEMIC_YEAR_ID";
            ddlAcademicYear.DataBind();

            FillContent();
        }

        //SmtpClient client = new SmtpClient("65.98.33.194", 26);
        //client.Credentials = new NetworkCredential("feedback@mrjteacher.com", "122333");
        //try
        //{
        //    client.EnableSsl = false;
        //    MailMessage mail = new MailMessage("test@mrjteacher.com", "feedback@mrjteacher.com", "HI", "HI");
        //    client.Send(mail);

        //}
        //catch (Exception ex)
        //{

        //    throw ex;
        //}

        //MyComponent.Entities.User user = new MyComponent.Entities.User
        //{
        //    Cv = "CV",
        //    Email = "Admin",
        //    FirstName = "mrjTeacher",
        //    LastName = "",
        //    ImageName = "No_Image",
        //    Password = "123",
        //    RoleId = 1,
        //    ID = 1,
        //};
        //BLL.UpdateUser(user);

    }

    private void FillContent()
    {
        DataTable dtAllContent = BLL.GetAllContent();
        ddlAllContents.DataSource = dtAllContent;
        ddlAllContents.DataTextField = "FILE_NAME";
        ddlAllContents.DataValueField = "CONTENT_ID";
        ddlAllContents.DataBind();
    }

    void SetAlert(string istrMessage)
    {
        string s = "<SCRIPT language=\"javascript\">" +

           "alert('" + istrMessage + "') ;</SCRIPT>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowAlert" + istrMessage, s, false);
    }
}
