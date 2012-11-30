<%@ Page Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="false"
    CodeFile="AddTeachers.aspx.cs" Inherits="GUI_AdminPages_AddTeachers" Title="إضافة المعلملين" %>

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
            width: 561px;
        }
        .style4
        {
            width: 561px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlAddTeachers" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td class="headerTd" colspan="4">
                        إضافة معلم جديد
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style2">
                        <asp:Label ID="Label3" runat="server" Text="الإسم الأول"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style2">
                        <asp:Label ID="Label4" runat="server" Text="إسم العائلة"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:FileUpload ID="fUploadTeacherImage" runat="server" Width="207px" CssClass="textBox" />
                        <asp:RequiredFieldValidator ID="rfvUploadTeacherImage" runat="server" ControlToValidate="fUploadTeacherImage"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style2">
                        <asp:Label ID="Label5" runat="server" Text="الصورة الشخصية"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:TextBox ID="txtCv" runat="server" CssClass="textBox" Height="99px" TextMode="MultiLine"
                            Width="432px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtCv" runat="server" ControlToValidate="txtCv"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style2">
                        <asp:Label ID="Label6" runat="server" Text="السيرة الذاتية"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Button ID="Button1" runat="server" Text="حفظ" OnClick="Button1_Click" CssClass="btn"
                            ValidationGroup="Save" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
