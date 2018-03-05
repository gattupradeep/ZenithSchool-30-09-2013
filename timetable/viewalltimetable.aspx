<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewalltimetable.aspx.cs" Inherits="timetable_viewalltimetable" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/activities_timetable.ascx" tagname="activities_timetable" tagprefix="uc4" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
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
    <script language="javascript" type="text/javascript">
        function openNewWin1(url) {
            var x = window.open(url, 'mynewwin', 'width=500,height=400,toolbar=0,scrollbars=yes,menubar=0,statusbar=0,location=0');
            x.focus();
        } 
    </script>
    <script language="javascript" type="text/javascript">
        function openNewWin2(url) {
            var x = window.open(url, 'mynewwin', 'width=350,height=400,toolbar=0,scrollbars=yes,menubar=0,statusbar=0,location=0');
            x.focus();
        } 
    </script>
    <script language="javascript" type="text/javascript">
        function openNewWin3(url) {
            var x = window.open(url, 'mynewwin', 'width=350,height=400,toolbar=0,scrollbars=yes,menubar=0,statusbar=0,location=0');
            x.focus();
        } 
    </script>
    <script language="javascript" type="text/javascript">
        function openNewWin(url) {
            var x = window.open(url, 'mynewwin', 'width=500,height=400,toolbar=0,scrollbars=yes,menubar=0,statusbar=0,location=0');
            x.focus();
        } 
    </script>
 <script type="text/javascript">
     function autowidth() {
         var screenW = 640, screenH = 480;
         if (parseInt(navigator.appVersion) > 3) {
             screenW = screen.width;
             currentwidth = screenW - 280;
//             if (currentwidth > 1042) {
//                 var assignwidth = document.getElementById("mwidth").style.width = "1042px";
//                 var panelwidth = document.getElementById("pnl1").style.width = "1042px";
//                 var panelwidth = document.getElementById("paneltd").style.width = "1042px";
//             }
//             else {
                 var assignwidth = document.getElementById("mwidth").style.width = currentwidth + "px";
                 var panelwidth = document.getElementById("pnl1").style.width = currentwidth + "px";
                 var panelwidth = document.getElementById("paneltd").style.width = currentwidth + "px";
//             }
         }

     }
    </script>
    <style type="text/css">
        .style1
        {
            height: 18px;
        }
    </style>
</head>
<%--<body onload="autowidth();">--%>
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
            <td style="height:600px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="230">
                                <tr id="trsidemenu" runat="server">
                                    <td style="width: 230px" align="right">
                                        <uc4:activities_timetable ID="activities_timetable1" runat="server" />
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
                        <td  valign="top" align="left" id="mwidth">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr class="app_container_title">
                                    <td style="height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/54.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">  View Timetable</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1"></td>
                                </tr>
                                <tr>
                                    <td style=" height: 100px; padding-left: 5px" valign="top" align="left" id="paneltd">
                                        <div id="pnl1" style="overflow:auto" class="thick_curve">
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
                                           <table cellpadding="0" cellspacing="0">
                                            <tr id="trfilter" runat="server">
                                                <td style="padding : 10px 10px 10px 10px" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="500">
                                                        <tr id="trstaff" runat="server">
                                                            <td style="width: 100px; height: 30px" align="left">
                                                                <asp:RadioButton ID="rbtnstaff" runat="server" CssClass="s_label" Text="Staff" Checked="True" GroupName="timetable" oncheckedchanged="rbtnstaff_CheckedChanged" AutoPostBack="True" />
                                                            </td>
                                                            <td style="width: 150px; height: 30px" align="left">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Staff Name :"></asp:Label>
                                                            </td>
                                                            <td style="width: 150px; height: 30px" align="left">
                                                                <asp:DropDownList ID="ddlstaff" runat="server" CssClass="s_textbox" 
                                                                    Width="130px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlstaff_SelectedIndexChanged" ></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 90px; height: 30px" align="left">
                                                                <asp:RadioButton ID="rbtstudent" runat="server" CssClass="s_label" 
                                                                    Text="Student" GroupName="timetable" 
                                                                    oncheckedchanged="rbtstudent_CheckedChanged" AutoPostBack="True" />
                                                            </td>
                                                            <td style="width: 90px; height: 30px" align="left">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Class: "></asp:Label>
                                                            </td>
                                                            <td style="width: 90px; height: 30px" align="left">
                                                                <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_textbox" 
                                                                    Width="130px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlclass_SelectedIndexChanged">
                                                                 <%--<asp:ListItem >Select</asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 70px; height: 30px" align="left">
                                                             <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Section: "></asp:Label>
                                                            </td>
                                                            <td style="width: 70px; height: 30px" align="left">
                                                            <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_textbox" 
                                                                    Width="130px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlsection_SelectedIndexChanged" >
                                                                    </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr  id="trgrid" runat="server">
                                                <td style="height: 30px;" align="left">
                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                            <tr class="view_detail_title_bg">
                                                                <td align="left" colspan="8" >
                                                                   <asp:Label ID="lblmode" runat="server" CssClass="title_label"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 30px" valign="top">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DataGrid ID="dgtimetable" runat="server" AutoGenerateColumns="False" 
                                                                                    BorderStyle="Solid"
                                                                                    BorderWidth="0px" CellPadding="0">
                                                                                    <Columns>
                                                                                        <asp:BoundColumn DataField="strperiod" HeaderText="Period" Visible="False"></asp:BoundColumn>
                                                                                        <asp:TemplateColumn HeaderText="Periods">
                                                                                            <HeaderStyle HorizontalAlign="Center" BorderStyle="None" BorderWidth="0px" />
                                                                                            <ItemStyle BorderStyle="None" BorderWidth="0px"/>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" width="130">
                                                                                                    <tr><td style="height: 1px;width:130px;" class="timetable_tableborder"></td></tr>
                                                                                                    <tr>
                                                                                                        <td style="height: 90px; width:130px;line-height: 23px" align="center" class="view_detail_subtitle_bg">
                                                                                                            <span class="timtetable_period"><%# DataBinder.Eval(Container.DataItem, "strperiod")%></span><br />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                    </Columns>
                                                                                    <HeaderStyle CssClass="timetable_daysheader" BorderStyle="None" Height="40px" />
                                                                                </asp:DataGrid>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trtotaldays" runat="server">
                                                                            <td>
                                                                                <table cellpadding="0" cellspacing="0" border="0" width="130">
                                                                                    <tr><td style="height: 1px; width:130px;" class="timetable_tableborder"></td></tr>
                                                                                    <tr>
                                                                                        <td style="height: 130px; width:130px;border:none;line-height: 23px" class="timetable_daysheader" align="center" >
                                                                                            Total<br />
                                                                                            Periods in<br />
                                                                                            a day
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td id="tdsunday" runat="server" valign="top">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td style="width: 151px; height: 40px;" class="timetable_daysheader" align="center">
                                                                                Sunday                                                                         </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 151px; height: 91px">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td class="timetable_leftborder">
                                                                                            <asp:DataList ID="dlsunday" runat="server" RepeatDirection="Vertical" 
                                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                                ShowHeader="False" onitemdatabound="dlsunday_ItemDataBound" >
                                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 90px; width:150px; padding-left: 10px" align="center"  class="s_label">
                                                                                                                <asp:Label ID="lblsunperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                                <asp:Label ID="lblsunsub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                                </asp:Label><br />
                                                                                                                <asp:Label ID="lblsuntech" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "teachername")%>'></asp:Label>
                                                                                                                <asp:Label ID="lblsunclass" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strclass")%>' Visible="false">
                                                                                                                </asp:Label><br />
                                                                                                                <asp:Label ID="lblsunstarttime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label>
                                                                                                                <asp:Label ID="lblsunendtime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label>
                                                                                                                <asp:Label ID="lblsunbreak" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trnd1" runat="server">
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                    <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                    <td style="height:130px; width:150px; padding-left: 10px" align="center" class="s_label">
                                                                                                        <asp:Label ID="lblsunnoofdays" runat="server">0</asp:Label>
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
                                                                <td id="tdmonday" runat="server" valign="top">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td style=" width: 151px; height: 40px;" class="timetable_daysheader" align="center">
                                                                                Monday
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 151px; height: 91px">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                      <td class="timetable_leftborder">
                                                                                            <asp:DataList ID="dlmonday" runat="server" RepeatDirection="Vertical" 
                                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                                ShowHeader="False" onitemdatabound="dlmonday_ItemDataBound" >
                                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 90px; width:150px;  padding-left: 10px" align="center"  class="s_label">
                                                                                                                <asp:Label ID="lblmonperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                                <asp:Label ID="lblmonsub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                                </asp:Label><br />
                                                                                                                 <asp:Label ID="lblmontech" runat="server"><%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                                </asp:Label><br />
                                                                                                                 <asp:Label ID="lblmonclass" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strclass")%>' Visible="false"></asp:Label>
                                                                                                                 <asp:Label ID="lblmonstarttime" CssClass="view_detail_title_bg"  runat="server">
                                                                                                                </asp:Label>
                                                                                                                <asp:Label ID="lblmonendtime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label>
                                                                                                               
                                                                                                                <asp:Label ID="lblmonbreak" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trnd2" runat="server">
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                    <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                                    <td style="height: 130px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                        <asp:Label ID="lblmonnoofdays" runat="server">0</asp:Label>
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
                                                                <td id="tdtuesday" runat="server" valign="top">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td style="width: 151px; height: 40px;" class="timetable_daysheader" align="center">
                                                                                Tuesday                                                                             </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 151px; height: 91px">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td class="timetable_leftborder">
                                                                                            <asp:DataList ID="dltuesday" runat="server" RepeatDirection="Vertical" 
                                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                                ShowHeader="False" onitemdatabound="dltuesday_ItemDataBound" >
                                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 90px; width:150px; padding-left: 10px" align="center" class="s_label">
                                                                                                                <asp:Label ID="lbltueperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                                <asp:Label ID="lbltuesub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                                </asp:Label><br />
                                                                                                                <asp:Label ID="lbltuetech" runat="server"><%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                                </asp:Label><br />
                                                                                                                <asp:Label ID="lbltueclass" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strclass")%>' Visible="false"></asp:Label>
                                                                                                                 <asp:Label ID="lbltuestarttime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label>
                                                                                                                <asp:Label ID="lbltueendtime" CssClass="view_detail_title_bg" runat="server" >
                                                                                                                </asp:Label>
                                                                                                                
                                                                                                                <asp:Label ID="lbltuebreak" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trnd3" runat="server">
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                    <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                                    <td style="height: 130px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                        <asp:Label ID="lbltuenoofdays" runat="server">0</asp:Label>
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
                                                                <td id="tdwednesday" runat="server" valign="top">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td style="width: 151px; height: 40px;" class="timetable_daysheader" align="center">
                                                                                Wednesday
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 151px; height: 91px">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                       <td class="timetable_leftborder">
                                                                                            <asp:DataList ID="dlwednesday" runat="server" RepeatDirection="Vertical" 
                                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                                ShowHeader="False" onitemdatabound="dlwednesday_ItemDataBound" >
                                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 90px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                                <asp:Label ID="lblwedperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                                <asp:Label ID="lblwedsub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                                </asp:Label><br />
                                                                                                                 <asp:Label ID="lblwedtech" runat="server"><%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                                </asp:Label><br />
                                                                                                                <asp:Label ID="lblwedclass" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strclass")%>' Visible="false"></asp:Label>
                                                                                                                 <asp:Label ID="lblwedstarttime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label>
                                                                                                                <asp:Label ID="lblwedendtime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label>
                                                                                                               
                                                                                                                <asp:Label ID="lblwedbreak" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trnd4" runat="server">
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                    <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                                    <td style="height: 130px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                        <asp:Label ID="lblwednoofdays" runat="server">0</asp:Label>
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
                                                                <td id="tdthursday" runat="server" valign="top">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td style="width: 151px; height: 40px;" class="timetable_daysheader" align="center">
                                                                                Thursday
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 151px; height: 91px">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                       <td class="timetable_leftborder">
                                                                                            <asp:DataList ID="dlthursday" runat="server" RepeatDirection="Vertical" 
                                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                                ShowHeader="False" onitemdatabound="dlthursday_ItemDataBound" >
                                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 90px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                                <asp:Label ID="lblthuperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                                <asp:Label ID="lblthusub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                                </asp:Label><br />
                                                                                                                 <asp:Label ID="lblthutech" runat="server"><%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                                </asp:Label><br />
                                                                                                                <asp:Label ID="lblthuclass" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strclass")%>' Visible="false"></asp:Label>
                                                                                                                 <asp:Label ID="lblthustarttime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label>
                                                                                                                <asp:Label ID="lblthuendtime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label>
                                                                                                               
                                                                                                                <asp:Label ID="lblthubreak" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trnd5" runat="server">
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                    <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                                    <td style="height: 130px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                        <asp:Label ID="lblthunoofdays" runat="server">0</asp:Label>
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
                                                                <td id="tdfriday" runat="server" valign="top">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td style="width: 151px; height: 40px;" class="timetable_daysheader" align="center">
                                                                                Friday
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 151px; height: 91px">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td class="timetable_leftborder">
                                                                                            <asp:DataList ID="dlfriday" runat="server" RepeatDirection="Vertical" 
                                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                                ShowHeader="False" onitemdatabound="dlfriday_ItemDataBound" >
                                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 90px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                                <asp:Label ID="lblfriperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                                <asp:Label ID="lblfrisub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                                </asp:Label><br />
                                                                                                                 <asp:Label ID="lblfritech" runat="server"><%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                                </asp:Label><br />
                                                                                                                <asp:Label ID="lblfriclass" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strclass")%>' Visible="false"></asp:Label>
                                                                                                                 <asp:Label ID="lblfristarttime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label>
                                                                                                                <asp:Label ID="lblfriendtime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label>
                                                                                                               
                                                                                                                <asp:Label ID="lblfribreak" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trnd6" runat="server">
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                    <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                                    <td style="height: 130px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                        <asp:Label ID="lblfrinoofdays" runat="server">0</asp:Label>
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
                                                                <td id="tdsaturday" runat="server" valign="top">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td style="width: 151px; height: 40px;" class="timetable_daysheader" align="center">
                                                                                Saturday
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 151px; height: 91px">
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td class="timetable_leftborder">
                                                                                            <asp:DataList ID="dlsaturday" runat="server" RepeatDirection="Vertical" 
                                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                                ShowHeader="False" onitemdatabound="dlsaturday_ItemDataBound" >
                                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                            <td style="height: 90px; width:150px; padding-left: 10px" align="center" class="s_label">
                                                                                                                <asp:Label ID="lblsatperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                                <asp:Label ID="lblsatsub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                                </asp:Label><br />
                                                                                                                <asp:Label ID="lblsattech" runat="server"><%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                                </asp:Label><br />
                                                                                                                <asp:Label ID="lblsatclass" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strclass")%>' Visible="false"></asp:Label>
                                                                                                                 <asp:Label ID="lblsatstarttime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label><br />
                                                                                                                <asp:Label ID="lblsatentime" CssClass="view_detail_title_bg" runat="server">
                                                                                                                </asp:Label><br />
                                                                                                                <asp:Label ID="lblsatbreak" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trnd7" runat="server">
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                    <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                                    <td style="height: 130px; width:150px;" align="center" class="s_label">
                                                                                                        <asp:Label ID="lblsatnoofdays" runat="server">0</asp:Label>
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
                                            </table>
                                                            </ContentTemplate>
                                                 </asp:UpdatePanel>
                                            </div>
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
            <td style="width: 100%; " align="left" valign="top">
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
