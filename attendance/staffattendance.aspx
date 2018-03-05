<%@ Page Language="C#" AutoEventWireup="true" CodeFile="staffattendance.aspx.cs" Inherits="attendance_staffattendance" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/admin_attendance.ascx" tagname="admin_attendance" tagprefix="uc1" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
     <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />    
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
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
                                        <uc1:admin_attendance ID="admin_attendance1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/48.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Assign Staff Attendance</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" class="app_container_auto">
                                            <tr>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left" style="width: 150px; height: 40px">
                                                             &nbsp;&nbsp;&nbsp;
                                                             <asp:Label ID="lbldegree0" runat="server" CssClass="s_label" Text="Staff Type"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 175px; height: 40px">
                                                    <asp:DropDownList ID="ddlstafftype" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlstafftype_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 150px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 475px; height: 40px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 150px; height: 40px">
                                                             &nbsp;&nbsp;
                                                             <asp:Label ID="Label56" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 175px; height: 40px">
                                                               <asp:DropDownList ID="ddlday2" Width="40px" runat="server" CssClass="s_dropdown" 
                                                                    AutoPostBack="True" onselectedindexchanged="ddlday2_SelectedIndexChanged">
                                                               </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlmonth2" Width="45px" runat="server" 
                                                                    CssClass="s_dropdown" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlmonth2_SelectedIndexChanged">
                                                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                                <asp:ListItem Value="6">Jun</asp:ListItem>
                                                                <asp:ListItem Value="7">Jul</asp:ListItem>
                                                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                <asp:ListItem Value="12">Dec</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlyear2" Width="55px" runat="server" 
                                                                    CssClass="s_dropdown" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlyear2_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 150px; height: 40px">
                                                                &nbsp;&nbsp;</td>
                                                            <td align="left" style="width: 475px; height: 40px">
                                                                &nbsp;&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trgrid" runat="server" visible="false">
                                                <td align="center">
                                                    <asp:DataGrid ID="dgstudentattend" runat="server" AutoGenerateColumns="False" Width="100%" 
                                                        BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        onitemdatabound="dgstudentattend_ItemDataBound">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                        <ItemStyle CssClass="s_datagrid_item"/>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="false"></asp:BoundColumn>                                                            
                                                            <asp:BoundColumn DataField="strdesignation" HeaderText="Designation"></asp:BoundColumn>                                                            
                                                            <asp:BoundColumn DataField="staffname" HeaderText="Staff Name">
                                                                <ItemStyle Width="180px"/>
                                                            </asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Attendance Status">
                                                                <ItemStyle Width="200px" />
                                                                <ItemTemplate>
                                                                    <asp:RadioButton ID="rbtnpresent" runat="server" Text="Present" GroupName="attendance" Checked="true" CssClass="s_label" /> <asp:RadioButton ID="rbtnabsent" runat="server" Text="Absent" GroupName="attendance" CssClass="s_label"/>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Session">
                                                                <ItemStyle Width="180px" />
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlseasion" runat="server" Width="150px" CssClass="s_textbox">
                                                                        <asp:ListItem>Full Day</asp:ListItem>
                                                                        <asp:ListItem>Half Day - Morning</asp:ListItem>
                                                                        <asp:ListItem>Half Day - Afternoon</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Leave Type">
                                                                <ItemStyle Width="180px" />
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlleavetype" runat="server" Width="150px" CssClass="s_textbox">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Reason For Absent">
                                                                <ItemStyle Width="150px" />
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtreason" runat="server" Width="130px" CssClass="s_textbox"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr id="trbutton" runat="server" visible="false">
                                                <td align="center" style="width: 950px; height: 40px; margin-left: 40px;">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="s_button" Text="Save" 
                                                        Width="60px" onclick="btnSave_Click" Height="27px" />
                                                    &nbsp;
                                                    <asp:Button ID="btncancel" runat="server" CssClass="s_button" Text="Cancel" 
                                                        Width="60px" Height="27px" onclick="btncancel_Click" />
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
