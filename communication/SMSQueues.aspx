<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMSQueues.aspx.cs" Inherits="communication_SMSQueues" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/admin_attendance.ascx" tagname="admin_attendance" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
<%@ Register src="../usercontrol/internal_messaging.ascx" tagname="internal_messaging" tagprefix="uc4" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Communication</title>
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
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('.s_textbox').datepicker({ dateFormat: 'yy/mm/dd' });
            }
        });
        $(function() {
            var dates = $("#txtfromdate, #txttodate").datepicker({
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                minDate: 0,
                numberOfMonths: 1,
                onSelect: function(selectedDate) {
                    var option = this.id == "txtfromdate" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker"),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });
        });
	</script>
    <script type="text/javascript">
        $(document).ready(function() {
            $('#chkAll').click(
             function() {
                 $("INPUT[type='checkbox']").attr('checked', $('#chkAll').is(':checked'));
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
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="230">
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:internal_messaging ID="internal_messaging1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc5:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Queued SMS</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="height: 100px; padding-left:5px" valign="top" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto">
                                             <tr class="view_detail_title_bg">
                                                <td align="left"><asp:Label ID="Labelname" runat="server" CssClass="title_label">Queued SMS</asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblsmstype" Text="SMS Type" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td  align="left">
                                                                <asp:DropDownList ID="ddlsmstype" runat="server" CssClass="s_dropdown" Width="150px">
                                                                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                                                                    <asp:ListItem Value="Admission">Admission</asp:ListItem>
                                                                    <asp:ListItem Value="Attendance">Attendance</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td  align="left">
                                                                <asp:Label ID="pat1" runat="server" CssClass="s_label" Text="Patron Type"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlpatron" runat="server" Width="150px" CssClass="s_dropdown" >
                                                                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                                                                    <asp:ListItem Value= "All">All</asp:ListItem>
                                                                    <asp:ListItem Value= "Staff">Staff</asp:ListItem>
                                                                    <asp:ListItem Value="Student" Text="Student"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Lablstan" runat="server" Text="Class" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td  align="left">
                                                                <asp:DropDownList ID="ddlstd" runat="server" Width="150px" CssClass="s_dropdown" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">&nbsp;</td>
                                                            <td  align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" >
                                                                <asp:Label ID="Lablsec" runat="server" Text="Department" 
                                                                CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:DropDownList ID="ddldept" runat="server" style="height: 22px" 
                                                                Width="150px" Height="16px" CssClass="s_dropdown" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="Lablsec1" runat="server" Text="Designation" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:DropDownList ID="ddldesig" runat="server" Width="150px" CssClass="s_dropdown">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" >
                                                                <asp:Label ID="lblfromdate" runat="server" Text="From Date" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lbltodate" runat="server" Text="Todate" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:TextBox ID="txttodate" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" align="center" valign="top">
                                                                <asp:DataGrid ID="dgqueuedsms" runat="server" AutoGenerateColumns="False" 
                                                                    Width="100%" >
                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                    <ItemStyle CssClass="s_datagrid_item" />
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="intid" Visible="False" HeaderText="intid">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strpatron" HeaderText="Patron Type">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strsmsbody" HeaderText="Message">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="intuserid" HeaderText="Sender">
                                                                        </asp:BoundColumn>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 710px; height: 20px">&nbsp;</td>
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
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
            </td>
        </tr>
    </table>
     <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
