<%@ Page Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="false"
    CodeFile="AddTests.aspx.cs" Inherits="GUI_AdminPages_AddTests" Title="إضافة اسئلة السنوات السابقة" %>

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
            width: 94px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlSearchContents" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1" width="100%" dir="rtl">
                <tr>
                    <td class="headerTd" colspan="4">
                        البحث عن ملف
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSpecialty" runat="server" Text="الفرع"></asp:Label>
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlSpecialtySearch" runat="server" AutoPostBack="true"
                            Width="200px">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblCourses" runat="server" Text="المادة"></asp:Label>
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlCourseSearch" runat="server" AutoPostBack="true"
                            Width="200px">
                        </SuperControls:SuperDropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCourseLevel" runat="server" Text="مستوى المادة"></asp:Label>
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlCourseLevels" runat="server" Width="200px">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label6" runat="server" Text="السنة الدراسية"></asp:Label>
                    </td>
                    <td class="style4">
                        <SuperControls:SuperDropDownList ID="ddlAcademicYearSearch" runat="server" Width="200px">
                        </SuperControls:SuperDropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="الدورة"></asp:Label>
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlSemesterSearch" runat="server" Width="200px">
                            <asp:ListItem Value="-1">الرجاء الاختيار</asp:ListItem>
                            <asp:ListItem Value="1">الشتوية</asp:ListItem>
                            <asp:ListItem Value="2">الصيفية</asp:ListItem>
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label8" runat="server" Text="إسم الملف"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtFileNameSearch" runat="server" CssClass="textBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2" colspan="3">
                        <asp:Button ID="btnSearch" runat="server" Text="بحث" CssClass="btn" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvContents" runat="server" Width="100%" CellPadding="3" GridLines="Vertical"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                            BorderWidth="1px">
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:BoundField DataField="FILE_NAME" HeaderText="اسم الملف" />
                                <asp:BoundField DataField="SPECIALTY_NAME" HeaderText="الفرع" />
                                <asp:BoundField DataField="COURSE_NAME" HeaderText="المادة" />
                                <asp:BoundField DataField="LEVEL_NAME" HeaderText="مستوى المادة" />
                                <asp:BoundField DataField="ACADEMIC_YEAR_NAME" HeaderText="السنة الدراسية" />
                                <asp:BoundField DataField="SEMESTER_NAME" HeaderText="الدورة" />
                                <asp:BoundField DataField="DOWNLOAD_COUNT" HeaderText="عدد مرات التحميل" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnlAddTests" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1" width="100%" dir="rtl">
                <tr>
                    <td class="headerTd" colspan="4">
                        إضافة ملف جديد
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblSpecialtyAdd" runat="server" Text="الفرع"></asp:Label>
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlSpecialty" runat="server" Width="200px" AutoPostBack="true">
                        </SuperControls:SuperDropDownList>
                        <asp:RequiredFieldValidator ID="rrvSpecialty" runat="server" ControlToValidate="ddlSpecialty"
                            ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
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
                    <td class="style5">
                        <asp:Label ID="lblAcademicYearAdd" runat="server" Text="السنة الدراسية"></asp:Label>
                    </td>
                    <td class="style4">
                        <SuperControls:SuperDropDownList ID="ddlAcademicYear" runat="server" Width="200px">
                        </SuperControls:SuperDropDownList>
                        <asp:RequiredFieldValidator ID="rfvAcademicYear" runat="server" ControlToValidate="ddlAcademicYear"
                            ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblCourseLevelsAdd" runat="server" Text="مستوى المادة"></asp:Label>
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlCourseLevelsAdd" runat="server" Width="200px">
                        </SuperControls:SuperDropDownList>
                        <asp:RequiredFieldValidator ID="rfvLevel" runat="server" ControlToValidate="ddlCourseLevelsAdd"
                            ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblSemesterAdd" runat="server" Text="الدورة"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSemester" runat="server" Width="200px">
                            <asp:ListItem Value="-1">الرجاء الاختيار</asp:ListItem>
                            <asp:ListItem Value="1">الشتوية</asp:ListItem>
                            <asp:ListItem Value="2">الصيفية</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSemester" runat="server" ControlToValidate="ddlSemester"
                            ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label4" runat="server" Text="إسم الملف"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="TextFileName" runat="server" CssClass="textBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTextFileName" runat="server" ControlToValidate="TextFileName"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblFile" runat="server" Text="الملف"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:FileUpload ID="FUpTest" runat="server" CssClass="textBox" />
                        <asp:RequiredFieldValidator ID="rfvFUpTest" runat="server" ControlToValidate="FUpTest"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
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
