<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Approvecancellation.aspx.cs" Inherits="transport_Approvecancellation" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/admin_transport.ascx" tagname="admin_transport" tagprefix="uc1" %>

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
	<link rel="stylesheet" type="text/css" href="../Media_front/Css/abtModal.css" />
	<script type="text/javascript" src="../Media_front/Js/abtModal.js"></script>
	<script type="text/javascript">
	    function showModal(url, w, h) {
	        showabtModal('mothersMedicals', w, h);
	        document.getElementById('trendsFrame').style.height = h + 'px';
	        document.getElementById('trendsFrame').style.width = w + 'px';
	        document.getElementById('trendsFrame').src = url;
	    }
	    function closeModal() {
	        document.getElementById('trendsFrame').src = "";
	        hideabtModal('mothersMedicals')
	        window.parent.location = "approveleave.aspx";
	    }
    </script>
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
    <div id="mothersMedicals" class="dialog">
        <div style="text-align:center"><span onclick="closeModal();" style="float:right;clear:both;" class="closeModal"></span></div>
        <iframe id="trendsFrame" src="" style="width:960px;height:300px;border:none;" scrolling='no' marginwidth='0' marginheight='0' frameborder='0' vspace='0' hspace='0' >some problem</iframe>
    </div>
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
                                    <td style="width: 100%" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/113.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Approve Student Busbooking Cancellation </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto">
                                            <tr>
                                                <td align="left" style="width:100%; height: 40px">
                                                    <asp:DataGrid ID="dgapprovebus" runat="server" AutoGenerateColumns="False"                                                         
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        CellPadding="4" onitemdatabound="dgapprovebus_ItemDataBound" >
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                        <ItemStyle CssClass="s_datagrid_item"/>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intadmitno" HeaderText="Admission No"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="name" HeaderText="Student Name"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="class" HeaderText="Standard" ></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="date" HeaderText="Request Date"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strdestination" HeaderText="Destination"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strroutename" HeaderText="Bus Route"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="status" HeaderText="Status"></asp:BoundColumn>
                                                            <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:Button id="btnapprove"  runat="server" CausesValidation="false" 
                                                                        CssClass="s_grdbutton" CommandName="button" 
                                                                        Text="Approve" Font-Bold="True" onclick="btnapprove_Click" />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:Button id="btncancel"  runat="server" CausesValidation="false" 
                                                                        CssClass="s_grdbutton" CommandName="button" 
                                                                        Text="Reject" Font-Bold="True" onclick="btncancel_Click" />
                                                                </ItemTemplate>
                                                               <%--<ItemTemplate>
                                                                    <a href="javascript: void(0)" onclick="showModal('viewstaffleaverequestdetails.aspx?rj=1&id=<%# DataBinder.Eval(Container.DataItem, "intid")%>','755','400')">
                                                                    <input type="button" class="s_grdbutton" name="reject" runat="server" value="Reject" id="reject" /></a>
                                                                </ItemTemplate>--%>
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