<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/activities_reminder.ascx" tagname="activities_reminder" tagprefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JqEventsCalendar/scripts/calendarscript.js"></script>
    <link href="JqEventsCalendar/cupertino/jquery-ui-1.7.3.custom.css" rel="stylesheet" type="text/css" />
    <link href="JqEventsCalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
    <script src="JqEventsCalendar/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="JqEventsCalendar/jquery/jquery-ui-1.7.3.custom.min.js" type="text/javascript"></script>
    <script src="JqEventsCalendar/jquery/jquery.qtip-1.0.0-rc3.min.js" type="text/javascript"></script>
    <script src="JqEventsCalendar/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
    <script src="JqEventsCalendar/fullcalendar/fullcalendar.js" type="text/javascript"></script>
    <script src="JqEventsCalendar/jquery/jquery-ui-timepicker-addon-0.6.2.min.js" type="text/javascript"></script>
    <!-- for color picker -->
    <script type="text/javascript" src="JqEventsCalendar/js/colorpicker/colorpicker.js"></script>
    <link rel="stylesheet" type="text/css" href="JqEventsCalendar/css/colorpicker/colorpicker.css" />
    <!-- for color picker -->
    <%--<script type="text/javascript">
        function dropvalue() {
            var title = document.getElementById("<%=addEventName.ClientID %>");
            document.getElementById("titlevalue").value = title.options[title.selectedIndex].text;
            ;
        }
        function dropvalueupdate() {
            var title = document.getElementById("<%=eventName.ClientID %>");
            document.getElementById("titlevalue").value = title.options[title.selectedIndex].text;
            ;
        }
    </script>--%>
    <style type='text/css'>
        #calendar
        {
            width: 98%;
            height:100%;
            margin: 0 auto;
        }
        /* css for timepicker */
        .ui-timepicker-div dl
        {
            text-align: left;
        }
        .ui-timepicker-div dl dt
        {
            height: 25px;
        }
        .ui-timepicker-div dl dd
        {
            margin: -25px 0 10px 65px;
        }        
        /* table fields alignment*/
        .alignRight
        {
        	text-align:right;
        	padding-right:10px;
        	padding-bottom:10px;
        }
        .alignLeft
        {
        	text-align:left;
        	padding-bottom:10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
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
                                        <uc1:activities_reminder ID="activities_reminder1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/220.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left"><asp:Label ID="lbltitle" runat="server" Text="Add / Edit / Delete Reminder"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td><div id="calendar">
                                        </div></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; padding-left: 10px" valign="top" align="left">
                                        <div id="updatedialog" style="font: 70% 'Trebuchet MS', sans-serif; margin: 50px;"
                                            title="Update or Delete Reminder">
                                            <table cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td class="alignRight s_label">
                                                        Reminder Title:</td>
                                                    <td class="alignLeft">
                                                        <%--<input id="eventName" type="text" class="s_textbox" />--%>
                                                        
                                                        <br />
                                                        <asp:TextBox ID="eventName" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="alignRight s_label">
                                                        Reminder Name:</td>
                                                    <td class="alignLeft">
                                                        <textarea id="eventDesc" cols="30" rows="3" class="s_textbox" ></textarea></td>
                                                </tr>
                                                <tr>
                                                    <td class="alignRight s_label">
                                                        start:</td>
                                                    <td class="alignLeft">
                                                        <span id="eventStart"></span></td>
                                                </tr>
                                                <tr>
                                                    <td class="alignRight s_label">
                                                        end: </td>
                                                    <td class="alignLeft">
                                                        <span id="eventEnd"></span><input type="hidden" id="eventId" /></td>
                                                </tr>
                                                <tr>
						                            <td>
							                            <label>Background Color</label>
						                            </td>
						                            <td>
							                            <div id="updatecolorSelectorBackground"><div style=" width:10px; height:10px; border: 2px solid #000000;"></div>
							                            <input type="text" id="updatecolorBackground" /></div>
						                            </td>
						                        </tr>
						                        <tr>
						                            <td>
							                            <label>Text Color</label>
						                            </td>
						                            <td>
							                            <div id="updatecolorSelectorForeground"><div style=" width:10px; height:10px; border: 2px solid #000000;"></div>
							                            <input type="text" id="updatecolorForeground"  /></div>
						                            </td>						
					                            </tr>
                                            </table>
                                        </div>
                                        <div id="addDialog" style="margin: 50px;"  title="Add Reminder" >
                                        <table cellpadding="0" >
                                                <tr>
                                                    <td class="alignRight s_label">
                                                        Reminder Title:</td>
                                                    <td class="alignLeft">
                                                        <%--<input id="addEventName" type="text" size="20" class="s_textbox" /><br />--%>
                                                        <asp:TextBox ID="addEventName" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td class="alignRight s_label">
                                                        Reminder Name:</td>
                                                    <td class="alignLeft">
                                                        <textarea id="addEventDesc" cols="30" rows="3" class="s_textbox" ></textarea></td>
                                                </tr>
                                                <tr>
                                                    <td class="alignRight s_label">
                                                        start:</td>
                                                    <td class="alignLeft">
                                                        <span id="addEventStartDate" ></span></td>
                                                </tr>
                                                <tr>
                                                    <td class="alignRight s_label">
                                                        end:</td>
                                                    <td class="alignLeft">
                                                        <span id="addEventEndDate" ></span></td>
                                                </tr>
                                                <tr>
						                            <td>
							                            <label>Background Color</label>
						                            </td>
						                            <td>
							                            <div id="colorSelectorBackground"><div style="background-color: #333333; width:30px; height:30px; border: 2px solid #000000;"></div></div>
							                            <input type="hidden" id="colorBackground" value="#333333" />
						                            </td>
						                        </tr>
						                        <tr>
						                            <td>
							                            <label>Text Color</label>
						                            </td>
						                            <td>
							                            <div id="colorSelectorForeground"><div style="background-color: #ffffff; width:30px; height:30px; border: 2px solid #000000;"></div></div>
							                            <input type="hidden" id="colorForeground" value="#ffffff" />
						                            </td>						
					                            </tr>
                                            </table>
                                        </div>
                                        <div runat="server" id="jsonDiv" />
                                        <input type="hidden" id="hdClient" runat="server" />
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%"  valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>