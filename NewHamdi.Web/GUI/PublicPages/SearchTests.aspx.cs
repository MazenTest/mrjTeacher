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

public partial class SearchTests : PublicBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSearch.Click += new EventHandler(btnSearch_Click);
        this.gvContents.PageIndexChanging += new GridViewPageEventHandler(gvContents_PageIndexChanging);
        base.OnInit(e);
    }

    void gvContents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvContents.PageIndex = e.NewPageIndex;
        SearchSelectedTest();
        upnlSearchContents.Update();
    }
    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string metaTags = "  اسئلة أسئلة السنوات السابقة الدوسيات اوراق أوراق العمل الكتب الطلاب  المعلم الاردني معلمو المواد المعلمين المعلمون السنوات الدراسية التخصصات التربية الاسلامية نظم المعلومات الرياضيات اللغة العربية اللغة الانجليزية الادبي العلمي التمريض برمجة الحاسوب الاخبار الأخبار التعليمية المواقع المفيدة";
            string description = "feedback@mrjteacher.com";
            AddMetaTagsAndPageDescription(metaTags, description);
        }
    }

    void btnSearch_Click(object sender, EventArgs e)
    {
        SearchSelectedTest();
        upnlSearchContents.Update();
    }

    private void SearchSelectedTest()
    {
        int academicYear = -1;
        int Specialty = -1;
        int semester = -1;
        string fileName = string.Empty;

        if (Convert.ToInt32(ddlAcademicYearSearch.SelectedValue) > 0)
            academicYear = Convert.ToInt32(ddlAcademicYearSearch.SelectedValue);

        if (Convert.ToInt32(ddlSpecialtySearch.SelectedValue) > 0)
            Specialty = Convert.ToInt32(ddlSpecialtySearch.SelectedValue);

        if (Convert.ToInt32(ddlSemesterSearch.SelectedValue) > 0)
            semester = Convert.ToInt32(ddlSemesterSearch.SelectedValue);

        if (!string.IsNullOrEmpty(txtFileNameSearch.Text))
            fileName = txtFileNameSearch.Text.Trim();

        DataTable dtContetns = BLL.SearchContents(
            academicYear, Specialty, semester, fileName, (int)MyComponent.Enums.ContentType.PreviousTests, -1, -1, -1);

        if (dtContetns != null && dtContetns.Rows.Count > 0)
            gvContents.DataSource = dtContetns;
        else
            gvContents.DataSource = new DataTable();

        gvContents.DataBind();
    }

    public string GetAcademicYearName()
    {
        string name = string.Empty;
        if (ddlAcademicYearSearch.SelectedValue != "-1")
            name = ddlAcademicYearSearch.SelectedItem.Text;
        else
            name = "-";

        return name;
    }

    public string GetSemesterName()
    {
        string name = string.Empty;
        if (ddlSemesterSearch.SelectedValue != "-1")
            name = ddlSemesterSearch.SelectedItem.Text;
        else
            name = "-";

        return name;
    }

    public string GetSpecialtyName()
    {
        string name = string.Empty;
        if (ddlSpecialtySearch.SelectedValue != "-1")
            name = ddlSpecialtySearch.SelectedItem.Text;
        else
            name = "-";

        return name;
    }


}
