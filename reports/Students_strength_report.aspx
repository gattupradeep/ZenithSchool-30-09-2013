<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Students_strength_report.aspx.cs" Inherits="reports_Students_strength_report" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />    
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $('#chkAll').click(
             function() {
                 $("INPUT[type='checkbox']").attr('checked', $('#chkAll').is(':checked'));
             });
        });    
     </script>
     <script type="text/javascript">
         $(function() {
             var dates = $("#DOBfromdate,#DOBtodate").daterangepicker({
                 dateFormat: "dd/mm/yy",
                 constrainDates: true,
                 datepickerOptions: {
                     changeMonth: true,
                     yearRange: '1930:2030',
                     maxDate: new Date,
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
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:toolkitscriptmanager>
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
            <td style="width: 98%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 98%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/17.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Student Strength Reports</td>                                                                 
                                                <td style="width: 20px; height: 50px">
                                                    &nbsp;</td>
                                                <td style="width: 110px; height: 50px" align="center">
                                                    <asp:Label ID="Label" runat="server" Font-Bold="true" CssClass="title_label" Text="Class & Section" Width="150px" ></asp:Label>
                                                </td>
                                                 <td style="width: 110px; height: 50px" align="center">  
                                                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
                                                     <ajaxtoolkit:PopupControlExtender ID="TextBox1_PopupControlExtender" runat="server"
                                                        Enabled="True" ExtenderControlID="" TargetControlID="TextBox1" 
                                                        PopupControlID="stdandsec" OffsetY="22">
                                                     </ajaxtoolkit:PopupControlExtender>
                                                    <asp:Panel ID="stdandsec" runat="server" ScrollBars="Vertical" Height="150" BackColor="white" BorderColor="#1874CD" BorderWidth="1px">
                                                    <asp:CheckBox ID="chkAll" runat="server" Text="Select All" CssClass="s_dropdown" style="float:left;margin-left:3px;"  />
                                                    <asp:Button ID="btnsend" runat="server" CssClass="s_button" Text="Apply" onclick="ddlstandard_SelectedIndexChanged" />
                                                    <asp:CheckBoxList ID="ddlstandard" runat="server" CssClass="s_dropdown" Width="170px" >
                                                    </asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table> 
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td style="width: 115px; height: 5px" align="left"></td>
                                </tr>
                                <tr id="trsort" runat="server">
                                    <td align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="905px" class="thick_curve">
                                            <tr>
                                                    <td style="width: 905px; height: 20px" align="center">
                                                        <table cellpadding="0" cellspacing="0" border="0" width="905px">
                                                            <tr class="view_detail_subtitle_bg">
                                                                <td colspan="6" style="width: 230px; height: 30px" align="left">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="subtitle_label" Text="Sort Report by"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                    <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Blood Group"></asp:Label>   
                                                                </td>
                                                                <td style="width: 115px; height: 30px" align="left">
                                                                   <asp:DropDownList ID="searchbyblood" runat="server" CssClass="s_dropdown" 
                                                                        Width="115px" AutoPostBack="True" 
                                                                        onselectedindexchanged="searchbyblood_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="All"></asp:ListItem>
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
                                                                    <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="House Name"></asp:Label>
                                                                </td>
                                                                <td style="width: 115px; height: 30px" align="left">
                                                                    <asp:DropDownList ID="searchbyhouse" runat="server" CssClass="s_dropdown" 
                                                                        Width="115px" AutoPostBack="True" 
                                                                        onselectedindexchanged="searchbyhouse_SelectedIndexChanged">                                                                      
                                                                    </asp:DropDownList>
                                                                </td>
                                                                
                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Gender"></asp:Label>
                                                                </td>
                                                                <td style="width: 115px; height: 30px" align="left">
                                                                    <asp:DropDownList ID="searchbygender" runat="server" CssClass="s_dropdown" 
                                                                        Width="115px" AutoPostBack="True" onselectedindexchanged="searchbygender_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" Text="-Select-"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="All"></asp:ListItem>
                                                                        <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                                                        <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Transport"></asp:Label>
                                                                </td>
                                                                <td style="width: 115px; height: 30px" align="left">
                                                                    <asp:DropDownList ID="searchbytransport" runat="server" CssClass="s_dropdown" 
                                                                        Width="115px" AutoPostBack="True" 
                                                                        onselectedindexchanged="searchbytransport_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" Text="-Select-"></asp:ListItem>
                                                                        <asp:ListItem Value="All" Text="All"></asp:ListItem>                                                        
                                                                        <asp:ListItem Value="School" Text="School"></asp:ListItem>
                                                                        <asp:ListItem Value="Own" Text="Own"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                
                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                    <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Accomodation"></asp:Label>
                                                                </td>
                                                                <td style="width: 115px; height: 30px" align="left">
                                                                    <asp:DropDownList ID="searchbyhostler" runat="server" CssClass="s_dropdown" 
                                                                        Width="115px" AutoPostBack="True" onselectedindexchanged="searchbyhostler_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" Text="-Select-"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="All"></asp:ListItem>
                                                                        <asp:ListItem Value="Hostel Inmates" Text="Hostel Inmates"></asp:ListItem>
                                                                        <asp:ListItem Value="dayscholor" Text="Dayscholor"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                
                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                    <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Birthday"></asp:Label>
                                                                </td>
                                                                <td style="width: 115px; height: 30px" align="left">
                                                                    <asp:DropDownList ID="searchbybirthday" runat="server" CssClass="s_dropdown" 
                                                                        Width="115px" AutoPostBack="True" 
                                                                        onselectedindexchanged="searchbybirthday_SelectedIndexChanged">                                                                           
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                    <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Religion"></asp:Label>
                                                                </td>
                                                                <td style="width: 115px; height: 30px" align="left">
                                                                    <asp:DropDownList ID="searchbyreligion" runat="server" CssClass="s_dropdown" 
                                                                        Width="115px" AutoPostBack="True" 
                                                                        onselectedindexchanged="searchbyreligion_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="All"></asp:ListItem>
                                                                        <asp:ListItem Value="Hindu" >Hindu</asp:ListItem>
                                                                        <asp:ListItem Value="Islam">Islam</asp:ListItem>
                                                                        <asp:ListItem Value="Christian">Christian</asp:ListItem>
                                                                        <asp:ListItem Value="Others">Others</asp:ListItem>                                                                                        
                                                                    </asp:DropDownList>
                                                                </td>
                                                                
                                                                <%--<td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                    <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Community"></asp:Label>
                                                                </td>
                                                                <td style="width: 115px; height: 30px" align="left">
                                                                    <asp:DropDownList ID="searchbycommunity" runat="server" CssClass="s_dropdown" Width="115px" AutoPostBack="True" 
                                                                        onselectedindexchanged="searchbycommunity_SelectedIndexChanged"> 
                                                                         <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                         <asp:ListItem Value="1" Text="All"></asp:ListItem>
                                                                        <asp:ListItem Value="FC">FC</asp:ListItem>
                                                                        <asp:ListItem Value="BC">BC</asp:ListItem>                                                        
                                                                        <asp:ListItem Value="OBC">OBC</asp:ListItem>
                                                                        <asp:ListItem Value="OC">OC</asp:ListItem>
                                                                        <asp:ListItem Value="SC/ST">SC/ST</asp:ListItem>
                                                                        <asp:ListItem Value="Others">Others</asp:ListItem>                                                       
                                                                    </asp:DropDownList>
                                                                </td>--%>
                                                                
                                                                <%--<td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                    
                                                                </td>
                                                                <td style="width: 115px; height: 30px" align="left">
                                                                    
                                                                </td>--%>
                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Date of Birth"></asp:Label>
                                                                </td>
                                                                <td colspan="3" style="height: 30px" align="left">
                                                                    <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="From Date :"></asp:Label>
                                                                    <asp:TextBox ID="DOBfromdate" Width="90px" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                                    <%--<ajaxtoolkit:CalendarExtender ID="Calendarextender3" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="DOBfromdate" TargetControlID="DOBfromdate"></ajaxtoolkit:CalendarExtender >--%>
                                                                    <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="To Date :"></asp:Label>
                                                                    <asp:TextBox ID="DOBtodate"  Width="90px" runat="server" CssClass="s_textbox" 
                                                                        ontextchanged="DOBtodate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                    <%--<ajaxtoolkit:CalendarExtender ID="Calendarextender1" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="DOBtodate" TargetControlID="DOBtodate"></ajaxtoolkit:CalendarExtender >--%>
                                                                    <span style="float:right"><asp:Button ID="bttnget" runat="server" Text="Search" Width="50px" CssClass="s_button"  onclick="DOBtodate_TextChanged" /></span>
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
                                    <td valign="top" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto" style="width:905px;">
                                            <tr class="view_detail_title_bg">
                                                <td><asp:Label ID="lbltitle" runat="server" Text="Reports" CssClass="title_label"></asp:Label> </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 1px" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="905px">
                                                        <tr>
                                                            <td style="width:905px; height: 600px" valign="top" align="left">
                                                             <div id="trmsg" runat="server" visible="false"><asp:Label ID="lblmsg" runat="server" CssClass="s_label"></asp:Label></div>
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
        <tr><td style="height:40px"></td></tr>
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
 </body>
</html>
