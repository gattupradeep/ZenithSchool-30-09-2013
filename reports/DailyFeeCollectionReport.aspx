<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DailyFeeCollectionReport.aspx.cs" Inherits="reports_DailyFeeCollectionReport" %>
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
	<script type="text/javascript">
	    function Validate() {
	        if (document.getElementById('txtfromdate').value == "") {
	            alert("Please select from date to proceed");
	            document.getElementById('txtfromdate').focus();
	            return false
	        }
	        if (document.getElementById('txttodate').value == "") {
	            alert("Please select to date to proceed");
	            document.getElementById('txttodate').focus();
	            return false
	        }
	    }
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
        <tr class="app_container_title"><td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" ><tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">Student Fee Collection Detail Report</td></tr></table></td></tr>        
        <tr>
            <td style="width: 100%; height: 400px" align="left" valign="top">
               <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1"><ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate></asp:UpdateProgress>
               <asp:UpdatePanel ID="updatepanal" UpdateMode="Conditional" runat="server" >
                    <ContentTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td valign="top"><table cellpadding="0" cellspacing="0" border="0" width="230"><tr><td align="right"><%--<uc5:feemanagement ID="feemanagement1" runat="server" />--%></td></tr><tr><td align="right" style="height:20px"></td></tr><tr><td align="right"></td></tr></table></td>
                            <td style="width: 1%" valign="top"></td>
                            <td style="width: 93%" valign="top" align="left">
                              <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr><td class="break"></td></tr>
                                    <tr>
                                        <td colspan="4" style="width: 100%; padding-left: 10px" valign="top" align="left">
                                            <table cellpadding="7" style="width:90%" cellspacing="0" border="0" class="app_container_auto">
                                                <tr class="view_detail_title_bg"><td colspan="5" style="width: 100%; height: 20px" align="left"><asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Student Fee Collection Details" ></asp:Label></td></tr>
                                                <tr id="trdate" runat="server"><td align="left" class="s_label">From Date</td><td align="left"><asp:TextBox ID="txtfromdate" runat="server" CssClass="s_textbox"  Width="150px"  ></asp:TextBox></td><td align="left" class="s_label">To Date</td><td align="left"><asp:TextBox ID="txttodate" runat="server" CssClass="s_textbox"  Width="150px"></asp:TextBox></td><td align="left"></td></tr>
                                                <tr><td align="left"></td><td align="right"><asp:Button ID="btnView" runat="server" CssClass="s_button" Text="View" onclick="btnView_Click" OnClientClick="return Validate();" /></td><td align="left"></td><td align="left"></td><td align="left"></td></tr>
                                                <tr>
                                                    <td colspan="5" style="width: 100%" valign="top" align="left">
                                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto" style="width:100%;">
                                                            <tr class="view_detail_title_bg"><td align="left"><asp:Label ID="lbltitle1" runat="server" Text="Reports" CssClass="title_label"></asp:Label></td></tr>
                                                            <tr><td style="width:100%" align="left"><table cellpadding="0" cellspacing="0" border="0" style="width:100%"><tr><td style="width:100%" valign="top" align="left"><CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" Width="350px" Height="50px" AutoDataBind="true" HasZoomFactorList="False" HasCrystalLogo="False" /></td></tr></table></td></tr>
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
