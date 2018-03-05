<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editdeletetextbooks.aspx.cs" Inherits="syllabus_editdeletetextbooks" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/admin_syllabus.ascx" tagname="admin_syllabus" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
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
                                        <uc1:admin_syllabus ID="admin_syllabus1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/75.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left"> Edit | Delete Textbooks</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <%-- <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
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
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Class"></asp:Label>
                                                </td>
                                                <td style="width: 350px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                        Width="145px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlstandard_SelectedIndexChanged"></asp:DropDownList>
                                                               <asp:Label ID="lblsame" runat="server" CssClass="s_label" 
                                                        Visible="False">1</asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trsubject" runat="server">
                                               <td style="width: 150px; height: 40px" align="left">
                                                     &nbsp;
                                                     <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Subject"></asp:Label>
                                               </td>
                                               <td style="width: 350px; height: 40px" align="left" >
                                                   <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_dropdown" 
                                                       Width="145px" AutoPostBack="True" 
                                                       onselectedindexchanged="ddlsubject_SelectedIndexChanged"></asp:DropDownList>
                                               </td>
                                           </tr>
                                           <tr id="tr2" runat="server" visible="false">
                                                <td colspan="2" style="height: 40px; width: 500px" align="center">
                                                    <asp:DataGrid ID="datagrid" runat="server" AutoGenerateColumns="False" 
                                                        Width="490px" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        onitemdatabound="datagrid_ItemDataBound" >
                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intsame" Visible="false"></asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Textbook Name">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltextbookname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strtextbookname")%>'></asp:Label>
                                                                    <asp:TextBox ID="txttextbookname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strtextbookname")%>' Visible="false"></asp:TextBox>
                                                                </ItemTemplate>
                                                             </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Author Name">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblauthorname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strauthorname")%>'></asp:Label>
                                                                    <asp:TextBox ID="txtauthorname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strauthorname")%>' Visible="false"></asp:TextBox>
                                                                </ItemTemplate>
                                                             </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Edit">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnaddunit" runat="server" 
                                                                        ImageUrl="../media/images/edit.gif" onclick="btnaddunit_Click" />
                                                                </ItemTemplate>
                                                             </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Delete">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btndelete" runat="server" 
                                                                        OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                                        ImageUrl="../media/images/delete.gif" onclick="btndelete_Click" />
                                                                </ItemTemplate>
                                                             </asp:TemplateColumn>
                                                        </Columns>
                                                    <HeaderStyle CssClass="s_datagrid_header"/>
                                                    </asp:DataGrid>
                                                </td>
                                          </tr>
                                           <tr>
                                                <td colspan="2" style="height: 40px; width: 500px" align="center">
                                                    <asp:Button ID="btndone" runat="server" CssClass="s_button" 
                                                    Text="Done" onclick="btndone_Click" />
                                                </td>
                                            </tr>
                                    </table>
                                                        </ContentTemplate>
                                            </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 20px"></td>
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
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
