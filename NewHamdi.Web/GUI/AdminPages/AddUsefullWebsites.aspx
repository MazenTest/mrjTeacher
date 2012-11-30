<%@ Page Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="false"
    CodeFile="AddUsefullWebsites.aspx.cs" Inherits="GUI_AdminPages_AddUsefullWebsites"
    Title="إضافة  و تعديل المواقع المفيدة" %>

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
        .style3
        {
            width: 90px;
        }
        .style4
        {
            text-align: right;
        }
        .style5
        {
            width: 92px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlAddUsefullWebsites" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" dir="rtl">
                <tr>
                    <td class="headerTd" colspan="4">
                        إضافة موقع جديد
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        الموقع
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlAllUsefulWebsites" runat="server" AutoPostBack="true">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnAddNew" runat="server" Text="إضافة جديد" CssClass="btn" />
                    </td>
                </tr>
                <tr runat="server" id="trImage" visible="false">
                    <td class="style5">
                        صورة الموقع
                    </td>
                    <td>
                        <asp:Image ID="imgUsefulWebsite" runat="server" Height="50" Visible="false" Width="50" />
                    </td>
                </tr>
            </table>
            <table class="style1" width="100%">
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvRedirectUrl" runat="server" ControlToValidate="txtRedirectUrl"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtRedirectUrl" runat="server" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td>
                        رابط التحويل
                    </td>
                    <td class="style4">
                        <asp:RequiredFieldValidator ID="rfvWebsiteName" runat="server" ControlToValidate="txtWebsiteName"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtWebsiteName" runat="server" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td class="style3">
                        اسم الموقع
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style4">
                        <asp:RequiredFieldValidator ID="rfvWebsiteImage" runat="server" ControlToValidate="fupWebsiteImage"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:FileUpload ID="fupWebsiteImage" runat="server" CssClass="textBox" />
                    </td>
                    <td class="style3">
                        صورة الموقع
                    </td>
                </tr>
                <tr>
                    <td class="style2" colspan="3">
                        <asp:Button ID="btnSaveWebsite" runat="server" Text="حفظ" CssClass="btn" ValidationGroup="Save" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSaveWebsite" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
