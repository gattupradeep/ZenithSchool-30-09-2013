<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_remainder.aspx.cs" Inherits="noticeboard_view_remainder" %>
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
                $('.s_textbox').datepicker({ dateFormat: 'yy/mm/dd' });
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
                                <tr>
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
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">View Reminder</td>
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
                                                    <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" class="title_label">&nbsp;View Reminder</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 30px" align="left">
                                                &nbsp;&nbsp; 
                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtdate" CssClass="s_textbox" runat="server"></asp:TextBox>
                                                     
                                                </td>
                                                <td style="width: 150px; height: 30px" align="right"></td>
                                                <td style="width: 200px; height: 30px" align="left"></td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 30px" align="left">
                                                &nbsp;&nbsp; 
                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Reminder"></asp:Label>
                                                 </td>
                                                <td align="left">                                                 
                                                    <asp:TextBox ID="txtremainder" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td style="width: 150px; height: 30px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 30px" align="left"></td>
                                            </tr>                                          
                                             <tr>
                                                <td style="width: 150px; height: 30px" align="left">
                                                &nbsp;&nbsp; 
                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Title"></asp:Label>
                                                &nbsp;</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txttitle" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td style="width: 150px; height: 30px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                            </tr>
                                          
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td align="left">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                        Width="60px" onclick="btnSave_Click"/>
                                                    <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" 
                                                        Width="60px" onclick="btnClear_Click" />
                                                </td>
                                                <td style="width: 150px; height: 30px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td align="left">
                                                    </td>
                                                <td style="width: 150px; height: 30px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 30px" align="left">
                                                    <asp:DataGrid ID="dgremainder" runat="server" AutoGenerateColumns="False"                                                                                                      
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="intid" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dtdate" HeaderText="Date">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strremainder" HeaderText="Reminder">
                                                           </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strtitle" HeaderText="Title"></asp:BoundColumn>
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

