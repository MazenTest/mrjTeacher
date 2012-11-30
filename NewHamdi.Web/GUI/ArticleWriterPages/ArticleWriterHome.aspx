<%@ Page Language="C#" MasterPageFile="~/GUI/ArticleWriterPages/ArticleWritersMasterPage.master"
    AutoEventWireup="false" CodeFile="ArticleWriterHome.aspx.cs" Inherits="GUI_ArticleWriterPages_ArticleWriterHome"
    Title="لوحة تحكم الكاتب" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style7
        {
            width: 100%;
            font-weight: bold;
        }
        .style8
        {
            text-align: center;
            font-size: 15px;
            font-family: "Times New Roman" , Times, serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style7">
        <tr>
            <td class="style8">
                أهلا و سهلا بكم في موقع المعلم الأردني<br />
                نرجو ان تجدو ا الفائدة و المتعة في تصفح موقعكم المتخصص بالمعلمين و الطلاب<br />
                يرجى ارسال ملاحظاتكم او اقتراحاتكم الى مدير الموقع.<br />
                feedback@mrjTeacher.com
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <br />
                <br />
                <a href="../PublicPages/PublicHome.aspx">الرجوع إلى الصفحة الرئيسية للموقع</a>
            </td>
        </tr>
    </table>
</asp:Content>
