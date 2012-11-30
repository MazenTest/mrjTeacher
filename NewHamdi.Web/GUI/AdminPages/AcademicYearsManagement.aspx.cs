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

public partial class GUI_AdminPages_AcademicYearsManagement : AdminBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSave.Click += new EventHandler(btnSave_Click);

        base.OnInit(e);
    }

    void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            AcademicYear academicYear = new AcademicYear
            {
                Name = txtAcademiYearName.Text
            };

            BLL.AddAcademicYear(academicYear);
            FillAcademicYears();
            ResetControls();

            upnlAcademicYears.Update();
            upnlAddAcademicYear.Update();

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
            FillAcademicYears();
        }
    }

    private void FillAcademicYears()
    {
        DataTable dtAllAcademisYears = BLL.GetAllAcademicYears();
        gvAcademicYears.DataSource = dtAllAcademisYears;
        gvAcademicYears.DataBind();
    }

    private void ResetControls()
    {
        txtAcademiYearName.Text = string.Empty;
    }

}
