<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addeditstaff.aspx.cs" Inherits="detailsrecord_addeditstaff"  %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/detailsrecord_staff.ascx" tagname="detailsrecord_staff" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" /> 
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>
	<link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />    
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>
    <script type="text/javascript">
      
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtdob').datepicker({ dateFormat: 'yy/mm/dd', changeMonth: true, constrainDates: true, yearRange: '1930:2030', changeYear: true });
            }
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtjoiningdate').datepicker({ dateFormat: 'yy/mm/dd', changeMonth: true, constrainDates: true, changeYear: true });
            }
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtprohibitto').datepicker({ dateFormat: 'yy/mm/dd', changeMonth: true, constrainDates: true, changeYear: true });
            }
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtperiodfrom').datepicker({ dateFormat: 'yy/mm/dd', changeMonth: true, constrainDates: true, changeYear: true });
            }
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtperiodto').datepicker({ dateFormat: 'yy/mm/dd', changeMonth: true, constrainDates: true, changeYear: true });
            }
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtworkftime').timepicker();
            }
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtworktotime').timepicker();
            }
        });
       
        $(document).ready(function() {
        $('#txtworkftime').timepicker();
        });
        $(document).ready(function() {
        $('#txtworktotime').timepicker();
        });        
        $(function() {
            var dates = $("#txtdob").datepicker({
                dateFormat: 'yy/mm/dd',
                constrainDates: true,
                changeMonth: true,
                yearRange: '1930:2030',
                changeYear: true
            });
        });
        $(function() {
            var dates = $("#txtjoiningdate").datepicker({
                 dateFormat: 'yy/mm/dd',
                constrainDates: true,
                changeMonth: true,
                changeYear: true
            });
        });
        $(function() {
            var dates = $("#txtprohibitto").datepicker({
                dateFormat: 'yy/mm/dd',
                constrainDates: true,
                changeMonth: true,
                changeYear: true
            });
        });
        $(function() {
        var dates = $("#txtperiodfrom").datepicker({
                dateFormat: 'yy/mm/dd',
                constrainDates: true,
                changeMonth: true,
                changeYear: true
            });
        });
        $(function() {
        var dates = $("#txtperiodto").datepicker({
                dateFormat: 'yy/mm/dd',
                constrainDates: true,
                changeMonth: true,
                changeYear: true
            });
        });             
	</script>
   
       
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></ajaxtoolkit:toolkitscriptmanager>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td style="width: 100%;" align="left">
                    <uc3:topbanner ID="topbanner1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%;" valign="top">
                    <uc2:topmenu ID="topmenu1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 400px" align="left" valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td style="width: 5%" valign="top">
                                <table cellpadding="0" cellspacing="0" border="0" width="230">
                                    <tr>
                                        <td style="width: 230px" align="right">
                                            <uc1:detailsrecord_staff ID="detailsrecord_staff1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 230px; height: 15px" align="right">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 230px" align="right">
                                            <uc4:school_info ID="school_info1" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width:1%" valign="top">
                            </td>
                            <td style="width: 94%" valign="top" align="left">
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr class="app_container_title">
                                        <td style="width: 100%; " align="left">
                                            <table cellpadding="0" cellspacing="0" border="0" width="750">
                                                <tr>
                                                    <td class="app_cont_title_img_td"><img src="../images/icons/50X50/18.png" class="app_cont_title_img" alt="icon" /></td>
                                                    <td align="left" >Add Staff Details </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="break"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
                                        <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                    <ProgressTemplate>
                                                        <div id="progressBackgroundFilter"></div>
                                                            <div id="processMessage">
                                                                <img alt="Loading" src="../media/images/Processing.gif" />
                                                            </div>
                                                    </ProgressTemplate>
                                            </asp:UpdateProgress>--%>
                                            <asp:UpdatePanel ID="updatepanal" runat="server" UpdateMode="Conditional" >
                                                 <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnSave" />
                                                 </Triggers>
                                                 <ContentTemplate>
                                                      <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td  align="left">
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Add Staff Details " ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr><td class="break">    
                                            </td></tr> 
                                            <tr><td>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                                        ValidationGroup="employee" DisplayMode="BulletList" 
                                                        HeaderText="Please fill the following errors" EnableClientScript="true" 
                                                        ShowMessageBox="true" CssClass="s_label" Height="100%" /> </td></tr>       
                                            <tr class="view_detail_subtitle_bg">
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr >
                                                            <td style="width:200px"><asp:Label ID="Label25" runat="server" Text="Personal Details" CssClass="subtitle_label"></asp:Label></td>
                                                            <td>                                                      
                                                            </td>                                                               
                                                        </tr>                                                    
                                                    </table>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label84" runat="server" CssClass="s_label" Text="Staff Type"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddltype" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" 
                                                                    onselectedindexchanged="ddltype_SelectedIndexChanged" AutoPostBack="True" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label26" runat="server" CssClass="s_label" Text="Title"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddltittle" runat="server" CssClass="s_dropdown" 
                                                                 Width="150px">
                                                                    <asp:ListItem>Mr</asp:ListItem>
                                                                    <asp:ListItem>Mrs</asp:ListItem>
                                                                    <asp:ListItem>Ms</asp:ListItem>
                                                                </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="tittleValidator6" runat="server" ControlToValidate="ddltittle" ValidationGroup="employee"  ErrorMessage="You should select atleast one" Width="16px">*</asp:RequiredFieldValidator>--%></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="First Name:  "></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                               <asp:TextBox ID="txtfirst" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>    
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                            <%--<asp:RequiredFieldValidator ID="firstnameValidator6" runat="server" ControlToValidate="txtfirst" ValidationGroup="employee" 
                                                                    Enabled="False" ErrorMessage="First name is required" Width="16px">*</asp:RequiredFieldValidator>--%></td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Middle Name :  "></asp:Label>
                                                                    </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                    <asp:TextBox ID="txtmiddle" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                    &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Lastname:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtlast" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox> 
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px"> 
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtlast" ValidationGroup="employee"  ErrorMessage="last name is required" Width="21px" Height="16px">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Gender:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:DropDownList ID="ddlgen" runat="server" CssClass="s_dropdown" Width="140px" >
                                                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlgen" ValidationGroup="employee"   ErrorMessage="Please select one gender" Width="16px" >*</asp:RequiredFieldValidator>--%></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label31" runat="server" CssClass="s_label" Text="Guardian"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:RadioButton ID="rbtfather" runat="server" Checked="True" 
                                                                    CssClass="s_label" GroupName="guardian" Text="Father" />
                                                                <asp:RadioButton ID="rbthusband" runat="server" CssClass="s_label" 
                                                                    GroupName="guardian" Text="Husband" />
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label32" runat="server" CssClass="s_label" Text="Guardian Name"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtguardianname" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                            <%--<asp:RequiredFieldValidator ID="guardiannameValidator6" runat="server" ControlToValidate="txtguardianname" ValidationGroup="employee"  
                                                                    Enabled="False" ErrorMessage="guardian name is required" Width="16px">*</asp:RequiredFieldValidator>--%></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Date of Birth"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                              <asp:TextBox ID="txtdob" runat="server" CssClass="s_textbox" Width="180px" ></asp:TextBox>
                                                              <%--<ajaxtoolkit:CalendarExtender ID="Calendarextender2" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtdob" TargetControlID="txtdob"></ajaxtoolkit:CalendarExtender >--%>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <%--<asp:RequiredFieldValidator ID="dobValidator6" runat="server" ControlToValidate="txtdob" ErrorMessage="Date of birth cannot be blank" ValidationGroup="employee"  Width="16px">*</asp:RequiredFieldValidator>--%></td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                               <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Nationality:  "></asp:Label>
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                               <asp:TextBox ID="txtnation" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="Religion:  "></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:DropDownList ID="ddlreli" runat="server" AutoPostBack="True" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlreli_SelectedIndexChanged" 
                                                                    Width="100px">
                                                                    <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                                    <asp:ListItem>Hindu</asp:ListItem>
                                                                    <asp:ListItem>Islam</asp:ListItem>
                                                                    <asp:ListItem>Christian</asp:ListItem>
                                                                    <asp:ListItem>Others</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="txtreligion" runat="server" CssClass="s_textbox" Width="80px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                             <%--<asp:RequiredFieldValidator ID="Requiredfieldvalidator101" runat="server" ControlToValidate="ddlreli" ErrorMessage="Please select Religion" InitialValue="--Select--" ValidationGroup="employee" >*</asp:RequiredFieldValidator>--%>
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="Address:"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtaddr" runat="server" CssClass="s_textbox" 
                                                                    TextMode="MultiLine" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                               <%--<asp:RequiredFieldValidator ID="Requiredfieldvalidator15" runat="server" ControlToValidate="txtaddr" ErrorMessage="Address cannot be blank" ValidationGroup="employee"  Width="16px" >*</asp:RequiredFieldValidator>--%>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <%--<tr id="trcommunity" runat="server">
                                                            <td align="left" style="width: 125px; height: 40px">
                                                           <asp:Label ID="Label85" runat="server" CssClass="s_label" Text="Community"></asp:Label>
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                            <asp:DropDownList ID="ddlcommunity" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px">
                                                                    <asp:ListItem Value="FC">FC</asp:ListItem>
                                                                    <asp:ListItem Value="BC">BC</asp:ListItem>                                                        
                                                                    <asp:ListItem Value="OBC">OBC</asp:ListItem>
                                                                    <asp:ListItem Value="OC">OC</asp:ListItem>
                                                                    <asp:ListItem Value="SC/ST">SC/ST</asp:ListItem>
                                                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                                               </asp:DropDownList>
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                              
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                          
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                           
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label82" runat="server" CssClass="s_label" Text="Country:"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:DropDownList ID="ddlcountry" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True"  onselectedindexchanged="ddlcountry_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="countryValidator6" runat="server" ControlToValidate="ddlcountry" ErrorMessage="Please select the country" InitialValue="0" ValidationGroup="employee"  Width="16px" >*</asp:RequiredFieldValidator></td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="State:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:DropDownList ID="ddlstate" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True"  onselectedindexchanged="ddlstate_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="RFVstatevalidator" runat="server" ControlToValidate="ddlstate" ErrorMessage="Please select the state" ValidationGroup="employee" InitialValue="0"  Width="16px" >*</asp:RequiredFieldValidator>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="City:  "></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                               <asp:DropDownList ID="ddlcity" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px">  </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">                                                        
                                                                <asp:RequiredFieldValidator ID="RFVcityvalidator" runat="server" ControlToValidate="ddlcity" ErrorMessage="Please select the city" ValidationGroup="employee" InitialValue="0"  Width="16px" >*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Zipcode:  "></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtzip" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="E-Mail:"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <label>
                                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="s_textbox"  Width="180px"></asp:TextBox>
                                                                    </label>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ValidationGroup="employee"
                                                                ErrorMessage="enter valid email" Text="*" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ControlToValidate="txtEmail" ValidationGroup="employee" ErrorMessage="Email field cannot be blank" Width="16px" >*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Phone No:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtph" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <%--<asp:RequiredFieldValidator ID="Pinvalidator" runat="server" ControlToValidate="txtph" ValidationGroup="employee"  ErrorMessage="Please enter phone number"  Width="16px" >*</asp:RequiredFieldValidator>--%>                                                                                                                                                                                                          
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                               <asp:Label ID="Label24" runat="server" CssClass="s_label" Text="Mobile No: "></asp:Label> 
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtmobile" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px"> 
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                               <asp:Label ID="Label28" runat="server" CssClass="s_label" Text="Address Proof"></asp:Label> 
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">                                                                                                                                                                                                      
                                                                <asp:DropDownList ID="ddladdproof" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddladdproof_SelectedIndexChanged">
                                                                    <asp:ListItem>Driving Licence</asp:ListItem>
                                                                    <asp:ListItem>IC Number</asp:ListItem>
                                                                    <asp:ListItem>Pan Card</asp:ListItem>
                                                                    <asp:ListItem>Voter Id</asp:ListItem>
                                                                    <asp:ListItem>Passport</asp:ListItem>
                                                                    <asp:ListItem>Ration Card</asp:ListItem>
                                                                    <asp:ListItem>Other</asp:ListItem>
                                                                </asp:DropDownList>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <%--<asp:RequiredFieldValidator ID="addproofValidator6" runat="server" ControlToValidate="ddladdproof" ValidationGroup="employee" 
                                                                    ErrorMessage="Please select atleast one field for address proof" Width="16px">*</asp:RequiredFieldValidator>--%></td>
                                                        </tr>
                                                        <tr id="trother" runat="server">
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label29" runat="server" CssClass="s_label" Text="Proof Number"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtproofno" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px"> 
                                                                    <%--<asp:RequiredFieldValidator ID="proofnoValidator6" runat="server" ControlToValidate="txtproofno" ValidationGroup="employee" 
                                                                     ErrorMessage="proof number field cannot be blank" Width="16px">*</asp:RequiredFieldValidator>--%></td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label30" runat="server" CssClass="s_label" 
                                                                    Text="Other" Visible="False"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">                                                                                                                                                                                                      
                                                                <asp:TextBox ID="txtother" runat="server" CssClass="s_textbox" Width="180px" 
                                                                    Visible="False"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6"align="left" style="width: 710px">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td align="left" style="width: 325px; height: 40px">
                                                                            <asp:Label ID="Label33" runat="server" CssClass="s_label" 
                                                                                Text="Any of the employee's child studying in the school?"></asp:Label>
                                                                            </td>                                                    
                                                                        <td align="left" style="width: 30px; height: 40px">
                                                                            &nbsp;</td>
                                                                        <td align="left" style="width: 325px; height: 40px">
                                                                            <asp:RadioButton ID="rbtyes" runat="server" Checked="True" 
                                                                                CssClass="s_label" GroupName="childstudy" Text="Yes" AutoPostBack="True" 
                                                                                oncheckedchanged="rbtyes_CheckedChanged" />
                                                                            <asp:RadioButton ID="rbtno" runat="server" 
                                                                                CssClass="s_label" GroupName="childstudy" Text="No" AutoPostBack="True" 
                                                                                oncheckedchanged="rbtno_CheckedChanged" />
                                                                        </td>
                                                                        <td align="left" style="width: 30px; height: 40px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trchild" runat="server">
                                                                        <td align="left" style="width: 325px; height: 40px" class="s_label">
                                                                            If&nbsp; Yes&nbsp; Details?</td>                                                    
                                                                        <td align="left" style="width: 30px; height: 40px">
                                                                            &nbsp;</td>
                                                                        <td align="left" style="width: 325px; height: 40px">
                                                                            <asp:TextBox ID="txtyesdetail" runat="server" CssClass="s_textbox" 
                                                                                Width="300px"></asp:TextBox>
                                                                            </td>
                                                                        <td align="left" style="width: 30px; height: 40px">
                                                                             &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>    
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td align="left" >
                                                    <asp:Label ID="Label35" runat="server" CssClass="subtitle_label" Text="Administration"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left" style="height: 40px" colspan="2">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Date Of Joining:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:TextBox ID="txtjoiningdate" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                                <%--<ajaxtoolkit:CalendarExtender ID="Calendarextender1" runat="server" 
                                                                    CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtjoiningdate" 
                                                                    TargetControlID="txtjoiningdate">
                                                                </ajaxtoolkit:CalendarExtender>--%>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <%--<asp:RequiredFieldValidator ID="Requiredfieldvalidator9" runat="server" ControlToValidate="txtjoiningdate"  ErrorMessage="Please select date of joining" ValidationGroup="1" 
                                                                   Width="16px">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                                <asp:Label ID="Label36" runat="server" CssClass="s_label" 
                                                                    Text="Prohibition time period if any   "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                                <asp:Label ID="Label38" runat="server" CssClass="s_label" Text="Up to"></asp:Label>
                                                                <br />
                                                              <asp:TextBox ID="txtprohibitto" runat="server" CssClass="s_textbox" Width="130px"></asp:TextBox><%--
                                                               <ajaxtoolkit:CalendarExtender ID="Calendarextender4" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtprohibitto" TargetControlID="txtprohibitto"></ajaxtoolkit:CalendarExtender > --%>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtprohibitto" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                                <asp:Label ID="Label41" runat="server" CssClass="s_label" Text="Work Timings"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label39" runat="server" CssClass="s_label" Text="From"></asp:Label>
                                                                <br />
                                                              <asp:TextBox ID="txtworkftime" runat="server" CssClass="s_textbox" Width="130px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label40" runat="server" CssClass="s_label" Text="To"></asp:Label>
                                                                <br />
                                                              <asp:TextBox ID="txtworktotime" runat="server" CssClass="s_textbox" Width="130px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Salary:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtsal" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <%--<asp:RequiredFieldValidator ID="Requiredfieldvalidator11" runat="server" ControlToValidate="txtsal" ValidationGroup="employee" 
                                                                ErrorMessage="please enter salary" Width="16px">*</asp:RequiredFieldValidator>--%>
                                                                    <%--<asp:RegularExpressionValidator id="RegularExpressionValidator5" ControlToValidate="txtsal" runat="server"
                                                                    ValidationExpression="^[+-]?(?:\d+\.?\d*|\d*\.?\d+)[\r\n]*$" CssClass="style10" Display="Dynamic" ErrorMessage="*"></asp:RegularExpressionValidator>--%>
                                                                    
                                                                    </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Department:"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:DropDownList ID="ddldepart" runat="server" CssClass="s_dropdown"  Width="150px"></asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                               <%--<asp:RequiredFieldValidator ID="Requiredfieldvalidator7" runat="server" ValidationGroup="employee" ControlToValidate="ddldepart" ErrorMessage="you have not select department"  Width="16px" >*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Designation:  "></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:DropDownList ID="ddldesignation" runat="server" CssClass="s_dropdown" Width="150px"></asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <%--<asp:RequiredFieldValidator ID="Requiredfieldvalidator12" runat="server" ControlToValidate="ddldesignation" ValidationGroup="employee" ErrorMessage="you have not select designation" Width="16px" >*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label83" runat="server" CssClass="s_label" Text="Experienced:"></asp:Label>
                                                            </td>
                                                            <td colspan="2" align="left" style="width: 230px; height: 40px">
                                                                <asp:RadioButton ID="rbtexpyes" runat="server" CssClass="s_label" 
                                                                    GroupName="experienced" Text="Yes" AutoPostBack="True" Checked="True" 
                                                                    oncheckedchanged="rbtexpyes_CheckedChanged" />
                                                                <asp:RadioButton ID="rbtexpno" runat="server" CssClass="s_label" 
                                                                    GroupName="experienced" Text="No" AutoPostBack="True" 
                                                                    oncheckedchanged="rbtexpno_CheckedChanged" />
                                                            </td>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                                <asp:TextBox ID="txtexpyear" runat="server" CssClass="s_textbox" Width="60px"></asp:TextBox>
                                                                Years<asp:TextBox ID="txtexpmonth" runat="server" CssClass="s_textbox" 
                                                                    Width="60px"></asp:TextBox>Months</td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td align="left">
                                                 <asp:Label ID="Label73" runat="server" CssClass="subtitle_label" Text="Health"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                             <asp:Label ID="Label74" runat="server" CssClass="s_label" Text="Blood Group"></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                  <asp:DropDownList ID="ddlbloodgp" runat="server" CssClass="s_dropdown" Width="150px">
                                                                      <asp:ListItem>O +ve</asp:ListItem>
                                                                      <asp:ListItem>A +ve</asp:ListItem>
                                                                      <asp:ListItem>O -ve</asp:ListItem>
                                                                      <asp:ListItem>A -ve</asp:ListItem>
                                                                      <asp:ListItem>B +ve</asp:ListItem>
                                                                      <asp:ListItem>AB +ve</asp:ListItem>
                                                                      <asp:ListItem>AB -ve</asp:ListItem>
                                                                      <asp:ListItem>B -ve</asp:ListItem>
                                                                  </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <%--<td align="left" style="width: 125px; height: 40px">
                                                             <asp:Label ID="Label75" runat="server" CssClass="s_label" Text="Height"></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                            <asp:TextBox ID="txtheight" runat="server" CssClass="s_textbox" Width="100px"></asp:TextBox>
                                                             <asp:Label ID="Label81" runat="server" CssClass="s_label" Text="cms"></asp:Label></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="healthValidator6" runat="server" ControlToValidate="txtheight" ValidationGroup="employee" 
                                                                ErrorMessage="you have not enter height field" Width="16px">*</asp:RequiredFieldValidator></td>--%>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                             <asp:Label ID="Label76" runat="server" CssClass="s_label" Text="Allergies if any"></asp:Label></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                            <asp:TextBox ID="txtallergies" runat="server" CssClass="s_textbox" Width="300px"></asp:TextBox>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                             <asp:Label ID="Label77" runat="server" CssClass="s_label" 
                                                                    Text="Identification Mark"></asp:Label></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                            <asp:TextBox ID="txtidentificationmark" runat="server" CssClass="s_textbox" 
                                                                       Width="300px"></asp:TextBox>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                             <asp:Label ID="Label78" runat="server" CssClass="s_label" 
                                                                    Text="Original Documents Received"></asp:Label></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                            <asp:TextBox ID="txtoriginalreceive" runat="server" CssClass="s_textbox" Width="300px"></asp:TextBox>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                             <asp:Label ID="Label79" runat="server" CssClass="s_label" 
                                                                    Text="Any other Remarks/Notes"></asp:Label></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                            <asp:TextBox ID="txtotherremark" runat="server" CssClass="s_textbox" Width="300px"></asp:TextBox>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                             <asp:Label ID="Label80" runat="server" CssClass="s_label" Text="Add Teacher Photo"></asp:Label></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                                   <asp:FileUpload ID="file" runat="server" CssClass="s_dropdown" />
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td align="left">
                                                 <asp:Label ID="Label42" runat="server" CssClass="subtitle_label" Text="General"></asp:Label></td>
                                            </tr>
                                            <tr id="trteaching" runat="server">
                                                <td align="left" style="width: 710px; height: 40px">
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                             <asp:Label ID="Label43" runat="server" CssClass="s_label" Text="Teaching Subjects"></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" CssClass="panel">
                                                                <asp:CheckBoxList ID="chkteachsubject" runat="server" Height="26px"></asp:CheckBoxList>
                                                            </asp:Panel>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                             <asp:Label ID="Label44" runat="server" CssClass="s_label" Text="Teaching Standard's"></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Panel ID="Panel2" runat="server" CssClass="panel" ScrollBars="Vertical">
                                                                    <asp:CheckBoxList ID="chkteachclass" runat="server"> 
                                                                       
                                                                    </asp:CheckBoxList>
                                                                </asp:Panel>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" class="break"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                             <asp:Label ID="Label89" runat="server" CssClass="s_label" Text="Languages"></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                            <asp:Panel ID="Panel3" runat="server" ScrollBars="Vertical" CssClass="panel">
                                                                <asp:CheckBoxList ID="chklanguages" runat="server" Height="26px"></asp:CheckBoxList>
                                                            </asp:Panel>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                             <asp:Label ID="Label90" runat="server" CssClass="s_label" Text=" Extra Curricular Activities"></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Panel ID="Panel4" runat="server" CssClass="panel" ScrollBars="Vertical">
                                                                    <asp:CheckBoxList ID="chkextraactivities" runat="server" Height="26px"></asp:CheckBoxList>
                                                                </asp:Panel>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                             <asp:Label ID="Label45" runat="server" CssClass="s_label" Text="Home Standard and Sec"></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:DropDownList ID="ddlhomeclass" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" 
                                                                    onselectedindexchanged="ddltype_SelectedIndexChanged" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                             <asp:Label ID="Label46" runat="server" CssClass="s_label" Text="Mobile No for Sms"></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                            <asp:TextBox ID="txtmobilesms" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                               </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                             <asp:Label ID="Label86" runat="server" CssClass="s_label" Text="Transport"></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:RadioButton ID="rbtown" runat="server" Checked="True" 
                                                                    CssClass="s_label" GroupName="transport" Text="Own" />
                                                                <asp:RadioButton ID="rbtschool" runat="server" 
                                                                    CssClass="s_label" GroupName="transport" Text="School" />
                                                               </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label87" runat="server" CssClass="s_label" Text="Hosteller"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:RadioButton ID="rbthostelyes" runat="server" CssClass="s_label" 
                                                                    Text="Yes" GroupName="Hosteler" />
                                                                <asp:RadioButton ID="rbthostelno" runat="server" Checked="True" 
                                                                    CssClass="s_label" Text="No" GroupName="Hosteler" />
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="6" style="height:40px">                                                                                                                
                                                                <asp:Button ID="btnSave" runat="server" CssClass="s_button" 
                                                                    onclick="btnSave_Click" Text="Save" ValidationGroup="employee" Width="60px" />
                                                                <asp:Button ID="btnClear" runat="server" CssClass="s_button" 
                                                                    onclick="btnClear_Click" Text="Clear" Width="60px" />
                                                                <asp:Label ID="lblempid" runat="server" CssClass="s_label" Text="0" 
                                                                    Visible="False"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td align="left" >
                                                    <asp:Label ID="Label50" runat="server" CssClass="subtitle_label" Text="Education"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr> 
                                                <td align="left">
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left" style="width: 150px; height: 40px">
                                                                <asp:Label ID="Label51" runat="server" CssClass="s_label" Text="Mode Of Education"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 175px; height: 40px">
                                                                <asp:DropDownList ID="ddlmode" runat="server" CssClass="s_textbox" Width="160px" onselectedindexchanged="ddlmode_SelectedIndexChanged">
                                                                    <asp:ListItem Value="Select">-Select-</asp:ListItem>
                                                                    <asp:ListItem Value="SSLC">SSLC</asp:ListItem>
                                                                    <asp:ListItem Value="HSC">HSC</asp:ListItem>
                                                                    <asp:ListItem Value="UG">UG</asp:ListItem>
                                                                    <asp:ListItem Value="PG"></asp:ListItem>
                                                                    <asp:ListItem Value="OTHER">OTHER</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 150px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 175px; height: 40px"></td>
                                                            <td align="left" style="width: 30px; height: 40px"></td>
                                                    </tr>
                                                    <tr id="trdegree" runat="server">
                                                        <td align="left" style="width: 150px; height: 40px">
                                                            <asp:Label ID="lbldegree" runat="server" CssClass="s_label" Text="Degree"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 175px; height: 40px">
                                                            <asp:TextBox ID="txtdegree" runat="server" CssClass="s_textbox" Width="160px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                        <td align="left" style="width: 150px; height: 40px">&nbsp;</td>
                                                        <td align="left" style="width: 175px; height: 40px">&nbsp;</td>
                                                        <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 150px; height: 40px" id="lbldegre" runat="server">
                                                            <asp:Label ID="Label55" runat="server" CssClass="s_label" Text="Major "></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 175px; height: 40px">
                                                            <asp:TextBox ID="txtmajor" runat="server" CssClass="s_textbox" Width="160px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                        <td align="left" style="width: 150px; height: 40px">&nbsp;</td>
                                                        <td align="left" style="width: 175px; height: 40px">&nbsp;</td>
                                                        <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 150px; height: 40px">
                                                            <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Name of the Institution"></asp:Label>
                                                        </td>
                                                        <td colspan="3" align="left" style="width: 355px; height: 40px">
                                                            <asp:TextBox ID="txtinstitutename" runat="server" CssClass="s_textbox" Width="340px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 175px; height: 40px">&nbsp;</td>
                                                        <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 150px; height: 40px">
                                                            <asp:Label ID="Label56" runat="server" CssClass="s_label" Text="Year passed out"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 175px; height: 40px">
                                                            <asp:TextBox ID="txtpassedout" runat="server" CssClass="s_textbox" Width="160px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                        <td align="left" style="width: 150px; height: 40px">
                                                            <asp:Label ID="Label60" runat="server" CssClass="s_label" Text="Percentage"></asp:Label></td>
                                                        <td align="left" style="width: 175px; height: 40px" class="s_label">
                                                            <asp:TextBox ID="txtpercent" runat="server" CssClass="s_textbox" Width="100px"></asp:TextBox>
                                                            &nbsp;%</td>
                                                        <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center" style="height: 40px">
                                                            <asp:Button ID="btnsave2" runat="server" CssClass="s_button" Height="27px" 
                                                                onclick="btnSave2_Click" Text="Save" Width="60px" />
                                                            <asp:Button ID="btnclear2" runat="server" CssClass="s_button" 
                                                                onclick="btnclear2_Click" Text="Clear" Width="60px" />
                                                            <asp:Label ID="lbleduid" runat="server" CssClass="s_label" Text="0" 
                                                                Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="right" style="height: 40px">
                                                            <asp:DataGrid ID="dgeducation" runat="server" AutoGenerateColumns="False"  
                                                                OnEditCommand="dgeducation_EditCommand" Width="100%" BorderStyle="None" 
                                                                BorderWidth="0px" GridLines="None">
                                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item" Font-Size="11px"/>
                                                                <ItemStyle Font-Size="11px" CssClass="s_datagrid_item"/>
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="intemployee" HeaderText="Employee ID" Visible="False"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="strmode" HeaderText="Education Mode"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="strdegree" HeaderText="Degree"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="strmajor" HeaderText="Major"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="strinstitution" HeaderText="Institution Name"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="intyearpass" HeaderText="Passed Out"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="intpercent" HeaderText="Percentage(%)"></asp:BoundColumn>
                                                                    <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
                                                                    <ItemStyle Width="40px" />
                                                                    </asp:ButtonColumn>
                                                                    <asp:TemplateColumn HeaderText="Delete">
                                                                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="btndelete" runat="server" 
                                                                            ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                                        OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                                        onclick="btndelete1_Click" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                </Columns>
                                                                <HeaderStyle CssClass="s_datagrid_header" Font-Size="12px"/>
                                                             </asp:DataGrid>
                                                        </td>
                                                     </tr>
                                                </table>
                                                </td>
                                            </tr>
                                            <tr id="trexperienced" runat="server">
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                         <tr class="view_detail_subtitle_bg">
                                                            <td align="left">
                                                                <asp:Label ID="Label88" runat="server" CssClass="subtitle_label" Text="Experience Details"></asp:Label>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr >
                                                                        <td align="left">
                                                                            <table cellpadding="7" cellspacing="0" border="0" width="100%">
                                                                                 
                                                                                <tr>
                                                                                    <td colspan="2" align="left" style="width: 325px; height: 40px">
                                                                                        <asp:Label ID="Label67" runat="server" CssClass="s_label" Text="Previous Work History:"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                                                    <td align="left" style="width: 125px; height: 40px">&nbsp;</td>
                                                                                    <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" style="width: 125px; height: 40px">
                                                                                        <asp:Label ID="Label68" runat="server" CssClass="s_label" Text="Organisation Name"></asp:Label>
                                                                                    </td>
                                                                                    <td colspan="3" align="left" style="width: 355px; height: 40px">
                                                                                        <asp:TextBox ID="txtorgname" runat="server" CssClass="s_textbox" Width="340px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="left" style="width: 30px; height: 40px"></td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" style="width: 125px; height: 40px">
                                                                                        <asp:Label ID="Label69" runat="server" CssClass="s_label" Text="Period"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" style="width: 200px; height: 40px">
                                                                                        <asp:Label ID="Label71" runat="server" CssClass="s_label" Text="From"></asp:Label>
                                                                                        <br />
                                                                                        <asp:TextBox ID="txtperiodfrom" runat="server" CssClass="s_textbox" Width="130px"></asp:TextBox>
                                                                                       
                                                                                    </td>
                                                                                    <td align="left" style="width: 30px; height: 40px"></td>
                                                                                    <td align="left" style="width: 125px; height: 40px">
                                                                                        <asp:Label ID="Label72" runat="server" CssClass="s_label" Text="To"></asp:Label>
                                                                                        <asp:TextBox ID="txtperiodto" runat="server" CssClass="s_textbox" Width="130px"></asp:TextBox>
                                                                                        
                                                                                    </td>
                                                                                    <td align="left" style="width: 30px; height: 40px"></td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" style="width: 125px; height: 40px">
                                                                                        <asp:Label ID="Label19" runat="server" CssClass="s_label" Text="Department"></asp:Label></td>
                                                                                    <td align="left" style="width: 200px; height: 40px">
                                                                                        <asp:TextBox ID="txtorgdept" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox></td>
                                                                                    <td align="left" style="width: 30px; height: 40px"></td>
                                                                                    <td align="left" style="width: 125px; height: 40px">
                                                                                        <asp:Label ID="Label70" runat="server" CssClass="s_label" Text="Designation"></asp:Label></td>
                                                                                    <td align="left" style="width: 30px; height: 40px">
                                                                                        <asp:TextBox ID="txtorgdesig" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox></td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 40px" align="center" colspan="6">
                                                                                        <asp:Button ID="btnsubmit" runat="server" CssClass="s_button" onclick="btnsubmit_Click" Text="Save" Width="75px" />
                                                                                        <asp:Button ID="btnerase" runat="server" CssClass="s_button" onclick="btnerase_Click" Text="Clear" Width="75px" />
                                                                                        <asp:Label ID="lblexpid" runat="server" CssClass="s_label" Text="0" 
                                                                                            Visible="False"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" colspan="6">
                                                                                        <asp:DataGrid ID="dgexperience" runat="server" AutoGenerateColumns="False" OnEditCommand="dgexperience_EditCommand" 
                                                                                         Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                                                         <AlternatingItemStyle CssClass="s_datagrid_alt_item" Font-Size="11px"/>
                                                                                         <ItemStyle CssClass="s_datagrid_item" Font-Size="11px"/>
                                                                                         <Columns>
                                                                                         <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                                                         <asp:BoundColumn DataField="intemployee" HeaderText="Employee ID" Visible="False"></asp:BoundColumn>
                                                                                         <asp:BoundColumn DataField="strorganization" HeaderText="Organization"></asp:BoundColumn>
                                                                                         <asp:BoundColumn DataField="dtperiodfrom1" HeaderText="Period From"></asp:BoundColumn>
                                                                                         <asp:BoundColumn DataField="dtperiodto1" HeaderText="Period To"></asp:BoundColumn>
                                                                                         <asp:BoundColumn DataField="strdepartment" HeaderText="Department"></asp:BoundColumn>
                                                                                         <asp:BoundColumn DataField="strdesignation" HeaderText="Designation"></asp:BoundColumn>
                                                                                         <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;"></asp:ButtonColumn>
                                                                                         <asp:TemplateColumn HeaderText="Delete">
                                                                                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                                                            <ItemTemplate>
                                                                                                <asp:ImageButton ID="btndelete" runat="server" 
                                                                                                    ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                                                                OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                                                                onclick="btndelete_Click" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                         </Columns>
                                                                                         <HeaderStyle CssClass="s_datagrid_header" Font-Size="12px"/>
                                                                                        </asp:DataGrid>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                     </tr>
                                                                </table>
                                                            </td>
                                                         </tr>
                                                        <tr>
                                                            <td align="center">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Button ID="btndone" runat="server" CssClass="s_button" Text="Done" 
                                                                    Width="75px" onclick="btndone_Click" />
                                                        <asp:Button ID="btnClear3" runat="server" CssClass="s_button" Text="Cancel" 
                                                            Width="60px" CausesValidation="False" onclick="btnClear3_Click" Visible="False" />
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
                            </td>
                        </tr>
                        <tr>
                            <td class="break"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100%;" align="left" valign="top">
                    <uc6:app_footer ID="app_footer" runat="server" />
                </td>
            </tr>
        </table>
        <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
