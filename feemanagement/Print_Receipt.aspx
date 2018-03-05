<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_Receipt.aspx.cs" Inherits="feemanagement_Print_Receipt" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fee Receipt</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <style id="Style1" type="text/css">
        @media print {
            .s_labelPrint1
            {
                font-family:Trebuchet MS, arial;
                font-size:small;
                font-weight:700;
                color:#000000;
	            height: 24px;
            }
            .s_labelPrint
            {
                font-family:Trebuchet MS, arial;
                font-size:small;
                font-weight:700;
                color:#282727;
	            height: 24px;
	        }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="DivIdToPrint" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
            <tr><td colspan="4" align="center" style="width: 100%; height: 40px"><img alt="Processing....." src="../images/ReceiptLogo.jpg" /></td></tr>
            <tr><td align="left" style="width: 25%; height: 40px">Receipt No</td><td id="tdReceiptNo" runat="server" align="left" style="width: 25%; height: 40px" class="s_labelPrint">&nbsp;</td><td align="left" style="width: 25%; height: 40px">Receipt Date</td><td id="tdReceiptDate" runat="server" align="left" style="width: 25%; height: 40px" class="s_labelPrint"></td></tr>
            <tr><td align="left" style="width: 25%; height: 40px">Student No</td><td id="tdStudentNo" runat="server" align="left" style="width: 25%; height: 40px" class="s_labelPrint">&nbsp;</td> <td align="left" style="width: 25%; height: 40px">Name</td><td id="tdStudentName" runat="server" align="left" style="width: 25%; height: 40px" class="s_labelPrint"></td></tr>
            <tr><td align="left" style="width: 25%; height: 40px">Received From</td><td id="tdReceivedFrom" runat="server" colspan="3" align="left" style="width: 75%; height: 40px" class="s_labelPrint"></td></tr>
            <tr><td align="left" style="width: 25%; height: 40px">Description</td><td id="tdDiscription" runat="server" colspan="3" align="left" style="width: 70%; height: 40px" class="s_labelPrint"></td></tr>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
            <tr><td align="left" style="width: 25%; height: 40px">Amount</td><td id="tdAmount" runat="server" colspan="3" align="left" style="width: 75%; height: 40px" class="s_labelPrint"></td></tr>
            <tr><td align="left" style="width: 25%; height: 40px">Paymode</td><td id="tdPaymode" runat="server" colspan="3" align="left" style="width: 75%; height: 40px" class="s_labelPrint"></td></tr>  
            <tr><td align="left" style="width: 25%; height: 40px">Reference No</td><td id="tdChequeNo" runat="server" colspan="3" align="left" style="width: 75%; height: 40px" class="s_labelPrint"></td></tr>
            <tr><td align="left" style="width: 25%; height: 40px">Cashier</td><td id="tdCashier" runat="server" colspan="3" align="left" style="width: 75%; height: 40px" class="s_labelPrint"></td></tr>
        </table>
    </div>
    </form>
</body>
</html>
