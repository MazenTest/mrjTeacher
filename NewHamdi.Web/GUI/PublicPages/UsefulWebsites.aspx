<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="UsefulWebsites.aspx.cs" Inherits="GUI_PublicPages_UsefulWebsites" Title="المواقع المفيدة" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlUsefulWebsites" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="text-align: center; width: 90%;">
                <asp:DataList ID="dlstUsefulWebsites" runat="server" RepeatColumns="6" RepeatDirection="Horizontal"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCCCC" />
                    <AlternatingItemStyle BackColor="#CCCCCC" />
                    <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <ItemTemplate>
                        <div style="text-align: center;">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <a href='<%#DataBinder.Eval(Container,"DataItem.WEBSITE_REDIRECT_URL") %>'>
                                            <asp:Image ID="imgUsefulWebsites" runat="server" Width="150" Height="75" ImageUrl='<%# "~/WebsitesImages/" + Eval("WEBSITE_IMAGE_NAME")%>' />
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="word-break: break-all;">
                                        <b>
                                            <%#DataBinder.Eval(Container,"DataItem.WEBSITE_NAME") %></b>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
