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

public partial class GUI_AdminPages_DeleteUsefulInfo : AdminBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.ibtnDeleteUsefulInfo.Click += new ImageClickEventHandler(ibtnDeleteUsefulInfo_Click);
        this.gvUsefulInfo.PageIndexChanging += new GridViewPageEventHandler(gvUsefulInfo_PageIndexChanging);
        base.OnInit(e);
    }
    void gvUsefulInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUsefulInfo.PageIndex = e.NewPageIndex;
        SearchUsefulInfo();
        upnlUsefulInfo.Update();
    }

    void ibtnDeleteUsefulInfo_Click(object sender, ImageClickEventArgs e)
    {
       // try
       // {
            List<Comment> UsefulInfoComments = null;
            string failedUsefulInfo = string.Empty;

            foreach (GridViewRow row in gvUsefulInfo.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnUsefulInfoId = (HiddenField)row.FindControl("hdnUsefulInfoId");
                    CheckBox cbSelectedUsefulInfo = (CheckBox)row.FindControl("cbSelect");
                    if (hdnUsefulInfoId != null && (cbSelectedUsefulInfo != null && cbSelectedUsefulInfo.Checked))
                    {
                        UsefulInfoComments = BLL.GetCommentsByUsefulInfoId(Convert.ToInt32(hdnUsefulInfoId.Value));
                        if (UsefulInfoComments == null || UsefulInfoComments.Count <= 0)
                        {
                            BLL.DeleteUsefulInfo(Convert.ToInt32(hdnUsefulInfoId.Value));
                            SetAlert(operationMessage);
                        }
                        else
                        {
                            UsefulInfo UsefulInfo = BLL.GetUsefulInfoById(Convert.ToInt32(hdnUsefulInfoId.Value));
                            if (UsefulInfo != null)
                                failedUsefulInfo += " " + UsefulInfo.Title;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(failedUsefulInfo))
                SetAlert("لا يمكن حذف المعلومات المفيدة التالية بسبب ارتباطها بتعليقات" + failedUsefulInfo);
        //}
        //catch (Exception ex)
        //{
        //    SetAlert("حدث خطأ لا يمكن المتابعة");
        //}

        SearchUsefulInfo();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SearchUsefulInfo();
            upnlUsefulInfo.Update();
        }
    }

    private void SearchUsefulInfo()
    {
        DataTable dtAllUsefulInfo = BLL.GetAllUsefulInfo();
        gvUsefulInfo.DataSource = dtAllUsefulInfo;
        gvUsefulInfo.DataBind();
    }
}
