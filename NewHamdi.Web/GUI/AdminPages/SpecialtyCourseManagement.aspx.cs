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

public partial class GUI_AdminPages_SpecialtyCourseManagement : AdminBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnAddCourse.Click += new EventHandler(btnAddCourse_Click);
        this.ddlAllSpecialties.SelectedIndexChanged += new EventHandler(ddlAllSpecialties_SelectedIndexChanged);
        this.btnDeleteCourse.Click += new EventHandler(btnDeleteCourse_Click);
        this.gvSpecialtyCourses.PageIndexChanging += new GridViewPageEventHandler(gvSpecialtyCourses_PageIndexChanging);
        this.gvCourses.PageIndexChanging += new GridViewPageEventHandler(gvCourses_PageIndexChanging);
        base.OnInit(e);
    }

    void gvCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCourses.PageIndex = e.NewPageIndex;
        FillAllCourses();
    }

    void gvSpecialtyCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSpecialtyCourses.PageIndex = e.NewPageIndex;
        FillSpecialtyCoursesGrid(Convert.ToInt32(ddlAllSpecialties.SelectedValue));
    }

    void btnDeleteCourse_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvSpecialtyCourses.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnCourseId = (HiddenField)row.FindControl("hdnCourseId");
                CheckBox cbSelectedCourse = (CheckBox)row.FindControl("cbSelect");
                if (hdnCourseId != null && (cbSelectedCourse != null && cbSelectedCourse.Checked))
                {
                    BLL.DeleteSpecialtyCourse(Convert.ToInt32(hdnCourseId.Value),
                        Convert.ToInt32(ddlAllSpecialties.SelectedValue));

                    SetAlert(operationMessage);
                }
            }
        }
        FillAllCourses();
        FillSpecialtyCoursesGrid(Convert.ToInt32(ddlAllSpecialties.SelectedValue));

    }

    void btnAddCourse_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvCourses.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnCourseId = (HiddenField)row.FindControl("hdnCourseId");
                CheckBox cbSelectedCourse = (CheckBox)row.FindControl("cbSelect");
                if (hdnCourseId != null && (cbSelectedCourse != null && cbSelectedCourse.Checked))
                {
                    BLL.AddSpecialtyCourse(Convert.ToInt32(hdnCourseId.Value),
                        Convert.ToInt32(ddlAllSpecialties.SelectedValue));

                    SetAlert(operationMessage);
                }
            }
        }
        FillAllCourses();
        FillSpecialtyCoursesGrid(Convert.ToInt32(ddlAllSpecialties.SelectedValue));
    }

    void ddlAllSpecialties_SelectedIndexChanged(object sender, EventArgs e)
    {
        int SpecialtyId = -1;
        if (int.TryParse(ddlAllSpecialties.SelectedValue, out SpecialtyId))
            if (SpecialtyId > 0)
            {
                FillAllCourses();
                FillSpecialtyCoursesGrid(SpecialtyId);
            }
            else
                pnlCourses.Visible = false;

        upnlCourses.Update();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSpecialties();
        }
    }

    private void FillSpecialties()
    {
        DataTable dtAllSpecialties = BLL.GetAllSpecialties();

        ddlAllSpecialties.DataSource = dtAllSpecialties;
        ddlAllSpecialties.DataTextField = "Specialty_NAME";
        ddlAllSpecialties.DataValueField = "Specialty_ID";
        ddlAllSpecialties.DataBind();
    }

    private void FillAllCourses()
    {
        DataTable dtSpecialtyCourses = null;
        DataTable dtAllCourses = BLL.GetAllCourses();
        int specialtyId = -1;
        if (int.TryParse(ddlAllSpecialties.SelectedValue, out specialtyId) && specialtyId > 0)
            dtSpecialtyCourses = BLL.GetSpecialtyCoursesBySpecialtyId(specialtyId);

        List<int> specialtyCourses = null;
        List<Course> courses = null;

        if (dtSpecialtyCourses != null && dtSpecialtyCourses.Rows.Count > 0)
            foreach (DataRow row in dtSpecialtyCourses.Rows)
            {
                if (specialtyCourses == null)
                    specialtyCourses = new List<int>();

                specialtyCourses.Add(Convert.ToInt32(row["Course_ID"]));
            }
        if (dtAllCourses != null && dtAllCourses.Rows.Count > 0)
            foreach (DataRow row in dtAllCourses.Rows)
            {
                if (courses == null)
                    courses = new List<Course>();

                courses.Add(new Course { ID = Convert.ToInt32(row["Course_ID"]), Name = row["Course_NAME"].ToString() });
            }

        if (specialtyCourses != null && courses != null)
            courses = courses.Where(l => !specialtyCourses.Contains(l.ID)).ToList();

        gvCourses.DataSource = courses;
        gvCourses.DataBind();



        //DataTable dtAllCourses = BLL.GetAllCourses();

        //gvCourses.DataSource = dtAllCourses;
        //gvCourses.DataBind();
    }

    private void FillSpecialtyCoursesGrid(int SpecialtyId)
    {
        gvSpecialtyCourses.DataSource = BLL.GetSpecialtyCoursesBySpecialtyId(SpecialtyId);
        gvSpecialtyCourses.DataBind();
        pnlCourses.Visible = true;
        upnlCourses.Update();
    }

}
