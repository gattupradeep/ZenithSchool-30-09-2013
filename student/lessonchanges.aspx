<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lessonchanges.aspx.cs" Inherits="student_lessonchanges" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lesson Changes</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
</head>
<body class="thick_curve">
    <form id="form1" runat="server">
    <div>
        <table cellpadding="7" cellspacing="0" border="0">
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Teacher" CssClass="s_label" ></asp:Label>&nbsp;&nbsp;&nbsp;:
                </td>
                <td>
                    <asp:Label ID="lblteacher" runat="server" CssClass="s_label_value"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Subject" CssClass="s_label"></asp:Label>&nbsp;&nbsp;&nbsp;:
                </td>
                <td>
                    <asp:Label ID="lblsubject" runat="server" CssClass="s_label_value"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    <asp:Label ID="Label1" runat="server" Text="Changes Required" CssClass="s_label"></asp:Label>&nbsp;&nbsp;&nbsp;:
                </td>
                <td>
                    <asp:TextBox ID="txtchanges" runat="server" TextMode="MultiLine" 
                        ToolTip="Please enter your comments to be changed in lesson plan" 
                        Height="70px" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnchanges" runat="server" CssClass="s_button" onclick="btnchanges_Click" Text="Send" />
                &nbsp;
                    <asp:Button ID="Button1" runat="server" CssClass="s_button" Text="Cancel" onclick="Button1_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
