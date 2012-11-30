<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="ContentManagement.aspx.cs" Inherits="GUI_AdminPages_ContentManagement"
    Title="إدارة المحتويات" %>

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
                <asp:ImageButton ID="ibtnDeleteContents" runat="server" ImageUrl="~/GUI/Icons/button_cancel.png"
                    PostBackUrl="~/GUI/AdminPages/DeleteContents.aspx" />
            </td>
            <td style="text-align: center">
                <asp:ImageButton ID="ibtnAddQuestoins" runat="server" ImageUrl="~/GUI/Icons/edit_add.png"
                    PostBackUrl="~/GUI/AdminPages/AddTests.aspx" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <b>حذف محتويات</b>
            </td>
            <td style="text-align: center">
                <b>إضافة اسئلة سنوات سابقة </b>
            </td>
        </tr>
    </table>
</asp:Content>
