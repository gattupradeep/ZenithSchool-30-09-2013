<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vehicle.aspx.cs" Inherits="transport_vehicle" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/admin_transport.ascx" tagname="admin_transport" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" media="screen" rel="stylesheet" type="text/css" />
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
            $("#txtfcissuedate").datepicker({ dateFormat: 'yy/mm/dd',
                changeMonth: true,
                constrainDates: true,
                changeYear: true
            });
        }
    });

    $(function() {
    var dates = $("#txtfcissuedate").datepicker({
            constrainDates: true,
            dateFormat: 'yy/mm/dd',
            changeMonth: true,
            changeYear: true
        });
    });
    $(document).ready(function() {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            $("#txtfcenddate").datepicker({ dateFormat: 'yy/mm/dd',
                changeMonth: true,
                constrainDates: true,
                changeYear: true
            });
        }
    });
    $(function() {
    var dates = $("#txtfcenddate").datepicker({
            constrainDates: true,
            dateFormat: 'yy/mm/dd',
            changeMonth: true,
            changeYear: true
        });
    });
    $(document).ready(function() {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            $("#txtinsuranceissuedate").datepicker({ dateFormat: 'yy/mm/dd',
                changeMonth: true,
                constrainDates: true,
                changeYear: true
            });
        }
    });
    $(function() {
    var dates = $("#txtinsuranceissuedate").datepicker({
            constrainDates: true,
            dateFormat: 'yy/mm/dd',
            changeMonth: true,
            changeYear: true
        });
    });
    $(document).ready(function() {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            $("#txtinsuranceenddate").datepicker({ dateFormat: 'yy/mm/dd',
                changeMonth: true,
                constrainDates: true,
                changeYear: true
            });
        }
    });
    $(function() {
    var dates = $("#txtinsuranceenddate").datepicker({
            constrainDates: true,
            dateFormat: 'yy/mm/dd',
            changeMonth: true,
            changeYear: true
        });
    }); 
     </script>  
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
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
                                        <uc1:admin_transport ID="admin_transport1" runat="server" />
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
                        <td style="width: 1%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/113.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Add / Edit Vehicle Master</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                <ProgressTemplate>
                                                    <div id="progressBackgroundFilter"></div>
                                                        <div id="processMessage">
                                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                                        </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                         <asp:UpdatePanel ID="updatepanal" runat="server" >
                                            <ContentTemplate>
                                             <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="6" class="title_label">Add / Edit Vehicle Master</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <table cellpadding="7" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Owner:  "></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                               <asp:DropDownList ID="ddlowner" runat="server" CssClass="s_dropdown" 
                                                                 Width="150px">
                                                                </asp:DropDownList>  
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Board Color:  "></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">                                                   
                                                                    <asp:TextBox ID="txtboardcolor" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox></td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" 
                                                                    Text="Registeration Number:"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                    <asp:TextBox ID="txtregno" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                    &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Rate Per KM:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                               <asp:TextBox ID="txtrate" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="rg1" runat="server" ControlToValidate="txtrate" ErrorMessage="Enter numeric only" 
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Engine Number:"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtengineno" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox> 
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px"> 
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="FC Number:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">                                                                                                                                                                                                      
                                                                <asp:TextBox ID="txtfcno" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td align="left">
                                                                    &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" 
                                                                    Text="Chassis Number: "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtchassisno" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="FC Issue Date:"></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtfcissuedate" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                            <%--<asp:DropDownList ID="ddlday1" runat="server" CssClass="s_dropdown">
                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                 <asp:ListItem Value="3">3</asp:ListItem>
                                                                 <asp:ListItem Value="4">4</asp:ListItem>
                                                                 <asp:ListItem Value="5">5</asp:ListItem>
                                                                 <asp:ListItem Value="6">6</asp:ListItem>
                                                                 <asp:ListItem Value="7">7</asp:ListItem>
                                                                 <asp:ListItem Value="8">8</asp:ListItem>
                                                                 <asp:ListItem Value="9">9</asp:ListItem>
                                                                 <asp:ListItem Value="10">10</asp:ListItem>
                                                                 <asp:ListItem Value="11">11</asp:ListItem>
                                                                 <asp:ListItem Value="12">12</asp:ListItem>
                                                                 <asp:ListItem Value="13">13</asp:ListItem>
                                                                 <asp:ListItem Value="14">14</asp:ListItem>
                                                                 <asp:ListItem Value="15">15</asp:ListItem>
                                                                 <asp:ListItem Value="16">16</asp:ListItem>
                                                                 <asp:ListItem Value="17">17</asp:ListItem>
                                                                 <asp:ListItem Value="18">18</asp:ListItem>
                                                                 <asp:ListItem Value="19">19</asp:ListItem>
                                                                 <asp:ListItem Value="20">20</asp:ListItem>
                                                                 <asp:ListItem Value="21">21</asp:ListItem>
                                                                 <asp:ListItem Value="22">22</asp:ListItem>
                                                                 <asp:ListItem Value="23">23</asp:ListItem>
                                                                 <asp:ListItem Value="24">24</asp:ListItem>
                                                                 <asp:ListItem Value="25">25</asp:ListItem>
                                                                 <asp:ListItem Value="26">26</asp:ListItem>
                                                                 <asp:ListItem Value="27">27</asp:ListItem>
                                                                 <asp:ListItem Value="28">28</asp:ListItem>
                                                                 <asp:ListItem Value="29">29</asp:ListItem>
                                                                 <asp:ListItem Value="30">30</asp:ListItem>
                                                                 <asp:ListItem Value="31">31</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlmonth1" runat="server" CssClass="s_dropdown">
                                                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                                <asp:ListItem Value="6">Jun</asp:ListItem>
                                                                <asp:ListItem Value="7">Jul</asp:ListItem>
                                                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                <asp:ListItem Value="12">Nov</asp:ListItem>
                                                                <asp:ListItem Value="13">Dec</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlyear1" runat="server" CssClass="s_dropdown">
                                                                <asp:ListItem>2010</asp:ListItem>
                                                                <asp:ListItem>2011</asp:ListItem>
                                                                <asp:ListItem>2012</asp:ListItem>
                                                                <asp:ListItem>2013</asp:ListItem>
                                                                <asp:ListItem>2014</asp:ListItem>
                                                                <asp:ListItem>2015</asp:ListItem>
                                                                <asp:ListItem>2016</asp:ListItem>
                                                                <asp:ListItem>2017</asp:ListItem>
                                                                <asp:ListItem>2018</asp:ListItem>
                                                                <asp:ListItem>2019</asp:ListItem>
                                                                <asp:ListItem>2020</asp:ListItem>
                                                                <asp:ListItem>2021</asp:ListItem>
                                                                <asp:ListItem>2022</asp:ListItem>
                                                                <asp:ListItem>2023</asp:ListItem>
                                                                <asp:ListItem>2024</asp:ListItem>
                                                                <asp:ListItem>2025</asp:ListItem>
                                                                </asp:DropDownList>--%>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Brand:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                               
                                                                <asp:TextBox ID="txtbrand" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                               
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="FC End Date:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtfcenddate" runat="server" CssClass="s_textbox" ></asp:TextBox>
                                                                <%--<asp:DropDownList ID="ddlday2" runat="server" CssClass="s_dropdown">
                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                                    <asp:ListItem Value="26">26</asp:ListItem>
                                                                    <asp:ListItem Value="27">27</asp:ListItem>
                                                                    <asp:ListItem Value="28">28</asp:ListItem>
                                                                    <asp:ListItem Value="29">29</asp:ListItem>
                                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                                    <asp:ListItem Value="31">31</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlmonth2" runat="server" CssClass="s_dropdown">
                                                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                                    <asp:ListItem Value="6">Jun</asp:ListItem>
                                                                    <asp:ListItem Value="7">Jul</asp:ListItem>
                                                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                    <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                    <asp:ListItem Value="12">Nov</asp:ListItem>
                                                                    <asp:ListItem Value="13">Dec</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlyear2" runat="server" CssClass="s_dropdown">
                                                                    <asp:ListItem>2010</asp:ListItem>
                                                                    <asp:ListItem>2011</asp:ListItem>
                                                                    <asp:ListItem>2012</asp:ListItem>
                                                                    <asp:ListItem>2013</asp:ListItem>
                                                                    <asp:ListItem>2014</asp:ListItem>
                                                                    <asp:ListItem>2015</asp:ListItem>
                                                                    <asp:ListItem>2016</asp:ListItem>
                                                                    <asp:ListItem>2017</asp:ListItem>
                                                                    <asp:ListItem>2018</asp:ListItem>
                                                                    <asp:ListItem>2019</asp:ListItem>
                                                                    <asp:ListItem>2020</asp:ListItem>
                                                                    <asp:ListItem>2021</asp:ListItem>
                                                                    <asp:ListItem>2022</asp:ListItem>
                                                                    <asp:ListItem>2023</asp:ListItem>
                                                                    <asp:ListItem>2024</asp:ListItem>
                                                                    <asp:ListItem>2025</asp:ListItem>
                                                                </asp:DropDownList>--%>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Model: "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">                                                                                             
                                                               
                                                                <asp:TextBox ID="txtmodel" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                               
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                               <asp:Label ID="Label24" runat="server" CssClass="s_label" Text="Insurance Number: "></asp:Label> </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtinsuranceno" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td align="left">
                                                                     <%--<asp:RegularExpressionValidator id="RegularExpressionValidator4" 
                                                                         ControlToValidate="txtmobile"
                                                                         ValidationExpression="\d{10}"
                                                                         Display="Dynamic"
                                                                         EnableClientScript="false" CssClass="style10"
                                                                         ErrorMessage="Mobile noumer must be 10 numeric digits"
                                                                         runat="server"/>--%>
                                                                     </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Type Of Vehicle:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                               
                                                               <asp:DropDownList ID="ddlvehicletype" runat="server" CssClass="s_dropdown" 
                                                                 Width="150px">
                                                                </asp:DropDownList>  
                                                               
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                             <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Insurance Issue Date:"></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtinsuranceissuedate" runat="server" CssClass="s_textbox" ></asp:TextBox>
                                                                <%--<asp:DropDownList ID="ddlday3" runat="server" CssClass="s_dropdown">
                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                                    <asp:ListItem Value="26">26</asp:ListItem>
                                                                    <asp:ListItem Value="27">27</asp:ListItem>
                                                                    <asp:ListItem Value="28">28</asp:ListItem>
                                                                    <asp:ListItem Value="29">29</asp:ListItem>
                                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                                    <asp:ListItem Value="31">31</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlmonth3" runat="server" CssClass="s_dropdown">
                                                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                                    <asp:ListItem Value="6">Jun</asp:ListItem>
                                                                    <asp:ListItem Value="7">Jul</asp:ListItem>
                                                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                    <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                    <asp:ListItem Value="12">Nov</asp:ListItem>
                                                                    <asp:ListItem Value="13">Dec</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlyear3" runat="server" CssClass="s_dropdown">
                                                                    <asp:ListItem>2010</asp:ListItem>
                                                                    <asp:ListItem>2011</asp:ListItem>
                                                                    <asp:ListItem>2012</asp:ListItem>
                                                                    <asp:ListItem>2013</asp:ListItem>
                                                                    <asp:ListItem>2014</asp:ListItem>
                                                                    <asp:ListItem>2015</asp:ListItem>
                                                                    <asp:ListItem>2016</asp:ListItem>
                                                                    <asp:ListItem>2017</asp:ListItem>
                                                                    <asp:ListItem>2018</asp:ListItem>
                                                                    <asp:ListItem>2019</asp:ListItem>
                                                                    <asp:ListItem>2020</asp:ListItem>
                                                                    <asp:ListItem>2021</asp:ListItem>
                                                                    <asp:ListItem>2022</asp:ListItem>
                                                                    <asp:ListItem>2023</asp:ListItem>
                                                                    <asp:ListItem>2024</asp:ListItem>
                                                                    <asp:ListItem>2025</asp:ListItem>
                                                                </asp:DropDownList>--%>
                                                            
                                                            <td align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Fuel:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtfuel" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                    <%--<asp:RegularExpressionValidator id="RegularExpressionValidator5" ControlToValidate="txtsal" runat="server"
                                                                    ValidationExpression="^[+-]?(?:\d+\.?\d*|\d*\.?\d+)[\r\n]*$" CssClass="style10" Display="Dynamic" ErrorMessage="*"></asp:RegularExpressionValidator>--%>
                                                                    
                                                                    </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Insurance End Date:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtinsuranceenddate" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                                <%--<asp:DropDownList ID="ddlday4" runat="server" CssClass="s_dropdown">
                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                                    <asp:ListItem Value="26">26</asp:ListItem>
                                                                    <asp:ListItem Value="27">27</asp:ListItem>
                                                                    <asp:ListItem Value="28">28</asp:ListItem>
                                                                    <asp:ListItem Value="29">29</asp:ListItem>
                                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                                    <asp:ListItem Value="31">31</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlmonth4" runat="server" CssClass="s_dropdown">
                                                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                                    <asp:ListItem Value="6">Jun</asp:ListItem>
                                                                    <asp:ListItem Value="7">Jul</asp:ListItem>
                                                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                    <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                    <asp:ListItem Value="12">Nov</asp:ListItem>
                                                                    <asp:ListItem Value="13">Dec</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlyear4" runat="server" CssClass="s_dropdown">
                                                                    <asp:ListItem>2010</asp:ListItem>
                                                                    <asp:ListItem>2011</asp:ListItem>
                                                                    <asp:ListItem>2012</asp:ListItem>
                                                                    <asp:ListItem>2013</asp:ListItem>
                                                                    <asp:ListItem>2014</asp:ListItem>
                                                                    <asp:ListItem>2015</asp:ListItem>
                                                                    <asp:ListItem>2016</asp:ListItem>
                                                                    <asp:ListItem>2017</asp:ListItem>
                                                                    <asp:ListItem>2018</asp:ListItem>
                                                                    <asp:ListItem>2019</asp:ListItem>
                                                                    <asp:ListItem>2020</asp:ListItem>
                                                                    <asp:ListItem>2021</asp:ListItem>
                                                                    <asp:ListItem>2022</asp:ListItem>
                                                                    <asp:ListItem>2023</asp:ListItem>
                                                                    <asp:ListItem>2024</asp:ListItem>
                                                                    <asp:ListItem>2025</asp:ListItem>
                                                                </asp:DropDownList>--%>
                                                               </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                            <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Vehicle Color:  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                              <asp:TextBox ID="txtvehiclecolor" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                             <asp:Label ID="Label20" runat="server" CssClass="s_label" Text="Free Services:  "></asp:Label></td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtfreeservices" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="rg0" runat="server" ControlToValidate="txtfreeservices" ErrorMessage="Enter numeric only" 
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                               </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                            <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="Number Of Seats:  "></asp:Label>
                                                                </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtseats" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="rg" runat="server" ControlToValidate="txtseats" ErrorMessage="Enter numeric only" 
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left">
                                                                <asp:Label ID="Label25" runat="server" CssClass="s_label" Text="Vehicle Number:"></asp:Label>
                                                                </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtvehicleno" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                               </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="6" style="height:10px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                            <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="Luxury Info:"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                            <asp:TextBox ID="txtluxury" runat="server" CssClass="s_textbox" TextMode="MultiLine" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="6" style="height:10px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                            <asp:Label ID="Label19" runat="server" CssClass="s_label" Text="Permit Info:"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                  
                                                            <asp:TextBox ID="txtpermit" runat="server" CssClass="s_textbox" 
                                                                    TextMode="MultiLine" Width="180px"></asp:TextBox>
                                                                  
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                   &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                   &nbsp;</td>
                                                            <td align="left">
                                                                   &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="6" style="height: 40px">
                                                                <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" Width="60px" onclick="btnSave_Click"/>
                                                                &nbsp;
                                                                <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" Width="60px" onclick="btnClear_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" style="height: 40px">
                                                    <asp:DataGrid ID="dgvehicle" runat="server" AutoGenerateColumns="False"
                                                    Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                         oneditcommand="dgvehicle_EditCommand">
                                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strownername" HeaderText="Owner" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strvehicleno" HeaderText="VehicleNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strengineno" HeaderText="EngineNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>                                                                                            
                                                            <asp:BoundColumn DataField="strchassisno" HeaderText="ChasssisNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strbrand" HeaderText="Brand" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strmodel" HeaderText="Model" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                 <HeaderStyle HorizontalAlign="Center" />
                                                                 <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strvehiclecolor" HeaderText="Vehicle color" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                 <HeaderStyle HorizontalAlign="Center" />
                                                                 <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;" HeaderStyle-HorizontalAlign="Center">                                                                                            

                                                                <HeaderStyle HorizontalAlign="Center" />

                                                            </asp:ButtonColumn>
                                                            <asp:TemplateColumn HeaderText="Delete">
                                                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btndelete" runat="server" 
                                                                        ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                                    OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                                        onclick="btndelete_Click"  />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">                                                                                                                
                                                            </asp:ButtonColumn>--%>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                        </asp:DataGrid>
                                                </td>
                                            </tr>
                                        </table>
                                            </ContentTemplate>
                                         </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; " align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>