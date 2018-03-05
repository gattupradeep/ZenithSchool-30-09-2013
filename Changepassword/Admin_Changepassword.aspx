<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Changepassword.aspx.cs" Inherits="Changepassword_Admin_Changepassword" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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
    
    </head>
<body onload="autowidth();" >
    <form id="form1" runat="server">
    <div>
        <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></ajaxtoolkit:toolkitscriptmanager>
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
                                    <td class="break">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:1%" valign="top">
                        </td>
                        <td style="width: 93%;" valign="top" align="left" >
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/326.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Change Password</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="5" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="6" >
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Change Password" ></asp:Label>
                                                </td>                                                
                                            </tr>
                                            <tr >
                                                <td style="width: 100px;" >
                                                    <asp:Label ID="Label7" runat="server" Text="Patron Type" CssClass="s_label"></asp:Label></td>
                                                <td colspan="5" align="left" >
                                                    <asp:DropDownList ID="ddlpatrontype" runat="server" CssClass="s_dropdown" 
                                                        AutoPostBack="True" 
                                                        onselectedindexchanged="ddlpatrontype_SelectedIndexChanged" >
                                                        <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
                                                        <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                                                        <asp:ListItem Text="Parents" Value="Parents"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr id="trstudentdetails" runat="server">
                                                <td >
                                                    <asp:Label ID="lblstudentname0" runat="server" Text="Class&amp;Sec" 
                                                        CssClass="s_label"></asp:Label></td>
                                                <td >
                                                    <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_dropdown" 
                                                        AutoPostBack="True" onselectedindexchanged="ddlclass_SelectedIndexChanged" ></asp:DropDownList></td>
                                                <td >
                                                    <asp:Label ID="lblstudentname" runat="server" Text="Student Name" 
                                                        CssClass="s_label"></asp:Label></td>
                                                <td><asp:DropDownList ID="ddlstudent" runat="server" CssClass="s_dropdown" 
                                                        AutoPostBack="True" onselectedindexchanged="ddlstudent_SelectedIndexChanged" ></asp:DropDownList></td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr id="trstaffdetailes" runat="server">
                                                <td style="width:100px"><asp:Label ID="Label4" runat="server" Text="Staff Type" 
                                                        CssClass="s_label"></asp:Label></td>
                                                <td ><asp:DropDownList ID="ddlstafftype" runat="server" 
                                                        CssClass="s_dropdown" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlstafftype_SelectedIndexChanged"></asp:DropDownList></td>
                                                <td><asp:Label ID="Label5" runat="server" Text="Department" CssClass="s_label"></asp:Label></td>
                                                <td><asp:DropDownList ID="ddldepartment" runat="server" CssClass="s_dropdown" 
                                                        AutoPostBack="True" onselectedindexchanged="ddldepartment_SelectedIndexChanged"></asp:DropDownList></td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Staff Name" 
                                                        CssClass="s_label"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlstaff" runat="server" CssClass="s_dropdown" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlstaff_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="trchangepwd" runat="server" visible="false">
                                                <td><asp:Label ID="Label2" runat="server" Text="New Password" CssClass="s_label"></asp:Label></td>
                                                <td ><asp:TextBox ID="txtnewpassword" runat="server" CssClass="s_textbox" TextMode="Password" AutoCompleteType="None" ></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnewpassword"
                                                        ErrorMessage="Enter Password" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                                </td>
                                                <td><asp:Label ID="Label3" runat="server" Text="Confirm Password" CssClass="s_label"></asp:Label></td>
                                                <td><asp:TextBox ID="txtconfirmpassword" runat="server" CssClass="s_textbox" TextMode="Password" AutoCompleteType="None" ></asp:TextBox>
                                                    <br />
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                        ControlToCompare="txtnewpassword" ControlToValidate="txtconfirmpassword" 
                                                        ErrorMessage="Password mismatch" Font-Size="Smaller"></asp:CompareValidator>
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr id="trchangepwd2" runat="server" visible="false">
                                                <td colspan="6" align="center"><asp:Button ID="btnChangepwd" runat="server" 
                                                        Text="Change Password" CssClass="s_button" onclick="btnChangepwd_Click" /></td>
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