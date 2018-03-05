<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search_view_vehicle.aspx.cs" Inherits="transport_Search_view_vehicle" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/admin_transport.ascx" tagname="admin_transport" tagprefix="uc1" %>
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
                                                <td align="left">Search / View Vehicle Details</td>
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
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel ID="updatepanal" runat="server" >
                                        <ContentTemplate>--%>
                                        <table cellpadding="3" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="6" class="title_label">Search / View Vehicle Details</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6"><asp:Label ID="lblowner" runat="server" Text="Select Contractor : " CssClass="s_label"></asp:Label>
                                                    <asp:DropDownList ID="ddlowner" runat="server" CssClass="s_dropdown" AutoPostBack="true" 
                                                        Width="150px" onselectedindexchanged="ddlowner_SelectedIndexChanged"></asp:DropDownList></td>
                                            </tr>
                                            <tr id="trvehicledetails" runat="server" visible="false">
                                                <td colspan="6">
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                        <tr class="view_detail_subtitle_bg">
                                                            <td colspan="6">Vehicle Details</td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Vehicle Contractor:  "></asp:Label></td>
                                                            <td><asp:Label ID="txtvehiclecontractor" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td ></td>
                                                            <td><asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Board Color:  "></asp:Label></td>
                                                            <td><asp:Label ID="txtboardcolor" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td ><asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Registeration Number:"></asp:Label></td>
                                                            <td ><asp:Label ID="txtregno" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td>&nbsp;</td>
                                                            <td ><asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Rate Per KM:  "></asp:Label></td>
                                                            <td ><asp:Label ID="txtrate" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td >&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td ><asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Engine Number:"></asp:Label></td>
                                                            <td ><asp:Label ID="txtengineno" runat="server" CssClass="s_label_value" ></asp:Label> </td>
                                                            <td > &nbsp;</td>
                                                            <td><asp:Label ID="Label11" runat="server" CssClass="s_label" Text="FC Number:  "></asp:Label></td>
                                                            <td><asp:Label ID="txtfcno" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td >&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Chassis Number: "></asp:Label></td>
                                                            <td><asp:Label ID="txtchassisno" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td >&nbsp;</td>
                                                            <td><asp:Label ID="Label12" runat="server" CssClass="s_label" Text="FC Issue Date:"></asp:Label></td>
                                                            <td ><asp:Label ID="txtfcissuedate" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Brand:  "></asp:Label></td>
                                                            <td ><asp:Label ID="txtbrand" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td >&nbsp;</td>
                                                            <td ><asp:Label ID="Label13" runat="server" CssClass="s_label" Text="FC End Date:  "></asp:Label></td>
                                                            <td ><asp:Label ID="txtfcenddate" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Model: "></asp:Label></td>
                                                            <td><asp:Label ID="txtmodel" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td>&nbsp;</td>
                                                            <td><asp:Label ID="Label24" runat="server" CssClass="s_label" Text="Insurance Number: "></asp:Label> </td>
                                                            <td><asp:Label ID="txtinsuranceno" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td > </td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Type Of Vehicle:  "></asp:Label></td>
                                                            <td ><asp:Label ID="txttypeofvehicle" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td >&nbsp;</td>
                                                            <td ><asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Insurance Issue Date:"></asp:Label></td>
                                                            <td ><asp:Label ID="txtinsuranceissuedate" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td ><asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Fuel:  "></asp:Label></td>
                                                            <td ><asp:Label ID="txtfuel" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td ></td>
                                                            <td ><asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Insurance End Date:  "></asp:Label></td>
                                                            <td ><asp:Label ID="txtinsuranceenddate" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td ><asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Vehicle Color:  "></asp:Label></td>
                                                            <td ><asp:Label ID="txtvehiclecolor" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td >&nbsp;</td>
                                                            <td ><asp:Label ID="Label20" runat="server" CssClass="s_label" Text="Free Services:  "></asp:Label></td>
                                                            <td ><asp:Label ID="txtfreeservices" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td ><asp:Label ID="Label17" runat="server" CssClass="s_label" Text="Number Of Seats:  "></asp:Label></td>
                                                            <td ><asp:Label ID="txtseats" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td >&nbsp;</td>
                                                            <td ><asp:Label ID="Label25" runat="server" CssClass="s_label" Text="Vehicle Number:"></asp:Label></td>
                                                            <td ><asp:Label ID="txtvehicleno" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td ><asp:Label ID="Label18" runat="server" CssClass="s_label" Text="Luxury Info:"></asp:Label></td>
                                                            <td ><asp:Label ID="txtluxury" runat="server" CssClass="s_label_value"  ></asp:Label></td>
                                                            <td >&nbsp;</td>
                                                            <td ><asp:Label ID="Label19" runat="server" CssClass="s_label" Text="Permit Info:"></asp:Label></td>
                                                            <td><asp:Label ID="txtpermit" runat="server" CssClass="s_label_value"  ></asp:Label></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr id="trback" runat="server">
                                                            <td colspan="6">
                                                                <asp:Button ID="btnback" runat="server" Text="Back" CssClass="s_button" onclick="btnback_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trdg" runat="server">
                                                <td align="center" colspan="6" style="height: 40px">
                                                    <asp:DataGrid ID="dgvehicle" runat="server" AutoGenerateColumns="False"
                                                    Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" oneditcommand="dgvehicle_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strownername" HeaderText="Contractor" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strvehicleno" HeaderText="VehicleNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strengineno" HeaderText="EngineNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>                                                                                            
                                                            <asp:BoundColumn DataField="strchassisno" HeaderText="ChasssisNo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strbrand" HeaderText="Brand" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strmodel" HeaderText="Model" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strvehiclecolor" HeaderText="Vehicle color" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="View" Text="&lt;img src=&quot;../media/images/view.gif&quot; alt=&quot;View&quot; border=&quot;0&quot; /&gt;">                                                                                                                
                                                            </asp:ButtonColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr id="trnodata" runat="server" visible="false">
                                                <td align="center"><asp:Label ID="lblnodata" runat="server" CssClass="nodatatodisplay" Text="There is no data to display"></asp:Label></td>
                                            </tr>
                                        </table>
                                       <%-- </ContentTemplate>
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
    </div>
    </form>
</body>
</html>