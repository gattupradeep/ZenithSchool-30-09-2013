<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentattendance-report.aspx.cs" Inherits="detailsrecord_studentattendance_report" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/detailsrecord_staff.ascx" tagname="detailsrecord_staff" tagprefix="uc1" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/admin_attendance.ascx" tagname="admin_attendance" tagprefix="uc5" %>

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
                                        <uc5:admin_attendance ID="admin_attendance1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/48.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Student Attendance Report</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="7" cellspacing="0" border="0" class="app_container_auto">
                                            <tr>
                                                <td style="width: 50px; height: 40px" align="left">
                                                    <asp:Label ID="Label22" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                </td>
                                                <td style="width: 160px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlstandard_SelectedIndexChanged"></asp:DropDownList>
                                                </td>                                                    
                                                <td style="width: 50px; height: 40px" align="left">
                                                    <asp:Label ID="Label23" runat="server" CssClass="s_label" Text="Section"></asp:Label>
                                                </td>
                                                <td style="width: 160px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlsection_SelectedIndexChanged" ></asp:DropDownList>
                                                </td>
                                                <td style="width:40px">
                                                    <asp:Label ID="Label24" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                </td>
                                                <td>
                                                <asp:TextBox ID="txtdate" runat="server" CssClass="s_textbox" Width="180px" 
                                                        AutoPostBack="True" ontextchanged="txtdate_TextChanged"></asp:TextBox>
                                                    <ajaxtoolkit:CalendarExtender ID="Calendarextender2" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtadmitdate" TargetControlID="txtdate"></ajaxtoolkit:CalendarExtender >
                                                </td>
                                            </tr>
                                            <tr>
                                               <td style="height: 10px" align="left" colspan="6"></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 40px" align="left" colspan="6">
                                                    <table style="width:100%">
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="Label25" runat="server" CssClass="s_label" Text="Standard :"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblstandard" runat="server" CssClass="s_label"></asp:Label></td>
                                                            <td align="right">
                                                                <asp:Label ID="Label27" runat="server" CssClass="s_label" Text="Section :"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblsection" runat="server" CssClass="s_label"></asp:Label></td>
                                                            <td align="right">
                                                               <asp:Label ID="Label29" runat="server" CssClass="s_label" Text="Home teacher :"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblhometeacher" runat="server" CssClass="s_label"></asp:Label></td>
                                                            <td align="right">
                                                                <asp:Label ID="Label31" runat="server" CssClass="s_label" Text="Date :"></asp:Label>
                                                            </td>
                                                            <td><asp:Label ID="lbldate" runat="server" CssClass="s_label"></asp:Label></td>
                                                        </tr> 
                                                        </table>
                                                     </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 40px" align="left" colspan="6">
                                                    <table style="width:100%">
                                                        <tr>
                                                            
                                                            <td>
                                                                <asp:DataGrid ID="dgattendance" runat="server" CellPadding="4" 
                                                                    ForeColor="#333333" GridLines="None" Width="450" AutoGenerateColumns="false" 
                                                                    onselectedindexchanged="dgattendance_SelectedIndexChanged">
                                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                                <ItemStyle CssClass="s_datagrid_item"/>
                                                                <Columns>
                                                                <asp:BoundColumn DataField="" HeaderText="Attendance summary"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="" HeaderText="Number"></asp:BoundColumn>
                                                                </Columns>
                                                                <HeaderStyle CssClass="s_datagrid_header"/>
                                                                </asp:DataGrid>
                                                           </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td style="height: 40px" align="left" colspan="6">
                                                    <asp:Label ID="Label32" runat="server" CssClass="s_label" Text="Month &amp; Year :"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblmonthandyear" runat="server" CssClass="s_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 40px" align="left" colspan="6">
                                                <asp:DataGrid ID="dgattendancedetail" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="450" AutoGenerateColumns="false">
                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                                <ItemStyle CssClass="s_datagrid_item"/>
                                                                <Columns>
                                                                <asp:BoundColumn DataField="" HeaderText="Name"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="" HeaderText="P"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="" HeaderText="A"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="" HeaderText="%"></asp:BoundColumn>
                                                                </Columns>
                                                                <HeaderStyle CssClass="s_datagrid_header"/>
                                                </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 40px" align="left" colspan="6">
                                                    &nbsp;</td>
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
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
