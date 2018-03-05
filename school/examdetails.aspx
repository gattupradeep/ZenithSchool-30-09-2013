<%@ Page Language="C#" AutoEventWireup="true" CodeFile="examdetails.aspx.cs" Inherits="school_examdetails" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc1" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>

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
            <td align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
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
                                        <uc1:school_profile ID="school_profile1" runat="server" />
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
                        <td style="width: 94%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                               <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/25.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >  Exam Details
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
                                       <%--  <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                            <ProgressTemplate>
                                                <div id="progressBackgroundFilter"></div>
                                                    <div id="processMessage">
                                                        <img alt="Loading" src="../media/images/Processing.gif" />
                                                    </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>--%>
                                        <asp:UpdatePanel ID="updatepanal" runat="server" >
                                            <ContentTemplate>
                                                     <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" >
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Assign Exam Types" ></asp:Label> 
                                                </td>
                                                <td style="width: 150px; height: 50px;" align="left">
                                                    <asp:Button ID="btnaddnew" runat="server" CssClass="s_button" Text="Add New" 
                                                        onclick="btnaddnew_Click"/>&nbsp;
                                                        <asp:Button ID="std1edit" runat="server" CssClass="s_button" Text="Edit" 
                                                        Width="60px" onclick="std1edit_Click"/>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td style="height: 40px" align="right" colspan="2">
                                                    <asp:DropDownList ID="ddlstandard" runat="server" AutoPostBack="True" 
                                                        CssClass="s_dropdown" onselectedindexchanged="ddlstandard_SelectedIndexChanged" >
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlexamtype" runat="server" AutoPostBack="True" 
                                                        CssClass="s_dropdown" onselectedindexchanged="ddlexamtype_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 40px" align="left" colspan="2">
                                                    <asp:DataGrid ID="dgexamsettings1" runat="server" AutoGenerateColumns="False"                                                     
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="5" 
                                                        onpageindexchanged="dgexamsettings1_PageIndexChanged" >
                                                        <PagerStyle Mode="NumericPages" />
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle 
                                                            Height="25px" CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intschoolexamsettingsid" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strclass" HeaderText="Standard" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strexamtype" HeaderText="Exam Type" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strsubject" HeaderText="Subject"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strexampapername" HeaderText="Exam Paper">
                                                            </asp:BoundColumn>                                                            
                                                            <asp:BoundColumn DataField="intmaxmark" HeaderText="Total Marks">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intpassmark" HeaderText="Passmark">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dttimeduration" HeaderText="Duration">
                                                            </asp:BoundColumn>
                                                        </Columns>
                                                        <HeaderStyle Font-Bold="True" Height="30px" CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                    <asp:Label ID="lblmsg" runat="server" CssClass="s_label"></asp:Label>
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
            <td style="width: 100%; " align="left" valign="top">
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>