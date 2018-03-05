<%@ Page Language="C#" AutoEventWireup="true" CodeFile="compose_message.aspx.cs" Inherits="communication_compose_message" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/admin_attendance.ascx" tagname="admin_attendance" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
<%@ Register src="../usercontrol/internal_messaging.ascx" tagname="internal_messaging" tagprefix="uc4" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc5" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Communication</title>
     <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />    
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function() {
            $('#chkAll').click(
             function() {
                 $("INPUT[type='checkbox']").attr('checked', $('#chkAll').is(':checked'));
             });
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
                                        <uc4:internal_messaging ID="internal_messaging1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc5:school_info ID="school_info1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/88.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Compose Mail</td>
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
                                                <td>
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                        <tr class="view_detail_title_bg">
                                                            <td  style="height: 30px" align="left" colspan="3"><asp:Label ID="Labelname" runat="server" CssClass="title_label">Compose Mail</asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="pat1" runat="server" CssClass="s_label" Text="Patron Type"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlpatron" runat="server" Width="150px" 
                                                        CssClass="s_dropdown" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlpatron_SelectedIndexChanged" >
                                                       <asp:ListItem Value= "Select">Select</asp:ListItem>
                                                       <asp:ListItem Value= "Teaching Staffs">Teaching Staffs</asp:ListItem>
                                                        <asp:ListItem Value= "Non Teaching Staff">Non Teaching Staff</asp:ListItem>
                                                         <asp:ListItem Value= "Admin">Admin</asp:ListItem>
                                                       <asp:ListItem Value="Student" Text="Student"></asp:ListItem>
                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr id="trstandard" runat="server" visible="false">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Lablstan" runat="server" Text="Standard" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                    
                                                    <asp:DropDownList ID="ddlstd" runat="server" Width="150px" CssClass="s_dropdown" 
                                                                    AutoPostBack="True" onselectedindexchanged="ddlstd_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr id="trsection" runat="server" visible="false">
                                                            <td align="left" class="style1">
                                                    <asp:Label ID="lblsection" runat="server" CssClass="s_label" Height="23px" 
                                                        Text="Section"></asp:Label>
                                                            </td>
                                                            <td align="left" class="style2">
                                                    <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlsection_SelectedIndexChanged" >
                                                    </asp:DropDownList>
                                                            </td>
                                                            <td align="left" class="style3">
                                                                </td>
                                                        </tr>
                                                        <tr id="trdept" runat="server" visible="false">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Lablsec" runat="server" Text="Department" 
                                                        CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                    
                                                    
                                                    <asp:DropDownList ID="ddldept" runat="server" style="height: 22px" 
                                                        Width="150px" Height="16px" CssClass="s_dropdown" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddldept_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr id="trdesig" runat="server" visible="false">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Lablsec1" runat="server" Text="Designation" 
                                                        CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                    
                                                    
                                                    <asp:DropDownList ID="ddldesig" runat="server" Width="150px" CssClass="s_dropdown" 
                                                                    AutoPostBack="True" onselectedindexchanged="ddldesig_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="lblnames" runat="server" CssClass="s_label" Height="23px" 
                                                        Text="To"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:CheckBox ID="chkAll" runat="server" Text="Check All"/><br />
                                                                <asp:Panel ID="pan" runat="server" Width="520px" BorderWidth="1px" CssClass="s_textbox" Height="100px" ScrollBars="Vertical">
                                                                <asp:CheckBoxList ID="chkgroups" runat="server" RepeatColumns="3"></asp:CheckBoxList>
                                                                </asp:Panel>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="lblsubject" runat="server" CssClass="s_label" Height="23px" 
                                                        Text="Subject"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtsubject" runat="server" CssClass="s_textbox" width="520"></asp:TextBox>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="lblmessage" runat="server" CssClass="s_label" Height="23px" 
                                                        Text="Message"></asp:Label>
                                                            </td>
                                                            <td style="width: 520px;height:300px;" align="left">
                                                                <cc2:Editor ID="txtmessage" runat="server" />
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 40px" align="center" valign="top" colspan="2">
                                                                <asp:Button ID="btnsend" runat="server" CssClass="s_button" Text="Send Mail" 
                                                                    Width="100" onclick="btnsend_Click" />
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                &nbsp;</td>
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
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
            </td>
        </tr>
    </table>
     <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

