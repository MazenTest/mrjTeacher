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
using System.Collections.Generic;
using MyComponent.Entities;

public partial class TeacherInfo : PublicBasePage
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        this.btnSaveComment.Click += new EventHandler(btnSaveComment_Click);
        base.OnInit(e);
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Tid"]))
            {
                FillTeacherInfo();
                FillComments();
                ClearCommentTextBox();

                upnlAllComments.Update();
                upnlAddComments.Update();
            }
        }
    }

    void btnSaveComment_Click(object sender, EventArgs e)
    {
        try
        {
            int teacherId = 0;
            if (int.TryParse(Request.QueryString["Tid"], out teacherId))
            {
                if (teacherId > 0)
                {
                    Comment comment = new Comment
                    {
                        WriterName = txtWriterNameComment.Text,
                        TeacherId = teacherId,
                        CommentBody = txtComment.Text,
                        IsActive = false,
                        PublishDate = DateTime.Now,
                    };

                    BLL.AddComment(comment);
                    ClearCommentTextBox();
                    SetAlert("تم إضافة التعليق بنجاح، سيتم نشر التعليق بعد موافقة الإدارة");
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogger.WriteError(ex);
        }
    }

    private void FillTeacherInfo()
    {
        int teacherId = 0;
        if (int.TryParse(Request.QueryString["Tid"], out teacherId))
        {
            if (teacherId > 0)
            {
                MyComponent.Entities.User teacher = BLL.GetUserById(teacherId);
                if (teacher != null)
                {
                    lblTeacherName.Text = teacher.FirstName + " " + teacher.LastName;
                    if (File.Exists(Server.MapPath("~/UsersImages/" + teacher.ImageName)))
                        imgTeacher.ImageUrl = ResolveUrl("~/UsersImages/" + teacher.ImageName);

                    dvCv.InnerHtml = teacher.Cv;
                    this.Title = "معلومات المعلم " + teacher.FirstName + " " + teacher.LastName;
                    lblTeacherInfoTitle.Text = "معلومات المعلم " + teacher.FirstName + " " + teacher.LastName;

                    btnSaveComment.Enabled = true;

                    string metaTags = teacher.FirstName + " " + teacher.LastName;
                    string description = teacher.FirstName + " " + teacher.LastName;
                    AddMetaTagsAndPageDescription(metaTags, description);
                }

                FillContentGrid(teacherId);
                FillComments();
            }
        }
    }

    private void FillContentGrid(int teacherId)
    {
        DataTable dtContetns = BLL.GetContentByWriterId(teacherId);

        if (dtContetns != null && dtContetns.Rows.Count > 0)
            gvContents.DataSource = dtContetns;
        else
            gvContents.DataSource = new DataTable();

        gvContents.DataBind();
    }

    private void ClearCommentTextBox()
    {
        txtComment.Text = string.Empty;
        txtWriterNameComment.Text = string.Empty;
    }

    private void FillComments()
    {
        int teacherId = 0;
        if (int.TryParse(Request.QueryString["Tid"], out teacherId))
        {
            if (teacherId > 0)
            {
                List<Comment> comments = BLL.GetCommentsByTeacherId(teacherId);

                if (comments != null && comments.Count > 0)
                    dlstTeacherComments.DataSource = comments.Where(c => c.IsActive).ToList();
                else
                    dlstTeacherComments.DataSource = new List<Comment>();

                dlstTeacherComments.DataBind();
            }
        }
    }
}
