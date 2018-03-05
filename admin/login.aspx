<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Admin_login" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>The schools</title>
		
		<link rel="stylesheet" type="text/css" href="../media/css/loginpage.css" />
		<link rel="stylesheet" type="text/css" href="../media/css/styles.css" />
		<style type="text/css">
		    .shadow_map
            {
             -moz-box-shadow:inset 0 0 15px #ooo;
               -webkit-box-shadow:inset 15px 0 0  #000;
               box-shadow:inset 0 0 15px #000;
            }
		</style>
</head>
<body>
    <form id="form1" runat="server">
    <div >    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	        <div class="header">
	            <table cellspacing="0" cellpadding="0" border="0" width="100%" style="background:#fff">
	                <tr>
	                    <td align="left" style="width:100px">
	                    <img src="../media/images/logonew.jpg" alt="Logo" />	                                                
	                    </td>
	                </tr>
	            </table>		        
	        </div>
	        <table cellpadding="0" cellspacing="0" width="100%" class="thick_border">
	            <tr>
	                <td>
	                    <div style="padding-top:5px;" align="center">
		                    <div  class="login_div" style="margin-bottom:30px;">
		                        <div>
		                            <table class="login_table" border="0" cellspacing="6" cellpadding="6" align ="center" height ="100">
			                            <tr>
				                            <td>
			                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                <table cellpadding="3" cellspacing="0" border="0" width="100%" class="shadow_map">
                                                    <tr>
                                                        <td style="width: 70px; height: 60px"><img src="../media/images/loginto.png" alt="Login" /></td>
                                                        <td style="width: 144px; height: 60px" class="title_label" valign="middle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Login</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 70px; height: 30px" class="s_label">&nbsp;&nbsp;&nbsp;&nbsp;Patron</td>
                                                        <td style="width: 144px; height: 30px">
                                                            <asp:DropDownList ID="ddlpatron" runat="server" CssClass="s_textbox" 
                                                                Width="180px">
                                                                <asp:ListItem>Staffs</asp:ListItem>
                                                                <asp:ListItem>Parents</asp:ListItem>
                                                                <asp:ListItem>Students</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 70px; height: 30px" class="s_label">&nbsp;&nbsp;&nbsp;&nbsp;Username</td>
                                                        <td style="width: 144px; height: 30px">
                                                            <asp:TextBox ID="txtusername" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                ControlToValidate="txtusername" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 70px; height: 30px" class="s_label">&nbsp;&nbsp;&nbsp;&nbsp;Password</td>
                                                        <td style="width: 144px; height: 30px">
                                                            <asp:TextBox ID="txtpassword" runat="server" CssClass="s_textbox" Width="180px" 
                                                                TextMode="Password"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                ControlToValidate="txtpassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="btnlogin" runat="server" Text="Login" CssClass="s_button" 
                                                                onclick="btnlogin_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height:7px"></td>
                                                    </tr>
                                                </table>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                           </td>				                           
			                            </tr>			                            
		                            </table>
		                        </div>
		                    </div>
		                    
                        </div>
	                </td>
	            </tr>
	            <tr>
	                <td>
	                    <marquee height="100%" loop="infinite" scrollamount="5" align="middle" direction="left" onmouseout="this.start();" onmouseover="this.stop();">
	                    <img src="../Media_front/images/Attendance_90.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/alumni_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/Admission_and_Promotion_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/alumni_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/Discipline_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/Exam_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/internal_mailing_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/Payroll_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/report_card_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/School_Schedule_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/virtual_classromm_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/campus_management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/hostel_management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/Library_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/Timetable_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/Syllabus_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="../Media_front/images/Profile_Management_256.jpg" width="100px" height="100px" alt="" />	                    
	                    </marquee>
	                </td>
	            </tr>
	            <tr>
	                <td style="height:50px">
	                    
	                </td>
	            </tr>
		    </table> 
        </div>
	    <div class="footer">
		    <p align="center" style="color:white;margin-top:0px;font-size:12px;text-align:center"> All rights reserved KL Suria Sdn Bhd - 2013 </p>
	    </div>
    </form>
</body>
</html>
