<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feestructure.aspx.cs" Inherits="feemanagement_feestructure" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/admin_inventory.ascx" tagname="admin_inventory" tagprefix="uc5" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/feemanagement.ascx" tagname="feemanagement" tagprefix="uc1" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server"></asp:ToolkitScriptManager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr><td style="width: 100%;" align="left"><uc3:topbanner ID="topbanner1" runat="server" /></td></tr>
        <tr><td style="width: 100%;" valign="top"><uc2:topmenu ID="topmenu1" runat="server" /></td></tr>
        <tr>
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="230">
                                <tr><td style="width: 230px; height: 15px" align="right"><uc1:feemanagement ID="feemanagement1" runat="server" /></td></tr>
                                <tr><td style="width: 230px; height: 15px" align="right"></td></tr>
                                <tr><td style="width: 230px" align="right"><uc4:school_info ID="school_info1" runat="server" /></td></tr>
                            </table>
                        </td>
                        <td style="width: 2%" valign="top"></td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title"><td style="width: 100%; " align="left"><table cellpadding="0" cellspacing="0" border="0" ><tr><td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td><td align="left">Fee Structure</td></tr></table></td></tr>
                                <tr><td class="break"></td></tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                       <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                         <ProgressTemplate><div id="progressBackgroundFilter"></div><div id="processMessage"><img alt="Loading" src="../media/images/Processing.gif" /></div></ProgressTemplate>
                                       </asp:UpdateProgress>
                                       <asp:UpdatePanel ID="updatepanal" runat="server" >
                                       <ContentTemplate> 
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr>
                                                <td style="width: 100%; height: 40px ;" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td valign="top">
                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td style="width:30%; height: 40px">
                                                                            <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
                                                                                <tr><td style="width:50%; height: 40px" align="left"><asp:Label ID="lblYear" runat="server" Text="year" CssClass="s_label"></asp:Label></td><td style="width:50%; height: 40px" align="left"><asp:DropDownList ID="ddlYear" runat="server" CssClass="s_dropdown" AutoPostBack="true" onselectedindexchanged="ddlYear_SelectedIndexChanged1"></asp:DropDownList></td></tr>
                                                                            </table>
                                                                        </td><td style="width:70%; height: 40px" align="left"></td>
                                                                    </tr>
                                                                    <tr class="view_detail_title_bg">
                                                                        <td align="left" style="width:30%">
                                                                            <asp:Label CssClass="title_label" ID="Label1" runat="server" Text="Particulars" ></asp:Label>
                                                                        </td>
                                                                        <td valign="bottom" align="left" style="width:70%">
                                                                            <asp:DataList ID="dlstandard" runat="server" RepeatDirection="Horizontal" Width="100%" BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" ShowHeader="False" Font-Bold="True" Font-Size="X-Large">
                                                                                <ItemTemplate><table cellpadding="0" cellspacing="0" border="0" width="71"><tr><td style="width:1px"></td><td style=" height:40px; width:70px" align="center" class="s_datagrid_header"><%# DataBinder.Eval(Container.DataItem, "Class")%></td></tr></table></ItemTemplate>
                                                                            </asp:DataList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="width:100%; height: 40px" align="left">
                                                                            <asp:DataGrid ID="grdfeemode" runat="server" AutoGenerateColumns="false" BorderStyle="None" BorderWidth="0px" GridLines="None" ShowHeader="False" Width="100%" onitemdatabound="grdfeemode_ItemDataBound">
                                                                                <Columns>
                                                                                    <asp:BoundColumn DataField="FeemodeID" Visible="false"></asp:BoundColumn>
                                                                                    <asp:TemplateColumn>
                                                                                        <ItemTemplate>
                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                                <tr>
                                                                                                    <td style="width: 100%" align="left" valign="top">
                                                                                                        <asp:DataGrid ID="grdparticular" runat="server" AutoGenerateColumns="False" ShowHeader="False" onitemdatabound="grdparticular_ItemDataBound"><AlternatingItemStyle /><ItemStyle />
                                                                                                            <Columns>
                                                                                                                 <asp:BoundColumn DataField="FeemodeID" Visible="false"></asp:BoundColumn>
                                                                                                                <asp:BoundColumn DataField="FeemodeName"><ItemStyle Width="250px" Height="30px" Font-Size="12px"/></asp:BoundColumn>
                                                                                                                <asp:TemplateColumn><ItemStyle HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:DataList ID="dlstandardfee" runat="server" RepeatDirection="Horizontal" BorderStyle="Solid" BorderWidth="0px" CellPadding="0" ShowFooter="False" ShowHeader="False">
                                                                                                                            <ItemTemplate>
                                                                                                                                <table cellpadding="0" cellspacing="0" border="0" width="71"><tr><td style="height: 30px; font-size:12px; border-left:1px solid black; width: 100%" align="center"><%# DataBinder.Eval(Container.DataItem, "Amount")%></td></tr></table>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:DataList>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateColumn>
                                                                                                            </Columns>
                                                                                                        </asp:DataGrid>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                </Columns>
                                                                                <HeaderStyle CssClass="s_datagrid_header" />
                                                                            </asp:DataGrid>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
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
        <tr><td style="width: 100%" valign="top"><uc6:app_footer ID="footer" runat="server" /></td></tr>
    </table>
    </div>
    </form>
</body>
</html>


