<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewfeedue.aspx.cs" EnableEventValidation="false" ValidateRequest="false" Inherits="feemanagement_viewfeedue" %>
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
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>    
     <script type="text/javascript">
         $(document).ready(function() {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             function EndRequestHandler(sender, args) {
                 $('#txtfromdate').datepicker({ dateFormat: 'yy/mm/dd',
                     changeMonth: true,
                     constrainDates: true,
                     changeYear: true
                 });
             }
         });
         $(document).ready(function() {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             function EndRequestHandler(sender, args) {
                 $('#txttodate').datepicker({ dateFormat: 'yy/mm/dd',
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
                 dateFormat: 'yy/mm/dd',
                 datepickerOptions: {
                     changeMonth: true,
                     changeYear: true
                 }
             });
         });
	</script>
    <script type="text/javascript">
        $(document).ready(function() {
        $('#chkall').click(
             function() {
        $("INPUT[type='checkbox']").attr('checked', $('#chkall').is(':checked'));
             });
         });
    </script>
    <script type="text/javascript">
        function CheckAll(oCheckbox) {
            var Grid = document.getElementById("<%=grdstudentfeedue.ClientID %>");
            for (i = 0; i < Grid.rows.length; i++) {
                Grid.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }
    </script>
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
                     <ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate>
                </asp:UpdateProgress>           
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server" >
                <ContentTemplate>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" style="width:230px">
                                <tr><td align="right"><uc5:feemanagement ID="feemanagement1" runat="server" /></td></tr>
                                <tr><td align="right" style="height:40px"></td></tr>
                                <tr>
                                    <td align="center" valign="middle">
                                        <table cellpadding="3" cellspacing="0" border="0" style="width:230px" class="app_container_auto">
                                            <tr><td align="left" style="width:115px" class="s_label">Admn No</td><td align="left" style="width:115px"><asp:TextBox ID="txtnameAdmno" runat="server" CssClass="s_textbox" Width="115px" AutoPostBack="true" MaxLength="10" ontextchanged="txtnameAdmno_TextChanged"></asp:TextBox></td></tr>
                                            <tr><td align="left" style="width:115px" class="s_label">Receipts Type</td><td align="left" style="width:115px"><asp:DropDownList ID="drpreceipt" runat="server" CssClass="s_dropdown" Width="115px" AutoPostBack="true" onselectedindexchanged="drpreceipt_SelectedIndexChanged" ><asp:ListItem Text="ALL" Value="0">ALL</asp:ListItem><asp:ListItem Text="Auto" Value="1">Auto</asp:ListItem><asp:ListItem Text="Manual" Value="2">Manual</asp:ListItem></asp:DropDownList></td></tr>
                                            <tr><td align="left" style="width:115px" class="s_label">Payment&#39;s Mode</td>
                                                <td align="left" style="width:115px"><asp:DropDownList ID="drpmode" runat="server" CssClass="s_dropdown" Width="115px" AutoPostBack="true" onselectedindexchanged="drpmode_SelectedIndexChanged" ><asp:ListItem Text="ALL" Value="0">ALL</asp:ListItem><asp:ListItem Text="Cash" Value="Cash">Cash</asp:ListItem><asp:ListItem Text="Cheque" Value="Cheque">Cheque</asp:ListItem><asp:ListItem Text="Visa" Value="Visa">Visa</asp:ListItem><asp:ListItem Text="Master" Value="Master">Master</asp:ListItem><asp:ListItem Text="TT" Value="TT">TT</asp:ListItem><asp:ListItem Text="Credit Card" Value="Credit Card">Credit Card</asp:ListItem></asp:DropDownList></td></tr>
                                            <tr><td align="left" style="width:115px" class="s_label">Ledger Type</td><td align="left" style="width:115px"><asp:DropDownList ID="drpledger" runat="server" CssClass="s_dropdown" Width="115px" AutoPostBack="true" onselectedindexchanged="drpledger_SelectedIndexChanged" ></asp:DropDownList></td></tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr><td align="right" style="height:40px"></td></tr>                                
                                <tr><td style="width: 230px" align="right"><uc4:school_info ID="school_info1" runat="server" /></td></tr>
                                <tr><td align="right"></td></tr>
                            </table>
                        </td>
                        <td style="width: 1%" valign="top"></td>
                        <td style="width: 93%" valign="top" align="left">
                          <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title"><td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" ><tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">View Fee Dues</td></tr></table></td></tr>
                                <tr><td class="break"></td></tr><tr>
                                    <td colspan="4" style="width: 100%; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto">
                                            <tr><td colspan="5" align="left"><table cellpadding="3" cellspacing="1" border="0" style="width:98%"><tr class="s_datagrid_header"><td id="tdChkall" runat="server" align="left" style="width:3%"><asp:CheckBox ID="chkall" runat="server" Text="ALL" onclick="CheckAll(this)" /></td>  <td align="left" style="width:7%">Year</td><td align="left" style="width:15%">Class</td>  <td align="left" style="width:23%">Student Name</td>  <td align="left" style="width:20%">FeeMode</td>  <td align="left" style="width:10%">Fee Amount</td>  <td align="left" style="width:10%">Paid</td>  <td align="left" style="width:11.8%">Balance</td></tr></table></td></tr>
                                            <tr>
                                                <td colspan="5" align="left" style="width:98%">
                                                    <table cellpadding="3" cellspacing="1" border="0" style="width:98%">
                                                        <tr class="s_datagrid_header">
                                                            <td id="tdChkall1" runat="server" align="left" style="width:3%"></td>
                                                            <td align="left" style="width:7%"><asp:DropDownList ID="drpyear" runat="server" CssClass="s_dropdown" AutoPostBack="true" Width="100%" onselectedindexchanged="drpyear_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td align="center" style="width:15%"><asp:DropDownList ID="drpclass" runat="server" AutoPostBack="True" Width="98%" onselectedindexchanged="drpclass_SelectedIndexChanged" ></asp:DropDownList></td>  
                                                            <td align="center" style="width:23%"><asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" onselectedindexchanged="ddlStudent_SelectedIndexChanged" Width="98%" ></asp:DropDownList></td>  
                                                            <td align="center" style="width:20%"><asp:DropDownList ID="drpfeemode" runat="server" AutoPostBack="True"  onselectedindexchanged="drpfeemode_SelectedIndexChanged" Width="98%" ></asp:DropDownList></td>  
                                                            <td align="left" style="width:10%"></td>  
                                                            <td align="center" style="width:10%"><asp:DropDownList ID="drpduetype" runat="server" AutoPostBack="True" Width="98%" onselectedindexchanged="drpduetype_SelectedIndexChanged" >
                                                                    <asp:ListItem Text="all" Value="0">ALL</asp:ListItem>
                                                                    <asp:ListItem Text="Paid" Value="Paid">Paid</asp:ListItem>
                                                                    <asp:ListItem Text="Unpaid" Value="Unpaid">Unpaid</asp:ListItem>
                                                                    <asp:ListItem Text="Canceled" Value="Cancelled">Cancelled</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>  
                                                            <td align="right" style="width:11.8%"><asp:Button ID="btnclear" runat="server" CssClass="s_grdbutton" onclick="btnclear_Click" Text="Clear" /></td>                                                                                                  
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr> 
                                            <tr id="trdate" runat="server">
                                                <td colspan="5" align="left" style="width:98%">
                                                    <table cellpadding="3" cellspacing="1" border="0" style="width:98%">
                                                        <tr class="s_datagrid_item">
                                                            <td id="tdChkall2" runat="server" align="left" style="width:3%">&nbsp;</td>
                                                            <td align="left" style="width:7%">&nbsp;</td>
                                                            <td align="left" style="width:15%">&nbsp;</td>  
                                                            <td align="left" style="width:23%">&nbsp;</td>  
                                                            <td align="left" style="width:20%" class="s_gridlabel">From Date</td>  
                                                            <td align="left" style="width:10%" class="s_datagrid_item"><asp:TextBox ID="txtfromdate" runat="server" AutoPostBack="true" CssClass="s_textbox" ontextchanged="txtfromdate_TextChanged" Width="100%"></asp:TextBox></td>  
                                                            <td align="left" style="width:10%" class="s_gridlabel">To Date</td>  
                                                            <td align="left" style="width:11.8%" class="s_datagrid_item"><asp:TextBox ID="txttodate" runat="server" AutoPostBack="true" CssClass="s_textbox" ontextchanged="txttodate_TextChanged" Width="85%"></asp:TextBox></td>                                                                                                  
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>                                                                                                                                   
                                            <tr>
                                                <td align="left" colspan="5" style="width: 98%"><asp:Panel ID="panalfeedue" runat="server" ScrollBars="Vertical" Height="412px" Width="98%" ><asp:DataGrid ID="grdstudentfeedue" runat="server" AutoGenerateColumns="False"  Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" ShowHeader="false" CellPadding="3" CellSpacing="1" onpageindexchanged="grdstudentfeedue_PageIndexChanged"><AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:TemplateColumn ItemStyle-Width="3%" ><ItemTemplate><asp:CheckBox ID="chkunpaid" runat="server" /></ItemTemplate></asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="StudentID" HeaderText="ID" Visible="False" ></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Year" HeaderText="Year" ItemStyle-Width="7%" ></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Class" HeaderText="Class" ItemStyle-Wrap="true" ItemStyle-Width="15%"> </asp:BoundColumn>                                                            
                                                            <asp:BoundColumn DataField="Student" HeaderText="Student Name" ItemStyle-Wrap="true" ItemStyle-Width="23%"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Feemode" HeaderText="Fee Mode" ItemStyle-Wrap="true" ItemStyle-Width="20%" ></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Amount" HeaderText="Fee Amount" ItemStyle-Width="10%"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Paid" HeaderText="Paid" ItemStyle-Width="10%"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Balance" HeaderText="Balance"  ItemStyle-Width="10%"></asp:BoundColumn>
                                                        </Columns>
                                                        <PagerStyle Mode="NumericPages" NextPageText="Next" PrevPageText="Previous" Position="Bottom" Font-Bold="true" Font-Underline="true" />
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                        </asp:DataGrid>
                                                     </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr><td align="center" colspan="5" style="width:98%" ></td></tr>
                                            <tr id="trcount" runat="server">
                                                <td align="left" colspan="5" >
                                                    <table cellpadding="0" cellspacing="0" border="0" width="98%" class="s_datagrid_header">
                                                        <tr><td style="width:20%"></td><td align="left" style="width:38%"><asp:Label ID="lblcount" runat="server" CssClass="title_label" ></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="lbcounttxt" runat="server" CssClass="title_label"></asp:Label></td><td align="left" style="width:40%">&nbsp;</td></tr>
                                                        <tr id="trsms" runat="server"><td colspan="3" align="left"><table cellpadding="0" cellspacing="0" border="0" width="98%" class="s_datagrid_header"><tr><td align="left" style="width:20%">&nbsp;</td><td align="left" style="width:38%"><asp:Label ID="lblsms" runat="server" CssClass="title_label" Text="Send Messsage for unpaid student ?"></asp:Label>&nbsp;&nbsp;<asp:Button ID="btnyes" runat="server" CssClass="s_button" onclick="btnyes_Click" Text="Yes" /></td><td align="left">&nbsp;</td></tr></table></td></tr>
                                                    </table>
                                                </td>
                                             </tr> 
                                            <tr id="trmessage" runat="server"><td colspan="5" align="left"><table cellpadding="0" cellspacing="0" border="0" width="98%" class="s_datagrid_header"><tr><td style="width:20%"></td><td align="left" valign="top" style=" height:auto; width:38%">&nbsp;</td><td align="left" style="height:auto; width:38%">&nbsp;<asp:Button ID="btnsms" runat="server" Text="Click to sms" CssClass="s_button" onclick="btnsms_Click" />&nbsp;<asp:Button ID="btnmail" runat="server" Text="Click to E-mail" CssClass="s_button" onclick="btnmail_Click" />&nbsp;</td><td style="width:2%"></td></tr></table></td></tr>
                                            <tr><td align="left"><asp:HiddenField ID="HidCyear" runat="server" /></td>  <td align="left"><asp:HiddenField ID="HiddenField2" runat="server" /></td><td align="left"><asp:HiddenField ID="HidAdm" runat="server" /></td><td align="left"><asp:Label ID="lblunpaid" runat="server" CssClass="s_label" Text="0" Visible="false"></asp:Label></td><td align="left"></td></tr>
                                    </table> 
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
   </div>
</form>
</body>
</html>
