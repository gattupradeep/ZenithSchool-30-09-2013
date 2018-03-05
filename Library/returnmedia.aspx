<%@ Page Language="C#" AutoEventWireup="true" CodeFile="returnmedia.aspx.cs" Inherits="Library_returnmedia" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register src="../usercontrol/admin_library.ascx" tagname="admin_library" tagprefix="uc1" %>
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
                                        <uc1:admin_library ID="admin_library1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/262.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left"> Return Media</td>
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
                                                <td class="title_label">&nbsp;&nbsp;Return Media</td>
                                            </tr>
                                            <tr>
                                                <td  align="left" valign="top" style="height:50px">&nbsp;&nbsp;
                                                    <asp:Label ID="Label1" runat="server" Text="Barcode : " CssClass="s_label"></asp:Label>
                                                    <asp:TextBox ID="Txtbarcode" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                    <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="s_button" 
                                                        onclick="Button1_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  align="left" valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <asp:DataGrid ID="dgreturnmedia" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                                                                 GridLines="None" Width="100%" oneditcommand="dgreturnmedia_EditCommand" AllowCustomPaging="True" ondeletecommand="dgreturnmedia_DeleteCommand">
                                                        <AlternatingItemStyle CssClass = "s_datagrid_alt_item" />
                                                        <ItemStyle CssClass = "s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intschool" HeaderText="intschool" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strpatrontype" HeaderText="Patron Type"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strname" HeaderText="Name"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intbarcode" HeaderText="Barcode"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strtitle" HeaderText="Media Title"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dtdateofissue1" HeaderText="Issued Date"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="dtdateofissue" DataField="dtdateofissue" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Expire Date" DataField="expirydate"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="execess" HeaderText="Days of Excess"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intid1" HeaderText="intid1" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="noofrenewals" HeaderText="noofrenewals" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="fine" HeaderText="Fine Amount"></asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Renewal">
                                                                <ItemTemplate>
                                                                    <asp:Button runat="server" CausesValidation="false" CommandName="delete" 
                                                                        Text="Renew" CssClass="s_grdbutton" />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Return">
                                                                <ItemTemplate>
                                                                    <asp:Button runat="server" CausesValidation="false" CommandName="edit" 
                                                                        Text="Return" CssClass="s_grdbutton" />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    <HeaderStyle CssClass = "s_datagrid_header" />
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
    <cc1:MsgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
