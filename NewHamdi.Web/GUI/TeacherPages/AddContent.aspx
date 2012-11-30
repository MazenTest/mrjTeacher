<%@ Page Language="C#" MasterPageFile="TeachersMasterPage.master" AutoEventWireup="false"
    CodeFile="AddContent.aspx.cs" Inherits="GUI_TeacherPages_AddContent" Title="إضافة محتويات" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style8
        {
            width: 109px;
        }
        .style9
        {
            width: 76px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlAddContent" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1" width="100%" dir="rtl">
                <tr>
                    <td class="headerTd" colspan="4">
                        إضافة ملف جديد
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblSpecialtyAdd" runat="server" Text="الفرع"></asp:Label>
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlSpecialty" runat="server" Width="200px" AutoPostBack="true">
                        </SuperControls:SuperDropDownList>
                        <asp:RequiredFieldValidator ID="rrvSpecialty" runat="server" ControlToValidate="ddlSpecialty"
                            ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style9">
                        <asp:Label ID="lblCourseAdd" runat="server" Text="المادة"></asp:Label>
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlCoursesAdd" runat="server" AutoPostBack="true"
                            Width="200px">
                        </SuperControls:SuperDropDownList>
                        <asp:RequiredFieldValidator ID="rfvCourse" runat="server" ControlToValidate="ddlCoursesAdd"
                            ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    
                    <td class="style9">
                        <asp:Label ID="lblCourseLevelsAdd" runat="server" Text="مستوى المادة"></asp:Label>
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlCourseLevelsAdd" runat="server" Width="200px">
                        </SuperControls:SuperDropDownList>
                        <asp:RequiredFieldValidator ID="rfvLevel" runat="server" ControlToValidate="ddlCourseLevelsAdd"
                            ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                    </td>
                
                    <td class="style9">
                        <asp:Label ID="Label4" runat="server" Text="إسم الملف"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="TextFileName" runat="server" CssClass="textBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTextFileName" runat="server" ControlToValidate="TextFileName"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblFile" runat="server" Text="الملف"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="FUpContent" runat="server" CssClass="textBox" />
                        <asp:RequiredFieldValidator ID="rfvFUpContent" runat="server" ControlToValidate="FUpContent"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style9">
                        <asp:Label ID="lblContentType" runat="server" Text="الملف"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlContentTypes" runat="server" Width="200">
                            <asp:ListItem Text="ورقة عمل" Value="2"></asp:ListItem>
                            <asp:ListItem Text="دوسية" Value="3"></asp:ListItem>
                            <asp:ListItem Text="أسئلة متوقعة" Value="4"></asp:ListItem>
                            <asp:ListItem Text="غير ذلك" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style2" colspan="4">
                        <asp:Button ID="btnSave" runat="server" Text="حفظ" CssClass="btn" ValidationGroup="Save" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
