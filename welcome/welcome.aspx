﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="welcome_welcome" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

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
            $('#txtworkftime').timepicker();
        });
        $(document).ready(function() {
            $('#txtworktotime').timepicker();
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
                                        &nbsp;</td>
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
                                                <td style="width: 50px; height: 50px"><img src="../media/images/moduleimg1.jpg" width="50" height="50" /></td>
                                                <td style="width: 685px; height: 50px; font-family: Arial; font-size: 23px; color: #2DA0ED; padding-left: 10px" align="left">
                                                                                                        Students Panel</td>
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
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="710">
                                            <tr>
                                                <td style="width: 710px; height: 400px" align="left" valign="top">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="952">
                                                        <tr>
                                                            <td style="width: 700px; height: 400px" valign="top" align="left">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="690">
                                                                    <tr>
                                                                        <td style="width: 690px; height: 40px; background-image: url(../media/images/welcometotheschools.png); background-repeat:no-repeat"></td>
                                                                    </tr>
                                                                    <tr><td style="width: 690px; height: 1px; background-color: #b3b3b3"></td></tr>
                                                                    <tr><td style="width: 690px; height: 10px"></td></tr>
                                                                    <tr>
                                                                        <td style="width: 690px; height: 100px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="690">
                                                                                <tr>
                                                                                    <td style="width: 120px; height: 105px" align="right"><img src="../media/images/icon01.gif" alt="Notice Board" /></td>
                                                                                    <td style="width: 20px; height: 105px"></td>
                                                                                    <td style="width: 550px; height: 105px"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 2px; height: 400px; background-color: #b3b3b3"></td>
                                                            <td style="width: 250px; height: 400px"></td>
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
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%; " align="left" valign="top" >
                    
                 <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
     <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>