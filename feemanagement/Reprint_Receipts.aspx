<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reprint_Receipts.aspx.cs" Inherits="feemanagement_Reprint_Receipts" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../usercontrol/feemanagement.ascx" tagname="feemanagement" tagprefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1" runat="server"><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>
    The Schools.in - Admin</title><link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link href="../css/autocomplete.css" media="screen" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
    <div>
    <asp:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></asp:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr><td style="width: 100%;" align="left"><uc3:topbanner ID="topbanner1" runat="server" /></td></tr>
        <tr><td style="width: 100%" valign="top"><uc2:topmenu ID="topmenu1" runat="server" /></td></tr>
        <tr>
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
                    <ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate></asp:UpdateProgress><asp:UpdatePanel ID="updatepanal" UpdateMode="Conditional" runat="server" >
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td valign="top"><table cellpadding="0" cellspacing="0" border="0" width="230"><tr><td align="right"><uc5:feemanagement ID="feemanagement1" runat="server" /></td></tr><tr><td align="right" style="height:20px"><uc4:school_info ID="feemanagement2" runat="server" /></td></tr></table></td>
                            <td style="width: 1%" valign="top"></td>
                            <td style="width: 93%" valign="top" align="left">
                              <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr class="app_container_title">
                                        <td style="width: 100%; " align="left">
                                            <table cellpadding="0" cellspacing="0" border="0" >
                                                <tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">Student Fee Collection Receipts Details</td></tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr><td class="break"></td></tr>
                                    <tr>
                                        <td colspan="4" style="width: 100%; padding-left: 10px" valign="top" align="left">
                                            <table cellpadding="7" style="width:90%" cellspacing="0" border="0" class="app_container_auto">
                                                <tr class="view_detail_title_bg"><td colspan="5" style="width: 100%; height: 20px" align="left"><asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Student Fee Collection Receipts Details" ></asp:Label></td></tr>
                                                <tr ><td align="left" class="s_label">Academic Year</td><td align="left"><asp:DropDownList ID="ddlyear" runat="server" CssClass="s_dropdown" AutoPostBack="true" Width="150px" onselectedindexchanged="ddlyear_SelectedIndexChanged" ></asp:DropDownList></td><td align="left" class="s_label">Standard</td><td align="left"><asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True"  Width="150px" onselectedindexchanged="ddlclass_SelectedIndexChanged"></asp:DropDownList></td><td align="left"><asp:HiddenField ID="HidCyear" runat="server" /></td></tr>
                                                <tr><td align="left" class="s_label">Admission No</td><td align="left"><asp:DropDownList ID="ddlAdmission" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlAdmission_SelectedIndexChanged"></asp:DropDownList></td><td align="left" class="s_label">Student</td><td align="left"><asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlName_SelectedIndexChanged"></asp:DropDownList></td><td align="left">&nbsp;</td></tr>
                                                <tr><td align="left"></td><td align="right"><asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" onclick="btnClear_Click" /></td><td align="left"></td><td align="left"></td><td align="left"></td></tr>
                                                <tr>
                                                    <td colspan="5" style="width: 100%" valign="top" align="left">
                                                        <table cellpadding="0" cellspacing="0" border="0" style="width:100%;">
                                                            <tr>
                                                                <td style="width:100%" align="left">
                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width:100%">
                                                                        <tr>
                                                                            <td style="width:100%" valign="top" align="left">
                                                                                <asp:DataGrid ID="dgReceipts" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="3" onpageindexchanged="dgReceipts_PageIndexChanged"><AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item"/><HeaderStyle CssClass="s_datagrid_header"/>
                                                                                    <Columns>
                                                                                        <asp:BoundColumn DataField="TransactionID" Visible="false"></asp:BoundColumn> 
                                                                                        <asp:BoundColumn DataField="Year" HeaderText="Year" ItemStyle-Width="10%"><ItemStyle Width="10%"></ItemStyle></asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="strReceiptNo" HeaderText="Receipt No" ItemStyle-Width="10%"><ItemStyle Width="10%"></ItemStyle></asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="Name" HeaderText="Student" ItemStyle-Width="40%" ItemStyle-Wrap="true"><ItemStyle Width="40%"></ItemStyle></asp:BoundColumn> 
                                                                                        <asp:BoundColumn DataField="AdmissionNo" HeaderText="Admission No" ItemStyle-Width="15%"><ItemStyle Width="15%"></ItemStyle></asp:BoundColumn> 
                                                                                        <asp:BoundColumn DataField="Amount" HeaderText="Paid Amount" ItemStyle-Width="15%"><ItemStyle Width="15%"></ItemStyle></asp:BoundColumn> 
                                                                                        <asp:BoundColumn DataField="PaidDate" HeaderText="Paid Date" ItemStyle-Width="10%"><ItemStyle Width="10%"></ItemStyle></asp:BoundColumn> 
                                                                                        <asp:BoundColumn DataField="Descriptions" HeaderText="Paid Date" Visible="false"></asp:BoundColumn> 
                                                                                        <asp:BoundColumn DataField="ReferenceNo" HeaderText="Paid Date" Visible="false"></asp:BoundColumn> 
                                                                                        <asp:BoundColumn DataField="Remitter" HeaderText="Paid Date" Visible="false"></asp:BoundColumn> 
                                                                                        <asp:BoundColumn DataField="Cashier" HeaderText="Paid Date" Visible="false"></asp:BoundColumn> 
                                                                                        <asp:BoundColumn DataField="PayMode" HeaderText="Paid Date" Visible="false"></asp:BoundColumn> 
                                                                                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center"><ItemTemplate><asp:Button id="BtnPrint"  runat="server" CssClass="s_grdbutton" CausesValidation="false" CommandName="button" Text="Print" onclick="BtnPrint_Click" /></ItemTemplate><ItemStyle HorizontalAlign="Center"></ItemStyle></asp:TemplateColumn>
                                                                                    </Columns>
                                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="Left" />
                                                                                </asp:DataGrid>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr><td align="center" colspan="5" style="width:98%" ></td></tr>
                                            </table> 
                                        </td>
                                    </tr>
                                </table>
                             </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>   
                    </tr>
                </table>
           </div>
    </form>
</body>
</html>
