<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_subject_language_ExtraCurricular.aspx.cs" Inherits="school_view_subject_language_ExtraCurricular" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

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
        
    <link rel="stylesheet" href="../include/jquery-ui-1.8.14.custom.css" type="text/css" />
    <link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />
    <script type="text/javascript" src="../include/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>    
    <script type="text/javascript">
            $(document).ready(function() {
            $('#timepicker_3').timepicker();
        });
        $(document).ready(function() {
            $('#timepicker_4').timepicker();
        });
        $(document).ready(function() {
            $('#timepicker_5').timepicker();
        });
        $(document).ready(function() {
            $('#timepicker_6').timepicker();
        });
        $(document).ready(function() {
            $('#timepicker_7').timepicker();
        });
    </script>
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
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/25.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >
                                                    Sections, Subject, Languages and Activities for Classes</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
                                        <%-- <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                <ProgressTemplate>
                                                    <div id="progressBackgroundFilter"></div>
                                                        <div id="processMessage">
                                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                                        </div>
                                                </ProgressTemplate>
                                          </asp:UpdateProgress>--%>
                                          <asp:UpdatePanel ID="updatepanal" runat="server" >
                                                <ContentTemplate>
                                                     <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                 <td colspan="6" align="left">
                                                    <table cellpadding="0" cellspacing="0" class="app_container">
                                                        <tr class="view_detail_title_bg" >
                                                            <td align="left" >
                                                                <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Assigned Sections, Subjects, languages and Activities for Classes" ></asp:Label>
                                                            </td>
                                                            <td style="width: 80px; height: 30px" align="center">
                                                            <asp:Button ID="btnedit" runat="server" CssClass="s_button"  Text="Edit" 
                                                                onclick="btnedit_Click2"/>
                                                            </td>
                                                            <td style="width: 80px; height: 50px">
                                                                <asp:Button ID="btnadd" runat="server" CssClass="s_button" Text="Add" 
                                                                    onclick="btnadd_Click"/>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="height: 30px" align="right">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="300">
                                                                    <tr>
                                                                        <td style="width: 105px; height: 30px" align="left">
                                                                            <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Class : "></asp:Label>
                                                                        </td>
                                                                        <td style="width: 150px; height: 30px" align="left">
                                                                            <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_textbox" 
                                                                                Width="130px" AutoPostBack="True" 
                                                                                onselectedindexchanged="ddlclass_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                                                                        </td>
                                                                        <td style="width: 100px; height: 30px" align="left">
                                                                            <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_textbox" 
                                                                                Width="80px" AutoPostBack="True" 
                                                                                onselectedindexchanged="ddlsection_SelectedIndexChanged" ></asp:DropDownList>&nbsp;&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" colspan="3">
                                                                <table cellpadding="0" cellspacing="0" width="100%" >
                                                                    <tr>
                                                                        <td style="height: 30px" valign="top" align="left">
                                                                            <asp:DataList ID="dlsubjects" runat="server" RepeatDirection="Vertical" 
                                                                                BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                                ShowHeader="False" style="z-index: 1" Width="724px">
                                                                                <ItemStyle VerticalAlign="Top" />
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" border="1" bordercolor="#DEE7D4">
                                                                                     <tr class="view_detail_subtitle_bg">
                                                                                        <td align="center" class="s_label">
                                                                                            Subject
                                                                                        </td>
                                                                                         <td align="center" class="s_label">
                                                                                            Second Languages
                                                                                        </td>
                                                                                         <td align="center" class="s_label">
                                                                                            Third Languages
                                                                                        </td>
                                                                                        <td align="center" class="s_label">
                                                                                            Extra - Curricular Activity
                                                                                        </td>
                                                                                       <%-- <td align="center" class="s_label">
                                                                                            Groups
                                                                                        </td> --%>                                                                                   
                                                                                    </tr>
                                                                                    <tr>                                                                                   
                                                                                        <td style="width:200px; padding-left: 10px; line-height:18px;" align="left" class="s_label" valign="top">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "subject")%>
                                                                                        </td>
                                                                                        <td style="width:150px;  padding-left: 10px" align="left" class="s_label" valign="top">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "language")%>
                                                                                        </td>
                                                                                        <td style="width:150px; padding-left: 10px" align="left" class="s_label" valign="top">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "thirdlanguage")%>
                                                                                        </td>
                                                                                        <td style="width:150px; padding-left: 10px" align="left" class="s_label" valign="top">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "extracurricular")%>
                                                                                        </td>
                                                                                        <%--<td style="width:150px; padding-left: 10px" align="left" class="s_label" valign="top">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "groups")%>
                                                                                        </td>        --%>                                                                             
                                                                                    </tr>
                                                                                </table>                                                                             
                                                                            </ItemTemplate>                                                                         
                                                                        </asp:DataList>
                                                                    </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                           <%-- <td style="height: 30px" valign="top" align="left">
                                                                <asp:DataList ID="dlsubjects" runat="server" RepeatDirection="Horizontal" 
                                                                    BorderStyle="None" BorderWidth="0px" CellPadding="0" ShowFooter="False" 
                                                                    ShowHeader="False">
                                                                    <ItemStyle VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" width="151">
                                                                            <tr>
                                                                                <td style="width:1px; background-color: Gray"></td>
                                                                                <td style="height: 50px; width:150px; font-weight: bold; background-color:#DEE7D1" align="center" class="s_label">
                                                                                    <%# DataBinder.Eval(Container.DataItem, "strstandard")%> <%# DataBinder.Eval(Container.DataItem, "strsection")%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width:1px; background-color: Gray"></td>
                                                                                <td style="height: 1px; width:150px; background-color: Gray"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width:1px; background-color: Gray"></td>
                                                                                <td style="height: 150px; width:150px; color: Black; font-size: 12px; padding-left: 10px" align="left" class="s_label" valign="top">
                                                                                    <%# DataBinder.Eval(Container.DataItem, "subject")%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width:1px; background-color: Gray"></td>
                                                                                <td style="height: 1px; width:150px; background-color: Gray"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width:1px; background-color: Gray"></td>
                                                                                <td style="height: 150px; width:150px; color: Black; font-size: 12px; padding-left: 10px" align="left" class="s_label" valign="top">
                                                                                    <%# DataBinder.Eval(Container.DataItem, "language")%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width:1px; background-color: Gray"></td>
                                                                                <td style="height: 1px; width:150px; background-color: Gray"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width:1px; background-color: Gray"></td>
                                                                                <td style="height: 150px; width:150px; color: Black; font-size: 12px; padding-left: 10px" align="left" class="s_label" valign="top">
                                                                                    <%# DataBinder.Eval(Container.DataItem, "extracurricular")%>
                                                                              </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                                
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
    </div>
    </form>
</body>
</html>
