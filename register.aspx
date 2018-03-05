<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>
<%@ Register TagName="uc_footer_resource" TagPrefix="uc1" Src="usercontro/footerresource.ascx" %>
<%@ Register TagName="uc_right_resource" TagPrefix="uc2" Src="usercontro/right_resources.ascx" %>
<%@ Register TagName="uc_Logo" TagPrefix="uc3" Src="usercontro/logo.ascx" %>
<%@ Register TagName="uc_banner" TagPrefix="uc4" Src="usercontro/banner.ascx" %>
<%@ Register TagName="uc_topmenu" TagPrefix="uc5" Src="usercontro/topmenu.ascx" %>
<%@ Register TagName="uc_footer" TagPrefix="uc6" Src="usercontro/footer.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
	    <title>The schools</title>
		<link rel="stylesheet" type="text/css" href="Media_front/Css/styles.css" />
		<script src="Media_front/Swf/swfobject_modified.js" type="text/javascript"></script>
		<script type="text/javascript" language="javascript">
		    var objChkd;

		    function HandleOnCheck() {
		        var chkLst = document.getElementById('chkschooltype');
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
	<body>
	<form id="form1" runat="server">
	    <div class="header">
			<uc5:uc_topmenu ID="uc_topmenu" runat="server" />
		</div>
		<table border="0" cellspacing="0" cellpadding="0" width="1000px" align="center">
		<!-- logo and contact section start  Main  -->
			<uc3:uc_Logo ID="uc_logo" runat="server" />
			<!-- logo and contact section end -->
			<tr>
			<!-- Banner Image start -->
				<td valign="top">
					<uc4:uc_banner ID="uc_banner" runat="server" />
				</td>
				<!-- Banner Image end -->
				<!-- Right side resources start -->
				<td valign="top">
					<uc2:uc_right_resource ID="uc_right_resource" runat="server" />
				</td>
				<!-- Right side resources end -->
			</tr>
			<!-- Container sources start -->
			<tr class="resource_footer" style="width:980px;">
				<td colspan="2"><span class="index_title">Registration</span></td>
			</tr>
			<tr align="center">
			     <td colspan="2">
			        <asp:ScriptManager ID="ScriptManager1" runat="server">
                     </asp:ScriptManager>
			        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <table class="form_text" style="margin-left:5px;margin-bottom:10px; text-align: left"  border="0" cellspacing="9" cellpadding="0">
                            <tr>
                                <td style="height:50px;"><h4 style="color:#777701;font-size:19px;">You are just 2 minutes away from your theschools.in account</h4></td>
                            </tr>
                            <tr>
                                <td><b>Your School's Name:<font color="red"></font></b></td>
                            </tr>
                            <tr> 
                                <td style="height: 30px">
                                    <asp:TextBox ID="txtschoolname" runat="server" Width="300px"></asp:TextBox>                                                                     
                                    &nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtschoolname" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td><b>Your Name:<b><font color="red"> </font></td>
                            </tr>
                            <tr> 
                                <td style="height: 30px">
                                    <asp:TextBox ID="txtyourname" runat="server" Width="300px"></asp:TextBox>                                                            
                                    &nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtyourname" Height="16px" Width="16px"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td style="width: 200px"><b>E-mail address: </b><font color="red"></font></td>
                                            <td style="width: 400px">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblemailmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                        <asp:ImageButton ID="chkemail" runat="server" CausesValidation="false" 
                                                            onclick="chkemail_Click" Width="1px" Height="1px" ImageUrl="Media_front/Images/1.jpg"/>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr> 
                                <td>
    						        <asp:TextBox ID="txtemailid" Width="300px" runat="server"></asp:TextBox><br />
    						        <font style="font-size:11px;color:Gray;">Note:this E-mail id will be used as your username</font>
                                    <%--<asp:RegularExpressionValidator ID="reg2" runat="server" ControlToValidate="txtemailid" ErrorMessage="Enter Valid email address" Height="16px" ValidationExpression="/^[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z_+])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9}$/" 
                                        Width="16px"></asp:RegularExpressionValidator>--%><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemailid" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                        ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtemailid" 
                                        ErrorMessage="Invalid Email ID" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid Email ID</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td><b>Address:</b><font color="red"> </font></td>
                            </tr>
                            <tr> 
                                <td style="height: 30px">
                                    <asp:TextBox ID="txtaddress" runat="server" Width="300px"></asp:TextBox>                                                                   
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtaddress" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Country:</b></td>
                            </tr>
                            <tr> 
                                <td style="height: 30px">
    						        <asp:DropDownList ID="ddlcountry" runat="server" Width="200px" 
                                        AutoPostBack="True" 
                                        onselectedindexchanged="ddlcountry_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td><b>State:</b></td>
                            </tr>
                            <tr> 
                                <td style="height: 30px">
    						        <asp:DropDownList ID="ddlstate" runat="server" Width="200px" 
                                        AutoPostBack="True" onselectedindexchanged="ddlstate_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td><b>City:</b></td>
                            </tr>
                            <tr> 
                                <td style="height: 30px">
    						        <asp:DropDownList ID="ddlcity" runat="server" Width="200px" AutoPostBack="True" 
                                        onselectedindexchanged="ddlcity_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Zip code:</b> </td>
                            </tr>
                            <tr> 
                                <td style="height: 30px">
                                    <asp:TextBox ID="txtzipcode" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                        ControlToValidate="txtzipcode" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                        ControlToValidate="txtzipcode" ErrorMessage="Only Alphanumeric" 
                                        ValidationExpression="^[0-9a-zA-Z ]+$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Phone number:</b> <font color="red"> </font></td>
                            </tr>
                            <tr> 
                                <td style="height: 30px">
                                    <asp:TextBox ID="txtcitycode" runat="server" Width="50px"></asp:TextBox>
                                    <asp:TextBox ID="txtphoneno" runat="server" Width="150px"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtphoneno" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                                        ControlToValidate="txtphoneno" ErrorMessage="Only Numbers" 
                                        ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Password:</b></td>
                            </tr>
                            <tr> 
                                <td style="height: 30px">
                                    <asp:TextBox ID="txtpassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtpassword" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Confirm password:</b></td>
                            </tr>
                            <tr> 
                                <td style="height: 30px">
                                    <asp:TextBox ID="txtcpassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtcpassword" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cmp" runat="server" ControlToValidate="txtcpassword" 
                                        ControlToCompare="txtpassword" ErrorMessage="Password Mismatch">Password Mismatch</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40px">
                                    <b>Please enter your school's name or an abbreviation of it so we can us it to 
                                    create an address for you </b>
                                </td>
                            </tr>
                            <tr> 
                                <td style="height: 30px">
                                    http:// <asp:TextBox ID="txtdomainname" runat="server" Width="300px"></asp:TextBox>
                                    .theschools.in
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                        ControlToValidate="txtdomainname" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
    						    </td>
                            </tr>
                            <tr> 
                                <td>
                                    If you'd like greene.theschools.in, then enter greene in the field above. 
                                    Letters and numbers only.					
                                </td>
                            </tr>
                            <tr>
                                <td><b>Is your school a..?</b></td>
                            </tr>
                            <tr>
                                <td style="height: 20px">
                                    <asp:CheckBoxList ID="chkschooltype" runat="server" ValidationGroup="testgroup" 
                                        onselectedindexchanged="chkschooltype_SelectedIndexChanged" RepeatColumns="2">
                                    </asp:CheckBoxList>
                                   <asp:TextBox ID="txtcheckbox" runat="server" ValidationGroup="testgroup" 
                                        Visible="false" Height="22px"/>
                                    <asp:RequiredFieldValidator ID="valcheckboxlist" Display="None" ErrorMessage="At least one school type must be selected" runat="server" ControlToValidate="txtcheckbox" ValidationGroup="testgroup" EnableClientScript="true">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px"></td></tr><tr>
                                <td> <b>No of Student's:<font color="red"></font></b></td></tr><tr>
                                <td style="height: 30px">
                                    <asp:DropDownList ID="ddlnoofstudents" runat="server" Height="20px" style="text-align:center">
                                    <asp:ListItem Value="1">1-100</asp:ListItem><asp:ListItem Value="2">101-500</asp:ListItem><asp:ListItem Value="3">501-1000</asp:ListItem><asp:ListItem Value="4">1001-2000</asp:ListItem><asp:ListItem Value="5">2001-3000</asp:ListItem><asp:ListItem Value="6">3001-4000</asp:ListItem><asp:ListItem Value="7">4001-5000</asp:ListItem><asp:ListItem Value="8">5001-6000</asp:ListItem><asp:ListItem Value="9">6001-7000</asp:ListItem><asp:ListItem Value="10">7001-8000</asp:ListItem><asp:ListItem Value="11">8001-9000</asp:ListItem><asp:ListItem Value="12">9001-10000</asp:ListItem><asp:ListItem Value="13">10001-15000</asp:ListItem><asp:ListItem Value="14">15001-20000</asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                        ControlToValidate="ddlnoofstudents" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator></td></tr><tr>
                                <td><asp:CheckBox ID="chk1" runat="server" Text="I acknowledge that i have read the privacy policy for this site." /> </td>
                            </tr>
                            <tr>
                                <td><asp:Button ID="btncrtsch" runat="server" Text="Create My School Site" CssClass="s_button" onclick="btncrtsch_Click"/></td>
                                
                            </tr>
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                  
			      </td>
			</tr>
			<!-- Container sources end -->
			
			<!-- Bottom resources start main tr -->
			<uc1:uc_footer_resource ID="uc_fot_res" runat="server" />
			
			<!-- Bottom resources end -->
		</table>
		<!-- footer start -->
		<uc6:uc_footer ID="uc_footer" runat="server" />
		<!-- footer end -->
		 </form>
	</body>
</html>

