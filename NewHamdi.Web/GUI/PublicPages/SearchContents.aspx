<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="SearchContents.aspx.cs" Inherits="SearchContents" Title="البحث عن المحتويات" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            text-align: center;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function RedirectToTeacherProfile() {

            var teachersDropDown = document.getElementById('<%= ddlCourseTeachers.ClientID %>');
            var coursesDropDown = document.getElementById('<%= ddlCourseSearch.ClientID %>');
            if (teachersDropDown != null) {
                // var x = teachersDropDown.options[teachersDropDown.selectedIndex].value;
                if (teachersDropDown.options[teachersDropDown.selectedIndex].value > 0)
                    window.open('TeacherInfo.aspx?Tid=' + teachersDropDown.options[teachersDropDown.selectedIndex].value,
                             'open_window', 'menubar, toolbar, location, directories, status, scrollbars, resizable, dependent, width=640, height=480, left=0, top=0');
                else {
                    if (coursesDropDown != null)
                        if (coursesDropDown.options[coursesDropDown.selectedIndex].value > 0)
                        window.open('CourseTeachers.aspx?Cid=' + coursesDropDown.options[coursesDropDown.selectedIndex].value,
                             'open_window', 'menubar, toolbar, location, directories, status, scrollbars, resizable, dependent, width=640, height=480, left=0, top=0');
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlSearchContents" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1" width="100%" dir="rtl">
                <colgroup class="label-td" width="100" />
                <colgroup />
                <colgroup class="label-td" width="100" />
                <colgroup />
                <tr>
                    <td class="headerTd" colspan="4">
                        بحث المحتويات
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSpecialty" runat="server" Text="الفرع"></asp:Label>
                    </td>
                    <td class="style5">
                        <SuperControls:SuperDropDownList ID="ddlSpecialtySearch" runat="server" AutoPostBack="true"
                            Width="200px">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td class="style6">
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
                    <td class="style5">
                        <SuperControls:SuperDropDownList ID="ddlCourseLevels" runat="server" Width="200px">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td class="style6">
                        <asp:Label ID="lblCourseTeachers" runat="server" Text="المعلم"></asp:Label>
                    </td>
                    <td class="style4">
                        <SuperControls:SuperDropDownList ID="ddlCourseTeachers" runat="server" Width="200px"
                            AutoPostBack="true">
                        </SuperControls:SuperDropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style9">
                        <asp:Label ID="lblContentType" runat="server" Text="نوع الملف"></asp:Label>
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
                        <asp:Button ID="btnSearch" runat="server" Text="بحث" CssClass="btn" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvContents" runat="server" Width="100%" CellPadding="3" GridLines="Vertical"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                            AllowPaging="true" PageSize="15" BorderWidth="1px">
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
                                <asp:BoundField DataField="TEACHER_NAME" HeaderText="المعلم" />
                                <asp:TemplateField HeaderText="تحميل">
                                    <ItemTemplate>
                                        <a href="javascript: void(0)" onclick="window.open('DownloadContent.aspx?Cid=<%#DataBinder.Eval(Container, "DataItem.CONTENT_ID")%>','windowname1', 
                                        'width=200, height=77,directories=no');return false;">
                                            <asp:Image ID="ibtnDownload" runat="server" ImageUrl="../images/Download22.png" Height="25"
                                                Width="25" /></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DOWNLOAD_COUNT" HeaderText="عدد مرات التحميل" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnlSearchPreviousQuestions" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1" width="100%" dir="rtl">
                <colgroup class="label-td" width="100" />
                <colgroup />
                <colgroup class="label-td" width="100" />
                <colgroup />
                <tr>
                    <td class="headerTd" colspan="4">
                        بحث أسئلة السنوات السابقة
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSpecialtyQuestions" runat="server" Text="الفرع"></asp:Label>
                    </td>
                    <td class="style5">
                        <SuperControls:SuperDropDownList ID="ddlSpecialtyQuestionsSearch" runat="server"
                            AutoPostBack="true" Width="200px">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td class="style6">
                        <asp:Label ID="lblCourseQuestionss" runat="server" Text="المادة"></asp:Label>
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlCourseQuestionsSearch" runat="server" AutoPostBack="true"
                            Width="200px">
                        </SuperControls:SuperDropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCourseQuestionsLevel" runat="server" Text="مستوى المادة"></asp:Label>
                    </td>
                    <td class="style5">
                        <SuperControls:SuperDropDownList ID="ddlCourseQuestionsLevels" runat="server" Width="200px">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td class="style6">
                        <asp:Label ID="Label1" runat="server" Text="السنة الدراسية"></asp:Label>
                    </td>
                    <td class="style4">
                        <SuperControls:SuperDropDownList ID="ddlAcademicYearSearchQuestions" runat="server"
                            Width="200px">
                        </SuperControls:SuperDropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="الدورة"></asp:Label>
                    </td>
                    <td class="style5">
                        <SuperControls:SuperDropDownList ID="ddlSemesterSearchQuestions" runat="server" Width="200px">
                            <asp:ListItem Value="-1">...الرجاء الاختيار</asp:ListItem>
                            <asp:ListItem Value="1">الشتوية</asp:ListItem>
                            <asp:ListItem Value="2">الصيفية</asp:ListItem>
                        </SuperControls:SuperDropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style2" colspan="4">
                        <asp:Button ID="btnSearchQuestions" runat="server" Text="بحث" CssClass="btn" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvPreviousQuestions" runat="server" Width="100%" CellPadding="3"
                            GridLines="Vertical" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999"
                            BorderStyle="Dashed" BorderWidth="1px" AllowPaging="true" PageSize="15" >
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
                                <asp:BoundField DataField="TEACHER_NAME" HeaderText="المعلم" />
                                <asp:BoundField DataField="ACADEMIC_YEAR_NAME" HeaderText="السنة الدراسية" />
                                <asp:BoundField DataField="SEMESTER_NAME" HeaderText="الدورة" />
                                <asp:TemplateField HeaderText="تحميل">
                                    <ItemTemplate>
                                        <a href="javascript: void(0)" onclick="window.open('DownloadContent.aspx?Cid=<%#DataBinder.Eval(Container, "DataItem.CONTENT_ID")%>','windowname1', 
                                        'width=200, height=77,directories=no');return false;">
                                            <asp:Image ID="ibtnDownload" runat="server" ImageUrl="../images/Download22.png" Height="25"
                                                Width="25" /></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DOWNLOAD_COUNT" HeaderText="عدد مرات التحميل" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- AddThis Button BEGIN -->
    <div class="addthis_toolbox addthis_default_style addthis_32x32_style">
        <a class="addthis_button_preferred_1"></a><a class="addthis_button_preferred_2">
        </a><a class="addthis_button_preferred_3"></a><a class="addthis_button_preferred_4">
        </a><a class="addthis_button_compact"></a><a class="addthis_counter addthis_bubble_style">
        </a>
    </div>

    <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4f4e9a0b2fbfe129"></script>

    <!-- AddThis Button END -->
</asp:Content>
