<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>The schools</title>
		
		<link rel="stylesheet" type="text/css" href="media/css/loginpage.css" />
		<link rel="stylesheet" type="text/css" href="media/css/styles.css" />
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
	                        <img src="media/images/logonew.jpg" alt="Logo" />	                                                
	                    </td>
	                    <td valign="bottom" align="left">
	                        <table>
	                            <tr>
	                                <td><span style="font-size:28px;color:Red">ZENITH INTERNATIONAL SCHOOL</span></td>
	                            </tr>
	                            <tr>
	                                <td align="center"><span style="font-size:15px;color:#274257">Learning for Life</span></td>
	                            </tr>
	                        </table>
	                    </td>
	                    <%--
	                    <td align="right">
		                       <img src="media/images/logo_product.png" alt="Logo" />
		                </td>--%>
	                </tr>
	            </table>
		        
	        </div>
	        <table cellpadding="0" cellspacing="0" width="100%" class="thick_border">
	            <tr>
	                <td>
	                    <div style="padding-top:5px;" align="center">
		                    <div style="margin-bottom:30px;">
		                        <div>
		                            <table border="0" cellspacing="0" cellpadding="0" width="100%">			
			                            <tr >
				                            <td colspan="2" align="center" >
				                                <a href="login.aspx"><img src="Media_front/images/adminlogin.jpg" alt="Admin Login"/></a>
				                            </td>
				                            <td colspan="2" align="center" >
				                                <a href="admin/login.aspx"><img src="Media_front/images/parent-teacher-student-conference.jpg" alt="Admin Login"/></a>
				                            </td>
			                            </tr>
			                            <!-- Container sources end -->
                            			
			                            <!-- Bottom resources start main tr -->
			                            <%--<uc1:uc_footer_resource ID="uc_fot_res" runat="server" />--%>
                            			
			                            <!-- Bottom resources end -->
		                            </table>
		                        </div>
		                    </div>
		                    
                        </div>
	                </td>
	            </tr>
	            <tr>
	                <td>
	                    <marquee height="100%" loop="infinite" scrollamount="5" align="middle" direction="left" onmouseout="this.start();" onmouseover="this.stop();">
	                    <img src="Media_front/images/Attendance_90.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/alumni_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/Admission_and_Promotion_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/alumni_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/Discipline_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/Exam_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/internal_mailing_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/Payroll_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/report_card_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/School_Schedule_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/virtual_classromm_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/campus_management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/hostel_management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/Library_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/Timetable_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/Syllabus_Management_256.jpg" width="100px" height="100px" alt="" />
	                    <img src="Media_front/images/Profile_Management_256.jpg" width="100px" height="100px" alt="" />	                    
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
