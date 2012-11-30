<%@ Page Language="C#" MasterPageFile="~/GUI/PublicPages/MasterPage.master" AutoEventWireup="false"
    CodeFile="NewsArchive.aspx.cs" Inherits="GUI_PublicPages_NewsArchive" Title="أرشيف الأخبار" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlNewss" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="2" cellspacing="1">
                <tr>
                    <td class="headerTd" colspan="6">
                        <b>أرشيف الأخبار</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:DataList ID="dlstNews" runat="server" Style="text-align: right; margin: 0 auto"
                            Width="663px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
                            CellPadding="3" GridLines="Vertical" Height="125px" RepeatColumns="4">
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <AlternatingItemStyle BackColor="#DCDCDC" />
                            <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <ItemTemplate>
                                <center>
                                    <table dir="rtl" width="100%" class="comenttbl">
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="hdnNewsId" runat="server" Value='<%#DataBinder.Eval(Container, "DataItem.NEWS_ID")%>' />
                                                <a href="NewsDetails.aspx?Nid=<%#DataBinder.Eval(Container, "DataItem.NEWS_ID")%>">
                                                    <asp:Image ID="imgNews1" runat="server" Height="75" Width="75" ImageUrl='<%# "~/NewsImages/" + Eval("IMAGE_NAME")%>' />
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>
                                                    <%#DataBinder.Eval(Container, "DataItem.TITLE")%></b>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </ItemTemplate>
                        </asp:DataList>
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
