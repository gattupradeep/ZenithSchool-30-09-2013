<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newstudentpopup.aspx.cs" EnableEventValidation="false" ValidateRequest="false" Inherits="feemanagement_newstudentpopup" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
     <script type="text/javascript" language="javascript">
         window.onload = function() {
             trDiscount.style.display = "none";
         };
         function Validation() {
             if (document.getElementById('txtFName').value == "") {
                 alert("Please enter the student name");
                 document.getElementById('txtFName').focus();
                 return false
             }
             if (document.getElementById('ddlyear').value == "") {
                 alert("Please select intake year");
                 document.getElementById('ddlyear').focus();
                 return false
             }
             if (document.getElementById('ddlMonth').value == "0") {
                 alert("Please select intake month");
                 document.getElementById('ddlMonth').focus();
                 return false
             }
             if (document.getElementById('ddlClass').value == "") {
                 document.getElementById('ddlClass').focus();
                 alert("Please select class");
                 return false
             }
             if (document.getElementById('txtICPASS').value == "") {
                 alert("IC/Passport number should not be blank");
                 document.getElementById('txtICPASS').focus();
                 return false
             }
             if (document.getElementById('txtadmno').value == "") {
                 alert("Admission number should not be blank");
                 document.getElementById('txtadmno').focus();
                 return false
             }
             DiscountDetails();
         }
         function ClearAdmdNo() {
             document.getElementById('ddlMonth').value = "0"
             document.getElementById('txtadmno').value = ""
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
         function AvoidTyping() {
             document.getElementById("<%= txtFeemode.ClientID %>").value = "";
             GetSelectedItem();
             return false
         }
         function CheckAll() {
             var chkall = document.getElementById("<%= chkall.ClientID %>");
             var TxtFeemode = document.getElementById("<%= txtFeemode.ClientID %>");
             var chkSingle = document.getElementById("<%= ddlSingle.ClientID %>");
             var chkBoxCount = chkSingle.getElementsByTagName("input");
             for (var i = 0; i < chkBoxCount.length; i++) {
                 if (chkall.checked == true) {
                     chkBoxCount[i].checked = true;
                     TxtFeemode.value = "Select All";
                 }
                 else {
                     chkBoxCount[i].checked = false;
                     TxtFeemode.value = "";
                 }
             }
             GetSelectedItem();
        }
        function GetSelectedItem() {
            var TxtFeemode = document.getElementById("<%= txtFeemode.ClientID %>");
            var chkSingle = document.getElementById("<%= ddlSingle.ClientID %>");
            var chkall = document.getElementById("<%= chkall.ClientID %>");
            var checkbox = chkSingle.getElementsByTagName("input");
            var label = chkSingle.getElementsByTagName("label");
            var inputs = document.getElementsByTagName('input');
            var SelectedClass = "";
            var SelectedValue = "";
            var SelectedAll = "";
            ClearTable();
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked) {
                    trDiscount.style.display = "";
                    SelectedClass += label[i].innerHTML + ",";
                    addRow(label[i].innerHTML);
                }
                SelectedValue += label[i].innerHTML + ",";
            }
            SelectedClass = removeLastComma(SelectedClass);
            SelectedValue = removeLastComma(SelectedValue);
            lblSelectAll.value = SelectedValue;
            var SplitCount = SelectedClass.split(",");
            var ClassCount = SplitCount.length;
            if (SelectedClass.length > 0 && ClassCount != checkbox.length) {
                TxtFeemode.value = SelectedClass;
                chkall.checked = false;
            }
            else if (ClassCount == checkbox.length) {
                TxtFeemode.value = "Select All";
                chkall.checked = true;
            }
            else
                TxtFeemode.value = "";
        }
         function removeLastComma(str) {
             return str.replace(/,$/, "");
         }
         function ClearTable() {
             var table = document.getElementById("dataTable");
             for (var i = table.rows.length - 1; i >= 0; i--) {
                 table.deleteRow(i);
             }
             trDiscount.style.display = "none";
         }
         function DiscountDetails() {
             if (trDiscount.style.display == "none") {
                 var TxtFeemode = document.getElementById("<%= txtFeemode.ClientID %>");
                 var chkSingle = document.getElementById("<%= ddlSingle.ClientID %>");
                 var checkbox = chkSingle.getElementsByTagName("input");
                 var label = chkSingle.getElementsByTagName("label");
                 ClearTable();
                    
                 for (var i = 0; i < checkbox.length; i++) {
                     trDiscount.style.display = "";
                     addRow(label[i].innerHTML);
                 }
             }
             var DisDetails = document.getElementById('HidDisDetails');
             var table = document.getElementById("dataTable");
             for (var i = 0; i < table.rows.length; i++) {
                 var row = table.rows[i];
                 var FeemodeName = row.cells[0].innerHTML;
                 
                 var Amount = row.cells[1].getElementsByTagName("input")[0].value;
                 if (Amount != "") {
                     var DisAmount = parseFloat(Amount);
                 }
                 else {
                     var DisAmount = 0;
                 }
                 if (DisAmount != 0) {
                     if (DisDetails.value == "")
                         DisDetails.value = FeemodeName + " - " + DisAmount;
                     else
                         DisDetails.value = DisDetails.value + "," + FeemodeName + " - " + DisAmount;
                 }
             }
         }
         function addRow(FeeMode) {

             var table = document.getElementById("dataTable");
             var rowCount = table.rows.length;
             var row = table.insertRow(rowCount);
             row.setAttribute("style", "height:30px");

             var cell1 = row.insertCell(0);
             cell1.setAttribute("style", "width:70%");
             cell1.setAttribute("style", "padding-left:20px");
             cell1.innerHTML = FeeMode;

             var cell2 = row.insertCell(1);
             var txtDis = document.createElement("input");
             cell2.setAttribute("style", "width:20%");
             txtDis.type = "text";
             txtDis.name = "txtbox[]";
             txtDis.setAttribute("style", "width:60px");
             txtDis.setAttribute("Maxlength", "5");
             txtDis.setAttribute('onkeypress', 'return validateFloatKeyPress(this, event);');
             txtDis.setAttribute('onblur', 'return ValidateNO(this);');
             cell2.appendChild(txtDis);

             var cell3 = row.insertCell(2);
             cell3.setAttribute("style", "width:10%");
             cell3.setAttribute("style", "align:left");
             cell3.innerHTML = "%";
         }
     </script>
     <script type="text/javascript">
         function DiscountDetails1() {
             var txtresult = document.getElementById('HidDFeeID');

             var DisDetails = document.getElementById('HidDisDetails');
             var table = document.getElementById("dataTable");
             for (var i = 0; i < table.rows.length; i++) {
                 var row = table.rows[i];
                 var FeemodeName = row.cells[0].innerHTML;
                 FeeDrpCascading.FeeModeID_for_FeeMode(FeemodeName, OnCallSumComplete, OnCallSumError, txtresult);
                 alert(document.getElementById('HidDFeeID').value);
                 var FeeId = document.getElementById('HidDFeeID').value;
                 var Amount = row.cells[1].getElementsByTagName("input")[0].value;
                 if (Amount != "") {
                     var DisAmount = parseFloat(Amount);
                 }
                 else {
                     var DisAmount = 0;
                 }
                 if (DisAmount != 0) {
                     if (DisDetails.value == "")
                         DisDetails.value = FeeId + " - " + DisAmount;
                     else
                         DisDetails.value = DisDetails.value + "," + FeeId + " - " + DisAmount;
                 }
                
             }
         }
        function OnCallSumComplete(result,txtresult,methodName)
        {
            txtresult.value = result;
        }
        function OnCallSumError(error,userContext,methodName)
        {
            if(error !== null) 
            {
                alert(error.get_message());
            }
        }
</script>
</head>
<body >
    <form id="form1" runat="server">
    <div align="center" style="margin-top:20px">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server" EnablePageMethods="true"><Services><asp:ServiceReference Path="~/feemanagement/FeeCascadingDropdown.asmx"/></Services></asp:ToolkitScriptManager>
        <asp:Panel ID="Panal" runat="server" style="width:500px; padding-left:7px; height:540px" ScrollBars="Vertical"> 
           <table cellpadding="0" cellspacing="0" style="border:black solid thin; width:100%">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" style="border:black solid thin; width:100%">
                            <tr><td align="left" style="height:40px; color:#F27609; padding-left:20px" class="s_label" >First Name</td><td style="height:40px"><asp:TextBox ID="txtFName" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox></td><td align="left" style="height:40px; width:50px"><asp:HiddenField ID="lblSelectAll" runat="server" /></td></tr>
                            <tr><td align="left" style="height:40px; color:#F27609; padding-left:20px" class="s_label">Middle Name</td><td style="height:40px"><asp:TextBox ID="txtMName" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox></td><td align="left" style="height:40px; width:50px"><asp:HiddenField ID="HidDisDetails" runat="server" /></td></tr>
                            <tr><td align="left" style="height:40px; color:#F27609; padding-left:20px" class="s_label">Last Name</td><td style="height:40px"><asp:TextBox ID="txtLName" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox></td><td align="left" style="height:40px; width:50px"><asp:HiddenField ID="HidDFeeID" runat="server" /></td></tr>                                                
                            <tr><td align="left" style="height:40px; color:#F27609; padding-left:20px" class="s_label">Intake Year</td><td style="height:40px"><asp:DropDownList ID="ddlyear" runat="server" Width="150px" CssClass="s_dropdown" onchange="ClearAdmdNo();"></asp:DropDownList><asp:CascadingDropDown ID="CascadingDropDown1" runat="server" Category="Year" TargetControlID="ddlyear" LoadingText="Loading year..." PromptText=" - Select intake year - " ServiceMethod="BindYeardropdown" ServicePath="~/feemanagement/FeeCascadingDropdown.asmx"></asp:CascadingDropDown></td><td align="left" style="height:40px; width:50px"></td></tr> 
                            <tr><td align="left" style="height:40px; color:#F27609; padding-left:20px" class="s_label">Intake Month</td><td style="height:40px"><asp:DropDownList ID="ddlMonth" runat="server" Width="150px" AutoPostBack="true" CssClass="s_dropdown" onselectedindexchanged="ddlMonth_SelectedIndexChanged"><asp:ListItem Value="0">Select</asp:ListItem><asp:ListItem Value="01">January</asp:ListItem><asp:ListItem Value="09">september</asp:ListItem></asp:DropDownList></td><td align="left" style="height:40px; width:50px">
                                &nbsp;</td></tr>                                                                       
                            <tr><td align="left" style="height:40px; color:#F27609; padding-left:20px" class="s_label">Class</td><td style="height:40px"><asp:DropDownList ID="ddlClass" runat="server" Width="150px" AutoPostBack="true" CssClass="s_dropdown" onselectedindexchanged="ddlClass_SelectedIndexChanged"></asp:DropDownList><asp:CascadingDropDown ID="ccLedger" ParentControlID="ddlyear" runat="server" Category="Class" TargetControlID="ddlClass" LoadingText="Loading Class..." PromptText=" - Select Class - " ServiceMethod="BindClassdropdown" ServicePath="~/feemanagement/FeeCascadingDropdown.asmx"></asp:CascadingDropDown></td><td align="left" style="height:40px; width:50px"></td></tr>
                            <tr><td align="left" style="height:40px; color:#F27609; padding-left:20px" class="s_label">IC/Passport No</td><td style="height:40px"><asp:TextBox ID="txtICPASS" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox></td><td align="left" style="height:40px; width:50px"></td></tr>                        
                            <tr><td align="left"  style="height:40px; color:#F27609; padding-left:20px" class="s_label">Admission No</td><td style="height:40px"><asp:TextBox ID="txtadmno" runat="server" CssClass="s_textbox" Width="150px" ReadOnly="True"></asp:TextBox></td><td align="left" style="height:40px; width:50px"></td></tr>
                            <tr><td align="left" valign="top"  style="height:40px; color:#F27609; padding-left:20px; padding-top:12px" class="s_label">Discount&nbsp; Fee Mode</td>
                                <td align="left" valign="top" style="padding-top:10px"><asp:TextBox ID="txtFeemode" runat="server" CssClass="s_textbox" AutoComplete="Off" Width="150px" onkeypress="return AvoidTyping();" onblur="return AvoidTyping();"></asp:TextBox><asp:PopupControlExtender ID="txtstd_PopupControlExtender" runat="server"  TargetControlID="txtFeemode" Enabled="true" PopupControlID="PanalFeemode" OffsetY="22"></asp:PopupControlExtender><asp:Panel ID="PanalFeemode" runat="server" ScrollBars="Vertical" BackColor="white" CssClass="app_container" BorderColor="#1874CD" BorderWidth="1px" Width="200px" Height="120px">
                                    <table border="0" cellpadding="0" cellspacing="0" ><tr><td style="width: 400px" align="left" valign="top"><table><tr><td style="width: 100%" align="left"><asp:CheckBox ID="chkall" runat="server" Text="Select All" CssClass="s_button" OnClick="CheckAll(); " style="float:left;margin-left:3px;"/></td></tr><tr><td style="width: 100%"  align="left"><asp:CheckBoxList ID="ddlSingle" runat="server" OnClick= "GetSelectedItem();"></asp:CheckBoxList></td></tr></table></td></tr></table></asp:Panel>
                                 </td>                                
                                <td align="left" style="height:40px; width:50px">&nbsp;</td>
                            </tr>
                            <tr id="trDiscount" runat="server"><td colspan="3" align="center" style="width:100%"><table id="dataTable" runat="server" class="app_container" border="0" cellpadding="0" cellspacing="0" style="width:75%"></table></td></tr>
                            <tr><td></td><td style="height:40px"><asp:Button ID="btnapply" runat="server" Font-Bold="True" OnClientClick="return Validation();" Font-Italic="False" ForeColor="White" Text="Apply" onclick="btnapply_Click" CssClass="s_button" Width="50px" />&nbsp;<asp:Button ID="Button1" runat="server" Font-Bold="True" ForeColor="White" Text="Cancel" onclick="Button1_Click" CssClass="s_button" Width="50px" /></td><td align="left"></td></tr>
                        </table>
                     </td>
                  </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
