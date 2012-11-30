<%@ Page Language="C#" MasterPageFile="~/GUI/ArticleWriterPages/ArticleWritersMasterPage.master"
    AutoEventWireup="false" CodeFile="ChangePassword.aspx.cs" Inherits="GUI_ArticleWriterPages_ChangePassword"
    Title="تعديل كلمة السر " %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlChangePassword" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" style="min-height: 50%;">
                <tr>
                    <td>
                        <asp:Label ID="lblUserName" runat="server" Text="اسم المستخدم"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="textBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                            ValidationGroup="Change">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        كلمة السر الجديدة
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="textBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            ValidationGroup="Change">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <Ajax:PasswordStrength ID="plPassword" runat="server" DisplayPosition="LeftSide"
                            TargetControlID="txtPassword" PreferredPasswordLength="8" Enabled="true">
                        </Ajax:PasswordStrength>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnChangePassword" runat="server" CssClass="btn" Text="تعديل" ValidationGroup="Change" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
