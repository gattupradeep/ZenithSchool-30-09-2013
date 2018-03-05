<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewstaffleavetaken.aspx.cs" Inherits="Leave_viewstaffleavetaken" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<%@ Register src="../usercontrol/admin_leave.ascx" tagname="admin_leave" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1" runat="server"><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>
    The Schools.in - Admin</title><link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" /><link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" /><link href="../media/css/calendar.css" media="screen" rel="stylesheet" type="text/css" />
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
    </head><body><form id="form1" runat="server">
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
                                        <uc1:admin_leave ID="admin_leave1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc5:school_info ID="school_info1" runat="server" />
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
                                                <td align="left" >View Staff leave Details</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="1" cellspacing="0" border="0" width="100%" class="app_container_auto">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="6" align="center">
                                                    <asp:Label ID="lbltitle" runat="server" Text="Staff Leave Details " CssClass="header_lable"></asp:Label>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="left" style="height: 2px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="left" style="width:90%">
                                                    <table cellpadding="1" cellspacing="0" border="0" width="100%">
                                                        <tr class="view_detail_title_bg">
                                                            <td align="right">&nbsp;
                                                            <asp:Label ID="lblid" runat="server" Text="Staff ID :" CssClass="header_lable">
                                                            </asp:Label>
                                                                </td>
                                                            <td align="left" >&nbsp;
                                                             <asp:Label ID="lblidtxt" runat="server" Text="Staff ID"  CssClass="header_lable">
                                                            </asp:Label>
                                                                </td>
                                                            <td align="right">
                                                             <asp:Label ID="lblname" runat="server" Text="Staff Name :"  CssClass="header_lable">
                                                            </asp:Label>
                                                                </td>
                                                            <td align="left">&nbsp;
                                                                 <asp:Label ID="lblnametxt" runat="server" Text="Staff Name" CssClass="header_lable">
                                                            </asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                <asp:Label ID="lblleavetext" Text="Leave type :" runat="server"  CssClass="header_lable">
                                                                        </asp:Label>&nbsp;
                                                                        <asp:DropDownList ID="drpleavetype" runat="server" CssClass="s_dropdown" AutoPostBack="true"  
                                                                        Width="140px" onselectedindexchanged="drpleavetype_SelectedIndexChanged">
                                                                    </asp:DropDownList></td>
                                                            <td align="left">
                                                            <asp:Label ID="lblyear" runat="server" Text="Year :" Width="40px" CssClass="header_lable" Visible="false">
                                                            </asp:Label>&nbsp;
                                                            <asp:DropDownList ID="drpyear" runat="server" CssClass="s_dropdown" 
                                                                    AutoPostBack="true" Width="80px" Visible="false" 
                                                                    onselectedindexchanged="drpyear_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                       </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="6" style="width: 95%; height: 40px">
                                                  
                                                    <asp:DataGrid ID="dgstaffleave" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                                                    Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="3" 
                                                        onpageindexchanged="dgstaffleave_PageIndexChanged" >                                                            
                                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intleavecategory" HeaderText="Leave" Visible="false">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strleavetype" HeaderText="Leave Type">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intnoofdays" HeaderText="Assigned Days">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="ct" HeaderText="Used Days">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="leavedate" HeaderText="Leave Days">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="mode" HeaderText="Mode">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="session" HeaderText="Session" >
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="reason" HeaderText="Reason">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="availdays" HeaderText="Available Days">
                                                            </asp:BoundColumn>
                                                        </Columns>
                                                        <PagerStyle Mode="NumericPages" Font-Bold="true" Font-Size="Small" />
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                        </asp:DataGrid>
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" >
                                                    <asp:Button ID="btnback" runat="server" CssClass="s_button" Text="Back" 
                                                        onclick="btnback_Click" />
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
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top">
                &nbsp;</td>
        </tr>
    </table>
   <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>
