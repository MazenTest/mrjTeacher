<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="SpecialtyCourseManagement.aspx.cs" Inherits="GUI_AdminPages_SpecialtyCourseManagement"
    Title="إدارة مواد التخصصات" %>

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

    <asp:UpdatePanel ID="upnlAllSpecialties" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="headerTd" colspan="4">
                        إدارة مواد التخصصات
                    </td>
                </tr>
                <tr>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlAllSpecialties" runat="server" CssClass="textBox"
                            AutoPostBack="true">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td>
                        التخصص
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnlCourses" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlCourses" runat="server" Visible="false">
                <table width="100%" dir="rtl">
                    <tr>
                        <td style="vertical-align: top;">
                            <div class="headerTd">
                                كل المواد
                            </div>
                            <br />
                            <asp:GridView ID="gvCourses" runat="server" Width="80%" CellPadding="3" GridLines="Vertical"
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
                                            <asp:HiddenField ID="hdnCourseId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.ID") %>' />
                                            <asp:CheckBox ID="cbSelect" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="1%" />
                                        <HeaderStyle Width="1%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Name" HeaderText="اسم المادة" />
                                </Columns>
                                <EmptyDataTemplate>
                                    لا يوجد مواد مضافة حالياً
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                        <td>
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddCourse" runat="server" Text=">" CssClass="btn" Width="40" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnDeleteCourse" runat="server" Text="<" CssClass="btn" Width="40" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="vertical-align: top;">
                            <div class="headerTd">
                                مواد التخصص
                            </div>
                            <br />
                            <asp:GridView ID="gvSpecialtyCourses" runat="server" Width="80%" CellPadding="3"
                                GridLines="Vertical" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999"
                                BorderStyle="Dashed" BorderWidth="1px" CellSpacing="4" AllowPaging="true" PageSize="20">
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
                                            <asp:HiddenField ID="hdnCourseId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.COURSE_ID") %>' />
                                            <asp:CheckBox ID="cbSelect" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="1%" />
                                        <HeaderStyle Width="1%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="COURSE_NAME" HeaderText="اسم المادة" />
                                </Columns>
                                <EmptyDataTemplate>
                                    لا يوجد مواد مضافة لهذا التخصص
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
