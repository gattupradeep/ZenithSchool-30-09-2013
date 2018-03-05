﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignbusroute.aspx.cs" Inherits="transport_assignbusroute" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register src="../usercontrol/admin_transport.ascx" tagname="admin_transport" tagprefix="uc1" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
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
                                    <td style="width: 100%;" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/113.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Add / Edit Assign Bus Route</td>
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
                                                <td colspan="4" class="title_label">&nbsp;&nbsp;Add / Edit Assign Bus Route</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" >
                                                    <table cellpadding="7" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td style="width: 250px; height: 40px" align="left">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Route"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlroute" runat="server" CssClass="s_dropdown" 
                                                                 Width="150px">                                                     
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 250px; height: 40px" align="left">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" 
                                                                    Text="Pickup &amp; Drop Point"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtdestination" runat="server" CssClass="s_textbox" 
                                                                    Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 250px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Pick up Time"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlpickhour" runat="server" CssClass="s_dropdown" Width="50px">                                                    
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlpickmin" runat="server" CssClass="s_dropdown" Width="50px">                                                                                                   
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlpickcat" runat="server" CssClass="s_dropdown" Width="60px">
                                                                <asp:ListItem Value="AM">AM</asp:ListItem>
                                                                <asp:ListItem Value="PM" >PM</asp:ListItem> 
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Drop Time"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddldrophour" runat="server" CssClass="s_dropdown" Width="50px">                                                   
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddldropmin" runat="server" CssClass="s_dropdown" Width="50px">                                                    
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddldropcat" runat="server" CssClass="s_dropdown" Width="60px">
                                                                <asp:ListItem Value="AM">AM</asp:ListItem>
                                                                <asp:ListItem Value="PM">PM</asp:ListItem> 
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Amount"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtamount" runat="server" CssClass="s_textbox" 
                                                                    Width="100px"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left">&nbsp;</td>
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
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 40px" align="left">
                                                    <asp:DataGrid ID="dgasgnbusroute" runat="server" AutoGenerateColumns="False"
                                                        
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        oneditcommand="dgasgnbusroute_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strdestination" HeaderText="Destination">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="introute" HeaderText="Route" visible="false">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dtpickuptime" HeaderText="Pick up Time">
                                                            </asp:BoundColumn>
                                                           <asp:BoundColumn DataField="dtdroptime" HeaderText="Drop Time">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intamount" HeaderText="Amount"></asp:BoundColumn>
															<asp:BoundColumn DataField="strroutename" HeaderText="Route">
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
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>