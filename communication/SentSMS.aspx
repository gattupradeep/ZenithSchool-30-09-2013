<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SentSMS.aspx.cs" Inherits="communication_SentSMS" %>

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
    <script type="text/javascript">
        $(document).ready(function() {
            $("ul#topnav li").hover(function() { //Hover over event on list item
                $(this).css({ 'background': '#88BB00 url(topnav_active.gif) repeat-x' }); //Add background color + image on hovered list item
                $(this).find("span").show(); //Show the subnav
            }, function() { //on hover out...
                $(this).css({ 'background': 'none' }); //Ditch the background
                $(this).find("span").hide(); //Hide the subnav
            });
        });
    </script>
    <link rel="stylesheet" href="../include/jquery-ui-1.8.14.custom.css" type="text/css" />
    <link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />
    <script type="text/javascript" src="../include/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>    
    <script type="text/javascript">
        $(document).ready(function() {
            $('#txtscheduletime').timepicker();
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
            <td style="width: 100%; height: 144px" align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 80px" valign="top">
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
                        <td style="width: 2%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="750">
                                            <tr>
                                                <td style="width: 50px; height: 50px"><img src="../media/images/moduleimg1.jpg" width="50" height="50" alt="SMS Module" /></td>
                                                <td style="width: 685px; height: 50px; font-family: Arial; font-size: 23px; color: #2DA0ED; padding-left: 10px" align="left">
                                                    Sent SMS</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 20px" valign="top" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="98%">
                                            <tr>
                                                <td>
                                                    <table cellpadding="5" cellspacing="0" border="0" class="curve" style="border-color:#9BBB58;" width="100%">
                                                        <tr style="background-color:#9BBB58">
                                                            <td  style="height: 30px" align="left" colspan="4"><asp:Label ID="Labelname" runat="server" CssClass="s_label" ForeColor="White">Sent SMS</asp:Label></td>
                                                        </tr>
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
                                                                <ajaxtoolkit:CalendarExtender ID="ajaxcallfrom" runat="server" TargetControlID="txtfromdate" CssClass="cal_Theme1" PopupButtonID="txtfromdate" Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lbltodate" runat="server" Text="Todate" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:TextBox ID="txttodate" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                                <ajaxtoolkit:CalendarExtender ID="ajaxcallto" runat="server" TargetControlID="txttodate" CssClass="cal_Theme1" PopupButtonID="txttodate" Format="dd/MM/yyyy"></ajaxtoolkit:CalendarExtender>
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

