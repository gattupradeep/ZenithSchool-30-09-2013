<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchstudentfee.aspx.cs" Inherits="feemanagement_searchstudentfee" %>
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
                        <td valign="top"><table cellpadding="0" cellspacing="0" border="0" width="230"><tr><td style="width: 230px" align="right"><uc5:feemanagement ID="feemanagement1" runat="server" /></td></tr><tr><td style="width: 230px; height: 15px" align="right"></td></tr><tr><td style="width: 230px" align="right"><uc4:school_info ID="school_info1" runat="server" /></td></tr></table></td>
                        <td style="width: 1%" valign="top"></td>
                        <td style="width: 93%" valign="top" align="left">
                           <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                               <ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate></asp:UpdateProgress>
                        <asp:UpdatePanel ID="updatepanal" runat="server" >
                          <ContentTemplate> 
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr class="app_container_title"> <td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" ><tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">View Fee Details</td></tr></table></td></tr>
                                        <tr><td class="break"></td></tr>
                                        <tr>
                                            <td colspan="4" style="width: 100%; padding-left: 10px" valign="top" align="left">
                                                <table cellpadding="7" style="width: 80%" cellspacing="0" border="0" class="app_container_auto">
                                                    <tr>
                                                        <td align="left" colspan="5">
                                                            <table border="0" cellpadding="5" cellspacing="1" style="width:100%">
                                                                <tr style="height:20px"><td align="left" style="width: 10%; height:20px" class="s_datagrid_header">Year</td><td align="left" style="width: 30%; height:20px" class="s_datagrid_header">Standard</td><td align="left"  style="width: 30%; height:20px" class="s_datagrid_header">Fee Mode</td><td align="left"  style="width: 10%; height:20px" class="s_datagrid_header">Amount</td></tr>
                                                                <tr style="height:20px"><td align="center" class="s_datagrid_header" style="width: 10%; height:20px"><asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="true" CssClass="s_dropdown" onselectedindexchanged="ddlyear_SelectedIndexChanged" Width="98%"></asp:DropDownList></td><td align="center" class="s_datagrid_header" style="width: 30%; height:20px"><asp:DropDownList ID="ddlstandard" runat="server" AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged" Width="98%"></asp:DropDownList></td><td align="center" class="s_datagrid_header" style="width: 30%; height:20px"><asp:DropDownList ID="ddlfeemode" runat="server" AutoPostBack="True" onselectedindexchanged="ddlfeemode_SelectedIndexChanged" Width="98%"></asp:DropDownList></td><td align="right" class="s_datagrid_header" style="width: 10%; height:20px"><asp:Button ID="btnclear" runat="server" CssClass="s_grdbutton" onclick="btnclear_Click" Text="Clear" /></td></tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="5">
                                                            <asp:DataGrid ID="dgstudentfee" runat="server" AutoGenerateColumns="False" Width="100%" BorderStyle="None" AllowPaging="true" PageSize="15" BorderWidth="0px" GridLines="None" CellPadding="3" onpageindexchanged="dgstudentfee_PageIndexChanged" ShowHeader="false"><AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="intID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="intyear" HeaderText="Year" ItemStyle-Width="10%"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="strstandard" HeaderText="Standard" ItemStyle-Width="30%" ItemStyle-Wrap="true" ></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="strfeemode" HeaderText="Fee Mode" ItemStyle-Width="30%" ItemStyle-Wrap="true"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="intAmount" HeaderText="Amount" ItemStyle-Width="10%"></asp:BoundColumn>
                                                                </Columns>
                                                                <PagerStyle Mode="NumericPages" Font-Bold="true" Font-Size="Small" /><HeaderStyle CssClass="s_datagrid_header" />
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <tr><td align="left"><asp:HiddenField ID="HidCyear" runat="server" /><asp:HiddenField ID="HidAdm" runat="server" /></td><td align="left" colspan="4"><asp:HiddenField ID="HiddenField1" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" /></td></tr>
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