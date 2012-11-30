<%@ Page Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="false"
    CodeFile="AddNews.aspx.cs" Inherits="GUI_AdminPages_AddNews" Title="إضافة الأخبار" %>

<%@ Register TagPrefix="CE" Assembly="CuteEditor" Namespace="CuteEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 282px;
        }
        .style2
        {
            text-align: right;
        }
        .style3
        {
            text-align: right;
            width: 577px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlAddNews" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td class="headerTd" colspan="2">
                        إضافة خبر جديد
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Image ID="imgNEwsImage" runat="server" Width="150" Height="75" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td class="style7" colspan="2">
                        <asp:Button ID="btnAddNew" runat="server" CssClass="btn" Text="إضافة جديد" />
                        <SuperControls:SuperDropDownList ID="ddlAllNewss" runat="server" AutoPostBack="true"
                            Width="200">
                        </SuperControls:SuperDropDownList>
                        الخبر
                    </td>
                    <tr>
                        <td class="style3">
                            <asp:TextBox ID="TextNewsTitle" runat="server" CssClass="textBox" Width="421px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNewsTitle" runat="server" ControlToValidate="TextNewsTitle"
                                ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="style2">
                            <asp:Label ID="Label1" runat="server" Text="عنوان الخبر"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:FileUpload ID="fUploadNewsImage" runat="server" CssClass="textBox" Width="207px" />
                            <asp:RequiredFieldValidator ID="rfvUploadNeasImage" runat="server" ControlToValidate="fUploadNewsImage"
                                ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="style2">
                            <asp:Label ID="Label5" runat="server" Text="صورة الخبر"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <CE:Editor ID="newsBody" runat="server" CustomCulture="ar" Height="200px" ShowHtmlMode="false"
                                Width="554px">
                            </CE:Editor>
                            <asp:RequiredFieldValidator ID="rfvnewsBody" runat="server" ControlToValidate="newsBody"
                                ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="style2">
                            <asp:Label ID="Label2" runat="server" Text="محتوى الخبر"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Button ID="btnSaveNews" runat="server" CssClass="btn" Text="حفظ" ValidationGroup="Save" />
                            &nbsp;
                        </td>
                        <td class="style2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td class="style2">
                            &nbsp;
                        </td>
                    </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSaveNews" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
