<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeFile="searchstudentpopup.aspx.cs" Inherits="student_withdrawalpopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
         function Validation() {
             if (document.getElementById('ddlstandard').value == "") {
                 alert("Please select standard to proceed");
                 document.getElementById('ddlstandard').focus()
                 return false
             }
             if (document.getElementById('ddlsection').value == "") {
                 alert("Please select section to proceed");
                 document.getElementById('ddlsection').focus()
                 return false
             }
             if (document.getElementById('ddlname').value == "") {
                 alert("Please select student name to proceed");
                 document.getElementById('ddlname').focus()
                 return false
             }
         }
         function ShowTr() {
             trparent.style.display = "";
             tradmno.style.display = "";
             tdparent.innerHTML = "";
             tdadmitno.innerHTML = "";
         }
         function HideTr() {
             trparent.style.display = "none";
             tradmno.style.display = "none";
         }
         window.onload = function() {
             if (document.getElementById('ddlname').value == "") {
                 trparent.style.display = "none";
                 tradmno.style.display = "none";
             }
         };
     </script>
</head>
<body >
    <form id="form1" runat="server">
    <div align="center" style="margin-top:20px">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server"><Services><asp:ServiceReference Path="~/feemanagement/FeeCascadingDropdown.asmx"/></Services></asp:ToolkitScriptManager>
        <table cellpadding="0" cellspacing="0" style="border:black solid thin;" width="400px">
            <tr><td align="left" style="height:40px; color:#F27609; padding-left:20px" class="s_label">Standard</td><td style="height:40px"><asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" Width="150px" onchange="HideTr();"></asp:DropDownList><asp:CascadingDropDown ID="Cddlstandard" runat="server" Category="Standard" TargetControlID="ddlstandard" LoadingText="Loading Class..." PromptText=" - Select standard - " ServiceMethod="BindStandarddropdown" ServicePath="~/feemanagement/FeeCascadingDropdown.asmx"></asp:CascadingDropDown></td></tr>
            <tr><td align="left" style="height:40px; color:#F27609; padding-left:20px" class="s_label">Section</td><td style="height:40px"><asp:DropDownList ID="ddlsection" runat="server" CssClass="s_dropdown" Width="150px" onchange="HideTr();"></asp:DropDownList><asp:CascadingDropDown ID="Cddlsection" runat="server" Category="Section" ParentControlID="ddlstandard" TargetControlID="ddlsection" LoadingText="Loading section..." PromptText=" - Select section - " ServiceMethod="BindSectiondropdown" ServicePath="~/feemanagement/FeeCascadingDropdown.asmx"></asp:CascadingDropDown></td></tr>
            <tr><td align="left" style="height:40px; color:#F27609; padding-left:20px" class="s_label">Student Name</td><td style="height:40px"><asp:DropDownList ID="ddlname" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlname_SelectedIndexChanged" onchange="ShowTr();"></asp:DropDownList><asp:CascadingDropDown ID="Cddlname" runat="server" Category="StudentName" ParentControlID="ddlsection" TargetControlID="ddlname" LoadingText="Loading Student..." PromptText=" - Select Student - " ServiceMethod="BindStudentdropdown" ServicePath="~/feemanagement/FeeCascadingDropdown.asmx"></asp:CascadingDropDown></td></tr>
            <tr id="trparent" runat="server"><td align="left" style="height:40px; color:#F27609; padding-left:20px" class="s_label">Parent / Guardian Name</td><td ID="tdparent" runat="server" style="height:40px" class="s_label"></td></tr>
            <tr id="tradmno" runat="server"><td align="left"  style="height:40px; color:#F27609; padding-left:20px" class="s_label">Admission No</td><td ID="tdadmitno" runat="server" style="height:40px" class="s_label"></td></tr>
            <tr><td style="height:40px">&nbsp;</td><td style="height:40px"><asp:Button ID="btnapply" runat="server" Font-Bold="True" Font-Italic="False" ForeColor="White" Text="Apply" onclick="btnapply_Click" CssClass="s_button" Width="50px" OnClientClick="return Validation();" />&nbsp;<asp:Button ID="Button1" runat="server" Font-Bold="True" ForeColor="White" Text="Cancel" onclick="Button1_Click" CssClass="s_button" Width="50px" /></td></tr>
        </table>
     </div>
    </form>
</body>
</html>
