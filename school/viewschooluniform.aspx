<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewschooluniform.aspx.cs" Inherits="school_viewschooluniform" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

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
                                                <td align="left" > School Uniform Details</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
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
                                                     <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="5">
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="School Uniform Juniors" ></asp:Label> 
                                                </td>
                                                <td style="width: 85px" align="right">
                                                        <asp:Button ID="btnedit" runat="server" CssClass="s_button" 
                                                            onclick="btnedit_Click" Text="Add/Edit" />
                                                </td>
                                            </tr>  
                                            <tr>
                                                <td colspan="6" align="right">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="250">
                                                        <tr>
                                                            <td style="width: 100px; height: 30px" align="right">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Class : "></asp:Label>
                                                            </td>
                                                            <td style="width: 150px; height: 30px" align="right">
                                                                <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_textbox" 
                                                                    Width="130px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlclass_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_title_bg" style="Height:10px;">
                                                <td colspan="6" align="right">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="uniform_gen" colspan="2">
                                                    B<br />
                                                    o<br />
                                                    y<br />
                                                    s</td>
                                                <td style="height: 100px; width:335px;" align="center" class="s_label" valign="top">
                                                    <asp:DataGrid ID="dguniformboysj" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                        BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowHeader="False">
                                                        <Columns>
                                                            <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="335">
                                                                        <tr>
                                                                            <td colspan="3" class="s_label view_detail_subtitle_bg" align="center"><%# DataBinder.Eval(Container.DataItem, "strweekdays") %></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 167px; height: 30px; padding-left: 10px; padding-top: 10px; padding-bottom: 10px;" align="left" class="s_label" valign="top">
                                                                                <b>Shirt : </b><%# DataBinder.Eval(Container.DataItem, "strshirt")%><br />
                                                                                <b>Trouser : </b><%# DataBinder.Eval(Container.DataItem, "strtrouserOrpant")%><br />
                                                                                <b>Shoes : </b><%# DataBinder.Eval(Container.DataItem, "strBshoes")%><br />
                                                                                <b>Socks : </b><%# DataBinder.Eval(Container.DataItem, "strBsocks")%><br />
                                                                                <b>Others : </b><%# DataBinder.Eval(Container.DataItem, "strBother")%><br />
                                                                            </td>
                                                                            <td style="width: 1px; height: 30px; background-color: #DEE7D1"></td>
                                                                            <td style="width: 167px; height: 30px; padding-top: 10px; padding-bottom: 10px" valign="top"><img src="../images/uniform/<%# DataBinder.Eval(Container.DataItem, "intschooluniformid")%>_boys.jpg" title="Boys Uniform" alt="Boys Uniform" class="uniform_img" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <HeaderStyle Height="0px" />
                                                    </asp:DataGrid>
                                                </td>
                                                <td class="uniform_gen" colspan="2">
                                                    G<br />
                                                    i<br />
                                                    r<br />
                                                    l<br />
                                                    s</td>
                                                <td style="height: 100px; width:335px;" align="center" class="s_label" valign="top">
                                                    <asp:DataGrid ID="dguniformgirlsj" runat="server" AutoGenerateColumns="False" 
                                                        BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowHeader="False" GridLines="None">
                                                        <Columns>
                                                            <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="335">
                                                                        <tr>
                                                                            <td colspan="3" class="s_label view_detail_subtitle_bg" align="center"><%# DataBinder.Eval(Container.DataItem, "strweekdays") %></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 167px; height: 30px; padding-left: 10px; padding-top: 10px; padding-bottom: 10px;" align="left" class="s_label" valign="top">
                                                                                <b>Top : </b><%# DataBinder.Eval(Container.DataItem, "strtop")%><br />
                                                                                <b>Bottom : </b><%# DataBinder.Eval(Container.DataItem, "strbottom")%><br />
                                                                                <b>Shoes : </b><%# DataBinder.Eval(Container.DataItem, "strGshoe")%><br />
                                                                                <b>Socks : </b><%# DataBinder.Eval(Container.DataItem, "strGsocks")%><br />
                                                                                <b>Others : </b><%# DataBinder.Eval(Container.DataItem, "strGother")%><br />
                                                                            </td>
                                                                            <td style="width: 1px; height: 30px; background-color: #DEE7D1"></td>
                                                                            <td style="width: 167px; height: 30px; padding-top: 10px; padding-bottom: 10px" valign="top"><img src="../images/uniform/<%# DataBinder.Eval(Container.DataItem, "intschooluniformid")%>_girls.jpg" title="Girls Uniform" alt="Girls Uniform" class="uniform_img" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <HeaderStyle Height="0px" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                        </table>
                                                 </ContentTemplate>
                                          </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 40px"></td>
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

