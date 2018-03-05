<%@ Page Language="C#" AutoEventWireup="true" CodeFile="schoollogin.aspx.cs" Inherits="schoollogin" %>

<%@ Register Src="usercontrols/topmenu.ascx" TagName="topmenu" TagPrefix="uc1" %>
<%@ Register Src="usercontrols/leftside1.ascx" TagName="leftside1" TagPrefix="uc2" %>
<%@ Register Src="~/usercontrols/banner.ascx" TagName="banner" TagPrefix="uc4" %>
<%@ Register Src="~/usercontrols/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>The schools online management</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link rel="stylesheet" href="css/styles.css" type="text/css" media="screen">
	<link rel="stylesheet" type="text/css" href="css/module_slider_style.css">
	<link rel="icon" type="image/jpeg" href="images/logo.jpg">
	<link rel="stylesheet" href="css/anythingslider.css">
	<link rel="stylesheet" href="css/jquery-ui.css">
	<link rel="stylesheet" href="css/page.css">
	<script src="js/anythingslider/jquery-min.js"></script>
	<script src="js/anythingslider/jquery.anythingslider.js"></script>
    <script type="text/javascript" src="js/topmenu.js"></script>
	<!--[if lt IE 7]>
    <script defer type="text/javascript" src="js/ie6.js"></script>
    <![endif]-->
	<!-- hidden-->
	<script src="js/hidden/ssm.js" type="text/javascript"></script>
	<script src="js/hidden/ssmItems.js"type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
		// DOM Ready
		$(function(){
			$('#slider').anythingSlider();
         });
         var objChkd;

         function HandleOnCheck() 
         {   var chkLst = document.getElementById('chkschooltype');
             if (objChkd && objChkd.checked)
                 objChkd.checked = false; objChkd = event.srcElement;
         }
         $(function() {
             function checkboxclicked() {
                 var n = $("#list input:checked").length;
                 $("input:#txtcheckbox").val(n == 0 ? "" : n);
             }
             $(":checkbox").click(checkboxclicked);
         });
	</script>
</head>
<body style="margin-left: 0px; margin-top:0px;"  onload="MM_preloadImages('images/benefits01.jpg','images/modules01.jpg','images/contactus01.jpg','images/home01.jpg')" bgcolor="#F9D5AE">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <table width="971" border="0" cellspacing="0" cellpadding="0" align="center">
                <tr> 
                    <td align="left" valign="top" bgcolor="#30321A" >
                        <uc1:topmenu ID="topmenu1" runat="server" />
                </td>
            </tr>
            <tr> 
                <td align="center" valign="top" bgcolor="#30321A">
                    <table width="941" border="0" cellspacing="0" cellpadding="0">
                        <tr> <!-- Banner section begin-->
                            <td >
		                    <uc4:banner ID="banner1" runat="server" />
		                   </td>
                        </tr><!-- Banner section end-->
		                <tr>
		                    <td>
		                        <div style="border-bottom:#30321A solid 2px;"></div>
		                    </td>           
		                </tr>
		                <tr> 
                            <td bgcolor="#E5EBC7">
                                <table width="941" border="0" cellspacing="0" cellpadding="0"  style="margin-bottom:5px;margin-left:2px;" >
                                    <tr > 
                                        <td  valign="top">
                                            <uc2:leftside1 ID="leftside11" runat="server" />
                                        </td>
                                        <td width="690" align="left" valign="top" >
                                            <table width="98%" border="0" cellspacing="0" cellpadding="0" class="form_text" style="margin-left:10px;margin-top:10px;margin-bottom:10px;"  >
                                                <tr> 
                                                    <td class="title_bg" style="height: 40px">
                                                        <h1>&nbsp; Registered Users Login</h1>
                                                    </td>
                                                </tr>
					                            <tr>
					                                <td>
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
					                                    <table cellpadding="0" cellspacing="0" border="0" width="300" class="shadow content_bg">
					                                        <tr>
					                                            <td colspan="2" style="width: 300px; height: 20px" align="left">
					                                            </td>
					                                        </tr>
					                                        <tr>
					                                            <td style="width: 100px; height: 30px" align="left">
                                                                    <b>&nbsp;Username</b>
					                                            </td>
					                                            <td style="width: 200px; height: 30px" align="left">
                                                                    <asp:TextBox ID="txtuser" runat="server" Width="160px"></asp:TextBox>			                                    
					                                            </td>
					                                        </tr>
					                                        <tr>
					                                            <td style="width: 100px; height: 30px" align="left">
					                                                <b>&nbsp;Password</b>
					                                            </td>
					                                            <td style="width: 200px; height: 30px" align="left">
                                                                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
					                                            </td>
					                                        </tr>
					                                        <tr>
					                                            <td style="width: 100px; height: 40px" align="left">
                                                                </td>
					                                            <td style="width: 200px; height: 40px" align="left">
                                                                    <asp:Button ID="btnlogin" runat="server" Text="Login" 
                                                                        onclick="btnlogin_Click" />
                                                                </td>
					                                        </tr>
					                                        <tr>
                                                                <td colspan="2" align="left" style="width: 300px; height: 40px">
                                                                    <asp:Label ID="lblerror" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                                </td>
                                                            </tr>
					                                    </table>
					                                    </ContentTemplate>
					                                    </asp:UpdatePanel>
					                                </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <!--footer start -->
		                 <uc3:footer ID="footer" runat="server" />
		                <!--footer end -->
                    </table>
                </td>
            </tr>
        </table>
        <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
</form>
</body>
</html>