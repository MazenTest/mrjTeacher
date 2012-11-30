<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="TransactionsHistoryManagement.aspx.cs" Inherits="GUI_AdminPages_TransactionsHistoryManagement"
    Title="إدارة حركات المستخدمين" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 99px;
        }
        .style3
        {
            width: 310px;
        }
        .style4
        {
            width: 83px;
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

    <asp:UpdatePanel ID="upnlUsers" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="2" cellspacing="2" dir="rtl">
                <colgroup class="label-td" width="100" />
                <colgroup />
                <colgroup class="label-td" width="100" />
                <colgroup />
                <tr>
                    <td class="headerTd" colspan="4">
                        إدارة حركات المستخدمين
                    </td>
                </tr>
                <tr>
                    <td>
                        المستخدم
                    </td>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlAllUsers" runat="server" CssClass="textBox"
                            AutoPostBack="true">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td class="style3">
                        عدد الحركات
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtTransactionsCount" runat="server" Text="3" CssClass="textBox"
                            Width="50"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnlTransaction" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td style="width: 100%">
                        <asp:GridView ID="gvTransaction" runat="server" Width="100%" CellPadding="3" GridLines="Vertical"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                            BorderWidth="1px" CellSpacing="4" AllowPaging="true" PageSize="15">
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
                                        <asp:HiddenField ID="hdnTransactionId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.TRANSACTION_ID") %>' />
                                        <asp:CheckBox ID="cbSelect" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="1%" />
                                    <HeaderStyle Width="1%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="WRITER_NAME" HeaderText="اسم المستخدم" />
                                <asp:BoundField DataField="TRANSACTION_DATE" HeaderText="تاريخ الإضافة" />
                                <asp:BoundField DataField="ARTICLE_TITLE" HeaderText="عنوان المقال" />
                                <asp:BoundField DataField="TRANSACTION_NOTE" HeaderText="نوع الحركة" />
                                <asp:BoundField DataField="FILE_NAME" HeaderText="اسم الملف" />
                                <asp:BoundField DataField="COURSE_NAME" HeaderText="اسم المادة" />
                            </Columns>
                            <EmptyDataTemplate>
                                لا يوجد حركات مضافة حالياً
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" class="style2">
                        <asp:ImageButton ID="ibtnDeleteTransaction" runat="server" ImageUrl="~/GUI/Icons/DeleteContent.png" />
                        <Ajax:ConfirmButtonExtender ID="ceDeleteTransaction" runat="server" TargetControlID="ibtnDeleteTransaction"
                            ConfirmText="هل أنت متأكد من عملية الحذف؟">
                        </Ajax:ConfirmButtonExtender>
                        </Ajax:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
