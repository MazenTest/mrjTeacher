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
using System.Collections.Generic;
using MyComponent.Entities;

public partial class GUI_TeacherPages_AddContent : TeacherBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSave.Click += new EventHandler(btnSave_Click);
        this.ddlSpecialty.SelectedIndexChanged += new EventHandler(ddlSpecialty_SelectedIndexChanged);
        this.ddlCoursesAdd.SelectedIndexChanged += new EventHandler(ddlCoursesAdd_SelectedIndexChanged);
        base.OnInit(e);
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSpecialties();

            ddlCoursesAdd.DataSource = new DataTable();
            ddlCoursesAdd.DataBind();
            ddlCourseLevelsAdd.DataSource = new DataTable();
            ddlCourseLevelsAdd.DataBind();

            upnlAddContent.Update();
        }
    }

    void btnSave_Click(object sender, EventArgs e)
    {
        MyComponent.Entities.Content content = new MyComponent.Entities.Content();
        content.FileName = TextFileName.Text;
        content.Semester = -1;
        content.SpecialtyId = Convert.ToInt32(ddlSpecialty.SelectedValue);
        content.PublishDate = DateTime.Now;
        content.AcademicYear = "-1";
        content.WriterId = Convert.ToInt32(Session["TeacherId"]);
        content.Type = Convert.ToInt32(ddlContentTypes.SelectedValue);

        bool fileSizePassed = true;

        if (FUpContent.PostedFile != null)
        {
            if (FUpContent.PostedFile != null)
            {
                int maxFileSize = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFileSize"].ToString());
                string extension = Path.GetExtension(FUpContent.PostedFile.FileName);
                string fileName = Guid.NewGuid().ToString() + extension;
                string path = Server.MapPath("~/Questions/");
                FUpContent.SaveAs(path + fileName);
                content.FileNamePath = fileName;
                content.LevelId = Convert.ToInt32(ddlCourseLevelsAdd.SelectedValue);
                content.CourseId = Convert.ToInt32(ddlCoursesAdd.SelectedValue);
            }
            else
                fileSizePassed = false;
        }

        if (fileSizePassed)
        {
            BLL.AddContent(content);
            SetAlert(operationMessage);
        }
        else
            SetAlert(maxFileSizeExceeds);
    }

    void ddlSpecialty_SelectedIndexChanged(object sender, EventArgs e)
    {
        int specialtyId = -1;
        if (int.TryParse(ddlSpecialty.SelectedValue, out specialtyId))
            if (specialtyId > 0)
            {
                FillSpecialtyCourses(specialtyId);
            }
            else
                ddlCoursesAdd.DataSource = new DataTable();

        ddlCoursesAdd.DataBind();

        upnlAddContent.Update();
    }

    void ddlCoursesAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseId = -1;
        if (int.TryParse(ddlCoursesAdd.SelectedValue, out courseId))
            if (courseId > 0)
            {
                DataTable dtCourseLevels = BLL.GetCourseLevelsByCourseId(courseId);
                ddlCourseLevelsAdd.DataSource = dtCourseLevels;
                ddlCourseLevelsAdd.DataTextField = "LEVEL_NAME";
                ddlCourseLevelsAdd.DataValueField = "LEVEL_ID";
                ddlCourseLevelsAdd.DataBind();
            }
            else
            {
                ddlCourseLevelsAdd.DataSource = new DataTable();
                ddlCourseLevelsAdd.DataBind();
            }
        upnlAddContent.Update();
    }

    private void FillSpecialties()
    {
        DataTable dtAllSpecialties = BLL.GetAllSpecialties();

        ddlSpecialty.DataSource = dtAllSpecialties;
        ddlSpecialty.DataTextField = "SPECIALTY_NAME";
        ddlSpecialty.DataValueField = "SPECIALTY_ID";
        ddlSpecialty.DataBind();
    }

    private void FillSpecialtyCourses(int SpecialtyId)
    {
        List<int> teacherCoursesIds = BLL.GetCoursesIdsByTeacherId(Convert.ToInt32(Session["TeacherId"]));
        List<Course> courses = new List<Course>();

        DataTable dtSpecialtyCourses = BLL.GetSpecialtyCoursesBySpecialtyId(SpecialtyId);

        if (dtSpecialtyCourses != null && dtSpecialtyCourses.Rows.Count > 0)
        {
            Course course = null;
            foreach (DataRow dr in dtSpecialtyCourses.Rows)
            {
                course = new Course
               {
                   ID = Convert.ToInt32(dr["COURSE_ID"]),
                   Name = dr["COURSE_NAME"].ToString(),
               };
                courses.Add(course);
            }
        }

        ddlCoursesAdd.DataSource = courses;

        if (teacherCoursesIds != null && teacherCoursesIds.Count > 0 && courses != null && courses.Count > 0)
        {
            courses = courses.Where(c => teacherCoursesIds.Where(tc => tc == c.ID).ToList().Count > 0).ToList();
            ddlCoursesAdd.DataSource = courses;
        }
        else
            ddlCoursesAdd.DataSource = new DataTable();

        ddlCoursesAdd.DataTextField = "NAME";
        ddlCoursesAdd.DataValueField = "ID";
        ddlCoursesAdd.DataBind();
    }
}
