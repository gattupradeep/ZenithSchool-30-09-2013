<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEditFeeDiscount.aspx.cs" Inherits="feemanagement_AddEditFeeDiscount" %>
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
    <script type="text/javascript" src="../media/js/jquery.min.js"></script> 
    <script type="text/javascript">
        function Validate() {
            if (document.getElementById('ddlStudent').value == "All") {
                alert("Please select Student to proceed");
                document.getElementById('drpfeemode').value = "0"
                document.getElementById('ddlStudent').focus();
                return false;
            }
        }
        function ValidateNO(txtDis) {
            if (txtDis.value != "" && txtDis.value > 0) {
                if (parseFloat(txtDis.value) > 100) {
                    alert("Discount should be less than or equal to 100%");
                    txtDis.value = "";
                    txtDis.focus();
                    return false
                }
                else {
                    var Decimal = parseFloat(txtDis.value).toFixed(2);
                    txtDis.value = Decimal;
                    return false
                }
            }
        }
        function validateFloatKeyPress(el, evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            if (charCode == 46 && el.value.indexOf(".") !== -1) {
                return false;
            }
            return true;
        }
        function ValidateText() {
            var tableInputs = document.getElementById("<%= dgFeeDiscount.ClientID %>").getElementsByTagName("input");
            var Bool = "N";
            for (var i = 0; i < tableInputs.length; i++) {
                if (tableInputs[i].id.indexOf("txtDiscount") > 0) {
                    if (tableInputs[i].value != "" && parseFloat(tableInputs[i].value) > 0) 
                        Bool = "Y";
               }
           }
           if (Bool == "N") {
               if (parseFloat(tableInputs.length) > 1 ) 
                   alert("Please enter discount for at least one fee mode");
               else 
                   alert("Please enter discount for fee mode");
               return false;
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
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1"><ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate></asp:UpdateProgress><asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server" >
                <ContentTemplate>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td valign="top"><table cellpadding="0" cellspacing="0" border="0" style="width:230px"><tr><td align="right"><uc5:feemanagement ID="feemanagement1" runat="server" /></td></tr><tr><td style="width: 230px" align="right"><uc4:school_info ID="school_info1" runat="server" /></td></tr><tr><td align="right"></td></tr></table></td>
                        <td style="width: 1%" valign="top"></td>
                        <td style="width: 93%" valign="top" align="left">
                          <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title"><td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" ><tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">Add/Edit Student's Fee Discount</td></tr></table></td></tr>
                                <tr><td class="break"></td></tr><tr>
                                    <td colspan="4" style="width: 100%" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" style="width:90%" class="app_container_auto">
                                            <tr><td colspan="5" align="left"><table cellpadding="3" cellspacing="1" border="0" style="width:100%"><tr class="s_datagrid_header"><td align="left" style="width:7%">Year</td><td align="left" style="width:15%">Class</td><td align="left" style="width:25%">Student Name</td><td align="left" style="width:13%">Admission No</td><td align="left" style="width:25%">Fee Mode</td><td align="left" style="width:15%">Discount</td></tr></table></td></tr>
                                            <tr><td colspan="5" align="left" style="width:98%"><table cellpadding="3" cellspacing="1" border="0" style="width:100%"><tr class="s_datagrid_header"><td align="left" style="width:7%"><asp:DropDownList ID="drpyear" runat="server" CssClass="s_dropdown" Width="100%" AutoPostBack="true" onselectedindexchanged="drpyear_SelectedIndexChanged"></asp:DropDownList></td><td align="center" style="width:15%"><asp:DropDownList ID="drpclass" runat="server" AutoPostBack="True" Width="98%" onselectedindexchanged="drpclass_SelectedIndexChanged" ></asp:DropDownList></td><td align="center" style="width:25%"><asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" onselectedindexchanged="ddlStudent_SelectedIndexChanged" Width="98%" ></asp:DropDownList></td><td align="center" style="width:13%"><asp:DropDownList ID="ddlAdmission" runat="server" AutoPostBack="True" Width="98%" onselectedindexchanged="ddlAdmission_SelectedIndexChanged"></asp:DropDownList></td><td align="left" style="width:25%"><asp:DropDownList ID="drpfeemode" runat="server" AutoPostBack="True" onselectedindexchanged="drpfeemode_SelectedIndexChanged" Width="98%" onchange="Validate(); "></asp:DropDownList></td><td align="right" style="width:15%"><asp:Button ID="btnclear" runat="server" CssClass="s_grdbutton" onclick="btnclear_Click" Text="Clear" /></td></tr></table></td></tr> 
                                            <tr>
                                                <td align="left" colspan="5" style="width: 100%">
                                                    <asp:DataGrid ID="dgFeeDiscount" runat="server" AutoGenerateColumns="False"  Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" ShowHeader="false" CellPadding="3" CellSpacing="1" ><AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="FeemodeID" Visible="false"></asp:BoundColumn><asp:BoundColumn DataField="Year" HeaderText="Year" ItemStyle-Width="7%" ></asp:BoundColumn><asp:BoundColumn DataField="Class" HeaderText="Class" ItemStyle-Wrap="true" ItemStyle-Width="15%"> </asp:BoundColumn><asp:BoundColumn DataField="Name" HeaderText="Student Name" ItemStyle-Wrap="true" ItemStyle-Width="25%"></asp:BoundColumn><asp:BoundColumn DataField="AdmissionNO" HeaderText="Admission NO" ItemStyle-Wrap="true" ItemStyle-Width="13%" ></asp:BoundColumn><asp:BoundColumn DataField="Feemode" HeaderText="Fee Mode" ItemStyle-Width="25%"></asp:BoundColumn><asp:TemplateColumn ItemStyle-Width="15%"><ItemTemplate><asp:TextBox ID="txtDiscount" runat="server" Width="80px" Text='<%#Eval("Discount") %>' CssClass="s_gridtext" MaxLength="6" onkeypress="return validateFloatKeyPress(this, event); " onblur="return ValidateNO(this); "></asp:TextBox></ItemTemplate></asp:TemplateColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr id="trSave" runat="server" visible="false"><td align="center" colspan="5" style="width: 100%">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="s_button" OnClientClick="return ValidateText();" onclick="btnSave_Click" /></td></tr>
                                            <tr><td align="left" colspan="5" style="width: 100%"><asp:HiddenField ID="Cyear" runat="server" /></td></tr>
                                        </table> 
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate></asp:UpdatePanel>
        </td>
     </tr>
    </table>
   </div>
</form>
</body>
</html>

