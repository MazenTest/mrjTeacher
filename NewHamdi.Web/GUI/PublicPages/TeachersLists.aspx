<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="TeachersLists.aspx.cs" Inherits="GUI_PublicPages_TeachersLists" Title="قائمة المعلمون" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upnlTeachers" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="2" cellspacing="1">
                <tr>
                    <td class="headerTd" colspan="6">
                        <b>قائمة المعلمون</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Repeater ID="rptSpecialties" runat="server">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnSpecialtyId" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.SPECIALTY_ID") %>' />
                                <center>
                                    <div class="headerTd">
                                        <%#DataBinder.Eval(Container,"DataItem.SPECIALTY_NAME") %></div>
                                </center>
                                <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                    <tr>
                                        <td>
                                            <asp:Repeater ID="rptSpecialtyCourses" runat="server">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnCourseId" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.COURSE_ID") %>' />
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <center>
                                                                    <b>
                                                                        <%#DataBinder.Eval(Container,"DataItem.COURSE_NAME") %></b></center>
                                                                <center>
                                                                    <asp:Label ID="lblNoDataFound" runat="server" Text="" Visible="false"></asp:Label></center>
                                                                <asp:DataList ID="dlstTeachers" runat="server" Style="text-align: right; margin: 0 auto"
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
                                                                                        <asp:Image ID="imgTeacher1" runat="server" Height="85" Width="85" ImageUrl='<%# "~/UsersImages/" + Eval("IMAGE_NAME")%>' />
                                                                                        <asp:HiddenField ID="hdnTeacherId" runat="server" Value='<%#DataBinder.Eval(Container, "DataItem.TEACHER_ID")%>' />
                                                                                        <br />
                                                                                        <br />
                                                                                        <a href="TeacherInfo.aspx?Tid=<%#DataBinder.Eval(Container, "DataItem.TEACHER_ID")%>">
                                                                                            <%#DataBinder.Eval(Container, "DataItem.TEACHER_NAME")%>
                                                                                        </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </center>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
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
