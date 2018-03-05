<%@ Page Language="C#" AutoEventWireup="true" CodeFile="returnbill.aspx.cs" Inherits="Inventory_returnbill" %>
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
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>    
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
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Return Bills</td>
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
                                                <td colspan="4" class="title_label">&nbsp;Return Bills</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblbillno" runat="server" CssClass="s_label" Text="Bill.No"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtbillno" runat="server" CssClass="s_textbox" Width="180px" 
                                                                    AutoPostBack="True" ontextchanged="txtbillno_TextChanged"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblpatron" runat="server" CssClass="s_label" Text="Patron"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drppatron" runat="server" Height="26px" 
                                                                     Width="180px" onselectedindexchanged="drppatron_SelectedIndexChanged">
                                                                    <asp:ListItem Value="Student">Student</asp:ListItem>
                                                                    <asp:ListItem Value="Teaching Staff">Teaching Staff</asp:ListItem>
                                                                    <asp:ListItem Value="Non-Teaching Staff">Non-Teaching Staff</asp:ListItem>
                                                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trstd" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblstandard" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpstandard" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="false"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right"></td>
                                                            <td style="width: 200px; height: 40px" align="left"></td>
                                                        </tr>
                                                        <tr id="trsec" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblsection" runat="server" CssClass="s_label" Text="Section"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpsection" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="false"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trstdname" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblStudentname" runat="server" CssClass="s_label" 
                                                                    Text="Student Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpstudentname" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="false"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trdept" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbldept" runat="server" CssClass="s_label" Text="Dept Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpdept" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="false"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trdesig" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbldesignation" runat="server" CssClass="s_label" 
                                                                    Text="Designation"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpdesignation" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="false"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trstaff" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblstaffname" runat="server" CssClass="s_label" 
                                                                    Text="Staff Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpstaffname" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="false"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblcategory" runat="server" CssClass="s_label" Text="Category"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpcategory" runat="server" Height="26px" 
                                                                     Width="180px" onselectedindexchanged="drpcategory_SelectedIndexChanged" 
                                                                    AutoPostBack="True" ></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblitems" runat="server" CssClass="s_label" Text="Items"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpitems" runat="server" Height="26px" 
                                                                     Width="180px" onselectedindexchanged="drpitems_SelectedIndexChanged" 
                                                                    AutoPostBack="True"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblprice" runat="server" CssClass="s_label" 
                                                                    Text="Price"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtprice" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblsold" runat="server" CssClass="s_label" 
                                                                    Text="Sold Qty"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblsoldqty" runat="server" CssClass="s_label" 
                                                                    Text="Sold Qty"></asp:Label>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbldiscount" runat="server" CssClass="s_label" 
                                                                    Text="Discount"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtdiscount" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblreturnqty" runat="server" CssClass="s_label" 
                                                                    Text="ReturnQty"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtreturnquantity" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;
                                                                <asp:Button ID="btnreturn" runat="server" CssClass="s_button" Text="Return" 
                                                                    Width="60px" onclick="btnreturn_Click"/>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 40px" align="left">
                                                    <asp:DataGrid ID="grdreturnitems" runat="server" AutoGenerateColumns="False" 
                                                         Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                        <ItemStyle CssClass="s_datagrid_item"/>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="id" HeaderText="intid" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strcategory" HeaderText="Category"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="stritemname" HeaderText="Items"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intprice" HeaderText="Price"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intqty" HeaderText="Quantity"></asp:BoundColumn>
                                                            <asp:BoundColumn  HeaderText="Total" DataField="total"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intdiscount" HeaderText="Discount"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intcategory" HeaderText="Cat" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intitem" HeaderText="Items" Visible="False"></asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="Edit"
                                                                Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;" 
                                                                Visible="False">
                                                                <ItemStyle Width="40px" /></asp:ButtonColumn>
                                                            <asp:ButtonColumn CommandName="delete" HeaderText="Delete" 
                                                                Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;" 
                                                                Visible="False">
                                                                <ItemStyle Width="50px" /></asp:ButtonColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
                                             </tr>
                                             <tr>
                                                <td colspan="4">
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbltotalamount" runat="server" CssClass="s_label" 
                                                                    Text="Total Amount"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left"> 
                                                                <asp:TextBox ID="txttotalamount" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                                    </td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbltotaldiscount" runat="server" CssClass="s_label" 
                                                                    Text="Total Discount"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left"> 
                                                                <asp:TextBox ID="txttotaldiscount" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="left">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblreturnamount" runat="server" CssClass="s_label" 
                                                                    Text="Return Amount"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtreturnamount" runat="server" CssClass="s_textbox" 
                                                                    Width="180px" BorderWidth="5px"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="left">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="right">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;
                                                                <asp:Button ID="btnfinal" runat="server" CssClass="s_button" Text="Finalize" 
                                                                    Width="60px" onclick="btnfinal_Click"/>&nbsp;
                                                                <asp:Button ID="btnrepay" runat="server" CssClass="s_button" Text="Re-pay" 
                                                                    Width="60px" onclick="btnrepay_Click"/>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="left">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
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
                </table>
            </td>
        </tr>
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>

