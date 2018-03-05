<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewlessons.aspx.cs" Inherits="student_viewlessons" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/activities_lessonplan.ascx" tagname="activities_lessonplan" tagprefix="uc1" %>
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
                                        <uc1:activities_lessonplan ID="activities_lessonplan1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > View Lesson Details</td>
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
                                                         <table cellpadding="0" cellspacing="0" border="0" width="98%">
                                            <tr>
                                                <td>
                                                    <table cellpadding="5" cellspacing="0" border="0" class="app_container_auto">
                                                        <tr class="view_detail_title_bg">
                                                            <td  style="height: 40px" align="left" colspan="4"><asp:Label ID="Labelname" runat="server" CssClass="title_label">View Lesson Details</asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                        <td style="height: 1px" align="left" colspan="4"></td>
                                                        </tr>
                                                        <tr class="view_detail_subtitle_bg">
                                                            <td style="height: 25px" align="left" colspan="4">
                                                                <asp:Label ID="Label21" runat="server" CssClass="subtitle_label" Text="Lesson Details" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 120px; height: 30px" align="left">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" 
                                                                    Text="Class"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 30px" align="left">
                                                                
                                                                <asp:Label ID="lblclass" runat="server" CssClass="s_label_value"></asp:Label>
                                                                
                                                            </td>                                                    
                                                            <td style="width: 120px; height: 30px" align="left">
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" 
                                                                    Text="Section"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 30px" align="left">
                                                                <asp:Label ID="lblsection" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 120px; height: 30px;" align="left">
                                                                <asp:Label ID="Label12" runat="server" CssClass="s_label" 
                                                                    Text="Subject"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 30px" align="left">
                                                                <asp:Label ID="lblsubject" runat="server" CssClass="s_label_value"></asp:Label>
                                                                </td>                                                    
                                                            <td style="width: 120px; height: 30px" align="left">
                                                                <asp:Label ID="Label14" runat="server" CssClass="s_label" 
                                                                    Text="Text Book Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 30px" align="left">
                                                            <asp:Label ID="lbltextbook" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 120px; height: 30px;" align="left">
                                                                <asp:Label ID="Label15" runat="server" CssClass="s_label" 
                                                                    Text="From Date"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 30px" align="left">
                                                                <asp:Label ID="lblfromdate" runat="server" CssClass="s_label_value"></asp:Label>
                                                                </td>                                                    
                                                            <td style="width: 120px; height: 30px" align="left">
                                                                <asp:Label ID="Label16" runat="server" CssClass="s_label" 
                                                                    Text="To Date"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 30px" align="left">
                                                                <asp:Label ID="lbltodate" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 120px; height: 30px" align="left">
                                                                <asp:Label ID="Label17" runat="server" CssClass="s_label" 
                                                                    Text="Teacher Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 30px" align="left">
                                                                <asp:Label ID="lblteachername" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                           
                                                            <td align="left">&nbsp;</td>
                                                            <td align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr class="view_detail_subtitle_bg">
                                                            <td style="height: 25px" align="left" colspan="4">
                                                                <asp:Label ID="Label23" runat="server" CssClass="subtitle_label" Text="Unit Details" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 40px" align="left" colspan="4">
                                                                <asp:DataGrid ID="dgviewlessons" runat="server" AutoGenerateColumns="False" 
                                                                Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" >
                                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="intid" HeaderText="intid" Visible="False">
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="dtdate" HeaderText="Date">
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="strunitname" HeaderText="Unit No / Name"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="lessonname" 
                                                                            HeaderText="Lesson Name"></asp:BoundColumn>
                                                                    <asp:BoundColumn HeaderText="Topic" 
                                                                        DataField="strtopic">
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="strdescription" HeaderText="Description">
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="noofperiods" HeaderText="No of Periods" ItemStyle-Width="10px"></asp:BoundColumn>
                                                                </Columns>
                                                                <HeaderStyle CssClass="s_datagrid_header"/>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 40px" align="center" colspan="4">
                                                                <input type ="button" value="Back" class="s_button" onclick="javascript:history.go(-1)" />
                                                            </td>
                                                        </tr>
                                                    </table>
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
            <td style="width: 100%; " align="left" valign="top" >
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

