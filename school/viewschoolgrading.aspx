﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewschoolgrading.aspx.cs" Inherits="school_viewschoolgrading" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

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
            $('#txtstarttime').timepicker();
        });
        $(document).ready(function() {
            $('#txtendtime').timepicker();
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
                        <td style="width: 94%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/25.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > School Grade</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
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
                                                         <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td align="left">
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="School Grade" ></asp:Label>
                                                </td>
                                                <td style="width: 85px">
                                                    <asp:Button ID="btnedit" runat="server" CssClass="s_button" onclick="btnedit_Click" Text="Edit" />
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td style="height:10px;" colspan="2"></td>
                                            </tr>   
                                            <tr>
                                                <td style="height: 40px" colspan="2">
                                                     <asp:DataGrid ID ="dggrade" runat="server" CellPadding="4" 
                                                        AutoGenerateColumns="False" CssClass="s_label" Width="100%" GridLines="None">
                                                         <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                         <ItemStyle CssClass="s_datagrid_item" />
                                                         <Columns>
                                                             <asp:BoundColumn DataField="intschoolgradingid" HeaderText="ID" Visible="False">
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strgrade" HeaderText="Grade">
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="intfrommarks" HeaderText="From Marks"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="inttomarks" HeaderText="To Marks"></asp:BoundColumn>
                                                         </Columns>
                                                         <HeaderStyle CssClass="s_datagrid_header" />
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
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>
