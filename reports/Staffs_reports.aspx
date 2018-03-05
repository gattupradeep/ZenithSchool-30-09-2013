<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Staffs_reports.aspx.cs" Inherits="reports_Staffs_reports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/detailsrecord_staff.ascx" tagname="detailsrecord_staff" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxtoolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />    
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>
    <script type="text/javascript">
         $(function() {
             var dates = $("#DOBfromdate,#DOBtodate").daterangepicker({
                 constrainDates: true,
                 datepickerOptions: {
                     changeMonth: true,
                     changeYear: true
                 }
             });
         });
	</script>
	<script type="text/javascript">
	    $(function() {
	    var dates = $("#DOJFromdate,#DOJTodate").daterangepicker({
	            constrainDates: true,
	            datepickerOptions: {
	                changeMonth: true,
	                changeYear: true
	            }
	        });
	    });
	</script>
	<style type="text/css">
        
        #bttnget
        {
        	display:none;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
   <div>
       <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
       </asp:ToolkitScriptManager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 100%;" align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" valign="top">
                <uc2:topmenu ID="topmenu1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 50px" align="left">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr class="app_container_title">
                        <td class="app_cont_title_img_td"><img src="../images/icons/50X50/18.png" class="app_cont_title_img" alt="icon" /></td>
                        <td align="left" >Staff Reports</td>
                        <td style="width: 900px; height: 50px;" align="left">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 20px"></td>
                                    <td style="width: 150px; height: 50px" align="left" >
                                        <asp:Label ID="lbl1" runat="server" Text="Staff Type" CssClass="title_label"></asp:Label>
                                        <asp:DropDownList ID="ddlstaff" runat="server" CssClass="s_dropdown" Width="150px" onselectedindexchanged="ddlstaff_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    </td>
                                    <td style="width: 20px"></td>
                                    <td style="width: 150px; height: 50px" align="left">
                                        <asp:Label ID="Label2" runat="server" Text="Department" CssClass="title_label"></asp:Label>
                                        <asp:DropDownList ID="ddldepart" runat="server" CssClass="s_dropdown" Width="150px" onselectedindexchanged="ddldepart_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 20px"></td>
                                    <td style="width: 20px"></td>
                                    <td style="width: 150px; height: 50px" align="left">
                                        <asp:Label ID="Label10" runat="server" Text="Staff Name" CssClass="title_label"></asp:Label>
                                        <asp:DropDownList ID="ddlstaffname" runat="server" CssClass="s_dropdown" Width="150px" onselectedindexchanged="ddlstaffname_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>                                                   
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
        </tr>
        <tr>
            <td class="break"></td>
        </tr>
        <tr>
            <td style="width: 100%; height: 50px" align="center">
                <table cellpadding="0" cellspacing="0" border="0" width="905px" class="thick_curve">
                    <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0" border="0" width="905px">
                                <tr>
                                    <td colspan="6" style="width: 230px; height: 30px" align="left">&nbsp;&nbsp;
                                        <asp:Label ID="Label1" runat="server" CssClass="reportsortyby"  
                                                                        Text="Sort Report by"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                        <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Gender"></asp:Label>
                                    </td>
                                    <td style="width: 115px; height: 30px" align="left">
                                        <asp:DropDownList ID="searchbygender" runat="server" CssClass="s_dropdown" 
                                            Width="115px" onselectedindexchanged="searchbygender_SelectedIndexChanged" 
                                            AutoPostBack="True">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="All">All</asp:ListItem>
                                            <asp:ListItem Value="Male">Male</asp:ListItem>
                                            <asp:ListItem Value="Female">Female</asp:ListItem>
                                            
                                        </asp:DropDownList>
                                    </td>
                                
                                    <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                        <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Experience"></asp:Label>
                                    </td>
                                    <td style="width: 115px; height: 30px" align="left">
                                        <asp:DropDownList ID="searchbyExperience" runat="server" CssClass="s_dropdown" 
                                            Width="115px" AutoPostBack="True" 
                                            onselectedindexchanged="searchbyExperience_SelectedIndexChanged">
                                        </asp:DropDownList>
                                           </td>
                                
                                    <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                        <%--<asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Community"></asp:Label>--%>
                                    </td>
                                    <td style="width: 115px; height: 30px" align="left">
                                        <%--<asp:DropDownList ID="searchbycommunity" runat="server" CssClass="s_dropdown" Width="115px" onselectedindexchanged="searchbycommunity_SelectedIndexChanged" AutoPostBack="True">                                                         
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="All">All</asp:ListItem>
                                            <asp:ListItem Value="FC">FC</asp:ListItem>
                                            <asp:ListItem Value="BC">BC</asp:ListItem>                                                        
                                            <asp:ListItem Value="OBC">OBC</asp:ListItem>
                                            <asp:ListItem Value="OC">OC</asp:ListItem>
                                            <asp:ListItem Value="SC/ST">SC/ST</asp:ListItem>
                                            <asp:ListItem Value="Others">Others</asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                        <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Birthday"></asp:Label>
                                    </td>
                                    <td style="width: 115px; height: 30px" align="left">
                                        <asp:DropDownList ID="searchbybirthday" runat="server" CssClass="s_dropdown" 
                                            Width="115px" 
                                            onselectedindexchanged="searchbybirthday_SelectedIndexChanged" 
                                            AutoPostBack="True">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="Today">Today</asp:ListItem>
                                            <asp:ListItem Value="This Week">This Week</asp:ListItem>
                                            <asp:ListItem Value="This Month">This Month</asp:ListItem>
                                            
                                        </asp:DropDownList>
                                    </td>
                                
                                    <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Blood group"></asp:Label></td>
                                    <td style="width: 115px; height: 30px" align="left">
                                        <asp:DropDownList ID="searchbyblood" runat="server" CssClass="s_dropdown" 
                                            Width="115px" onselectedindexchanged="searchbyblood_SelectedIndexChanged" 
                                            AutoPostBack="True"> 
                                              <asp:ListItem Value="0">--Select--</asp:ListItem>
                                              <asp:ListItem Value="All">All</asp:ListItem>
                                              <asp:ListItem Value="O +ve">O +ve</asp:ListItem>
                                              <asp:ListItem Value="A +ve">A +ve</asp:ListItem>
                                              <asp:ListItem Value="O -ve">O -ve</asp:ListItem>
                                              <asp:ListItem Value="A -ve">A -ve</asp:ListItem>
                                              <asp:ListItem Value="B +ve">B +ve</asp:ListItem>
                                              <asp:ListItem Value="AB +ve">AB +ve</asp:ListItem>
                                              <asp:ListItem Value="AB -ve">AB -ve</asp:ListItem>
                                              <asp:ListItem Value="B -ve">B -ve</asp:ListItem>                                                                     
                                        </asp:DropDownList>
                                    </td>
                                
                                    <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                        <asp:Label ID="Label5" runat="server" CssClass="s_label">Transport</asp:Label>
                                    </td>
                                    <td style="width: 115px; height: 30px" align="left">
                                        <asp:DropDownList ID="searchbytransport" runat="server" CssClass="s_dropdown" Width="115px" onselectedindexchanged="searchbytransport_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="All">All</asp:ListItem>
                                        <asp:ListItem Value="School">School</asp:ListItem>
                                        <asp:ListItem Value="Own">Own</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;&nbsp;<asp:Label 
                                            ID="Label16" runat="server" CssClass="s_label" Text="Date Of Birth :"></asp:Label></td>
                                    <td style="width: 135px; height: 30px" align="left">
                                           <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="From Date"></asp:Label>
                                           <asp:TextBox ID="DOBfromdate" Width="80px" runat="server" CssClass="s_textbox"></asp:TextBox>
                                           <%--<ajaxtoolkit:CalendarExtender ID="Calendarextender3" 
                                           runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" 
                                           PopupButtonID="DOBfromdate" TargetControlID="DOBfromdate"></ajaxtoolkit:CalendarExtender >--%>
                                    </td>
                                
                                    <td style="width: 135px; height: 30px" align="left">&nbsp;&nbsp;
                                           <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="To Date"></asp:Label>
                                           <asp:TextBox ID="DOBtodate"  Width="80px" runat="server" 
                                            CssClass="s_textbox" ontextchanged="DOBtodate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <%--<ajaxtoolkit:CalendarExtender ID="Calendarextender1" 
                                           runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd"
                                            PopupButtonID="DOBtodate" TargetControlID="DOBtodate"></ajaxtoolkit:CalendarExtender >--%>
                                        </td>
                                    <td style="width: 115px; height: 30px" align="left">
                                        <asp:Label 
                                            ID="Label19" runat="server" CssClass="s_label" Text="Date of Joined :"></asp:Label></td>
                                
                                   <td style="width: 135px; height: 30px" align="left">     &nbsp;&nbsp;
                                           <asp:Label ID="Label20" runat="server" CssClass="s_label" Text="From Date"></asp:Label>
                                           <asp:TextBox ID="DOJFromdate" Width="70px" runat="server" 
                                           CssClass="s_textbox"></asp:TextBox>
                                          <%-- <ajaxtoolkit:CalendarExtender ID="DOJFromdate_CalendarExtender" 
                                           runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" 
                                           PopupButtonID="DOJFromdate" TargetControlID="DOJFromdate"></ajaxtoolkit:CalendarExtender >--%>
                                        </td>
                                    <td style="width: 135px; height: 30px" align="left">
                                           <asp:Label ID="Label21" runat="server" CssClass="s_label" Text="To Date"></asp:Label>
                                           <asp:TextBox ID="DOJTodate" Width="80px" runat="server" 
                                            CssClass="s_textbox" ontextchanged="DOJTodate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <%-- <ajaxtoolkit:CalendarExtender ID="DOJTodate_CalendarExtender" 
                                            runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" 
                                            PopupButtonID="DOJTodate" TargetControlID="DOJTodate"></ajaxtoolkit:CalendarExtender >--%>
                                           </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center"><asp:Button ID="bttnget" runat="server" Text="Search" Width="50px" CssClass="s_button"  onclick="DOBtodate_TextChanged" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="break"></td>
        </tr>
        <tr>
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 90%" valign="top" align="center">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td valign="top" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto" style="width:905px;">
                                            <tr class="view_detail_title_bg">
                                                <td align="left"><asp:Label ID="lbltitle1" runat="server" Text="Reports" CssClass="title_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 1px" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="905px">
                                                        <tr>
                                                            <td style="width:905px; height: 600px" valign="top" align="left">
                                                             <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                                                                AutoDataBind="true" HasZoomFactorList="False" HasCrystalLogo="False" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="break"></td>
        </tr>
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
