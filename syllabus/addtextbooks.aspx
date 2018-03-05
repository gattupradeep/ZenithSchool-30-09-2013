<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addtextbooks.aspx.cs" Inherits="syllabus_addtextbooks" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/admin_syllabus.ascx" tagname="admin_syllabus" tagprefix="uc1" %>
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
                                                <td align="left">Add TextBook and Units</td>
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
                                            <asp:UpdatePanel ID="updatepanal" runat="server" >
                                                <ContentTemplate>
                                                         <table cellpadding="0" cellspacing="0" style="width:500px" class="app_container">
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
                                            <tr id="trpaper" runat="server">
                                               <td style="width: 150px; height: 40px" align="left">
                                                     &nbsp;&nbsp;
                                                     <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Paper"></asp:Label>
                                               </td>
                                               <td style="width: 350px; height: 40px" align="left" >
                                                   <asp:DropDownList ID="ddlpaper" runat="server" CssClass="s_dropdown" 
                                                       Width="145px" AutoPostBack="True" 
                                                       onselectedindexchanged="ddlpaper_SelectedIndexChanged"></asp:DropDownList>
                                               </td>
                                           </tr>
                                           <tr id="trbelow" runat="server" visible="false">
                                               <td colspan="2" style="width: 500px; height: 40px" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="500">
                                                       <tr>
                                                           <td style="width: 150px; height: 40px" align="left">
                                                               &nbsp;
                                                               <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="TextBook Name"></asp:Label>
                                                           </td>
                                                           <td style="width: 350px; height: 40px" align="left" class="">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="350">
                                                                    <tr>
                                                                        <td style="width: 250px; height: 40px" align="left" class="">
                                                                            <asp:TextBox ID="txttextbookname" runat="server" CssClass="s_textbox" 
                                                                                Width="230px"></asp:TextBox>
                                                                           <asp:DropDownList ID="ddltextbook" runat="server" CssClass="s_dropdown" 
                                                                               Width="230px" AutoPostBack="True" 
                                                                                onselectedindexchanged="ddltextbook_SelectedIndexChanged" ></asp:DropDownList>
                                                                        </td>
                                                                        <td style="width: 100px; height: 40px" align="left" class="">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td style="width: 150px; height: 40px" align="left">
                                                               &nbsp;
                                                               <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Author"></asp:Label>
                                                           </td>
                                                           <td style="width: 350px; height: 40px" align="left" class="">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="350">
                                                                    <tr>
                                                                        <td style="width: 200px; height: 40px" align="left" class="">
                                                                            <asp:TextBox ID="txtauthor" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                            <asp:Label ID="lblauthor" runat="server" CssClass="s_label"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 150px; height: 40px" align="left" class="">
                                                                            <asp:Button ID="btnaddtext" runat="server" CssClass="s_button" Text="Add New" 
                                                                                onclick="btnaddtext_Click" />
                                                                            <asp:Button ID="btncancel" runat="server" CssClass="s_button" Text="Cancel" 
                                                                                onclick="btncancel_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                           </td>
                                                       </tr>
                                                       <tr id="tr1" runat="server">
                                                           <td colspan="2" style="width: 500px; height: 40px" align="left">
                                                               &nbsp;
                                                               <asp:Label ID="Label6" runat="server" CssClass="s_label" 
                                                                   Text="Is Unit Name same as Unit No?"></asp:Label>
                                                                <asp:RadioButton ID="rbtnyes" runat="server" Checked="True" 
                                                                    CssClass="s_label" GroupName="unitname" Text="Yes" />
                                                                <asp:RadioButton ID="Rbtnno" runat="server" CssClass="s_label" 
                                                                    GroupName="unitname" Text="No" />
                                                            </td>
                                                       </tr>
                                                       <tr id="tr2" runat="server" visible="false">
                                                            <td colspan="2" style="height: 40px; width: 500px" align="center">
                                                                <asp:DataGrid ID="datagrid" runat="server" AutoGenerateColumns="False" Width="490px" BorderStyle="None" BorderWidth="0px" GridLines="None" onitemdatabound="datagrid_ItemDataBound">
                                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="intid" Visible="false"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="intunitno" Visible="false"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="intedit" Visible="false"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strunitno" HeaderText="Unit No" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle Width="165px" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strunitname1" HeaderText="Unit Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle Width="165px" />
                                                                        </asp:BoundColumn>
                                                                        <asp:TemplateColumn HeaderText="Unit Name" Visible="false">
                                                                            <ItemStyle Width="165px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblunitname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strunitname")%>' Visible="false"></asp:Label>
                                                                                <asp:TextBox ID="txtunitname" runat="server" Width="150px" 
                                                                                    Text='<%# DataBinder.Eval(Container.DataItem, "strunitname")%>' 
                                                                                    ontextchanged="txtunitname_TextChanged"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn HeaderText="Add/Update">
                                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnaddunit" runat="server" 
                                                                                    ImageUrl="../media/images/add.gif" onclick="btnaddunit_Click" />
                                                                            </ItemTemplate>
                                                                         </asp:TemplateColumn>
                                                                        <asp:TemplateColumn HeaderText="Delete">
                                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btndelete" runat="server" 
                                                                                    ImageUrl="../media/images/delete.gif" onclick="btndelete_Click" />
                                                                            </ItemTemplate>
                                                                         </asp:TemplateColumn>
                                                                    </Columns>
                                                                <HeaderStyle CssClass="s_datagrid_header"/>
                                                                </asp:DataGrid>
                                                            </td>
                                                      </tr>
                                                    </table>
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
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
