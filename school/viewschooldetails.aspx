<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewschooldetails.aspx.cs" Inherits="school_viewschooldetails" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc5" %>

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
                                <tr >
                                    <td style="width: 230px" align="right">
                                        <uc5:school_profile ID="school_profile1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="center">
                                        <uc4:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:1%" valign="top">
                        </td>
                        <td style="width: 94%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/25.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >
                                                    School Information</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 5px" valign="top" align="left">
                                         <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                <ProgressTemplate>
                                                    <div id="progressBackgroundFilter"></div>
                                                        <div id="processMessage">
                                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                                        </div>
                                                </ProgressTemplate>
                                          </asp:UpdateProgress>--%>
                                          <asp:UpdatePanel ID="updatepanal" runat="server" >
                                                 <ContentTemplate>
                                                    <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td colspan="3"  align="left">
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Name of the School :" ></asp:Label> <asp:Label ID="lblschoolname" runat="server" CssClass="title_label_value"></asp:Label>
                                                </td>
                                                <td style="width: 85px">
                                                    <asp:Button ID="btnedit" runat="server" CssClass="s_button" onclick="btnedit_Click" Text="Edit" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 1px" align="left" colspan="4"></td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4" >
                                                    <asp:Label ID="Label21" runat="server" CssClass="subtitle_label" Text="Academic Details"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label22" runat="server" CssClass="s_label" Text="Branch" ></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblbranch" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>                                                    
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Year Established" ></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblyear" runat="server" CssClass="s_label_value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px;" align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Academic Year Start" ></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblyearstart" runat="server" CssClass="s_label_value" ></asp:Label>
                                                </td>                                                    
                                                <td style="width: 200px; height: 40px;" align="left">
                                                    <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Academic Year End" ></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblyearend" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Board"></asp:Label>
                                                </td>
                                                <td align="left" >
                                                    <asp:Label ID="lblboard" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                <td align="left" >&nbsp;</td>
                                                <td align="left">&nbsp;</td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg" >
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label23" runat="server" CssClass="subtitle_label" Text="Communication Details"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label24" runat="server" CssClass="s_label" Text="Country"></asp:Label>
                                                </td>
                                                <td style="width: 220px; height: 40px" align="left">
                                                    <asp:Label ID="lblcountry" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Labelstate" runat="server" CssClass="s_label" Text="State"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblstate" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label25" runat="server" CssClass="s_label" Text="City"></asp:Label>
                                                </td>
                                                <td style="width: 220px; height: 40px" align="left">
                                                    <asp:Label ID="lblcity" runat="server" CssClass="s_label_value" ></asp:Label>
                                                </td>
                                               
                                                <td align="left" >
                                                    <asp:Label ID="Label20" runat="server" CssClass="s_label" Text="Address"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lbladdress" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label26" runat="server" CssClass="s_label" Text="Pincode"></asp:Label>
                                                </td>
                                                <td style="width: 220px; height: 40px" align="left">
                                                    <asp:Label ID="lblpincode" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Phone" ></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblphone" runat="server" CssClass="s_label_value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Fax" ></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblfax" runat="server" CssClass="s_label_value" ></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label" runat="server" CssClass="s_label" Text="Website" ></asp:Label>
                                                </td>
                                                <td align="left">                                                    
                                                    <asp:Label ID="lblwebsite" runat="server" CssClass="s_label_value" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Email ID"></asp:Label>
                                                </td>
                                                <td style="width: 220px; height: 40px;" align="left">
                                                    <asp:Label ID="lblemail" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td align="left" colspan="4" >
                                                    <asp:Label ID="Label27" runat="server" CssClass="subtitle_label" Text="Facilities"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <%--<td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="Groups Available"></asp:Label>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left" >
                                                    <asp:Label ID="lblgroups" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>--%>
                                                <td style="height: 40px;" align="left">
                                                    <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Hostel Facility"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblhostel" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                <td style="height: 40px;width:240px" align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Library "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbllibrary" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td style="width: 350px; height: 40px;" align="left">
                                                    <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="School Transport"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbltransport" runat="server" CssClass="s_label_value" ></asp:Label>
                                                </td>
                                                <%--<td style="height: 40px;width:240px" align="left">
                                                    <asp:Label ID="Label28" runat="server" CssClass="s_label" Text="Library "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbllibrary" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>--%>
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
