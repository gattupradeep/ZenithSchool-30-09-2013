<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewclasstimingsandperiods.aspx.cs" Inherits="school_viewclasstimingsandperiods" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc1" %>

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
    </script>    
</head>
<body>
    <form id="form1" runat="server">
    <div> 
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:toolkitscriptmanager>   
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
                                        <uc1:school_profile ID="school_profile1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/25.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >
                                                   View Class Timings and Periods</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
                                         <!--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                            <ProgressTemplate>
                                                <div id="progressBackgroundFilter"></div>
                                                    <div id="processMessage">
                                                        <img alt="Loading" src="../media/images/Processing.gif" />
                                                    </div>
                                            </ProgressTemplate>
                                         </asp:UpdateProgress>
                                         <asp:UpdatePanel ID="updatepanal" runat="server" >
                                             <ContentTemplate> -->
                                                 <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr>
                                                <td >
                                                    <table cellpadding="5" cellspacing="0" border="0">
                                                        <tr class="view_detail_title_bg" >
                                                            <td colspan="3"  align="left" >
                                                               <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="School Timings and Periods" ></asp:Label>
                                                            </td>                                                            
                                                            <td style="width: 100px; height: 50px">
                                                                <asp:Button ID="btnedit" runat="server" CssClass="s_button" Text="Add/Edit" 
                                                                    Width="80px" onclick="btnedit_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 175px; height: 40px; padding-left: 15px">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" 
                                                                    Text="Class "></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px; padding-left: 15px">
                                                                <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_dropdown" 
                                                                    onselectedindexchanged="ddlclass_SelectedIndexChanged" Width="140px" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 175px; height: 40px; padding-left: 15px">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" 
                                                                    Text="No of periods in a day"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px; padding-left: 15px">
                                                                <asp:Label ID="lblperiods" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        
                                                       
                                                        <tr>
                                                            <td align="left" style="width: 175px; height: 40px; padding-left: 15px">
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" 
                                                                    Text="No of intervals in a day"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px; padding-left: 15px">
                                                                <asp:Label ID="lblintervals" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 175px; height: 40px; padding-left: 15px">
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" 
                                                                    Text="First Interval after"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px; padding-left: 15px">                                                    
                                                                <asp:Label ID="lblfirstinterval" runat="server" CssClass="s_label_value"></asp:Label>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 175px; height: 40px; padding-left: 15px">
                                                                <asp:Label ID="Label24" runat="server" CssClass="s_label" 
                                                                    Text="Second Interval after"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px; padding-left: 15px">                                                                                             
                                                                <asp:Label ID="lblsecondinterval" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 175px; height: 40px; padding-left: 15px">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Lunch after"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px; padding-left: 15px">
                                                                <asp:Label ID="lbllunch" runat="server" CssClass="s_label_value"></asp:Label>
                                                                </td>
                                                        </tr>
                                                                              
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                 <td align="left" style="width: 710px; height: 20px"></td>  
                                            </tr>
                                             <tr class="view_detail_subtitle_bg">
                                                 <td style="height: 25px" align="left" >
                                                    <asp:Label ID="Label4" runat="server" CssClass="subtitle_label" Text="Period Details"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                 <td align="left" style="width: 750px">
                                                    <table cellpadding="7" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Panel ID="Panel1" Width="750" Height="95" ScrollBars="Horizontal" runat="server" CssClass="thick_curve">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td align="left" style="height: 40px;">
                                                                                <table cellpadding="0" cellspacing="0" border="0" class="view_detail_subtitle_bg">
                                                                                    <tr>
                                                                                        <td style="width:150px" valign="top" >
                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="150">
                                                                                                <tr>
                                                                                                    <td align="left" class="s_label" style="padding-left:10px;">
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
                                                                                                                <td style="width: 90px; height: 30px; padding-left: 10px" align="left">
                                                                                                                    Time
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <table cellpadding="0" cellspacing="0" width="60">
                                                                                                                        <tr>
                                                                                                                            <td style="width: 60px; height: 30px;" align="center">
                                                                                                                                <span class="curve period_time_bg"><asp:Label ID="lblstarttimings1" runat="server" Width="60px" ></asp:Label></span>
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
                                                                                                ShowHeader="False" CssClass="s_label" >
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="141">
                                                                                                        <tr>
                                                                                                            <td style="height: 30px; width:50px;" align="center">
                                                                                                                <b><asp:Label ID="lblper" CssClass="timtetable_period" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strper")%>'></asp:Label></b>
                                                                                                                <asp:Label ID="lblperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                            </td>
                                                                                                            <td style="height: 30px; width:71px;" align="center">
                                                                                                                <table cellpadding="0" cellspacing="0" border="0" width="71">
                                                                                                                    <tr class="smalllabel">
                                                                                                                        <td style="width: 35px; height: 38px;" align="right">End&nbsp;</td>
                                                                                                                        <td style="width: 1px; height: 20px;" class="timetable_tableborder" ></td>
                                                                                                                        <td style="width: 35px; height: 30px; " align="left">&nbsp;Start</td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="height: 30px; width:50px;" align="center">
                                                                                                            </td>
                                                                                                            <td style="height: 30px; width:31px;" align="center">
                                                                                                                <table cellpadding="0" cellspacing="0" border="0" width="71">
                                                                                                                    <tr>
                                                                                                                        <td colspan="3" style="width: 91px; height: 20px">
                                                                                                                            <table cellpadding="0" cellspacing="0" width="71">
                                                                                                                                <tr>
                                                                                                                                    <td style="width: 71px; height: 20px;" class="curve period_time_bg" align="center">
                                                                                                                                        <asp:Label ID="lblhh" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strETHH")%>'></asp:Label> 
                                                                                                                                        :
                                                                                                                                        <asp:Label ID="lblmm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strETMM")%>'></asp:Label>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td style="width: 35px; height: 20px"></td>
                                                                                                                        <td style="width: 1px; height: 20px;" class="timetable_tableborder"></td>
                                                                                                                        <td style="width: 35px; height: 20px"></td>
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
                                        </table>
                                              <!--</ContentTemplate>
                                         </asp:UpdatePanel> -->
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 40px">
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
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
