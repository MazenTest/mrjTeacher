<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="AdminHome.aspx.cs" Inherits="GUI_AdminPages_AdminHome" Title="لوحة تحكم مدير الموقع" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td class="headerTd" colspan="4">
                <asp:Label ID="lblWelcome" Font-Bold="true" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style2">
                <b>اهلا وسهلا بكم في لوحة تحكم مدير الموقع</b>
            </td>
        </tr>
    </table>
</asp:Content>
