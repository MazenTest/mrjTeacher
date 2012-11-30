using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;
using MyComponent.Business;
using MyComponent.Entities;
using System.Net.Mail;
using System.Net;
using MyComponent.Enums;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private bool refreshState;

    private bool isRefresh;

    protected override void OnInit(EventArgs e)
    {
        this.Page.Load += new EventHandler(Page_Load);
        //this.lbtnContactUs.Click += new EventHandler(lbtnContactUs_Click);
        //this.ibtnClose.Click += new ImageClickEventHandler(ibtnClose_Click);
        //this.btnSend.Click += new EventHandler(btnSend_Click);

        base.OnInit(e);
    }

    void lbtnContactUs_Click(object sender, EventArgs e)
    {
        //ClearEmailForm();
        //popUpEmailDetails.Show();
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BuildNewsSlider();
            BuildTopTenMarquee();
            BuildBanners();
            BuildTopArticlesMarquee();
            FillTopArticleWritersDataList();
            BuildUsefulInfoMarquee();
        }
    }

    private void BuildBanners()
    {
        Banner activeBanner = null;
        //12 is Number Of Banners In Main Page :
        for (int i = 1; i <= 12; i++)
        {
            activeBanner = BLL.GetActiveBannerByPositionId(i);
            if (activeBanner != null)
                switch ((BannerPosition)i)
                {
                    case BannerPosition.FirstRowRight:
                        {
                            imgActiveRightBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgActiveRightBanner.Alt = activeBanner.Title;
                            ahrefActiveRightBanner.HRef = activeBanner.RedirectUrl;
                            ahrefActiveRightBanner.Target = "_blank";

                            break;
                        }
                    case BannerPosition.FirstRowCenter:
                        {
                            imgActiveCenterBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgActiveCenterBanner.Alt = activeBanner.Title;
                            ahrefActiveCenterBanner.HRef = activeBanner.RedirectUrl;
                            ahrefActiveCenterBanner.Target = "_blank";

                            break;
                        }
                    case BannerPosition.FirstRowLeft:
                        {
                            imgActiveLeftBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgActiveLeftBanner.Alt = activeBanner.Title;
                            ahrefActiveLeftBanner.HRef = activeBanner.RedirectUrl;
                            ahrefActiveLeftBanner.Target = "_blank";

                            break;
                        }

                    case BannerPosition.SecondRowRight:
                        {
                            imgSecondRowActiveRightBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgSecondRowActiveRightBanner.Alt = activeBanner.Title;
                            ahrefSecondRowActiveRightBanner.HRef = activeBanner.RedirectUrl;
                            ahrefSecondRowActiveRightBanner.Target = "_blank";

                            break;
                        }
                    case BannerPosition.SecondRowCenter:
                        {
                            imgSecondRowActiveCenterBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgSecondRowActiveCenterBanner.Alt = activeBanner.Title;
                            ahrefSecondRowActiveCenterBanner.HRef = activeBanner.RedirectUrl;
                            ahrefSecondRowActiveCenterBanner.Target = "_blank";

                            break;
                        }
                    case BannerPosition.SecondRowLeft:
                        {
                            imgSecondRowActiveLeftBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgSecondRowActiveLeftBanner.Alt = activeBanner.Title;
                            ahrefSecondRowActiveLeftBanner.HRef = activeBanner.RedirectUrl;
                            ahrefSecondRowActiveLeftBanner.Target = "_blank";

                            break;
                        }

                    case BannerPosition.ThirdRowRight:
                        {
                            imgThirdRowActiveRightBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgThirdRowActiveRightBanner.Alt = activeBanner.Title;
                            ahrefThirdRowActiveRightBanner.HRef = activeBanner.RedirectUrl;
                            ahrefThirdRowActiveRightBanner.Target = "_blank";

                            break;
                        }
                    case BannerPosition.ThirdRowCenter:
                        {
                            imgThirdRowActiveCenterBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgThirdRowActiveCenterBanner.Alt = activeBanner.Title;
                            ahrefThirdRowActiveCenterBanner.HRef = activeBanner.RedirectUrl;
                            ahrefThirdRowActiveCenterBanner.Target = "_blank";

                            break;
                        }
                    case BannerPosition.ThirdRowLeft:
                        {
                            imgThirdRowActiveLeftBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgThirdRowActiveLeftBanner.Alt = activeBanner.Title;
                            ahrefThirdRowActiveLeftBanner.HRef = activeBanner.RedirectUrl;
                            ahrefThirdRowActiveLeftBanner.Target = "_blank";

                            break;
                        }

                    case BannerPosition.FourthRowRight:
                        {
                            imgFourthRowActiveRightBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgFourthRowActiveRightBanner.Alt = activeBanner.Title;
                            ahrefFourthRowActiveRightBanner.HRef = activeBanner.RedirectUrl;
                            ahrefFourthRowActiveRightBanner.Target = "_blank";

                            break;
                        }
                    case BannerPosition.FourthRowCenter:
                        {
                            imgFourthRowActiveCenterBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgFourthRowActiveCenterBanner.Alt = activeBanner.Title;
                            ahrefFourthRowActiveCenterBanner.HRef = activeBanner.RedirectUrl;
                            ahrefFourthRowActiveCenterBanner.Target = "_blank";

                            break;
                        }
                    case BannerPosition.FourthRowLeft:
                        {
                            imgFourthRowActiveLeftBanner.Src = ResolveUrl("~/BannersImages/" + activeBanner.ImageName);
                            imgFourthRowActiveLeftBanner.Alt = activeBanner.Title;
                            ahrefFourthRowActiveLeftBanner.HRef = activeBanner.RedirectUrl;
                            ahrefFourthRowActiveLeftBanner.Target = "_blank";

                            break;
                        }
                }
        }
    }

    private void BuildTopTenMarquee()
    {
        DataTable dtTopTenContents = BLL.GetTopTenContents();
        string dvTopTenContent = "<center>";

        if (dtTopTenContents != null && dtTopTenContents.Rows.Count > 0)
        {
            for (int i = 0; i <= dtTopTenContents.Rows.Count - 1; i++)
            {
                dvTopTenContent += "<p>";
                dvTopTenContent += "<a href=\"TeacherInfo.aspx?Tid=" + dtTopTenContents.Rows[i]["USER_ID"] + "\" target=\"_blank\" class=\"hrefMain\">";
                dvTopTenContent += dtTopTenContents.Rows[i]["FULL_NAME"].ToString() +
                    "  " + Convert.ToDateTime(dtTopTenContents.Rows[i]["PUBLISH_DATE"]).ToShortDateString()
                    + " " + dtTopTenContents.Rows[i]["FILE_NAME"].ToString();
                dvTopTenContent += "</a></p><br />";
            }
            dvTopTenContent += "</center>";
            dvTopTen.InnerHtml = dvTopTenContent;
        }
    }

    private void BuildNewsSlider()
    {
        DataTable dtNews = BLL.GetTopFourNews();

        string dvNewsStart = "<div id=\"featured\">";
        string strCaptions = string.Empty;

        if (dtNews != null && dtNews.Rows.Count > 0)
        {
            DataRow[] rows = dtNews.Select("NEWS_ID > 0");
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                dvNewsStart += " <img src=\"../../NewsImages/" + rows[i]["IMAGE_NAME"].ToString() + "\" data-caption=\"#SP" + rows[i]["NEWS_ID"].ToString() + "\" width=\"968\"" + " height=\"280\"/>";

                strCaptions += "<span class=\"orbit-caption\" id=\"SP" + rows[i]["NEWS_ID"].ToString() + "\"" + " style=\"text-align: right\">";
                strCaptions += "<a href=\"" + "NewsDetails.aspx?Nid=" + rows[i]["NEWS_ID"].ToString() + "\" style=\"color: white; text-decoration:none;\">";
                strCaptions += "<b><span style=\"font-size: x-large;\">";
                strCaptions += rows[i]["TITLE"].ToString();
                strCaptions += "</span></b>";
                strCaptions += "</a>";
                strCaptions += " </span>";
            }

            dvNewsStart += "</div>";
            dvNewsStart += strCaptions;

            dvNews.InnerHtml = dvNewsStart;
        }
    }

    public void SetAlert(string istrMessage)
    {
        string s = "<SCRIPT language=\"javascript\">" +

           "alert('" + istrMessage + "') ;</SCRIPT>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowAlert" + istrMessage, s, false);
    }

    private void BuildTopArticlesMarquee()
    {
        DataTable dtTopTenArticles = BLL.GetTopTenArticles();
        rptTopTenArticles.DataSource = dtTopTenArticles;
        rptTopTenArticles.DataBind();
    }

    private void FillTopArticleWritersDataList()
    {
        DataTable dtTopArticleWriters = BLL.GetTopUsersByRoleId((int)UserRoles.ArticleWriter);
        dlstArticleWriters.DataSource = dtTopArticleWriters;
        dlstArticleWriters.DataBind();
    }

    protected void lbtnLogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/GUI/Default.aspx");
    }

    private void BuildUsefulInfoMarquee()
    {
        DataTable dtAllUsefulInfo = BLL.GetTopTenUsefulInfo();
        dlstAllUsefulInfo.DataSource = dtAllUsefulInfo;
        dlstAllUsefulInfo.DataBind();
    }

    #region Browser Refresh

    protected override void LoadViewState(object savedState)
    {
        object[] AllStates = (object[])savedState;
        base.LoadViewState(AllStates[0]);
        refreshState = bool.Parse(AllStates[1].ToString());
        if (Session["ISREFRESH"] != null)
            isRefresh = (refreshState == (bool)Session["ISREFRESH"]);

    }
    protected override object SaveViewState()
    {
        Session["ISREFRESH"] = refreshState;
        object[] AllStates = new object[3];
        AllStates[0] = base.SaveViewState();
        AllStates[1] = !(refreshState);
        return AllStates;
    }
    #endregion
}
