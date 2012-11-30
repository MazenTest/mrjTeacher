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

public partial class GUI_PublicPages_TeachersLists : PublicBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.rptSpecialties.ItemDataBound += new RepeaterItemEventHandler(rptSpecialties_ItemDataBound);
        this.rptSpecialties.ItemCreated += new RepeaterItemEventHandler(rptSpecialties_ItemCreated);
        base.OnInit(e);
    }

    void rptSpecialties_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptSpecialtyCourses = (Repeater)e.Item.FindControl("rptSpecialtyCourses");
            if (rptSpecialtyCourses != null)
            {
                rptSpecialtyCourses.ItemDataBound += new RepeaterItemEventHandler(rptSpecialtyCourses_ItemDataBound);
            }
        }
    }

    void rptSpecialties_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hdnSpecialtyId = (HiddenField)e.Item.FindControl("hdnSpecialtyId");
            Repeater rptSpecialtyCourses = (Repeater)e.Item.FindControl("rptSpecialtyCourses");
            if (rptSpecialtyCourses != null)
            {
                DataTable dtSpecialtyCourses = BLL.GetSpecialtyCoursesBySpecialtyId(Convert.ToInt32(hdnSpecialtyId.Value));
                rptSpecialtyCourses.DataSource = dtSpecialtyCourses;
                rptSpecialtyCourses.DataBind();
            }
        }
    }

    void rptSpecialtyCourses_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hdnCourseId = (HiddenField)e.Item.FindControl("hdnCourseId");
            DataList dlstTeachers = (DataList)e.Item.FindControl("dlstTeachers");
            if (dlstTeachers != null)
            {
                DataTable dtCourseTeachers = BLL.GetTeachersByCourseId(Convert.ToInt32(hdnCourseId.Value));
                if (dtCourseTeachers != null && dtCourseTeachers.Rows.Count > 0)
                {
                    dlstTeachers.DataSource = dtCourseTeachers;
                    dlstTeachers.DataBind();
                }
                else
                {
                    Label lblNoDataFound = (Label)e.Item.FindControl("lblNoDataFound");
                    if (lblNoDataFound != null)
                    {
                        lblNoDataFound.Text = "لا يوجد معلمون لهذه المادة حالياً";
                        lblNoDataFound.Visible = true;
                    }
                }
            }
        }
    }


    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtAllspecialties = BLL.GetAllSpecialties();
            if (dtAllspecialties != null && dtAllspecialties.Rows.Count > 0)
                rptSpecialties.DataSource = dtAllspecialties;
            else
                rptSpecialties.DataSource = new DataTable();

            rptSpecialties.DataBind();

            string metaTags = "  اسئلة أسئلة السنوات السابقة الدوسيات اوراق أوراق العمل الكتب الطلاب  المعلم الاردني معلمو المواد المعلمين المعلمون السنوات الدراسية التخصصات التربية الاسلامية نظم المعلومات الرياضيات اللغة العربية اللغة الانجليزية الادبي العلمي التمريض برمجة الحاسوب الاخبار الأخبار التعليمية المواقع المفيدة";
            string description = "feedback@mrjteacher.com";
            AddMetaTagsAndPageDescription(metaTags, description);

        }
    }
}
