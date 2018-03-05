<%@ Page Language="C#" AutoEventWireup="true" CodeFile="driver.aspx.cs" Inherits="transport_driver" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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
                $("#txtdateofbirth").datepicker({ dateFormat: 'yy/mm/dd', 
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                    });
            }
         });

       $(function() {
            var dates = $("#txtdateofbirth").datepicker({
                constrainDates: true,
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true
            });
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $("#txtissuedate").datepicker({ dateFormat: 'yy/mm/dd',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                    });
            }
        });
        $(function() {
            var dates = $("#txtissuedate").datepicker({
                constrainDates: true,
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true
            });
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $("#txtexpirydate").datepicker({ dateFormat: 'yy/mm/dd',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(function() {
            var dates = $("#txtexpirydate").datepicker({
                constrainDates: true,
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
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
        .style3
        {
            width: 150px;
            height: 40px;
        }
        .style4
        {
            width: 300px;
            height: 40px;
        }
        .style5
        {
            width: 50px;
            height: 40px;
        }
  </style>
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
                                                <td align="left">Add / Edit Driver master</td>
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
                                                <td colspan="4" class="title_label">Add / Edit Driver master</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table cellpadding="7" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Driver Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtdriver" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="left">
                                                                <asp:RegularExpressionValidator ID="reg1" runat="server"
                                                                ControlToValidate="txtdriver" ErrorMessage="Enter vaid name" Height="16px" 
                                                                ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" Width="16px"></asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                                 ControlToValidate="txtdriver" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="width: 50px; height: 40px" align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Date Of Birth"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">                                                              
                                                               <asp:TextBox ID="txtdateofbirth" runat="server" 
                                                                    Width="150px"></asp:TextBox>
                                                                  
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Licence No"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtlicenceno" runat="server" CssClass="s_textbox" 
                                                                    Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="left">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                                    ControlToValidate="txtlicenceno" ErrorMessage="*" Height="16px" 
                                                                    Width="16px"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="reg3" runat="server" 
                                                                    ControlToValidate="txtlicenceno" ErrorMessage="Enter valid licence number(ex:6098GB69112)" Height="16px"  ValidationExpression="^[0-9]*([0-9]*[A-Za-z][0-9]*){0,2}[0-9]*$"
                                                                    Width="16px"></asp:RegularExpressionValidator>
                                                                </td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style3">
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Licence Issue Date"></asp:Label>
                                                            </td>
                                                            <td align="left" class="style1">
                                                                <asp:TextBox ID="txtissuedate" runat="server"  
                                                                    Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="right" class="style4"></td>
                                                            <td align="left" class="style5"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Licence Expiry Date"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtexpirydate" runat="server" 
                                                                    Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Mode Of Licence"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                              <asp:DropDownList ID="ddlmode" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" >
                                                              <asp:ListItem Value="Light">Light</asp:ListItem>
                                                              <asp:ListItem Value="Heavy">Heavy</asp:ListItem>
                                                              </asp:DropDownList> 
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Address"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtaddress" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="left">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                                                    ControlToValidate="txtaddress" ErrorMessage="*" Height="16px" 
                                                                    Width="16px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Area"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtarea" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="left">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                                                                    ControlToValidate="txtarea" ErrorMessage="*" Height="16px" 
                                                                    Width="16px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="City"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtcity" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="left">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                                                                    ControlToValidate="txtcity" ErrorMessage="*" Height="16px" 
                                                                    Width="16px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="State"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtstate" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="left">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                                                                    ControlToValidate="txtcity" ErrorMessage="*" Height="16px" 
                                                                    Width="16px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Country"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtcountry" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="left">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" 
                                                                    ControlToValidate="txtcountry" ErrorMessage="*" Height="16px" 
                                                                    Width="16px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Phone No"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtphoneno" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="left">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtphoneno" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Mobile Number"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtmobile" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 300px; height: 40px" align="left">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                                                                    ControlToValidate="txtmobile" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style1">
                                                                </td>
                                                            <td align="left" class="style2">
                                                                </td>
                                                            <td align="right" class="style1"></td>
                                                            <td align="left" class="style2"></td>
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
                                                            <td style="width: 300px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 50px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="width: 750px; height: 40px" align="left">
                                                    <asp:DataGrid ID="dgdriver" runat="server" AutoGenerateColumns="False"
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                         oneditcommand="dgdriver_EditCommand" >
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strdrivername" HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="address" HeaderText="Address"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strcountry" HeaderText="Country"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="contact" HeaderText="Contact"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                           
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
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
                                                            <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete"  Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>--%>
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
            <td style="width: 100%;" align="left" valign="top" >
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Label ID="resultlabel" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
