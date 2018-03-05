<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ledger.aspx.cs" Inherits="fee_management_ledger" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/Account_menu.ascx" tagname="Account_menu" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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
    <ajaxtoolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            CombineScripts="True">
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
                                                <td align="left" > Add / Edit Ledger</td>
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
                                                <td ><asp:Label ID="lbltitle" runat="server" Text="Ledger" CssClass="title_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbl_groups" runat="server" CssClass="s_label" 
                                                                    Text="Groups" meta:resourcekey="lbl_groupsResource1"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlgroups" runat="server" CssClass="s_dropdown" 
                                                                    Width="180px" meta:resourcekey="ddlgroupsResource1"></asp:DropDownList>
                                                                </td>
                                                            <td style="width: 150px; height: 40px" align="right"></td>
                                                            <td style="width: 200px; height: 40px" align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbl_ledger" runat="server" CssClass="s_label" 
                                                                    Text="Ledger Name" meta:resourcekey="lbl_ledgerResource1"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtledger" runat="server" CssClass="s_textbox" Width="180px" 
                                                                    meta:resourcekey="txtledgerResource1"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbl_openbalance" runat="server" CssClass="s_label" 
                                                                    Text="Opening Balance" meta:resourcekey="lbl_openbalanceResource1"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtopenbalance" runat="server" CssClass="s_textbox" 
                                                                    Width="180px" meta:resourcekey="txtopenbalanceResource1"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="validateopenbalance" runat="server" ControlToValidate="txtopenbalance"
                                                                ErrorMessage="Please Enter Only Numbers" 
                                                                    ValidationExpression="^\s*[+-]?\s*(?:\d{1,3}(?:(,?)\d{3})?(?:\1\d{3})*(\.\d*)?|\.\d+)\s*$" 
                                                                    meta:resourcekey="validateopenbalanceResource1"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbl_opendate" runat="server" CssClass="s_label" 
                                                                    Text="Opening Date" meta:resourcekey="lbl_opendateResource1"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtopendate" runat="server" CssClass="s_textbox" Width="180px" 
                                                                    meta:resourcekey="txtopendateResource1"></asp:TextBox>
                                                                <ajaxtoolkit:CalendarExtender ID="Calendarextender" runat="server" 
                                                                    CssClass="cal_Theme1" Format="yyyy/MM/dd" 
                                                                 PopupButtonID="txtopendate" TargetControlID="txtopendate" Enabled="True">
                                                                </ajaxtoolkit:CalendarExtender >
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbl_address" runat="server" CssClass="s_label" 
                                                                    Text="Address" meta:resourcekey="lbl_addressResource1"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtaddress" runat="server" CssClass="s_textbox" Width="180px" 
                                                                    TextMode="MultiLine" meta:resourcekey="txtaddressResource1"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbl_phoneno" runat="server" CssClass="s_label" 
                                                                    Text="Phone Number" meta:resourcekey="lbl_phonenoResource1"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtphoneno" runat="server" CssClass="s_textbox" Width="180px" 
                                                                    meta:resourcekey="txtphonenoResource1"></asp:TextBox>
                                                                <asp:regularexpressionvalidator id="phonenoVALIDATE" 
                                                                    controltovalidate="txtphoneno" validationexpression="^[\d\s\(\)\-\+]+$"
                                                                        display="Dynamic" ErrorMessage="Enter proper number" runat="server" 
                                                                    meta:resourcekey="phonenoVALIDATEResource1"></asp:regularexpressionvalidator>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbl_mobile" runat="server" CssClass="s_label" 
                                                                    Text="Mobile Number" meta:resourcekey="lbl_mobileResource1"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtmobile" runat="server" CssClass="s_textbox" Width="180px" 
                                                                    meta:resourcekey="txtmobileResource1"></asp:TextBox>
                                                                <asp:RegularExpressionValidator id="mobileValidate" runat="server" ControlToValidate="txtmobile" 
                                                                  ErrorMessage="Enter Mobile number" 
                                                                  ValidationExpression="^[\d\s\(\)\-\+]+$" 
                                                                    meta:resourcekey="mobileValidateResource1"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lbl_email" runat="server" CssClass="s_label" 
                                                                    Text="E-mail Id" meta:resourcekey="lbl_emailResource1"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtemail" runat="server" CssClass="s_textbox" Width="180px" 
                                                                    meta:resourcekey="txtemailResource1"></asp:TextBox>
                                                            <asp:RegularExpressionValidator id="mailid" runat="server" ControlToValidate="txtemail" 
                                                                  ErrorMessage="Enter an email address" 
                                                                  ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                                    meta:resourcekey="mailidResource1"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Button ID="btn_Save" runat="server" CssClass="s_button" Text="Save" 
                                                                    Width="60px" onclick="btnSave_Click" meta:resourcekey="btn_SaveResource1"/>
                                                                &nbsp;
                                                                <asp:Button ID="btn_Clear" runat="server" CssClass="s_button" Text="Clear" 
                                                                    Width="60px" onclick="btnClear_Click" 
                                                                    meta:resourcekey="btn_ClearResource1" />
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:DataGrid ID="dgd_ledger" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        ondeletecommand="dgd_ledger_DeleteCommand" 
                                                        oneditcommand="dgd_ledger_EditCommand" 
                                                        meta:resourcekey="dgd_ledgerResource1">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="intid" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strgroupname" HeaderText="Groups">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strledgername" HeaderText="Ledger">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intopeningbalance" HeaderText="Opening Balance">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dates" HeaderText="Date" Visible="false">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="straddress" HeaderText="Address">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strphone" HeaderText="Phone" >
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strmobileno" HeaderText="Mobile">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="stremailid" HeaderText="E-mail" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intschool" HeaderText="schoolID" Visible="False" >
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intgroup" HeaderText="intgroup" Visible="False" >
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dtopeningdate" HeaderText="Date" Visible="false" >
                                                            </asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="Edit"                                                                
                                                                Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;" 
                                                                meta:resourcekey="ButtonColumnResource1">
                                                                <ItemStyle Width="40px" />
                                                            </asp:ButtonColumn>
                                                            <asp:ButtonColumn CommandName="delete" HeaderText="Delete"                                                                 
                                                                Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;" 
                                                                meta:resourcekey="ButtonColumnResource2">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>
                                                            </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header"/>
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
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox1" 
            style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" 
            runat="server" meta:resourcekey="MsgBox1Resource1"></cc1:msgBox>
    </div>
    </form>
</body>
</html>

