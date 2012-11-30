<%@ Page Language="C#" MasterPageFile="~/GUI/PublicPages/MasterPage.master" AutoEventWireup="false"
    CodeFile="Letter.aspx.cs" Inherits="GUI_PublicPages_Letter" Title="الرسالة و الرؤيا" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            color: #CC0000;
            font-size: large;
        }
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        .style3
        {
            color: #CC0000;
            font-size: large;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style4
        {
            height: 33px;
        }
        .style5
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td colspan="2" style="text-align: center" class="style4">
                <b>الــــرؤيـــــا</b>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style3" style="text-align: center">
                بالعلم و التكنولوجيا و القيم نبني طالباً متميزاً
            </td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: 700; text-align: center;" class="style5">
                الـــــرســـالــــة
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style1" style="text-align: center">
                <span class="style2">نحو مدرسة فاعلة تكتشف الموهوبين وتراعي الفروق الفردية وتطورهم علمياً
                    وتكنولوجياً وتغرس القيم والأخلاق والمواطنة الصالحة في نفوسهم بمشاركة المجتمع المحلي</span>
            </td>
        </tr>
    </table>
</asp:Content>
