<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownloadContent.aspx.cs"
    Inherits="GUI_PublicPages_DownloadContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>مركز تحميل الملفات</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td colspan="4" style="text-align: center; font-size: xx-large">
                    <asp:LinkButton ID="lbtnDownload" runat="server" Text="اضغط هنا للتحميل" OnClick="lbtnDownload_Click"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
