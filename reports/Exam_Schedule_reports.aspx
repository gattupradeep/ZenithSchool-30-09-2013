<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exam_Schedule_reports.aspx.cs" Inherits="reports_Exam_Schedule_reports" %>
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
         $(document).ready(function() {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             function EndRequestHandler(sender, args) {
                 $('.s_textbox').datepicker({ dateFormat: 'dd/mm/yy' });
             }
         });
        $(function() {
        var dates = $("#txtfromdate,#txttodate").daterangepicker({
        dateFormat:"dd/mm/yy",
        constrainDates:true,
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
        #txtfromdate,#txttodate { float: left; margin-right: 10px; }
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/36.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Exam Schedule</td>                                                                 
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
                                    <td align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="905px" class="thick_curve">
                                            <tr class="view_detail_subtitle_bg">
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="subtitle_label" Text="Sort Report by"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 905px; height: 20px" align="center">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td style=" height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label" runat="server" CssClass="s_label" Text="Class & Section :" Width="150px" ></asp:Label>
                                                            </td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:TextBox ID="txtclass" runat="server" CssClass="s_textbox" ReadOnly="true"></asp:TextBox>
                                                                 <ajaxtoolkit:PopupControlExtender ID="TextBox1_PopupControlExtender" runat="server"
                                                                    Enabled="True" ExtenderControlID="" TargetControlID="txtclass" 
                                                                    PopupControlID="stdandsec" OffsetY="22">
                                                                 </ajaxtoolkit:PopupControlExtender>
                                                                <asp:Panel ID="stdandsec" runat="server" ScrollBars="Vertical" Height="150" BackColor="white" BorderColor="#1874CD" BorderWidth="1px">
                                                                <asp:CheckBox ID="chkAll" runat="server" Text="Select All" CssClass="s_dropdown" style="float:left;margin-left:3px;"  />
                                                                <asp:Button ID="btnsend" runat="server" CssClass="s_button" Text="Apply" 
                                                                        onclick="btnsend_Click"  />
                                                                <asp:CheckBoxList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                                        Width="150px">
                                                                </asp:CheckBoxList>
                                                                </asp:Panel>
                                                            </td>                                                            
                                                            <td style="height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Exam Type :"></asp:Label>
                                                            </td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:DropDownList ID="ddlexamtype" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="true" 
                                                                                onselectedindexchanged="ddlexamtype_SelectedIndexChanged" >
                                                                </asp:DropDownList>
                                                            </td>                                                            
                                                            <td style="height: 30px" align="left">
                                                                <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="Subject :"></asp:Label>
                                                            </td>                                                            
                                                            <td style=" height: 30px" align="left">
                                                                <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_dropdown"  AutoPostBack="true"
                                                                    Width="150px" onselectedindexchanged="ddlsubject_SelectedIndexChanged" >
                                                                </asp:DropDownList>
                                                            </td>                                                            
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="From Date :"></asp:Label>
                                                            </td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:TextBox ID="txtfromdate" Width="100px" runat="server" CssClass="s_textbox" ></asp:TextBox>
                                                            </td>                                                            
                                                            <td style=" height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="To Date :"></asp:Label>
                                                            </td>
                                                            <td style=" height: 30px" align="left">
                                                                <asp:TextBox ID="txttodate"  Width="100px" runat="server" CssClass="s_textbox" ></asp:TextBox><span ><asp:Button ID="bttnget" runat="server" Text="Search" Width="50px" CssClass="s_button" OnClick="bttnsearch_click" /></span>
                                                            </td>                                                            
                                                            <td style=" height: 30px" align="left">
                                                                &nbsp;</td>                                                            
                                                            <td style=" height: 30px" align="left">
                                                                <asp:Button ID="btnreset" runat="server" Text="Reset" CssClass="s_button" 
                                                                    onclick="btnreset_Click" /></td>                                                            
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
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto" style="width:905px">
                                            <tr class="view_detail_title_bg">
                                                <td align="left"><asp:Label ID="lbltitle" runat="server" Text="Reports" CssClass="title_label"></asp:Label> </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 1px" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="905px">
                                                        <tr>
                                                            <td style="width:905px; height: 600px;" valign="top" align="left">
                                                             <div id="trmsg" runat="server" visible="false"><asp:Label ID="lblmsg" runat="server" CssClass="s_label"></asp:Label></div>
                                                             <div style="z-index:9999"><CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
                                                                AutoDataBind="true" HasZoomFactorList="False" HasCrystalLogo="False" /></div>
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