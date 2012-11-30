<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="SearchArticles.aspx.cs" Inherits="SearchArticles" Title="البحث عن المقالات" %>

<asp:Content ID="Article1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            width: 243px;
            text-align: left;
        }
        .style4
        {
            text-align: right;
            width: 463px;
        }
    </style>
</asp:Content>
<asp:Content ID="Article2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlSearchArticles" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1" dir="ltr">
                <colgroup />
                <colgroup class="label-td" width="100" />
                <colgroup />
                <colgroup class="label-td" width="100" />
                <tr>
                    <td class="headerTd" colspan="4">
                        البحث عن المقالات
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:TextBox ID="txtArticleTitle" runat="server" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td class="style3">
                        <asp:Label ID="lblArticleTitle" runat="server" Text="عنوان المقال"></asp:Label>
                    </td>
                    <td class="style4">
                        <SuperControls:SuperDropDownList ID="ddlWriters" runat="server" Width="200px">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td class="style3">
                        <asp:Label ID="lblWriter" runat="server" Text="الكاتب"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="label-td" style="text-align: center" colspan="4">
                        <asp:Button ID="btnSearch" runat="server" Text="بحث" CssClass="btn" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvArticles" runat="server" Width="100%" CellPadding="3" GridLines="Vertical"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                            BorderWidth="1px" AllowPaging="true" PageSize="10">
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:BoundField HeaderText="تاريخ النشر" DataField="PUBLISH_DATE" ItemStyle-Width="30%"
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:TemplateField HeaderText="عنوان المقال">
                                    <ItemTemplate>
                                        <a href="ArticleDetails.aspx?Aid=<%#DataBinder.Eval(Container, "DataItem.ARTICLE_ID")%>"
                                            target="_blank"><b>
                                                <%#DataBinder.Eval(Container, "DataItem.ARTICLE_TITLE")%></b> </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="70%" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                لا يوجد مقالات مضافة حالياً
                            </EmptyDataTemplate>
                        </asp:GridView>
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
