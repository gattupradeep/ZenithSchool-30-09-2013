<%@ Page Language="C#" AutoEventWireup="true" CodeFile="homeworkdetails.aspx.cs" Inherits="school_homeworkdetails" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/activities_homework.ascx" tagname="activities_homework" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
        <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />   
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>    
    <style type="text/css">
        .style1
        {
            width: 175px;
            height: 40px;
        }
        .style2
        {
            width: 200px;
            height: 40px;
        }
    </style>
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
                                        <uc1:activities_homework ID="activities_homework1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/49.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Homework Details</td>
                                                <td style="width: 100px; height: 50px"> 
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
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
                                                         <table cellpadding="0" cellspacing="0" class="app_container">
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px; padding-left: 10px">
                                                    <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Standard" Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblstandard" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" 
                                                        Text="Teacher" Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblteacher" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px; padding-left: 10px">
                                                    <asp:Label ID="Label14" runat="server" CssClass="s_label" 
                                                        Text="Subject" Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblsubject" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td id="tdattachment" runat="server" align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label26" runat="server" CssClass="s_label" Font-Bold="True" 
                                                        Text="Attachments"></asp:Label>
                                                </td>
                                                <td runat="server" align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblattatchments" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td align="left" style="padding-left: 10px" class="style1">
                                                    <asp:Label ID="Label15" runat="server" CssClass="s_label" Font-Bold="True" 
                                                        Text="Topic Name"></asp:Label>
                                                </td>
                                                <td align="left" class="style2">
                                                    <asp:Label ID="lbltopic" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="Label27" runat="server" CssClass="s_label" Font-Bold="True" 
                                                        Text="Status"></asp:Label>
                                                </td>
                                                <td align="left" class="style2">
                                                    <asp:Label ID="lblstatus" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td align="left" style="width: 175px; height: 40px; padding-left: 10px">
                                                    <asp:Label ID="Label25" runat="server" CssClass="s_label" Font-Bold="True" 
                                                        Text="Publish Date"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblpublish" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label22" runat="server" CssClass="s_label" 
                                                        Text="Description" Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lbldescript" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px; padding-left: 10px">
                                                    <asp:Label ID="Label23" runat="server" CssClass="s_label" 
                                                        Text="Assigned Date" Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblassigned" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label24" runat="server" CssClass="s_label" 
                                                        Text="Due Date" Font-Bold="True"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lbldue" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trunitlession" runat="server">
                                                <td align="left" style="width: 175px; height: 40px; padding-left: 10px">
                                                    <asp:Label ID="Label34" runat="server" CssClass="s_label" Font-Bold="True" 
                                                        Text="Unit"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblunit" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label33" runat="server" CssClass="s_label" Font-Bold="True" 
                                                        Text="Lesson Name"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lbllesson" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trtextbook" runat="server">
                                                <td align="left" style="width: 175px; height: 40px; padding-left: 10px">
                                                    <asp:Label ID="Label35" runat="server" CssClass="s_label" Font-Bold="True" 
                                                        Text="Textbook"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lbltextbook" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                <asp:HiddenField ID="hdnid" runat="server" />
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 40px" colspan="4">
                                                    <%--<input id="btnback" type="button" value="Back"  onclick="javascript:history.go(-1);" />--%>
                                                     <asp:Button ID="btnback" runat="server" Text="Back" CssClass="s_button"  Width="70px" onclick="btnback_Click" />
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
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

