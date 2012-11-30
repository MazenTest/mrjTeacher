<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="BannersManagement.aspx.cs" Inherits="GUI_AdminPages_BannersManagement"
    Title="إدارة الإعلانات" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
            border: 1;
            border-style: dashed;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style2">
        <tr>
            <td style="text-align: center">
                <asp:ImageButton ID="ibtnActivateBanner" runat="server" ImageUrl="~/GUI/Icons/tick.png"
                    PostBackUrl="~/GUI/AdminPages/ActivateBanners.aspx" />
            </td>
            <td style="text-align: center">
                <asp:ImageButton ID="ibtnAddBanner" runat="server" ImageUrl="~/GUI/Icons/edit_add.png"
                    PostBackUrl="~/GUI/AdminPages/AddBanners.aspx" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <b>تفعيل و حذف الإعلانات</b>
            </td>
            <td style="text-align: center">
                <b>إضافة إعلانات </b>
            </td>
        </tr>
    </table>
</asp:Content>
