<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataEncyption.aspx.cs" Inherits="DataEncryption_DataEncyption" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 152px;
        }
        .style4
        {
            width: 108px;
        }
    </style>
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="s1" runat="server">
        </asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="upnlEncryption" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table class="style1">
                        <tr>
                            <td class="style4">
                                Text to Encypt
                            </td>
                            <td class="style3">
                                <asp:TextBox ID="txtToEncrypt" runat="server" Width="575px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt" OnClick="btnEncrypt_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Text to Decypt
                            </td>
                            <td class="style3">
                                <asp:TextBox ID="txtToDecrypt" runat="server" Width="575px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnDecrypt" runat="server" Text="Decrypt" OnClick="btnDecrypt_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        </form>
    </center>
</body>
</html>
