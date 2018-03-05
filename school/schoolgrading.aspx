<%@ Page Language="C#" AutoEventWireup="true" CodeFile="schoolgrading.aspx.cs" Inherits="admin_schoolgrading" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc1" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    
    <link rel="stylesheet" href="../include/jquery-ui-1.8.14.custom.css" type="text/css" />
    <link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />
    <script type="text/javascript" src="../include/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>    
    <script type="text/javascript">
            $(document).ready(function() {
            $('#txtstarttime').timepicker();
        });
        $(document).ready(function() {
            $('#txtendtime').timepicker();
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
            <td align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
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
                                        <uc1:school_profile ID="school_profile1" runat="server" />
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
                        <td style="width: 94%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Edit Grade</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr>
                                                <td colspan="2" align="left">
                                                     <asp:DataGrid ID ="dggrade" runat="server" CellPadding="4" 
                                                        AutoGenerateColumns="False" CssClass="s_label" 
                                                        oneditcommand="dggrade_EditCommand" Width="100%" GridLines="None" 
                                                         onitemdatabound="dggrade_ItemDataBound" >
                                                         <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                         <ItemStyle CssClass="s_datagrid_item" />
                                                         <Columns>
                                                             <asp:BoundColumn DataField="intschoolgradingid" HeaderText="ID" Visible="False">
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strgrade" HeaderText="Grade" Visible="False">
                                                                <ItemStyle Width="100px" />
                                                             </asp:BoundColumn>
                                                             <asp:TemplateColumn HeaderText="Grade">
                                                                <ItemStyle Width="100px" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtgrade" runat="server" Width="80px"></asp:TextBox>
                                                                </ItemTemplate>
                                                             </asp:TemplateColumn>
                                                             <asp:BoundColumn DataField="intfrommarks" HeaderText="From Marks">
                                                                <ItemStyle Width="100px" />
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="inttomarks" HeaderText="To Marks" Visible="False">
                                                                <ItemStyle Width="100px" />
                                                             </asp:BoundColumn>
                                                             <asp:TemplateColumn HeaderText="To Marks">
                                                                <ItemStyle Width="100px" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txttomarks" runat="server" Width="80px"></asp:TextBox>
                                                                </ItemTemplate>
                                                             </asp:TemplateColumn>
                                                             <asp:ButtonColumn CommandName="edit" HeaderText="Update" 
                                                                 Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="60px" />
                                                             </asp:ButtonColumn>
                                                            <asp:TemplateColumn HeaderText="Delete">
                                                                <ItemStyle Width="100px"  />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btndelete" runat="server" 
                                                                        ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                                    OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                                        onclick="btndelete_Click"  />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                             <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete" 
                                                                 Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="60px" />
                                                             </asp:ButtonColumn>--%>
                                                         </Columns>
                                                         <HeaderStyle CssClass="s_datagrid_header" />
                                                     </asp:DataGrid>
                                                     <asp:DataGrid ID ="dggrade1" runat="server" CellPadding="4" 
                                                        AutoGenerateColumns="False" CssClass="s_label" Width="100%" GridLines="None" 
                                                         onitemdatabound="dggrade1_ItemDataBound" 
                                                         oneditcommand="dggrade1_EditCommand" ShowHeader="False">
                                                         <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                         <ItemStyle CssClass="s_datagrid_item" />
                                                         <Columns>
                                                             <asp:BoundColumn DataField="strgrade" HeaderText="Grade" Visible="False">
                                                                <ItemStyle Width="100px" />
                                                             </asp:BoundColumn>
                                                             <asp:TemplateColumn HeaderText="Grade">
                                                                <ItemStyle Width="100px" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtgrade" runat="server" Width="80px"></asp:TextBox>
                                                                </ItemTemplate>
                                                             </asp:TemplateColumn>
                                                             <asp:BoundColumn DataField="intfrommarks" HeaderText="From Marks">
                                                                <ItemStyle Width="100px" />
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="inttomarks" HeaderText="To Marks" Visible="False">
                                                                <ItemStyle Width="100px" />
                                                             </asp:BoundColumn>
                                                             <asp:TemplateColumn HeaderText="To Marks">
                                                                <ItemStyle Width="100px" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txttomarks" runat="server" Width="80px"></asp:TextBox>
                                                                </ItemTemplate>
                                                             </asp:TemplateColumn>
                                                             <asp:ButtonColumn CommandName="edit" HeaderText="Add Grade" 
                                                                 Text="Add Grade" ButtonType="PushButton">
                                                                <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                             </asp:ButtonColumn>
                                                         </Columns>
                                                         <HeaderStyle CssClass="s_datagrid_header" />
                                                     </asp:DataGrid>
                                                  </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height:40px;">
                                                    <asp:Button ID="Btnsave" runat="server"  
                                                        Text="Done" onclick="Btnsave_Click" CssClass="s_button" Width="62px"/>
                                                </td>
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
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>

