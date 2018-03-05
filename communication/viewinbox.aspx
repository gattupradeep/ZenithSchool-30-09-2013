<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewinbox.aspx.cs" Inherits="communication_viewinbox" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/internal_messaging.ascx" tagname="internal_messaging" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
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
    <style type="text/css">
        .style1
        {
            width: 100px;
            height: 40px;
        }
        .style2
        {
            height: 40px;
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
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="230">
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc1:internal_messaging ID="internal_messaging1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/88.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > View&nbsp; Mail</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto">
                                            <tr>
                                                <td>
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                        <tr class="view_detail_title_bg">
                                                            <td  style="height: 30px" align="left" colspan="2"><input type="button" class="s_button" value="Back" onclick="javascript:history.go(-1)" /> &nbsp;&nbsp;<asp:Label ID="Labelname" runat="server" CssClass="title_label">View Mail</asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style1">
                                                                <asp:Label runat="server" CssClass="s_label" Text="From" Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td align="left" class="style2">
                                                                : <asp:Label ID="lblfrom" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                        </tr>
                                                       <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="To" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                : <asp:Label ID="lblto" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                        </tr>
                                                       <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Subject" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                : <asp:Label ID="lblsubject" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Message" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                : <asp:Label ID="lblmessage" runat="server" CssClass="s_label_value"></asp:Label>
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
            <td style="width: 100%;" align="left" valign="top">
                                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
     <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
