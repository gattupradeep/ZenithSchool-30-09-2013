<%@ Page Language="C#" AutoEventWireup="true" CodeFile="smsexamdetails.aspx.cs" Inherits="communication_smsexamdetails" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/admin_attendance.ascx" tagname="admin_attendance" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/communication_admin.ascx" tagname="communication_admin" tagprefix="uc5" %>
<%@ Register Src="../usercontro/smscategorymenu.ascx" TagName="smsmenu" TagPrefix="ucsmsmenu" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="admin_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Communication</title>
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
                $('#txtDelaydate').datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true });
            }
        });
        $(function() {
        var dates = $("#txtDelaydate").datepicker({
                constrainDates: true,
                minDate: 0,
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
        });
	</script>
    <script type="text/javascript">
        $(document).ready(function() {
        $('#Checkall').click(
             function() {
                $("INPUT[type='checkbox']").attr('checked', $('#Checkall').is(':checked'));
             });
         });
         $(document).ready(function() {
         $('#chkAll').click(
             function() {
                $("INPUT[type='checkbox']").attr('checked', $('#chkAll').is(':checked'));
             });
         });
     </script>
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
                                        <uc5:communication_admin ID="communication_admin1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../media/images/smsicon.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Send SMS</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="center">
                                        <%-- <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                            <ProgressTemplate>
                                                <div id="progressBackgroundFilter"></div>
                                                    <div id="processMessage">
                                                        <img alt="Loading" src="../media/images/Processing.gif" />
                                                    </div>
                                            </ProgressTemplate>
                                         </asp:UpdateProgress>
                                         <asp:UpdatePanel ID="updatepanal" runat="server" >
                                                <ContentTemplate>--%>
                                                    <table cellpadding="0" cellspacing="0" border="0" width="98%">
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="3" border="0" width="61%" class="top_curve">
                                                        <tr>
                                                            <td colspan="2" valign="top" align="center">
                                                                <ucsmsmenu:smsmenu ID="ucsmsmenu" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" class="sms_template_lable" align="center">
                                                                <asp:Label ID="lbltitle" runat="server" CssClass="sms_header" Text="SMS for Exam Schedule"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" class="sms_template_lable">
                                                                <asp:Label ID="lblsingstd" runat="server" Text="Standard & Sec" CssClass="sms_label"></asp:Label>
                                                            </td>   
                                                            <td>
                                                                <asp:DropDownList ID="ddlstandardsingle" runat="server" CssClass="sms_label" 
                                                                    Width="150px" onselectedindexchanged="ddlstandardsingle_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr >
                                                            <td valign="top" class="sms_template_lable">
                                                                <asp:Label ID="lblexamtype" runat="server" Text="Exam Type" CssClass="sms_label"></asp:Label>
                                                            </td>   
                                                            <td>
                                                                <asp:DropDownList ID="ddlexamtype" runat="server" CssClass="sms_label" Width="150px" 
                                                                    onselectedindexchanged="ddlexamtype_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" class="sms_template_lable">
                                                                <asp:Label ID="lblmessagetype" runat="server" Text="Message Type" CssClass="sms_label"></asp:Label>
                                                            </td>   
                                                            <td>
                                                                <asp:RadioButton ID="rdnewmsg" runat="server" GroupName="rdmsgtype" Text="New" 
                                                                    CssClass="sms_label" Checked="true" oncheckedchanged="rdnewmsg_CheckedChanged" AutoPostBack="true" />
                                                                <asp:RadioButton ID="rdPremsg" runat="server" GroupName="rdmsgtype" 
                                                                    Text="Pre defined" CssClass="sms_label" 
                                                                    oncheckedchanged="rdPremsg_CheckedChanged" AutoPostBack="true" />
                                                            </td>
                                                        </tr>
                                                        <tr id="trpredefined" runat="server" visible="false">
                                                            <td valign="top" class="sms_template_lable">
                                                                <asp:Label ID="lblpremsg" runat="server" Text="SMS Header" CssClass="sms_label"></asp:Label>
                                                            </td>   
                                                            <td>
                                                            <asp:DropDownList ID="ddlpredefinedmsg" runat="server" Width="150px" 
                                                                    onselectedindexchanged="ddlpredefinedmsg_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trnewsms" runat="server">
                                                            <td valign="top" class="sms_template_lable">
                                                                <asp:Label ID="Label1" runat="server" Text="SMS Header" CssClass="sms_label"></asp:Label>
                                                            </td>   
                                                            <td>
                                                                <asp:TextBox ID="txtnewsmsheader" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" class="sms_template_lable">
                                                                <asp:Label ID="lblmessage" runat="server" Text="Message" CssClass="sms_label"></asp:Label>
                                                            </td>   
                                                            <td >
                                                                <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine" Height="100px" Width="400px" CssClass="s_textbox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr >
                                                            <td align="left" valign="top" class="sms_template_lable">
                                                             <asp:Label ID="Label78" runat="server" CssClass="sms_label" Text="Keywords"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width:400px; height:auto">
                                                                <asp:Label ID="lblkeywords" runat="server" CssClass="sms_keyword_label" Height="100%" 
                                                                    Text=""></asp:Label>
                                                            </td>                                                
                                                        </tr>
                                                        <tr id="trconditionquery" runat="server" visible="false">
                                                            <td valign="top" colspan="2" align="center"><asp:Label ID="lblconditionquery" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" colspan="2" align="center"><asp:Label ID="Hiddenerror" runat="server" CssClass="nodatatodisplay"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center" valign="top" style="width:100%">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                    <tr id="trdgattendance" runat="server">
                                                                        <td valign="top" align="center">
                                                                            <asp:DataGrid ID="dgexamdetails" runat="server" GridLines="None" 
                                                                                AutoGenerateColumns="False" Width="100%">
                                                                                <ItemStyle CssClass="s_datagrid_item" />
                                                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                                  <Columns>
                                                                                    <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False">
                                                                                    </asp:BoundColumn>
                                                                                    <asp:BoundColumn DataField="strexamtype" HeaderText="Exam Name">
                                                                                    </asp:BoundColumn>
                                                                                    <asp:BoundColumn DataField="strexampaper" HeaderText="Paper Name">
                                                                                    </asp:BoundColumn>
                                                                                    <asp:BoundColumn DataField="dtexamdate" HeaderText="Exam Date">
                                                                                    </asp:BoundColumn>
                                                                                    <asp:BoundColumn DataField="strexamstarttime" HeaderText="Time">
                                                                                    </asp:BoundColumn>
                                                                                </Columns>
                                                                                <HeaderStyle CssClass="s_datagrid_header" />
                                                                            </asp:DataGrid>
                                                                        </td>   
                                                                    </tr>
                                                                    <tr id="trsendbutton" runat="server" visible="false">
                                                                        <td align="center" valign="middle" class="s_datagrid_header">
                                                                            <table cellpadding="5" cellspacing="0" border="0" width="60%" style="text-align:center">
                                                                                <tr>
                                                                                    <td colspan="3">
                                                                                        <asp:Button ID="Sendsms" runat="server" Text="Send SMS" 
                                                                                            CssClass="s_button" onclick="Sendsms_Click" />
                                                                                        &nbsp;&nbsp;
                                                                                    <asp:Button ID="sendlater" runat="server" Text="Delay" CssClass="s_button" 
                                                                                            onclick="sendlater_Click" /></td>
                                                                                </tr>
                                                                                <tr id="trdelaydate" runat="server" visible="false">
                                                                                    <td>
                                                                                        <asp:Label ID="lbldelaydate" runat="server" Text="Delay Date :" CssClass="s_datagrid_header"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:TextBox ID="txtDelaydate" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="submitdelay" runat="server" Text="Submit" CssClass="s_button" 
                                                                                            onclick="submitdelay_Click" />
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
                                        </table><%--
                                                </ContentTemplate>
                                         </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:admin_footer ID="admin_footer" runat="server" />
            </td>
        </tr>
    </table>
     <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
