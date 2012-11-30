<%@ Page Language="C#" MasterPageFile="~/GUI/ArticleWriterPages/ArticleWritersMasterPage.master"
    AutoEventWireup="false" CodeFile="AddArticle.aspx.cs" Inherits="GUI_AdminPages_AddArticle"
    Title="إضافة المقالات" %>

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
            text-align: center;
        }
        .style7
        {
            width: 130px;
        }
        .style8
        {
            text-align: right;
            width: 130px;
        }
        .style9
        {
            text-align: center;
            width: 130px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlAddArticle" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1" width="80%">
                <tr>
                    <td class="headerTd" colspan="2">
                        إضافة و تعديل المقالات
                    </td>
                    <td class="headerTd">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        المقال
                    </td>
                    <td colspan="2">
                        <SuperControls:SuperDropDownList ID="ddlAllArticles" runat="server" AutoPostBack="true"
                            Width="200">
                        </SuperControls:SuperDropDownList>
                        <asp:Button ID="btnAddNew" runat="server" Text="إضافة جديد" CssClass="btn" />
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblArticleTitle" runat="server" Text="عنوان المقال"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtArticleTitle" runat="server" CssClass="textBox" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style3">
                        <asp:RequiredFieldValidator ID="rfvArticleTitle" runat="server" ControlToValidate="txtArticleTitle"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="Label2" runat="server" Text="محتوى المقال"></asp:Label>
                    </td>
                    <td class="style3">
                        <CE:Editor ID="ArticleBody" runat="server" Height="200px" Width="549px" CustomCulture="ar"
                            ShowHtmlMode="false">
                        </CE:Editor>
                    </td>
                    <td class="style3">
                        <asp:RequiredFieldValidator ID="rfvArticleBody" runat="server" ControlToValidate="ArticleBody"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center;">
                        <asp:Button ID="btnSaveArticle" runat="server" Text="حفظ" CssClass="btn" ValidationGroup="Save" />
                    </td>
                    <td style="text-align: center;">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
