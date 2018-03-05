<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome_admin.aspx.cs" Inherits="welcome_Welcome_admin" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc1" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
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
     <script language="javascript" type="text/javascript">
         function openNewWin1(url) {
             var x = window.open(url, 'mynewwin', 'width=820,height=400,toolbar=0,scrollbars=yes');
             x.focus();
         } 
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
                                        <uc1:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 2%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="760">
                                            <tr>
                                                <td style="width: 760px; height: 400px; background-image: url(../media/images/dashboardback.jpg); background-repeat: repeat-x" align="left" valign="top">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="760">
                                                        <tr>
                                                            <td style="width: 560px; height: 400px" valign="top" align="left">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="550">
                                                                    <tr>
                                                                        <td style="width: 550px; height: 40px; padding-left: 20px">
                                                                            <img src="../media/images/welcometotheschools.png" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr><td style="width: 550px; height: 1px; background-color: #b3b3b3"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr>
                                                                        <td style="width: 550px; height: 100px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="550">
                                                                                <tr>
                                                                                    <td style="width: 120px; height: 105px" align="right"><img src="../media/images/icon01.gif" alt="Notice Board" /></td>
                                                                                    <td style="width: 10px; height: 105px"></td>
                                                                                    <td style="width: 420px; height: 105px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                            <tr>
                                                                                                <td style="width: 420px; height: 30px" align="left">
                                                                                                   <asp:UpdatePanel ID="upnotice" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                                        <tr>
                                                                                                            <td style="width: 300px; height: 30px; padding-left: 20px" class="s_dash_title">
                                                                                                                Notice Board </td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="right"><asp:ImageButton ID="btnNprevious" runat="server" ImageUrl="../media/images/leftarrow.gif" onclick="btnNprevious_Click" />
                                                                                                                &nbsp;&nbsp;
                                                                                                                <br />
                                                                                                                Previous&nbsp;&nbsp; </td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="left">
                                                                                                                &nbsp; <asp:ImageButton ID="btnNnext" runat="server" 
                                                                                                                    ImageUrl="../media/images/rightarrow.gif" onclick="btnNnext_Click" /><br />
                                                                                                                &nbsp;Next
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 420px; height: 50px" colspan="3">
                                                                                                                <asp:DataGrid ID="dgnotice" runat="server" CellPadding="4" GridLines="None" 
                                                                                                                    Width="100%" AutoGenerateColumns="false" AllowPaging="true" PageSize="1" 
                                                                                                                    ShowHeader="False">
                                                                                                                    <PagerStyle Visible="False" />
                                                                                                                    <AlternatingItemStyle ForeColor="White"/>
                                                                                                                    <ItemStyle ForeColor="White"/>
                                                                                                                    <Columns>
                                                                                                                        <asp:TemplateColumn>
                                                                                                                            <ItemTemplate>
                                                                                                                               <asp:Panel ID="Panel1" Width="420" Height="100" ScrollBars="Vertical" runat="server" CssClass="curve">
                                                                                                                                <table width="100%">
                                                                                                                                    <tr>
                                                                                                                                        <td style="font-weight:bold; color:Black; width:150px"  class="s_label">
                                                                                                                                          <asp:Label ID="lblnotice" runat="server" CssClass="s_label" Text="Notice:"></asp:Label>
                                                                                                                                           <%# DataBinder.Eval(Container, "DataItem.strnoticename")%>
                                                                                                                                        </td>
                                                                                                                                        <td style="font-weight:bold; color:Black; width:150px" align="right" class="s_label">
                                                                                                                                          <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Date:"></asp:Label>
                                                                                                                                            <%# DataBinder.Eval(Container, "DataItem.date")%>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td colspan="2" style="width:300px" class="s_label">
                                                                                                                                          <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Description:"></asp:Label>
                                                                                                                                             <%# DataBinder.Eval(Container, "DataItem.strdescription")%>
                                                                                                                                        </td>
                                                                                                                                        
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                                </asp:Panel>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateColumn>
                                                                                                                    </Columns>
                                                                                                                    <HeaderStyle/>
                                                                                                                </asp:DataGrid>
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
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px; background-image: url(../media/images/line1.png)"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr>
                                                                        <td style="width: 550px; height: 100px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="550">
                                                                                <tr>
                                                                                    <td style="width: 120px; height: 105px" align="right"><img src="../media/images/icon02.gif" alt="Notice Board" /></td>
                                                                                    <td style="width: 10px; height: 105px"></td>
                                                                                    <td style="width: 420px; height: 105px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                            <tr>
                                                                                                <td style="width: 420px; height: 30px" align="left">
                                                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                                            <tr>
                                                                                                                <td style="width: 300px; height: 30px" class="s_dash_title">
                                                                                                                    <asp:Label ID="lbltimetabletoday" runat="server"></asp:Label>&#39;s Timetable<asp:Label ID="lbltimetabledate" runat="server" Visible="false"></asp:Label></td>
                                                                                                                <td style="width: 60px; height: 30px" valign="top" align="right">
                                                                                                                    <asp:ImageButton ImageUrl="../media/images/leftarrow.gif" 
                                                                                                                        ID="btntimetableyesterday" runat="server" 
                                                                                                                        onclick="btntimetableyesterday_Click" />
                                                                                                                    <br />
                                                                                                                    <asp:Label ID="lbltimetableyesterday" runat="server"></asp:Label></td>
                                                                                                                <td style="width: 60px; height: 30px" valign="top" align="left">
                                                                                                                    <asp:ImageButton ImageUrl="../media/images/rightarrow.gif" 
                                                                                                                        ID="btntimetable2marrow" runat="server" onclick="btntimetable2marrow_Click" /><br />
                                                                                                                    &nbsp;<asp:Label ID="lbltimetable2marrow" runat="server"></asp:Label></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 420px; height: 50px" colspan="3" align="left">
                                                                                                                    <asp:Panel ID="Panel1" Width="410" Height="100" ScrollBars="Horizontal" runat="server" CssClass="curve">
                                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                                                            <tr>
                                                                                                                                <td align="left" style="height: 40px; width: 100%">
                                                                                                                                    <asp:DataGrid ID="dgtimetable" runat="server" AutoGenerateColumns="False" 
                                                                                                                                        BorderStyle="None" BorderWidth="0px" GridLines="None"  
                                                                                                                                        Width="100%">
                                                                                                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                                                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                                                                                                        <Columns>
                                                                                                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False">
                                                                                                                                            </asp:BoundColumn>
                                                                                                                                            <asp:BoundColumn DataField="strclass" HeaderStyle-HorizontalAlign="Center" 
                                                                                                                                                HeaderText="Class" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                                                                                            <asp:BoundColumn DataField="strteacher" HeaderStyle-HorizontalAlign="Center" 
                                                                                                                                                HeaderText="Teacher Name" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                                                                                            <asp:BoundColumn DataField="strperiod" HeaderStyle-HorizontalAlign="Center" 
                                                                                                                                                HeaderText="Period" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                                                                                            <asp:BoundColumn DataField="strsubject" HeaderStyle-HorizontalAlign="Center" 
                                                                                                                                                HeaderText="Subject" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                                                                                        </Columns>
                                                                                                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                                                                                                    </asp:DataGrid>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </table>
                                                                                                                    </asp:Panel>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 420px; height: 40px" colspan="3" align="left">
                                                                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                                                                        <tr>
                                                                                                                            <td style="width: 100px; height:40px"><asp:Label ID="lblselect0" runat="server" 
                                                                                                                                    Text="Select Class"></asp:Label></td>
                                                                                                                            <td style="width: 100px; height:40px">
                                                                                                                                <asp:DropDownList ID="ddlclassfortime" runat="server" AutoPostBack="True" 
                                                                                                                                    CssClass="s_dropdown1" Width="100px" 
                                                                                                                                    onselectedindexchanged="ddlclassfortime_SelectedIndexChanged">
                                                                                                                                </asp:DropDownList>
                                                                                                                            </td>
                                                                                                                            <td style="width: 100px; height:40px">
                                                                                                                                <asp:Label ID="lblselect1" runat="server" Text="Select Teacher"></asp:Label>
                                                                                                                            </td>
                                                                                                                            <td style="width: 120px; height:40px">
                                                                                                                                <asp:DropDownList ID="ddlteacherfortime" runat="server" AutoPostBack="True" 
                                                                                                                                    CssClass="s_dropdown1" Width="100px" 
                                                                                                                                    onselectedindexchanged="ddlteacherfortime_SelectedIndexChanged">
                                                                                                                                </asp:DropDownList>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
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
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px; background-image: url(../media/images/line1.png)"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr>
                                                                        <td style="width: 550px; height: 100px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="550">
                                                                                <tr>
                                                                                    <td style="width: 120px; height: 105px" align="right"><img src="../media/images/icon03.gif" alt="Notice Board" /></td>
                                                                                    <td style="width: 10px; height: 105px"></td>
                                                                                    <td style="width: 420px; height: 105px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                            <tr>
                                                                                                <td style="width: 420px; height: 30px" align="left">
                                                                                                    <asp:UpdatePanel ID="upteachingshedule" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                                        <tr>
                                                                                                            <td style="width: 300px; height: 30px;  padding-left: 20px; background-image:url(../media/images/t_teachingschedule.png); background-repeat: no-repeat" class="s_dash_title">
                                                                                                                <asp:Label ID="lblabsenttoday" runat="server"></asp:Label>
                                                                                                                &#39;s Absent List
                                                                                                                <asp:Label ID="lblabsentdate" runat="server" Visible="false"></asp:Label>
                                                                                                            </td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="right">
                                                                                                                <asp:ImageButton ID="btnSyeaterday" runat="server" ImageUrl="../media/images/leftarrow.gif" onclick="btnSyeaterday_Click" />
                                                                                                                <br />
                                                                                                                <asp:Label ID="lbltimetableyesterday0" runat="server"></asp:Label>
                                                                                                                &nbsp;&nbsp;<br />                                                                                                                
                                                                                                            </td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="left"><asp:ImageButton ID="btnStomorrow" runat="server" ImageUrl="../media/images/rightarrow.gif" onclick="btnStomorrow_Click" />
                                                                                                                <br />
                                                                                                                <asp:Label ID="lbltimetable2marrow0" runat="server"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 420px; height:80px;" colspan="3">
                                                                                                                <asp:Panel ID="Panel2" Width="410" Height="100" ScrollBars="Horizontal" runat="server" CssClass="curve">
                                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                                                        <tr>
                                                                                                                            <td align="left" style="height: 40px; width: 100%">
                                                                                                                                <asp:DataGrid ID="dgabsent" runat="server" AutoGenerateColumns="False" 
                                                                                                                                    BorderStyle="None" BorderWidth="0px" GridLines="None"  
                                                                                                                                    Width="100%">
                                                                                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                                                                                    <ItemStyle CssClass="s_datagrid_item" />
                                                                                                                                    <Columns>
                                                                                                                                        <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False">
                                                                                                                                        </asp:BoundColumn>
                                                                                                                                        <asp:BoundColumn DataField="strclass" HeaderStyle-HorizontalAlign="Center" 
                                                                                                                                            HeaderText="Class" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                                                                                        <asp:BoundColumn DataField="strteacher" HeaderStyle-HorizontalAlign="Center" 
                                                                                                                                            HeaderText="Teacher Name" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                                                                                        <asp:BoundColumn DataField="strperiod" HeaderStyle-HorizontalAlign="Center" 
                                                                                                                                            HeaderText="Period" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                                                                                        <asp:BoundColumn DataField="strsubject" HeaderStyle-HorizontalAlign="Center" 
                                                                                                                                            HeaderText="Subject" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                                                                                    </Columns>
                                                                                                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                                                                                                                </asp:DataGrid>
                                                                                                                                <asp:Label ID="lblabsentlist" runat="server" Text="No Absenties" Visible="false"></asp:Label>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </asp:Panel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 420px; height: 40px" colspan="3" align="left">
                                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                                    <tr>
                                                                                                                        <td style="width: 100px; height:40px">
                                                                                                                            <asp:Label ID="Label1" runat="server" 
                                                                                                                                Text="Select Type"></asp:Label></td>
                                                                                                                        <td style="width: 200px; height:40px">
                                                                                                                            <asp:DropDownList ID="ddlstafftype" runat="server" AutoPostBack="True" 
                                                                                                                                CssClass="s_dropdown1" Width="180px" 
                                                                                                                                onselectedindexchanged="ddlstafftype_SelectedIndexChanged">
                                                                                                                                <asp:ListItem>Teaching Staffs</asp:ListItem>
                                                                                                                                <asp:ListItem>Non Teaching Staffs</asp:ListItem>
                                                                                                                            </asp:DropDownList>
                                                                                                                        </td>
                                                                                                                        <td style="width: 120px; height:40px">
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
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
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px; background-image: url(../media/images/line1.png)"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr>
                                                                        <td style="width: 550px; height: 100px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="550">
                                                                                <tr>
                                                                                    <td style="width: 120px; height: 105px" align="right"><img src="../media/images/icon04.gif" alt="Notice Board" /></td>
                                                                                    <td style="width: 10px; height: 105px"></td>
                                                                                    <td style="width: 420px; height: 105px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                            <tr>
                                                                                                <td style="width: 420px; height: 30px" align="left">
                                                                                                    <asp:UpdatePanel ID="upleaverequest" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                                                <tr>
                                                                                                                    <td style="width: 300px; height: 30px; padding-left: 20px; background-image:url(../media/images/t_homeworkassigned.png); background-repeat: no-repeat" class="s_dash_title">
                                                                                                                        <asp:Label ID="lblrequesttoday" runat="server"></asp:Label>
                                                                                                                        &#39;s Leave Request
                                                                                                                        <asp:Label ID="lblrequestdate" runat="server" Visible="false"></asp:Label>
                                                                                                                    </td>
                                                                                                                    <td style="width: 60px; height: 30px" valign="top" align="right">
                                                                                                                        <asp:ImageButton ID="btnLryesterday" runat="server" 
                                                                                                                            ImageUrl="../media/images/leftarrow.gif" onclick="btnLryesterday_Click" />
                                                                                                                        <br />
                                                                                                                        <asp:Label ID="lbltimetableyesterday1" runat="server"></asp:Label>
                                                                                                                    </td>
                                                                                                                    <td style="width: 60px; height: 30px" valign="top" align="left">
                                                                                                                        &nbsp; <asp:ImageButton ID="btnLrtommorow" runat="server" 
                                                                                                                            ImageUrl="../media/images/rightarrow.gif" onclick="btnLrtommorow_Click"/>
                                                                                                                        <br />
                                                                                                                        <asp:Label ID="lbltimetable2marrow1" runat="server"></asp:Label>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 420px; height: 50px" colspan="3">
                                                                                                                        <asp:Panel ID="Panel3" Width="410" Height="100" ScrollBars="Horizontal" runat="server" CssClass="curve">
                                                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                                                                <tr>
                                                                                                                                    <td align="left" style="height: 40px; width: 100%">
                                                                                                                                        <asp:DataGrid ID="dgleaverequest" runat="server" AutoGenerateColumns="False" 
                                                                                                                                            BorderStyle="None" BorderWidth="0px" GridLines="None"  
                                                                                                                                            Width="100%">
                                                                                                                                            <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                                                                                            <ItemStyle CssClass="s_datagrid_item" />
                                                                                                                                            <Columns>
                                                                                                                                                <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False">
                                                                                                                                                </asp:BoundColumn>
                                                                                                                                                <asp:BoundColumn DataField="strstaffname" HeaderStyle-HorizontalAlign="Center" 
                                                                                                                                                    HeaderText="Staff Name" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                                                                                                <asp:BoundColumn DataField="strleavecategory" HeaderStyle-HorizontalAlign="Center" 
                                                                                                                                                    HeaderText="Leave Type" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                                                                                                <asp:BoundColumn DataField="strsession" HeaderStyle-HorizontalAlign="Center" 
                                                                                                                                                    HeaderText="Mode of Leave" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                                                                                            </Columns>
                                                                                                                                            <HeaderStyle CssClass="s_datagrid_header" />
                                                                                                                                        </asp:DataGrid>
                                                                                                                                        <asp:Label ID="lblLrequest" runat="server" CssClass="s_label"></asp:Label>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </asp:Panel>
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
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px; background-image: url(../media/images/line1.png)"></td></tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 2px; height: 400px; background-color: #b3b3b3"></td>
                                                            <td style="width: 6px; height: 400px"></td>
                                                            <td style="width: 192px; height: 400px; padding-top: 10px" valign="top" align="left">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="192">
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="192">
                                                                                <tr>
                                                                                    <td style="width: 52px; height: 52px; background-image: url(../media/images/Reminders.gif)"></td>
                                                                                    <td style="width: 140px; height: 52px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="140">
                                                                                            <tr>
                                                                                                <td style="width: 140px; height: 30px; padding-left: 10px" class="s_dash_title1">
                                                                                                    Reminder  
                                                                                                </td>                  
                                                                                            </tr>
                                                                                             <tr>
                                                                                                <td style="width: 140px; height:1px; background-color: #000000"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 50px;" valign="top">
                                                                                        <asp:Panel ID="pnlremainder" runat="server" ScrollBars="Vertical" Width="192px" Height="150px">
                                                                                        <asp:DataGrid ID="dgreminder" runat="server" CellPadding="4" GridLines="None" Width="180px" AutoGenerateColumns="false" AllowPaging="true" ShowHeader="False">
                                                                                            <PagerStyle Visible="False" />
                                                                                            <AlternatingItemStyle ForeColor="White"/>
                                                                                            <ItemStyle ForeColor="White"/>
                                                                                            <Columns>
                                                                                                <asp:TemplateColumn>
                                                                                                    <ItemTemplate>
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="180">
                                                                                                           <%-- <tr>
                                                                                                                <td style="font-weight:bold; color:Black; font-size:11px;">
                                                                                                                    <%# DataBinder.Eval(Container, "DataItem.strdate")%>
                                                                                                                </td>
                                                                                                            </tr>--%>
                                                                                                            <tr>
                                                                                                                <td style="font-weight:bold; color:Black; font-size:11px;">
                                                                                                                    <%# DataBinder.Eval(Container, "DataItem.title")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="s_label" style="font-size:12px;">
                                                                                                                    <%# DataBinder.Eval(Container, "DataItem.description")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateColumn>
                                                                                            </Columns>
                                                                                            <HeaderStyle/>
                                                                                        </asp:DataGrid>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 10px;" valign="top">
                                                                                        
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="192">
                                                                                <tr>
                                                                                    <td style="width: 52px; height: 52px; background-image: url(../media/images/Quick_View.gif); background-repeat: no-repeat"></td>
                                                                                    <td style="width: 140px; height: 52px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="140">
                                                                                            <tr>
                                                                                                <td style="width: 140px; height: 30px; padding-left: 10px" class="s_dash_title1">
                                                                                                    Quick View</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 140px; height:1px; background-color: #000000"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" style="width: 192px; height: 50px;" class="s_text" valign="top">
                                                                                        <asp:DataGrid ID="dgquickview" runat="server" AutoGenerateColumns="false" PageSize="1" ShowHeader="False" CellPadding="4" GridLines="None" Width="100%" AllowPaging="true">
                                                                                            <PagerStyle Visible="False" />
                                                                                            <AlternatingItemStyle ForeColor="White"/>
                                                                                            <ItemStyle ForeColor="White"/>
                                                                                            <Columns>
                                                                                                <asp:TemplateColumn>
                                                                                                    <ItemTemplate>
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td style=" font-family:Verdana; color:Black; font-size:11px; width:120px">Total 
                                                                                                                    Messages(<%# DataBinder.Eval(Container, "DataItem.totalcount")%>),</td>
                                                                                                                <td style=" font-family:Verdana; color:Black; font-size:11px; width:70px">Unread(<%# DataBinder.Eval(Container, "DataItem.unreadcount")%>)</td>
                                                                                                            </tr>                                                                                                            
                                                                                                        </table>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateColumn>                                                       
                                                                                            </Columns>                                                                                            
                                                                                        </asp:DataGrid>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-family:Verdana; color:Black; font-size:11px; width:50px" align="center">
                                                                                        Attendance</td>
                                                                                    <td style=" font-family:Verdana; color:Black; font-size:11px; width:100px" align="center">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td>P-<asp:Label ID="lblpresent" runat="server"></asp:Label></td>
                                                                                                <td>A-<asp:Label ID="lblabsent" runat="server"></asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>L-P(<asp:Label ID="lblpending" runat="server"></asp:Label>)</td>
                                                                                                <td>R(<asp:Label ID="lblreject" runat="server"></asp:Label>)</td>
                                                                                            </tr>
                                                                                        </table>                                                                                  
                                                                                    </td>                                                                                                                                                                        
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" style="width: 192px; height: 10px;">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="192">
                                                                                <tr>
                                                                                    <td style="width: 52px; height: 52px; background-image: url(../media/images/Calendar.gif)"></td>
                                                                                    <td style="width: 140px; height: 52px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="140">
                                                                                            <tr>
                                                                                                <td style="width: 140px; height: 30px; padding-left: 10px" class="s_dash_title1">
                                                                                                    Calendar</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 140px; height:1px; background-color: #000000"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 50px;" class="s_text" valign="top">
                                                                                        <asp:Calendar ID="Calendar1" runat="server" ondayrender="Calendar1_DayRender"></asp:Calendar>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 10px;" class="s_text" valign="top">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td style="width:100px">
                                                                                                     <asp:TextBox ID="txt1" runat="server" CssClass="s_textbox" Width="20px" Height="10px" BackColor="LightSeaGreen"></asp:TextBox>
                                                                                                     &nbsp;&nbsp;<asp:Label ID="lbl1" runat="server" Text="= HalfDay"></asp:Label></td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt2" runat="server" CssClass="s_textbox" Width="20px" 
                                                                                                        Height="10px" BackColor="#AAAAFF"></asp:TextBox>
                                                                                                    &nbsp;<asp:Label ID="Label2" runat="server" Text="= Holiday"></asp:Label></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="192">
                                                                                <tr>
                                                                                    <td style="width: 52px; height: 52px; background-image: url(../media/images/this_week.gif)"></td>
                                                                                    <td style="width: 140px; height: 52px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="140">
                                                                                            <tr>
                                                                                                <td style="width: 140px; height: 30px; padding-left: 10px" class="s_dash_title1">
                                                                                                    This Week</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 140px; height:1px; background-color: #000000"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 50px;" class="s_text" valign="top">
                                                                                        <asp:DataGrid ID="dgThisweek" runat="server" CellPadding="4" 
                                                                                             GridLines="None" Width="100%" AutoGenerateColumns="false" AllowPaging="true" PageSize="1" AllowSorting="True">                                                                                                                    
                                                                                             <PagerStyle Visible="False" />
                                                                                             <Columns>  
                                                                                                <asp:TemplateColumn HeaderText="Date">
                                                                                                     <ItemTemplate>
                                                                                                         <table width="120px">
                                                                                                               <tr>
                                                                                                                    <td style="font-size:9px; width:110px; font-family:Verdana" class="s_label" align="center">
                                                                                                                         <a href="../events/viewevents.aspx"><%# DataBinder.Eval(Container, "DataItem.date")%></a>
                                                                                                                    </td>
                                                                                                               </tr>
                                                                                                         </table>
                                                                                                      </ItemTemplate>
                                                                                                 </asp:TemplateColumn>
                                                                                                <asp:BoundColumn DataField="streventname" HeaderText="EventName" ItemStyle-Font-Names="Verdana" ItemStyle-Font-Size="9px">
                                                                                                    <ItemStyle Width="102px" HorizontalAlign="Center" CssClass="s_label" />
                                                                                                </asp:BoundColumn>                                                                                               
                                                                                            </Columns>
                                                                                           <HeaderStyle ForeColor="Black" BackColor="White" Font-Names="Verdana" Font-Size="11px" HorizontalAlign="Center"/>
                                                                                       </asp:DataGrid>
                                                                                       <asp:Label ID="lblthisweek" runat="server" CssClass="s_label"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 10px;" class="s_text" valign="top">
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
        <asp:Label ID="lblnoticecount" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblnoticeindex" runat="server" Visible="false" Text="0"></asp:Label>
        <asp:Label ID="lblsheduledate" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblLrequestdate" runat="server" Visible="false" Text="0"></asp:Label>
    </div>
    </form>
</body>
</html>
