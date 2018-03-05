<%@ Page Language="C#" AutoEventWireup="true" CodeFile="setuserrights.aspx.cs" Inherits="role_setuserrights" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/admin_role.ascx" tagname="admin_role" tagprefix="uc1" %>
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
<body>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
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
                                        <uc1:admin_role ID="admin_role1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/79.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Set User Rights</td>
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
                                                         <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr>
                                                <td style="width: 710px" align="center">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="710">
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="User Type :  "></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                    <asp:DropDownList ID="ddltype" runat="server" CssClass="s_dropdown" 
                                                                        Width="130px" AutoPostBack="True" 
                                                                        onselectedindexchanged="ddltype_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px"></td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Staff Name :"></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                    <asp:DropDownList ID="ddlstaff" runat="server" CssClass="s_dropdown" 
                                                                        Width="130px" AutoPostBack="True" 
                                                                        onselectedindexchanged="ddlstaff_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px"></td>
                                                        </tr>                                                        
                                                        <tr>
                                                            <td style="height: 40px" align="left" class="s_label" colspan="6">
                                                                <strong>Choose Modules</strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 40px" align="left" colspan="6" valign="top" class="s_label">
                                                                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Justify"
                                                                    Width="710px">
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="border" colspan="6" valign="top">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 700px; height: 40px;" align="center">
                                                    <asp:Button ID="btnsave" runat="server" Font-Bold="False"
                                                        Height="25px" OnClick="btnsave_Click" Text="Save" 
                                                        CssClass="s_button" Width="60px" />
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
                    <tr>
                        <td class="break"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; " align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
