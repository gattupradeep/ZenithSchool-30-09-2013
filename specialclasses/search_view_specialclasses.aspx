<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search_view_specialclasses.aspx.cs" Inherits="specialclasses_search_view_specialclasses" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/activities_timetable.ascx" tagname="activities_timetable" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/special_class.ascx" tagname="special_class" tagprefix="uc5" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" /> 
       
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
                                        <uc5:special_class ID="special_class2" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info2" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/303.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Search | View Special Class</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
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
                                        <table cellpadding="5" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" class="title_label">&nbsp; Search | View Special Class</td>
                                            </tr>
                                             <tr>
                                                <td align="left" style="height:40px; width:150px">
                                                    &nbsp;
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Standard&Section:"></asp:Label>                                                    
                                                    &nbsp;</td>
                                                <td align="left" style="height:40px; width:150px">                                                                                                        
                                                    <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_dropdown" Width="170px" AutoPostBack="True" onselectedindexchanged="ddlclass_SelectedIndexChanged"></asp:DropDownList>                                                                                                        
                                                </td>
                                               <td align="left" style="height:40px; width:100px">
                                                    &nbsp;
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Date :"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" style="height:40px; width:150px">
                                                     <asp:TextBox ID="txtdate" runat="server" CssClass="s_textbox" Width="150px" AutoPostBack="True" ontextchanged="txtdate_TextChanged"></asp:TextBox>
                                                </td>
                                                        
                                            </tr>
                                             <tr>
                                                <td align="left" style="height:40px; width:150px">
                                                    &nbsp;
                                                   <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Subject :"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" style="height:40px; width:150px">
                                                    <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_dropdown" Width="170px" AutoPostBack="True" onselectedindexchanged="ddlsubject_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                               <td align="left" style="height:40px; width:100px">
                                                    
                                                    &nbsp;
                                                    
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Teacher :"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" style="height:40px; width:150px">
                                                    <asp:DropDownList ID="ddlteacher" runat="server" CssClass="s_dropdown" 
                                                        Width="170px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlteacher_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr >
                                                <td style="height: 40px;width:100%;" align="center" colspan="4">                                                    
                                                    <asp:Label ID="lblmsg" runat="server" CssClass="s_label" ForeColor="#CC3300"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="width:750px; height: 40px; line-height:10px" align="center">                                                    
                                                    <asp:DataGrid ID="dgspecialclass" runat="server" AutoGenerateColumns="False" 
                                                    BorderStyle="None" BorderWidth="0px" GridLines="None" Width="100%" 
                                                    oneditcommand="dgspecialclass_EditCommand">
                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                    <ItemStyle CssClass="s_datagrid_item"/>
                                                    <Columns>
                                                        <asp:BoundColumn DataField="intSpecialClassesID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>                                                                
                                                        <asp:BoundColumn DataField="strClass" HeaderText="Class" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="date" HeaderText="Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="strStartTime" HeaderText="Start time" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="strEndTime" HeaderText="End time" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn> 
                                                        <asp:BoundColumn DataField="strSubject" HeaderText="Subject" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="name" HeaderText="Teacher" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                        <asp:ButtonColumn HeaderText="View" Text="&lt;img src=&quot;../media/images/view.png&quot; alt=&quot;&quot; border=&quot;0&quot;/&gt;" CommandName="edit"></asp:ButtonColumn>
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
                                <tr><td class="break"></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
                             </ContentTemplate>
                    </asp:UpdatePanel>
            </td>
        </tr>
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
