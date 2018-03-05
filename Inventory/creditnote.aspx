﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="creditnote.aspx.cs" Inherits="Inventory_creditnote" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/admin_inventory.ascx" tagname="admin_inventory" tagprefix="uc5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
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
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>
    <script type="text/javascript">
        $(function() {
        var dates = $("#txtinvoicedate").datepicker({
                constrainDates: true,
                dateFormat: 'yy/mm/dd',                
                    changeMonth: true,
                    changeYear: true
            });
        });
	</script>   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ajaxtoolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
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
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc5:admin_inventory ID="admin_inventory1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/72.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left"> Credit Note</td>
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
                                                <td  class="title_label">&nbsp; Credit Note</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="5" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblinvoiceno" runat="server" CssClass="s_label" 
                                                                    Text="Invoice No"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtinvoiceno" runat="server" CssClass="s_textbox" 
                                                                    Width="180px" AutoPostBack="false"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">                                                
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbldate" runat="server" CssClass="s_label" 
                                                                    Text="Invoice Date"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtinvoicedate" runat="server" CssClass="s_textbox" 
                                                                    Width="180px" ></asp:TextBox>
                                                                    <%--<ajaxtoolkit:CalendarExtender ID="Calendarextender2" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtinvoicedate" TargetControlID="txtinvoicedate"></ajaxtoolkit:CalendarExtender >--%>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblname" runat="server" CssClass="s_label" 
                                                                    Text="Supplier Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drp_supplier" runat="server" Height="22px" 
                                                                     Width="180px"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblamount" runat="server" CssClass="s_label" 
                                                                    Text="Amount"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtamount" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lbltax" runat="server" CssClass="s_label" 
                                                                    Text="Tax %"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txttax" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">&nbsp;</td>
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
                                                <td align="left" >
                                                    <asp:DataGrid ID="grdcredit" runat="server" AutoGenerateColumns="False" 
                                                        OnDeleteCommand="grdcredit_DeleteCommand" OnEditCommand="grdcredit_EditCommand" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="intid" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strinvoiceno" HeaderText="Invoice No">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="invoicedate" HeaderText="InvoiceDate">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strsuppliername" HeaderText="Supplier Name">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="numamount" HeaderText="Amount"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="numtax" HeaderText="Tax"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dtinvoicedate" HeaderText="Invoice Date" Visible="false"></asp:BoundColumn>
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
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr><td class="break"></td></tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; " align="left" valign="top" >
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>

