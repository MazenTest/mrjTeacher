<%@ Page Language="C#" CodeFile="Default22.aspx.cs" Inherits="Default22" AutoEventWireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upnlAll" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div>
                <table>
                    <tr>
                        <td>
                            <SuperControls:SuperDropDownList ID="ddlAllContents" runat="server" Width="200">
                            </SuperControls:SuperDropDownList>
                            <asp:RequiredFieldValidator ID="rfvContent" runat="server" ControlToValidate="ddlAllContents"
                                ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <SuperControls:SuperDropDownList ID="ddlSpecialties" runat="server" AutoPostBack="true"
                                Width="200">
                            </SuperControls:SuperDropDownList>
                            <asp:RequiredFieldValidator ID="rfvSpecialties" runat="server" ControlToValidate="ddlSpecialties"
                                ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <SuperControls:SuperDropDownList ID="ddlCourses" runat="server" AutoPostBack="true"
                                Width="200">
                            </SuperControls:SuperDropDownList>
                            <asp:RequiredFieldValidator ID="rfvCourses" runat="server" ControlToValidate="ddlCourses"
                                ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <SuperControls:SuperDropDownList ID="ddlLevel" runat="server" Width="200">
                            </SuperControls:SuperDropDownList>
                            <asp:RequiredFieldValidator ID="rfvLevel" runat="server" ControlToValidate="ddlLevel"
                                ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <SuperControls:SuperDropDownList ID="ddlAcademicYear" runat="server" Width="200">
                            </SuperControls:SuperDropDownList>
                            <asp:RequiredFieldValidator ID="rfvAcademicYear" runat="server" ControlToValidate="ddlAcademicYear"
                                ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <SuperControls:SuperDropDownList ID="ddlSemester" runat="server" Width="200">
                                <asp:ListItem Value="-1">الرجاء الاختيار</asp:ListItem>
                                <asp:ListItem Value="1">الشتوية</asp:ListItem>
                                <asp:ListItem Value="2">الصيفية</asp:ListItem>
                            </SuperControls:SuperDropDownList>
                            <asp:RequiredFieldValidator ID="rfvSemester" runat="server" ControlToValidate="ddlSemester"
                                ValidationGroup="Save" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="حفظ" ValidationGroup="Save" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
