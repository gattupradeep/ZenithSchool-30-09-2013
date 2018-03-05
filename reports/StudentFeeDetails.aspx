<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentFeeDetails.aspx.cs" Inherits="reports_StudentFeeDetails" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../usercontrol/feemanagement.ascx" tagname="feemanagement" tagprefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1" runat="server"><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>
    The Schools.in - Admin</title><link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link href="../css/autocomplete.css" media="screen" rel="stylesheet" type="text/css" />
    <%-- for Cal--%>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>    
     <script type="text/javascript">
         $(document).ready(function() {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             function EndRequestHandler(sender, args) {
                 $('#txtfromdate').datepicker({ dateFormat: 'dd/mm/yy',
                     changeMonth: true,
                     constrainDates: true,
                     changeYear: true
                 });
             }
         });
         $(document).ready(function() {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             function EndRequestHandler(sender, args) {
                 $('#txttodate').datepicker({ dateFormat: 'dd/mm/yy',
                     changeMonth: true,
                     constrainDates: true,
                     changeYear: true
                 });
             }
         });
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
         $(function() {
             var dates = $("#txtfromdate,#txttodate").daterangepicker({
                 constrainDates: true,
                 dateFormat: 'dd/mm/yy',
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
        #txtfrom,#txtTo { float: left; margin-right: 10px; }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>
    <asp:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></asp:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr><td style="width: 100%;" align="left"><uc3:topbanner ID="topbanner1" runat="server" /></td></tr>
        <tr><td style="width: 100%" valign="top"><uc2:topmenu ID="topmenu1" runat="server" /></td></tr>
        <tr class="app_container_title"><td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" ><tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">Student Fee details Report</td></tr></table></td></tr>
        <tr><td style="width: 100%; height: 400px" align="left" valign="top">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1"><ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate></asp:UpdateProgress>
                <asp:UpdatePanel ID="updatepanal" UpdateMode="Conditional" runat="server" >
                    <ContentTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td valign="top">
                                <table cellpadding="0" cellspacing="0" border="0" width="230">
                                    <tr><td align="right" style="height:30px"></td></tr>
                                    <tr><td align="right" style="height:30px"></td></tr>
                                    <tr>
                                        <td align="right">
                                            <table>
                                                <tr><td align="left" style="width:115px" class="s_label">Admission No</td><td align="left" style="width:115px"><asp:TextBox ID="txtnameAdmno" runat="server" CssClass="s_textbox" Width="115px" AutoPostBack="true" ontextchanged="txtnameAdmno_TextChanged"></asp:TextBox></td></tr>
                                                <tr><td align="left" style="width:115px" class="s_label">Receipts Type</td><td align="left" style="width:115px"><asp:DropDownList ID="drpreceipt" runat="server" CssClass="s_dropdown" Width="115px" AutoPostBack="true" onselectedindexchanged="drpreceipt_SelectedIndexChanged"><asp:ListItem Text="ALL" Value="0">ALL</asp:ListItem><asp:ListItem Text="Auto" Value="1">Auto</asp:ListItem><asp:ListItem Text="Manual" Value="2">Manual</asp:ListItem></asp:DropDownList></td></tr>
                                                <tr><td align="left" style="width:115px" class="s_label">Payment&#39;s Mode</td><td align="left" style="width:115px"><asp:DropDownList ID="drpmode" runat="server" CssClass="s_dropdown" Width="115px" AutoPostBack="true" onselectedindexchanged="drpmode_SelectedIndexChanged"><asp:ListItem Text="ALL" Value="0">ALL</asp:ListItem><asp:ListItem Text="Cash" Value="Cash">Cash</asp:ListItem><asp:ListItem Text="Cheque" Value="Cheque">Cheque</asp:ListItem><asp:ListItem Text="Cash" Value="Visa">Visa</asp:ListItem><asp:ListItem Text="Master" Value="Master">Master</asp:ListItem><asp:ListItem Text="TT" Value="TT">TT</asp:ListItem><asp:ListItem Text="Credit Card" Value="Credit Card">Credit Card</asp:ListItem></asp:DropDownList></td></tr>
                                                <tr><td align="left" style="width:115px" class="s_label">Cashier</td><td align="left" style="width:115px"><asp:DropDownList ID="drpledger" runat="server" CssClass="s_dropdown" Width="115px" AutoPostBack="true" onselectedindexchanged="drpledger_SelectedIndexChanged" ></asp:DropDownList></td></tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr><td align="right"></td></tr>
                                </table>
                            </td>
                            <td style="width: 1%" valign="top"></td>
                            <td style="width: 93%" valign="top" align="left">
                              <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr><td class="break"></td></tr>
                                    <tr>
                                        <td colspan="4" style="width: 100%; padding-left: 10px" valign="top" align="left">
                                            <table cellpadding="7" style="width:90%" cellspacing="0" border="0" class="app_container_auto">
                                                <tr class="view_detail_title_bg"><td colspan="5" style="width: 100%; height: 20px" align="left"><asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Student Fee details" ></asp:Label></td></tr>
                                                <tr><td align="left" style="width:20%" class="s_label">Academic Year</td><td align="left" style="width:20%"><asp:DropDownList ID="drpyear" runat="server" CssClass="s_dropdown" AutoPostBack="true" Width="150px" onselectedindexchanged="drpyear_SelectedIndexChanged"></asp:DropDownList></td><td align="left" style="width:20%" class="s_label">Due Type</td><td align="left" style="width:20%"><asp:DropDownList ID="drpduetype" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="drpduetype_SelectedIndexChanged"><asp:ListItem Text="all" Value="0">ALL</asp:ListItem><asp:ListItem Text="Paid" Value="Paid">Paid</asp:ListItem><asp:ListItem Text="Unpaid" Value="Unpaid">Unpaid</asp:ListItem><asp:ListItem Text="Canceled" Value="Cancelled">Canceled</asp:ListItem></asp:DropDownList></td><td align="left" style="width:20%">&nbsp;</td></tr>
                                                <tr><td align="left" style="width: 20%" class="s_label">Fee Mode</td><td align="left" style="width: 20%"><asp:DropDownList ID="drpfeemode" runat="server" AutoPostBack="True" onselectedindexchanged="drpfeemode_SelectedIndexChanged" Width="150px"></asp:DropDownList></td><td align="left" style="width: 20%" class="s_label">Class</td><td align="left" style="width: 20%"><asp:DropDownList ID="drpclass" runat="server" Width="150px" AutoPostBack="True" onselectedindexchanged="drpclass_SelectedIndexChanged"></asp:DropDownList></td><td align="left" style="width: 20%">&nbsp;</td></tr>
                                                <tr id="trdate" runat="server"><td align="left" class="s_label">From Date</td><td align="left"><asp:TextBox ID="txtfromdate" runat="server" AutoPostBack="true" CssClass="s_textbox" ontextchanged="txtfromdate_TextChanged" Width="150px"></asp:TextBox></td><td align="left" class="s_label">To Date</td><td align="left"><asp:TextBox ID="txttodate" runat="server" AutoPostBack="true" CssClass="s_textbox" ontextchanged="txttodate_TextChanged" Width="150px"></asp:TextBox></td><td align="left"></td></tr>
                                                <tr><td align="left" style="width:20%">&nbsp;</td><td align="right" style="width:20%"><asp:Button ID="btnclear" runat="server" CssClass="s_button" Text="Clear" onclick="btnclear_Click1" /></td><td align="left" style="width:20%">&nbsp;</td><td align="left" style="width:20%">&nbsp;</td><td align="left" style="width:20%">&nbsp;</td></tr>
                                                <tr>
                                                    <td colspan="5" style="width: 100%" valign="top" align="left">
                                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto" style="width:100%">
                                                            <tr class="view_detail_title_bg"><td align="left"><asp:Label ID="lbltitle1" runat="server" Text="Reports" CssClass="title_label"></asp:Label></td></tr>
                                                            <tr><td style="width:100%" align="left"><table cellpadding="0" cellspacing="0" border="0" style="width:100%"><tr><td style="width:100%" valign="top" align="left"><CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" Width="350px" AutoDataBind="true" /></td></tr></table></td></tr>
                                                        </table>                                                        
                                                    </td>
                                                </tr>
                                                <tr><td align="center" colspan="5" style="width:98%" ></td></tr>
                                            </table> 
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers><asp:PostBackTrigger ControlID="CrystalReportViewer1" /></Triggers>
                        </asp:UpdatePanel>
                        </td>   
                    </tr>
                </table>
           </div>
    </form>
</body>
</html>
