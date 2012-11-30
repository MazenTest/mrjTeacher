<%@ Page Language="C#" AutoEventWireup="false" CodeFile="LoginPage.aspx.cs" Inherits="AdminCMS_LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>لوحة تحكم موقع المعلم الأردني</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="loginForm" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true"
        AsyncPostBackTimeout="999" ScriptMode="Release" LoadScriptsBeforeUI="true" EnablePageMethods="true">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference Path="~/GUI/js/RequestHandler.js" />
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdateProgress ID="upAjaxUpdate" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <div id="UpdateDiv" class="loadingPanel">
                <img id="Img1" src="~/GUI/images/ajax-loader22.gif" alt="Loading" runat="server" />
                ...الرجاء الانتظار
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <fieldset>
        <asp:UpdatePanel ID="upnlLogin" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table dir="rtl">
                    <tr>
                        <td>
                            <b>اسم المستخدم</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="input" ValidationGroup="Login"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                                ValidationGroup="Login">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>كلمة المرور</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                ValidationGroup="Login">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <asp:Label ID="lblInvalidUserNamePassword" runat="server" Text="خطأ في اسم المستخدم أو كلمة المرور"
                            Visible="false"></asp:Label>
                    </tr>
                </table>
                <asp:Button ID="btnLogin" runat="server" CssClass="button" Text="تسجيل الدخول" ValidationGroup="Login" />
                <a href="../PublicPages/PublicHome.aspx">الرجوع إلى الصفحة الرئيسية للموقع</a>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    </form>
</body>
</html>
