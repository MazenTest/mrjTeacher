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

public partial class GUI_AdminPages_SpecialtiesManagement : AdminBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSave.Click += new EventHandler(btnSave_Click);
        this.ddlAllSpecialties.SelectedIndexChanged += new EventHandler(ddlAllSpecialties_SelectedIndexChanged);
        this.btnUpdateSpecialty.Click += new EventHandler(btnUpdateSpecialty_Click);
        base.OnInit(e);
    }

    void btnUpdateSpecialty_Click(object sender, EventArgs e)
    {
        try
        {
            int specialtyId = -1;
            if (int.TryParse(ddlAllSpecialties.SelectedValue, out specialtyId))
                if (specialtyId > 0)
                {
                    Specialty specialty = BLL.GetSpecialtyById(specialtyId);
                    if (specialty != null)
                    {
                        specialty.Name = txtSpecialtyNameUpdate.Text;

                        BLL.UpdateSpecialty(specialty);

                        ResetUpdateControls();

                        upnlUpdateSpecialty.Update();
                        FillSpecialties();
                        upnlSpecialties.Update();
                        SetAlert(operationMessage);
                    }
                }
        }
        catch (Exception ex)
        {
            ErrorLogger.WriteError(ex);
        }
    }

    void ddlAllSpecialties_SelectedIndexChanged(object sender, EventArgs e)
    {
        int specialtyId = -1;
        if (int.TryParse(ddlAllSpecialties.SelectedValue, out specialtyId))
            if (specialtyId > 0)
            {
                Specialty specialty = BLL.GetSpecialtyById(specialtyId);
                if (specialty != null)
                {
                    txtSpecialtyNameUpdate.Text = specialty.Name;
                    trSpecialtyInfo.Visible = true;
                    btnUpdateSpecialty.Visible = true;

                    upnlUpdateSpecialty.Update();
                }
            }
    }

    void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Specialty specialty = new Specialty
            {
                Name = txtSpecialtyName.Text
            };

            BLL.AddSpecialty(specialty);
            FillSpecialties();
            ResetControls();
            upnlAddSpecialties.Update();
            upnlSpecialties.Update();

            upnlUpdateSpecialty.Update();

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
            FillSpecialties();
        }
    }

    private void FillSpecialties()
    {
        DataTable dtAllSpecialties = BLL.GetAllSpecialties();
        gvSpecialties.DataSource = dtAllSpecialties;
        gvSpecialties.DataBind();

        ddlAllSpecialties.DataSource = dtAllSpecialties;
        ddlAllSpecialties.DataTextField = "SPECIALTY_NAME";
        ddlAllSpecialties.DataValueField = "SPECIALTY_ID";
        ddlAllSpecialties.DataBind();
    }

    private void ResetControls()
    {
        txtSpecialtyName.Text = string.Empty;
    }

    private void ResetUpdateControls()
    {
        txtSpecialtyNameUpdate.Text = string.Empty;
        trSpecialtyInfo.Visible = false;
        btnUpdateSpecialty.Visible = false;
    }
}
