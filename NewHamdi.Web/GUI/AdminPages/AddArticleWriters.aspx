<%@ Page Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="false"
    CodeFile="AddArticleWriters.aspx.cs" Inherits="GUI_AdminPages_AddArticleWriters"
    Title="إضافة الكّتاب" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: right;
        }
        .style3
        {
            text-align: right;
            width: 555px;
        }
        .style4
        {
            width: 555px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlAddArticleWriters" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td class="headerTd" colspan="4">
                        إضافة كاتب جديد
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td class="style2">
                        <asp:Label ID="Label3" runat="server" Text="الإسم الأول"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td class="style2">
                        <asp:Label ID="Label4" runat="server" Text="إسم العائلة"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:FileUpload ID="fUploadArticleWriterImage" runat="server" Width="207px" CssClass="textBox" />
                    </td>
                    <td class="style2">
                        <asp:Label ID="Label5" runat="server" Text="الصورة الشخصية"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:RequiredFieldValidator ID="rfvtxtCv" runat="server" ControlToValidate="txtCv"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtCv" runat="server" CssClass="textBox" Height="99px" TextMode="MultiLine"
                            Width="432px"></asp:TextBox>
                    </td>
                    <td class="style2">
                        <asp:Label ID="Label6" runat="server" Text="السيرة الذاتية"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Button ID="btnSave" runat="server" Text="حفظ" CssClass="btn" ValidationGroup="Save" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
