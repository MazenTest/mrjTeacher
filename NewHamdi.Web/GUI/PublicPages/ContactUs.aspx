<%@ Page Language="C#" MasterPageFile="~/GUI/PublicPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ContactUs.aspx.cs" Inherits="GUI_PublicPages_ContactUs" Title="من نحن" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style4
        {
            height: 33px;
        }
        .style5
        {
            width: 101px;
        }
        .style6
        {
            width: 209px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="height: 120px">
        <tr>
            <td class="headerTd">
                <b>اتصل بنا</b>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upnlEmails" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" cellpadding="1" cellspacing="1" border="0" dir="rtl">
                            <colgroup class="label-td" width="100" />
                            <colgroup />
                            <colgroup class="label-td" width="100" />
                            <colgroup />
                            <tr>
                                <td class="style5">
                                    الاسم :
                                </td>
                                <td class="style6">
                                    <asp:TextBox ID="txtSenderName" runat="server" CssClass="textBox" MaxLength="30"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSenderName" runat="server" ControlToValidate="txtSenderName"
                                        ValidationGroup="Send">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    البريد الإلكتروني :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSenderemail" runat="server" CssClass="textBox" MaxLength="100"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSenderemail" runat="server" ControlToValidate="txtSenderemail"
                                        ValidationGroup="Send">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtSenderemail"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Send">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    عنوان الرسالة :
                                </td>
                                <td class="style6">
                                    <asp:TextBox ID="txtEmailSubject" runat="server" CssClass="textBox" MaxLength="80"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmailSubject" runat="server" ControlToValidate="txtEmailSubject"
                                        ValidationGroup="Send">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    نص الرسالة :
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtEmailBody" runat="server" CssClass="textBox" TextMode="MultiLine"
                                        Width="601px" Height="200px" MaxLength="500"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmailBody" runat="server" ControlToValidate="txtEmailBody"
                                        ValidationGroup="Send">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <asp:Button ID="btnSend" runat="server" CssClass="btn" Text="إرسال" ValidationGroup="Send" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <asp:Label ID="lblEmailSent" runat="server" Font-Bold="true" ForeColor="Green" Text="تم الإرسال بنجاح، شكراً لكـ على تواصلك معنا"
                                        Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
