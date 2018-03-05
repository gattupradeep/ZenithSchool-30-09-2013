<%@ Page Language="C#" AutoEventWireup="true" CodeFile="examschedule.aspx.cs" Inherits="school_examschedule"  %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/admin_exam.ascx" tagname="admin_exam" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="footer" TagPrefix="uc6" %>
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
                 $('#txtstarttime').timepicker();
                 $('#txtendtime').timepicker();
             }
         });
         $(document).ready(function() {
             $('#txtstarttime').timepicker();
         });
         $(document).ready(function() {
             $('#txtendtime').timepicker();
         });        
    </script> 
    <script language="javascript" type="text/javascript">
     function openNewWin1(url) {
         var x = window.open(url, 'mynewwin', 'width=800,,toolbar=1,scrollbars=yes');
         x.focus();
     } 
    </script>
    <script type="text/javascript">
        function popup(url) {
            var width = 500;
            var height = 400;
            var left = (screen.width - width) / 2;
            var top = (screen.height - height) / 2;
            var params = 'width=' + width + ', height=' + height;
            params += ', top=' + top + ', left=' + left;
            params += ', directories=no';
            params += ', location=no';
            params += ', menubar=no';
            params += ', resizable=no';
            params += ', scrollbars=no';
            params += ', status=no';
            params += ', toolbar=no';
            newwin = window.open(url, 'windowname5', params);
            if (window.focus) { newwin.focus() }
            return false;
        }
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
                                        <uc1:admin_exam ID="admin_exam1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/36.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left"> Assign Exam Schedule</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 20px" valign="top" align="left">
                                      <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                            <ProgressTemplate>
                                                <div id="progressBackgroundFilter"></div>
                                                    <div id="processMessage">
                                                        <img alt="Loading" src="../media/images/Processing.gif" />
                                                    </div>
                                            </ProgressTemplate>
                                         </asp:UpdateProgress>--%>
                                        <asp:UpdatePanel ID="updatepanal" runat="server" >
                                                <ContentTemplate>
                                            <table cellpadding="0" cellspacing="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" style=" height: 40px; padding-left:10px" class="title_label">
                                                    Exam Details</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 175px; height: 30px; padding-left:10px">
                                                    <asp:Label ID="Label12" runat="server" CssClass="s_label" 
                                                        Text="Class &amp; Section"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 30px">
                                                    <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_dropdown" 
                                                        Width="180px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlclass_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 175px; height: 30px">
                                                    <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Exam Type"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 30px">
                                                    <asp:DropDownList ID="ddlexamtype" runat="server" CssClass="s_dropdown" 
                                                        Width="180px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlexamtype_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 175px; height: 30px; padding-left:10px">
                                                    <asp:Label ID="Label19" runat="server" CssClass="s_label" Text="Subject Name"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 30px">
                                                    <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_dropdown" 
                                                        Width="180px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlsubject_SelectedIndexChanged1">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 175px; height: 30px">
                                                     <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Exam Paper"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 30px">
                                                    <asp:DropDownList ID="ddlexampaper" runat="server" CssClass="s_dropdown" 
                                                        Width="180px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlexampaper_SelectedIndexChanged" >
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 175px; height: 30px; padding-left:10px">
                                                    <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Exam Date"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 30px">
                                                    <asp:DropDownList ID="ddlday" runat="server" CssClass="s_dropdown" Width="50px">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlmonth" runat="server" CssClass="s_dropdown" Width="65px">
                                                        <asp:ListItem Value="01">Jan</asp:ListItem>
                                                        <asp:ListItem Value="02">Feb</asp:ListItem>
                                                        <asp:ListItem Value="03">Mar</asp:ListItem>
                                                        <asp:ListItem Value="04">Apr</asp:ListItem>
                                                        <asp:ListItem Value="05">May</asp:ListItem>
                                                        <asp:ListItem Value="06">June</asp:ListItem>
                                                        <asp:ListItem Value="07">July</asp:ListItem>
                                                        <asp:ListItem Value="08">Aug</asp:ListItem>
                                                        <asp:ListItem Value="09">Sep</asp:ListItem>
                                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlyear" runat="server" CssClass="s_dropdown" 
                                                        Width="63px" >
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lbldate" runat="server" CssClass="s_label"></asp:Label>
                                                                </td>
                                                <td style="width: 175px; height: 30px">
                                                   <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Exam Time"></asp:Label>
                                                            </td>
                                                <td style="width: 200px; height: 30px">
                                                    <asp:Label ID="lblfrom" runat="server" Text="From" CssClass="s_label"></asp:Label>
                                                    <asp:TextBox ID="txtstarttime" runat="server" CssClass="s_textbox" Width="50px"></asp:TextBox>
                                                    <asp:Label ID="lblfromtime" runat="server" CssClass="s_label"></asp:Label>
                                                    <asp:Label ID="Label5" runat="server" Text="To" CssClass="s_label"></asp:Label>
                                                    <asp:TextBox ID="txtendtime" runat="server" CssClass="s_textbox" Width="50px">
                                                    </asp:TextBox><asp:Label ID="lbltotime" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 175px; height: 30px; padding-left:10px">
                                                    <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="Invigilator"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 30px">
                                                    <asp:DropDownList ID="ddlinvegilator1" runat="server" CssClass="s_dropdown" Width="180px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 175px; height: 30px">
                                                    <asp:Label ID="lblid" runat="server" CssClass="s_label" Visible="false">0</asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 30px">
                                                    &nbsp;</td>
                                                
                                            </tr>
                                            <tr>
                                               
                                                <td align="center" colspan="4" style="width: 750px; height: 40px">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="s_button" 
                                                        onclick="btnsave_Click" Text="Update" Visible="False" Width="60px" />
                                                    <asp:Button ID="Button1" runat="server" CssClass="s_button" 
                                                        onclick="Button1_Click" Text="Set Portion" />
                                                    <asp:Button ID="Button4" runat="server" CssClass="s_button" 
                                                        onclick="Button4_Click" Text="Hide" />
                                                    <asp:Button ID="Button2" runat="server" CssClass="s_button" 
                                                        onclick="Button2_Click" Text="Done" />
                                                    <%--<asp:Button ID="btnsetseat" runat="server" CssClass="s_button" 
                                                        onclick="btnsetseat_Click" Text="Set Seating" />--%>
                                                </td>
                                            </tr>
                                            
                                                        <tr ID="trsetseating" runat="server" visible="false">
                                                            <td align="left" colspan="4" style="width: 750px; height: 40px">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="750">
                                                                    <tr class="view_detail_title_bg">
                                                                        <td class="title_label" colspan="4" 
                                                                            style="width: 750px; height: 40px; padding-left:10px">
                                                                            Set Seating Arrangements
                                                                        </td>
                                                                    </tr>
                                                                    <tr ID="trrollno" runat="server">
                                                                        <td style="width: 175px; height: 30px; padding-left:10px">
                                                                            <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Roll No"></asp:Label>
                                                                        </td>
                                                                        <td align="left" colspan="3" style="width: 575px">
                                                                            <asp:Panel ID="pnl1" runat="server" ScrollBars="Both" Width="560px">
                                                                                <asp:DataList ID="dlrollno" runat="server" 
                                                                                    onitemdatabound="dlrollno_ItemDataBound" RepeatDirection="Horizontal" 
                                                                                    Width="540px">
                                                                                    <ItemTemplate>
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="150">
                                                                                            <tr>
                                                                                                <td style="width: 150px; height: 30px">
                                                                                                    <asp:CheckBox ID="chksellectall" runat="server" AutoPostBack="True" 
                                                                                                        oncheckedchanged="chksellectall_CheckedChanged" Text="Select All" />
                                                                                                    <asp:Label ID="lblrid" runat="server" 
                                                                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ct")%>' Visible="false"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 150px; height: 120px" valign="top">
                                                                                                    <asp:CheckBoxList ID="chkrollno" runat="server" RepeatDirection="Vertical">
                                                                                                    </asp:CheckBoxList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:DataList>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr ID="trrollnoadd" runat="server">
                                                                        <td style="width: 175px; height: 30px; padding-left:10px">
                                                                            &nbsp;</td>
                                                                        <td style="width: 200px; height: 30px">
                                                                            <asp:Button ID="btnaddtoroom" runat="server" CssClass="s_button" 
                                                                                onclick="btnaddtoroom_Click" Text="Add" />
                                                                        </td>
                                                                        <td style="width: 175px; height: 30px">
                                                                            &nbsp;</td>
                                                                        <td style="width: 200px; height: 30px">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 175px; height: 30px; padding-left:10px">
                                                                            <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Room Type"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 30px">
                                                                            <asp:DropDownList ID="ddlroomtype" runat="server" AutoPostBack="True" 
                                                                                CssClass="s_dropdown" onselectedindexchanged="ddlroomtype_SelectedIndexChanged" 
                                                                                Width="180px">
                                                                                <asp:ListItem Text="-Select-" Value="Select"></asp:ListItem>
                                                                                <asp:ListItem Text="Class" Value="Classes"></asp:ListItem>
                                                                                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="width: 175px; height: 30px">
                                                                            <asp:Label ID="Label3" runat="server" CssClass="s_label" Text=" Class "></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 30px">
                                                                            <asp:DropDownList ID="ddlclass1" runat="server" AutoPostBack="True" 
                                                                                CssClass="s_dropdown" onselectedindexchanged="ddlclass1_SelectedIndexChanged" 
                                                                                Width="180px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr ID="traddednos" runat="server">
                                                                        <td style="width: 175px; height: 30px; padding-left:10px">
                                                                            <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Roll No"></asp:Label>
                                                                        </td>
                                                                        <td align="left" colspan="3" style="width: 575px; height: 30px">
                                                                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="560px">
                                                                                <asp:DataList ID="dlrollno1" runat="server" 
                                                                                    onitemdatabound="dlrollno1_ItemDataBound" RepeatDirection="Horizontal" 
                                                                                    Width="540px">
                                                                                    <ItemStyle VerticalAlign="Top" />
                                                                                    <ItemTemplate>
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="150">
                                                                                            <tr>
                                                                                                <td style="width: 150px; height: 30px">
                                                                                                    <asp:CheckBox ID="chksellectall1" runat="server" AutoPostBack="True" 
                                                                                                        oncheckedchanged="chksellectall1_CheckedChanged" Text="Select All" />
                                                                                                    <asp:Label ID="lblrid" runat="server" 
                                                                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ct")%>' Visible="true"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 150px; height: 120px">
                                                                                                    <asp:CheckBoxList ID="chkrollno" runat="server" RepeatDirection="Vertical">
                                                                                                    </asp:CheckBoxList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:DataList>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 175px; height: 30px; padding-left:10px">
                                                                            &nbsp;</td>
                                                                        <td style="width: 200px; height: 30px">
                                                                            <asp:Button ID="btnremove" runat="server" CssClass="s_button" 
                                                                                onclick="btnremove_Click" Text="Remove" />
                                                                        </td>
                                                                        <td style="width: 175px; height: 30px">
                                                                            &nbsp;</td>
                                                                        <td style="width: 200px; height: 30px">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 175px; height: 30px; padding-left:10px">
                                                                            <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Room  Capacity "></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 30px">
                                                                            <asp:Label ID="lblroomcapacity" runat="server" CssClass="s_label"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 175px; height: 30px">
                                                                            <asp:Label ID="Label20" runat="server" CssClass="s_label" 
                                                                                Text="Remaining Capacity"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 30px">
                                                                            <asp:Label ID="lblremaining" runat="server" CssClass="s_label"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr ID="trsetportion" runat="server" visible="false">
                                                            <td align="left" colspan="4" style="width:100%; height: 40px">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr class="view_detail_title_bg">
                                                                        <td class="title_label" style="height: 40px">
                                                                            Set Portion</td>
                                                                    </tr>
                                                                    <tr style="background: silver">
                                                                        <td>
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="350px">
                                                                                <tr>
                                                                                    <td style="height: 40px;color:red;">
                                                                                        <div style="height: 10px; width: 10px; background: red; float: left">
                                                                                            &nbsp;</div>
                                                                                        &nbsp;Not Yet Started</td>
                                                                                    <td style="height: 40px;color:#C1590F;">
                                                                                        <div style="height: 10px; width: 10px; background: #C1590F; float: left">
                                                                                            &nbsp;</div>
                                                                                        &nbsp;Started</td>
                                                                                    <td style="height: 40px;color:Green;">
                                                                                        <div style="height: 10px; width: 10px; background: Green; float: left">
                                                                                            &nbsp;</div>
                                                                                        &nbsp;Completed</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style=" height: 40px">
                                                                            <asp:DataGrid ID="dglesson1" runat="server" AutoGenerateColumns="False" 
                                                                                GridLines="None" onitemdatabound="dglesson1_ItemDataBound" ShowHeader="false" 
                                                                                Width="100%">
                                                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                                <ItemStyle CssClass="s_datagrid_item" />
                                                                                <Columns>
                                                                                    <asp:BoundColumn DataField="strunitno" HeaderText="Unit No" Visible="False">
                                                                                    </asp:BoundColumn>
                                                                                    <asp:TemplateColumn>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkunitno" runat="server" AutoPostBack="True" 
                                                                                                oncheckedchanged="chkunitno_CheckedChanged" 
                                                                                                Text='<%# DataBinder.Eval(Container.DataItem, "strunitno")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBoxList ID="chklesson" runat="server" RepeatColumns="3" 
                                                                                                RepeatDirection="Horizontal">
                                                                                            </asp:CheckBoxList>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                </Columns>
                                                                            </asp:DataGrid>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" style=" height: 40px">
                                                                            <asp:Button ID="btnaddlesson" runat="server" CssClass="s_button" 
                                                                                onclick="btnaddlesson_Click" Text="Add Lesson" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="4">
                                                                <asp:DataGrid ID="dgexamschedule" runat="server" AutoGenerateColumns="False" 
                                                                    CellPadding="4" GridLines="None" Width="100%">
                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                    <ItemStyle CssClass="s_datagrid_item" />
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strsubjectname" 
                                                                            HeaderStyle-HorizontalAlign="Center" HeaderText="Subject" 
                                                                            ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strexampaper" HeaderStyle-HorizontalAlign="Center" 
                                                                            HeaderText="Paper" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strexamdate" HeaderStyle-HorizontalAlign="Center" 
                                                                            HeaderText="Date" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="time" HeaderStyle-HorizontalAlign="Center" 
                                                                            HeaderText="Time" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="name" HeaderStyle-HorizontalAlign="Center" 
                                                                            HeaderText="Invigilator" ItemStyle-HorizontalAlign="Center">
                                                                        </asp:BoundColumn>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                                                </asp:DataGrid>
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
                </table>
            </td>
        </tr>
        <tr>
            <td class="break"></td>
        </tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:footer ID="footer" runat="server" />                
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
