﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="designation.aspx.cs" Inherits="admin_Admin_Designation" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
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
                                        <uc1:mainmasters ID="mainmasters1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/86.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left"> Add / Edit Designation</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" class="title_label">&nbsp;Add / Edit Designation</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Designation:"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txtdesig" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right"></td>
                                                <td style="width: 200px; height: 40px" align="left"></td>
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
                                            <tr>
                                                <td colspan="4" style=" height: 40px" align="left">
                                                    <asp:DataGrid ID="dgdesig" runat="server" AutoGenerateColumns="False" 
                                                         OnEditCommand="dgdesig_EditCommand" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="Designation ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strdesignation" HeaderText="Designation">
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
                                                            <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
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
            <td style="width: 100%; height: 50px" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>