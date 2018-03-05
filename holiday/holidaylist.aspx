<%@ Page Language="C#" AutoEventWireup="true" CodeFile="holidaylist.aspx.cs" Inherits="school_holidaylist" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/holiday.ascx" tagname="holiday" tagprefix="uc4" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc1" %>
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
                $('.s_textbox').datepicker({ dateFormat: 'yy/mm/dd' });
            }
        });
        $(function() {
            var dates = $("#txtfromdate").datepicker({
                constrainDates: true,
                dateFormat: 'mm/dd/yy',
                changeMonth: true,
                changeYear: true
            });
        });
        $(function() {
        var dates = $("#txtTodate").datepicker({
                constrainDates: true,
                dateFormat: 'mm/dd/yy',
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
                                        <uc4:holiday ID="holiday1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/221.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Add Academic Holidays</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                       <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="up1" DisplayAfter="1" >
                                            <ProgressTemplate>
                                                <div id="progressBackgroundFilter"></div>
                                                    <div id="processMessage">
                                                        <img alt="Loading" src="../media/images/Processing.gif" />
                                                    </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" class="title_label">&nbsp;Add Academic Holidays</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height:40px">&nbsp;&nbsp;
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Academic year :"></asp:Label>
                                                </td>
                                                <td align="left" >
                                                <asp:DropDownList ID="ddlyear" runat="server" CssClass="s_dropdown" onselectedindexchanged="ddlyear_SelectedIndexChanged" AutoPostBack="True" Width="150">
                                                </asp:DropDownList>
                                                </td>
                                                <td align="right" ></td>
                                                <td align="left" ></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height:40px">&nbsp;&nbsp;
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" 
                                                        Text="Name of the holiday :"></asp:Label>
                                                </td>
                                                <td align="left" >
                                                    <asp:TextBox ID="txtnameofholiday" runat="server" CssClass="s_textbox" Width="200px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtnameofholiday" Font-Size="10px"></asp:RequiredFieldValidator>                                                 
                                                </td>
                                                <td align="right" >&nbsp;</td>
                                                <td align="left" >&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 40px" align="left">
                                                    <asp:UpdatePanel ID="up1" runat="server">
                                                        <ContentTemplate>
                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                <tr>
                                                                    <td style="width: 150px; height: 40px" align="left">&nbsp;&nbsp;
                                                                        <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Date :"></asp:Label>
                                                                    </td>
                                                                    <td style="height: 40px" align="left" colspan="3">
                                                                        <%--<asp:Label ID="lbl1" Text="From" runat="server" CssClass="s_label"></asp:Label>--%>
                                                                        
                                                                        <asp:TextBox ID="txtfromdate" runat="server" CssClass="s_textbox" Width="160px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtfromdate" Font-Size="10px"></asp:RequiredFieldValidator>
                                                                        <%--&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblto" Text="To" runat="server" CssClass="s_label"></asp:Label>
                                                                        
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTodate" runat="server" CssClass="s_textbox" Width="160px"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtfromdate" ControlToValidate="txtTodate" ErrorMessage="From Date Is Greater Than To Date" Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator></td>--%>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                        Width="60px" onclick="btnSave_Click"/>
                                                    &nbsp;
                                                    <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" 
                                                        Width="60px" onclick="btnClear_Click" />
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">
                                                    <asp:HiddenField ID="hdnid" runat="server" />
                                                        </td>
                                                <td style="width: 200px; height: 40px" ></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 40px" align="left">
                                                    <asp:DataGrid ID="dgcalender" runat="server" AutoGenerateColumns="False" 
                                                        OnEditCommand="dgcalender_EditCommand" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="Id" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="date" HeaderText="Date" HeaderStyle-HorizontalAlign="center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strholidayname" HeaderText="Holiday Name" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundColumn> 
                                                            <asp:BoundColumn DataField="dayname" HeaderText="Day" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundColumn>                                                          
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle Width="40px" />
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
                                                            <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>--%>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
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
                        <td class="break"></td>
                    </tr>
                </table>
            </td>
        </tr>
         <tr>
            <td class="break"></td>
        </tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    <uc1:footer ID="footer1" runat="server" />
    </form>
</body>
</html>
