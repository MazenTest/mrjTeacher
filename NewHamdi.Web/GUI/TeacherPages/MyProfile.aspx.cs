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

public partial class GUI_TeacherPages_MyProfile : TeacherBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.ibtnDeleteContent.Click += new ImageClickEventHandler(ibtnDeleteContent_Click);
        this.gvContents.PageIndexChanging += new GridViewPageEventHandler(gvContents_PageIndexChanging);
        this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        this.btnUpdateImage.Click += new EventHandler(btnUpdateImage_Click);
        base.OnInit(e);
    }

    void btnUpdateImage_Click(object sender, EventArgs e)
    {
        if (fupTeacherImage.PostedFile != null)
        {
            if (fupTeacherImage.PostedFile != null)
            {
                string extension = Path.GetExtension(fupTeacherImage.PostedFile.FileName);
                string imageName = Guid.NewGuid().ToString() + extension;
                string path = Server.MapPath("~/UsersImages/");
                fupTeacherImage.SaveAs(path + imageName);

                BLL.UpdateUserImage(Convert.ToInt32(Session["TeacherId"]), imageName);

                FillTeacherInfo();
                SetAlert(operationMessage);
                upnlMyProfile.Update();
            }
        }
    }

    void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["TeacherId"] != null)
        {
            MyComponent.Entities.User teacher = BLL.GetUserById(Convert.ToInt32(Session["TeacherId"]));
            if (teacher != null)
            {
                teacher.FirstName = txtTeacherFirstName.Text;
                teacher.LastName = txtTeacherLastName.Text;
                teacher.Cv = txtMyCv.Text;

                BLL.UpdateUser(teacher);

                SetAlert(operationMessage);
                upnlMyProfile.Update();
            }
        }
    }

    void gvContents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvContents.PageIndex = e.NewPageIndex;
        FillContentGrid();
        upnlMyProfile.Update();
    }

    void ibtnDeleteContent_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in gvContents.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnContentId = (HiddenField)row.FindControl("hdnContentId");
                CheckBox cbSelectedContent = (CheckBox)row.FindControl("cbSelect");
                if (hdnContentId != null && (cbSelectedContent != null && cbSelectedContent.Checked))
                {
                    BLL.DeleteContent(Convert.ToInt32(hdnContentId.Value));
                    SetAlert(operationMessage);
                }
            }
        }
        FillContentGrid();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillTeacherInfo();
            upnlMyProfile.Update();
        }
    }

    private void FillTeacherInfo()
    {
        MyComponent.Entities.User teacher = BLL.GetUserById(Convert.ToInt32(Session["TeacherId"]));
        if (teacher != null)
        {
            txtTeacherFirstName.Text = teacher.FirstName;
            txtTeacherLastName.Text = teacher.LastName;

            if (File.Exists(Server.MapPath("~/UsersImages/" + teacher.ImageName)))
                imgTeacher.ImageUrl = ResolveUrl("~/UsersImages/" + teacher.ImageName);

            txtMyCv.Text = teacher.Cv;
        }
        FillContentGrid();
    }

    private void FillContentGrid()
    {
        DataTable dtContetns = BLL.GetContentByWriterId(Convert.ToInt32(Session["TeacherId"]));

        if (dtContetns != null && dtContetns.Rows.Count > 0)
            gvContents.DataSource = dtContetns;
        else
            gvContents.DataSource = new DataTable();

        gvContents.DataBind();

    }
}
