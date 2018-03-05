<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_assigned_room_date.aspx.cs" Inherits="admission_View_assigned_room_date" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/internal_messaging.ascx" tagname="internal_messaging" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/admission.ascx" tagname="admission" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>


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
            <td style="width: 100%" valign="top">
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
                                        <uc1:admission ID="admission1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15PX" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            
                            </table>
                        </td>
                        <td style="width: 2%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="750">
                                            <tr>
                                              <td class="app_cont_title_img_td"><img src="../images/icons/50X50/76.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td style="width: 550px; height: 50px">
                                                    View_Assigned_Room_Date</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>--%>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 20px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="710">
                                            <tr>
                                                <td>
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%" class="app_container">
                                                        <tr class="view_detail_title_bg">
                                                            <td  style="height: 30px" align="left" colspan="4"><asp:Label ID="Labelname" runat="server" CssClass="title_label">View Admission Interview</asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                 <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Interview Date" 
                                                                     Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lbldate" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Interview Time" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="lbltime" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                       <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Standard" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblstandard" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label19" runat="server" CssClass="s_label" 
                                                                    Text="Staff Name" Font-Bold="True"></asp:Label>
                                                            </td>
                                                             <td style="height: 40px" align="left">
                                                                <asp:Label ID="lblstaff" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                       <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label17" runat="server" CssClass="s_label" 
                                                                    Text="From Appl" Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblfrom" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label18" runat="server" CssClass="s_label" 
                                                                    Text="To  Appl" Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="lblto" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trbuilding" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Building Name" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                 <asp:Label ID="lblbuild" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Floor" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                                 <td style="height: 40px" align="left">
                                                                <asp:Label ID="lblfloor" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trroom" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Room Name" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblroom" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                &nbsp;</td>
                                                            <td style="height: 40px" align="left">
                                                                     &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                            <td align="center" style="height: 40px" colspan="4">
                                                                <asp:Button ID="btnback" runat="server" Text="Back" CssClass="s_button"  Width="70px" onclick="btnback_Click" />
                                                            </td>
                                                            
                                                          </tr>
                                                       </table>
                                                    </td>                                                
                                                </tr>
                                             <tr>
                                                <td align="center" style="width: 710px; height: 20px">
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
        <tr>
             <td style="width: 100%; height: 50px" align="left" valign="top">
                <uc4:footer ID="footer1" runat="server" />
            </td>
        </tr>
    </table>
     <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>