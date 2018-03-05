﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewnoticeboard.aspx.cs" Inherits="noticeboard_viewnoticeboard" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/noticeboard.ascx" tagname="noticeboard" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
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
                dateFormat: 'mm/dd/yy',
                changeMonth: true,
                changeYear: true
            });
        });
    </script>  
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
                                <tr id="trsidemenu" runat="server">
                                    <td style="width: 230px" align="right">
                                        <uc1:noticeboard ID="noticeboard1" runat="server" />
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
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/222.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">View Notice Board</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td>

                                            </td>
                                        </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 15px" valign="top" align="left">
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
			                                         <table cellpadding="0" cellspacing="0" border="0" class="app_container">
					                        <tr class="view_detail_title_bg">
					                            <td colspan="4" class="title_label">&nbsp;View Notice Board</td>
					                        </tr>
					                        <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Notice:"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlnotice" runat="server" AutoPostBack="True" 
                                                        CssClass="s_dropdown" onselectedindexchanged="ddlnotice_SelectedIndexChanged" 
                                                        Width="145px">
                                                    </asp:DropDownList>
                                                     
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtdate" runat="server" CssClass="s_textbox" AutoPostBack="true" 
                                                        ontextchanged="txtdate_TextChanged1"></asp:TextBox>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left"></td>
                                            </tr>
                                           <tr>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td align="left">
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 30px" align="left">
                                                    <asp:DataGrid ID="dgnotice" runat="server" AutoGenerateColumns="False"                                                                                                      
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        oneditcommand="dgnotice_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="id" Visible="False" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                           </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dtdate" HeaderText="Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strdescription" HeaderText="Description" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                           </asp:BoundColumn>
                                                           <asp:BoundColumn DataField="strnoticename" HeaderText="Notice" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intnotice" HeaderText="Notice ID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="View" Text="&lt;img src=&quot;../media/images/view.png&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">                                                                                                                
                                                            </asp:ButtonColumn>
                                                            </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="height: 30px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr id="trcancel" runat="server">
                                                <td colspan="4" style="height: 30px" align="left">
                                                    <asp:TextBox ID="txtbox" runat="server" CssClass="s_textbox" Height="100px" TextMode="MultiLine" Width="400px" Font-Names="arial" ForeColor="#003559"></asp:TextBox>
                                                    <asp:Button ID="btnCancel" runat="server" CssClass="s_button" Text="Cancel" Width="60px" onclick="btnCancel_Click" />
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="height: 50px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 50px" align="left">&nbsp;</td>
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
                </table>
            </td>
         </tr>
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
