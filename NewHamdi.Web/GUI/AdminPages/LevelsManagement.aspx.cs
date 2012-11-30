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

public partial class GUI_AdminPages_LevelsManagement : AdminBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSave.Click += new EventHandler(btnSave_Click);
        this.ddlAllLevels.SelectedIndexChanged += new EventHandler(ddlAllLevels_SelectedIndexChanged);
        this.btnUpdateLevel.Click += new EventHandler(btnUpdateLevel_Click);
        base.OnInit(e);
    }

    void btnUpdateLevel_Click(object sender, EventArgs e)
    {
        try
        {
            int LevelId = -1;
            if (int.TryParse(ddlAllLevels.SelectedValue, out LevelId))
                if (LevelId > 0)
                {
                    Level Level = BLL.GetLevelById(LevelId);
                    if (Level != null)
                    {
                        Level.Name = txtLevelNameUpdate.Text;

                        BLL.UpdateLevel(Level);

                        ResetUpdateControls();

                        upnlUpdateLevel.Update();
                        FillLevels();
                        upnlLevels.Update();
                        SetAlert(operationMessage);
                    }
                }
        }
        catch (Exception ex)
        {
            ErrorLogger.WriteError(ex);
        }
    }

    void ddlAllLevels_SelectedIndexChanged(object sender, EventArgs e)
    {
        int LevelId = -1;
        if (int.TryParse(ddlAllLevels.SelectedValue, out LevelId))
            if (LevelId > 0)
            {
                Level Level = BLL.GetLevelById(LevelId);
                if (Level != null)
                {
                    txtLevelNameUpdate.Text = Level.Name;
                    trLevelInfo.Visible = true;
                    btnUpdateLevel.Visible = true;

                    upnlUpdateLevel.Update();
                }
            }
    }

    void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Level Level = new Level
            {
                Name = txtLevelName.Text
            };

            BLL.AddLevel(Level);
            FillLevels();
            ResetControls();
            upnlAddLevels.Update();
            upnlLevels.Update();

            upnlUpdateLevel.Update();

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
            FillLevels();
        }
    }

    private void FillLevels()
    {
        DataTable dtAllLevels = BLL.GetAllLevels();
        gvLevels.DataSource = dtAllLevels;
        gvLevels.DataBind();

        ddlAllLevels.DataSource = dtAllLevels;
        ddlAllLevels.DataTextField = "Level_NAME";
        ddlAllLevels.DataValueField = "Level_ID";
        ddlAllLevels.DataBind();
    }

    private void ResetControls()
    {
        txtLevelName.Text = string.Empty;
    }

    private void ResetUpdateControls()
    {
        txtLevelNameUpdate.Text = string.Empty;
        trLevelInfo.Visible = false;
        btnUpdateLevel.Visible = false;
    }
}
