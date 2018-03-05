<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignsubstitute.aspx.cs" Inherits="substitute_assignsubstitute" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/admin_leave.ascx" tagname="admin_leave" tagprefix="uc1" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/admin_sbstitute.ascx" tagname="admin_sbstitute" tagprefix="uc5" %>
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
                <uc3:topbanner ID="topbanner" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" valign="top">
                <uc2:topmenu ID="topmenu" runat="server" />
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
                                        <uc5:admin_sbstitute ID="admin_sbstitute1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/201.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Assign | Edit Substitute</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                         <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                <ProgressTemplate>
                                                    <div id="progressBackgroundFilter"></div>
                                                        <div id="processMessage">
                                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                                        </div>
                                                </ProgressTemplate>
                                         </asp:UpdateProgress>--%>
                                        <asp:UpdatePanel ID="updatepanal" runat="server" >
                                                <ContentTemplate>
                                                         <table cellpadding="0" cellspacing="0" class="app_container_auto">
                                            <tr>
                                                <td>
                                                    <asp:DataGrid ID="dgassignstaff" runat="server" AutoGenerateColumns="False" Width="100%"                                                         
                                                        BorderStyle="Solid" BorderWidth="1px"  CssClass="s_label" 
                                                        BorderColor="Black" GridLines="Both" 
                                                        onitemdatabound="dgassignstaff_ItemDataBound">
                                                        <AlternatingItemStyle BorderColor="Black" BorderStyle="Solid" 
                                                            BorderWidth="1px" />
                                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                                            ForeColor="White" Height="40px" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intstaff" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="serialno" HeaderText="SL. No"><ItemStyle Width="80px" /></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strleavedate" HeaderText="Leave Date"><ItemStyle Width="100px" /></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strstaffname" HeaderText="Staff Name"><ItemStyle Width="150px" /></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="teachingclass" HeaderText="Teaching Classes"><ItemStyle Width="150px" /></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="teachingsubject" HeaderText="Teaching Subjects"><ItemStyle Width="150px" /></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="status" HeaderText="Status"><ItemStyle Width="150px" /></asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Assign Substitute">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Button id="btnassign"  runat="server" CausesValidation="false" 
                                                                        CssClass="s_grdbutton" CommandName="button" 
                                                                        Text="Assign" onclick="btnassign_Click"  />
                                                                </ItemTemplate>
                                                             </asp:TemplateColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 40px; padding-left: 20px">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 30px; height: 20px; background-color: #4F6228"></td>
                                                            <td style="height: 20px; padding-left: 10px; padding-right: 20px" class="s_label">
                                                                Not Assigned</td>
                                                            <td style="width: 30px; height: 20px; background-color: #C2D69B"></td>
                                                            <td style="height: 20px; padding-left: 10px; padding-right: 20px" class="s_label">
                                                                Not Completely Assigned</td>
                                                            <td style="width: 30px; height: 20px; background-color: #9BBB59"></td>
                                                            <td style="height: 20px; padding-left: 10px" class="s_label">Assigned</td>
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
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top" >
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
        <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>