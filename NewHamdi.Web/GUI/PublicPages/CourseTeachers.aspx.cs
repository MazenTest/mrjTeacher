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
using System.Collections.Generic;
using System.IO;
using MyComponent.Entities;
using MyComponent.Business;

public partial class GUI_PublicPages_CourseTeachers : PublicBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        base.OnInit(e);
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCourseTeachers();

            string metaTags = "معلمو المواد المعلمين المعلمون السنوات الدراسية التخصصات التربية الاسلامية نظم المعلومات الرياضيات اللغة العربية اللغة الانجليزية الادبي العلمي التمريض برمجة الحاسوب";
            string description = "feedback@mrjteacher.com";
            AddMetaTagsAndPageDescription(metaTags, description);
        }
    }

    private void FillCourseTeachers()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Cid"]))
        {
            int courseId = -1;
            if (int.TryParse(Request.QueryString["Cid"], out courseId))
                if (courseId > 0)
                {
                    Course course = BLL.GetCourseById(courseId);
                    if (course != null)
                    {
                        lblCourseName.Text = "  معلمو مادة " + course.Name;
                        this.Title = "  معلمو مادة " + course.Name;
                    }

                    DataTable dtCourseTeachers = BLL.GetTeachersByCourseId(courseId);
                    if (dtCourseTeachers != null && dtCourseTeachers.Rows.Count > 0)
                    {
                        dlstTeachers.DataSource = dtCourseTeachers;
                        dlstTeachers.DataBind();
                    }
                    else
                    {
                        lblNoDataFound.Text = "لا يوجد معلمون لهذه المادة حالياً";
                        lblNoDataFound.ForeColor = System.Drawing.Color.Red;
                        lblNoDataFound.Visible = true;
                    }
                }
                else
                {
                    lblNoDataFound.Text = "لا يوجد معلمون لهذه المادة حالياً";
                    lblNoDataFound.ForeColor = System.Drawing.Color.Red;
                    lblNoDataFound.Visible = true;
                }
        }
        else
        {
            lblNoDataFound.Text = "لا يوجد معلمون لهذه المادة حالياً";
            lblNoDataFound.ForeColor = System.Drawing.Color.Red;
            lblNoDataFound.Visible = true;
        }
    }
}
