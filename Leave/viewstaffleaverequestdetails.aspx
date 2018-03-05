<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewstaffleaverequestdetails.aspx.cs" Inherits="Leave_viewstaffleaverequestdetails" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/admin_leave.ascx" tagname="admin_leave" tagprefix="uc1" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {

            $("ul#topnav li").hover(function() { //Hover over event on list item
                $(this).css({ 'background': '#88BB00 url(topnav_active.gif) repeat-x' }); //Add background color + image on hovered list item
                $(this).find("span").show(); //Show the subnav
            }, function() { //on hover out...
                $(this).css({ 'background': 'none' }); //Ditch the background
                $(this).find("span").hide(); //Hide the subnav
            });

        });
    </script>
    <style type="text/css">
        td { height: 30px; width: 175px;}
    * {
	color: #666;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" class="curve">
            <tr>
                <td style="padding: 20px 20px 20px 20px">
                <asp:Panel ID="panel" runat="server" width="710" Height="340" ScrollBars="Vertical">
                    <table cellpadding="0" cellspacing="0" width="710">
                        <tr style="background-color:#DEE7D4">
                            <td colspan="4" align="left" style="height: 30px">
                                <asp:Label ID="Label21" runat="server" CssClass="s_label" 
                                    Text="Leave Request Details" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 175px; height: 30px">
                                <asp:Label ID="lblstafftype" runat="server" CssClass="s_label" Height="23px" 
                                    Text="Staff Type :" Font-Bold="True"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblstafftype1" runat="server" CssClass="s_label" Height="23px" 
                                    Text="Staff Type:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblstaffname" runat="server" CssClass="s_label" Height="23px" 
                                    Text="Staff Name :" Font-Bold="True"></asp:Label>
                             </td>
                            <td align="left">
                                <asp:Label ID="lblstaffname1" runat="server" CssClass="s_label" Height="23px" 
                                    Text="Staffname"></asp:Label>
                             </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lbldept" runat="server" CssClass="s_label" Height="23px" 
                                    Text="Department :" Font-Bold="True"></asp:Label>
                             </td>
                            <td align="left">
                                <asp:Label ID="lbldept1" runat="server" CssClass="s_label" Height="23px" 
                                    Text="department"></asp:Label>
                             </td>
                            <td align="left">
                                <asp:Label ID="lbldesig" runat="server" CssClass="s_label" Height="23px" 
                                    Text="Designation :" Font-Bold="True"></asp:Label>
                             </td>
                            <td align="left">
                                <asp:Label ID="lbldesig1" runat="server" CssClass="s_label" Height="23px" 
                                    Text="Designation"></asp:Label>
                             </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblrequestdate" runat="server" CssClass="s_label" Height="23px" 
                                    Text="Request Raised Date :" Font-Bold="True"></asp:Label>
                             </td>
                            <td align="left">
                                <asp:Label ID="lblrequestdate2" runat="server" CssClass="s_label" Height="23px" 
                                    Text="Request Date"></asp:Label>
                             </td>
                            <td align="left">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 710px">
                                <asp:DataGrid ID="dgleaverequest1" runat="server" AutoGenerateColumns="False"                                                         
                                    Width="100%" BorderStyle="None" BorderWidth="0px" 
                                    GridLines="None" CellPadding="4">
                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                    <ItemStyle CssClass="s_datagrid_item"/>
                                    <Columns>
                                        <asp:BoundColumn DataField="strleavedate" HeaderText="Leave Required On" HeaderStyle-ForeColor="White">
                                            <ItemStyle Width="150px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="strleavetype" HeaderText="Leave Type" HeaderStyle-ForeColor="White">
                                            <ItemStyle Width="150px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="strsession" HeaderText="Session" HeaderStyle-ForeColor="White">
                                            <ItemStyle Width="150px" />
                                        </asp:BoundColumn>
                                    </Columns>
                                    <HeaderStyle CssClass="s_datagrid_header"/>
                                </asp:DataGrid>
                            </td>
                        </tr>
                        <tr style="background-color:#DEE7D4">
                            <td align="left" colspan="4" width="710px">
                                <asp:Label ID="lblreason" runat="server" CssClass="s_label" Height="23px" 
                                    Text="Reason" Font-Bold="True"></asp:Label>
                             </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="width: 710px; padding: 10px 0px 10px 0px">
                                <asp:Label ID="lblreason1" runat="server" CssClass="s_label" Height="23px"></asp:Label>
                                <asp:TextBox ID="txtreason" runat="server" CssClass="s_textbox" Width="500px" 
                                    Visible="False"></asp:TextBox>
                             </td>
                        </tr>
                        <tr id="trreject" runat="server">
                            <td colspan="4" style="width: 710px; padding: 10px 0px 10px 0px" align="center">
                                <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Reject" 
                                    onclick="btnSave_Click"/>
                             </td>
                        </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

