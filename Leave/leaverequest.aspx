<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leaverequest.aspx.cs" Inherits="school_leaverequest" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/admin_leave.ascx" tagname="admin_leave" tagprefix="uc1" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

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
                                                <td align="left" > Add / Edit Staff Leave Request</td>
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
                                                <td colspan="6"><asp:Label ID="lbltitle" runat="server" Text="Add / Edit Staff Leave Request" CssClass="title_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <table cellpadding="7" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" style="width: 100px; height: 40px">
                                                                <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Staff Type"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:DropDownList ID="ddlstafftype" runat="server" CssClass="s_dropdown" 
                                                                    Width="140px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlstafftype_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Department"></asp:Label>
                                                                    </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:DropDownList ID="ddldepartment" runat="server" CssClass="s_dropdown" 
                                                                    Width="140px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddldepartment_SelectedIndexChanged">
                                                                   
                                                                </asp:DropDownList>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 100px; height: 40px">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Designation"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:DropDownList ID="ddldesignation" runat="server" CssClass="s_dropdown" 
                                                                    Width="140px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddldesignation_SelectedIndexChanged">
                                                                   
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Staff Name"></asp:Label>
                                                                    </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:DropDownList ID="ddlstaffname" runat="server" CssClass="s_dropdown" 
                                                                    Width="140px" 
                                                                    onselectedindexchanged="ddlstaffname_SelectedIndexChanged" 
                                                                    AutoPostBack="True">
                                                                   
                                                                </asp:DropDownList>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 100px; height: 40px">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="From Date:  "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                               <asp:DropDownList ID="ddlday2" Width="40px" runat="server" CssClass="s_dropdown">
                                                               </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlmonth2" Width="45px" runat="server" 
                                                                    CssClass="s_dropdown">
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
                                                                    CssClass="s_dropdown">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" 
                                                                    Text="To Date: "></asp:Label>
                                                                    </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                 <asp:DropDownList ID="ddlday3" Width="40px" runat="server" CssClass="s_dropdown">
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlmonth3" Width="45px" runat="server" 
                                                                     CssClass="s_dropdown">
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
                                                                <asp:DropDownList ID="ddlyear3" Width="55px" runat="server" 
                                                                     CssClass="s_dropdown">
                                                                </asp:DropDownList>
                                                                    </td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="center" style="width:100%; height: 40px">
                                                                <asp:Button ID="btnsetleave"  runat="server" CssClass="s_button"
                                                                    Text="Set Leave Details" onclick="btnsetleave_Click"/>
                                                            </td>                                                
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="center" style="width:100%; padding-top: 5px; padding-bottom: 10px;">
                                                                <asp:DataList ID="dlavailleave" runat="server" RepeatDirection="Horizontal" RepeatColumns="2" Width="100%" BorderStyle="Dotted" BackColor="#D8D8D8">
                                                                    <ItemTemplate>
                                                                        <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                                            <tr>
                                                                                <td style="width: 200px; height: 30px" class="s_label">
                                                                                    <%# DataBinder.Eval(Container.DataItem, "strleavetype")%> : 
                                                                                </td>
                                                                                <td>
                                                                                   <span style="color:#CB4B1A;font-weight:bold"> <%# DataBinder.Eval(Container.DataItem, "avail")%></span> / <span style="font-weight:bold;color:#5693B4"> <%# DataBinder.Eval(Container.DataItem, "intnoofdays")%></span>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trleavegrid" runat="server">
                                                <td colspan="6" align="left" style="width:100%; height: 40px">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:DataGrid ID="dgleaverequest" runat="server" AutoGenerateColumns="False"                                                         
                                                                    Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="4" 
                                                                    onitemdatabound="dgleaverequest_ItemDataBound">
                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                                    <ItemStyle CssClass="s_datagrid_item"/>
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="strdate" HeaderText="Date">
                                                                            <ItemStyle Width="150px" />
                                                                        </asp:BoundColumn>
                                                                        <asp:TemplateColumn HeaderText="Leave Type">
                                                                            <ItemStyle Width="150px" />
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlleavetype" runat="server" Width="120px"></asp:DropDownList>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn HeaderText="Mode of Leave">
                                                                            <ItemStyle Width="150px" />
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlmodeofleave" runat="server" Width="120px">
                                                                                    <asp:ListItem>Full Day</asp:ListItem>
                                                                                    <asp:ListItem>Half Day - Morning</asp:ListItem>
                                                                                    <asp:ListItem>Half Day - Evening</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="s_datagrid_header"/>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 80px">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Reason:  "></asp:Label>
                                                                </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtreason" runat="server" CssClass="s_textbox" Width="500px" 
                                                                    TextMode="MultiLine" Height="70px" ></asp:TextBox>
                                                                </td>                                                
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center" style="height: 40px">
                                                                <%--<asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" Width="60px" onclick="btnSave_Click"/>--%>
                                                                <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" onclick="btnSave_Click" />
                                                                <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" Width="60px" onclick="btnClear_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>                                                
                                            </tr>
                                            <tr id="trmaingrid" runat="server">
                                                <td colspan="6" align="left" style="width:100%; height: 40px">
                                                    <asp:DataGrid ID="dgleaverequest1" runat="server" AutoGenerateColumns="False"                                                         
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        CellPadding="4" onitemdatabound="dgleaverequest1_ItemDataBound">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                        <ItemStyle CssClass="s_datagrid_item"/>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="name" HeaderText="Staff Name">
                                                                <ItemStyle Width="150px" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="leavetypes" HeaderText="Leave Type">
                                                                <ItemStyle Width="150px" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strdateofrequest" HeaderText="Raised Date"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strfromdate" HeaderText="Date From"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strtodate" HeaderText="Date To"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strreason" HeaderText="Reason" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strrequest" HeaderText="Leave Request"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strstatus" HeaderText="Status"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strrequest1" HeaderText="Cancel Request"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strstatus1" HeaderText="Status"></asp:BoundColumn>
                                                            <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:Button id="btnreject"  runat="server" CausesValidation="false" 
                                                                        CssClass="s_grdbutton" CommandName="button" 
                                                                        Text="Cancel" Font-Bold="True" onclick="btnreject_Click"/>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
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
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>