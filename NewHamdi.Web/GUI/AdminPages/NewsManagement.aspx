<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="NewsManagement.aspx.cs" Inherits="GUI_AdminPages_NewsManagement" Title="إدارة الأخبار" %>

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
                    PostBackUrl="~/GUI/AdminPages/DeleteNews.aspx" />
            </td>
            <td style="text-align: center">
                <asp:ImageButton ID="ibtnAddNews" runat="server" ImageUrl="~/GUI/Icons/edit_add.png"
                    PostBackUrl="~/GUI/AdminPages/AddNews.aspx" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <b>حذف و نشر الأخبار</b>
            </td>
            <td style="text-align: center">
                <b>إضافة أخبار </b>
            </td>
        </tr>
    </table>
</asp:Content>
