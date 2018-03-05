<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentWiseFeeReceiptReport.aspx.cs" Inherits="reports_StudentWiseFeeReceiptReport" %>
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
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1"><ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate></asp:UpdateProgress><asp:UpdatePanel ID="updatepanal" UpdateMode="Conditional" runat="server" >
                    <ContentTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="width: 100%" valign="top" align="center">
                              <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr class="app_container_title"><td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" ><tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">
                                        Student Wise Fee details Report</td></tr></table></td></tr>
                                    <tr><td class="break"></td></tr>
                                    <tr>
                                        <td colspan="4" style="width: 100%; padding-left: 10px" valign="top" align="center">
                                            <table cellpadding="7" style="width:100%" cellspacing="0" border="0" class="app_container_auto">
                                                <tr class="view_detail_title_bg"><td colspan="5" style="width: 100%; height: 20px" align="left"><asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Student Wise Fee details" ></asp:Label></td></tr>
                                                <tr><td align="left" style="width:20%" class="s_label">Intake Year &amp; Month</td><td align="left" style="width:20%; height: 40px"><asp:DropDownList ID="ddlyear" runat="server" CssClass="s_dropdown" AutoPostBack="true" Width="150px" onselectedindexchanged="ddlyear_SelectedIndexChanged" ></asp:DropDownList></td><td align="left" style="width:20%" class="s_label">
                                                    Class</td><td align="left" style="width:20%"><asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlclass_SelectedIndexChanged"></asp:DropDownList></td><td align="left" style="width:20%; height: 40px"><asp:HiddenField ID="HidCyear" runat="server" /></td></tr>
                                                <tr><td align="left" style="width: 20%" class="s_label">Admission No</td><td align="left" style="width: 20%; height: 40px"><asp:DropDownList ID="ddlAdmission" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlAdmission_SelectedIndexChanged"></asp:DropDownList></td><td align="left" style="width: 20%" class="s_label">
                                                    Student Name</td><td align="left" style="width: 20%"><asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" Width="150px" onselectedindexchanged="ddlName_SelectedIndexChanged"></asp:DropDownList></td><td align="left" style="width: 20%; height: 40px">
                                                    &nbsp;</td></tr>
                                                <tr id="trMonthYeartxt" runat="server"><td align="left" class="s_label" style="width: 20%">
                                                    Intake Month &amp; Year</td><td colspan="4" id="tdMonthYeartxt" runat="server" class="s_label" align="left" style="width: 80%; height: 40px">
                                                        &nbsp;</td></tr>
                                                <tr><td align="left" style="width:20%; height: 40px">&nbsp;</td><td align="right" style="width:20%; height: 40px"><asp:Button ID="btnclear" runat="server" CssClass="s_button" Text="Clear" onclick="btnclear_Click" /></td><td colspan="3" align="left" style="width:60%; height: 40px">
                                                    &nbsp;</td></tr><tr>
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