<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewexampapers.aspx.cs" Inherits="admin_viewexampapers" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

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
          
    <style type="text/css">
        .style1
        {
            width: 720px;
            height: 48px;
        }
    </style>
          
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
                        <td style="width: 100%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 150%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/25.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Exam Papers</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 5px;" valign="top" align="left">
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
                                                     <table  cellpadding="7" cellspacing="0" border="0" class="app_container" style="width:800px">
                                          <tr class="view_detail_title_bg">
                                                <td style="width: 84px" align="left"class="title_label">
                                                    Class :</td>
                                                <td style="width: 154px">
                                                    <asp:DropDownList ID="ddlstandard" runat="server" AutoPostBack="True" 
                                                        CssClass="s_dropdown" onselectedindexchanged="ddlstandard_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    </td>
                                                <td style="width: 84px" class="title_label" align="left">Subject :</td>
                                                <td style="width: 174px">
                                                    <asp:DropDownList ID="ddlsubject" runat="server" AutoPostBack="True" 
                                                        CssClass="s_dropdown" onselectedindexchanged="ddlsubject_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 164px">
                                                    <asp:Button ID="btnedit" runat="server" CssClass="s_button" onclick="btnedit_Click" Text="Edit" />
                                                    <asp:Button ID="btnadd" runat="server" CssClass="s_button" Text="Add" 
                                                        onclick="btnadd_Click" />
                                                </td>
                                          </tr> 
                                          <tr id="trgrid" visible="false" runat="server">
                                            <td style="color:black; font-size:13px; font-family:Verdana" 
                                                  align="left" colspan="5" class="style1">
                                             <asp:BulletedList ID="blexampapers" BulletStyle="Square" runat="server"></asp:BulletedList>
                                           </td>
                                         </tr>
                                          <tr id="trerror" visible="false" runat="server">
                                            <td style="height: 50px; width:720px; color:black; font-size:13px; font-family:Verdana" 
                                                  align="left" colspan="5">
                                                No Exam Papers Assinged for This Class &amp; Subject. Please Click Add to Assign</td>
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
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
