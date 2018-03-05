<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mangedb.aspx.cs" Inherits="admin_mangedb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td style="width: 1003px; height: 150px; background-image: url(design/adminpanel1.jpg)"></td>
            </tr>
            <tr>
                <td style="width: 1003px; height: 5px"></td>
            </tr>
            <tr>
                <td style="width: 1003px; height: 46px; background-image: url(design/fillmenu.jpg)">
                </td>
            </tr>
            <tr>
                <td style="width: 1003px; height: 420px">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td style="width: 1000px; height: 420px; background-color: #CDE6F3" valign="top" align="center" class="countersales"> 
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="5" style="width: 1003px; height: 15px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="width: 1003px; height: 2px; background-color: #126089">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 2px; height: 15px; background-color: #126089">
                                    </td>
                                    <td class="title" colspan="3" style="width: 999px; height: 30px; background-color: #1f80b3" align="left">
                                        &nbsp;
                                        :: Manage DB:.</td>
                                    <td style="width: 2px; height: 15px; background-color: #126089">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="width: 1003px; height: 2px; background-color: #126089">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 2px; height: 25px; background-color: #126089">
                                    </td>
                                    <td style="width: 150px; height: 25px" align="right">
                                        Query : &nbsp;</td>
                                    <td style="width: 2px; height: 25px; background-color: #126089">
                                    </td>
                                    <td style="width: 847px; height: 25px" align="left">
                                        &nbsp;<asp:TextBox ID="txtquery" runat="server" CssClass="txtbox11px" Width="800px" Height="200px" TextMode="MultiLine"></asp:TextBox></td>
                                    <td style="width: 2px; height: 25px; background-color: #126089">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="width: 1003px; height: 2px; background-color: #126089">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 2px; height: 25px; background-color: #126089">
                                    </td>
                                    <td style="width: 150px; height: 25px" align="right">
                                        Final
                                        Query : &nbsp;</td>
                                    <td style="width: 2px; height: 25px; background-color: #126089">
                                    </td>
                                    <td style="width: 847px; height: 25px" align="left">
                                        &nbsp;<asp:TextBox ID="txtfinalquery" runat="server" CssClass="txtbox11px" Width="800px" Height="70px" TextMode="MultiLine"></asp:TextBox></td>
                                    <td style="width: 2px; height: 25px; background-color: #126089">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="width: 1003px; height: 2px; background-color: #126089">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 2px; height: 15px; background-color: #126089">
                                    </td>
                                    <td class="title" colspan="3" style="width: 999px; height: 40px; background-color: #1f80b3">
                                        <asp:Button ID="btnsave" runat="server" CssClass=" btntxt1" OnClick="btnsave_Click"
                                            Text="Execute" Height="30px" Width="100px" BackColor="Gray" BorderColor="#CDE6F3" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" ForeColor="White" />
                                        <asp:Button ID="btnclear" runat="server" CssClass="btntxt1" OnClick="btnclear_Click"
                                            Text="Clear" Height="30px" Width="100px" BackColor="Gray" BorderColor="#CDE6F3" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" ForeColor="White" CausesValidation="False" /></td>
                                    <td style="width: 2px; height: 15px; background-color: #126089">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="width: 760px; height: 2px; background-color: #126089">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 2px; height: 15px; background-color: #126089">
                                    </td>
                                    <td colspan="5" style="width: 999px; height: 40px">
                                        <asp:DataGrid ID="dgbranchmaster" runat="server" CssClass="dg"
                                            Width="100%">
                                            <HeaderStyle BackColor="#1F80B3" Font-Bold="True" Font-Names="Verdana" Font-Size="11px"
                                                ForeColor="White" Height="25px" />
                                            <AlternatingItemStyle BackColor="Gainsboro" />
                                            <ItemStyle ForeColor="Black" Height="25px" />
                                        </asp:DataGrid></td>
                                    <td style="width: 2px; height: 15px; background-color: #126089">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="width: 1003px; height: 2px; background-color: #126089">
                                    </td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>
