<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search_view_Contractor.aspx.cs" Inherits="transport_Search_view_Contractor" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/admin_transport.ascx" tagname="admin_transport" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <style type="text/css">
        .style1
        {
            font-family: Trebuchet MS, arial;
            font-size: small;
            font-weight: 700;
            color: #282727;
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div><table cellpadding="0" cellspacing="0" border="0" width="100%">
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
                                        <uc1:admin_transport ID="admin_transport1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/113.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Search / View Contractor </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                           <%-- <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                              <ProgressTemplate>
                                                <div id="progressBackgroundFilter"></div>
                                                <div id="processMessage">
                                                    <img alt="Loading" src="../media/images/Processing.gif" />
                                                </div>
                                             </ProgressTemplate>
                                            </asp:UpdateProgress>
                                           <asp:UpdatePanel ID="updatepanal" runat="server" >
                                         <ContentTemplate>--%>
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" class="title_label">&nbsp;Search / View Contractor</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table cellpadding="7" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="lblcontractor" runat="server" CssClass="s_label" Text="Contractor Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlcontractor" runat="server" CssClass="s_dropdown" Width="150px"
                                                                    onselectedindexchanged="ddlcontractor_SelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left"></td>
                                                        </tr>                                                                                                                
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="viewdriverdetails" runat="server" visible="false">
                                                <td colspan="4">
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                        <tr class="view_detail_subtitle_bg" >
                                                            <td colspan="4" class="style1">Contractor Details</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Contractor Name :"></asp:Label></td>
                                                            <td ><asp:Label ID="txtcontractorname" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                            <td align="right"><asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Address :"></asp:Label></td>
                                                            <td ><asp:Label ID="txtaddress" runat="server" CssClass="s_label_value" Text="Contractor Name"></asp:Label></td>
                                                        </tr> 
                                                        <tr>
                                                            <td align="right"><asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Contact No :"></asp:Label></td>
                                                            <td><asp:Label ID="txtcontactdetails" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td align="right"><asp:Label ID="Label4" runat="server" CssClass="s_label" Text="No of Vehicle in School :"></asp:Label></td>
                                                            <td><asp:Label ID="txtnoofvehicle" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                        </tr> 
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:DataGrid ID="dgvehicledetails" runat="server" AutoGenerateColumns="false" Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                                <AlternatingItemStyle />
                                                                <ItemStyle />    
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="strbrand" HeaderText="Make"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strmodel" HeaderText="Model"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strvehicleno" HeaderText="Vehicle No"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strregno" HeaderText="strregno"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strengineno" HeaderText="Engine No"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strchassisno" HeaderText="Chassis No"></asp:BoundColumn>
                                                                    </Columns>
                                                                <HeaderStyle CssClass="view_detail_title_bg" />    
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>  
                                                        <tr id="trback" runat="server"><td colspan="4">
                                                            <asp:Button ID="btnback" runat="server" Text="Back" CssClass="s_button" 
                                                                onclick="btnback_Click" />
                                                            </td></tr>                                                                                                            
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trgrid" runat="server">
                                                <td colspan="4" align="left">
                                                    <asp:DataGrid ID="dgowner" runat="server" AutoGenerateColumns="False"                                                        
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        oneditcommand="dgowner_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strownername" HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="address" HeaderText="Address"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strcountry" HeaderText="Country"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="contact" HeaderText="Contact"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="View"  Text="&lt;img src=&quot;../media/images/view.gif&quot; alt=&quot;View&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>                                                
                                            </tr>
                                        </table>
                                        <%--</ContentTemplate>
                                        </asp:UpdatePanel>--%>
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
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Label ID="resultlabel" runat="server"></asp:Label>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
