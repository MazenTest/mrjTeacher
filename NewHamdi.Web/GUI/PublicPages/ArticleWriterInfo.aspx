<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    ValidateRequest="false" CodeFile="ArticleWriterInfo.aspx.cs" Inherits="ArticleWriterInfo"
    Title="معلومات الكاتب" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style7
        {
            width: 139px;
        }
        .style8
        {
            text-align: right;
        }
        .style9
        {
            width: 139px;
            height: 43px;
        }
        .style10
        {
            height: 43px;
        }
        .style11
        {
            width: 412px;
        }
        .style12
        {
            width: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlMyProfile" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="2" cellspacing="1" dir="rtl">
                <tr>
                    <td class="headerTd" colspan="6">
                        <asp:Label ID="lblArticleWriterInfoTitle" runat="server" Text="" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style9">
                        <b>الاسم :</b>
                    </td>
                    <td class="style10">
                        <asp:Label ID="lblArticleWriterName" runat="server" Text="" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Image runat="server" ID="imgArticleWriter" Width="120" Height="120" ImageUrl="~/GUI/images/Perosn.png" />
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        <b>السيرة الذاتية :</b>
                    </td>
                    <td colspan="3">
                        <div id="dvCv" runat="server">
                            <b>السيرة الذاتية</b>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>أعمالي :</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvContents" runat="server" Width="94%" CellPadding="3" GridLines="Vertical"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                            BorderWidth="1px" AllowPaging="true" PageSize="20">
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:BoundField DataField="ARTICLE_TITLE" HeaderText="العنوان" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table width="98%" cellpadding="3" cellspacing="0" border="0" style="text-align: center;
        margin: 0 auto">
        <tr>
            <td colspan="4">
                <b>التعليقات</b>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="text-align: right" class="style1" valign="top">
                            <asp:UpdatePanel ID="upnlAllComments" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DataList ID="dlstArticleWriterComments" runat="server" Style="text-align: right;
                                        margin: 0 auto" Width="842px" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                        BorderWidth="1px" CellPadding="4" GridLines="Both">
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <ItemStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <ItemTemplate>
                                            <table dir="rtl" width="100%" class="comenttbl">
                                                <tr>
                                                    <td>
                                                        <b>
                                                            <%#Server.HtmlEncode(DataBinder.Eval(Container, "DataItem.WriterName").ToString())%></b>
                                                        <br />
                                                        <span class="date">
                                                            <%# Convert.ToDateTime( DataBinder.Eval(Container,"DataItem.PublishDate")) %></span>
                                                    </td>
                                                    <td style="vertical-align: top; width: 80%; word-break: break-all;" class="comenttd">
                                                        <b>
                                                            <%# Server.HtmlEncode( DataBinder.Eval(Container,"DataItem.CommentBody").ToString() )%></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="style1" valign="top" colspan="2">
                <asp:UpdatePanel ID="upnlAddComments" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="text-align: right">
                            <table dir="rtl" width="100%">
                                <tr>
                                    <td class="style11">
                                        <b>اضافة تعليق</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11">
                                        <b>الاسم :</b>
                                        <asp:TextBox ID="txtWriterNameComment" runat="server" MaxLength="20" CssClass="textBox"
                                            Width="200"></asp:TextBox>
                                    </td>
                                    <td class="style12">
                                        <asp:RequiredFieldValidator ID="rfvWriterName" runat="server" ControlToValidate="txtWriterNameComment"
                                            ValidationGroup="AddCommet">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11">
                                        <b>التعليق :</b>
                                        <asp:TextBox ID="txtComment" runat="server" Height="90px" TextMode="MultiLine" ValidationGroup="AddCommet"
                                            Width="350px" CssClass="textBox"></asp:TextBox>
                                    </td>
                                    <td class="style12">
                                        <asp:RequiredFieldValidator ID="rfvComment" runat="server" ControlToValidate="txtComment"
                                            ValidationGroup="AddCommet">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td valign="bottom">
                                        <asp:Button ID="btnSaveComment" runat="server" Text="إضافة" ValidationGroup="AddCommet"
                                            CssClass="btn" Enabled="false" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
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
