<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="CourseTeacherManagement.aspx.cs" Inherits="GUI_AdminPages_CourseTeacherManagement"
    Title="إدارة معلمون المواد" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 548px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

        function SelectAllCheckboxes(spanChk) {

            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
        spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
              elm[i].id != theBox.id) {
                //elm[i].click();
                if (elm[i].checked != xState)
                    elm[i].click();
                //elm[i].checked=xState;
            }

        }
    </script>

    <asp:UpdatePanel ID="upnlAddTeachers" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="headerTd" colspan="4">
                        إدارة معلمون المواد
                    </td>
                </tr>
                <tr>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlAllCourses" runat="server" CssClass="textBox"
                            AutoPostBack="true">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td>
                        المادة
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnCourselTeachers" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlCourseTeachers" runat="server" Visible="false">
                <table width="100%" dir="rtl">
                    <tr>
                        <td style="vertical-align: top;">
                            <div>
                                كل المعلمون
                            </div>
                            <asp:GridView ID="gvTeachers" runat="server" Width="80%" CellPadding="3" GridLines="Vertical"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                                BorderWidth="1px" CellSpacing="4" AllowPaging="true" PageSize="20">
                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="cbSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnTeacherId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.ID") %>' />
                                            <asp:CheckBox ID="cbSelect" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="1%" />
                                        <HeaderStyle Width="1%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FirstName" HeaderText="اسم المعلم" />
                                </Columns>
                                <EmptyDataTemplate>
                                    لا يوجد معلمون مضافون حالياً
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddTeacher" runat="server" Text=">" CssClass="btn" Width="40" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnDeleteTeacher" runat="server" Text="<" CssClass="btn" Width="40" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="vertical-align: top;">
                            <div>
                                معلمو المادة
                            </div>
                            <asp:GridView ID="gvCourseTeachers" runat="server" Width="80%" CellPadding="3" GridLines="Vertical"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                                BorderWidth="1px" CellSpacing="4" AllowPaging="true" PageSize="20">
                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="cbSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnTeacherId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.Teacher_ID") %>' />
                                            <asp:CheckBox ID="cbSelect" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="1%" />
                                        <HeaderStyle Width="1%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TEACHER_NAME" HeaderText="اسم المعلم" />
                                </Columns>
                                <EmptyDataTemplate>
                                    لا يوجد معلمون مضافون لهذه المادة
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
