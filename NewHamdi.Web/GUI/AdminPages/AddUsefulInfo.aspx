<%@ Page Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="false"
    CodeFile="AddUsefulInfo.aspx.cs" Inherits="GUI_AdminPages_AddUsefulInfo" Title="إضافة المعلومات المفيدة" %>

<%@ Register TagPrefix="CE" Assembly="CuteEditor" Namespace="CuteEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 282px;
        }
        .style3
        {
            text-align: center;
        }
        .style7
        {
            width: 120px;
        }
        .style8
        {
            text-align: right;
            width: 120px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlAddUsefulInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1" width="80%" dir="rtl">
                <tr>
                    <td class="headerTd" colspan="2">
                        إضافة و تعديل المعلومات المفيدة
                    </td>
                    <td class="headerTd">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        المعلومات المفيدة
                    </td>
                    <td colspan="2">
                        <SuperControls:SuperDropDownList ID="ddlAllUsefulInfos" runat="server" AutoPostBack="true"
                            Width="200">
                        </SuperControls:SuperDropDownList>
                        <asp:Button ID="btnAddNew" runat="server" Text="إضافة جديد" CssClass="btn" />
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblUsefulInfoTitle" runat="server" Text="العنوان"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsefulInfoTitle" runat="server" CssClass="textBox" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style3">
                        <asp:RequiredFieldValidator ID="rfvUsefulInfoTitle" runat="server" ControlToValidate="txtUsefulInfoTitle"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="Label2" runat="server" Text="المحتوى"></asp:Label>
                    </td>
                    <td class="style3">
                        <CE:Editor ID="UsefulInfoBody" runat="server" Height="200px" Width="549px" CustomCulture="ar"
                            ShowHtmlMode="false">
                        </CE:Editor>
                    </td>
                    <td class="style3">
                        <asp:RequiredFieldValidator ID="rfvUsefulInfoBody" runat="server" ControlToValidate="UsefulInfoBody"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center;">
                        <asp:Button ID="btnSaveUsefulInfo" runat="server" Text="حفظ" CssClass="btn" ValidationGroup="Save" />
                    </td>
                    <td style="text-align: center;">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
