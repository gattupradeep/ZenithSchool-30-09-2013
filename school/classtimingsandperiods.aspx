<%@ Page Language="C#" AutoEventWireup="true" CodeFile="classtimingsandperiods.aspx.cs" Inherits="school_classtimingsandperiods" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc4" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
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
            $('#timepicker_3').timepicker();
        });
        $(document).ready(function() {
            $('#timepicker_4').timepicker();
        });
        $(document).ready(function() {
            $('#timepicker_5').timepicker();
        });
        $(document).ready(function() {
            $('#timepicker_6').timepicker();
        });
        $(document).ready(function() {
            $('#timepicker_7').timepicker();
        });
        $(document).ready(function() {
            $('#timepicker_8').timepicker();
        });
    </script>
    <style type="text/css">
        .style1
        {
            width: 175px;
            height: 40px;
        }
        .style2
        {
            width: 150px;
            height: 40px;
        }
        .style3
        {
            width: 50px;
            height: 40px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div> 
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></ajaxtoolkit:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
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
                                        <uc4:school_profile ID="school_profile1" runat="server" />
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
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >
                                                    Class Timings and Periods</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
                                        <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
                                            <ProgressTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" width="710">
                                                    <tr>
                                                        <td style="width: 710px" align="center">
                                                            <img src="../media/images/Processing.gif" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>    --%>                                 
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td style="width: 100%" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                                        <tr class="view_detail_title_bg" >
                                                            <td colspan="6"  align="left" >
                                                               <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Edit Timings and Periods" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <table cellpadding="10" cellspacing="0" border="0">
                                                                    
                                                                   
                                                                    <tr>
                                                                        <td align="left" class="style1">
                                                                            <asp:Label ID="Label3" runat="server" CssClass="s_label" 
                                                                                Text="Class"></asp:Label>
                                                                            </td>
                                                                        <td align="left" class="style2">
                                                                            <asp:DropDownList ID="ddlclass" runat="server"  CssClass="s_dropdown" 
                                                                                Width="140px" onselectedindexchanged="ddlclass_SelectedIndexChanged" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                            </td>
                                                                        <td align="left" class="style3"> 
                                                                            </td>
                                                                        
                                                                    </tr>
                                                                    <tr>
                                                                      <%--  <td colspan="6">
                                                                            <asp:UpdatePanel ID="up1" runat="server"> 
                                                                                <ContentTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                                <tr>--%>
                                                                                     <td align="left" style="width: 175px; height: 40px;">
                                                                            <asp:Label ID="Label5" runat="server" CssClass="s_label" 
                                                                                Text="No of periods in a day"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 150px; height: 40px">
                                                                            <asp:DropDownList ID="ddlnoofperiods" runat="server" AutoPostBack="True" 
                                                                                CssClass="s_dropdown" Width="140px" 
                                                                                onselectedindexchanged="ddlnoofperiods_SelectedIndexChanged">
                                                                                <asp:ListItem>-Select-</asp:ListItem>
                                                                                <asp:ListItem>1</asp:ListItem>
                                                                                <asp:ListItem>2</asp:ListItem>
                                                                                <asp:ListItem>3</asp:ListItem>
                                                                                <asp:ListItem>4</asp:ListItem>
                                                                                <asp:ListItem>5</asp:ListItem>
                                                                                <asp:ListItem>6</asp:ListItem>
                                                                                <asp:ListItem>7</asp:ListItem>
                                                                                <asp:ListItem>8</asp:ListItem>
                                                                                <asp:ListItem>9</asp:ListItem>
                                                                                <asp:ListItem>10</asp:ListItem>
                                                                                <asp:ListItem>11</asp:ListItem>                                                        
                                                                                <asp:ListItem>12</asp:ListItem>
                                                                                <asp:ListItem>13</asp:ListItem>
                                                                                <asp:ListItem>14</asp:ListItem>
                                                                                <asp:ListItem>15</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" style="width: 50px; height: 40px">&nbsp;
                                                                        </td>
                                                                        <td align="left" style="width: 175px; height: 40px">
                                                                            <asp:Label ID="Label13" runat="server" CssClass="s_label" 
                                                                                Text="No of intervals in a day"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 150px; height: 40px">
                                                                            <asp:DropDownList ID="ddlnoofintervals" runat="server" AutoPostBack="True" 
                                                                                CssClass="s_dropdown" 
                                                                                onselectedindexchanged="ddlnoofintervals_SelectedIndexChanged" Width="140px">
                                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                                <asp:ListItem Value="5">5</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" style="width: 50px; height: 40px">
                                                                            &nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>                                               
                                                                    </tr>
                                                                    <tr id="trinterval1" runat="server">
                                                                        <td align="left" style="width: 175px; height: 40px">
                                                                            <asp:Label ID="Label6" runat="server" CssClass="s_label" 
                                                                                Text="First Interval after"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 150px; height: 40px">
                                                                            <asp:DropDownList ID="ddlinterval1" runat="server" 
                                                                                CssClass="s_dropdown" Width="140px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" style="width: 50px; height: 40px">
                                                                            &nbsp;</td>
                                                                        <td align="left" style="width: 175px; height: 40px">
                                                                            <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Lunch after"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 150px; height: 40px">
                                                                            <asp:DropDownList ID="ddllunch" runat="server" 
                                                                                CssClass="s_dropdown" Width="140px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" style="width: 50px; height: 40px">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr id="trtag1" runat="server">
                                                                        <td align="left" style="width: 175px; height: 40px">
                                                                            <asp:Label ID="lblI2" runat="server" CssClass="s_label" Text="Second Interval after"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 150px; height: 40px">
                                                                            <asp:DropDownList ID="ddlinterval2" runat="server" 
                                                                                CssClass="s_dropdown" Width="140px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" style="width: 50px; height: 40px">
                                                                            &nbsp;</td>
                                                                        <td align="left" style="width: 175px; height: 40px">
                                                                            <asp:Label ID="lblI3" runat="server" CssClass="s_label" 
                                                                                Text="Third Interval after"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 150px; height: 40px">
                                                                            <asp:DropDownList ID="ddlinterval3" runat="server" 
                                                                                CssClass="s_dropdown" Width="140px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" style="width: 50px; height: 40px">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr id="trtag2" runat="server">
                                                                        <td align="left" style="width: 175px; height: 40px">
                                                                            <asp:Label ID="lblI4" runat="server" CssClass="s_label" 
                                                                                Text="Fourth Interval after"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 150px; height: 40px">
                                                                            <asp:DropDownList ID="ddlinterval4" runat="server" 
                                                                                CssClass="s_dropdown" Width="140px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" style="width: 50px; height: 40px">
                                                                            &nbsp;</td>
                                                                        <td align="left" style="width: 175px; height: 40px">
                                                                            <asp:Label ID="lblI5" runat="server" CssClass="s_label" 
                                                                                Text="Fifth Interval after"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="width: 150px; height: 40px">
                                                                            <asp:DropDownList ID="ddlinterval5" runat="server" 
                                                                                CssClass="s_dropdown" Width="140px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" style="width: 50px; height: 40px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr >
                                                                        <td align="left" style="width: 175px; height: 40px">
                                                                            &nbsp;</td>
                                                                        <td align="center" style="height: 40px" colspan="3">
                                                                            <asp:Button ID="btnset" runat="server" CssClass="s_button" 
                                                                                onclick="btnset_Click" Text="Set Periods Start Time End Time" 
                                                                                Width="240px" />
                                                                        </td>
                                                                        <td align="left" style="width: 150px; height: 40px">
                                                                            &nbsp;</td>
                                                                        <td align="left" style="width: 50px; height: 40px">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr class="view_detail_subtitle_bg">
                                                             <td style="height: 25px" align="left" colspan="6" >
                                                                <asp:Label ID="Label4" runat="server" CssClass="subtitle_label" Text="Period Details"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="break" colspan="6"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="height: 20px" colspan="6">
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="dltime" Width="730" Height="100" ScrollBars="Horizontal" runat="server" CssClass="top_curve" onitemdatabound="Panel1_ItemDataBound">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td align="left" style="height: 40px; ">
                                                                                            <table cellpadding="0" cellspacing="0" border="0" class="view_detail_subtitle_bg">
                                                                                                <tr>
                                                                                                    <td valign="top" >
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="150" style="padding-left:10px;">
                                                                                                            <tr>
                                                                                                                <td align="left" class="s_label" valign="top" >
                                                                                                                    Period
                                                                                                                </td>
                                                                                                                <td align="left" class="s_label">
                                                                                                                    Start
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" class="s_label" colspan="2">
                                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="150" style="height:35px;">
                                                                                                                        <tr>
                                                                                                                            <td style="width: 90px; height: 30px;" align="left">
                                                                                                                                Time
                                                                                                                            </td>
                                                                                                                            <td>
                                                                                                                                <table cellpadding="0" cellspacing="0" width="60">
                                                                                                                                    <tr>
                                                                                                                                        <td style="width: 60px; height: 30px;" align="center">
                                                                                                                                            <span class="curve period_time_bg"><asp:Label ID="lblstarttime" runat="server" class="curve period_time_bg" Width="55px"></asp:Label></span>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" class="s_label" style="height:5px;" colspan="2">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td valign="top" align="left">
                                                                                                        <asp:DataList ID="dlperiods" runat="server" RepeatDirection="Horizontal" 
                                                                                                            BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                                            ShowHeader="False" CssClass="s_label" 
                                                                                                            onitemdatabound="dlperiods_ItemDataBound">
                                                                                                            <ItemTemplate>
                                                                                                                <table cellpadding="0" cellspacing="0" border="0" width="141">
                                                                                                                    <tr>
                                                                                                                        <td style="height: 30px; width:50px;" class="s_label" align="center">
                                                                                                                            <asp:Label ID="lblper" CssClass="timtetable_period" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strper")%>'></asp:Label>
                                                                                                                            <asp:Label ID="lblperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td style="height: 30px; width:91px;" align="center">
                                                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="91">
                                                                                                                                <tr class="s_label">
                                                                                                                                    <td style="width: 35px; height: 38px; " align="right" class="smalllabel">End&nbsp;</td>
                                                                                                                                    <td style="width: 1px; height: 20px;" class="timetable_tableborder" ></td>
                                                                                                                                    <td style="width: 35px; height: 30px; " align="left" class="smalllabel">&nbsp;Start</td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td style="height: 30px; width:50px;" align="center">
                                                                                                                        </td>
                                                                                                                        <td style="height: 30px; width:91px;" align="center">
                                                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="91">
                                                                                                                                <tr>
                                                                                                                                    <td colspan="3" style="width: 85px; height: 20px;" class="curve period_time_bg">
                                                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="85" >
                                                                                                                                            <tr>
                                                                                                                                                <td style="width: 85px; height: 20px">
                                                                                                                                                    <asp:DropDownList ID="ddlHH" runat="server" Width="40px">
                                                                                                                                                        <asp:ListItem>00</asp:ListItem>
                                                                                                                                                        <asp:ListItem>01</asp:ListItem>
                                                                                                                                                        <asp:ListItem>02</asp:ListItem>
                                                                                                                                                        <asp:ListItem>03</asp:ListItem>
                                                                                                                                                        <asp:ListItem>04</asp:ListItem>
                                                                                                                                                        <asp:ListItem>05</asp:ListItem>
                                                                                                                                                        <asp:ListItem>06</asp:ListItem>
                                                                                                                                                        <asp:ListItem>07</asp:ListItem>
                                                                                                                                                        <asp:ListItem>08</asp:ListItem>
                                                                                                                                                        <asp:ListItem>09</asp:ListItem>
                                                                                                                                                        <asp:ListItem>10</asp:ListItem>
                                                                                                                                                        <asp:ListItem>11</asp:ListItem>
                                                                                                                                                        <asp:ListItem>12</asp:ListItem>
                                                                                                                                                        <asp:ListItem>13</asp:ListItem>
                                                                                                                                                        <asp:ListItem>14</asp:ListItem>
                                                                                                                                                        <asp:ListItem>15</asp:ListItem>
                                                                                                                                                        <asp:ListItem>16</asp:ListItem>
                                                                                                                                                        <asp:ListItem>17</asp:ListItem>
                                                                                                                                                        <asp:ListItem>18</asp:ListItem>
                                                                                                                                                        <asp:ListItem>19</asp:ListItem>
                                                                                                                                                        <asp:ListItem>20</asp:ListItem>
                                                                                                                                                        <asp:ListItem>21</asp:ListItem>
                                                                                                                                                        <asp:ListItem>22</asp:ListItem>
                                                                                                                                                        <asp:ListItem>23</asp:ListItem>
                                                                                                                                                    </asp:DropDownList>
                                                                                                                                                    <asp:DropDownList ID="ddlMM" runat="server" Width="40px">
                                                                                                                                                        <asp:ListItem>00</asp:ListItem>
                                                                                                                                                        <asp:ListItem>05</asp:ListItem>
                                                                                                                                                        <asp:ListItem>10</asp:ListItem>
                                                                                                                                                        <asp:ListItem>15</asp:ListItem>
                                                                                                                                                        <asp:ListItem>20</asp:ListItem>
                                                                                                                                                        <asp:ListItem>25</asp:ListItem>
                                                                                                                                                        <asp:ListItem>30</asp:ListItem>
                                                                                                                                                        <asp:ListItem>35</asp:ListItem>
                                                                                                                                                        <asp:ListItem>40</asp:ListItem>
                                                                                                                                                        <asp:ListItem>45</asp:ListItem>
                                                                                                                                                        <asp:ListItem>50</asp:ListItem>
                                                                                                                                                        <asp:ListItem>55</asp:ListItem>
                                                                                                                                                    </asp:DropDownList>
                                                                                                                                                    <asp:Label ID="lblhh" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strETHH")%>'></asp:Label>
                                                                                                                                                    <asp:Label ID="lblmm" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strETMM")%>'></asp:Label>
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                        </table>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td style="width: 45px; height: 20px"></td>
                                                                                                                                    <td style="width: 1px; height: 20px;" class="timetable_tableborder" ></td>
                                                                                                                                    <td style="width: 45px; height: 20px"></td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:DataList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="center" style="height: 20px;">
                                                                <asp:Label ID="lbltimingerror" runat="server" CssClass="s_label" 
                                                                    Font-Bold="True" ForeColor="Red"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="center" style="width: 750px; height: 40px">
                                                                <asp:Button ID="btnSave" runat="server" CssClass="s_button" 
                                                                    onclick="btnSave_Click" Text="Save/Next" Width="80px" />
                                                                <asp:Button ID="btncancel" runat="server" CausesValidation="False" 
                                                                    CssClass="s_button" onclick="btncancel_Click" Text="Cancel" Visible="False" 
                                                                    Width="80px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="center" style="height: 10px;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>  
                                            <tr>
                                                <td style="width: 100%;height:10px;" align="left">
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
            <td style="width: 100%;" align="left" valign="top" >
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
