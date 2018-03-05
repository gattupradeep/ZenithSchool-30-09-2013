<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_specialclasses.aspx.cs" Inherits="specialclasses_view_specialclasses" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/activities_timetable.ascx" tagname="activities_timetable" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/special_class.ascx" tagname="special_class" tagprefix="uc5" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
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
                                        <uc5:special_class ID="special_class1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/303.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Search | View Special Class</td>
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
                                                         <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td class="title_label">
                                                     &nbsp;&nbsp;&nbsp; Special Class Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 10px" valign="top" align="left">
                                                    <table cellpadding="7" cellspacing="0" border="0" >
                                                        <tr>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" Font-Bold="True" 
                                                                    Text="Standard &amp; section:"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                
                                                                <asp:Label ID="lblclass" runat="server" CssClass="s_label"></asp:Label>
                                                                
                                                            </td>                                                    
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="style1">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Font-Bold="True" 
                                                                    Text="Date :"></asp:Label>
                                                                </td>
                                                            <td align="left" class="style1">
                                                                <asp:Label ID="lbldate" runat="server" CssClass="s_label"></asp:Label>
                                                                </td>                                                    
                                                            <td align="left" class="style1">
                                                                &nbsp;</td>
                                                            <td align="left" class="style1">
                                                                &nbsp;&nbsp;&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" Font-Bold="True" 
                                                                    Text="Time :"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lbltime" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                           
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Font-Bold="True" 
                                                                    Text="Subject :"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px" align="left">
                                                                <asp:Label ID="lblsubject" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" Font-Bold="True" 
                                                                    Text="Teacher :"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px" align="left">
                                                                <asp:Label ID="lblteacher" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                           
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Font-Bold="True" 
                                                                    Text="Remarks :"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px" align="left">
                                                                <asp:Label ID="lblremarks" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            
                                                            <td align="left" >
                                                                &nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" >
                                                                &nbsp;</td>
                                                            <td style="font-size:13px" align="left">
                                                                &nbsp;</td>
                                                            
                                                            <td align="left">
                                                            <%--<input class="s_button" onclick="javascript:history.go(-1)" type="button" 
                                                                value="Back" />--%>
                                                            <asp:Button ID="btnback" runat="server" CssClass="s_button" Text="Back" 
                                                                    onclick="btnback_Click" />    
                                                            </td>
                                                            <td align="left">                                                    
                                                                &nbsp;&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table> 
                                                 </ContentTemplate>
                                         </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr><td class="break"></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
        <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
        <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
