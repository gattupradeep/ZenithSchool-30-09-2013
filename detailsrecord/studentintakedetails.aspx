<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentintakedetails.aspx.cs" Inherits="detailsrecord_studentintakedetails" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/detailsrecord_student.ascx" tagname="detailsrecord_student" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />    
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>  
    <script type="text/javascript">
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtdateofreg').datepicker({ dateFormat: 'yy/mm/dd',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(function() {
        var dates = $("#txtdateofreg").datepicker({
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                constrainDates: true,
                changeYear: true
            });
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtadmitdate').datepicker({ dateFormat: 'yy/mm/dd',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(function() {
        var dates = $("#txtadmitdate").datepicker({
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                constrainDates: true,
                changeYear: true
            });
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtbirthdate').datepicker({ dateFormat: 'yy/mm/dd',
                    changeMonth: true,
                    constrainDates: true,
                    yearRange: '1990:2020',
                    changeYear: true
                });
            }
        });
        $(function() {
        var dates = $("#txtbirthdate").datepicker({
                dateFormat: 'yy/mm/dd',
                maxDate: new Date,
                changeMonth: true,
                constrainDates: true,
                yearRange: '1990:2020',
                changeYear: true
            });
        });
    </script>
    <style type="text/css">
        .style1
        {
            width: 200px;
            height: 40px;
        }
        .style2
        {
            width: 35px;
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:toolkitscriptmanager>
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
                                        <uc1:detailsrecord_student ID="detailsrecord_student1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15PX" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                       <td  style="width:2%"></td>
                        <td style="width: 93%" valign="top" align="left">
                           <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                        <ProgressTemplate>
                                            <div id="progressBackgroundFilter"></div>
                                                <div id="processMessage">
                                                    <img alt="Loading" src="../media/images/Processing.gif" />
                                                </div>
                                        </ProgressTemplate>
                            </asp:UpdateProgress>--%>
                            <asp:UpdatePanel ID="updatepanal" runat="server" >
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnSave" />
                                </Triggers>
                                    <ContentTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                 <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/17.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Student Intake Details</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr> 
                               
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
                                        <table cellpadding="5" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="6">
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Student Details" ></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                 <td class="break" colspan="6">    
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td colspan="6">
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="student" DisplayMode="BulletList" HeaderText="Please fill the following errors" EnableClientScript="true" ShowMessageBox="true" CssClass="s_label" Height="100%" />
                                                </td>
                                             </tr>    
                                              <tr class="view_detail_subtitle_bg">
                                                <td align="left" colspan="6">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr >
                                                            <td style="width:200px" ><asp:Label ID="Label7" runat="server" Text="Personal Details" CssClass="subtitle_label"></asp:Label></td>
                                                                                                                        
                                                        </tr>                                                    
                                                    </table>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label20" runat="server" CssClass="s_label" Text="Year"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">&nbsp;
                                                    <asp:DropDownList ID="ddlyear" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="true" onselectedindexchanged="ddlyear_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlyear" ErrorMessage="Please select the year" ValidationGroup="student" InitialValue="--Select--"  Width="16px" >*</asp:RequiredFieldValidator>
                                                </td>
                                                 <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label22" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                </td>
                                                 <td align="left" style="height: 40px; width:200px">&nbsp;
                                                    <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                         Width="150px" AutoPostBack="true" onselectedindexchanged="ddlstandard_SelectedIndexChanged1"></asp:DropDownList>
                                                </td>
                                                 <td align="left" style="width: 35px; height: 40px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlstandard" ErrorMessage="Please select the standard" ValidationGroup="student" InitialValue="--Select--"  Width="16px" >*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                   <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Section"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                     <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlsection_SelectedIndexChanged" ></asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                     &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                         ControlToValidate="ddlsection" ErrorMessage="Please select the section" 
                                                         InitialValue="--Select--" ValidationGroup="student" Width="16px">*</asp:RequiredFieldValidator></td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                     <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="First Name"></asp:Label>
                                                    
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">&nbsp;
                                                    <asp:DropDownList ID="ddlfirstname" runat="server" CssClass="s_dropdown" 
                                                         Width="150px" AutoPostBack="true" onselectedindexchanged="ddlfirstname_SelectedIndexChanged"></asp:DropDownList>
                                                    
                                                </td>
                                                <td style="width:35px"></td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label27" runat="server" CssClass="s_label" Text="Middle Name"></asp:Label>
                                                    
                                                </td>
                                                <td align="left" >&nbsp;
                                                    <asp:TextBox ID="txtmiddle" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                   
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Last Name"></asp:Label>
                                                   
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">&nbsp;
                                                    <asp:TextBox ID="txtlast" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    
                                                </td>
                                                <td style="width:35px">
                                                    &nbsp;</td>
                                           </tr>
                                            <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                     <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="Gender"></asp:Label>
                                                    
                                                </td>
                                                <td align="left">
                                                    <asp:RadioButton ID="RBmale" runat="server" CssClass="s_label" Text="Male" GroupName="gender" Checked="True" />
                                                    <asp:RadioButton ID="RBfemale" runat="server" CssClass="s_label" Text="Female" GroupName="gender" />
                                                   
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label102" runat="server" CssClass="s_label" 
                                                        Text="Date Of Registration"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">&nbsp;
                                                    <asp:TextBox ID="txtdateofreg" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    </td>
                                                <td style="width:35px">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtappnumber"></asp:RequiredFieldValidator>--%>
                                                    </td>
                                           </tr>
                                           <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label13" runat="server" CssClass="s_label" 
                                                        Text="Date Of Admission"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:TextBox ID="txtadmitdate" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                        <%--<ajaxtoolkit:CalendarExtender ID="Calendarextender2" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtadmitdate" TargetControlID="txtadmitdate"></ajaxtoolkit:CalendarExtender >--%>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label101" runat="server" CssClass="s_label" 
                                                        Text="Application Number"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">&nbsp;
                                                    <asp:TextBox ID="txtappnumber" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:35px">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="s_label" 
                                                        ErrorMessage="*" ControlToValidate="txtadmitno"></asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label19" runat="server" CssClass="s_label" Text="Date Of Birth"></asp:Label>
                                                </td>
                                                <td align="left" >&nbsp;
                                                <asp:TextBox ID="txtbirthdate" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    <%--<ajaxtoolkit:CalendarExtender ID="Calendarextender1" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtbirthdate" TargetControlID="txtbirthdate"></ajaxtoolkit:CalendarExtender >--%>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    
                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" 
                                                        Text="Admission Number"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">&nbsp;                                                                                                                                                    
                                                   <asp:TextBox ID="txtadmitno" runat="server" CssClass="s_textbox" Width="180px" 
                                                        ontextchanged="txtadmitno_TextChanged"></asp:TextBox>                                                    
                                                </td>
                                                <td style="width:35px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label21" runat="server" CssClass="s_label" Text="Nationality"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:TextBox ID="txtnationality" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">                                                    
                                                    <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Student Birth/Passport/IC No"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">&nbsp;                                                                                                                                                    
                                                <asp:TextBox ID="txtstudentbirth" runat="server" CssClass="s_textbox" Width="180px" AutoPostBack="true"
                                                        ontextchanged="txtstudentbirth_TextChanged"></asp:TextBox>                                                    
                                                </td>
                                                <td style="width:35px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label23" runat="server" CssClass="s_label" Text="Religion"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:DropDownList ID="ddlreli" runat="server" CssClass="s_dropdown" AutoPostBack="true" 
                                                        Width="150px" onselectedindexchanged="ddlreli_SelectedIndexChanged">
                                                        <asp:ListItem Value="0" Text="Select" ></asp:ListItem>
                                                        <asp:ListItem >Hindu</asp:ListItem>
                                                        <asp:ListItem >Islam</asp:ListItem>
                                                        <asp:ListItem >Christian</asp:ListItem>
                                                        <asp:ListItem >Others</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label109" runat="server" CssClass="s_label" 
                                                        Text="(If other religion please enter)"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">&nbsp;
                                                    <asp:TextBox ID="txtreligion" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:35px">
                                                    &nbsp;</td>
                                            </tr>
                                           <%--<tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label88" runat="server" CssClass="s_label" Text="Community"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlcommunity" runat="server" CssClass="s_dropdown" Width="150px">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="FC">FC</asp:ListItem>
                                                        <asp:ListItem Value="BC">BC</asp:ListItem>
                                                        <asp:ListItem Value="FBC">FBC</asp:ListItem> 
                                                        <asp:ListItem Value="MBC">MBC</asp:ListItem>                                                       
                                                        <asp:ListItem Value="OBC">OBC</asp:ListItem>
                                                        <asp:ListItem Value="OC">OC</asp:ListItem>
                                                        <asp:ListItem Value="SC/ST">SC/ST</asp:ListItem>
                                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label89" runat="server" CssClass="s_label" Text="Caste"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="txtcaste" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:35px">
                                                    &nbsp;</td>
                                            </tr>--%>
                                            <tr>
                                              <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label35" runat="server" CssClass="s_label" Text="Father/Guardian Name"></asp:Label>
                                                </td>
                                                <td align="left" >&nbsp;                                                    
                                                    <asp:TextBox ID="txtfathername" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label25" runat="server" CssClass="s_label" Text="Residential Address"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;
                                                <asp:TextBox ID="txtresidential" runat="server" CssClass="s_textbox" Width="200px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td style="width:35px">
                                                    &nbsp;</td>
                                            </tr>
                                             <tr id="trroll" runat="server">
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label98" runat="server" CssClass="s_label" Text="Mother Tongue"></asp:Label>
                                                 </td>
                                                <td align="left">&nbsp;
                                                    <asp:TextBox ID="txtmothertongue" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                 </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label82" runat="server" CssClass="s_label" Text="Country"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">&nbsp;
                                                    <asp:DropDownList ID="ddlcountry" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlcountry_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                <td style="width:35px">
                                                    <asp:RequiredFieldValidator ID="RFVcountryvalidator1" runat="server" ControlToValidate="ddlcountry" ErrorMessage="Please select the country" InitialValue="0" ValidationGroup="student"  Width="16px" >*</asp:RequiredFieldValidator>
                                                     <%--<asp:RequiredFieldValidator ID="countryValidator6" runat="server" ControlToValidate="ddlcountry" ErrorMessage="Please select the country" ValidationGroup="employee"  Width="16px" >*</asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label28" runat="server" CssClass="s_label" Text="State"></asp:Label>
                                                </td>
                                                <td align="left" >&nbsp;
                                                    <asp:DropDownList ID="ddlstate" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlstate_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    <asp:RequiredFieldValidator ID="RFVstatevalidator1" runat="server" ControlToValidate="ddlstate" ErrorMessage="Please select the state" ValidationGroup="student" InitialValue="0" Width="16px" >*</asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label29" runat="server" CssClass="s_label" Text="City"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">&nbsp;
                                                    <asp:DropDownList ID="ddlcity" runat="server" CssClass="s_dropdown" Width="150px"></asp:DropDownList>
                                                </td>
                                                <td style="width:35px">
                                                    <asp:RequiredFieldValidator ID="RFVcityvalidator1" runat="server" ControlToValidate="ddlcity" ErrorMessage="Please select the city" InitialValue="0" ValidationGroup="student" Width="16px" >*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label30" runat="server" CssClass="s_label" Text="Zipcode"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                <asp:TextBox ID="txtzipcode" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox></td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px" valign="middle">
                                                    <asp:Label ID="Label31" runat="server" CssClass="s_label" Text="Residence Phone Number"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">&nbsp;
                                                    <asp:TextBox ID="txtphoneno" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:35px; height:40px">&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label32" runat="server" CssClass="s_label" Text="Mobile Number"></asp:Label>
                                                </td>
                                                <td align="left" >
                                                    <%--<asp:RegularExpressionValidator ID="rg" ControlToValidate="txtphoneno" ValidationExpression="^\d+$" runat="server" ErrorMessage="Enter number in numeric only"></asp:RegularExpressionValidator>--%>
                                                    &nbsp;<asp:TextBox ID="txtmobile" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox></td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label33" runat="server" CssClass="s_label" Text="Alternate Mobile Number&lt;/br&gt;(If Any)"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtmobile" ValidationExpression="^\d+$" runat="server" ErrorMessage="Enter number in numeric only"></asp:RegularExpressionValidator>--%>
                                                    &nbsp;<asp:TextBox ID="txtaltmobileno" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox></td>
                                                <td style="width:35px">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label34" runat="server" CssClass="s_label" Text="House"></asp:Label>
                                                </td>
                                                <td align="left" >
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtaltmobileno" ValidationExpression="^\d+$" runat="server" ErrorMessage="Enter number in numeric only"></asp:RegularExpressionValidator>--%>&nbsp; <asp:DropDownList ID="ddlhouse" runat="server" CssClass="s_dropdown" Width="150px"></asp:DropDownList>
                                                    
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="height: 40px; width:200px">
                                                    &nbsp;</td>
                                                <td style="width:35px">&nbsp;</td>
                                            </tr>
                                           
                                            <tr><td class="break" colspan="6"></td></tr>
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="6" >
                                                   <asp:Label CssClass="title_label" ID="Label4" runat="server" Text="Subject Details" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr><td class="break" colspan="6"></td></tr>
                                            <tr id="trtag1" runat="server">
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label73" runat="server" CssClass="s_label" Text="Hometeacher"></asp:Label></td>
                                                <td align="left" colspan="3" style="height: 40px">&nbsp;  
                                                    <asp:Label ID="lblteacher" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2" style="height: 40px">  
                                                    <asp:Button ID="btnassignhome" runat="server" CssClass="s_button" 
                                                        Text="Assign Homeclass" onclick="btnassignhome_Click" Visible="False"/>
                                                </td>
                                            </tr>
                                            <tr id="trtag2" runat="server">
                                                <td align="left" style="width:200px; height: 40px">
                                                    <asp:Label ID="Label74" runat="server" CssClass="s_label" Text="Subjects"></asp:Label>
                                                </td>
                                                <td style="width: 670px; height: 40px" colspan="5">&nbsp;
                                                    <asp:Label ID="lblsubjects" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>                                     
                                            <tr id="trtag3" runat="server">
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Second Language"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:DropDownList ID="ddlsecondlanguage" runat="server" CssClass="s_dropdown" Width="150px"></asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label75" runat="server" CssClass="s_label" Text="Third Language"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">&nbsp;
                                                    <asp:DropDownList ID="ddlthirdlanguage" runat="server" CssClass="s_dropdown" Width="150px"></asp:DropDownList>
                                                </td>
                                                <td style="width:35px"></td>
                                            </tr> 
                                            <tr>
                                                <td align="left" style="width: 870px; height: 10px" colspan="6">
                                                    &nbsp;</td>
                                            </tr> 
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label76" runat="server" CssClass="s_label" Text="Extra Curricular Activities"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:Panel ID="Panel1" runat="server" CssClass="panel" ScrollBars="Vertical">
                                                    <asp:CheckBoxList ID="chkextra" runat="server"></asp:CheckBoxList></asp:Panel>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">&nbsp;</td>
                                                <td align="left" style="height: 40px; width:200px">&nbsp;</td>
                                                <td style="width:35px"></td>
                                            </tr>
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" >
                                                   <asp:Label CssClass="title_label" ID="Label5" runat="server" Text="Parents Details" ></asp:Label>
                                                </td>
                                                <td align="left" colspan="5">&nbsp;
                                                    <asp:DropDownList ID="ddlparent" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlparent_SelectedIndexChanged">
                                                        <asp:ListItem Value="Father"></asp:ListItem>
                                                        <asp:ListItem Value="Mother"></asp:ListItem>
                                                        <asp:ListItem Value="Father & Mother"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="Ftag" runat="server">
                                                <td colspan="6">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="870">
                                                        <tr>
                                                           <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label38" runat="server" CssClass="s_label" 
                                                                Text="Father Occupation"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;
                                                                <asp:TextBox ID="txtfatherOccupation" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                            <asp:Label ID="Label110" runat="server" CssClass="s_label" 
                                                                    Text="Parent Passport or I.C No"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:200px">
                                                        &nbsp;
                                                        <asp:TextBox ID="txtparentpassport" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width:35px">
                                                                &nbsp;</td>
                                                        </tr>
                                                         <tr>
                                                                <td align="left" style="width: 200px; height: 40px">
                                                                    <asp:Label ID="Label39" runat="server" CssClass="s_label" 
                                                                        Text="Father Designation"></asp:Label>
                                                                </td>
                                                                <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;
                                                                <asp:TextBox ID="txtfatherdesignation" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                    &nbsp;</td>
                                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                                <td align="left" style="width: 200px; height: 40px">
                                                                    <asp:Label ID="Label40" runat="server" CssClass="s_label" 
                                                                        Text="Organization Name"></asp:Label>
                                                                </td>
                                                                <td align="left" style="height: 40px; width:200px">&nbsp;
                                                                <asp:TextBox ID="txtfatherorganisation" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                    &nbsp;</td>
                                                                <td style="width:35px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label41" runat="server" CssClass="s_label" Text="Work Address"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                            &nbsp;
                                                            <asp:TextBox ID="txtfatherworkaddress" runat="server" CssClass="s_textbox" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label85" runat="server" CssClass="s_label" Text="Country"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:200px">&nbsp;
                                                                <asp:DropDownList ID="ddlFcountry" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlFcountry_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td style="width:35px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label42" runat="server" CssClass="s_label" Text="State"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;
                                                                <asp:DropDownList ID="ddlFstate" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlFstate_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label43" runat="server" CssClass="s_label" Text="City"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:200px">&nbsp;
                                                                <asp:DropDownList ID="ddlFcity" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px"></asp:DropDownList>
                                                            </td>
                                                            <td style="width:35px">
                                                                &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 200px; height: 40px">
                                                            <asp:Label ID="Label44" runat="server" CssClass="s_label" Text="Zipcode"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 200px; height: 40px">
                                                        &nbsp;
                                                        <asp:TextBox ID="txtfatherpincode" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            &nbsp;</td>
                                                        <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                        <td align="left" style="width: 200px; height: 40px">
                                                            <asp:Label ID="Label97" runat="server" CssClass="s_label" 
                                                                Text="Father office number"></asp:Label>
                                                        </td>
                                                        <td align="left" style="height: 40px; width:200px">&nbsp;
                                                            <asp:TextBox ID="txtFofficephone" runat="server" CssClass="s_textbox" 
                                                                Width="180px"></asp:TextBox>

                                                        </td>
                                                        <td style="width:35px">&nbsp;</td>
                                                    </tr> 
                                                    <tr>
                                                        <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label100" runat="server" CssClass="s_label" 
                                                                    Text="Father email"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;
                                                                <asp:TextBox ID="txtfatheremail" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                        <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                        <td align="left" style="width: 200px; height: 40px">
                                                            <asp:Label ID="Label52" runat="server" CssClass="s_label" 
                                                                Text="Father Mobile Number"></asp:Label>
                                                        </td>
                                                        <td align="left" style="height: 40px; width:200px">&nbsp;
                                                            <asp:TextBox ID="txtfathermobileno" runat="server" CssClass="s_textbox" 
                                                                Width="180px"></asp:TextBox>
                                                           <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                                                ControlToValidate="txtfathermobileno" 
                                                                ErrorMessage="Enter number in numeric only" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
                                                        </td>
                                                        <td style="width:35px">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                            CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>    
                                                        <tr id="trfincome" runat="server">
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 35px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="height: 40px; width:200px">
                                                                &nbsp;</td>
                                                            <td style="width:35px">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>                                   
                                            <tr id="Mtag" runat="server">
                                                <td colspan="6">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="870">
                                                        <tr>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label36" runat="server" CssClass="s_label">Mother&apos;s Name</asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">&nbsp;
                                                                <asp:TextBox ID="txtmothername" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label53" runat="server" CssClass="s_label">Mother&apos;s Mobile Number</asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:200px">&nbsp;
                                                                <asp:TextBox ID="txtmothermobileno" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtmothermobileno" ValidationExpression="^\d+$" runat="server" ErrorMessage="Enter number in numeric only"></asp:RegularExpressionValidator>--%>
                                                            </td>
                                                            <%--<td style="width:35px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>
                                                            </td>--%>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label45" runat="server" CssClass="s_label">Mother&apos;s Occupation</asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">&nbsp;
                                                                <asp:RadioButton ID="RBhomemaker" runat="server" AutoPostBack="True" CssClass="s_label" GroupName="occupation" oncheckedchanged="RBhomemaker_CheckedChanged" Text="Home Maker" />
                                                                <asp:RadioButton ID="RBother" runat="server" AutoPostBack="True" CssClass="s_label" GroupName="occupation" oncheckedchanged="RBother_CheckedChanged" Text="Other" />
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="lblMdesig" runat="server" CssClass="s_label">Mother&amp;&apos;s Designation</asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:200px">&nbsp;
                                                                <asp:TextBox ID="txtmotherdesignation" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width:35px">&nbsp;</td>
                                                        </tr>
                                                        <tr id="tag1" runat="server">
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label47" runat="server" CssClass="s_label">Organization Name</asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">&nbsp;
                                                                <asp:TextBox ID="txtmotherorganisation" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label48" runat="server" CssClass="s_label">Work Address</asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:200px">&nbsp;
                                                                <asp:TextBox ID="txtmotherworkaddress" runat="server" CssClass="s_textbox" 
                                                                    TextMode="MultiLine" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width:35px"></td>
                                                        </tr>
                                                         <tr id="tag2" runat="server">
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label86" runat="server" CssClass="s_label" Text="Country"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">&nbsp;
                                                                <asp:DropDownList ID="ddlMcountry" runat="server" AutoPostBack="True" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlMcountry_SelectedIndexChanged" 
                                                                    Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label49" runat="server" CssClass="s_label">State</asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:200px">&nbsp;
                                                                <asp:DropDownList ID="ddlMstate" runat="server" AutoPostBack="True" CssClass="s_dropdown" onselectedindexchanged="ddlMstate_SelectedIndexChanged" 
                                                                    Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width:35px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr id="tag3" runat="server">
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label50" runat="server" CssClass="s_label">City</asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">&nbsp;
                                                                <asp:DropDownList ID="ddlMcity" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="lblzip" runat="server" CssClass="s_label">Zipcode</asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:200px">&nbsp;
                                                                <asp:TextBox ID="txtmotherpincode" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width:35px"></td>
                                                        </tr>
                                                        <tr id="tag4" runat="server">                                            
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label99" runat="server" CssClass="s_label" 
                                                                    Text="Mother office number"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">&nbsp;
                                                                <asp:TextBox ID="txtMofficephone" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label105" runat="server" CssClass="s_label" 
                                                                    Text="Mother Email address"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:200px">&nbsp;
                                                                <asp:TextBox ID="txtMemail" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width:35px"></td>
                                                        </tr> 
                                                        <tr id="tag5" runat="server">
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;</td>
                                                            <td  align="left" style="width: 200px; height: 40px">
                                                                &nbsp;</td>
                                                            <%--<td align="left" style="width: 35px; height: 40px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>
                                                            </td>--%>
                                                            <td align="left" style="width: 200px; height: 40px"></td>
                                                            <td align="left" style="height: 40px; width:200px">&nbsp;</td>
                                                            <td style="width:35px">&nbsp;</td>
                                                        </tr>     
                                                    </table>
                                                </td>                                                
                                            </tr>
                                             <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="6" >
                                                   <asp:Label CssClass="title_label" ID="Label61" runat="server" Text="Parents/Guardain Details For Emergency" ></asp:Label>
                                                </td>
                                                <%--<td align="left" colspan="5">
                                                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlparent_SelectedIndexChanged">
                                                        <asp:ListItem Value="Father/Guardian"></asp:ListItem>
                                                        <asp:ListItem Value="Mother"></asp:ListItem>
                                                        <asp:ListItem Value="Father & Mother"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>--%>
                                            </tr>
                                             <tr id="Etag" runat="server">
                                                <td colspan="6">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="870">
                                                        <tr>
                                                           <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label14" runat="server" CssClass="s_label" 
                                                                Text="Name "></asp:Label>
                                                            </td>
                                                            <td align="left" >&nbsp;
                                                                <asp:TextBox ID="txtemergencyname" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                            <asp:Label ID="Label37" runat="server" CssClass="s_label" Text="Passport or I.C No"></asp:Label>
                                                            </td>
                                                            <td align="left" >&nbsp;
                                                        <asp:TextBox ID="txtemergencypassport" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width:35px">
                                                                &nbsp;</td>
                                                        </tr>
                                                         <tr>
                                                                <td align="left" style="width: 200px; height: 40px">
                                                            <asp:Label ID="Label51" runat="server" CssClass="s_label" 
                                                                Text="Relationship to student"></asp:Label>
                                                                </td>
                                                                <td align="left" >&nbsp;
                                                        <asp:TextBox ID="txtrelation" runat="server" CssClass="s_textbox" 
                                                                Width="180px"></asp:TextBox>

                                                                </td>
                                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                                <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label60" runat="server" CssClass="s_label" 
                                                                    Text="Home Number"></asp:Label>
                                                                </td>
                                                                <td align="left" >&nbsp;
                                                                <asp:TextBox ID="txtemergencyhome" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="width:35px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style1">
                                                            <asp:Label ID="Label46" runat="server" CssClass="s_label" 
                                                                Text="Office number"></asp:Label>
                                                                </td>
                                                            <td align="left" >&nbsp;
                                                            <asp:TextBox ID="txtemergencyoffice" runat="server" CssClass="s_textbox" 
                                                                Width="180px"></asp:TextBox>

                                                                </td>
                                                            <td align="left" class="style2"></td>
                                                            <td align="left" class="style1">
                                                            <asp:Label ID="Label54" runat="server" CssClass="s_label" 
                                                                Text="Mobile Number"></asp:Label>
                                                                </td>
                                                            <td align="left">&nbsp;
                                                            <asp:TextBox ID="txtemergencymobile" runat="server" CssClass="s_textbox" 
                                                                Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td class="style2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;</td>
                                                            <%--<td align="left" style="height: 40px; width:200px">
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                                                ControlToValidate="txtfathermobileno" 
                                                                ErrorMessage="Enter number in numeric only" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                            </td>--%>
                                                            <%--<td style="width:35px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                        CssClass="s_label" ErrorMessage="*" ControlToValidate="txtdateofreg"></asp:RequiredFieldValidator>
                                                                    </td>--%>
                                                    </tr>
                                                 </table>
                                                </td>
                                            </tr>                                   
                                            <tr><td colspan="6" class="break"></td></tr> 
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label56" runat="server" CssClass="s_label" 
                                                        Text="Siblings Studying &lt;/br&gt;in the school ?"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:RadioButton ID="RBsY" runat="server" AutoPostBack="True" 
                                                        CssClass="s_label" GroupName="sibling" oncheckedchanged="RBsY_CheckedChanged" 
                                                        Text="Yes" />
                                                    <asp:RadioButton ID="RBsN" runat="server" AutoPostBack="True" 
                                                        CssClass="s_label" GroupName="sibling" oncheckedchanged="RBsN_CheckedChanged" 
                                                        Text="No" />
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="height: 40px; width:200px">
                                                    &nbsp;</td>
                                                <td style="width:35px"></td>
                                            </tr>
                                            <tr id="trtag" runat="server">
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label55" runat="server" CssClass="s_label" 
                                                        Text="Number Of Siblings"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:TextBox ID="txtnoofsiblings" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label57" runat="server" CssClass="s_label" Text="If Yes, Enter Details"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                <asp:TextBox ID="txtsiblingdetails" runat="server" CssClass="s_textbox" 
                                                        Width="200px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td style="width:35px"></td>
                                            </tr>
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="6" >
                                                   <asp:Label CssClass="title_label" ID="Label6" runat="server" Text="Communication Details" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label58" runat="server" CssClass="s_label" Text="Mobile Number For SMS"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:DropDownList ID="ddlmobileforsms" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlmobileforsms_SelectedIndexChanged">
                                                    <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                                    <asp:ListItem Text="Father's" Value="Father"></asp:ListItem>
                                                    <asp:ListItem Text="Mother's" Value="Mother"></asp:ListItem>
                                                    <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label79" runat="server" CssClass="s_label" Text="If other Enter number"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">&nbsp;
                                                <asp:TextBox ID="txtothermobileno" runat="server" CssClass="s_textbox" 
                                                        Width="180px" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td style="width:35px"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label59" runat="server" CssClass="s_label" 
                                                        Text="Parent's Personal Email "></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                <asp:TextBox ID="txtpersonalemail" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    &nbsp;</td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label62" runat="server" CssClass="s_label" Text="Correspondence Address"></asp:Label>
                                                </td>
                                                <td align="left" >&nbsp;
                                                     <asp:TextBox ID="txtcorresaddress" runat="server" CssClass="s_textbox" 
                                                         Width="200px" TextMode="MultiLine"></asp:TextBox>
                                                     &nbsp;</td>
                                                <td style="width:35px">&nbsp;</td>
                                            </tr> 
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="6" >
                                                   <asp:Label CssClass="title_label" ID="Label8" runat="server" Text="Health Details" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label69" runat="server" CssClass="s_label" Text="Height"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:TextBox ID="txtheight" runat="server" CssClass="s_textbox" Width="170px"></asp:TextBox><asp:Label ID="cms" runat="server" Text="cms" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label94" runat="server" CssClass="s_label" Text="Weight"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:TextBox ID="txtweight" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:35px"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label68" runat="server" CssClass="s_label" Text="Blood Group"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:DropDownList ID="ddlbloodgroup" runat="server" CssClass="s_dropdown" Width="150px">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="O +ve">O +ve</asp:ListItem>
                                                    <asp:ListItem Value="A +ve">A +ve</asp:ListItem>
                                                    <asp:ListItem Value="O -ve">O -ve</asp:ListItem>
                                                    <asp:ListItem Value="A -ve">A -ve</asp:ListItem>
                                                    <asp:ListItem Value="B +ve">B +ve</asp:ListItem>
                                                    <asp:ListItem Value="AB +ve">AB +ve</asp:ListItem>
                                                    <asp:ListItem Value="AB -ve">AB -ve</asp:ListItem>
                                                    <asp:ListItem Value="B -ve">B -ve</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label70" runat="server" CssClass="s_label" Text="Identification Mark 1"></asp:Label>
                                                </td>
                                                <td align="left" >&nbsp;
                                                    <asp:TextBox ID="txtidentification1" runat="server" CssClass="s_textbox" 
                                                        Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td style="width:35px"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label72" runat="server" CssClass="s_label" Text="Identification Mark 2"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:TextBox ID="txtidentification2" runat="server" CssClass="s_textbox" 
                                                        Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px"></td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label71" runat="server" CssClass="s_label" Text="Allergies (If Any)"></asp:Label>
                                                </td>
                                                <td align="left" >&nbsp;
                                                    <asp:TextBox ID="txtallergies" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:35px"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label91" runat="server" CssClass="s_label" Text="Hostler"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:RadioButton ID="hostleryes" runat="server" 
                                                        CssClass="s_label" GroupName="hostler" Text="Yes" AutoPostBack="True" 
                                                        oncheckedchanged="hostleryes_CheckedChanged1" />
                                                    <asp:RadioButton ID="hostlerno" runat="server" 
                                                        CssClass="s_label" GroupName="hostler" Text="No" AutoPostBack="True" 
                                                        oncheckedchanged="hostlerno_CheckedChanged1" />
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="height: 40px; width:200px">
                                                     &nbsp;</td>
                                                <td style="width:35px">&nbsp;</td>
                                            </tr>
                                            <tr id="trtransporthead" runat="server" class="view_detail_title_bg" >
                                                <td align="left" colspan="6" >
                                                   <asp:Label CssClass="title_label" ID="Label10" runat="server" Text="Transport Details" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trtransport" runat="server">
                                                <td align="left" colspan="6">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">                                                         
                                                        <tr>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label95" runat="server" CssClass="s_label" Text="Transport"></asp:Label>                                                        
                                                            </td>
                                                            <td align="left">&nbsp;
                                                                 <asp:RadioButton ID="rbschool" runat="server" CssClass="s_label" GroupName="transport" Text="School Transport" AutoPostBack="True" 
                                                                    oncheckedchanged="rbschool_CheckedChanged" />
                                                                 <asp:RadioButton ID="rbown" runat="server" CssClass="s_label" GroupName="transport" Text="Own" AutoPostBack="True" 
                                                                oncheckedchanged="rbown_CheckedChanged" />    
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="height: 40px; width:200px">
                                                                 &nbsp;</td>
                                                            <td style="width:35px">&nbsp;</td>
                                                        </tr>
                                                        <tr id="tr1" runat="server">
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label77" runat="server" CssClass="s_label" Text="Route"></asp:Label>
                                                            </td>
                                                            <td align="left">&nbsp;
                                                                <asp:DropDownList ID="ddlroute" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlroute_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label108" runat="server" CssClass="s_label" Text="Destination"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:200px">&nbsp;
                                                                <asp:DropDownList ID="ddlpickanddrop" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlroute_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td style="width:35px"></td>
                                                        </tr> 
                                                        <tr id="tr2" runat="server">
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label83" runat="server" CssClass="s_label" Text="Bus Number"></asp:Label>
                                                            </td>
                                                            <td align="left">&nbsp;
                                                                <asp:Label ID="lblbusnumber" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 35px; height: 40px"></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label84" runat="server" CssClass="s_label" Text="Driver Name"></asp:Label>
                                                            </td>
                                                            <td align="left">&nbsp;
                                                                <asp:Label ID="lbldriver" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="width:35px"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="6" >
                                                   <asp:Label CssClass="title_label" ID="Label12" runat="server" Text="Other Details" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style=" height: 40px; width:200px">
                                                    <asp:Label ID="Label78" runat="server" CssClass="s_label" Text="Original Documents Recieved"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:TextBox ID="txtdocuments" runat="server" CssClass="s_textbox"  Width="190px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td style="width: 35px">&nbsp;</td>
                                                <td align="left" style="height: 40px; width:200px">
                                                    <asp:Label ID="Label80" runat="server" CssClass="s_label" Text="Other Remarks / Notes"></asp:Label>
                                                        </td>
                                                <td align="left" style="height: 40px; width:200px">&nbsp;
                                                     <asp:TextBox ID="txtremarks" runat="server" CssClass="s_textbox" Width="190px" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                <td style="width:35px"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label81" runat="server" CssClass="s_label" Text="Student Photo"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 435px; height: 40px" colspan="3">&nbsp;
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px; font-size:medium">
                                                     <asp:Literal ID="lit_Status" runat="server" />
                                                </td>
                                                <td style="width:35px"></td>
                                            </tr> 
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label106" runat="server" CssClass="s_label" 
                                                        Text="Previous Standard"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:TextBox ID="txtpreviousclass" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label90" runat="server" CssClass="s_label" 
                                                        Text="Previous Institution"></asp:Label>
                                                        </td>
                                                <td align="left" style="height: 40px; width:200px">&nbsp;
                                                    <asp:TextBox ID="txtprviousinstitute" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                        </td>
                                                <td style="width:35px"></td>
                                            </tr> 
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label107" runat="server" Text="Concession Details" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                    <asp:TextBox ID="txtconcession" runat="server" CssClass="s_textbox" 
                                                        Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 35px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="height: 40px; width:200px">&nbsp;</td>
                                                <td style="width:35px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" style="height: 40px">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" Width="60px" onclick="btnSave_Click" ValidationGroup="student" />
                                                    <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" 
                                                        Width="60px" onclick="btnClear_Click" CausesValidation="False" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                            </table>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table></td></tr><tr>
            <td style="width: 100%" valign="top">
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

