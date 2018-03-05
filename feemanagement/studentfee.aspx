<%@ Page Language="C#" AutoEventWireup="true"  EnableViewState="true" CodeFile="studentfee.aspx.cs" EnableEventValidation="false" ValidateRequest="false"  Inherits="Fee_studentfee" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/feemanagement.ascx" tagname="feemanagement" tagprefix="uc5" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Media_front/Css/abtModal.css" />
	<script type="text/javascript" src="../Media_front/Js/abtModal.js"></script> 
	<link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>
	<script type="text/javascript">
	    $(function() {
	        var dates = $("#txtreceiptdate").datepicker({
	            dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true
	        });
	    });
	    $(function() {
	        var dates = $("#txtchequedate").datepicker({
	            dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true
	        });
	    });
	</script>   
    <script type="text/javascript">
        function showModal(url, w, h) {
            showabtModal('mothersMedicals', w, h);
            document.getElementById('trendsFrame').style.height = h + 'px';
            document.getElementById('trendsFrame').style.width = w + 'px';
            document.getElementById('trendsFrame').src = url;
        }
        function closeModal() {
            document.getElementById('trendsFrame').src = "";
            hideabtModal('mothersMedicals')
            window.parent.location = "studentfee.aspx";
        }
        function CheckAll() {
            var chkall = document.getElementById("<%= chkall.ClientID %>");
            var TxtFeemode = document.getElementById("<%= txtFeemode.ClientID %>");
            var chkSingle = document.getElementById("<%= ddlSingle.ClientID %>");
            var chkBoxCount = chkSingle.getElementsByTagName("input");
            if (document.getElementById("<%= txtadmno.ClientID %>").value != "") {
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
            }
            else {
                alert("Please select Admission number to proceed");
                document.getElementById("<%= txtFeemode.ClientID %>").value = "";
                document.getElementById("<%= txtadmno.ClientID %>").focus();
                return false
            }
        }
        function GetSelectedItem() {
            var TxtFeemode = document.getElementById("<%= txtFeemode.ClientID %>");
            var chkSingle = document.getElementById("<%= ddlSingle.ClientID %>");
            var chkall = document.getElementById("<%= chkall.ClientID %>");
            var checkbox = chkSingle.getElementsByTagName("input");
            var label = chkSingle.getElementsByTagName("label");
            var SelectedClass = "";
            var SelectedValue = "";
            var SelectedAll = "";
            if (document.getElementById("<%= txtadmno.ClientID %>").value != "") {
                for (var i = 0; i < checkbox.length; i++) {
                    if (checkbox[i].checked)
                        SelectedClass += label[i].innerHTML + ",";
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
            else {
                alert("Please select Admission number to proceed");
                document.getElementById("<%= txtFeemode.ClientID %>").value = "";
                CheckBoxListSelect()
                document.getElementById("<%= txtadmno.ClientID %>").focus();
                return false
            }
        }
        function removeLastComma(str) {
            return str.replace(/,$/, "");
        }
        function ValidatetxtAdm() {
            if (document.getElementById("<%= txtadmno.ClientID %>").value == "") {
                tdnametxt.innerHTML = "";
                tdstandardtxt.innerHTML = "";
                trStudentName.style.display = "none";
                document.getElementById("<%= txtFeemode.ClientID %>").value = ""
                document.getElementById("<%= chkall.ClientID %>").checked = false;
                if (document.getElementById('HidFname').value != "") {
                    tdYeartxt.innerHTML = "";
                    tdMonthtxt.innerHTML = "";
                    trSIn.style.display = "none";
                    return false
                }
                return false
            }
        }
        function Validation() {
            if (document.getElementById("<%= txtreceiptdate.ClientID %>").value == "") {
                alert("Please select receipt date to Proceed");
                document.getElementById("<%= txtreceiptdate.ClientID %>").focus();
                return false
            }
            if (document.getElementById("<%= txtadmno.ClientID %>").value == "") {
                alert("Please select Admision number to Proceed");
                document.getElementById("<%= txtadmno.ClientID %>").focus();
                return false
            }
            if (document.getElementById("<%= txtFeemode.ClientID %>").value == "") {
                alert("Please select feemode to Proceed");
                document.getElementById("<%= txtFeemode.ClientID %>").focus();
                return false
            }
            if (document.getElementById("<%= ratiomanual.ClientID %>").checked == true) {
                if (document.getElementById("<%= txtReceiptNo.ClientID %>").value == "") {
                    alert("Please enter receipts number to Proceed");
                    document.getElementById("<%= txtReceiptNo.ClientID %>").focus();
                    return false
                }
            }
            if (trfeedetails.style.display == "none") {
                alert("Please Click Pay button for payment");
                document.getElementById("<%= btnOk.ClientID %>").focus();
                return false
            }
            else {
                var tableInputs = document.getElementById('dgStudentfee').getElementsByTagName("input");
                for (var i = 0; i < tableInputs.length; i++) {
                    if (tableInputs[i].id.indexOf("txtpayable") > 0) {
                        if (tableInputs[i].value == "") {
                            tableInputs[i].focus();
                            alert("Please enter amount");
                            return false
                        }
                    }
                }
            }  
            if (trDiscountReason.style.display != "none" && document.getElementById('txtDiscount').value > 0) {
                if (document.getElementById('txtDiscountReason').value == "") {
                    alert("Plaese enter the reason for discount");
                    document.getElementById('txtDiscountReason').focus();
                    return false;
                }
            }
            if (document.getElementById("<%= drp_mode.ClientID %>").value == "" ) {
                alert("Please select payment mode to Proceed");
                document.getElementById("<%= drp_mode.ClientID %>").focus();
                return false
            }
            else if (trbank.style.display != "none" &&  trchequedate.style.display != "none") {
                if (document.getElementById("<%= txtbankname.ClientID %>").value == "") {
                    alert("Please enter bank name to Proceed");
                    document.getElementById("<%= txtbankname.ClientID %>").focus();
                    return false
                }
                if (document.getElementById("<%= txtchequedate.ClientID %>").value == "") {
                    alert("Please enter cheque date to Proceed");
                    document.getElementById("<%= txtchequedate.ClientID %>").focus();
                    return false
                }
                if (document.getElementById("<%= txtchequeno.ClientID %>").value == "") {
                    alert("Please enter cheque number to Proceed");
                    document.getElementById("<%= txtchequeno.ClientID %>").focus();
                    return false
                } 
            }
            if (document.getElementById("<%= txtRemitter.ClientID %>").value == "") {
                alert("Please enter the remitter name");
                document.getElementById("<%= txtRemitter.ClientID %>").focus();
                return false
            }
        }
        function Validation1() {
            if (document.getElementById("<%= txtreceiptdate.ClientID %>").value == "") {
                alert("Please select receipt date to Proceed");
                document.getElementById("<%= txtreceiptdate.ClientID %>").focus();
                return false
            }
            if (document.getElementById("<%= txtadmno.ClientID %>").value == "") {
                alert("Please select Admision number to Proceed");
                document.getElementById("<%= txtadmno.ClientID %>").focus();
                return false
            }
            if (document.getElementById("<%= txtFeemode.ClientID %>").value == "") {
                alert("Please select feemode to Proceed");
                document.getElementById("<%= txtFeemode.ClientID %>").focus();
                return false
            }
            if (document.getElementById("<%= ratiomanual.ClientID %>").checked == true) {
                if (document.getElementById("<%= txtReceiptNo.ClientID %>").value == "") {
                    alert("Please enter receipts number to Proceed");
                    document.getElementById("<%= txtReceiptNo.ClientID %>").focus();
                    return false
                }
            }
            if (trfeedetails.style.display == "none") {
                alert("Please Click Pay button for payment");
                document.getElementById("<%= btnOk.ClientID %>").focus();
                return false
            }
        }
        function Validation2() {
            if (document.getElementById("<%= txtreceiptdate.ClientID %>").value == "") {
                alert("Please select receipt date to Proceed");
                document.getElementById("<%= txtreceiptdate.ClientID %>").focus();
                return false
            }
            if (document.getElementById("<%= txtadmno.ClientID %>").value == "") {
                alert("Please select Admision number to Proceed");
                document.getElementById("<%= txtadmno.ClientID %>").focus();
                return false
            }
        }
        function Validation3() {
            if (trfeedetails.style.display == "none") {
                document.getElementById("<%= ratiomanual.ClientID %>").checked = false;
                document.getElementById("<%= ratioauto.ClientID %>").checked = true;
                tdReclabel.style.display = "none";
                tdRectext.style.display = "none";
            }
            if (document.getElementById("<%= txtreceiptdate.ClientID %>").value == "") {
                alert("Please select receipt date to Proceed");
                document.getElementById("<%= txtreceiptdate.ClientID %>").focus();
                return false
            }
            if (document.getElementById("<%= txtadmno.ClientID %>").value == "") {
                alert("Please select Admision number to Proceed");
                document.getElementById("<%= txtadmno.ClientID %>").focus();
                return false
            }
            if (document.getElementById("<%= txtFeemode.ClientID %>").value == "") {
                alert("Please select feemode to Proceed");
                document.getElementById("<%= txtFeemode.ClientID %>").focus();
                return false
            }
            if (trfeedetails.style.display == "none") {
                alert("Please Click Pay button for payment");
                document.getElementById("<%= btnOk.ClientID %>").focus();
                return false
            }
        }
        function ValidateForFeeSelection() {
            if (document.getElementById("<%= txtreceiptdate.ClientID %>").value == "") {
                alert("Please select receipt date to Proceed");
                document.getElementById("<%= txtreceiptdate.ClientID %>").focus();
                return false
            }
            if (document.getElementById("<%= txtadmno.ClientID %>").value == "") {
                alert("Please select Admision number to Proceed");
                document.getElementById("<%= txtadmno.ClientID %>").focus();
                return false
            }
            if (document.getElementById("<%= txtFeemode.ClientID %>").value == "") {
                alert("Please select feemode to Proceed");
                document.getElementById("<%= txtFeemode.ClientID %>").focus();
                return false
            }
            document.getElementById('Hidden').value = "0.00";
            document.getElementById('txtDiscount').value = "";
        }
        function ShowDiscountReason() {
            trDiscount.style.display = "";
            trDiscountAmount.style.display = "";
            trDiscountReason.style.display = "none";
            return false
        }
        function hidegrd() {
            trfeedetails.style.display = "none";
            trfeesHeader.style.display = "none";
            trDiscount.style.display = "none";
            CheckBoxListSelect()
            document.getElementById('txtFeemode').value = "";
            alert("fee amount already paid for selected student");
            return false
        }
        function FeemodeSelection() {
            if (document.getElementById("<%= drp_mode.ClientID %>").value != "" && document.getElementById("<%= drp_mode.ClientID %>").value != "Cash") {
                if (document.getElementById("<%= drp_mode.ClientID %>").value != "Cheque") {
                    trbank.style.display = "";
                    trchequedate.style.display = "none";
                    return false
                }
                else {
                    trbank.style.display = "";
                    trchequedate.style.display = "";
                    return false
                }
            }
            else {
                trbank.style.display = "none";
                trchequedate.style.display = "none";
                return false
            }
        }
        function validate(key) {
            var keycode = (key.which) ? key.which : key.keyCode;
            var phn = document.getElementById('txtchequeno');
            if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57)) {
                return false;
            }
            else {
                if (phn.value.length < 10) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        function validateFloatKeyPress(el, evt) {
            var row = el.parentNode.parentNode;
            var rowIndex = row.rowIndex - 1;
            var Balance = row.cells[2].getElementsByTagName("input")[0].value;
            var Payable = row.cells[3].getElementsByTagName("input")[0].value;
            var Len = Balance.length
            row.cells[3].getElementsByTagName("input")[0].setAttribute('maxlength', Len);
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            if (charCode == 46 && el.value.indexOf(".") !== -1) {
                return false;
            }
            return true;
        }
        function validateFloatKeyPressDiscount(el, evt) {
            var Len = document.getElementById('Hidden').value;
            if(Len > 0 )
                document.getElementById('txtDiscount').setAttribute('maxlength', Len.length);
            else
                document.getElementById('txtDiscount').setAttribute('maxlength', "0"); 
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            if (charCode == 46 && el.value.indexOf(".") !== -1) {
                return false;
            }
            return true;
        }
        function Invalid() {
            alert("Invalid admission number");
            document.getElementById('txtadmno').value = "";
            document.getElementById('txtadmno').focus();
        }
        function ShowReceiptNo() {
            Validation3();
            if (document.getElementById("<%= ratiomanual.ClientID %>").checked) {
                document.getElementById("<%= ratioauto.ClientID %>").checked = false;
                tdReclabel.style.display = "";
                tdRectext.style.display = "";
                return false
            }
        }
        function HideReceiptNo() {
            Validation3();
            if (document.getElementById("<%= ratioauto.ClientID %>").checked) {
                document.getElementById("<%= ratiomanual.ClientID %>").checked = false;
                tdReclabel.style.display = "none";
                tdRectext.style.display = "none";
                return false
            }
        }
        function Clear() {
            document.getElementById('txtadmno').value = "";
            trStudentName.style.display = "none";
            if (document.getElementById('HidFname').value != "") {
                trSIn.style.display = "none";
            }
            CheckBoxListSelect()
            document.getElementById('txtFeemode').value = "";
            document.getElementById('drp_mode').value = "";
            document.getElementById('txtRemitter').value = "";
            document.getElementById('txtnarration').value = "";
            document.getElementById("<%= ratiomanual.ClientID %>").checked = false;
            document.getElementById("<%= ratioauto.ClientID %>").checked = true;
            trfeesHeader.style.display = "none";
            trfeedetails.style.display = "none";
            ClearGrd();
            trDiscount.style.display = "none";
            trDiscountReason.style.display = "none";
            document.getElementById('drp_mode').value = "";
            document.getElementById('txtbankname').value = "";
            document.getElementById('txtbranch').value = "";
            document.getElementById('txtchequedate').value = "";
            document.getElementById('txtchequeno').value = "";
            document.getElementById('txtDiscountReason').value = "";
            trbank.style.display = "none";
            trchequedate.style.display = "none";
            document.getElementById('txtReceiptNo').value = "";
            document.getElementById('txtDiscount').value = "";
            return false
        }
        function Clear1() {
            CheckBoxListSelect()
            document.getElementById('txtFeemode').value = "";
            document.getElementById('drp_mode').value = "";
            document.getElementById('txtRemitter').value = "";
            document.getElementById('txtnarration').value = "";
            document.getElementById("<%= ratiomanual.ClientID %>").checked = false;
            document.getElementById("<%= ratioauto.ClientID %>").checked = true;
            trfeesHeader.style.display = "none";
            trfeedetails.style.display = "none";
            ClearGrd();
            trDiscount.style.display = "none";
            trDiscountReason.style.display = "none";
            document.getElementById('drp_mode').value = "";
            document.getElementById('txtbankname').value = "";
            document.getElementById('txtbranch').value = "";
            document.getElementById('txtchequedate').value = "";
            document.getElementById('txtchequeno').value = "";
            document.getElementById('txtDiscountReason').value = "";
            trbank.style.display = "none";
            trchequedate.style.display = "none";
            document.getElementById('txtReceiptNo').value = "";
            document.getElementById('txtDiscount').value = "";
        }
        function ClearGrd() {
            var tableInputs = document.getElementById('dgStudentfee').getElementsByTagName("input");
            for (var i = 0; i < tableInputs.length; i++) {
                if (tableInputs[i].id.indexOf("txtpayable") > 0) {
                    tableInputs[i].value = "";
                }
            }
        }
        function CheckBoxListSelect() {
            var chkBoxList = document.getElementById('ddlSingle');
            var chkBoxCount = chkBoxList.getElementsByTagName("input");
            for (var i = 0; i < chkBoxCount.length; i++) {
                chkBoxCount[i].checked = false;
            }
            document.getElementById('chkall').checked = false;
            return false;
        }
        function ShowDiscount() {
            if (trfeedetails.style.display == "none") {
                alert("Please Click Pay button for payment");
                document.getElementById("<%= btnOk.ClientID %>").focus();
                return false
            }
            else {
                var tableInputs = document.getElementById('dgStudentfee').getElementsByTagName("input");
                for (var i = 0; i < tableInputs.length; i++) {
                    if (tableInputs[i].id.indexOf("txtpayable") > 0) {
                        if (tableInputs[i].value == "") {
                            alert("Please enter the amount");
                            document.getElementById('txtDiscount').value = "";
                            tableInputs[i].focus();
                            return false
                        }
                    }
                }
            }        
            if (document.getElementById('txtDiscount').value > 0) {
                if (parseFloat(document.getElementById('txtDiscount').value) > parseFloat(document.getElementById('Hidden').value)) {
                    alert("Discount amount should not exceed paid amout");
                    document.getElementById('txtDiscount').value = "";
                    rDiscountReason.style.display = "none";
                }
                else {
                    var Decimal = parseFloat(document.getElementById('txtDiscount').value).toFixed(2);
                    document.getElementById('txtDiscount').value = Decimal;
                    trDiscountReason.style.display = "";
                }
            }
            else {
                document.getElementById('txtDiscountReason').value = "";
                trDiscountReason.style.display = "none";
            }
        }
        function AvoidTyping() {
            document.getElementById("<%= txtFeemode.ClientID %>").value = "";
            GetSelectedItem();
            return false
        }
        function calculate(RowID) {
            var row = RowID.parentNode.parentNode;
            var rowIndex = row.rowIndex - 1;
            var FeeMode = row.cells[0].innerHTML;
            var FeeAmount = row.cells[1].innerHTML;
            var Balance = row.cells[2].getElementsByTagName("input")[0].value;
            var Payable = row.cells[3].getElementsByTagName("input")[0].value;
            if (parseFloat(Payable) > 0) {
                if (parseFloat(Payable) <= parseFloat(Balance)) {
                    var Decimal = parseFloat(Payable).toFixed(2);
                    row.cells[3].getElementsByTagName("input")[0].value = Decimal;
                    var tableInputs = document.getElementById('dgStudentfee').getElementsByTagName("input");
                    var total = 0;
                    var Prev = 0;
                    for (var i = 0; i < tableInputs.length; i++) {
                        if (tableInputs[i].id.indexOf("txtpayable") > 0) {
                            tempAmount = parseFloat(tableInputs[i].value);
                            if (isNaN(tempAmount)) tempAmount = 0;
                            Prev = total;
                            total = total + tempAmount;
                        }
                    }
                    document.getElementById("lblTotalPaidtxt").innerHTML = total.toFixed(2);
                    document.getElementById('Hidden').value = total.toFixed(2);
                    return false
                }
                else {
                    alert(FeeMode + " amount should not exceed balance amount "+Balance);
                    row.cells[3].getElementsByTagName("input")[0].value = '';
                    return false
                }
            }
        }
        function isNumberKey(key) {
            var keycode = (key.which) ? key.which : key.keyCode;
            if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57)) {
                return false;
            }
            else {
                return true;
            }
        }
     </script>
    <script type="text/javascript">
        window.onload = function() {
            HideRow();
        };
        function HideRow() {
            tdReclabel.style.display = "none";
            tdRectext.style.display = "none";
            if (document.getElementById("<%= txtFeemode.ClientID %>").value == "") {
                trfeesHeader.style.display = "none";
                trfeedetails.style.display = "none";
                trDiscount.style.display = "none";
                trDiscountReason.style.display = "none";
            }
            document.getElementById('drp_mode').value = "";
            trchequedate.style.display = "none";
            trbank.style.display = "none";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="mothersMedicals" class="dialog">
        <div style="text-align:center"><span onclick="closeModal();" style="float:right;clear:both;"  class="closeModal"></span></div>
        <iframe id="trendsFrame" src="" style="width:960px;height:300px;border:none;" scrolling='no' marginwidth='0' marginheight='0' frameborder='0'>some problem</iframe>
    </div>
        <div>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server"><Services><asp:ServiceReference Path="~/feemanagement/FeeCascadingDropdown.asmx"/></Services></asp:ToolkitScriptManager>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr><td style="width: 100%;" align="left"><uc3:topbanner ID="topbanner" runat="server" /></td></tr>
                    <tr><td style="width: 100%;" valign="top"><uc2:topmenu ID="topmenu" runat="server" /></td></tr>
                    <tr>
                        <td style="width: 100%" align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 5%" valign="top"><table cellpadding="0" cellspacing="0" border="0" width="230">
                                            <tr><td style="width: 230px" align="right"><uc5:feemanagement ID="feemanagement1" runat="server" /></td></tr>
                                            <tr><td style="width: 230px" align="right"></td></tr>
                                            <tr><td style="width: 230px" align="right"><uc4:school_info ID="school_info1" runat="server" /></td></tr></table>
                                    </td><td style="width: 1%" valign="top"></td>
                                    <td style="width: 98%" valign="top" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr class="app_container_title"><td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" >
                                                        <tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left"> Student&#39;s Fee Receipts</td></tr></table></td>
                                            </tr>
                                            <tr><td colspan="4" style="width: 100%; background-image: url(../media/images/bline.jpg)"></td></tr>
                                            <tr><td colspan="4" style="width: 100%"></td></tr>
                                            <tr>
                                                <td colspan="4" style="width: 100%" valign="top" align="left">
<%--                                                        <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                           <ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                        <asp:UpdatePanel ID="updatepanal" runat="server" UpdateMode="Always">
                                                           <ContentTemplate> --%>
                                                            <table cellpadding="7" cellspacing="0" border="0" style="width:90%" class="app_container_auto" >
                                                                <tr>
                                                                    <td style="width: 20%" align="left" class="s_label">Receipt Date</td><td style="width: 20%" align="left"><asp:TextBox ID="txtreceiptdate" runat="server" CssClass="s_textbox" MaxLength="10" Width="150px"></asp:TextBox></td>
                                                                    <td style="width: 20%" align="left" class="s_label">Admission No</td><td style="width: 30%" align="left"><asp:TextBox ID="txtadmno" runat="server" CssClass="s_textbox" MaxLength="10" AutoPostBack="true" Width="150px" ontextchanged="txtadmno_TextChanged" onblur="javascripts: return ValidatetxtAdm();" ></asp:TextBox>&nbsp;<a href="javascript: void(0)" onclick="showModal('searchstudentpopup.aspx?date=<% Response.Write(txtreceiptdate.Text); %>','420','280')"/><input type="button" id="Search" value="Find ?" class="s_button" onclick="return Search_onclick()" /><a href="javascript: void(0)" onclick="showModal('newstudentpopup.aspx?date=<% Response.Write(txtreceiptdate.Text); %>','510','570')"> <input type="button" id="new" value="New" class="s_button"/></a><a href="javascript: void(0)" onclick="showModal('searchstudentpopup.aspx?date=<% Response.Write(txtreceiptdate.Text); %>','420','280')" /></td><td style="width: 10%" align="left"></td>
                                                                </tr>
                                                                <tr id="trStudentName" runat="server" visible="false"><td style="width: 20%" align="left" class="s_label">Name</td><td id="tdnametxt" runat="server" style="width: 20%" align="left"></td><td style="width: 20%" align="left" class="s_label">Class</td><td ID="tdstandardtxt" runat="server" style="width: 30%" align="left"></td><td style="width: 10%" align="left" ></td></tr>
                                                                <tr id="trSIn" runat="server" visible="false"><td style="width: 20%" align="left" class="s_label">Intake Year</td><td ID="tdYeartxt" runat="server" style="width: 20%" align="left"></td><td style="width: 20%" align="left" class="s_label">Intake Month</td><td ID="tdMonthtxt" runat="server" style="width: 30%" align="left"></td><td style="width: 10%" align="left" ></td></tr>                                                                
                                                                <tr>
                                                                    <td style="width: 20%" align="left" class="s_label">Fee Mode</td>
                                                                    <td style="width: 20%" align="left">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td style="width: 80%" align="left">
                                                                                    <asp:TextBox ID="txtFeemode" runat="server" CssClass="s_textbox" AutoComplete="Off" Width="150px" onkeypress="return AvoidTyping();" onblur="return AvoidTyping();" onClick="javascripts: return Validation2();"></asp:TextBox>
                                                                                    <asp:PopupControlExtender ID="txtstd_PopupControlExtender" runat="server"  TargetControlID="txtFeemode" Enabled="true" PopupControlID="PanalFeemode" OffsetY="22"></asp:PopupControlExtender>
                                                                                    <asp:Panel ID="PanalFeemode" runat="server" ScrollBars="Vertical" BackColor="white" CssClass="app_container" BorderColor="#1874CD" BorderWidth="1px" Width="200px">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" >
                                                                                            <tr>
                                                                                                <td style="width: 400px" align="left" valign="top">
                                                                                                    <table>
                                                                                                        <tr><td style="width: 100%" align="left"><asp:CheckBox ID="chkall" runat="server" Text="Select All" CssClass="s_button" OnClick="CheckAll(); " style="float:left;margin-left:3px;"/></td></tr>
                                                                                                        <tr><td style="width: 100%"  align="left"><asp:CheckBoxList ID="ddlSingle" runat="server" OnClick= "GetSelectedItem();"></asp:CheckBoxList></td></tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                   </asp:Panel>
                                                                                </td>
                                                                                <td style="width: 20%" align="left" valign="top"><asp:Button ID="btnOk" CssClass="s_grdbutton" Text="Pay" runat="server" OnClientClick="javasripts: return ValidateForFeeSelection();" onclick="btnOk_Click"/></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td style="width: 20%" align="left"></td><td align="left" style="width:30%"><asp:HiddenField ID="lblSelectAll" runat="server" /></td><td style="width: 10%" align="left" ></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 20%" class="s_label">Receipt No</td>
                                                                    <td align="left" style="width: 20%" class="s_label"><asp:RadioButton ID="ratiomanual" runat="server" Text="Manual" onChange="javasripts: return ShowReceiptNo();"  /><asp:RadioButton ID="ratioauto" Checked="true" runat="server" Text="Auto" onChange="javasripts: return HideReceiptNo();"/></td>
                                                                    <td id="tdReclabel" runat="server" align="left" style="width: 20%" class="s_label">Enter Receipt No</td>                                                                    
                                                                    <td id="tdRectext" runat="server" align="left" style="width: 30%" class="s_label"><asp:TextBox ID="txtReceiptNo" runat="server" CssClass="s_textbox" onClick="javascripts: return Validation3();" Width="150px"></asp:TextBox></td><td align="left" style="width: 10%"></td>                                                                    
                                                                </tr>
                                                                <tr id="trfeesHeader" runat="server">
                                                                    <td style="width: 20%" align="left"></td>
                                                                    <td class="app_container_auto" colspan="3" style="width: 70%" align="left">
                                                                        <table class="app_container_auto" border="0" cellpadding="5" cellspacing="0" style="width:100%">
                                                                            <tr><td style="width: 25%" align="left" class="s_datagrid_header">Fee Mode</td><td style="width: 15%" align="left" class="s_datagrid_header">Actual Fee</td><td style="width: 15%" align="left" class="s_datagrid_header">Payable</td><td style="width: 45%" align="left" class="s_datagrid_header">Previous details</td></tr>
                                                                        </table>                                                                        
                                                                    </td>
                                                                    <td style="width: 10%" align="left"></td>
                                                                </tr>
                                                                <tr id="trfeedetails" runat="server">
                                                                    <td style="width: 20%" align="left"><asp:HiddenField ID="HidLname" runat="server" /></td>
                                                                    <td colspan="3" align="center" valign="top" style="width: 70%" class="app_container_auto">
                                                                        <div style="height:auto; width:100%"  class="app_container" >
                                                                            <asp:DataGrid ID="dgStudentfee" runat="server" Width="100%" AutoGenerateColumns="false" CellPadding="5" HeaderStyle-Font-Bold="true" GridLines="None" ShowHeader="false" onitemdatabound="dgStudentfee_ItemDataBound" ><AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" /><HeaderStyle CssClass="s_datagrid_header" />
                                                                             <Columns>
                                                                                    <asp:BoundColumn DataField="AcademicYear" Visible="false"></asp:BoundColumn>
                                                                                    <asp:BoundColumn DataField="Class" Visible="false"></asp:BoundColumn> 
                                                                                    <asp:TemplateColumn ItemStyle-VerticalAlign="Top" HeaderStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
                                                                                                <tr><td align="left" style="width:100%" class="s_label"><%#Eval("Class")%>  -  <%#Eval("AcademicYear")%></td></tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="width:100%">
                                                                                                        <asp:DataGrid ID="DgPayable" runat="server" Width="100%" AutoGenerateColumns="false" CellPadding="5" HeaderStyle-Font-Bold="true" GridLines="None" ShowHeader="false"><AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" /><HeaderStyle CssClass="s_datagrid_header" />
                                                                                                        <Columns>
                                                                                                                <asp:BoundColumn DataField="intAssignID" Visible="false"></asp:BoundColumn>
                                                                                                                <asp:BoundColumn DataField="FeemodeID" Visible="false"></asp:BoundColumn>
                                                                                                                <asp:BoundColumn DataField="FeemodeName" HeaderText="Fee Mode" ItemStyle-Wrap="true" ItemStyle-Width="25%" ></asp:BoundColumn>
                                                                                                                <asp:BoundColumn DataField="FeeAmount" HeaderText="Actual Fee" ItemStyle-Width="15%" ></asp:BoundColumn>
                                                                                                                <asp:BoundColumn DataField="AcademicYear" Visible="false"></asp:BoundColumn>
                                                                                                                <asp:TemplateColumn><ItemTemplate ><asp:HiddenField ID="HidBalance" runat="server" Value='<%#Eval("Balance") %>' /></ItemTemplate></asp:TemplateColumn>
                                                                                                                <asp:TemplateColumn HeaderText="Payable" ItemStyle-Width="15%"><ItemTemplate ><asp:TextBox ID="txtpayable" runat="server" Width="70px" onblur="return calculate(this)" onkeypress="return validateFloatKeyPress(this, event)"></asp:TextBox></ItemTemplate></asp:TemplateColumn>
                                                                                                                <asp:TemplateColumn ItemStyle-Width="45%">
                                                                                                                    <ItemTemplate>
                                                                                                                       <table border="0" cellpadding="5" cellspacing="0" style="width:100%" class="menu_container">
                                                                                                                            <tr id="trConcession" runat="server"><td style="width:70%" align="left">Discount</td><td ID="tdcontxt" runat="server" style="width:30%" align="left"></td></tr> 
                                                                                                                            <tr id="trConAmount" runat="server"><td style="width:70%" align="left">Discount Amount</td><td ID="tdConAmount" runat="server" style="width:30%" align="left"></td></tr>                                                                                                                                                                                                                       
                                                                                                                            <tr id="trPaidDate" runat="server"><td style="width:70%" align="left">Last paid Date</td><td style="width:30%" align="left"><%#Eval("LastPaidDate") %></td></tr>
                                                                                                                            <tr><td style="width:70%" align="left">Previous Payments</td><td style="width:30%" align="left"><%#Eval("PaidAmount") %></td></tr>
                                                                                                                            <tr><td style="width:70%" align="left">Balance</td><td style="width:30%" align="left"><%#Eval("Balance") %></td></tr>
                                                                                                                        </table> 
                                                                                                                    </ItemTemplate>
                                                                                                                    <ItemStyle VerticalAlign="Top"></ItemStyle>
                                                                                                                </asp:TemplateColumn> 
                                                                                                            </Columns>   
                                                                                                        </asp:DataGrid>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle VerticalAlign="Top" />
                                                                                        <ItemStyle VerticalAlign="Top" />
                                                                                    </asp:TemplateColumn> 
                                                                                </Columns>   
                                                                            </asp:DataGrid>
                                                                        </div>
                                                                    </td>
                                                                    <td style="width:10%" align="left"></td>
                                                                </tr>
                                                                <tr id="trDiscount" runat="server">
                                                                    <td style="width: 20%; padding-top:20px" align="left"><asp:HiddenField ID="HidPaidYear" runat="server" Value="0" /></td>
                                                                    <td colspan="3" align="center" valign="top" style="width: 70%" class="app_container_auto">
                                                                        <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                                            <tr id="trDiscountAmount" runat="server"><td style="width:25%" align="left">&nbsp;Additional Discount</td><td style="width:15%" align="left">&nbsp;<asp:TextBox ID="txtDiscount" runat="server" CssClass="s_textbox" Width="90%" onkeypress="return validateFloatKeyPressDiscount(this, event)" onblur="ShowDiscount();"></asp:TextBox></td><td style="width:15%" align="left"></td><td style="width:31%; padding-left:15px" align="left">Total amount :</td><td style="width:14%" align="left"><asp:Label ID="lblTotalPaidtxt" runat="server" Text="0.00"></asp:Label></td></tr>
                                                                            <tr id="trDiscountReason" runat="server"><td style="width:25%" align="left">&nbsp;Discount Reason</td><td colspan="3" style="width:75%" align="left">&nbsp;<asp:TextBox ID="txtDiscountReason" runat="server" CssClass="s_textbox" TextMode="MultiLine" Width="150px"></asp:TextBox></td><td><asp:HiddenField ID="Hidden" Value="0.00" runat="server" /></td></tr>
                                                                        </table>   
                                                                    </td>
                                                                    <td style="width:10%" align="left"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="5" style="width:100%" align="left">
                                                                       <table cellpadding="7" cellspacing="0" border="0px" width="100%">
                                                                            <tr>
                                                                                <td style="width: 20%" align="left" class="s_label">Mode of Payment</td>
                                                                                <td colspan="4" style="width: 80%" align="left">
                                                                                    <asp:DropDownList ID="drp_mode" runat="server" Width="150px" onClick="javascripts: return Validation1();" onchange="FeemodeSelection();"></asp:DropDownList>
                                                                                    <asp:CascadingDropDown ID="CascadingDropDown1" runat="server" Category="Mode" TargetControlID="drp_mode" LoadingText="Loading pay mode..." PromptText=" - Select Mode - " ServiceMethod="BindModedropdown" ServicePath="~/feemanagement/FeeCascadingDropdown.asmx"></asp:CascadingDropDown>                                                                                            
                                                                                 </td>
                                                                            </tr>
                                                                            <tr id="trbank" runat="server"><td align="left" style="width: 20%" class="s_label">Bank Name</td><td align="left" style="width: 20%"><asp:TextBox ID="txtbankname" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox></td><td align="left" style="width: 20%" class="s_label">Branch</td><td align="left" style="width: 30%"><asp:TextBox ID="txtbranch" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox></td><td style="width:10%"></td></tr>
                                                                            <tr id="trchequedate" runat="server"><td align="left" style="width: 20%" class="s_label">Cheque/DD Date</td><td align="left" style="width: 20%"><asp:TextBox ID="txtchequedate" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox></td><td align="left" style="width: 20%" class="s_label">Cheque/DD Number</td><td align="left" style="width: 30%"><asp:TextBox ID="txtchequeno" runat="server" CssClass="s_textbox" Width="150px" onkeypress="return isNumberKey(event);"></asp:TextBox></td><td style="width:10%"></tr>
                                                                            <tr><td align="left" style="width: 20%" class="s_label">Remitter</td><td align="left" style="width: 20%"><asp:TextBox ID="txtRemitter" runat="server" Width="150px" CssClass="s_textbox"></asp:TextBox></td><td align="left" style="width: 20%"><asp:HiddenField ID="HidPassport" runat="server" /></td><td align="left" style="width: 30%"><asp:HiddenField ID="HidDis" Value="0" runat="server" /></td><td style="width:10%"></tr>
                                                                            <tr><td align="left" style="width: 20%" class="s_label">Remarks</td><td align="left" style="width: 20%"><asp:TextBox ID="txtnarration" runat="server" CssClass="s_textbox" TextMode="MultiLine" Width="150px"></asp:TextBox></td><td align="left" style="width: 20%"><asp:HiddenField ID="HidFname" runat="server" /></td><td align="left" style="width: 30%"><asp:HiddenField ID="HidMname" runat="server" /></td><td style="width:10%"></tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trPrintreceipts" runat="server" visible="false">
                                                                    <td colspan="4" align="left" style="width: 90%">
                                                                        <div id="DivIdToPrint" runat="server">
                                                                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
                                                                                <tr><td align="left" style="width: 25%">Receipt No</td><td id="tdReceiptNo" runat="server" align="left" style="width: 25%" class="s_label"></td> <td align="left" style="width: 25%">Receipt Date</td><td id="tdReceiptDate" runat="server" align="left" style="width: 25%"><asp:HiddenField ID="HidNewOld" runat="server"/></td></tr>
                                                                                <tr><td align="left" style="width: 25%">Student No</td><td id="tdStudentNo" runat="server" align="left" style="width: 25%" class="s_label"></td> <td align="left" style="width: 25%">Name</td><td id="tdStudentName" runat="server" align="left" style="width: 25%" class="s_label"><asp:HiddenField ID="HidNewOld0" runat="server" /></td></tr>
                                                                                <tr><td align="left" style="width: 25%">Received From</td><td id="tdReceivedFrom" runat="server" colspan="3" align="left" style="width: 75%" class="s_label"></td></tr>
                                                                                <tr><td align="left" style="width: 25%">Description</td><td id="tdDiscription" runat="server" colspan="3" align="left" style="width: 70%" class="s_label"></td></tr>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                                                                                <tr><td align="left" style="width: 25%">Amount</td><td id="tdAmount" runat="server" colspan="3" align="left" style="width: 75%" class="s_label"></td></tr>
                                                                                <tr><td align="left" style="width: 25%">Paymode</td><td id="tdPaymode" runat="server" colspan="3" align="left" style="width: 75%" class="s_label"></td></tr>  
                                                                                <tr><td align="left" style="width: 25%">Reference No</td><td id="tdChequeNo" runat="server" colspan="3" align="left" style="width: 75%" class="s_label"></td></tr>
                                                                                <tr><td align="left" style="width: 25%">Cashier</td><td id="tdCashier" runat="server" colspan="3" align="left" style="width: 75%" class="s_label"></td></tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                    <td align="left" style="width: 10%"></td>
                                                                </tr>
                                                                <tr><td  colspan="4" style="width: 90%" align="center"><asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Print" Width="60px"  OnClientClick="javascripts:return Validation();" onclick="btnSave_Click"/><asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" Width="60px" OnClientClick="return Clear(); "/></td><td style="width: 10%" align="center"></td></tr>
                                                                 <tr>
                                                                    <td colspan="5" align="left" style="width: 100%">
                                                                        <asp:DataGrid ID="grd_trasaction" runat="server" AutoGenerateColumns="False" Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" AllowPaging="true" PageSize="15" onpageindexchanged="grd_trasaction_PageIndexChanged"><AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                                            <Columns>
                                                                                <asp:BoundColumn DataField="ID" HeaderText="intid" Visible="False"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="TransactionID" HeaderText="intid" Visible="False"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="PayMode" HeaderText="Mode"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="FromLedger" HeaderText="From Ledger"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="ToLedger" HeaderText="To Ledger"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="Paid" HeaderText="Amount"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="ChequeORddNo" HeaderText="Cheque/DD No"></asp:BoundColumn>
                                                                                <asp:BoundColumn DataField="PaidDate" HeaderText="Paid Date"></asp:BoundColumn>                                                                                
                                                                            </Columns>
                                                                            <PagerStyle Mode="NumericPages" Font-Bold="true"  Font-Underline="true" NextPageText="Next" PrevPageText="Prev" /><HeaderStyle CssClass="s_datagrid_header" />
                                                                        </asp:DataGrid>
                                                                    </td>
                                                                 </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
<%--                                            </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr><td style="width: 100%" valign="top" ><uc6:app_footer ID="footer" runat="server" /></td></tr>                                             
                    </table>
                </div>
        </form>
    </body>
</html>
