<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feemode.aspx.cs" Inherits="Fee_Feemode" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../usercontrol/feemanagement.ascx" tagname="feemanagement" tagprefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script> 
    <script type="text/javascript">
        function Validatation() {
            if (document.getElementById('txtfeemode').value == "") {
                alert("Please enter fee mode to proceed");
                document.getElementById('txtfeemode').focus();
                return false
            }
        }
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server"></asp:ToolkitScriptManager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr><td style="width: 100%;" align="left"><uc3:topbanner ID="topbanner1" runat="server" /></td></tr>
        <tr><td style="width: 100%;" valign="top"><uc2:topmenu ID="topmenu1" runat="server" /></td></tr>
        <tr>
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top"><table cellpadding="0" cellspacing="0" border="0" width="230"><tr><td style="width: 230px" align="right"><uc5:feemanagement ID="feemanagement1" runat="server" /></td></tr><tr><td style="width: 230px; height: 15px" align="right"></td></tr><tr><td style="width: 230px" align="right"><uc4:school_info ID="school_info1" runat="server" /></td></tr></table></td>
                        <td style="width: 1%" valign="top"></td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title"><td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" ><tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">Fee Mode</td></tr></table></td></tr>
                                <tr><td class="break"></td></tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                              <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                 <ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate>
                                               </asp:UpdateProgress>
                                               <asp:UpdatePanel ID="updatepanal" runat="server" >
                                               <ContentTemplate> 
                                                <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                                    <tr class="view_detail_title_bg"><td colspan="4"><asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Add Fee Mode" ></asp:Label></td></tr>
                                                    <tr><td style="width: 150px" align="left" class="s_label">Fee Mode</td>
                                                        <td style="width: 200px" align="left"><asp:TextBox ID="txtfeemode" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox></td>
                                                        <td style="width: 150px" align="right"></td><td style="width: 200px" align="left"></td></tr>
                                                    <tr><td style="width: 150px" align="right">&nbsp;</td><td style="width: 200px" align="left"><asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" Width="60px" OnClientClick="return Validatation();" onclick="btnSave_Click"/> &nbsp;<asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" Width="60px" onclick="btnClear_Click" /> </td>
                                                        <td style="width: 150px" align="right"><asp:Label ID="lbleditid" runat="server" CssClass="s_label" Visible="false"></asp:Label></td><td style="width: 200px" align="left"></td></tr>
                                                    <tr>
                                                        <td colspan="3" style="width: 500px" align="left">
                                                            <asp:DataGrid ID="dgfee" runat="server" AutoGenerateColumns="False" Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="2" CellSpacing="1" oneditcommand="dgfee_EditCommand"><AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item"/>
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="FeemodeID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="FeemodeName" HeaderText="Fee Mode"></asp:BoundColumn> 
                                                                    <asp:ButtonColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;"><HeaderStyle HorizontalAlign="Center"></HeaderStyle><ItemStyle Width="40px" /></asp:ButtonColumn>
                                                                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Delete">
                                                                        <ItemTemplate><asp:ImageButton ID="btnimagedelete" runat="server" ImageUrl="~/media/images/delete.gif" onclick="ImageButton1_Click" onclientclick="return confirm('Are you sure you want to delete?')" /></ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle><ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle></asp:TemplateColumn>
                                                                </Columns>
                                                                <HeaderStyle CssClass="s_datagrid_header"/>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>                                            
                                    </td>
                                </tr>
                            </table>
                         </td>
                    </tr>
                    <tr><td class="break"></td></tr>
                </table>
            </td>
        </tr>
        <tr><td style="width: 100%; height: 50px" align="left" valign="top"><uc6:app_footer ID="footer" runat="server" /></td></tr>
    </table>
    </div>
    </form>
</body>
</html>