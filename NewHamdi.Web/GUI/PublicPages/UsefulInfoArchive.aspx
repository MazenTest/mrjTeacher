<%@ Page Language="C#" MasterPageFile="~/GUI/PublicPages/MasterPage.master" AutoEventWireup="false"
    CodeFile="UsefulInfoArchive.aspx.cs" Inherits="GUI_PublicPages_UsefulInfoArchive" Title="أرشيف المعلومات المفيدة" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlUsefulInfos" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="2" cellspacing="1">
                <tr>
                    <td class="headerTd" colspan="6">
                        <b>أرشيف المعلومات المفيدة</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        <asp:DataList ID="dlstAllUsefulInfo" runat="server" Style="text-align: right; margin: 0 auto"
                            Width="900px" Height="160px" RepeatColumns="1" CellPadding="4" 
                            ForeColor="#333333">
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <AlternatingItemStyle BackColor="White" />
                            <ItemStyle BackColor="#E3EAEB" />
                            <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <ItemTemplate>
                                <a href="UsefulInfoDetails.aspx?Uid=<%#DataBinder.Eval(Container,"DataItem.USEFUL_INFO_ID") %>">
                                    <b>
                                        <%#DataBinder.Eval(Container,"DataItem.USEFUL_INFO_TITLE") %>
                                    </b></a>
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
