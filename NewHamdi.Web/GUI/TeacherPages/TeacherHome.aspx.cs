﻿using System;
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

public partial class GUI_TeacherPages_TeacherHome : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.Page.Load+=new EventHandler(Page_Load);
        base.OnInit(e);

    }
     void Page_Load(object sender, EventArgs e)
    {

    }
}
