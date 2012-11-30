<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="DeleteUsefulInfo.aspx.cs" Inherits="GUI_AdminPages_DeleteUsefulInfo"
    Title="حذف المعلومات المفيدة" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
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

    <asp:UpdatePanel ID="upnlUsefulInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td style="width: 100%">
                        <asp:GridView ID="gvUsefulInfo" runat="server" Width="100%" CellPadding="3" GridLines="Vertical"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                            BorderWidth="1px" CellSpacing="4" AllowPaging="true" PageSize="15">
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:BoundField DataField="PUBLISH_DATE" HeaderText="تاريخ الإضافة" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        العنوان
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="word-break: break-all; text-align: right;">
                                                    <%# DataBinder.Eval(Container, "DataItem.USEFUL_INFO_TITLE")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnUsefulInfoId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.Useful_Info_ID") %>' />
                                        <asp:CheckBox ID="cbSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" class="style2">
                        <asp:ImageButton ID="ibtnDeleteUsefulInfo" runat="server" ImageUrl="~/GUI/Icons/DeleteContent.png" />
                        <Ajax:ConfirmButtonExtender ID="ceDeleteUsefulInfo" runat="server" TargetControlID="ibtnDeleteUsefulInfo"
                            ConfirmText="هل أنت متأكد من عملية الحذف؟">
                        </Ajax:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
