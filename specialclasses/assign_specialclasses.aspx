<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assign_specialclasses.aspx.cs" Inherits="specialclasses_assign_specialclasses" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/activities_timetable.ascx" tagname="activities_timetable" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/special_class.ascx" tagname="special_class" tagprefix="uc5" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
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
	<script type="text/javascript">
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtdate').datepicker({ dateFormat: 'yy/mm/dd',
                    changeMonth: true,
                    constrainDates: true,
                    minDate: new Date,
                    changeYear: true
                });
            }
        });
        $(function() {
            var dates = $("#txtdate").datepicker({
                constrainDates: true,
                minDate: new Date,
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true
            });
        });
       
	</script>
    <link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />  
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>
    <script type="text/javascript">
    
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtfromtime').timepicker();
                $('#txttotime').timepicker();
            }
        });
        $(document).ready(function() {
            $('#txtfromtime').timepicker();
        });
        $(document).ready(function() {
            $('#txttotime').timepicker();
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
                                        <uc5:special_class ID="special_class1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/303.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Assign Special Class</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                     <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                <ProgressTemplate>
                                                    <div id="progressBackgroundFilter"></div>
                                                        <div id="processMessage">
                                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                                        </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>--%>
                                            <%--<asp:UpdatePanel ID="updatepanal" runat="server" >
                                                <ContentTemplate>--%>
                                        <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="3" class="title_label">&nbsp;Assign Special Class</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10px; height: 40px" align="left">
                                                </td>
                                                <td style="height: 40px; width:200px" align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Standard &amp; section:"></asp:Label>                                                    
                                                </td>
                                                <td >
                                                    <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_dropdown" AutoPostBack="true"
                                                        Width="170px" onselectedindexchanged="ddlclass_SelectedIndexChanged"></asp:DropDownList>                                                
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td style="width: 10px; height: 50px" align="left">
                                                </td>
                                                <td style="width: 200px; height: 50px" align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Date :"></asp:Label>
                                                </td>
                                                <td style="height:50px">
                                                    <asp:TextBox ID="txtdate" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox> 
                                                     
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ControlToValidate="txtdate" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                           </tr>
                                            <tr>
                                                <td align="left"></td>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Time :"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="From"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txtfromtime" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                        ControlToValidate="txtfromtime" ErrorMessage="*"></asp:RequiredFieldValidator>                                                    
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="To"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txttotime" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                        ControlToValidate="txttotime" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Subject :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_dropdown" AutoPostBack="true" 
                                                        Width="170px" onselectedindexchanged="ddlsubject_SelectedIndexChanged"></asp:DropDownList>                                                    
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="-Select-" 
                                                        ControlToValidate="ddlsubject" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10px; height: 40px" align="left">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Teacher :"></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:DropDownList ID="ddlteacher" runat="server" CssClass="s_dropdown" Width="170px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlteacher_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="-Select-" 
                                                        ControlToValidate="ddlteacher" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblstaff" runat="server" Text="Staff name" CssClass="s_label"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                    <%--<asp:TextBox ID="txtstaffname" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>--%>
                                                    <asp:DropDownList ID="ddlstaff" runat="server" CssClass="s_dropdown" Width="170px"></asp:DropDownList>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Remarks :"></asp:Label>
                                                </td>
                                                <td style=" height:40px">
                                                    <asp:TextBox ID="txtremarks" runat="server" CssClass="s_textbox" Height="50px" 
                                                        TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td colspan="3" style=" height: 40px; line-height:10px" align="center">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="s_button" Text="Save" 
                                                        onclick="btnsave_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btncancel" runat="server" CssClass="s_button" Text="Cancel" 
                                                        onclick="btncancel_Click" CausesValidation="False" />
                                                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnback" runat="server" CssClass="s_button" Text="Back" 
                                                        onclick="btnback_Click" CausesValidation="False" />
                                                    <%--<input class="s_button" onclick="javascript:history.go(-1)" type="button" 
                                                    value="Back" id="btnback" runat="server" />--%>
                                                </td>
                                            </tr>
                                        </table>
                                               <%-- </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                                <tr><td class="break"></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td style="width: 100%;" align="left" valign="top" >
                <uc6:app_footer ID="footer" runat="server" />    
            </td>
        </tr>
    </table>
        <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
