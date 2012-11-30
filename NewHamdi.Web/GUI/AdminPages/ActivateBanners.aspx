<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="ActivateBanners.aspx.cs" Inherits="GUI_AdminPages_ActivateBanners"
    Title="إدارة الإعلانات" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlBanner" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="gvBanner" runat="server" Width="100%" CellPadding="3" GridLines="Vertical"
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
                                        فعال
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="imgActive" runat="server" Width="20" Height="20" ImageUrl='<%# GetBannerStatus(Convert.ToBoolean( DataBinder.Eval(Container,"DataItem.BANNER_IS_ACTIVE"))) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        صورة الإعلان
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="imgBanner" runat="server" Width="60" Height="30" ImageUrl='<%# "~/BannersImages/" + Eval("BANNER_IMAGE_NAME")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BANNER_TITLE" HeaderText="اسم الإعلان" />
                                <asp:BoundField DataField="BANNER_REDIRECT_URL" HeaderText="رابط التحويل" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        مكان الظهور
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#GetPositionName(DataBinder.Eval(Container,"DataItem.BANNER_POSITION").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnBannerId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.BANNER_ID") %>' />
                                        <asp:CheckBox ID="cbSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:ImageButton ID="ibtnDeleteBanner" runat="server" ImageUrl="~/GUI/Icons/DeleteContent.png" />
                        <Ajax:ConfirmButtonExtender ID="ceDeleteBanner" runat="server" TargetControlID="ibtnDeleteBanner"
                            ConfirmText="هل أنت متأكد من عملية الحذف؟">
                        </Ajax:ConfirmButtonExtender>
                        <asp:ImageButton ID="ibtnActivateBanner" runat="server" ImageUrl="~/GUI/Icons/Activate.png" />
                        <Ajax:ConfirmButtonExtender ID="ceActivateBanner" runat="server" TargetControlID="ibtnActivateBanner"
                            ConfirmText="هل أنت متأكد من عملية التفعيل؟">
                        </Ajax:ConfirmButtonExtender>
                        <asp:ImageButton ID="ibtnDeActivateBanner" runat="server" ImageUrl="~/GUI/Icons/DeActivate.png" />
                        <Ajax:ConfirmButtonExtender ID="ceDeactivateBanner" runat="server" TargetControlID="ibtnDeActivateBanner"
                            ConfirmText="هل أنت متأكد من عملية إلغاء التفعيل؟">
                        </Ajax:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
