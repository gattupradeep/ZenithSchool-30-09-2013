<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assigneditsubstitute.aspx.cs" Inherits="substitute_assigneditsubstitute" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/activities_timetable.ascx" tagname="activities_timetable" tagprefix="uc4" %>

<%@ Register src="../usercontrol/admin_sbstitute.ascx" tagname="admin_sbstitute" tagprefix="uc1" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>

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
    <style type="text/css">
        .style1
        {
            width: 755px;
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
                                        <uc1:admin_sbstitute ID="admin_sbstitute1" runat="server" />
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
                                         <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/201.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Assign Edit Substitute Teacher</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1"></td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px" valign="top" align="left" class="style2">
                                        <table cellpadding="0" cellspacing="0" class="app_container_auto">
                                            <tr class="view_detail_title_bg">
                                                <td style="height: 40px; padding-left: 15px" align="left" class="header_lable">
                                                    Working Days &amp; Periods for
                                                    <asp:Label ID="lblmode" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="height: 30px; width:130px" valign="top">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="130">
                                                                    <tr>
                                                                        <td style="width: 130px">
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
                                                                                    <tr><td style="height: 1px; width:130px;"  class="timetable_tableborder"></td></tr>
                                                                                    <tr>
                                                                                        <td style="height: 90px; width:130px; line-height: 23px" align="center" class="view_detail_subtitle_bg">
                                                                                         
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
                                                                  <%--  <tr>
                                                                        <td style="width: 130px">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="130">
                                                                                <tr><td style="height: 1px; width:130px;" class="timetable_tableborder"></td></tr>
                                                                                <tr>
                                                                                  <td style="height: 90px; width:130px;" align="center" class="timetable_daysheader">
                                                                                        Total<br />
                                                                                        Periods<br />
                                                                                        in a Day
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>--%>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td id="tdsunday" runat="server" valign="top" class="style1">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 151px; height: 91px" valign="top">
                                                                            <asp:DataList ID="dldays" runat="server" RepeatDirection="Horizontal"
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" onitemdatabound="dldays_ItemDataBound">
                                                                                <ItemStyle VerticalAlign="Top" BorderStyle="None" BorderWidth="0px" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                        <tr>
                                                                                            <td style="width: 151px; height: 40px;" class="timetable_daysheader" align="center">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "strday")%><br />
                                                                                                <%# DataBinder.Eval(Container.DataItem, "strleavedate")%>
                                                                                                <asp:Label ID="lblday" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strday")%>'></asp:Label>
                                                                                                <asp:Label ID="lblleavedate" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strleavedate1")%>'></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 151px" align="center">
                                                                                                <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                    <tr>
                                                                                                         <td class="timetable_leftborder">
                                                                                                            <asp:DataList ID="dlperiods" runat="server" RepeatDirection="Vertical" 
                                                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                                                ShowHeader="False" onitemdatabound="dlperiods_ItemDataBound" >
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
                                                                                                                                <asp:Label ID="lblday" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strday")%>'></asp:Label>
                                                                                                                                <asp:Label ID="lblleavedate" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strleavedate")%>'></asp:Label>
                                                                                                                                <asp:Label ID="lblsunperiod" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "strperiod")%>'></asp:Label>
                                                                                                                                <asp:Label ID="lblsunsub" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'>
                                                                                                                                </asp:Label><br />
                                                                                                                                <asp:Label ID="lblclass" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strclass")%>'></asp:Label><br />
                                                                                                                                 <asp:Label ID="lblstarttime" runat="server">
                                                                                                                                </asp:Label>
                                                                                                                                <asp:Label ID="lblendtime" runat="server">
                                                                                                                                 </asp:Label>
                                                                                                                                <asp:Label ID="lblsuntech" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "teachername")%>' Visible="false"></asp:Label>
                                                                                                                                <asp:DropDownList ID="ddlsunteacher" runat="server" Width="130px"></asp:DropDownList>
                                                                                                                                
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:DataList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <%--<td style="width: 151px">
                                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                                                                <tr>
                                                                                                                    <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                                    <td style="height: 1px; width:150px;" class="timetable_tableborder"></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                                    <td style="height: 90px; width:150px;" align="left" class="s_label">
                                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="150">
                                                                                                                            <tr>
                                                                                                                                <td style="width: 50px; height: 90px">
                                                                                                                                    <asp:Label ID="lbltotalperiods" runat="server" Text="0"></asp:Label>
                                                                                                                                </td>
                                                                                                                                <td style="width:1px;" class="timetable_tableborder"></td>
                                                                                                                                <td style="width: 99px; height: 90px">
                                                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="99">
                                                                                                                                        <tr>
                                                                                                                                            <td style="width: 99px; height: 45px">
                                                                                                                                                <asp:Label ID="lblassigned" runat="server" Text="0"></asp:Label>
                                                                                                                                            </td> 
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td style="width: 99px; height: 1px;" class="timetable_tableborder"></td> 
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td style="width: 99px; height: 45px">
                                                                                                                                                <asp:Label ID="lblunassigned" runat="server" Text="0"></asp:Label>
                                                                                                                                            </td> 
                                                                                                                                        </tr>
                                                                                                                                    </table>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </table>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>--%>
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
                                                </td>
                                            </tr>
                                            <tr id="trupdate" runat="server">
                                                <td style="height: 40px; color: White; font-weight: bold; border-top: solid 1px Gray" align="center" class="s_label">
                                                    <asp:Button ID="btnupdate" runat="server" CssClass="s_button" Text="Update" 
                                                        onclick="btnupdate_Click"/>
                                                    &nbsp;
                                                    <asp:Button ID="btncancel" runat="server" CssClass="s_button" 
                                                        Text="Cancel" onclick="btncancel_Click"  />
                                                </td>
                                            </tr>
                                        </table>
                                     </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 40px">
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
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
