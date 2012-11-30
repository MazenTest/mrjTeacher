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

public partial class GUI_PublicPages_UsefulWebsites : PublicBasePage
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
            DataTable dtAllUsefulWebsites = BLL.GetActiveUsefulWebsites();
            dlstUsefulWebsites.DataSource = dtAllUsefulWebsites;
            dlstUsefulWebsites.DataBind();

            string metaTags = "  اسئلة أسئلة السنوات السابقة الدوسيات اوراق أوراق العمل الكتب الطلاب  المعلم الاردني معلمو المواد المعلمين المعلمون السنوات الدراسية التخصصات التربية الاسلامية نظم المعلومات الرياضيات اللغة العربية اللغة الانجليزية الادبي العلمي التمريض برمجة الحاسوب الاخبار الأخبار التعليمية المواقع المفيدة";
            string description = "feedback@mrjteacher.com";
            AddMetaTagsAndPageDescription(metaTags, description);
        }
    }

}
