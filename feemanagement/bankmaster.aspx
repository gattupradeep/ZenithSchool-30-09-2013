<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bankmaster.aspx.cs" Inherits="feemanagement_bankmaster" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/admin_inventory.ascx" tagname="admin_inventory" tagprefix="uc5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/feemanagement.ascx" tagname="feemanagement" tagprefix="uc5" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ajaxtoolkit:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
        </ajaxtoolkit:ToolkitScriptManager>
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
                                <%--<tr>
                                    <td style="width: 230px" align="right">
                                        <uc5:admin_inventory ID="admin_inventory1" runat="server" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                      <uc5:feemanagement ID="feemanagement1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 2%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Bank Account Master</td>
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
                                        <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" style="width: 700px; height: 20px" align="left"><asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Add Account Details" ></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="lbl_group" runat="server" CssClass="s_label" 
                                                        Text="Group"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label Text="Student" runat="server" ID="lblstudent" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="lbl_pay_mode" runat="server" CssClass="s_label" 
                                                        Text="Pay mode"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="drp_pay_mode" runat="server" Height="26px" 
                                                         Width="180px" AutoPostBack="true" 
                                                        onselectedindexchanged="drp_pay_mode_SelectedIndexChanged">
                                                        <asp:ListItem Value="select">-select-</asp:ListItem>
                                                        <asp:ListItem  Value="Cash">Cash</asp:ListItem>
                                                        <asp:ListItem  Value="Cheque/DD">Cheque/DD</asp:ListItem>
                                                        </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="lblFeetype" runat="server" CssClass="s_label" Text="Fee Type"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="drpfeetype" runat="server" Height="26px" AutoPostBack="true" 
                                                         Width="180px" onselectedindexchanged="drpfeetype_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="lbl_ledger" runat="server" CssClass="s_label" 
                                                        Text="Ledger"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="drp_ledger" runat="server" Height="26px" 
                                                         Width="180px" AutoPostBack="true" 
                                                        onselectedindexchanged="drp_ledger_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr id="trbankname" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="lblbankname" runat="server" CssClass="s_label" Text="Bank Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label Text="Bank name" runat="server" ID="lblbankname1" CssClass="s_label"></asp:Label>
                                                    </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr id="trbranch" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="lblbranch" runat="server" CssClass="s_label" Text="Branch"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label Text="Branch" runat="server" ID="lblbranch1" CssClass="s_label"></asp:Label>
                                                    </td>
                                                <td style="width: 150px; height: 40px" align="right">
                                                    <asp:Label ID="lbleditid" runat="server" CssClass="s_label" Visible="false"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                                                                        
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Enter" 
                                                        Width="60px" onclick="btnSave_Click"/>
                                                    &nbsp;
                                                    <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" 
                                                        Width="60px" onclick="btnClear_Click"/>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="width: 350px; height: 40px" align="left">
                                                    <asp:DataGrid ID="grd_bankmaster" runat="server" AutoGenerateColumns="False" 
                                                         Width="700px" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        ondeletecommand="grd_bankmaster_DeleteCommand" 
                                                        oneditcommand="grd_bankmaster_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="intid" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strgroupname" HeaderText="Groups">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn  HeaderText="FeeType" DataField="strfeetype">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intgroups" HeaderText="Groups" Visible="false">
                                                            </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strpaymode" HeaderText="Payable Mode">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strledger" HeaderText="To Ledger">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn  HeaderText="intfeetype" DataField="intfeetype" Visible="false">
                                                            </asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="Edit" 
                                                                
                                                                
                                                                Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="40px" />
                                                            </asp:ButtonColumn>
                                                            <asp:ButtonColumn CommandName="delete" HeaderText="Delete" 
                                                                
                                                                
                                                                Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>
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
    <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>
