﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="staffattendance-report1.aspx.cs" Inherits="detailsrecord_staffattendance_report" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="~/usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/detailsrecord_staff.ascx" tagname="detailsrecord_staff" tagprefix="uc1" %>

<%@ Register src="../usercontrol/admin_attendance.ascx" tagname="admin_attendance" tagprefix="uc1" %>

<%@ Register assembly="Highchart" namespace="Highchart.UI" tagprefix="cc2" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />  
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <script type="text/javascript" src="../Resources/Fancybox/jquery.fancybox-1.3.2.pack.js"></script>
    <script type="text/javascript" src="../Resources/Fancybox/jquery.easing-1.3.pack.js"></script>
    <link rel="stylesheet" href="../Resources/Fancybox/jquery.fancybox-1.3.2.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../Resources/css/shCoreDefault.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../Resources/css/style.css" type="text/css" media="screen" />
    <script type="text/javascript">

        $(document).ready(function() {
            $("a.linkcode").fancybox();
        });
    
    </script>
    <script type="text/javascript">
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtdate').datepicker({ dateFormat: 'yy/mm/dd',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(function() {
            var dates = $("#txtdate").datepicker({
                constrainDates: true,
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true
            });
        }); 
    </script>
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
    <script type="text/javascript">
<!--
        function popup(url) {
            var width = 400;
            var height = 200;
            var left = (screen.width - width) / 2;
            var top = (screen.height - height) / 2;
            var params = 'width=' + width + ', height=' + height;
            params += ', top=' + top + ', left=' + left;
            params += ', directories=no';
            params += ', location=no';
            params += ', menubar=no';
            params += ', resizable=no';
            params += ', scrollbars=no';
            params += ', status=no';
            params += ', toolbar=no';
            newwin = window.open(url, 'windowname5', params);
            if (window.focus) { newwin.focus() }
            return false;
        }
// -->
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
                                <tr id="trsidemenu" runat="server">
                                    <td style="width: 230px" align="right">
                                        <uc1:admin_attendance ID="admin_attendance1" runat="server" />
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15PX" align="right">
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
                        <td style="width: 93%;" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/48.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Staff Attendance Search | View</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td  valign="top" align="left" style="padding-left:10px">
                                       <%-- <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                <ProgressTemplate>
                                                    <div id="progressBackgroundFilter"></div>
                                                        <div id="processMessage">
                                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                                        </div>
                                                </ProgressTemplate>
                                         </asp:UpdateProgress>--%>
                                         <asp:UpdatePanel ID="updatepanal" runat="server" >
                                                <ContentTemplate>
                                                     <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 100%;">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 100px; height: 40px" align="left">
                                                                <asp:Label ID="Label24" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtdate" runat="server" CssClass="s_textbox" Width="170px" ontextchanged="txtdate_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 110px; height: 40px" align="">
                                                                <asp:Label ID="Label22" runat="server" CssClass="s_label" 
                                                                    Text="Staff Type"></asp:Label>
                                                            </td>
                                                            <td style="width: 170px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlstafftype" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlstafftype_SelectedIndexChanged1" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 110px; height: 40px" align="">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" 
                                                                    Text="Staff Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 170px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlstaffname" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" AutoPostBack="True" onselectedindexchanged="ddlstaffname_SelectedIndexChanged" 
                                                                    ></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%; height: 10px" align="left"></td>
                                            </tr>
                                           <tr>
                                                <td style="width: 100%" align="left">
                                                    <table cellpadding="0" cellspacing="0"  class="curve" width="950">
                                                         <tr id="tr1" runat="server" class="view_detail_subtitle_bg">
                                                            <td style="width: 950px; height: 40px; color: Black; font-weight: bold;  padding-left: 10px"  align="left" class="s_label">
                                                            <asp:Label ID="Label25" runat="server" Text="Staff Type :" 
                                                                    CssClass="s_label" ForeColor="Black"></asp:Label>
                                                                &nbsp;<asp:Label ID="lblstafftype" runat="server"></asp:Label>&nbsp; | Date :
                                                                
                                                                <asp:Label ID="lbldate" runat="server"></asp:Label>
                                                                <asp:Label ID="lblsunday" runat="server" CssClass="s_label" Visible="False" 
                                                                    Text="-1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 950px; height: 20px"></td>
                                                        </tr>
                                                        <tr id="tr2" runat="server">
                                                            <td style="width: 950px; padding: 0px 10px 0px 10px" align="left" class="s_label">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 950px">
                                                                          <div>        
                                                                            <center>
                                                                                <div class="chartcontainerarea" >
                                                                                 <%--   <cc2:ColumnChart ID="hcVendas" Width="100%" Height="250px" runat="server" ></cc2:ColumnChart>--%>
                                                                                  <cc2:ColumnChart ID="hcVendas" Width="100%" Height="250px" runat="server" 
                                                                                        EnableViewState="False" ></cc2:ColumnChart>
                                                                                </div>
                                                                            </center>
                                                                          </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 950px; height: 20px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 950px">
                                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                                <tr>
                                                                                    <td style="width: 450px" valign="top">
                                                                                        <asp:DataGrid ID="dgattendance" runat="server" CellPadding="4" 
                                                                                            ForeColor="#333333" GridLines="None" Width="450px" AutoGenerateColumns="False">
                                                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                                                        <ItemStyle CssClass="s_datagrid_item"/>
                                                                                        <Columns>
                                                                                        <asp:BoundColumn DataField="desc1" HeaderText="Attendance Summary">
                                                                                            <ItemStyle Width="350px" />
                                                                                        </asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="ct" HeaderText="Number">
                                                                                            <ItemStyle Width="100px" />
                                                                                        </asp:BoundColumn>
                                                                                        </Columns>
                                                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                                                        </asp:DataGrid>
                                                                                    </td>
                                                                                    <td style="width: 50px">&nbsp;</td>
                                                                                    <td style="width: 450px" valign="top">
                                                                                        <asp:DataGrid ID="dgleave" runat="server" CellPadding="4" 
                                                                                            ForeColor="#333333" GridLines="None" Width="450px" 
                                                                                            AutoGenerateColumns="False">
                                                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                                                        <ItemStyle CssClass="s_datagrid_item"/>
                                                                                        <Columns>
                                                                                        <asp:BoundColumn DataField="strleavetype" HeaderText=" Leave Type">
                                                                                            <ItemStyle Width="250px" />
                                                                                        </asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="intnoofdays" HeaderText="Total Leaves">
                                                                                            <ItemStyle Width="100px" />
                                                                                        </asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="avail" HeaderText="Available Leaves">
                                                                                            <ItemStyle Width="100px" />
                                                                                        </asp:BoundColumn>
                                                                                        </Columns>
                                                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                                                        </asp:DataGrid>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 950px; height: 20px"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px" align="left">
                                                </td>
                                            </tr>
                                            <tr id="tr3" runat="server">
                                                <td style="height: 40px" align="left">
                                                    <table style="width:100%">
                                                        <tr>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="lblmonthandyear" runat="server" CssClass="s_label"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                           <td style="height: 40px" align="left">
                                                                <asp:DataGrid ID="dgattendancedetail" runat="server" CellPadding="4" 
                                                                ForeColor="#333333" Width="450px" AutoGenerateColumns="False">
                                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                                <ItemStyle CssClass="s_datagrid_item"/>
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="staffname" HeaderText="Name">
                                                                        <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                            Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
                                                                        </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c1" HeaderText="1"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c2" HeaderText="2"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c3" HeaderText="3"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c4" HeaderText="4"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c5" HeaderText="5"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c6" HeaderText="6"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c7" HeaderText="7"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c8" HeaderText="8"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c9" HeaderText="9"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c10" HeaderText="10"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c11" HeaderText="11"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c12" HeaderText="12"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c13" HeaderText="13"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c14" HeaderText="14"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c15" HeaderText="15"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c16" HeaderText="16"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c17" HeaderText="17"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c18" HeaderText="18"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c19" HeaderText="19"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c20" HeaderText="20"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c21" HeaderText="21"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c22" HeaderText="22"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c23" HeaderText="23"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c24" HeaderText="24"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c25" HeaderText="25"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c26" HeaderText="26"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c27" HeaderText="27"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c28" HeaderText="28"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c29" HeaderText="29"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c30" HeaderText="30"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="c31" HeaderText="31"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="present" HeaderText="P" DataFormatString="{0:0.0}">
                                                                    <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                            Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Absent" HeaderText="A" DataFormatString="{0:0.0}">
                                                                    <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                            Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Percentage" HeaderText="%">
                                                                    <ItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                                                                            Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
                                                                    </asp:BoundColumn>
                                                                </Columns>
                                                                <HeaderStyle CssClass="s_datagrid_header"/>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 40px" align="left">
                                            </td>
                                        </tr>
                                    </table>
                                                </ContentTemplate>
                                         </asp:UpdatePanel>
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
