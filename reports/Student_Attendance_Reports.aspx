<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student_Attendance_Reports.aspx.cs" Inherits="reports_CR_Student_Attendance_Student_Attendance_Reports" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
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
        var dates = $("#Attnd_Date").datepicker({
        changeMonth: true,
        changeYear: true
        });
     });
	</script>
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/48.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Student Attendance Reports</td>                                                                 
                                                <td style="width: 60px; height: 50px">
                                                    &nbsp;</td>
                                                <td style="width: 100px; height: 50px" align="center">
                                                    <asp:Label ID="Label" runat="server" Font-Bold="true" CssClass="title_label" Text="Class & Section"></asp:Label>
                                                </td>
                                                 <td style="width: 110px; height: 50px" align="center">  
                                                    <asp:TextBox ID="classandsec" runat="server" ReadOnly="true"></asp:TextBox>
                                                     <ajaxtoolkit:PopupControlExtender ID="TextBox1_PopupControlExtender" runat="server"
                                                        Enabled="True" ExtenderControlID="" TargetControlID="classandsec" 
                                                        PopupControlID="stdandsec" OffsetY="22">
                                                     </ajaxtoolkit:PopupControlExtender>
                                                    <asp:Panel ID="stdandsec" runat="server" ScrollBars="Vertical" Height="150" BackColor="white" BorderColor="#1874CD" BorderWidth="1px">
                                                    <asp:CheckBox ID="chkAll" runat="server" Text="Select All" CssClass="s_dropdown" style="float:left;margin-left:3px;"  />
                                                    <asp:Button ID="btnsend" runat="server" CssClass="s_button" OnClick="chklstandard_SelectedIndexChanged" Text="Apply"/>
                                                    <asp:CheckBoxList ID="chklstandard" runat="server" CssClass="s_dropdown" 
                                                            Width="170px" >
                                                    </asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                                <td style="width: 60px; height: 50px">
                                                    &nbsp;&nbsp;</td>
                                                
                                                <td style="width: 100px; height: 50px" align="center">
                                                    <asp:Label runat="server" Font-Bold="true" ID="Label2" Text="Academic Year" CssClass="title_label"></asp:Label>
                                                </td>
                                                <td style="width: 150px; height: 50px" align="center">    
                                                    <asp:DropDownList ID="ddlacademicyear" runat="server" CssClass="s_dropdown" 
                                                        Width="70px" onselectedindexchanged="ddlacademicyear_SelectedIndexChanged" >
                                                    </asp:DropDownList>
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
                                <tr>
                                    <td align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="905px" class="thick_curve">
                                            <tr class="view_detail_subtitle_bg">
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="subtitle_label"  
                                                        Text="Sort Report by"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 905px; height: 20px" align="center">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="800">
                                                        <tr>
                                                            <td style="height: 1px" align="right" colspan="4">
                                                                <asp:Label ID="lblsunday" runat="server" visible="false" CssClass="s_label" Text=""></asp:Label>
                                                            </td>
                                                        </tr>                                                        
                                                        <tr>
                                                            <td style="width: 155px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label17" runat="server" CssClass="s_label" 
                                                                    Text="Report for Date :"></asp:Label>
                                                            </td>
                                                            <td style="height: 30px" align="left">                                                                
                                                                <asp:TextBox ID="Attnd_Date" Width="90px" runat="server" CssClass="s_textbox" 
                                                                    ontextchanged="Attnd_Date_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <%--<ajaxtoolkit:CalendarExtender ID="Attnd_Date_CalendarExtender" runat="server" 
                                                                    CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="Attnd_Date" 
                                                                    TargetControlID="Attnd_Date"></ajaxtoolkit:CalendarExtender >--%>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>                                                        
                                                            <td style="width: 155px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label16" runat="server" CssClass="s_label" 
                                                                    Text="Report for Month :"></asp:Label>
                                                            </td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:DropDownList ID ="month_year" runat ="server" 
                                                                    onselectedindexchanged="month_year_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>    
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 155px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Report for :"></asp:Label>
                                                            </td>
                                                            <td style="height: 30px;width: 235px;" align="left">
                                                                <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="From Month:"></asp:Label>
                                                                    <asp:DropDownList ID ="from_year" runat ="server"></asp:DropDownList>
                                                                
                                                            </td>
                                                            <td><asp:Label ID="Label15" runat="server" CssClass="s_label" Text="To Month :"></asp:Label>
                                                                <asp:DropDownList ID ="to_year" runat ="server" 
                                                                    onselectedindexchanged="to_year_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 155px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label runat="server" ID="lblg" Text="Student name :" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 30px;width: 235px;" align="left">
                                                                <asp:DropDownList ID="ddlname" runat="server" CssClass="s_dropdown" 
                                                                    Width="170px" onselectedindexchanged="ddlname_SelectedIndexChanged" AutoPostBack="true" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 230px" align="right">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto" style="width:903px;">
                                            <tr class="view_detail_title_bg">
                                                <td align="left"><asp:Label ID="lbltitle" runat="server" Text="Reports" CssClass="title_label"></asp:Label> </td>
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

