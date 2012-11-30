<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="UsefulWebsitesManagement.aspx.cs" Inherits="GUI_AdminPages_UsefulWebsitesManagement"
    Title="إدارة المواقع المفيدة" %>

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
                <asp:ImageButton ID="ibtnActivateNews" runat="server" ImageUrl="~/GUI/Icons/tick.png"
                    PostBackUrl="~/GUI/AdminPages/DeleteUsefulWebsites.aspx" />
            </td>
            <td style="text-align: center">
                <asp:ImageButton ID="ibtnAddNews" runat="server" ImageUrl="~/GUI/Icons/edit_add.png"
                    PostBackUrl="~/GUI/AdminPages/AddUsefullWebsites.aspx" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <b>حذف مواقع مفيدة</b>
            </td>
            <td style="text-align: center">
                <b>إضافة مواقع مفيدة </b>
            </td>
        </tr>
    </table>
</asp:Content>
