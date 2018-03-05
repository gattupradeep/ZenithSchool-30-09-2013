<%@ Page Language="C#" AutoEventWireup="true" CodeFile="requestpopup.aspx.cs" Inherits="transport_requestpopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server">
    <div align="center" style="margin-top:40px">
        <%--<asp:Panel ID="pan" runat="server" BorderWidth="1px" Width="300px">--%>
        <table cellpadding="0" cellspacing="0" style="border:black solid thin;" width="300px">
            <tr>
                <td align="right" style="height:40px">
                    <asp:Label ID="Label2" runat="server" Text="Standard" Font-Bold="False" ForeColor="#F27609" Font-Names="arial" Font-Size="14px"></asp:Label>&nbsp;&nbsp;&nbsp;:
                </td>
                <td style="height:40px">
                    <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="height:40px">
                    <asp:Label ID="Label3" runat="server" Text="Section" Font-Bold="False" ForeColor="#F27609" Font-Names="arial" Font-Size="14px"></asp:Label>&nbsp;&nbsp;&nbsp;:
                </td>
                <td style="height:40px">
                    <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlsection_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td valign="middle" align="right" style="height:40px">
                    <asp:Label ID="Label1" runat="server" Text="Student Name" Font-Bold="False" ForeColor="#F27609" Font-Names="arial" Font-Size="14px"></asp:Label>&nbsp;&nbsp;&nbsp;:
                </td>
                <td style="height:40px">
                    <asp:DropDownList ID="ddlname" runat="server" CssClass="s_dropdown" 
                        Width="150px" AutoPostBack="True" 
                        onselectedindexchanged="ddlname_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td valign="middle" align="right" style="height:40px">
                    <asp:Label ID="Label4" runat="server" Text="Admission No :" Font-Bold="False" 
                        ForeColor="#F27609" Font-Names="arial" Font-Size="14px"></asp:Label>
                </td>
                <td style="height:40px">
                    <asp:Label ID="lbladmitno" runat="server" Font-Bold="False" ForeColor="#F27609" 
                        Font-Names="arial" Font-Size="14px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height:40px">
                    &nbsp;</td>
                <td style="height:40px">
                    <asp:Button ID="btnapply" runat="server" Font-Bold="True" 
                        Font-Italic="False" ForeColor="White" Text="Apply" 
                        onclick="btnapply_Click" CssClass="s_button" />&nbsp;
                    <asp:Button ID="Button1" runat="server" Font-Bold="True" ForeColor="White" 
                        Text="Cancel" onclick="Button1_Click" CssClass="s_button" />
                </td>
            </tr>
        </table>
       <%-- </asp:Panel>--%>
    </div>
    </form>
</body>
</html>
