<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payments.aspx.cs" Inherits="fee_management_payments" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/Account_menu.ascx" tagname="Account_menu" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
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
            <td style="width: 100%" valign="top">
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
                                        <uc1:Account_menu ID="Account_menu1" runat="server" />
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
                                                <td align="left" > Payments</td>
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
                                                <td><asp:Label ID="lbltitle" runat="server" Text="Payments" CssClass="title_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbl_mode" runat="server" CssClass="s_label" 
                                                                    Text="Mode of Payment"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drp_mode" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="True" 
                                                                    onselectedindexchanged="drp_mode_SelectedIndexChanged">
                                                                    <asp:ListItem Value="-Select-" Selected="True">-Select-</asp:ListItem>
                                                                    <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                                    <asp:ListItem Value="Cheque/DD">Cheque/DD</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr_ledger" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbl_Fromledger" runat="server" CssClass="s_label" 
                                                                    Text="From Ledger"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drp_Fromledger" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="True" 
                                                                    onselectedindexchanged="drp_Fromledger_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trbank" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblbankname" runat="server" CssClass="s_label" Text="Bank Name"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtbankname" runat="server" CssClass="s_textbox" Width="180px" 
                                                                    Enabled="False"></asp:TextBox>
                                                                </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trbranch" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblbranch" runat="server" CssClass="s_label" Text="Branch"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtbranch" runat="server" CssClass="s_textbox" Width="180px" 
                                                                    Enabled="False"></asp:TextBox>
                                                                </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbltogroup" runat="server" CssClass="s_label" 
                                                                    Text="To Group"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drptogroup" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="True" 
                                                                    onselectedindexchanged="drptogroup_SelectedIndexChanged1">
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trledger2" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbltoledger" runat="server" CssClass="s_label" 
                                                                    Text="To Ledger"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drptoledger" runat="server" Height="26px" 
                                                                     Width="180px">
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trstandard2" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblstandard2" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpstandard" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="True" 
                                                                    onselectedindexchanged="drpstandard2_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right"></td>
                                                            <td style="width: 200px; height: 40px" align="left"></td>
                                                        </tr>
                                                        <tr id="trsection" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblsection2" runat="server" CssClass="s_label" Text="Section"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpsection" runat="server" Height="29px" 
                                                                    AutoPostBack="true" onselectedindexchanged="drpsection2_SelectedIndexChanged" 
                                                                    Width="179px"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trstudent2" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblstudentname2" runat="server" CssClass="s_label" 
                                                                    Text="Student Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpstudentname" runat="server" Height="26px" 
                                                                     Width="180px"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trdept2" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbldept2" runat="server" CssClass="s_label" Text="Dept Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpdept" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="true" 
                                                                    onselectedindexchanged="drpdept2_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trdesignation2" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbldesignation2" runat="server" CssClass="s_label" 
                                                                    Text="Designation"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpdesignation" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="true" 
                                                                    onselectedindexchanged="drpdesignation2_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trstaffname2" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblstaffname2" runat="server" CssClass="s_label" 
                                                                    Text="Staff Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpstaffname" runat="server" Height="26px" 
                                                                     Width="180px" AutoPostBack="false"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trchequedate" runat="server">
                                                            <td align="left" class="style1">
                                                                <asp:Label ID="lblcheque" runat="server" CssClass="s_label" 
                                                                    Text="Cheque/DD Date"></asp:Label>
                                                            </td>
                                                            <td align="left" class="style2">
                                                                <asp:TextBox ID="txtchequedate" runat="server" CssClass="s_textbox" 
                                                                    Width="180px"></asp:TextBox>
                                                                 <ajaxtoolkit:CalendarExtender ID="Calendarextender" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" 
                                                                 PopupButtonID="txtchequedate" TargetControlID="txtchequedate">
                                                                </ajaxtoolkit:CalendarExtender >   
                                                                </td>
                                                            <td align="right" class="style1"></td>
                                                            <td align="left" class="style3"></td>
                                                        </tr>
                                                        <tr id="trchequeno" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblchequeno" runat="server" CssClass="s_label" 
                                                                    Text="Cheque/DD Number"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtchequeno" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="txtchequenovalidate" runat="server" ControlToValidate="txtchequeno"
                                                                ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style4">
                                                                <asp:Label ID="lblamount" runat="server" CssClass="s_label" 
                                                                    Text="Amount"></asp:Label>
                                                            </td>
                                                            <td align="left" class="style5">
                                                                <asp:TextBox ID="txtamount" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="amountvalidate" runat="server" ControlToValidate="txtamount"
                                                                ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\s*[+-]?\s*(?:\d{1,3}(?:(,?)\d{3})?(?:\1\d{3})*(\.\d*)?|\.\d+)\s*$">
                                                                </asp:RegularExpressionValidator>                                                    
                                                                </td>
                                                            <td align="right" class="style4"></td>
                                                            <td align="left" class="style5"></td>
                                                        </tr>                                                                                        
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblnarration" runat="server" CssClass="s_label" 
                                                                    Text="Narration"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtnarration" runat="server" CssClass="s_textbox" 
                                                                    Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                                                                    
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Payment" 
                                                                    Width="70px" onclick="btnSave_Click"/>
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
                                                <td align="left">
                                                    <asp:DataGrid ID="grd_trasaction" runat="server" AutoGenerateColumns="False" 
                                                         Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        ondeletecommand="grd_trasaction_DeleteCommand" 
                                                        oneditcommand="grd_trasaction_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="intid" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intschool" HeaderText="school" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strmodeofpayment" HeaderText="Mode" Visible="true"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intfromgroups" HeaderText="From Groups" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="inttogroups" HeaderText="To Groups" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intfromledgers" HeaderText="From Ledger" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="inttoledgers" HeaderText="To Ledger" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intamount" HeaderText="Amount"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strnarration" HeaderText="Narration" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strbankname" HeaderText="Bank" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strbranchname" HeaderText="Branch" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strchequeorddno" HeaderText="Cheque/DD No" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strchequeordddate" HeaderText="Cheque/DD Date" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="fromledger" HeaderText="From Ledger" Visible="true" ></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="toledger" HeaderText="To Ledger" Visible="true"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="transdt" HeaderText="Transaction Date" Visible="true"></asp:BoundColumn>
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
                    <tr>
                        <td class="break"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>
