<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student_Timetable_Report.aspx.cs" Inherits="reports_Student_Timetable_Report" %>
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
                        <td class="app_cont_title_img_td"><img src="../images/icons/50X50/54.png" class="app_cont_title_img" alt="icon" /></td>
                        <td align="left" >Student's Timetable Reports</td>                        
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
                            <table cellpadding="5" cellspacing="0" border="0" width="905px">
                                <tr class="view_detail_subtitle_bg">
                                    <td colspan="8" style="width: 230px; height: 30px" align="left">&nbsp;&nbsp;
                                        <asp:Label ID="Label1" runat="server" CssClass="reportsortyby" Text="Sort Report by"></asp:Label>
                                    </td>
                                </tr> 
                                <tr>
                                    <td>
                                        <asp:Label ID="lblclass" runat="server" CssClass="s_label" Text="Class"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_textbox" 
                                            Width="130px" AutoPostBack="True" 
                                            onselectedindexchanged="ddlclass_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbldays" runat="server" CssClass="s_label" Text="Days"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddldays" runat="server" CssClass="s_textbox" 
                                            Width="130px" AutoPostBack="True" 
                                            onselectedindexchanged="ddldays_SelectedIndexChanged"></asp:DropDownList>
                                    </td>                                    
                                    <td>
                                        <asp:Label ID="lblsubject" runat="server" CssClass="s_label" Text="Subject"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_textbox"  AutoPostBack="true"
                                            Width="130px" onselectedindexchanged="ddlsubject_SelectedIndexChanged"></asp:DropDownList>
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
