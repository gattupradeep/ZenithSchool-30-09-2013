<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search_view_driver.aspx.cs" Inherits="transport_Search_view_driver" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
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
    <link href="../media/css/calendar.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>
      
</head>
<body>
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
                                                <td align="left">Search / View Driver Details</td>
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
                                        <table cellpadding="5" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" class="title_label">Search / View Driver Details</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Label ID="Labeldriver" runat="server" CssClass="s_label" Text="Select Driver : "></asp:Label>
                                                    <asp:DropDownList ID="ddldriver" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" onselectedindexchanged="ddldriver_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                </td>                                                
                                            </tr>
                                            <tr id="trdriverdetails" runat="server" visible="false">
                                                <td colspan="4">
                                                    <table cellpadding="3" cellspacing="0" width="100%">
                                                        <tr class="view_detail_subtitle_bg">
                                                            <td colspan="4">Driver Details</td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td rowspan="4"></td>
                                                            <td rowspan="4"><asp:Image ID="imgdriverphoto" runat="server" CssClass="s_textbox" Width="100" Height="100" AlternateText="Driver Photo"/></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td ><asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Driver Name"></asp:Label></td>
                                                            <td align="left"><asp:Label ID="txtdriver" runat="server" CssClass="s_label_value" ></asp:Label></td>                                                            
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Date Of Birth"></asp:Label></td>
                                                            <td ><asp:Label ID="txtdateofbirth" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Licence No"></asp:Label></td>
                                                            <td align="left"><asp:Label ID="txtlicenceno" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Licence Issuedate"></asp:Label></td>
                                                            <td><asp:Label ID="txtissuedate" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Licence Expirydate"></asp:Label></td>
                                                            <td align="left"><asp:Label ID="txtexpirydate" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                            <td ><asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Mode Of Licence"></asp:Label></td>
                                                            <td ><asp:Label ID="txtmode" runat="server" CssClass="s_label"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td ><asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Address"></asp:Label></td>
                                                            <td align="left"><asp:Label ID="txtaddress" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td ><asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Area"></asp:Label></td>
                                                            <td><asp:Label ID="txtarea" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label9" runat="server" CssClass="s_label" Text="City"></asp:Label></td>
                                                            <td align="left"><asp:Label ID="txtcity" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                            <td><asp:Label ID="Label10" runat="server" CssClass="s_label" Text="State"></asp:Label></td>
                                                            <td><asp:Label ID="txtstate" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Country"></asp:Label></td>
                                                            <td align="left"><asp:Label ID="txtcountry" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td><asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Phone No"></asp:Label></td>
                                                            <td><asp:Label ID="txtphoneno" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Mobileno"></asp:Label></td>
                                                            <td align="left"><asp:Label ID="txtmobile" runat="server" CssClass="s_label_value" ></asp:Label></td>
                                                            <td><asp:Label ID="lbldocumentrec" runat="server" Text="Document Received" CssClass="s_label"></asp:Label></td>
                                                            <td><asp:Label ID="txtdocumentrec" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                        </tr> 
                                                        <tr id="trback" runat="server">
                                                            <td colspan="4">
                                                               <asp:Button ID="btnback" runat="server" Text="Back" CssClass="s_button" onclick="btnback_Click" />
                                                            </td>
                                                       </tr>                                                       
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                            <tr id="trgrid1" runat="server">
                                                <td colspan="4" style="width: 750px; height: 40px" align="left">
                                                    <asp:DataGrid ID="dgdriver" runat="server" AutoGenerateColumns="False"
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        oneditcommand="dgdriver_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Photo">
                                                                <ItemTemplate>
                                                                    <img src = "../images/Driver/<%#DataBinder.Eval(Container.DataItem,"intid") %>.jpg" alt="photo" width="50" height="50" />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="strdrivername" HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="address" HeaderText="Address"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strcountry" HeaderText="Country"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="contact" HeaderText="Contact"  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                            </asp:BoundColumn>                                                           
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="View"  Text="&lt;img src=&quot;../media/images/view.gif&quot; alt=&quot;view&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                        </table>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
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
    </div>
    </form>
</body>
</html>