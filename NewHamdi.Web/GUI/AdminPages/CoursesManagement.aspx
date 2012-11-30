<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="CoursesManagement.aspx.cs" Inherits="GUI_AdminPages_CoursesManagement"
    Title="إدارة المواد" %>

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

    <asp:UpdatePanel ID="upnlAddCourses" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="headerTd" colspan="4">
                        إضافة مادة جديد
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:RequiredFieldValidator ID="rfvCourseName" runat="server" ControlToValidate="txtCourseName"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtCourseName" runat="server" CssClass="textBox">
                        </asp:TextBox>
                    </td>
                    <td>
                        اسم المادة
                    </td>
                </tr>
            </table>
            <div style="text-align: center">
                <asp:Button ID="btnSave" runat="server" Text="حفظ" ValidationGroup="Save" CssClass="btn" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnlCourses" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="gvCourses" runat="server" Width="100%" CellPadding="3" GridLines="Vertical"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                            BorderWidth="1px" CellSpacing="4" AllowPaging="true" PageSize="20">
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:BoundField DataField="COURSE_NAME" HeaderText="اسم المادة" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnCourseId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.COURSE_ID") %>' />
                                        <asp:CheckBox ID="cbSelect" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="2%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" class="style2">
                        <asp:ImageButton ID="ibtnDeleteCourse" runat="server" ImageUrl="~/GUI/Icons/DeleteContent.png" />
                        <Ajax:ConfirmButtonExtender ID="ceDeleteCourse" runat="server" TargetControlID="ibtnDeleteCourse"
                            ConfirmText="هل أنت متأكد من عملية الحذف؟">
                        </Ajax:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnlUpdateCourse" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="headerTd" colspan="4">
                        تعديل معلومات المادة
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
                <tr id="trCourseInfo" runat="server" visible="false">
                    <td class="style2">
                        <asp:RequiredFieldValidator ID="rfvCourseNameUpdate" runat="server" ControlToValidate="txtCourseNameUpdate"
                            ValidationGroup="Update">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtCourseNameUpdate" runat="server" CssClass="textBox">
                        </asp:TextBox>
                    </td>
                    <td>
                        اسم المادة
                    </td>
                </tr>
            </table>
            <div style="text-align: center">
                <asp:Button ID="btnUpdateCourse" runat="server" Text="تعديل" ValidationGroup="Update"
                    CssClass="btn" Visible="false" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
