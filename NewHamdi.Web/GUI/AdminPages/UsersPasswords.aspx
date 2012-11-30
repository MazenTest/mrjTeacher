<%@ Page Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="false"
    CodeFile="UsersPasswords.aspx.cs" Inherits="GUI_AdminPages_UsersPasswords" Title="تعديل كلمات سر المعلمين" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 557px;
            text-align: right;
        }
        .style3
        {
            width: 557px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlChangePassword" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td class="headerTd" colspan="4">
                        تعديل كلمة سر المعلم
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <asp:RadioButtonList ID="rblstUserType" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" AutoPostBack="true" dir="rtl">
                            <asp:ListItem Text="معلم" Value="2" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="كاتب" Value="4"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        نوع المستخدم
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:RequiredFieldValidator ID="rfvTeachers" runat="server" ControlToValidate="ddlTeachers"
                            ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                        <SuperControls:SuperDropDownList ID="ddlTeachers" runat="server" Width="200" AutoPostBack="true">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblTeacher" runat="server" Text="المعلم"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblUserName" runat="server" Text="اسم المستخدم"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="كلمة المرور"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="حفظ" CssClass="btn"
                            ValidationGroup="Save" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
