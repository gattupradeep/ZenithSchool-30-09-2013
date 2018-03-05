<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_bookings.aspx.cs" Inherits="transport_view_bookings" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/admin_transport.ascx" tagname="admin_transport" tagprefix="uc1" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>    
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
                                        <uc1:admin_transport ID="admin_transport1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/113.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">View&nbsp; Bus Booking</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px" valign="top" align="left">
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
                                                <td colspan="4" class="title_label">&nbsp;View&nbsp; Bus Booking</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Route No"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlrouteno" runat="server" CssClass="s_dropdown" 
                                                                 Width="100px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlrouteno_SelectedIndexChanged">                                                     
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Driver"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lbldrivername" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Vehicle No"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblvehicleno" runat="server" CssClass="s_label" Text="0"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="No. of Seats"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblnoofseats" runat="server" CssClass="s_label" Text="0"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" 
                                                                    Text="Available Seats"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblavailable" runat="server" CssClass="s_label" Text="0"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                                 Width="100px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlstandard_SelectedIndexChanged">                                                     
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                </td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <%--<tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Section"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_dropdown" 
                                                                 Width="100px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlsection_SelectedIndexChanged">                                                     
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Student"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlstudent" runat="server" CssClass="s_dropdown" 
                                                                 Width="150px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlstudent_SelectedIndexChanged">                                                     
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 40px" align="left">
                                                    <asp:DataGrid ID="dgasgnbusroute" runat="server" AutoGenerateColumns="False"
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strroutename" HeaderText="Route No" >
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strdrivername" HeaderText="Driver Name">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strvehicleno" HeaderText="Vehicle No">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="class" HeaderText="Standard"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intadmitno" HeaderText="Admission No">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="name" HeaderText="Student"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strdestination" HeaderText="Destination">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="status" HeaderText="Status">
                                                            </asp:BoundColumn>
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
                                <tr>
                                    <td class="break"></td>
                                </tr>
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
    <asp:Label ID="resultlabel" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>