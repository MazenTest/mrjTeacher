<%@ Page Language="C#" MasterPageFile="~/GUI/AdminPages/AdminMaster.master" AutoEventWireup="false"
    CodeFile="LevelsManagement.aspx.cs" Inherits="GUI_AdminPages_LevelsManagement"
    Title="إدارة مستويات المواد" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 548px;
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

    <asp:UpdatePanel ID="upnlAddLevels" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="headerTd" colspan="4">
                        إضافة مستوى جديد
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:RequiredFieldValidator ID="rfvLevelName" runat="server" ControlToValidate="txtLevelName"
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtLevelName" runat="server" CssClass="textBox">
                        </asp:TextBox>
                    </td>
                    <td>
                        اسم مستوى المادة
                    </td>
                </tr>
            </table>
            <div style="text-align: center">
                <asp:Button ID="btnSave" runat="server" Text="حفظ" ValidationGroup="Save" CssClass="btn" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnlLevels" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="gvLevels" runat="server" Width="100%" CellPadding="3" GridLines="Vertical"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Dashed"
                            BorderWidth="1px" CellSpacing="4" AllowPaging="true" PageSize="20">
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:BoundField DataField="Level_NAME" HeaderText="اسم مستوى المادة" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnlUpdateLevel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="headerTd" colspan="4">
                        تعديل معلومات مستوى المادة
                    </td>
                </tr>
                <tr>
                    <td>
                        <SuperControls:SuperDropDownList ID="ddlAllLevels" runat="server" CssClass="textBox"
                            AutoPostBack="true">
                        </SuperControls:SuperDropDownList>
                    </td>
                    <td>
                        مستوى المادة
                    </td>
                </tr>
                <tr id="trLevelInfo" runat="server" visible="false">
                    <td class="style2">
                        <asp:RequiredFieldValidator ID="rfvLevelNameUpdate" runat="server" ControlToValidate="txtLevelNameUpdate"
                            ValidationGroup="Update">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtLevelNameUpdate" runat="server" CssClass="textBox">
                        </asp:TextBox>
                    </td>
                    <td>
                        اسم مستوى المادة
                    </td>
                </tr>
            </table>
            <div style="text-align: center">
                <asp:Button ID="btnUpdateLevel" runat="server" Text="تعديل" ValidationGroup="Update"
                    CssClass="btn" Visible="false" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
