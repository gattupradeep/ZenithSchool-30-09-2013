<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogs.aspx.cs" Inherits="admin_UserLogs" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
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
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>

	
	 <script type="text/javascript">
	     $(document).ready(function() {
	         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
	         function EndRequestHandler(sender, args) {
	             $('.s_textbox').datepicker({ dateFormat: 'dd/mm/yy' });
	         }
	     });
	     $(function() {
	         var dates = $("#txtfromdate,#txttodate").daterangepicker({
	             dateFormat: "dd/mm/yy",
	             constrainDates: true,
	             datepickerOptions: {
	                 changeMonth: true,
	                 changeYear: true
	             }
	         });
	     });
	</script>
	<style type="text/css">        
        #bttnget
        {
        	display:none;
        }
        #txtfromdate,#txttodate { float: left; margin-right: 10px; }
        .style1
        {
            width: 205px;
        }
    </style>
	
	
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></ajaxtoolkit:toolkitscriptmanager>
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
                                   <%-- <td style="width: 230px" align="right">
                                        <uc1:admin_events ID="admin_events1" runat="server" />
                                    </td>--%>
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/85.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">User Activity Logs </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                           <ProgressTemplate>
                                             <div id="progressBackgroundFilter"></div>
                                             <div id="processMessage">
                                                <img alt="Loading" src="../media/images/Processing.gif" />
                                             </div>
                                          </ProgressTemplate>
                                        </asp:UpdateProgress>--%>
                                        <asp:UpdatePanel ID="updatepanal" runat="server" >
                                        <ContentTemplate> 
                                        <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                           <tr class="view_detail_title_bg">
                                                <td class="title_label" colspan="6">UserLogs</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style1">
                                                   <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="StaffName"></asp:Label></td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlstaffname" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="true" 
                                                        onselectedindexchanged="ddlstaffname_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                   <asp:Label ID="lblmenuname" runat="server" CssClass="s_label" Text="MenuName"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlmenuname" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="true" 
                                                        onselectedindexchanged="ddlmenuname_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblstatus" runat="server" Text="Status" CssClass="s_label"></asp:Label>
                                                </td> 
                                                <td style="height: 40px" align="left">
                                                       <%-- <span ><asp:Button ID="bttnget" runat="server" Text="Search" Width="50px" CssClass="s_button" OnClick="bttnsearch_click" /></span>--%>
                                                    <asp:DropDownList ID="ddlActionType" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="true" 
                                                        onselectedindexchanged="ddlActionType_SelectedIndexChanged">
                                                        
                                                    </asp:DropDownList>
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblfrom" runat="server" Text="From Date : " CssClass="s_label">
                                                    </asp:Label>
                                                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="s_textbox" 
                                                         Width="100px"></asp:TextBox>                                                    
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="tolabel" runat="server" Text="To Date: " CssClass="s_label"></asp:Label>
                                                    <asp:TextBox ID="txttodate" runat="server" CssClass="s_textbox" 
                                                        Width="100px"></asp:TextBox>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                                                                  
                                                    <asp:Button ID="btnsearch" runat="server" CssClass="s_button" Text="Search" 
                                                        onclick="btnsearch_Click" />
                                                                                                  
                                                    </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                                                                  
                                                    &nbsp;</td>
                                                <td style="width: 150px; height: 40px" align="right">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="height: 40px" align="left">
                                                    <asp:DataGrid ID="dguserlogs" runat="server" AutoGenerateColumns="False" 
                                                       Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        CellPadding="3" AllowPaging="true" 
                                                        OnPageIndexChanged="dguserlogs_PageIndexChanged" PageSize="15"> 
                                                        <PagerStyle Mode="NumericPages" />
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle  CssClass="s_datagrid_item"/>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intUserLogsID" HeaderText="ID" Visible="False"></asp:BoundColumn>                                                            
                                                            <asp:BoundColumn DataField="menuname" HeaderText="MenuName">
                                                            </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="dtDate" HeaderText="Date">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strActionType" HeaderText="Status"></asp:BoundColumn>                                                            
                                                            <asp:BoundColumn DataField="name" HeaderText="Staff Name" ></asp:BoundColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                    </asp:DataGrid>
                                                    
                                                   
                                                 </td>
                                            </tr>
                                        </table>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
       <%-- <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>--%>
    </table>
    <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>