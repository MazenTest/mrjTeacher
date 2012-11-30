using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using MyComponent.Business;
using MyComponent.Entities;
using System.Web.UI.HtmlControls;

public partial class SearchContents : PublicBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSearch.Click += new EventHandler(btnSearch_Click);
        this.gvContents.PageIndexChanging += new GridViewPageEventHandler(gvContents_PageIndexChanging);
        this.ddlSpecialtySearch.SelectedIndexChanged += new EventHandler(ddlSpecialtySearch_SelectedIndexChanged);
        this.ddlCourseSearch.SelectedIndexChanged += new EventHandler(ddlCourseSearch_SelectedIndexChanged);
        this.ddlSpecialtyQuestionsSearch.SelectedIndexChanged += new EventHandler(ddlSpecialtyQuestionsSearch_SelectedIndexChanged);
        this.ddlCourseQuestionsSearch.SelectedIndexChanged += new EventHandler(ddlCourseQuestionsSearch_SelectedIndexChanged);
        this.btnSearchQuestions.Click += new EventHandler(btnSearchQuestions_Click);
        this.gvPreviousQuestions.PageIndexChanging += new GridViewPageEventHandler(gvPreviousQuestions_PageIndexChanging);
        base.OnInit(e);
    }

    void gvPreviousQuestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPreviousQuestions.PageIndex = e.NewPageIndex;
        SearchPreviousQuestions();
        upnlSearchPreviousQuestions.Update();
    }

    void btnSearchQuestions_Click(object sender, EventArgs e)
    {
        SearchPreviousQuestions();
        upnlSearchPreviousQuestions.Update();
    }

    void ddlCourseQuestionsSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseId = -1;
        if (int.TryParse(ddlCourseQuestionsSearch.SelectedValue, out courseId))
            if (courseId > 0)
            {
                DataTable dtCourseLevels = BLL.GetCourseLevelsByCourseId(courseId);
                ddlCourseQuestionsLevels.DataSource = dtCourseLevels;
                ddlCourseQuestionsLevels.DataTextField = "LEVEL_NAME";
                ddlCourseQuestionsLevels.DataValueField = "LEVEL_ID";
                ddlCourseQuestionsLevels.DataBind();
            }
            else
            {
                ddlCourseQuestionsLevels.DataSource = new DataTable();
                ddlCourseQuestionsLevels.DataSource = new DataTable();

                upnlSearchPreviousQuestions.Update();
            }
    }

    void ddlSpecialtyQuestionsSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        int specialtyId = -1;
        if (int.TryParse(ddlSpecialtyQuestionsSearch.SelectedValue, out specialtyId))
            if (specialtyId > 0)
            {
                FillSpecialtyCoursesForQuestions(specialtyId);
            }
            else
                ddlCourseQuestionsSearch.DataSource = new DataTable();

        ddlCourseQuestionsSearch.DataBind();

        upnlSearchPreviousQuestions.Update();
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

                DataTable dtCourseTeachers = BLL.GetTeachersByCourseId(courseId);
                ddlCourseTeachers.DataSource = dtCourseTeachers;
                ddlCourseTeachers.DataTextField = "TEACHER_NAME";
                ddlCourseTeachers.DataValueField = "TEACHER_ID";
                ddlCourseTeachers.Items.Add(new ListItem("الكل", "-1"));
                ddlCourseTeachers.DataBind();
                ddlCourseTeachers.Items.Add(new ListItem("الكل", "-1"));
            }
            else
            {
                ddlCourseLevels.DataSource = new DataTable();
                ddlCourseLevels.DataBind();

                ddlCourseTeachers.DataSource = new DataTable();
                ddlCourseTeachers.DataBind();
            }
        upnlSearchContents.Update();
    }

    void ddlSpecialtySearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        int specialtyId = -1;
        if (int.TryParse(ddlSpecialtySearch.SelectedValue, out specialtyId))
            if (specialtyId > 0)
            {
                FillSpecialtyCourses(specialtyId);
            }
            else
                ddlCourseSearch.DataSource = new DataTable();

        ddlCourseSearch.DataBind();

        upnlSearchContents.Update();
    }

    void gvContents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvContents.PageIndex = e.NewPageIndex;
        SearchSelectedContents();
        upnlSearchContents.Update();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAcademicYearsForQuestions();

            FillSpecialties();
            FillSpecialtiesForQuestions();

            ddlCourseSearch.DataSource = new DataTable();
            ddlCourseSearch.DataBind();

            ddlCourseQuestionsSearch.DataSource = new DataTable();
            ddlCourseQuestionsSearch.DataBind();

            ddlCourseLevels.DataSource = new DataTable();
            ddlCourseLevels.DataBind();

            ddlCourseQuestionsLevels.DataSource = new DataTable();
            ddlCourseQuestionsLevels.DataBind();

            ddlCourseTeachers.DataSource = new DataTable();
            ddlCourseTeachers.DataBind();

            string metaTags = " المعلم الاردني معلمو المواد المعلمين المعلمون السنوات الدراسية التخصصات التربية الاسلامية نظم المعلومات الرياضيات اللغة العربية اللغة الانجليزية الادبي العلمي التمريض برمجة الحاسوب الاخبار الأخبار التعليمية المواقع المفيدة";
            string description = "feedback@mrjteacher.com";
            AddMetaTagsAndPageDescription(metaTags, description);

            ddlCourseTeachers.Attributes.Add("onChange", "return RedirectToTeacherProfile();");
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchSelectedContents();
        upnlSearchContents.Update();
    }

    private void SearchSelectedContents()
    {
        int academicYear = -1;
        int specialty = -1;
        int semester = -1;
        string fileName = string.Empty;
        int courseId = -1;
        int levelId = -1;
        int teacherId = -1;
        int fileType = -1;

        if (Convert.ToInt32(ddlSpecialtySearch.SelectedValue) > 0)
            specialty = Convert.ToInt32(ddlSpecialtySearch.SelectedValue);

        if (!string.IsNullOrEmpty(ddlCourseSearch.SelectedValue))
            courseId = Convert.ToInt32(ddlCourseSearch.SelectedValue);

        if (!string.IsNullOrEmpty(ddlCourseLevels.SelectedValue))
            levelId = Convert.ToInt32(ddlCourseLevels.SelectedValue);

        if (!string.IsNullOrEmpty(ddlCourseTeachers.SelectedValue))
            teacherId = Convert.ToInt32(ddlCourseTeachers.SelectedValue);

        if (!string.IsNullOrEmpty(ddlContentTypes.SelectedValue))
            fileType = Convert.ToInt32(ddlContentTypes.SelectedValue);

        DataTable dtContetns = BLL.SearchContents(
            academicYear, specialty, semester, fileName, fileType, courseId, levelId, teacherId);

        if (dtContetns != null && dtContetns.Rows.Count > 0)
            gvContents.DataSource = dtContetns;
        else
            gvContents.DataSource = new DataTable();

        gvContents.DataBind();
    }

    private void FillSpecialties()
    {
        DataTable dtAllSpecialties = BLL.GetAllSpecialties();

        ddlSpecialtySearch.DataSource = dtAllSpecialties;
        ddlSpecialtySearch.DataTextField = "SPECIALTY_NAME";
        ddlSpecialtySearch.DataValueField = "SPECIALTY_ID";
        ddlSpecialtySearch.DataBind();
    }

    private void FillSpecialtyCourses(int SpecialtyId)
    {
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

        ddlCourseSearch.DataSource = courses;

        if (courses != null && courses.Count > 0)
            ddlCourseSearch.DataSource = courses;
        else
            ddlCourseSearch.DataSource = new DataTable();

        ddlCourseSearch.DataTextField = "NAME";
        ddlCourseSearch.DataValueField = "ID";
        ddlCourseSearch.DataBind();
    }

    private void FillAcademicYearsForQuestions()
    {
        DataTable dtAllAcademicYears = BLL.GetAllAcademicYears();

        ddlAcademicYearSearchQuestions.DataSource = dtAllAcademicYears;
        ddlAcademicYearSearchQuestions.DataTextField = "ACADEMIC_YEAR_NAME";
        ddlAcademicYearSearchQuestions.DataValueField = "ACADEMIC_YEAR_ID";
        ddlAcademicYearSearchQuestions.DataBind();
    }

    private void FillSpecialtiesForQuestions()
    {
        DataTable dtAllSpecialties = BLL.GetAllSpecialties();

        ddlSpecialtyQuestionsSearch.DataSource = dtAllSpecialties;
        ddlSpecialtyQuestionsSearch.DataTextField = "SPECIALTY_NAME";
        ddlSpecialtyQuestionsSearch.DataValueField = "SPECIALTY_ID";
        ddlSpecialtyQuestionsSearch.DataBind();
    }


    private void FillSpecialtyCoursesForQuestions(int SpecialtyId)
    {
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

        // ddlCourseQuestionsSearch.DataSource = courses;

        if (courses != null && courses.Count > 0)
            ddlCourseQuestionsSearch.DataSource = courses;
        else
            ddlCourseQuestionsSearch.DataSource = new DataTable();

        ddlCourseQuestionsSearch.DataTextField = "NAME";
        ddlCourseQuestionsSearch.DataValueField = "ID";
        ddlCourseQuestionsSearch.DataBind();
    }

    private void SearchPreviousQuestions()
    {
        int academicYear = -1;
        int specialty = -1;
        int semester = -1;
        string fileName = string.Empty;
        int courseId = -1;
        int levelId = -1;
        int teacherId = -1;
        int fileType = (int)MyComponent.Enums.ContentType.PreviousTests;

        if (Convert.ToInt32(ddlAcademicYearSearchQuestions.SelectedValue) > 0)
            academicYear = Convert.ToInt32(ddlAcademicYearSearchQuestions.SelectedValue);

        if (Convert.ToInt32(ddlSpecialtyQuestionsSearch.SelectedValue) > 0)
            specialty = Convert.ToInt32(ddlSpecialtyQuestionsSearch.SelectedValue);

        if (!string.IsNullOrEmpty(ddlCourseQuestionsSearch.SelectedValue))
            courseId = Convert.ToInt32(ddlCourseQuestionsSearch.SelectedValue);

        if (!string.IsNullOrEmpty(ddlCourseQuestionsLevels.SelectedValue))
            levelId = Convert.ToInt32(ddlCourseQuestionsLevels.SelectedValue);

        if (!string.IsNullOrEmpty(ddlSemesterSearchQuestions.SelectedValue))
            semester = Convert.ToInt32(ddlSemesterSearchQuestions.SelectedValue);


        DataTable dtQuestions = BLL.SearchContents(
            academicYear, specialty, semester, fileName, fileType, courseId, levelId, teacherId);

        if (dtQuestions != null && dtQuestions.Rows.Count > 0)
            gvPreviousQuestions.DataSource = dtQuestions;
        else
            gvPreviousQuestions.DataSource = new DataTable();

        gvPreviousQuestions.DataBind();
    }
}
