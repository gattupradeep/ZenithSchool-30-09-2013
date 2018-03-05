<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewNewAdmissionDetails.aspx.cs" Inherits="feemanagement_ViewNewAdmissionDetails" %>
<%@ Register src="../usercontrol/feemanagement.ascx" tagname="feemanagement" tagprefix="uc5" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>The Schools.in - Admin</title>
<link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript" src="../media/js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></asp:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr><td style="width: 100%;" align="left"><uc3:topbanner ID="topbanner1" runat="server" /></td></tr>
        <tr><td style="width: 100%;" valign="top"><uc2:topmenu ID="topmenu1" runat="server" /></td></tr>
        <tr>
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="230"><tr><td style="width: 230px" align="right"><uc5:feemanagement ID="feemanagement1" runat="server" /></td></tr><tr><td style="width: 230px" align="right"></td></tr><tr><td style="width: 230px" align="right"><uc4:school_info ID="school_info1" runat="server" /></td></tr></table>
                        </td>
                        <td style="width: 1%" valign="top"></td>
                        <td style="width: 93%" valign="top" align="left">
                           <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                               <ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate></asp:UpdateProgress><asp:UpdatePanel ID="updatepanal" runat="server" >
                            <ContentTemplate> 
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr class="app_container_title"><td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" ><tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">View New Admission Details</td></tr></table></td></tr>
                                        <tr><td class="break"></td></tr>
                                        <tr>
                                            <td colspan="4" style="width: 100%; padding-left: 10px" valign="top" align="left">
                                                <table cellpadding="5" style="width:80%" cellspacing="0" border="0" class="app_container_auto">
                                                    <tr class="view_detail_title_bg"><td colspan="5" align="left" style="width: 100%"><asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="View New Admission Details" ></asp:Label></td></tr>
                                                    <tr>
                                                        <td align="left" style="width:20%" class="s_label">Intake Year</td>
                                                        <td align="left" style="width:20%"><asp:DropDownList ID="ddlyear" runat="server" CssClass="s_dropdown" AutoPostBack="true" Width="150px" onselectedindexchanged="ddlyear_SelectedIndexChanged"></asp:DropDownList></td>
                                                        <td align="left" style="width:20%">&nbsp;</td>
                                                        <td align="left" style="width:20%" class="s_label">Intake Month</td>
                                                        <td align="left" style="width:20%"><asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlMonth_SelectedIndexChanged"><asp:ListItem Text="All" Value="All">All</asp:ListItem><asp:ListItem Text="january" Value="01">january</asp:ListItem><asp:ListItem Text="september" Value="09">september</asp:ListItem></asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width:20%" class="s_label">Class</td>
                                                        <td align="left" style="width:20%"><asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlClass_SelectedIndexChanged"></asp:DropDownList></td>
                                                        <td align="left" style="width:20%">&nbsp;</td>
                                                        <td align="left" style="width:20%" class="s_label">Fee Mode</td>
                                                        <td align="left" style="width:20%"><asp:DropDownList ID="ddlFeeMode" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlFeeMode_SelectedIndexChanged"></asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width:20%" class="s_label">Student Name</td>
                                                        <td align="left" style="width:20%"><asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlName_SelectedIndexChanged" ></asp:DropDownList></td>
                                                        <td align="left" style="width:20%">&nbsp;</td>
                                                        <td align="left" style="width:20%" class="s_label">Payment Status</td>
                                                        <td align="left" style="width:20%"><asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged" Width="150px"><asp:ListItem Text="All" Value="All">All</asp:ListItem><asp:ListItem Text="Paid" Value="Paid">Paid</asp:ListItem><asp:ListItem Text="Unpaid" Value="Unpaid">Unpaid</asp:ListItem></asp:DropDownList></td>
                                                    </tr>
                                                    <tr><td colspan="5" align="center" style="width:100%"><asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="s_button" onclick="btnclear_Click" /></td></tr>
                                                    <tr>
                                                        <td align="left" colspan="5" style="width: 100%">
                                                            <asp:DataGrid ID="dgNewAdmn" runat="server" AutoGenerateColumns="False" Width="100%" BorderStyle="None" AllowPaging="true" PageSize="15" BorderWidth="0px" GridLines="None" CellPadding="3" onpageindexchanged="dgNewAdmn_PageIndexChanged"><AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="Year" HeaderText="Year & Month"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="StudentID" HeaderText="Admission No"></asp:BoundColumn>                                                                                                                                        
                                                                    <asp:BoundColumn DataField="Student" HeaderText="Student Name" ItemStyle-Wrap="true"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Class" HeaderText="Class" ItemStyle-Wrap="true"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Feemode" HeaderText="Fee Mode" ItemStyle-Wrap="true"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Amount" HeaderText="Amount"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Paid" HeaderText="Paid"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Balance" HeaderText="Balance"></asp:BoundColumn>                                                                                                                                                                                                            
                                                                </Columns>
                                                                <PagerStyle Mode="NumericPages" Font-Bold="true" Font-Size="Small" /><HeaderStyle CssClass="s_datagrid_header" />
                                                            </asp:DataGrid>
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
        <tr><td style="width: 100%" valign="top"><uc6:app_footer ID="footer" runat="server" /></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
