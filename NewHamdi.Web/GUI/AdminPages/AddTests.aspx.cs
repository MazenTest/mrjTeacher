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

public partial class GUI_AdminPages_AddTests : AdminBasePage
{
    #region [Events]

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSave.Click += new EventHandler(btnSave_Click);
        this.btnSearch.Click += new EventHandler(btnSearch_Click);
        this.ddlSpecialtySearch.SelectedIndexChanged += new EventHandler(ddlSpecialtySearch_SelectedIndexChanged);
        this.ddlCourseSearch.SelectedIndexChanged += new EventHandler(ddlCourseSearch_SelectedIndexChanged);
        this.ddlSpecialty.SelectedIndexChanged += new EventHandler(ddlSpecialty_SelectedIndexChanged);
        this.ddlCoursesAdd.SelectedIndexChanged += new EventHandler(ddlCoursesAdd_SelectedIndexChanged);
        base.OnInit(e);
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
        upnlAddTests.Update();
    }

    void ddlCourseSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseId = -1;
        if (int.TryParse(ddlCourseSearch.SelectedValue, out courseId))
            if (courseId > 0)
            {
                DataTable dtCourseLevels = BLL.GetCourseLevelsByCourseId(courseId);
                ddlCourseLevels.DataSource = dtCourseLevels;
                ddlCourseLevels.DataTextField = "LEVEL_NAME";
                ddlCourseLevels.DataValueField = "LEVEL_ID";
                ddlCourseLevels.DataBind();


            }
            else
            {
                ddlCourseLevels.DataSource = new DataTable();
                ddlCourseLevels.DataBind();
            }
        upnlSearchContents.Update();
    }

    void ddlSpecialtySearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        int specialtyId = -1;
        if (int.TryParse(ddlSpecialtySearch.SelectedValue, out specialtyId))
            if (specialtyId > 0)
            {
                FillSpecialtyCoursesForSearch(specialtyId);
            }
            else
            {
                ddlCourseSearch.DataSource = new DataTable();
                ddlCourseSearch.DataBind();
            }
        upnlSearchContents.Update();
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

        upnlAddTests.Update();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAcademicYears();
            FillSpecialties();
            upnlSearchContents.Update();

            ddlCoursesAdd.DataSource = new DataTable();
            ddlCoursesAdd.DataBind();
            ddlCourseLevelsAdd.DataSource = new DataTable();
            ddlCourseLevelsAdd.DataBind();

            upnlAddTests.Update();
        }
    }

    void btnSave_Click(object sender, EventArgs e)
    {
        MyComponent.Entities.Content content = new MyComponent.Entities.Content();
        content.FileName = TextFileName.Text;
        content.Semester = Convert.ToInt32(ddlSemester.SelectedValue);
        content.SpecialtyId = Convert.ToInt32(ddlSpecialty.SelectedValue);
        content.PublishDate = DateTime.Now;
        content.AcademicYear = ddlAcademicYear.SelectedValue;
        content.WriterId = Convert.ToInt32(Session["SecureAdminSite"]);
        content.Type = (int)MyComponent.Enums.ContentType.PreviousTests;

        bool fileSizePassed = true;

        if (FUpTest.PostedFile != null)
        {
            if (FUpTest.PostedFile != null)
            {
                int maxFileSize = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFileSize"].ToString());
                string extension = Path.GetExtension(FUpTest.PostedFile.FileName);
                string fileName = Guid.NewGuid().ToString() + extension;
                string path = Server.MapPath("~/Questions/");
                FUpTest.SaveAs(path + fileName);
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

    void btnSearch_Click(object sender, EventArgs e)
    {
        int academicYear = -1;
        int Specialty = -1;
        int semester = -1;
        string fileName = string.Empty;
        int courseId = -1;
        int levelId = -1;

        if (Convert.ToInt32(ddlAcademicYearSearch.SelectedValue) > 0)
            academicYear = Convert.ToInt32(ddlAcademicYearSearch.SelectedValue);

        if (Convert.ToInt32(ddlSpecialtySearch.SelectedValue) > 0)
            Specialty = Convert.ToInt32(ddlSpecialtySearch.SelectedValue);

        if (Convert.ToInt32(ddlSemesterSearch.SelectedValue) > 0)
            semester = Convert.ToInt32(ddlSemesterSearch.SelectedValue);

        if (!string.IsNullOrEmpty(txtFileNameSearch.Text))
            fileName = txtFileNameSearch.Text.Trim();

        if (!string.IsNullOrEmpty(ddlCourseSearch.SelectedValue))
            courseId = Convert.ToInt32(ddlCourseSearch.SelectedValue);

        if (!string.IsNullOrEmpty(ddlCourseLevels.SelectedValue))
            levelId = Convert.ToInt32(ddlCourseLevels.SelectedValue);


        DataTable dtContetns = BLL.SearchContents(
            academicYear, Specialty, semester, fileName, (int)MyComponent.Enums.ContentType.PreviousTests, courseId, levelId, -1);

        if (dtContetns != null && dtContetns.Rows.Count > 0)
            gvContents.DataSource = dtContetns;
        else
            gvContents.DataSource = new DataTable();

        gvContents.DataBind();
        upnlSearchContents.Update();
    }

    #endregion

    #region [Methods]

    //public string GetAcademicYearName()
    //{
    //    string name = string.Empty;
    //    if (ddlAcademicYearSearch.SelectedValue != "-1")
    //        name = ddlAcademicYearSearch.SelectedItem.Text;
    //    else
    //        name = "-";

    //    return name;
    //}

    //public string GetSemesterName()
    //{
    //    string name = string.Empty;
    //    if (ddlSemesterSearch.SelectedValue != "-1")
    //        name = ddlSemesterSearch.SelectedItem.Text;
    //    else
    //        name = "-";

    //    return name;
    //}

    //public string GetSpecialtyName()
    //{
    //    string name = string.Empty;
    //    if (ddlSpecialtySearch.SelectedValue != "-1")
    //        name = ddlSpecialtySearch.SelectedItem.Text;
    //    else
    //        name = "-";

    //    return name;
    //}

    private void FillAcademicYears()
    {
        DataTable dtAllAcademicYears = BLL.GetAllAcademicYears();
        ddlAcademicYearSearch.DataSource = dtAllAcademicYears;
        ddlAcademicYearSearch.DataTextField = "ACADEMIC_YEAR_NAME";
        ddlAcademicYearSearch.DataValueField = "ACADEMIC_YEAR_ID";
        ddlAcademicYearSearch.DataBind();

        ddlAcademicYear.DataSource = dtAllAcademicYears;
        ddlAcademicYear.DataTextField = "ACADEMIC_YEAR_NAME";
        ddlAcademicYear.DataValueField = "ACADEMIC_YEAR_ID";
        ddlAcademicYear.DataBind();
    }

    private void FillSpecialties()
    {
        DataTable dtAllSpecialties = BLL.GetAllSpecialties();
        ddlSpecialtySearch.DataSource = dtAllSpecialties;
        ddlSpecialtySearch.DataTextField = "SPECIALTY_NAME";
        ddlSpecialtySearch.DataValueField = "SPECIALTY_ID";
        ddlSpecialtySearch.DataBind();

        ddlSpecialty.DataSource = dtAllSpecialties;
        ddlSpecialty.DataTextField = "SPECIALTY_NAME";
        ddlSpecialty.DataValueField = "SPECIALTY_ID";
        ddlSpecialty.DataBind();
    }

    private void FillSpecialtyCoursesForSearch(int SpecialtyId)
    {
        ddlCourseSearch.DataSource = BLL.GetSpecialtyCoursesBySpecialtyId(SpecialtyId);
        ddlCourseSearch.DataTextField = "COURSE_NAME";
        ddlCourseSearch.DataValueField = "COURSE_ID";
        ddlCourseSearch.DataBind();
    }

    private void FillSpecialtyCourses(int SpecialtyId)
    {
        ddlCoursesAdd.DataSource = BLL.GetSpecialtyCoursesBySpecialtyId(SpecialtyId);
        ddlCoursesAdd.DataTextField = "COURSE_NAME";
        ddlCoursesAdd.DataValueField = "COURSE_ID";
        ddlCoursesAdd.DataBind();
    }
    #endregion

}
