﻿<%@ Page Language="C#" MasterPageFile="~/GUI/ArticleWriterPages/ArticleWritersMasterPage.master"
    AutoEventWireup="false" CodeFile="CommnetsManagement.aspx.cs" Inherits="GUI_ArticleWriterPages_CommnetsManagement"
    Title="إدارة التعليقات" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

 function SelectAllCheckboxes(spanChk){

   // Added as ASPX uses SPAN for checkbox
   var oItem = spanChk.children;
   var theBox= (spanChk.type=="checkbox") ? 
        spanChk : spanChk.children.item[0];
   xState=theBox.checked;
   elm=theBox.form.elements;

   for(i=0;i<elm.length;i++)
     if(elm[i].type=="checkbox" && 
              elm[i].id!=theBox.id)
     {
       //elm[i].click();
       if(elm[i].checked!=xState)
         elm[i].click();
       //elm[i].checked=xState;
     }

 }
    </script>

    <asp:UpdatePanel ID="upnlComment" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="gvComment" runat="server" Width="90%" CellPadding="3" GridLines="Vertical"
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
                                        <asp:CheckBox ID="cbSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnCommentId" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.ID") %>' />
                                        <asp:CheckBox ID="cbSelect" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="2%" />
                                    <HeaderStyle Width="2%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="CommentBody" HeaderText="التعليق" />
                                <asp:BoundField DataField="PublishDate" HeaderText="تاريخ الإضافة" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        فعال
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="imgActive" runat="server" Width="20" Height="20" ImageUrl='<%# GetNewsStatus(Convert.ToBoolean( DataBinder.Eval(Container,"DataItem.IsActive"))) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:ImageButton ID="ibtnDeleteComment" runat="server" ImageUrl="~/GUI/Icons/DeleteContent.png" />
                        <Ajax:ConfirmButtonExtender ID="ceDeleteComment" runat="server" TargetControlID="ibtnDeleteComment"
                            ConfirmText="هل أنت متأكد من عملية الحذف؟">
                        </Ajax:ConfirmButtonExtender>
                        <asp:ImageButton ID="ibtnActivateComment" runat="server" ImageUrl="~/GUI/Icons/Activate.png" />
                        <Ajax:ConfirmButtonExtender ID="ceActivateComment" runat="server" TargetControlID="ibtnActivateComment"
                            ConfirmText="هل أنت متأكد من عملية التفعيل؟">
                        </Ajax:ConfirmButtonExtender>
                        <asp:ImageButton ID="ibtnDeActivateComment" runat="server" ImageUrl="~/GUI/Icons/DeActivate.png" />
                        <Ajax:ConfirmButtonExtender ID="ceDeactivateComment" runat="server" TargetControlID="ibtnDeActivateComment"
                            ConfirmText="هل أنت متأكد من عملية إلغاء التفعيل؟">
                        </Ajax:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
