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
using System.Collections.Generic;
using MyComponent.Enums;

public partial class GUI_AdminPages_CourseTeacherManagement : AdminBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnAddTeacher.Click += new EventHandler(btnAddTeacher_Click);
        this.ddlAllCourses.SelectedIndexChanged += new EventHandler(ddlAllCourses_SelectedIndexChanged);
        this.btnDeleteTeacher.Click += new EventHandler(btnDeleteTeacher_Click);
        this.gvCourseTeachers.PageIndexChanging += new GridViewPageEventHandler(gvCourseTeachers_PageIndexChanging);
        this.gvTeachers.PageIndexChanging += new GridViewPageEventHandler(gvTeachers_PageIndexChanging);
        base.OnInit(e);
    }

    void gvTeachers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTeachers.PageIndex = e.NewPageIndex;
        FillAllTeachers();
    }

    void gvCourseTeachers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCourseTeachers.PageIndex = e.NewPageIndex;
        FillCourseTeachersGrid(Convert.ToInt32(ddlAllCourses.SelectedValue));
    }

    void btnDeleteTeacher_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvCourseTeachers.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnTeacherId = (HiddenField)row.FindControl("hdnTeacherId");
                CheckBox cbSelectedTeacher = (CheckBox)row.FindControl("cbSelect");
                if (hdnTeacherId != null && (cbSelectedTeacher != null && cbSelectedTeacher.Checked))
                {
                    BLL.DeleteTeacherCourse(Convert.ToInt32(ddlAllCourses.SelectedValue),
                        Convert.ToInt32(hdnTeacherId.Value));

                    SetAlert(operationMessage);
                }
            }
        }
        FillAllTeachers();
        FillCourseTeachersGrid(Convert.ToInt32(ddlAllCourses.SelectedValue));

    }

    void btnAddTeacher_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvTeachers.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnTeacherId = (HiddenField)row.FindControl("hdnTeacherId");
                CheckBox cbSelectedTeacher = (CheckBox)row.FindControl("cbSelect");
                if (hdnTeacherId != null && (cbSelectedTeacher != null && cbSelectedTeacher.Checked))
                {
                    BLL.AddTeacherCourse(Convert.ToInt32(ddlAllCourses.SelectedValue),
                        Convert.ToInt32(hdnTeacherId.Value));

                    SetAlert(operationMessage);
                }
            }
        }
        FillAllTeachers();
        FillCourseTeachersGrid(Convert.ToInt32(ddlAllCourses.SelectedValue));
    }

    void ddlAllCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseId = -1;
        if (int.TryParse(ddlAllCourses.SelectedValue, out courseId))
            if (courseId > 0)
            {
                FillAllTeachers();
                FillCourseTeachersGrid(courseId);
            }
            else
                pnlCourseTeachers.Visible = false;

        upnCourselTeachers.Update();
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

        ddlAllCourses.DataSource = dtAllCourses;
        ddlAllCourses.DataTextField = "COURSE_NAME";
        ddlAllCourses.DataValueField = "COURSE_ID";
        ddlAllCourses.DataBind();
    }

    private void FillAllTeachers()
    {
        DataTable dtCourseTeachers = null;
        DataTable dtAllTeachers = BLL.GetUsersByRoleId((int)UserRoles.Teacher);
        int courseId = -1;
        if (int.TryParse(ddlAllCourses.SelectedValue, out courseId) && courseId > 0)
            dtCourseTeachers = BLL.GetTeachersByCourseId(courseId);

        List<int> courseTeachers = null;
        List<User> Teachers = null;

        if (dtCourseTeachers != null && dtCourseTeachers.Rows.Count > 0)
            foreach (DataRow row in dtCourseTeachers.Rows)
            {
                if (courseTeachers == null)
                    courseTeachers = new List<int>();

                courseTeachers.Add(Convert.ToInt32(row["TEACHER_ID"]));
            }
        if (dtAllTeachers != null && dtAllTeachers.Rows.Count > 0)
            foreach (DataRow row in dtAllTeachers.Rows)
            {
                if (Teachers == null)
                    Teachers = new List<User>();

                Teachers.Add(new User { ID = Convert.ToInt32(row["User_ID"]), FirstName = row["FIRST_NAME"].ToString() + " " + row["LAST_NAME"].ToString() });
            }

        if (courseTeachers != null && Teachers != null)
            Teachers = Teachers.Where(l => !courseTeachers.Contains(l.ID)).ToList();

        gvTeachers.DataSource = Teachers;
        gvTeachers.DataBind();
    }

    private void FillCourseTeachersGrid(int courseId)
    {
        gvCourseTeachers.DataSource = BLL.GetTeachersByCourseId(courseId);
        gvCourseTeachers.DataBind();
        pnlCourseTeachers.Visible = true;
        upnCourselTeachers.Update();
    }

}
