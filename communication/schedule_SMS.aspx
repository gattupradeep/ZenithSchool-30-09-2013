<%@ Page Language="C#" AutoEventWireup="true" CodeFile="schedule_SMS.aspx.cs" Inherits="communication_schedulesms" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/admin_attendance.ascx" tagname="admin_attendance" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/communication_admin.ascx" tagname="communication_admin" tagprefix="uc5" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
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
            var dates = $("#txtdate").datepicker({
                constrainDates: true,
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true
            });
        });
    </script>
    <link rel="stylesheet" href="../include/jquery-ui-1.8.14.custom.css" type="text/css" />
    <link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />
    <script type="text/javascript" src="../include/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>    
    <script type="text/javascript">
        $(document).ready(function() {
            $('#txtscheduletime').timepicker();
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
                                                <td align="left" > SMS Schedule</td>
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
                                        <%--<asp:UpdatePanel ID="updatepanal" runat="server" >
                                             <ContentTemplate>--%>
                                                     <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td> <asp:Label ID="Label2" runat="server" Text="Pre defined Messages" CssClass="title_label" Font-Size="20px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td style="width:20%" class="top_curve" valign="top">
                                                                <asp:DataGrid ID="dgcategory" runat="server" AutoGenerateColumns="False" 
                                                                    Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                                    oneditcommand="dgcategory_EditCommand" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                                                                <AlternatingItemStyle  />
                                                                <ItemStyle  />
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="intid" HeaderText="intid" Visible="False">
                                                                        </asp:BoundColumn>
                                                                        <asp:TemplateColumn  HeaderText="Category" HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="Medium">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton runat="server" CausesValidation="false" CommandName="edit" 
                                                                                    Text='<%# DataBinder.Eval(Container, "DataItem.strcategory") %>' CssClass="sms_category" Width="98%" Font-Underline="false"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                   <HeaderStyle BackColor="#F79E51" />
                                                                </asp:DataGrid>
                                                                </td>
                                                                <td style="width:80%" valign="top" style="vertical-align:top">
                                                                    <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                       <tr>
                                                                            <td valign="top" style="width:30%" class="top_curve">
                                                                                    <asp:DataGrid ID="dgsmstemplate" runat="server" AutoGenerateColumns="False" 
                                                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None"
                                                                                        ondeletecommand="dgsmstemplate_DeleteCommand" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <AlternatingItemStyle   />
                                                                                    <ItemStyle  />
                                                                                        <Columns>
                                                                                            <asp:BoundColumn DataField="intid" HeaderText="intid" Visible="False">
                                                                                            </asp:BoundColumn>
                                                                                            <asp:TemplateColumn  HeaderText="Templates" HeaderStyle-ForeColor="White" HeaderStyle-Font-Size="Medium">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="delete" 
                                                                                                        Text='<%# DataBinder.Eval(Container.DataItem, "strtemplatename") %>' CssClass="s_button" Width="98%" Font-Underline="false" ></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateColumn>
                                                                                        </Columns>
                                                                                       <HeaderStyle BackColor="#F79E51" />
                                                                                    </asp:DataGrid>
                                                                            </td>
                                                                            <td valign="top" style="width:50%;" class="top_curve">
                                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                    <tr align="center" style="background:#F79E51">
                                                                                        <td><asp:Label ID="Label1" runat="server" Text="Message Box" CssClass="s_label"></asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding:10px;"><asp:Label ID="lblselectedmsg" runat="server" Text="" CssClass="s_label"></asp:Label></td>
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
                                                <td align="center" style="width: 710px; height: 20px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 710px; height: 40px">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" valign="top" class="style1">
                                                                <asp:Label ID="Label3" runat="server" Text="Select Patron Type" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top" class="style1">
                                                                <asp:DropDownList ID="ddpatron" runat="server" AutoPostBack="True" 
                                                                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                                                    <asp:ListItem>-Select-</asp:ListItem>
                                                                    <asp:ListItem>Student</asp:ListItem>
                                                                    <asp:ListItem>Teaching Staff</asp:ListItem>
                                                                    <asp:ListItem>Non Teaching Staff</asp:ListItem>
                                                                    <asp:ListItem>All Staff</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddpatron" InitialValue="-Select-"
                                                                    ErrorMessage="Select Patron type"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" valign="top" class="style2">
                                                                <asp:Panel ID="pan" runat="server" Width="180px" BorderWidth="1px" BackColor="#F7F7F7" BorderColor="#1874CD" Height="100px" ScrollBars="Vertical" >
                                                                <asp:CheckBoxList ID="chkgroups" runat="server" ></asp:CheckBoxList>
                                                                </asp:Panel>
                                                           </td>
                                                            <td align="left" valign="top" class="style3">&nbsp;&nbsp;
                                                            
                                                                <asp:Label ID="lbltime" runat="server" Text="Schedule Time" 
                                                                    CssClass="s_label"></asp:Label>
                                                                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtscheduletime" runat="server" CssClass="s_text" Width="50"></asp:TextBox><asp:RequiredFieldValidator 
                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtscheduletime"
                                                                    ErrorMessage="Enter Time"></asp:RequiredFieldValidator></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 710px; height: 40px">
                                                    <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="s_button" 
                                                        onclick="btnsave_Click" />
                                                </td>
                                           </tr>
                                            <tr>
                                                <td align="left" style="width: 710px; height: 40px">
                                                    <asp:DataGrid ID="dgsmsSchedule" runat="server" AutoGenerateColumns="False" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        oneditcommand="dgsmsSchedule_EditCommand" >
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                            <Columns>
                                                                <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False">
                                                                </asp:BoundColumn>
                                                                <asp:TemplateColumn ItemStyle-VerticalAlign="Top" >
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                            <asp:LinkButton ID="btndelall" runat="server" OnClientClick="return confirm('Are you certain you want to delete Selected?');" CommandName="delete" Text="Delete" ForeColor="Red" Font-Underline="false" onclick="btndelall_Click"></asp:LinkButton>
                                                                            <br />
                                                                            <asp:checkbox id="chkSelectAll" runat="server" autopostback="true" oncheckedchanged="chkSelectAll_CheckedChanged"/>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                    <table><tr><td><asp:CheckBox ID="chkselect" runat="server" /></td></tr></table>
                                                                    </ItemTemplate>
                                                                    <ItemStyle VerticalAlign="Top"></ItemStyle>
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="strcategory"  HeaderText="Category">
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn DataField="strtemplatename"  HeaderText="Template">
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn DataField="strscheduledtime"  HeaderText="Schedule Time">
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn DataField="strpatron" HeaderText="Patron Type">
                                                                </asp:BoundColumn>
                                                                <asp:ButtonColumn CommandName="edit" HeaderText="Edit" 
                                                                Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
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
                                                                <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete" 
                                                                Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="50px" />
                                                                </asp:ButtonColumn>--%>
                                                            </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />    
                                                    </asp:DataGrid>
                                                </td>
                                           </tr>
                                            <tr>
                                                <td align="left" style="width: 710px; height: 40px">
                                                    &nbsp;</td>
                                           </tr>
                                           </table>
                                           <%--  </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr><td class="break"></td></tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
     <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
