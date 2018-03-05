<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showsecondlanguage.aspx.cs" Inherits="timetable_showsecondlanguage" %>

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
</head>
<body style="margin-top: 20px">
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="450" class="curve" align="center">
            <tr class="timetable_daysheader">
                <td style="height: 40px; padding-left: 15px" align="left" class="title_label">
                    <asp:Label ID="lbltitle" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 40px; font-weight: bold; padding-left: 15px" align="left" class="s_label">
                    <asp:Label ID="Label6" runat="server" CssClass="s_label" 
                        Text="Select Room(alloted to standard &amp; section)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 30px;width:100%;" align="left" colspan="4">
                    <asp:DataGrid ID="dg2" runat="server" AutoGenerateColumns="False" 
                        BorderStyle="None" BorderWidth="0px" GridLines="None" Width="600px"> 
                        <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                        <ItemStyle CssClass="s_datagrid_item"/>
                            <Columns>
                                <asp:BoundColumn DataField="strlanguage2" HeaderText="Subject" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                <asp:BoundColumn DataField="strstandard" HeaderText="standard"></asp:BoundColumn>
                                <asp:BoundColumn DataField="strsection" HeaderText="section"></asp:BoundColumn>
                                <asp:BoundColumn DataField="strteachername" HeaderText="Teacher"></asp:BoundColumn>
                            </Columns>
                        <HeaderStyle CssClass="s_datagrid_header"/>
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td style="height: 40px; font-weight: bold" align="center" class="s_label">
                    <asp:Button ID="btncancel" runat="server" CssClass="s_button" 
                        Text="Close" onclick="btncancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
