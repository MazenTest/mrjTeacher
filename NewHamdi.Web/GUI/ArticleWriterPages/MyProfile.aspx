<%@ Page Language="C#" MasterPageFile="ArticleWritersMasterPage.master" AutoEventWireup="false"
    CodeFile="MyProfile.aspx.cs" Inherits="GUI_ArticleWriterPages_MyProfile" Title="ملفي الشخصي" %>

<%@ Register TagPrefix="CE" Assembly="CuteEditor" Namespace="CuteEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style7
        {
            width: 139px;
        }
        .style9
        {
            width: 139px;
            height: 43px;
        }
        .style12
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

    <asp:UpdatePanel ID="upnlMyProfile" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="2" cellspacing="1">
                <tr>
                    <td style="text-align: center" colspan="6">
                        <b>صفحتي الشخصية</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image runat="server" ID="imgArticleWriter" Width="120" Height="120" Visible="true"
                            ImageUrl="~/GUI/images/Perosn.png" />
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        <b>تعديل الصورة الشخصية</b>
                    </td>
                    <td class="style12" colspan="2">
                        <asp:FileUpload ID="fupArticleWriterImage" runat="server" CssClass="textBox" />
                        <asp:RequiredFieldValidator ID="rfvArticleWriterImage" runat="server" ControlToValidate="fupArticleWriterImage"
                            ValidationGroup="UpdateImage">*</asp:RequiredFieldValidator>
                        <asp:Button ID="btnUpdateImage" runat="server" CssClass="btn" Text="تعديل الصورة"
                            ValidationGroup="UpdateImage" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style9">
                        الاسم
                    </td>
                    <td class="style12">
                        <asp:TextBox ID="txtArticleWriterFirstName" runat="server" CssClass="textBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtArticleWriterFirstName"
                            ValidationGroup="Update">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtArticleWriterLastName" runat="server" CssClass="textBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvArticleWriterLastName" runat="server" ControlToValidate="txtArticleWriterLastName"
                            ValidationGroup="Update">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <%-- <td class="style7">
                        السيرة الذاتية
                    </td>--%>
                    <td colspan="4">
                        <%--<asp:TextBox ID="txtMyCv" runat="server" TextMode="MultiLine" Height="100" Width="400"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMyCv" runat="server" ControlToValidate="txtMyCv"
                            ValidationGroup="Update">*</asp:RequiredFieldValidator>--%>
                        <CE:Editor ID="txtMyCv" runat="server" Height="150px" Width="580px" CustomCulture="ar"
                            ShowHtmlMode="false">
                        </CE:Editor>
                        <asp:RequiredFieldValidator ID="rfvMyCv" runat="server" ControlToValidate="txtMyCv"
                            ValidationGroup="Update">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="btnUpdate" runat="server" Text="تعديل المعلومات" ValidationGroup="Update"
                            CssClass="btn" />
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        أعمالي:
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvContents" runat="server" Width="94%" CellPadding="3" GridLines="Vertical"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                            BorderWidth="1px" AllowPaging="true" PageSize="15">
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnContentId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.ARTICLE_ID") %>' />
                                        <asp:CheckBox ID="cbSelect" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="1%" />
                                    <ItemStyle Width="1%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ARTICLE_TITLE" HeaderText="اسم الملف" />
                                
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="4">
                        <asp:ImageButton ID="ibtnDeleteContent" runat="server" ImageUrl="~/GUI/Icons/DeleteContent.png" />
                        <Ajax:ConfirmButtonExtender ID="ceDeleteNews" runat="server" TargetControlID="ibtnDeleteContent"
                            ConfirmText="هل أنت متأكد من عملية الحذف؟">
                        </Ajax:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpdateImage" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
