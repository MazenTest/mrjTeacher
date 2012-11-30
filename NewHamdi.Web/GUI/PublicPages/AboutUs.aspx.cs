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

public partial class GUI_PublicPages_AboutUs : PublicBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string metaTags = "فكرة ملكية من نحن تعود المعلم الاردني الأردني المعلمين المعلمون نظم المعلومات الاداريو الإدارية طارق طبربور زياد الثانوية مدرسة مدارس";
            string description = "تعود فكرة وملكية وإدارة موقع المعلم الأردني للمعلم حمدي حسن حسن لمبحث نظم المعلومات الإدارية مدرسة طارق بن زياد الثانوية/ عمان الرابعة/ طارق/طبربور 0795972048 feedback@mrjteacher.com";
            AddMetaTagsAndPageDescription(metaTags, description);
        }
    }
}
