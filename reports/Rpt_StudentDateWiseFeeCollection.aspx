<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_StudentDateWiseFeeCollection.aspx.cs" EnableEventValidation="false" ValidateRequest="false" Inherits="reports_Rpt_StudentDateWiseFeeCollection" %>
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
                 $('#txtFrom').datepicker({ dateFormat: 'dd/mm/yy',
                     changeMonth: true,
                     constrainDates: true,
                     changeYear: true
                 });
             }
         });
         $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             function EndRequestHandler(sender, args) {
                 $('#txtTo').datepicker({ dateFormat: 'dd/mm/yy',
                     changeMonth: true,
                     constrainDates: true,
                     changeYear: true
                 });
             }
         });
         $(function() {
             var dates = $("#txtFrom,#txtTo").daterangepicker({
                 constrainDates: true,
                 dateFormat: 'dd/mm/yy',
                 datepickerOptions: {
                     changeMonth: true,
                     changeYear: true
                 }
             });
         });
        function checkDt(fld) {
             if (fld.value != "") {
                 var mo, day, yr;
                 var entry = fld.value;
                 var reLong = /\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/;
                 var reShort = /\b\d{1,2}[\/-]\d{1,2}[\/-]\d{2}\b/;
                 var valid = (reLong.test(entry)) || (reShort.test(entry));
                 if (valid) {
                     var delimChar = (entry.indexOf("/") != -1) ? "/" : "-";
                     var delim1 = entry.indexOf(delimChar);
                     var delim2 = entry.lastIndexOf(delimChar);
                     mo = parseInt(entry.substring(0, delim1), 10);
                     day = parseInt(entry.substring(delim1 + 1, delim2), 10);
                     yr = parseInt(entry.substring(delim2 + 1), 10);
                     // handle two-digit year
                     if (yr < 100) {
                         var today = new Date();
                         // get current century floor (e.g., 2000)
                         var currCent = parseInt(today.getFullYear() / 100) * 100;
                         // two digits up to this year + 15 expands to current century
                         var threshold = (today.getFullYear() + 15) - currCent;
                         if (yr > threshold) {
                             yr += currCent - 100;
                         } else {
                             yr += currCent;
                         }
                     }
                     var testDate = new Date(yr, mo - 1, day);
                     if (testDate.getDate() == day) {
                         if (testDate.getMonth() + 1 == mo) {
                             if (testDate.getFullYear() == yr) {
                                 // fill field with database-friendly format
                                 fld.value = mo + "/" + day + "/" + yr;
                                 return true;
                             } else {
                                 alert("Check the year entry.");
                             }
                         } else {
                             alert("Check the month entry.");
                         }
                     } else {
                         alert("Check the date entry.");
                     }
                 } else {
                     alert("Invalid date format. Enter as mm/dd/yyyy.");
                 }
                 fld.value = "";
                 return false;
             }
             else {
                 return false;
             }
         }
    </script>  
    <style type="text/css">        
        #bttnget
        {
        	display:none;
        }
        #txtFrom,#txtTo { float: left; margin-right: 10px; }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>
    <asp:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"><Services><asp:ServiceReference Path="~/feemanagement/FeeCascadingDropdown.asmx"/></Services></asp:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr><td style="width: 100%;" align="left"><uc3:topbanner ID="topbanner1" runat="server" /></td></tr>
        <tr><td style="width: 100%" valign="top"><uc2:topmenu ID="topmenu1" runat="server" /></td></tr>
        <tr>
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatepanal"  DisplayAfter="5">
                   <ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate>
                </asp:UpdateProgress>             
                <asp:UpdatePanel ID="updatepanal" UpdateMode="Conditional" runat="server" >
                    <ContentTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="width: 100%" valign="top" align="center">
                              <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr class="app_container_title"><td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" ><tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">Student Date Wise Fee details Report</td></tr></table></td></tr><tr><td></td></tr>
                                    <tr>
                                        <td colspan="4" style="width: 100%; padding-left: 10px" valign="top" align="center">
                                            <table cellpadding="7" style="width:80%" cellspacing="0" border="0" class="app_container_auto">
                                                <tr class="view_detail_title_bg"><td colspan="5" style="width: 100%; height: 20px" align="left"><asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Student Date Wise Fee details" ></asp:Label></td></tr>
                                                <tr><td align="left" style="width:20%" class="s_label">Year</td><td colspan="4" align="left" style="width:80%"><asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="true" CssClass="s_dropdown" onselectedindexchanged="ddlyear_SelectedIndexChanged" Width="150px"></asp:DropDownList></td></tr>
                                                <tr><td align="left" class="s_label" style="width:20%">From Date</td><td align="left" style="width:20%"><asp:TextBox ID="txtFrom" runat="server" CssClass="s_textbox" onblur="checkDt(this)" AutoPostBack="true" Width="150px" ontextchanged="txtFrom_TextChanged"></asp:TextBox></td><td align="left" class="s_label" style="width:20%">To Date</td><td colspan="2" align="left" style="width:40%"><asp:TextBox ID="txtTo" runat="server" CssClass="s_textbox" onblur="checkDt(this)" AutoPostBack="true" Width="150px" ontextchanged="txtTo_TextChanged"></asp:TextBox></td></tr>
                                                <tr><td align="left" class="s_label" style="width:20%">PayMode</td><td align="left" style="width:20%"><asp:DropDownList ID="ddlPayMode" runat="server" AutoPostBack="true" CssClass="s_dropdown"  Width="150px" onselectedindexchanged="ddlPayMode_SelectedIndexChanged"></asp:DropDownList><asp:CascadingDropDown ID="CascadingDropDown1" runat="server" Category="Mode" TargetControlID="ddlPayMode" LoadingText="Loading pay mode..." PromptText=" - Select Mode - " ServiceMethod="BindModedropdown" ServicePath="~/feemanagement/FeeCascadingDropdown.asmx"></asp:CascadingDropDown></td><td align="left" class="s_label" style="width:20%">Class</td><td colspan="2" align="left" style="width:40%"><asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True" onselectedindexchanged="ddlclass_SelectedIndexChanged" Width="150px"></asp:DropDownList></td></tr>
                                                <tr><td align="left" style="width: 20%" class="s_label">Admission No</td><td align="left" style="width: 20%"><asp:DropDownList ID="ddlAdmission" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlAdmission_SelectedIndexChanged"></asp:DropDownList></td><td align="left" style="width: 20%" class="s_label">Student Name</td><td colspan="2" align="left" style="width: 40%"><asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlName_SelectedIndexChanged"></asp:DropDownList></td></tr>
                                                <tr><td align="left" style="width:20%">&nbsp;</td><td align="right" style="width:20%"><asp:Button ID="btnclear" runat="server" CssClass="s_button" Text="Clear" onclick="btnclear_Click" /></td><td colspan="3" align="left" style="width:60%">&nbsp;</td></tr>
                                                <tr><td colspan="5" style="width: 100%" valign="top" align="left"><table cellpadding="0" cellspacing="0" border="0" class="app_container_auto" style="width:100%;"><tr class="view_detail_title_bg"><td align="left"><asp:Label ID="lbltitle1" runat="server" Text="Reports" CssClass="title_label"></asp:Label></td></tr>
                                                            <tr><td style="width:100%" align="left"><table cellpadding="0" cellspacing="0" border="0" style="width:100%"><tr><td style="width:100%" valign="top" align="left"><CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" Width="350px" Height="50px" AutoDataBind="true" HasZoomFactorList="False" HasCrystalLogo="False" /></td></tr></table></td></tr></table></td></tr>
                                                <tr><td align="center" colspan="5" style="width:98%" ><asp:HiddenField ID="HidCyear" runat="server" /></td></tr>
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
