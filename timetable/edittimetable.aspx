<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edittimetable.aspx.cs" Inherits="timetable_edittimetable" %>

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
                        <td style="width: 2%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="750">
                                            <tr>
                                                <td style="width: 50px; height: 50px"><img src="../media/images/moduleimg1.jpg" width="50" height="50" /></td>
                                                <td style="width: 600px; height: 50px; font-family: Arial; font-size: 23px; color: #2DA0ED; padding-left: 10px" align="left">
                                                    Students Time Table</td>
                                                <td style="width: 100px; height: 50px">
                                                    <asp:Button ID="btnedit" runat="server" CssClass="s_button" Text="Add/Edit" 
                                                        Width="80px" onclick="btnedit_Click"/>
                                                </td>
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
                                         <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                    <ProgressTemplate>
                                                        <div id="progressBackgroundFilter"></div>
                                                            <div id="processMessage">
                                                                <img alt="Loading" src="../media/images/Processing.gif" />
                                                            </div>
                                                    </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:UpdatePanel ID="updatepanal" runat="server" >
                                                      <ContentTemplate>
                                                             <table cellpadding="0" cellspacing="0" class="curve">
                                            <tr>
                                                <td style="height: 40px" align="right">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="450">
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
                                                                    Width="130px" AutoPostBack="True"></asp:DropDownList>&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="background-color:#9BBB58">
                                                <td style="height: 40px; color: White; font-weight: bold; padding-left: 15px" align="left" class="s_label">
                                                    Periods &amp; Working Days
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="height: 30px; width:130px" valign="top">
                                                                <asp:DataGrid ID="dgtimetable" runat="server" AutoGenerateColumns="False" 
                                                                    BorderStyle="None" 
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
                                                                                    <tr><td style="height: 1px; width:130px; background-color: Gray"></td></tr>
                                                                                    <tr>
                                                                                        <td style="height: 90px; width:130px; font-weight: bold; background-color:#DEE7D1; line-height: 23px" align="center" class="s_label1">
                                                                                            Start Time : <%# DataBinder.Eval(Container.DataItem, "strstarttime")%><br />
                                                                                            <%# DataBinder.Eval(Container.DataItem, "strperiod")%><br />
                                                                                            End Time : <%# DataBinder.Eval(Container.DataItem, "strendtime")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#666666" CssClass="s_label" Font-Bold="True" 
                                                                        ForeColor="White" Height="40px" />
                                                                </asp:DataGrid>
                                                            </td>
                                                            <td id="tdsunday" runat="server">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 151px; height: 40px; background-color: #666666; color: White; font-weight:bold" class="s_label" align="center">
                                                                            Sunday
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 151px; height: 91px">
                                                                            <asp:DataList ID="dlsunday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlsunday_ItemDataBound">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 1px; width:150px; background-color: Gray"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 90px; width:150px; color: Black; font-size: 12px; padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lblsunperiod" runat="server" Visible="false"><%# DataBinder.Eval(Container.DataItem, "strperiod")%></asp:Label>
                                                                                                <asp:Label ID="lblsunsubtech" runat="server">
                                                                                                    <asp:DropDownList ID="ddlsunsubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                    <asp:DropDownList ID="ddlsunteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                </asp:Label>
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
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="border-left: solid 1px white; width: 151px; height: 40px; background-color: #666666; color: White; font-weight:bold" class="s_label" align="center">
                                                                            Monday
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 151px; height: 91px">
                                                                            <asp:DataList ID="dlmonday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlmonday_ItemDataBound">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 1px; width:150px; background-color: Gray"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 90px; width:150px; color: Black; font-size: 12px; padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lblmonperiod" runat="server" Visible="false"><%# DataBinder.Eval(Container.DataItem, "strperiod")%></asp:Label>
                                                                                                <asp:Label ID="lblmonsubtech" runat="server">
                                                                                                    <asp:DropDownList ID="ddlmonsubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                    <asp:DropDownList ID="ddlmonteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                </asp:Label>
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
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="border-left: solid 1px white; width: 151px; height: 40px; background-color: #666666; color: White; font-weight:bold" class="s_label" align="center">
                                                                            Tuesday
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 151px; height: 91px">
                                                                            <asp:DataList ID="dltuesday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dltuesday_ItemDataBound">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 1px; width:150px; background-color: Gray"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 90px; width:150px; color: Black; font-size: 12px; padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lbltueperiod" runat="server" Visible="false"><%# DataBinder.Eval(Container.DataItem, "strperiod")%></asp:Label>
                                                                                                <asp:Label ID="lbltuesubtech" runat="server">
                                                                                                    <asp:DropDownList ID="ddltuesubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                    <asp:DropDownList ID="ddltueteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                </asp:Label>
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
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="border-left: solid 1px white; width: 150px; height: 40px; background-color: #666666; color: White; font-weight:bold" class="s_label" align="center">
                                                                            Wednesday
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 151px; height: 91px">
                                                                            <asp:DataList ID="dlwednesday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlwednesday_ItemDataBound">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 1px; width:150px; background-color: Gray"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 90px; width:150px; color: Black; font-size: 12px; padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lblwedperiod" runat="server" Visible="false"><%# DataBinder.Eval(Container.DataItem, "strperiod")%></asp:Label>
                                                                                                <asp:Label ID="lblwedsubtech" runat="server">
                                                                                                    <asp:DropDownList ID="ddlwedsubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                    <asp:DropDownList ID="ddlwedteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                </asp:Label>
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
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="border-left: solid 1px white; width: 150px; height: 40px; background-color: #666666; color: White; font-weight:bold" class="s_label" align="center">
                                                                            Thursday
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 151px; height: 91px">
                                                                            <asp:DataList ID="dlthursday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlthursday_ItemDataBound">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 1px; width:150px; background-color: Gray"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 90px; width:150px; color: Black; font-size: 12px; padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lblthuperiod" runat="server" Visible="false"><%# DataBinder.Eval(Container.DataItem, "strperiod")%></asp:Label>
                                                                                                <asp:Label ID="lblthusubtech" runat="server">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "strsubject")%>
                                                                                                    <asp:DropDownList ID="ddlthusubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                    <asp:DropDownList ID="ddlthuteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                </asp:Label>
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
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="border-left: solid 1px white; width: 150px; height: 40px; background-color: #666666; color: White; font-weight:bold" class="s_label" align="center">
                                                                            Friday
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 151px; height: 91px">
                                                                            <asp:DataList ID="dlfriday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlfriday_ItemDataBound">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 1px; width:150px; background-color: Gray"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 90px; width:150px; color: Black; font-size: 12px; padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lblfriperiod" runat="server" Visible="false"><%# DataBinder.Eval(Container.DataItem, "strperiod")%></asp:Label>
                                                                                                <asp:Label ID="lblfrisubtech" runat="server">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "strsubject")%>
                                                                                                    <asp:DropDownList ID="ddlfrisubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                    <asp:DropDownList ID="ddlfriteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                </asp:Label>
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
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="border-left: solid 1px white; width: 150px; height: 40px; background-color: #666666; color: White; font-weight:bold" class="s_label" align="center">
                                                                            Saturday
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 151px; height: 91px">
                                                                            <asp:DataList ID="dlsaturday" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dlsaturday_ItemDataBound">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 1px; width:150px; background-color: Gray"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width:1px; background-color: Gray"></td>
                                                                                            <td style="height: 90px; width:150px; color: Black; font-size: 12px; padding-left: 10px" align="center" class="s_label">
                                                                                                <asp:Label ID="lblsatperiod" runat="server" Visible="false"><%# DataBinder.Eval(Container.DataItem, "strperiod")%></asp:Label>
                                                                                                <asp:Label ID="lblsatsubtech" runat="server">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "strsubject")%>
                                                                                                    <asp:DropDownList ID="ddlsatsubject" runat="server" Width="130px"></asp:DropDownList><br /><br />
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "teachername")%>
                                                                                                    <asp:DropDownList ID="ddlsatteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                </asp:Label>
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
                                                <td style="height: 40px; color: White; font-weight: bold; border-top: solid 1px Gray" align="center" class="s_label">
                                                    <asp:Button ID="btnupdate" runat="server" CssClass="s_button" Text="Update" />
                                                &nbsp;
                                                    <asp:Button ID="btncancel" runat="server" CssClass="s_button" 
                                                        Text="Cancel/Back" />
                                                </td>
                                            </tr>
                                        </table>
                                                      </ContentTemplate>
                                             </asp:UpdatePanel>
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
        <%--<tr>
            <td style="width: 100%;" align="left" valign="top" >
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>--%>
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
