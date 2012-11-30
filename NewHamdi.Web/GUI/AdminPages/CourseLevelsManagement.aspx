<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="CourseLevelsManagement.aspx.cs" Inherits="GUI_AdminPages_CourseLevelsManagement"
    Title="إدارة مستويات المواد" %>

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

    <asp:UpdatePanel ID="upnlAddLevels" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="headerTd" colspan="4">
                        إدارة مستويات المواد
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
    <asp:UpdatePanel ID="upnCourselLevels" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlCourseLevels" runat="server" Visible="false">
                <table width="100%" dir="rtl">
                    <tr>
                        <td style="vertical-align: top;">
                            <div>
                                كل المستويات
                            </div>
                            <asp:GridView ID="gvLevels" runat="server" Width="80%" CellPadding="3" GridLines="Vertical"
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
                                            <asp:HiddenField ID="hdnLevelId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.ID") %>' />
                                            <asp:CheckBox ID="cbSelect" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="1%" />
                                        <HeaderStyle Width="1%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NAME" HeaderText="اسم مستوى المادة" />
                                </Columns>
                                <EmptyDataTemplate>
                                    لا يوجد مستويات مضافة حالياً
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddLevel" runat="server" Text=">" CssClass="btn" Width="40" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnDeleteLevel" runat="server" Text="<" CssClass="btn" Width="40" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="vertical-align: top;">
                            <div>
                                مستويات المادة
                            </div>
                            <asp:GridView ID="gvCourseLevels" runat="server" Width="80%" CellPadding="3" GridLines="Vertical"
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
                                            <asp:HiddenField ID="hdnLevelId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.Level_ID") %>' />
                                            <asp:CheckBox ID="cbSelect" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="1%" />
                                        <HeaderStyle Width="1%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Level_NAME" HeaderText="اسم مستوى المادة" />
                                </Columns>
                                <EmptyDataTemplate>
                                    لا يوجد مستويات مضافة لهذه المادة
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
