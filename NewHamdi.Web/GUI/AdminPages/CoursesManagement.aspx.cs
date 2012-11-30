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
using MyComponent.Business;
using MyComponent.Entities;

public partial class GUI_AdminPages_CoursesManagement : AdminBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSave.Click += new EventHandler(btnSave_Click);
        this.ddlAllCourses.SelectedIndexChanged += new EventHandler(ddlAllCourses_SelectedIndexChanged);
        this.btnUpdateCourse.Click += new EventHandler(btnUpdateCourse_Click);
        this.ibtnDeleteCourse.Click += new ImageClickEventHandler(ibtnDeleteCourse_Click);
        base.OnInit(e);
    }

    void ibtnDeleteCourse_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gvCourses.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnCourseId = (HiddenField)row.FindControl("hdnCourseId");
                    CheckBox cbSelectedCourse = (CheckBox)row.FindControl("cbSelect");
                    if (hdnCourseId != null && (cbSelectedCourse != null && cbSelectedCourse.Checked))
                    {
                        BLL.DeleteCourse(Convert.ToInt32(hdnCourseId.Value));
                        SetAlert(operationMessage);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            SetAlert("يجب فصل المادة عن المستويات و المعلمين قبل عملية الحذف");
        }
        FillCourses();
    }

    void btnUpdateCourse_Click(object sender, EventArgs e)
    {
        try
        {
            int CourseId = -1;
            if (int.TryParse(ddlAllCourses.SelectedValue, out CourseId))
                if (CourseId > 0)
                {
                    Course Course = BLL.GetCourseById(CourseId);
                    if (Course != null)
                    {
                        Course.Name = txtCourseNameUpdate.Text;

                        BLL.UpdateCourse(Course);

                        ResetUpdateControls();

                        upnlUpdateCourse.Update();
                        FillCourses();
                        upnlCourses.Update();
                        SetAlert(operationMessage);
                    }
                }
        }
        catch (Exception ex)
        {
            ErrorLogger.WriteError(ex);
        }
    }

    void ddlAllCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        int CourseId = -1;
        if (int.TryParse(ddlAllCourses.SelectedValue, out CourseId))
            if (CourseId > 0)
            {
                Course Course = BLL.GetCourseById(CourseId);
                if (Course != null)
                {
                    txtCourseNameUpdate.Text = Course.Name;
                    trCourseInfo.Visible = true;
                    btnUpdateCourse.Visible = true;

                    upnlUpdateCourse.Update();
                }
            }
    }

    void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Course Course = new Course
            {
                Name = txtCourseName.Text
            };

            BLL.AddCourse(Course);
            FillCourses();
            ResetControls();
            upnlAddCourses.Update();
            upnlCourses.Update();

            upnlUpdateCourse.Update();

            SetAlert(operationMessage);
        }
        catch (Exception ex)
        {
            ErrorLogger.WriteError(ex);
        }
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCourses();
        }
    }

    private void FillCourses()
    {
        DataTable dtAllCourses = BLL.GetAllCourses();
        gvCourses.DataSource = dtAllCourses;
        gvCourses.DataBind();

        ddlAllCourses.DataSource = dtAllCourses;
        ddlAllCourses.DataTextField = "Course_NAME";
        ddlAllCourses.DataValueField = "Course_ID";
        ddlAllCourses.DataBind();
    }

    private void ResetControls()
    {
        txtCourseName.Text = string.Empty;
    }

    private void ResetUpdateControls()
    {
        txtCourseNameUpdate.Text = string.Empty;
        trCourseInfo.Visible = false;
        btnUpdateCourse.Visible = false;
    }
}
