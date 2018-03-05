<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignstaffleave.aspx.cs" Inherits="Leave_assignstaffleave" %>

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
    <script language="javascript" type="text/javascript">
        function truncnoofdays()
        {
            var val1 = document.getElementById('txtnoofdays').value;
            var val2 = document.getElementById('txtnoofdays0').value;
            if (IsNumeric(val1) == true) {
                if (val1.indexOf("0") >-1 && val1.length == 1) {
                    val1 = "";
                    document.getElementById('txtnoofdays').value = val1;
                }
                else {
                    if (val1.indexOf(".") > -1) {
                        if (val1.length > val1.indexOf(".") + 2) {
                            val1 = val1.substring(0, val1.indexOf(".") + 2);
                        }
                        document.getElementById('txtnoofdays').value = val1;
                    }
                }
                document.getElementById('txtnoofdays0').value = val1;
            }
            else {
                if (val1.length < val2.length) {
                    if (val1.indexOf(".") > -1) {
                        val1 = val1.substring(0, val1.indexOf("."));
                        document.getElementById('txtnoofdays').value = val1;
                    }
                }
                else {
                    if (val1.indexOf(".") > -1 && val1.length == val1.indexOf(".")+1) {
                        val1 = val1 + '5';
                        document.getElementById('txtnoofdays').value = val1;
                    }
                    else {
                        val1 = val1.substring(0, val1.length-1);
                        document.getElementById('txtnoofdays').value = val1;
                    }
                }
                document.getElementById('txtnoofdays0').value = val1;
            }
        }
        function IsNumeric(input) { var RE = /^-{0,1}\d*\.{0,1}\d+$/; return (RE.test(input)); } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
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
                                        <uc1:admin_leave ID="admin_leave" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/55.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Assign Staff&#39;s Leave Category</td>
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
                                                <td><asp:Label ID="lbltitle" runat="server" Text="Leave Category" CssClass="title_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Lbldept" runat="server" CssClass="s_label" Text="Department"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpdept" runat="server" Height="25px"  
                                                                    Width="180px" AutoPostBack="True" 
                                                                    onselectedindexchanged="drpdept_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left"></td>
                                                        </tr>
                                                        <tr id="trpay" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Lbldesignation" runat="server" CssClass="s_label" 
                                                                    Text="Designation"></asp:Label>
                                                            </td>
                                                            <td style="width: 0px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpdesignation" runat="server" Height="25px" 
                                                                    onselectedindexchanged="drpdesignation_SelectedIndexChanged" Width="180px" 
                                                                    AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr id="trunpay" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Lblstaffname" runat="server" CssClass="s_label" 
                                                                    Text="Staff Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 0px; height: 40px" align="left">
                                                                <asp:DropDownList ID="drpstaffname" runat="server" Height="25px" Width="180px" 
                                                                    AutoPostBack="True" onselectedindexchanged="drpstaffname_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Lblleavecategory" runat="server" CssClass="s_label" 
                                                                    Text="Leave Category"></asp:Label>
                                                            </td>
                                                                <td  style="width: 200px; height: 40px" align="left">
                                                                    <asp:DropDownList ID="drpleavecategory" runat="server" Height="25px" 
                                                                        Width="180px">
                                                                       
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 30px" align="left">&nbsp;</td>
                                                            <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Lblnoofdays" runat="server" CssClass="s_label" Text="No Of Days"></asp:Label>
                                                            </td>
                                                            <td  style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtnoofdays" runat="server" CssClass="s_textbox" Width="180px" OnKeyUp="truncnoofdays()"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 30px" align="left">
                                                                <asp:TextBox ID="txtnoofdays0" runat="server" 
                                                                    Width="0px" BorderStyle="None" BorderWidth="0px" ForeColor="White"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                            </td>
                                                                <td  style="width: 200px; height: 40px" align="left">
                                                                <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                                    Width="60px" onclick="btnSave_Click"/>
                                                                <asp:Button ID="btncancel" runat="server" CssClass="s_button" Text="Cancel" 
                                                                    Width="60px" onclick="btnClear_Click" />
                                                                </td>
                                                            <td style="width: 150px; height: 30px" align="left">&nbsp;</td>
                                                            <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:DataGrid ID="grdleavecategory" runat="server" AutoGenerateColumns="False" 
                                                         OnEditCommand="grdleavecategory_EditCommand" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="4">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="id" HeaderText="intid" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intstaffid" HeaderText="staffname" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intleavecategory" HeaderText="Leave Category" 
                                                                Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strleavetype" HeaderText="Leave Category"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intnoofdays" HeaderText="No Of Days" DataFormatString="{0:0.0}">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intdepartment" HeaderText="dept" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intdesignation" HeaderText="designation" 
                                                                Visible="False"></asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="40px" />
                                                            </asp:ButtonColumn>
                                                            <asp:TemplateColumn HeaderText="Delete">
                                                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btndelete" runat="server" 
                                                                        ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                                    OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                                        onclick="btndelete_Click"  />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete"  Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>--%>
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
