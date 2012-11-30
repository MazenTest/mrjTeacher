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

public partial class GUI_AdminPages_TransactionsHistoryManagement : AdminBasePage
{
    private int SelectedUserId
    {
        set
        {
            ViewState["SelectedUserId"] = value;
        }
        get
        {
            int userId = -1;
            if (ViewState["SelectedUserId"] != null)
                userId = Convert.ToInt32(ViewState["SelectedUserId"]);
            return userId;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.ibtnDeleteTransaction.Click += new ImageClickEventHandler(ibtnDeleteTransaction_Click);
        this.gvTransaction.PageIndexChanging += new GridViewPageEventHandler(gvTransaction_PageIndexChanging);
        this.ddlAllUsers.SelectedIndexChanged += new EventHandler(ddlAllUsers_SelectedIndexChanged);
        base.OnInit(e);
    }

    void ddlAllUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        int userId = -1;
        if (int.TryParse(ddlAllUsers.SelectedValue, out userId))
            if (userId > 0)
            {
                SelectedUserId = userId;
                SearchTransactions(userId);
                upnlTransaction.Update();
            }
    }

    void gvTransaction_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTransaction.PageIndex = e.NewPageIndex;
        SearchTransactions(SelectedUserId);
        upnlTransaction.Update();
    }

    void ibtnDeleteTransaction_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvTransaction.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnTransactionId = (HiddenField)row.FindControl("hdnTransactionId");
                CheckBox cbSelectedTransaction = (CheckBox)row.FindControl("cbSelect");
                if (hdnTransactionId != null && (cbSelectedTransaction != null && cbSelectedTransaction.Checked))
                {
                    BLL.DeleteTransactionsHistoryByTransactionId(Convert.ToInt32(hdnTransactionId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        SearchTransactions(SelectedUserId);
        upnlTransaction.Update();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillUsers();
        }
    }

    private void FillUsers()
    {
        DataTable dtAllUsers = BLL.GetAllUsers();
        ddlAllUsers.DataSource = dtAllUsers;
        ddlAllUsers.DataTextField = "FULL_NAME";
        ddlAllUsers.DataValueField = "USER_ID";
        ddlAllUsers.DataBind();
    }

    private void SearchTransactions(int userId)
    {
        int recordsCount = 0;
        int.TryParse(txtTransactionsCount.Text, out recordsCount);
        if (recordsCount <= 0)
            recordsCount = 3;

        if (userId > 0)
        {
            DataTable dtAllTransaction = BLL.GetTransactionsHistoryByUserId(userId, recordsCount);
            gvTransaction.DataSource = dtAllTransaction;
            gvTransaction.DataBind();
        }
    }

}
