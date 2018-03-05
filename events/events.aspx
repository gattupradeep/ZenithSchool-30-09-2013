<%@ Page Language="C#" AutoEventWireup="true" CodeFile="events.aspx.cs" Inherits="school_events" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/admin_events.ascx" tagname="admin_events" tagprefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" media="screen" rel="stylesheet" type="text/css" />  
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>
	
	<!-- for color picker -->
    <script type="text/javascript" src="JqEventsCalendar/js/colorpicker/colorpicker.js"></script>
    <link rel="stylesheet" type="text/css" href="JqEventsCalendar/css/colorpicker/colorpicker.css" />
    <!-- for color picker -->
    
    <script type="text/javascript">
        $(document).ready(function() {
            $("#colorSelectorBackground").ColorPicker({
                //color: "#333333",
                onShow: function(colpkr) {
                    $(colpkr).css("z-index", "10000");
                    $(colpkr).fadeIn(500);
                    return false;
                },
                onHide: function(colpkr) {
                    $(colpkr).fadeOut(500);
                    return false;
                },
                onChange: function(hsb, hex, rgb) {
                    $("#colorSelectorBackground div").css("backgroundColor", "#" + hex);
                    $("#txtbackgroundcolor").val("#" + hex);
                }
            });
            //$("#colorBackground").val("#1040b0");		
            $("#colorSelectorForeground").ColorPicker({
                //color: "#ffffff",
                onShow: function(colpkr) {
                    $(colpkr).css("z-index", "10000");
                    $(colpkr).fadeIn(500);
                    return false;
                },
                onHide: function(colpkr) {
                    $(colpkr).fadeOut(500);
                    return false;
                },
                onChange: function(hsb, hex, rgb) {
                    $("#colorSelectorForeground div").css("backgroundColor", "#" + hex);
                    $("#txttextcolor").val("#" + hex);
                }
            });
        });
        $(function() {
        var dates = $("#txtfromdate,#txttodate").daterangepicker({
        constrainDates: true,
                dateFormat:'dd/mm/yy',
                datepickerOptions: {
                    changeMonth: true,
                    changeYear: true
                }
            });
        });
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></ajaxtoolkit:toolkitscriptmanager>
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
                                        <uc1:admin_events ID="admin_events1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/85.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Add / Edit Events</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td class="title_label" colspan="4">Add / Edit Events</td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Event type:"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddleventtype" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="true" >
                                                    </asp:DropDownList>
                                                    
                                                </td>
                                                <td style="height: 40px" align="center">
                                                    <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="ddleventtype" ErrorMessage="Please Select Event type" InitialValue="0" >
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td style="height: 40px" align="center">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width:160px; height:40px">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Event name:"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txteventname" runat="server" CssClass="s_textbox" 
                                                        Width="150px"></asp:TextBox>
                                                            
                                                </td>
                                                <td style="height: 40px" align="left">
                                                    <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="txteventname" ErrorMessage="Enter an event type" >
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td style="height: 40px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width:160px; height:40px">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Date:"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblfrom" runat="server" Text="From : " CssClass="s_label"></asp:Label><asp:TextBox ID="txtfromdate" runat="server" CssClass="s_textbox" Width="100px"></asp:TextBox>                                                    
                                                </td>
                                                <td style="height: 40px" align="left" colspan="2">
                                                    <asp:Label ID="tolabel" runat="server" Text="To : " CssClass="s_label"></asp:Label>
                                                    <asp:TextBox ID="txttodate" runat="server" CssClass="s_textbox" 
                                                        Width="100px" AutoPostBack="True"></asp:TextBox>                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width:160px; height:40px">
                                                    <asp:Label ID="lblbackground" runat="server" CssClass="s_label" 
                                                        Text="Background Color:"></asp:Label></td>
                                                <td align="left" style="width:200px; height:40px">
                                                <div id="colorSelectorBackground" style="width:32px;height:32px"><div id="divbackcolor" runat="server" style="background-color: #333333; width:30px; height:30px; border: 2px solid #000000;"></div></div>                                                   
                                                        <input type="hidden" id="txtbackgroundcolor" runat="server" value="#333333" />
                                                </td>
                                                <td align="left" >
                                                    &nbsp;</td>
                                                <td align="left"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width:160px; height:40px">
                                                    <asp:Label ID="lblforeground" runat="server" CssClass="s_label" Text="Text Color:"></asp:Label></td>
                                                <td align="left" style="width:200px; height:40px">
                                                <div id="colorSelectorForeground" style="width:32px;height:32px"><div id="divtextcolor" runat="server" style="background-color: #ffffff; width:30px; height:30px; border: 2px solid #000000;"></div></div>
                                                    <input type="hidden" id="txttextcolor" runat="server" value="#ffffff" />
                                                </td>
                                                <td align="left" >&nbsp;</td>
                                                <td align="left" >&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" >&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                        Width="60px" onclick="btnSave_Click"/>
                                                    &nbsp;
                                                    <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" 
                                                        Width="60px" onclick="btnClear_Click" CausesValidation="False" />
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 40px" align="left">
                                                    <asp:DataGrid ID="dgevents" runat="server" AutoGenerateColumns="False" 
                                                       Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="4" 
                                                        oneditcommand="dgevents_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle  CssClass="s_datagrid_item"/>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="event_id" HeaderText="ID" Visible="False"></asp:BoundColumn>                                                            
                                                            <asp:BoundColumn DataField="title" HeaderText="Event type">
                                                            </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="description" HeaderText="Event name">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="event_start" HeaderText="Start Date"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="event_end" HeaderText="End Date"></asp:BoundColumn>                                                            
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="40px" />
                                                            </asp:ButtonColumn>
                                                            <asp:TemplateColumn HeaderText="Delete">
                                                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btndelete" runat="server" 
                                                                        ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                                    OnClientClick="return confirm('Are you sure you want to delete this record?')" onclick="btndelete_Click" 
                                                                         />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete"  Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>--%>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                    </asp:DataGrid>
                                                 </td>
                                            </tr>
                                        </table>
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
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>