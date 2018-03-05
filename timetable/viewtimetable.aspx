<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewtimetable.aspx.cs" Inherits="timetable_viewtimetable" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc1" %>

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
//                if (currentwidth > 900) {
//                    var assignwidth = document.getElementById("mwidth").style.width = "900";
//                    var panelwidth = document.getElementById("pnl1").style.width = "900";
//                    var panelwidth = document.getElementById("paneltd").style.width = "900";
//                }
//                else {
                    var assignwidth = document.getElementById("mwidth").style.width = currentwidth + "px";
                    var panelwidth = document.getElementById("pnl1").style.width = currentwidth + "px";
                    var panelwidth = document.getElementById("paneltd").style.width = currentwidth + "px";
//                }
            }
        }
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
            <td style=" height: 600px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="230">
                                <tr>
                                    <td style="width: 230px" align="left">
                                        <uc4:activities_timetable ID="activities_timetable1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc1:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%" valign="top">
                        </td>
                        <td valign="top" align="left" id="mwidth">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr class="app_container_title">
                                    <td style="height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/54.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Students Time Table</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break" ></td>
                                </tr>
                                <tr>
                                    <td style="height: 100px; padding-left: 5px" valign="top" align="left" id="paneltd">
                                        <div id="pnl1" class="thick_curve">
                                            <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                <ProgressTemplate>
                                                    <div id="progressBackgroundFilter"></div>
                                                        <div id="processMessage">
                                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                                        </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:UpdatePanel ID="updatepanal" runat="server" >
                                                     <ContentTemplate>--%>
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="height: 40px" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="550">
                                                        <tr>
                                                            <td style="width: 150px; height: 30px" align="right">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Class & Section : "></asp:Label>
                                                            </td>
                                                            <td style="width: 150px; height: 30px" align="right">
                                                                <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_textbox" 
                                                                    Width="130px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlclass_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                                                            </td>
                                                            <td style="width: 150px; height: 30px" align="right">
                                                                <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_textbox" 
                                                                    Width="130px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlsection_SelectedIndexChanged"></asp:DropDownList>
                                                               
                                                            </td>
                                                            <td style="width: 100px; height: 30px" align="right">
                                                                <asp:Button ID="btnedit" runat="server" CssClass="s_button" Text="Edit" 
                                                                    Width="80px" onclick="btnedit_Click"/>
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" >
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Periods & Working Days" ></asp:Label>
                                                    <asp:Label ID="lblmode" runat="server" Visible="False" CssClass="title_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:DataGrid ID="dgtimetable" runat="server" AutoGenerateColumns="False" 
                                                                    BorderStyle="Solid"
                                                                    BorderWidth="0px" CellPadding="0">
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="strperiod" HeaderText="Period" Visible="False"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strstarttime" HeaderText="Start Time" 
                                                                            Visible="False">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strendtime" HeaderText="End Time" Visible="False"></asp:BoundColumn>
                                                                        <asp:TemplateColumn HeaderText="Periods">
                                                                            <HeaderStyle HorizontalAlign="Center" BorderStyle="None" BorderWidth="0px" />
                                                                            <ItemStyle BorderStyle="None" BorderWidth="0px"/>
                                                                            <ItemTemplate>
                                                                                <table cellpadding="0" cellspacing="0" border="0" width="130">
                                                                                    <tr><td style="height: 1px; width:130px;" class="timetable_tableborder" ></td></tr>
                                                                                    <tr>
                                                                                        <td style="height: 90px; width:130px; line-height: 23px" align="center" class="view_detail_subtitle_bg">
                                                                                            <span class="timetable_startendtime">Start Time : <%# DataBinder.Eval(Container.DataItem, "strstarttime")%></span><br />
                                                                                            <span class="timtetable_period"><%# DataBinder.Eval(Container.DataItem, "strperiod")%></span><br />
                                                                                            <span class="timetable_startendtime">End Time : <%# DataBinder.Eval(Container.DataItem, "strendtime")%></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="timetable_daysheader" BorderStyle="None" Height="40px" />
                                                                </asp:DataGrid>
                                                            </td>
                                                            <td id="tdsunday" runat="server" valign="top">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 151px; height: 40px;" class="timetable_daysheader" align="center">
                                                                            Sunday                                                                         
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 151px; height: 91px">
                                                                            <asp:DataList ID="dlsunday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlsunday_ItemDataBound" 
                                                                                onitemcommand="dlsunday_ItemCommand">
                                                                                <ItemStyle VerticalAlign="Top" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px" class="timetable_tableborder"></td>
                                                                                            <td style="height: 1px; width:150px" class="timetable_tableborder"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:15px;" class="timetable_leftborder"></td>
                                                                                            <td style="height: 90px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                               <asp:Label ID="lblsunperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                <asp:Label ID="lblsunsub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlsunsubject" runat="server" Width="130px"> 
                                                                                                   </asp:DropDownList><br /><br />
                                                                                                <asp:ImageButton ID="btnsunnsecond" runat="server" 
                                                                                                    ImageUrl="~/media/images/change.jpg" Visible="true" />
                                                                                                <asp:Label ID="lblsuntech" runat="server">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlsunteacher" runat="server" Width="130px"> 
                                                                                                    </asp:DropDownList>
                                                                                                <asp:Label ID="lblsunbreak" runat="server" Visible="false"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td id="tdmonday" runat="server" valign="top">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 151px; height: 40px;" class="timetable_daysheader" align="center">
                                                                            Monday
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 151px; height: 91px">
                                                                            <asp:DataList ID="dlmonday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlmonday_ItemDataBound" 
                                                                                onitemcommand="dlmonday_ItemCommand">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                            <td style="height: 90px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lblmonperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                <asp:Label ID="lblmonsub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlmonsubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                <asp:ImageButton ID="btnmonsecond" runat="server" 
                                                                                                    ImageUrl="~/media/images/change.jpg" Visible="true" />
                                                                                                <asp:Label ID="lblmontech" runat="server">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlmonteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                <asp:Label ID="lblmonbreak" runat="server" Visible="false"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td id="tdtuesday" runat="server" valign="top">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 151px; height: 40px;" class="timetable_daysheader" align="center">
                                                                            Tuesday
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 151px; height: 91px">
                                                                            <asp:DataList ID="dltuesday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dltuesday_ItemDataBound" 
                                                                                onitemcommand="dltuesday_ItemCommand">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                            <td style="height: 90px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lbltueperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                <asp:Label ID="lbltuesub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddltuesubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                <asp:ImageButton ID="btntuesecond" runat="server" 
                                                                                                    ImageUrl="~/media/images/change.jpg" Visible="true" />
                                                                                                <asp:Label ID="lbltuetech" runat="server">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddltueteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                <asp:Label ID="lbltuebreak" runat="server" Visible="false"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
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
                                                                            <asp:DataList ID="dlwednesday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlwednesday_ItemDataBound" 
                                                                                onitemcommand="dlwednesday_ItemCommand">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                            <td style="height: 90px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lblwedperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                <asp:Label ID="lblwedsub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlwedsubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                <asp:ImageButton ID="btnwedsecond" runat="server" 
                                                                                                    ImageUrl="~/media/images/change.jpg" Visible="true" />
                                                                                                <asp:Label ID="lblwedtech" runat="server">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlwedteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                <asp:Label ID="lblwedbreak" runat="server" Visible="false"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
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
                                                                            <asp:DataList ID="dlthursday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlthursday_ItemDataBound" 
                                                                                onitemcommand="dlthursday_ItemCommand">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                            <td style="height: 90px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lblthuperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                <asp:Label ID="lblthusub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlthusubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                <asp:ImageButton ID="btnthusecond" runat="server" 
                                                                                                    ImageUrl="~/media/images/change.jpg" Visible="true" />
                                                                                                <asp:Label ID="lblthutech" runat="server">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlthuteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                <asp:Label ID="lblthubreak" runat="server" Visible="false"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
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
                                                                            <asp:DataList ID="dlfriday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlfriday_ItemDataBound" 
                                                                                onitemcommand="dlfriday_ItemCommand">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                            <td style="height: 90px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lblfriperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                <asp:Label ID="lblfrisub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlfrisubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                <asp:ImageButton ID="btnfrisecond" runat="server" 
                                                                                                    ImageUrl="~/media/images/change.jpg" Visible="true" />
                                                                                                <asp:Label ID="lblfritech" runat="server">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlfriteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                <asp:Label ID="lblfribreak" runat="server" Visible="false"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
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
                                                                            <asp:DataList ID="dlsaturday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlsaturday_ItemDataBound" 
                                                                                onitemcommand="dlsaturday_ItemCommand" >
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                            <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px;" class="timetable_leftborder"></td>
                                                                                            <td style="height: 90px; width:150px;padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lblsatperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                <asp:Label ID="lblsatsub" CssClass="timetable_daysheader1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlsatsubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                <asp:ImageButton ID="btnsatsecond" runat="server" 
                                                                                                    ImageUrl="~/media/images/change.jpg" Visible="true" />
                                                                                                <asp:Label ID="lblsattech" runat="server">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                </asp:Label>
                                                                                                <asp:DropDownList ID="ddlsatteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                <asp:Label ID="lblsatbreak" runat="server" Visible="false"></asp:Label>
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
                                                </td>
                                            </tr>
                                            <tr id="trupdate" runat="server">
                                                <td style="height: 40px; border-top: solid 1px Gray" align="center" class="s_label">
                                                    <asp:Button ID="btnupdate" runat="server" CssClass="s_button" Text="Update" 
                                                        onclick="btnupdate_Click" />
                                                &nbsp;
                                                    <asp:Button ID="btncancel" runat="server" CssClass="s_button" 
                                                        Text="Cancel" onclick="btncancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                                    <%--</ContentTemplate>
                                             </asp:UpdatePanel>--%>
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
            <td style="width: 100%; " align="left" valign="top" >
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
