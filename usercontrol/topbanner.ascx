<%@ Control Language="C#" AutoEventWireup="true" CodeFile="topbanner.ascx.cs" Inherits="admin_usercontrol_topbanner" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td style="width: 50%; height: 144px" align="left">
            <img src="../media/images/logonew.jpg" alt="Logo" />
        </td>
        <td style="width: 50%; height: 144px" align="right">
            <table cellpadding="0" cellspacing="0" border="0" width="100">
                <tr>
                    <td style="width: 100px; height: 90px"></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 54px">
                        <asp:ImageButton ID="btndash" runat="server" 
                            ImageUrl="~/media/images/dashboard.png" onclick="btndash_Click" AlternateText="Dashboard" ToolTip="Dashboard" />
                    </td>
                </tr>
            </table>
        </td>
        <td class="thick_curve">
            <table cellpadding="0" cellspacing="0" border="0" width="450px">
                <tr>
                    <td style="width: 130px" align="center"><img id="logeduser" src="" runat="server" alt="User Profile" width="100" height="100" /></td>
                    <td valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" width="370">
                            <tr>
                                <td style="width: 100px" align="left"><asp:Label ID="lblname" runat="server" CssClass="s_label" Text="Name"></asp:Label></td>
                                <td style="width: 20px" align="center">:</td>
                                <td style="width: 250px" align="left"><asp:Label ID="lblviewname" runat="server" CssClass="s_label" ></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100px" align="left"><asp:Label ID="Label1" runat="server" CssClass="s_label" Width="100px" Text="User Type"></asp:Label></td>
                                <td style="width: 20px" align="center">:</td>
                                <td style="width: 150px" align="left"><asp:Label ID="lblusertype" runat="server" CssClass="s_label"></asp:Label></td>
                            </tr>
                            <tr id="tr1tag" runat="server">
                                <td style="width: 100px" align="left"><asp:Label ID="Label2" runat="server" CssClass="s_label"></asp:Label></td>
                                <td style="width: 20px" align="center">:</td>
                                <td style="width: 150px" align="left"><asp:Label ID="Label5" runat="server" CssClass="s_label" ></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

