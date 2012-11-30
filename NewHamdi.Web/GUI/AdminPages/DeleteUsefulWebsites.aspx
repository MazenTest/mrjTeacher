<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="DeleteUsefulWebsites.aspx.cs" Inherits="GUI_AdminPages_DeleteUsefulWebsites"
    Title="حذف المواقع المفيدة" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
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

    <asp:UpdatePanel ID="upnlUsefulWebsites" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style2">
                <tr>
                    <td>
                        <asp:GridView ID="gvUsefulWebsites" runat="server" Width="100%" CellPadding="3" GridLines="Vertical"
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
                                        فعال
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="imgActive" runat="server" Width="20" Height="20" ImageUrl='<%# GetWebsiteStatus(Convert.ToBoolean( DataBinder.Eval(Container,"DataItem.IS_ACTIVE"))) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        صورة الإعلان
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="imgUsefulWebsites" runat="server" Width="60" Height="30" ImageUrl='<%# "~/WebsitesImages/" + Eval("WEBSITE_IMAGE_NAME")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        رابط التحويل
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="word-break: break-all;">
                                            <%# DataBinder.Eval(Container, "DataItem.WEBSITE_REDIRECT_URL")%>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Width="50%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        اسم الموقع
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="word-break: break-all;">
                                            <%# DataBinder.Eval(Container, "DataItem.WEBSITE_NAME")%>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnUsefulWebsitesId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.WEBSITE_ID") %>' />
                                        <asp:CheckBox ID="cbSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:ImageButton ID="ibtnDeleteUsefulWebsites" runat="server" ImageUrl="~/GUI/Icons/DeleteContent.png" />
                        <Ajax:ConfirmButtonExtender ID="ceDeleteUsefulWebsites" runat="server" TargetControlID="ibtnDeleteUsefulWebsites"
                            ConfirmText="هل أنت متأكد من عملية الحذف؟">
                        </Ajax:ConfirmButtonExtender>
                        <asp:ImageButton ID="ibtnActivateUsefulWebsites" runat="server" ImageUrl="~/GUI/Icons/Activate.png" />
                        <Ajax:ConfirmButtonExtender ID="ceActivateUsefulWebsites" runat="server" ConfirmText="هل أنت متأكد من عملية التفعيل؟"
                            TargetControlID="ibtnActivateUsefulWebsites">
                        </Ajax:ConfirmButtonExtender>
                        <asp:ImageButton ID="ibtnDeactivateUsefulWebsites" runat="server" ImageUrl="~/GUI/Icons/DeActivate.png" />
                        <Ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="هل أنت متأكد من عملية إلغاء التفعيل؟"
                            TargetControlID="ibtnDeactivateUsefulWebsites">
                        </Ajax:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
