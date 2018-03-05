<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registrationform.aspx.cs" Inherits="admission_registrationform" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/admission.ascx" tagname="admission" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <<link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
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

            $("ul#topnav li").hover(function() { //Hover over event on list item
                $(this).css({ 'background': '#88BB00 url(topnav_active.gif) repeat-x' }); //Add background color + image on hovered list item
                $(this).find("span").show(); //Show the subnav
            }, function() { //on hover out...
                $(this).css({ 'background': 'none' }); //Ditch the background
                $(this).find("span").hide(); //Hide the subnav
            });

        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtbirthdate').datepicker({ dateFormat: 'yy/mm/dd',
                changeMonth: true,
                constrainDates: true,
                yearRange: '1930:2030', 
                maxDate: new Date,
                changeYear: true });
            }
        });
        $(function() {
        var dates = $("#txtbirthdate").datepicker({
                dateFormat: 'yy/mm/dd',
                constrainDates: true,
                changeMonth: true,
                maxDate: new Date,
                yearRange: '1930:2030',
                changeYear: true
            });
        });
    </script>    
      
   
      
    <style type="text/css">
        .style1
        {
            width: 700px;
            height: 20px;
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
            <td style="width: 100%; height: 144px" align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
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
                                        <uc1:admission ID="admission" runat="server" />
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
                        <td style="width: 2%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="750px">
                                            <tr>
                                                  <td class="app_cont_title_img_td"><img src="../images/icons/50X50/76.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td style="width:550px; height: 50px">
                                                    Registration Form</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                               <tr>
                                    <td style="width: 100%; height: 10px">
                                        <table cellpadding="5" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                               <td align="left" colspan="6">
                                                    <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Particulars of student"></asp:Label>
                                               </td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 850px; height: 20px" colspan="6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label117" runat="server" CssClass="s_label" Text="Year"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:DropDownList ID="ddlyear" runat="server" CssClass="s_dropdown" Width="150px">
                                                    </asp:DropDownList>
                                                 </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Date "></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">
                                                <asp:TextBox ID="txtdate" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                        </td>
                                                <td style="width:20px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="First Name"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                     <asp:TextBox ID="txtfirst" runat="server" CssClass="s_textbox" Width="180px" TabIndex="1"></asp:TextBox>
                                                     </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label27" runat="server" CssClass="s_label" Text="Middle Name"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="txtmiddle" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    </td>
                                                <td style="width:20px">&nbsp;</td>
                                           </tr>
                                           <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Last Name"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:TextBox ID="txtlast" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label21" runat="server" CssClass="s_label" Text="Nationality"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="txtnationality" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:20px">&nbsp;</td>
                                            </tr>
                                           <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label23" runat="server" CssClass="s_label" Text="Religion"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="txtreligion" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="Gender"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:RadioButton ID="RBfemale" runat="server" CssClass="s_label" Text="Female" 
                                                        GroupName="gender" />
                                                    &nbsp; <asp:RadioButton ID="RBmale" runat="server" CssClass="s_label" Text="Male" GroupName="gender" />
                                                 </td>
                                                <td style="width:20px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    
                                                    <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Student Birth/Passport/IC NO"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:TextBox ID="txtstudentbirth" runat="server" CssClass="s_textbox" Width="180px" AutoPostBack="true"></asp:TextBox>
                                                    
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label98" runat="server" CssClass="s_label" Text="Mother Tongue"></asp:Label>
                                                        </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp; 
                                                    <asp:TextBox ID="txtmothertongue" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:20px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label19" runat="server" CssClass="s_label" Text="Date Of Birth"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="txtbirthdate" runat="server" CssClass="s_textbox" Width="180px" 
                                                        AutoPostBack="True" ontextchanged="txtbirthdate_TextChanged"></asp:TextBox>
                                                         <%--<ajaxtoolkit:CalendarExtender ID="Calendarextender2" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtbirthdate" TargetControlID="txtbirthdate"></ajaxtoolkit:CalendarExtender >--%>
                                                    </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label67" runat="server" CssClass="s_label" Text="Age"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 210px; height: 40px">
                                                    <asp:TextBox ID="txtage" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:20px">
                                                    &nbsp;</td>                                               
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label28" runat="server" CssClass="s_label" 
                                                        Text="Admission Required for Class" Width="190px"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                   <asp:DropDownList ID="ddlstandard" runat="server" Width="150px">
                                                   </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Present Class"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 210px; height: 40px">
                                                    <asp:TextBox ID="txtpresentclass" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                    </td>
                                                <td style="width:20px">
                                                    &nbsp;</td>                                               
                                            </tr>
                                           <tr>
                                               <td align="left" style="height: 10px; width:700px; font-family: 'Trebuchet MS'; font-size: 16px; color: #2DA0ED;" colspan="6" valign="bottom"></td>
                                            </tr>
                                            
                                            <tr class="view_detail_title_bg" >
                                               <td align="left" colspan="6">
                                                    <asp:Label CssClass="title_label" ID="lblparent" runat="server" Text="Parents / Guardian Details"></asp:Label>
                                               </td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 700px; height: 20px" colspan="6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label39" runat="server" CssClass="s_label" 
                                                        Text="Father/Guardian Name"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="txtfathername" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label114" runat="server" CssClass="s_label" Text="Mother  Name"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">
                                                <asp:TextBox ID="txtmothername" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    </td>
                                                <td style="width:20px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label115" runat="server" CssClass="s_label" 
                                                        Text="Father/Guardian Qualification"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="txtfatherqualification" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" 
                                                        Text="Mother Qualification"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">
                                                <asp:TextBox ID="txtmotherqualification" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                        </td>
                                                <td style="width:20px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label116" runat="server" CssClass="s_label" 
                                                        Text="Father/Guardian Occupation"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="txtfatheroccupation" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label40" runat="server" CssClass="s_label" 
                                                        Text="Mother Occupation"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">
                                                <asp:TextBox ID="txtmotheroccupation" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:20px">
                                                    &nbsp;</td>
                                            </tr>
                                             <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Parents E-mail"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="txtemail" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                            &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label9" runat="server" CssClass="s_label" 
                                                        Text="Mobile Number"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">
                                                <asp:TextBox ID="Txtmobile" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:20px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Phone Number"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="Txtphone" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label31" runat="server" CssClass="s_label" Text="Home Town"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">
                                                <asp:TextBox ID="txthometown" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                        </td>
                                                <td style="width:20px">&nbsp;</td>
                                            </tr> 
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label82" runat="server" CssClass="s_label" Text="Country"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:DropDownList ID="ddlcountry" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlcountry_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label42" runat="server" CssClass="s_label" Text="State"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">
                                                    <asp:DropDownList ID="ddlstate" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlstate_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                <td style="width:20px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label50" runat="server" CssClass="s_label">City</asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:DropDownList ID="ddlcity" runat="server" CssClass="s_dropdown" Width="150px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label45" runat="server" CssClass="s_label"> Address</asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:200px">
                                                <asp:TextBox ID="txtpermanent" runat="server" CssClass="s_textbox" Width="180px" 
                                                        TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td style="width:20px">
                                                    &nbsp;</td>
                                            </tr>                               
                                            <tr>
                                                <td align="left" style="width: 700px; height: 20px; font-family: Arial; font-size: 16px; color: #2DA0ED;" colspan="6" valign="bottom">
                                                   
                                                  </td>
                                            </tr>                                            
                                             <tr class="view_detail_title_bg" >
                                               <td align="left" colspan="6">
                                                    <asp:Label CssClass="title_label" ID="lblstaffchild" runat="server" Text="Staff Child(Mention the name of the parents(s) working at the school)"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width:500px; height: 40px"; >
                                                    <asp:Label ID="Label20" runat="server" CssClass="s_label" 
                                                        Text="Whether any of the parent working in our school?"></asp:Label>
                                               </td>
                                                 <td align="left" style="width:200px; height: 40px"; colspan="5" >
                                                    
                                                    &nbsp;<asp:RadioButton ID="RByes" runat="server" CssClass="s_label" Text="Yes" 
                                                         GroupName="Parents Name" AutoPostBack="True" 
                                                         oncheckedchanged="RByes_CheckedChanged" />
                                                    
                                                    &nbsp;
                                                    
                                                    <asp:RadioButton ID="RBno" runat="server" CssClass="s_label" Text="No" 
                                                         GroupName="Parents Name" AutoPostBack="True" 
                                                         oncheckedchanged="RBno_CheckedChanged" Checked="True" />
                                                    
                                               </td>                                                                              
                                            </tr>
                                            <tr id="trstaff" runat="server">
                                                <td align="left" style="width: 800px; height: 40px; font-family:Arial; font-size:16px; color: #2DA0ED" colspan="6" valign="top">
                                                    <table>
                                                        <tr>
                                                            <td align="left" style="width: 700px; height: 10px; font-family: Arial; font-size: 16px; color: #2DA0ED;" colspan="6" valign="bottom"></td>
                                                         </tr>
                                                         <tr>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                 <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Name"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                 <asp:Label ID="Label22" runat="server" CssClass="s_label" Text="Department"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                  <asp:Label ID="Label24" runat="server" CssClass="s_label" Text="Designation"></asp:Label>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:200px">
                                                                  <asp:Label ID="Label113" runat="server" CssClass="s_label" 
                                                                      Text="Relation with the student"></asp:Label>
                                                            </td>
                                                            <td style="width:20px"></td>
                                                        </tr> 
                                                        <tr>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;<asp:TextBox ID="txtstaff1" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;<asp:TextBox ID="txtdept1" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>&nbsp;</td>
                                                            <td align="left" style="width: 50px; height: 40px">
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;<asp:TextBox ID="txtdesig1" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>&nbsp;</td>
                                                            <td align="left" style="height: 40px; width:20px">
                                                                <asp:TextBox ID="txtrelation" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="height: 40px; width:20px">
                                                            </td>
                                                         </tr> 
                                                     </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="font-family: Arial; font-size: 16px; color: #2DA0ED;" 
                                                    colspan="6" valign="bottom" class="style1">
                                                    </td>
                                            </tr> 
                                            <tr class="view_detail_title_bg" >
                                               <td align="left" colspan="6">
                                                    <asp:Label CssClass="title_label" ID="lblprevious" runat="server" Text=" Details of the previous school"></asp:Label> 
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td align="left" style="width: 700px; height: 5px" colspan="6">&nbsp;</td>
                                            </tr> 
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label99" runat="server" CssClass="s_label" 
                                                        Text="Name of the School"></asp:Label>
                                                </td>
                                                
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label100" runat="server" CssClass="s_label" 
                                                        Text="Medium of Instruction"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px"></td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label101" runat="server" CssClass="s_label" 
                                                        Text="Previous Class Studied" Width="150"></asp:Label>
                                                        </td>
                                                <td align="left" style="height: 40px; width:200px">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label102" runat="server" CssClass="s_label" 
                                                        Text="Aggregate Marks(%) "></asp:Label>
                                                        &nbsp;</td>
                                                <td style="width:20px"></td>
                                           </tr> 
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label103" runat="server" CssClass="s_label" Text="1."></asp:Label>
                                                     <asp:TextBox ID="txtpreviousschool1" runat="server" CssClass="s_textbox" 
                                                        Width="135px"></asp:TextBox></td>
                                                <td  style="width: 200px; height: 40px" align="center">
                                                     <asp:TextBox ID="txtpreviousmedium1" runat="server" CssClass="s_textbox" 
                                                        Width="140px"></asp:TextBox>
                                                     </td>
                                                <td style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                                <td  style="width: 200px; height: 40px">
                                                     <asp:TextBox ID="txtpreviousclass1" runat="server" CssClass="s_textbox" 
                                                        Width="140px"></asp:TextBox>
                                                    </td>
                                                <td align="center"  style="height: 40px; width:200px" >
                                                     <asp:TextBox ID="txtpreviousagrr1" runat="server" CssClass="s_textbox" 
                                                        Width="140px"></asp:TextBox>
                                                     </td>
                                                <td  style="height: 40px; width:20px">
                                                    &nbsp;</td>
                                            </tr> 
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label104" runat="server" CssClass="s_label" Text="2."></asp:Label>
                                                    <asp:TextBox ID="txtpreviousschool2" runat="server" CssClass="s_textbox" 
                                                        Width="135px"></asp:TextBox></td>
                                                <td align="center" style="width: 200px; height: 40px">
                                                     
                                                     <asp:TextBox ID="txtpreviousmedium2" runat="server" CssClass="s_textbox" 
                                                        Width="140px"></asp:TextBox>
                                                     </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                     <asp:TextBox ID="txtpreviousclass2" runat="server" CssClass="s_textbox" 
                                                        Width="140px"></asp:TextBox>
                                                    </td>
                                                <td align="center" style="height: 40px; width:200px">
                                                     
                                                     <asp:TextBox ID="txtpreviousagrr2" runat="server" CssClass="s_textbox" 
                                                        Width="140px"></asp:TextBox>
                                                     </td>
                                                <td style="width:20px">
                                                    &nbsp;</td>
                                            </tr> 
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label105" runat="server" CssClass="s_label" Text="3."></asp:Label>
                                                    <asp:TextBox ID="txtpreviousschool3" runat="server" CssClass="s_textbox" 
                                                        Width="135px"></asp:TextBox></td>
                                                <td align="center" style="width: 200px; height: 40px">
                                                     <asp:TextBox ID="txtpreviousmedium3" runat="server" CssClass="s_textbox" 
                                                        Width="140px"></asp:TextBox></td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                   </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                     <asp:TextBox ID="txtpreviousclass3" runat="server" CssClass="s_textbox" 
                                                        Width="140px"></asp:TextBox>
                                                    </td>
                                                <td align="center" style="height: 40px; width:200px">
                                                     <asp:TextBox ID="txtpreviousagrr3" runat="server" CssClass="s_textbox" 
                                                        Width="140px"></asp:TextBox>
                                                    </td>
                                                <td style="width:20px">
                                                    &nbsp;</td>
                                             </tr>
                                             <tr>
                                                <td align="left" style="width: 700px; height: 10px; font-family: Arial; font-size: 16px; color: #2DA0ED;" colspan="6" valign="bottom"></td>
                                            </tr> 
                                            <tr class="view_detail_title_bg" >
                                               <td align="left" colspan="6">
                                                    <asp:Label CssClass="title_label" ID="lblsports" runat="server" Text="Sports/Co-curricular Achievements"></asp:Label>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td align="left" style="width: 700px; height: 5px" colspan="6">&nbsp;</td>
                                            </tr> 
                                             <tr>
                                                <td align="left" style="width:200px; height: 40px">
                                                    <asp:Label ID="Label12" runat="server" CssClass="s_label" 
                                                        Text="Sports/Co-curricular"></asp:Label>
                                               </td>
                                                 <td align="left" style="width:430px; height: 40px" colspan="4">
                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" 
                                                        Text="Any Other Prizes or Achievements" width="250px"></asp:Label>
                                                     &nbsp;</td>                                                                           
                                            </tr>
                                            <tr>
                                                 <td align="left" style="width:200px; height: 40px">
                                                    <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="1."></asp:Label>
                                                     <asp:TextBox ID="txtsports1" runat="server" CssClass="s_textbox" 
                                                        Width="150px"></asp:TextBox>
                                                  </td>
                                                     <td align="left" style="width:430px; height: 40px" colspan="4">
                                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:TextBox ID="txtareas" runat="server" CssClass="s_textbox" 
                                                        Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                         &nbsp;</td> 
                                                </tr> 
                                                
                                             <tr>
                                                 <td align="left" style="width:200px; height: 40px">
                                                    <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="2."></asp:Label>
                                                    <asp:TextBox ID="txtsports2" runat="server" CssClass="s_textbox" 
                                                        Width="150px"></asp:TextBox>
                                                    </td>
                                                   <td align="left" style="width:430px; height: 40px" colspan="4">
                                               </td> 
                                             </tr>   
                                             <tr>
                                                 <td align="left" style="width:200px; height: 40px">
                                                    <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="3."></asp:Label>
                                                    <asp:TextBox ID="txtsports3" runat="server" CssClass="s_textbox" 
                                                        Width="150px"></asp:TextBox>
                                                  </td>
                                                     <td align="left" style="width:430px; height: 40px" colspan="4">
                                               </td> 
                                             </tr>  
                                            <tr class="view_detail_title_bg" >
                                               <td align="left" colspan="6">
                                                    <asp:Label CssClass="title_label" ID="lbllanguage" runat="server" Text="Language Selections"></asp:Label>
                                                </td>
                                             </tr> 
                                              <tr>
                                                 <td align="left"  >
                                                    <asp:Label ID="Label106" runat="server" CssClass="s_label" 
                                                        Text="Second Language"></asp:Label>
                                                    </td>
                                                    <td align="left" ; colspan="5" >
                                                    <asp:DropDownList ID="ddlsecondlanguage" runat="server" CssClass="s_dropdown" 
                                                            Width="150px" AutoPostBack="True"></asp:DropDownList>
                                                    </td>
                                                </tr>      
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label107" runat="server" CssClass="s_label" 
                                                        Text="Third Language"></asp:Label>
                                                </td>
                                                <td align="left" ; colspan="5">
                                                    <asp:DropDownList ID="ddlthirdlanguage" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="True"></asp:DropDownList>
                                                </td>
                                               
                                            </tr> 
                                             <tr id="trgroup" runat="server">
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label110" runat="server" CssClass="s_label" 
                                                        Text="Subjects"></asp:Label>
                                                </td>
                                                 <td align="left" colspan="5">
                                                     <asp:Panel ID="Panel1" runat="server" BackColor="#F7F7F7" BorderColor="#1874CD" 
                                                         BorderWidth="1px" Height="75px" ScrollBars="Vertical" Width="180px">
                                                         <asp:CheckBoxList ID="chksubjects" runat="server" CssClass="s_label">
                                                         </asp:CheckBoxList>
                                                     </asp:Panel>
                                                 </td>
                                            </tr> 
                                            
                                                <tr class="view_detail_title_bg" >
                                               <td align="left" colspan="6">
                                                    <asp:Label CssClass="title_label" ID="lblhostel" runat="server" Text="Whether the student wants to avail school transport / hostel"></asp:Label>
                                                </td>
                                             </tr> 
                                             <%--<tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label111" runat="server" CssClass="s_label" 
                                                        Text="Hostel"></asp:Label>
                                                </td>
                                                 <td align="left" style="width: 200px; height: 40px">
                                                    <asp:RadioButton ID="RByes1" runat="server" CssClass="s_label" Text="Yes" 
                                                         GroupName="hostel" />
                                                     &nbsp;
                                                        <asp:RadioButton ID="RBno1" runat="server" CssClass="s_label" Text="No" 
                                                         GroupName="hostel" />
                                                    </td>
                                                    <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" 
                                                        Text="Transport"></asp:Label>
                                                </td>
                                                 <td align="left" style="width: 200px; height: 40px">
                                                    <asp:RadioButton ID="RadioButton1" runat="server" CssClass="s_label" Text="Own" 
                                                         GroupName="hostel" />
                                                     &nbsp;
                                                        <asp:RadioButton ID="RadioButton2" runat="server" CssClass="s_label" Text="School" 
                                                         GroupName="hostel" />
                                                    </td>
                                                </tr> --%>
                                                <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label111" runat="server" CssClass="s_label" 
                                                        Text="Hostel"></asp:Label>
                                                </td>
                                                 <td align="left" style="width: 200px; height: 40px">
                                                    <asp:RadioButton ID="RByes1" runat="server" CssClass="s_label" Text="Yes" 
                                                         GroupName="hostel" />
                                                     &nbsp;
                                                        <asp:RadioButton ID="RBno1" runat="server" CssClass="s_label" Text="No" 
                                                         GroupName="hostel" />
                                                    </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                                 <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" 
                                                        Text="Transport"></asp:Label>
                                                </td>
                                                 <td align="left" style="width: 200px; height: 40px">
                                                    <asp:RadioButton ID="RBown" runat="server" CssClass="s_label" Text="Own" 
                                                         GroupName="transport" />
                                                     &nbsp;
                                                        <asp:RadioButton ID="RBschool" runat="server" CssClass="s_label" Text="School" 
                                                         GroupName="transport" />
                                                    </td>
                                                <td style="width:20px">
                                                    &nbsp;</td>
                                             </tr>
                                                  <tr class="view_detail_title_bg" >
                                               <td align="left" colspan="6">
                                                    <asp:Label CssClass="title_label" ID="lblsiblings" runat="server" Text="Details Of Siblings"></asp:Label>
                                                      </td>
                                              </tr>
                                             <tr id="trbrosis" runat="server">
                                                <td align="left" style="width: 300px; height: 40px">
                                                    <asp:Label ID="Label112" runat="server" CssClass="s_label" 
                                                        Text="Whether any of the siblings studying in our school"></asp:Label>
                                                </td>
                                                <td align="left" colspan="5" style="width: 400px; height: 40px">
                                                    <asp:RadioButton ID="RByes0" runat="server" CssClass="s_label" Text="Yes" 
                                                         GroupName="brother/sister" AutoPostBack="True" 
                                                        oncheckedchanged="RByes0_CheckedChanged" />
                                                    &nbsp;
                                                    <asp:RadioButton ID="RBno0" runat="server" CssClass="s_label" Text="No" 
                                                         GroupName="brother/sister" AutoPostBack="True" 
                                                        oncheckedchanged="RBno0_CheckedChanged" Checked="True" />
                                                    &nbsp;<asp:Label ID="lbladminid" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                            </tr>
                                            <tr id="trbrother" runat="server">
                                                <td align="left" style="width: 800px; height: 40px; font-family:Arial; font-size:16px; color: #2DA0ED" colspan="6" valign="top">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                         
                                                        <tr>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:Label ID="Label58" runat="server" CssClass="s_label" 
                                                                    Text="Name of the child"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="Label93" runat="server" CssClass="s_label" 
                                                                    Text="Admission Number"></asp:Label>
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="Label79" runat="server" CssClass="s_label" Text="Class"></asp:Label>
                                                                &nbsp;</td>
                                                            <td align="left" style="height: 40px; width:200px">
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="Label94" runat="server" CssClass="s_label" Text="Remarks"></asp:Label>
                                                                &nbsp;</td>
                                                            <td style="width:60px"></td>
                                                        </tr>                                            
                                                        
                                                        <tr>
                                                            <td align="center" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtchild" runat="server" CssClass="s_textbox" Width="140px"></asp:TextBox></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                 &nbsp;&nbsp;
                                                                 <asp:TextBox ID="txtadmn" runat="server" CssClass="s_textbox" Width="140px"></asp:TextBox>
                                                                 &nbsp;</td>
                                                            <td align="center" style="width: 200px; height: 40px">
                                                                 <asp:TextBox ID="txtclass" runat="server" CssClass="s_textbox" Width="140px"></asp:TextBox>
                                                            </td>
                                                            <td align="center" style="width: 200px; height: 40px">
                                                                &nbsp;&nbsp;
                                                                <asp:TextBox ID="txtremarks" runat="server" CssClass="s_textbox" Width="140px"> 
                                                                    </asp:TextBox>
                                                                &nbsp;</td>
                                                            <td style="width:60px">
                                                                <asp:Button ID="btnadd" runat="server" CssClass="s_button" Text="Add" 
                                                                    onclick="btnadd_Click" Width="32px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="height: 40px; width:700px" colspan="5">
                                                            <asp:DataGrid ID="dgregistration" runat="server" AutoGenerateColumns="False" Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" ondeletecommand="dgregistration_deletecommand" oneditcommand="dgregistration_editcommand">
                                                            <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                            <ItemStyle CssClass="s_datagrid_item" />
                                                            <Columns>
                                                            <asp:BoundColumn DataField="intid"  Visible="false">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Name of the child" DataField="strnameofthechild">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Admission No" DataField="stradmission">
                                                            </asp:BoundColumn>                                                
                                                            <asp:BoundColumn HeaderText="Class/Section" DataField="strclass">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Remarks" DataField="strremarks">
                                                            </asp:BoundColumn>
                                                                <asp:ButtonColumn CommandName="edit" HeaderText="Edit" 
                                                                    Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn CommandName="delete" HeaderText="Delete" 
                                                                    Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                </asp:ButtonColumn>
                                                            </Columns>
                                                            <HeaderStyle Font-Size="12px" CssClass="s_datagrid_header"/>
                                                            </asp:DataGrid>                                                    
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" style="width: 700px; height: 40px">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="s_button" Text="Save" 
                                                        onclick="btnsave_Click" Width="60px" />
                                                        <asp:Button ID="btnclear" runat="server" CssClass="s_button" Text="Clear" 
                                                        onclick="btnclear_Click" Width="60px" />
                                                </td>
                                            </tr>
                                        </table>

                                    </td>
                                </tr>
                                
                              </table>
                           </td>
                       </tr>
                       
                   </table>
               </td>                         
            </tr>                           
          <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top">
                <uc4:footer ID="footer1" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

























                               




                                                                                    
                                   