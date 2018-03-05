<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="vendor_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The schools</title>
	<link rel="stylesheet" type="text/css" href="../Media_front/Css/styles.css" />
</head>
<body style="margin-top: 50px">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
			<!-- Container sources start -->
			<tr class="resource_footer" style="width:100%">
				<td><span class="index_title">Vendor Login </span></td>
			</tr>
			<tr>
			    <td align="left">
		            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <table cellpadding="7" cellspacing="0" border="0" class="text shadow_map">
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 30px" align="right">
                                <b>&nbsp;Username </b>
                            </td>
                            <td style="width: 200px; height: 30px" align="left">
                                : <asp:TextBox ID="txtuser" runat="server" Width="160px"></asp:TextBox>			                                    
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 30px" align="right">
                                <b>&nbsp;Password </b>
                            </td>
                            <td style="width: 200px; height: 30px" align="left">
                                : <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnlogin" CssClass="s_button" runat="server" Text="Login" 
                                    onclick="btnlogin_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" style="width: 300px; height: 40px">
                                &nbsp;</td>
                        </tr>
                    </table>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
			</tr>
			<!-- Container sources end -->
       </table>
    </div>
    </form>
</body>
</html>
