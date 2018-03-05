﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="allotroomsandcapacity.aspx.cs" Inherits="school_allotroomsandcapacity" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/admin_building.ascx" tagname="admin_building" tagprefix="uc1" %>
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
                                        <uc1:admin_building ID="admin_building1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/78.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Set Class Room</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4"><asp:Label ID="lbltitle" runat="server" Text="Set Class Room" CssClass="title_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Building Name"></asp:Label>
                                                </td>
                                                <td align="left" class="style2">
                                                    <asp:DropDownList ID="ddlbuildname" runat="server" CssClass="s_dropdown" 
                                                        Width="180px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlbuildname_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" class="style1"></td>
                                                <td align="left" class="style2"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Floors"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlfloor" runat="server" CssClass="s_dropdown" 
                                                        Width="180px" Height="24px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlfloor_SelectedIndexChanged">                                                      
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Room  No  "></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlrooms" runat="server" CssClass="s_dropdown" 
                                                        Width="78px">
                                                    </asp:DropDownList>
                                                    &nbsp;&nbsp;</td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" 
                                                        Text="Room Type"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlroomtype" runat="server" CssClass="s_dropdown" 
                                                        Width="180px" Height="24px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlroomtype_SelectedIndexChanged">
                                                        <asp:ListItem Value="Classes">Classes</asp:ListItem>
                                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 40px" align="left" colspan="2">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr id="trclasses" runat="server" visible="false">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" 
                                                        Text="Class &amp; Section"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_dropdown" 
                                                        Height="25px" Width="180px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlclass_SelectedIndexChanged1">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_dropdown" 
                                                        Height="25px" Width="50px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr id="trothers" runat="server" visible="false">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Other"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txtother" runat="server" CssClass="s_textbox" Width="163px"></asp:TextBox>
                                                </td>
                                                <td style="height: 40px" align="left" colspan="2">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Room Capacity"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txtcapacity" runat="server" CssClass="s_textbox" Width="75px"></asp:TextBox>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
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
                                                    <asp:DataGrid ID="dgcapacity" runat="server" AutoGenerateColumns="False" 
                                                         OnEditCommand="dgcapacity_EditCommand" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strbuildname" HeaderText="Building Name">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strfloor" HeaderText="Floor">
                                                            </asp:BoundColumn>                                        
                                                            <asp:BoundColumn DataField="strroomno" HeaderText="Room No"></asp:BoundColumn>                                                           
                                                            <asp:BoundColumn DataField="roomname" HeaderText="Room Name"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strcapacity" HeaderText="Room Capacity">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strother" HeaderText="Others" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intbuildname" HeaderText="Building ID" Visible="False"></asp:BoundColumn>                                                            
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
                                                        <HeaderStyle CssClass="s_datagrid_header"/>
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
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
