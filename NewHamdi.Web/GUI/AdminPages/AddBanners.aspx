<%@ Page Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="false"
    CodeFile="AddBanners.aspx.cs" Inherits="GUI_AdminPages_AddBanners" Title="إضافة إعلانات" %>

<%@ Register TagPrefix="CE" Assembly="CuteEditor" Namespace="CuteEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            text-align: right;
        }
        .style3
        {
            text-align: right;
        }
        .style4
        {
            width: 237px;
        }
        .style5
        {
            text-align: right;
            width: 237px;
        }
        .style6
        {
            width: 272px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlAddBanners" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td class="headerTd" colspan="4">
                        إضافة إعلان جديد
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:RequiredFieldValidator ID="rfvBannerRedirectUrl" runat="server" ControlToValidate="txtBannerRedirectUrl"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtBannerRedirectUrl" runat="server" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblRedirectUrl" runat="server" Text="رابط التحويل"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:RequiredFieldValidator ID="rfvBannersTitle" runat="server" ControlToValidate="TextBannersTitle"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="TextBannersTitle" runat="server" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblBannerTitle" runat="server" Text="اسم الإعلان"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:RequiredFieldValidator ID="rfvBannerPositions" runat="server" ControlToValidate="ddlBannerPositions"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlBannerPositions" runat="server" CssClass="textBox">
                            <asp:ListItem Text="السطر الأول - يمين" Value="1"></asp:ListItem>
                            <asp:ListItem Text="السطر الأول - متوسط" Value="2"></asp:ListItem>
                            <asp:ListItem Text="السطر الاول - يسار" Value="3"></asp:ListItem>
                            <asp:ListItem Text="السطر الثاني - يمين" Value="4"></asp:ListItem>
                            <asp:ListItem Text="السطر الثاني - متوسط" Value="5"></asp:ListItem>
                            <asp:ListItem Text="السطر الثاني - يسار" Value="6"></asp:ListItem>
                            <asp:ListItem Text="السطر الثالث - يمين" Value="7"></asp:ListItem>
                            <asp:ListItem Text="السطر الثالث - متوسط" Value="8"></asp:ListItem>
                            <asp:ListItem Text="السطر الثالث - يسار" Value="9"></asp:ListItem>
                            <asp:ListItem Text="السطر الرابع - يمين" Value="10"></asp:ListItem>
                            <asp:ListItem Text="السطر الرابع - متوسط" Value="11"></asp:ListItem>
                            <asp:ListItem Text="السطر الرابع - يسار" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style2">
                        <asp:Label ID="lblBannerPosition" runat="server" Text="مكان الظهور"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:RequiredFieldValidator ID="rfvUploadBannersImage" runat="server" ControlToValidate="fUploadBannersImage"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:FileUpload ID="fUploadBannersImage" runat="server" CssClass="textBox" />
                    </td>
                    <td class="style2">
                        <asp:Label ID="lblBannerImage" runat="server" Text="صورة الإعلان"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3" colspan="3">
                        &nbsp;</td>
                    <td class="style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1" colspan="4">
                        &nbsp; &nbsp;
                        <asp:Button ID="btnSaveBanner" runat="server" CssClass="btn" Text="حفظ" 
                            ValidationGroup="Save" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSaveBanner" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
