<%@ Page Language="C#" MasterPageFile="~/GUI/PublicPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="AboutUs.aspx.cs" Inherits="GUI_PublicPages_AboutUs" Title="من نحن" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" 
        style="height: 120px">
        <tr>
            <td colspan="2" style="text-align: center" class="style4">
                <b>من نحن؟</b>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style3" style="text-align: center">
                تعود فكرة وملكية وإدارة موقع المعلم الأردني للمعلم حمدي حسن حسن<br />
&nbsp;معلم لمبحث نظم المعلومات
                الإدارية 
                <br />
                مدرسة طارق بن زياد الثانوية/ عمان الرابعة/ طارق/طبربور<br />
&nbsp;0795972048 
                <br />
                feedback@mrjteacher.com
            </td>
        </tr>
    </table>
</asp:Content>
