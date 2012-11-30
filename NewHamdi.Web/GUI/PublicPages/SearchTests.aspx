<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="SearchTests.aspx.cs" Inherits="SearchTests" Title="البحث عن اسئلة السنوات السابقة" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlSearchContents" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style1" dir="ltr">
                <tr>
                    <td class="headerTd" colspan="4">
                        البحث عن ملف
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:DropDownList ID="ddlAcademicYearSearch" runat="server" Width="200px">
                            <asp:ListItem Value="-1">الرجاء الاختيار</asp:ListItem>
                            <asp:ListItem Value="1">2007</asp:ListItem>
                            <asp:ListItem Value="2">2008</asp:ListItem>
                            <asp:ListItem Value="3">2009</asp:ListItem>
                            <asp:ListItem Value="4">2010</asp:ListItem>
                            <asp:ListItem Value="5">2011</asp:ListItem>
                            <asp:ListItem Value="6">2012</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label6" runat="server" Text="السنة الدراسية"></asp:Label>
                    </td>
                    <td style="text-align: right">
                        <asp:DropDownList ID="ddlSpecialtySearch" runat="server" Width="200px">
                            <asp:ListItem Value="-1">الرجاء الاختيار</asp:ListItem>
                            <asp:ListItem Value="1">علمي</asp:ListItem>
                            <asp:ListItem Value="2">أدبي</asp:ListItem>
                            <asp:ListItem Value="3">إدارة معلوماتية</asp:ListItem>
                            <asp:ListItem Value="4">المواد المشتركة - أسئلة عامة</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="Label7" runat="server" Text="الفرع"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:TextBox ID="txtFileNameSearch" runat="server" CssClass="textBox"></asp:TextBox>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label8" runat="server" Text="إسم الملف"></asp:Label>
                    </td>
                    <td style="text-align: right">
                        <asp:DropDownList ID="ddlSemesterSearch" runat="server" Width="200px">
                            <asp:ListItem Value="-1">الرجاء الاختيار</asp:ListItem>
                            <asp:ListItem Value="1">الشتوية</asp:ListItem>
                            <asp:ListItem Value="2">الصيفية</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="Label9" runat="server" Text="الدورة"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2" colspan="3">
                        <asp:Button ID="btnSearch" runat="server" Text="بحث" CssClass="btn" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvContents" runat="server" Width="100%" CellPadding="3" GridLines="Vertical"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                            BorderWidth="1px" AllowPaging="true" PageSize="10">
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                             <asp:BoundField DataField="DOWNLOAD_COUNT" HeaderText="عدد مرات التحميل" />
                                <asp:TemplateField HeaderText="تحميل">
                                    <ItemTemplate>
                                        <a href="javascript: void(0)" onclick="window.open('DownloadContent.aspx?Cid=<%#DataBinder.Eval(Container, "DataItem.CONTENT_ID")%>','windowname1', 
                                        'width=200, height=77,directories=no');return false;">
                                            <asp:Image ID="ibtnDownload" runat="server" ImageUrl="../images/Download22.png" Height="25"
                                                Width="25" /></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الفرع">
                                    <ItemTemplate>
                                        <%# GetSpecialtyName()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="السنة الدراسية">
                                    <ItemTemplate>
                                        <%# GetAcademicYearName()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الدورة">
                                    <ItemTemplate>
                                        <%# GetSemesterName()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FILE_NAME" HeaderText="اسم الملف" />
                            </Columns>
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
