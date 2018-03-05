<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignfee.aspx.cs" Inherits="Fee_assignfee" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../usercontrol/feemanagement.ascx" tagname="feemanagement" tagprefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script> 
    <script type="text/javascript">
        function CheckAll() {
            var chkall = document.getElementById("chkall");
            var TxtClass = document.getElementById("<%= txtstd.ClientID %>");
            var chkBoxList = document.getElementById("ddlstandard");
            var chkBoxCount = chkBoxList.getElementsByTagName("input");
            for (var i = 0; i < chkBoxCount.length; i++) {
                if (chkall.checked == true) {
                    chkBoxCount[i].checked = true;
                    TxtClass.value = "Select All";
                }
                else {
                    chkBoxCount[i].checked = false;
                    TxtClass.value = "";
                }
            }
            return false;
       }
       function GetSelectedItem() {
           var TxtClass = document.getElementById("<%= txtstd.ClientID %>");
           var CHK = document.getElementById("<%= ddlstandard.ClientID %>");
           var chkall = document.getElementById("chkall");
           var checkbox = CHK.getElementsByTagName("input");
           var label = CHK.getElementsByTagName("label");
           var SelectedClass = "";
           var SelectedAll = "";
           var atLeast = 0;
           for (var i = 0; i < checkbox.length; i++) {
               if (checkbox[i].checked) 
                    SelectedClass += label[i].innerHTML + ",";
               }
            SelectedClass = removeLastComma(SelectedClass);
           var SplitCount = SelectedClass.split(",");
           var ClassCount = SplitCount.length;
           if (SelectedClass.length > 0 && ClassCount != checkbox.length) {
               TxtClass.value = "";
               TxtClass.value = SelectedClass;
               chkall.checked = false;
           }
           else if (ClassCount == checkbox.length) {
               TxtClass.value = "Select All";
               chkall.checked = true;
           }
           else
               TxtClass.value = "";
       }
       function removeLastComma(str) {
           return str.replace(/,$/, "");
       }
       function ValidateFeemode() {
           if (document.getElementById('<%= ddlfeemode.ClientID %>').value == 0) {
               alert(" Please select feemode to proceed");
               document.getElementById('<%= txtstd.ClientID %>').value = "";
               document.getElementById('<%= ddlfeemode.ClientID %>').focus();
               return false;
           }
       }
       function ValidateClass() {
           if (document.getElementById('<%= txtstd.ClientID %>').value == "") {
               alert("Please select class to proceed");
               document.getElementById('<%= txtAmount.ClientID %>').value="";
               document.getElementById('<%= ddlfeemode.ClientID %>').focus();
               return false;
           }
       }
       function Validation() {
            var Feemode =document.getElementById('<%= ddlfeemode.ClientID %>');
            var Class   =document.getElementById('<%= txtstd.ClientID %>');
            var Amount = document.getElementById('<%= txtAmount.ClientID %>');
            if (Feemode.value == 0) {
               alert(" Please select feemode to proceed");
               Feemode.focus();
               return false;
           }
           if (Class.value == "") {
               alert("Please select class to proceed");
               Class.focus();
               return false;
           }
           if (Amount.value == "") {
               alert("Please enter the Amount to proceed");
               Amount.focus();
               return false;
           }
           SelectAll();
       }
       function validate(key) {
           var keycode = (key.which) ? key.which : key.keyCode;
           var phn = document.getElementById('txtAmount');
           if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57)) {
               return false;
           }
           else {
               if (phn.value.length < 15) {
                   return true;
               }
               else {
                   return false;
               }
           }
       }
       function SelectAll() {
           var lblSelectAll = document.getElementById("<%= lblSelectAll.ClientID %>");
           var CHK = document.getElementById("<%= ddlstandard.ClientID %>");
           var chkall = document.getElementById("chkall");
           var checkbox = CHK.getElementsByTagName("input");
           var label = CHK.getElementsByTagName("label");
           var SelectedClass = "";
           for (var i = 0; i < checkbox.length; i++) {
               SelectedClass += label[i].innerHTML + ",";
            }
            SelectedClass = removeLastComma(SelectedClass);
            lblSelectAll.value = SelectedClass;
        }
        function AvoidTyping() {
            document.getElementById("<%= txtstd.ClientID %>").value = "";
            GetSelectedItem();
            return false
        }
        function uncheck() {
            var chkall = document.getElementById("chkall");
            chkall.checked = false;
            return false
        }
     </script>
</head>
<body>
    <form id="form1" runat="server">    
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr><td style="width: 100%;" align="left"><uc3:topbanner ID="topbanner1" runat="server" /></td></tr>
        <tr><td style="width: 100%;" valign="top"><uc2:topmenu ID="topmenu1" runat="server" /></td></tr>
        <tr>
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top"><table cellpadding="0" cellspacing="0" border="0" width="230"><tr><td style="width: 230px" align="right"><uc5:feemanagement ID="feemanagement1" runat="server" /></td></tr><tr><td style="width: 230px; height: 15px" align="right"></td></tr><tr><td style="width: 230px" align="right"><uc4:school_info ID="school_info1" runat="server" /></td></tr></table></td>
                        <td style="width: 1%" valign="top"></td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title"><td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" ><tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">Assign fee</td></tr></table></td></tr>
                                <tr><td class="break"></td></tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="UpdatePanel" DisplayAfter="1" >
                                         <ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate>
                                        </asp:UpdateProgress>                                          
                                        <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                            <ContentTemplate>                                        
                                               <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                                    <tr class="view_detail_title_bg"><td colspan="5" align="left" class="title_label">Assign fee </td></tr>
                                                    <tr><td style="width: 150px; padding-top:20px" align="left" class="s_label">AcademicYear</td>
                                                        <td colspan="4" align="left"><asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" onselectedindexchanged="ddlYear_SelectedIndexChanged"></asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px" align="left" class="s_label">Fee Mode</td>
                                                        <td style="width: 185px" align="left"><asp:DropDownList ID="ddlfeemode" runat="server" onchange="uncheck();" Width="170px" Height="19px" AutoPostBack="true" onselectedindexchanged="ddlfeemode_SelectedIndexChanged"></asp:DropDownList></td>
                                                        <td align="left" style="width:150px">&nbsp;</td><td align="left"></td><td align="left"></td></tr>
                                                     <tr>
                                                        <td style="width: 185px" align="left" class="s_label">Class</td>
                                                        <td style="width: 185px" align="left">
                                                        <asp:TextBox ID="txtstd" runat="server" CssClass="s_textbox" Width="170px" AutoComplete="off" onkeypress="return AvoidTyping();" onblur="return AvoidTyping();" OnClick="ValidateFeemode(); "></asp:TextBox>
                                                            <asp:PopupControlExtender ID="txtstd_PopupControlExtender" runat="server" TargetControlID="txtstd" Enabled="true" PopupControlID="panalstd" OffsetY="22"></asp:PopupControlExtender>
                                                            <asp:Panel ID="panalstd" runat="server" CssClass="app_container" ScrollBars="Vertical" Height="150px" BackColor="white" BorderWidth="1px" Width="340px">
                                                                <table border="0" cellpadding="0" cellspacing="0" >
                                                                    <tr>
                                                                        <td style="width: 400px" align="left" valign="top">
                                                                            <table>
                                                                                <tr><td style="width: 100%" align="left"><asp:CheckBox ID="chkall" runat="server" Text="Select All" CssClass="s_button" OnClick="CheckAll(); " style="float:left;margin-left:3px;"/></td>
                                                                                </tr><tr><td style="width: 100%"  align="left"><asp:CheckBoxList ID="ddlstandard" runat="server" RepeatColumns="3" OnClick= "GetSelectedItem();"></asp:CheckBoxList></td></tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                           </asp:Panel>
                                                            &nbsp;</td>
                                                        <td style="width: 185px" align="left"><asp:HiddenField ID="lblSelectAll" runat="server" /></td>
                                                        <td align="left"><br /><br /></td><td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px" align="left" class="s_label">Amount</td>
                                                        <td style="width: 185px" align="left"><asp:TextBox ID="txtAmount" runat="server" CssClass="s_textbox" Width="170px" onkeypress="return validate(event)" OnClick="ValidateClass();"></asp:TextBox></td>
                                                        <td align="left" style="width:150px"><asp:Label ID="lblEditID" runat="server" CssClass="s_label" Visible="false" Text="0"></asp:Label></td>
                                                        <td align="left"></td><td align="left"></td>
                                                    </tr>
                                                    <tr id="trbutton" runat="server"><td style="width: 150px" align="right">&nbsp;</td>
                                                        <td style="width: 185px" align="left"> <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" Width="60px" OnClientClick="javascripts: return Validation(); " onclick="btnSave_Click" />&nbsp;<asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" Width="60px" onclick="btnClear_Click"/></td>
                                                        <td align="left" style="width:150px">&nbsp;</td><td align="left">&nbsp;</td><td align="left"></td></tr>
                                                   <tr id="trgrdview" runat="server">
                                                        <td colspan="5" align="left">
                                                            <asp:DataGrid ID="dgsetfee" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="15"  Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="4" CellSpacing="1" onpageindexchanged="dgsetfee_PageIndexChanged" oneditcommand="dgsetfee_EditCommand" ><AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="AssignID" Visible="false" > </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="FeemodeID" Visible="false" ></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="FeemodeName" HeaderText="Fee Mode" ItemStyle-Wrap="true"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Class" HeaderText="Class" ItemStyle-Wrap="true"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="FeeAmount" HeaderText="Fee Amount" ></asp:BoundColumn>
                                                                    <asp:ButtonColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;"><HeaderStyle HorizontalAlign="Center"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle></asp:ButtonColumn>
                                                                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Delete"><ItemTemplate><asp:ImageButton ID="btnimagedelete" runat="server" ImageUrl="~/media/images/delete.gif" onclick="ImageButton1_Click" onclientclick="return confirm('Are you sure you want to delete?')" /></ItemTemplate><HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle><ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle></asp:TemplateColumn>
                                                                </Columns>
                                                                <PagerStyle Mode="NumericPages" Font-Bold="true"  Font-Underline="true" NextPageText="Next" PrevPageText="Prev" /><HeaderStyle CssClass="s_datagrid_header" />
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>                                                
                                     </td>
                                </tr>
                                <tr><td class="break"></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td> 
        </tr>           
        <tr><td style="width: 100%;" align="left" valign="top"><uc6:app_footer ID="footer" runat="server" /></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
