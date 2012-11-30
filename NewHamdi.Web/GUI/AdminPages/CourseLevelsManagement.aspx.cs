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

public partial class GUI_AdminPages_CourseLevelsManagement : AdminBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnAddLevel.Click += new EventHandler(btnAddLevel_Click);
        this.ddlAllCourses.SelectedIndexChanged += new EventHandler(ddlAllCourses_SelectedIndexChanged);
        this.btnDeleteLevel.Click += new EventHandler(btnDeleteLevel_Click);
        this.gvCourseLevels.PageIndexChanging += new GridViewPageEventHandler(gvCourseLevels_PageIndexChanging);
        this.gvLevels.PageIndexChanging += new GridViewPageEventHandler(gvLevels_PageIndexChanging);
        base.OnInit(e);
    }

    void gvLevels_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLevels.PageIndex = e.NewPageIndex;
        FillAllLevels();
    }

    void gvCourseLevels_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCourseLevels.PageIndex = e.NewPageIndex;
        FillCourseLevelsGrid(Convert.ToInt32(ddlAllCourses.SelectedValue));
    }

    void btnDeleteLevel_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvCourseLevels.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnLevelId = (HiddenField)row.FindControl("hdnLevelId");
                CheckBox cbSelectedLevel = (CheckBox)row.FindControl("cbSelect");
                if (hdnLevelId != null && (cbSelectedLevel != null && cbSelectedLevel.Checked))
                {
                    BLL.DeleteCourseLevel(Convert.ToInt32(ddlAllCourses.SelectedValue),
                        Convert.ToInt32(hdnLevelId.Value));

                    SetAlert(operationMessage);
                }
            }
        }
        FillAllLevels();
        FillCourseLevelsGrid(Convert.ToInt32(ddlAllCourses.SelectedValue));

    }

    void btnAddLevel_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvLevels.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnLevelId = (HiddenField)row.FindControl("hdnLevelId");
                CheckBox cbSelectedLevel = (CheckBox)row.FindControl("cbSelect");
                if (hdnLevelId != null && (cbSelectedLevel != null && cbSelectedLevel.Checked))
                {
                    BLL.AddCourseLevel(Convert.ToInt32(ddlAllCourses.SelectedValue),
                        Convert.ToInt32(hdnLevelId.Value));

                    SetAlert(operationMessage);
                }
            }
        }
        FillAllLevels();
        FillCourseLevelsGrid(Convert.ToInt32(ddlAllCourses.SelectedValue));
    }

    void ddlAllCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseId = -1;
        if (int.TryParse(ddlAllCourses.SelectedValue, out courseId))
            if (courseId > 0)
            {
                FillAllLevels();
                FillCourseLevelsGrid(courseId);
            }
            else
                pnlCourseLevels.Visible = false;

        upnCourselLevels.Update();
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

    private void FillAllLevels()
    {
        DataTable dtCourseLevels = null;
        DataTable dtAllLevels = BLL.GetAllLevels();
        int courseId = -1;
        if (int.TryParse(ddlAllCourses.SelectedValue, out courseId) && courseId > 0)
            dtCourseLevels = BLL.GetCourseLevelsByCourseId(courseId);

        List<int> courseLevels = null;
        List<Level> levels = null;

        if (dtCourseLevels != null && dtCourseLevels.Rows.Count > 0)
            foreach (DataRow row in dtCourseLevels.Rows)
            {
                if (courseLevels == null)
                    courseLevels = new List<int>();

                courseLevels.Add(Convert.ToInt32(row["LEVEL_ID"]));
            }
        if (dtAllLevels != null && dtAllLevels.Rows.Count > 0)
            foreach (DataRow row in dtAllLevels.Rows)
            {
                if (levels == null)
                    levels = new List<Level>();

                levels.Add(new Level { ID = Convert.ToInt32(row["LEVEL_ID"]), Name = row["LEVEL_NAME"].ToString() });
            }

        if (courseLevels != null && levels != null)
            levels = levels.Where(l => !courseLevels.Contains(l.ID)).ToList();

        gvLevels.DataSource = levels;
        gvLevels.DataBind();
    }

    private void FillCourseLevelsGrid(int courseId)
    {
        gvCourseLevels.DataSource = BLL.GetCourseLevelsByCourseId(courseId);
        gvCourseLevels.DataBind();
        pnlCourseLevels.Visible = true;
        upnCourselLevels.Update();
    }

}
