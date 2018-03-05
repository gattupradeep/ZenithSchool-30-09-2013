<%@ Page Language="C#" AutoEventWireup="true" CodeFile="subject_language_ExtraCurricular.aspx.cs" Inherits="school_subject_language_ExtraCurricular" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc4" %>

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
                                        <uc4:school_profile ID="school_profile1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Assign Section, Subject, Language &amp; Activities to Class</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
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
                                                           <table cellpadding="7" cellspacing="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="6">
                                                    <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Assign Section, Subject, Language & Activities to Class" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" 
                                                        Text="Class"></asp:Label>
                                                    <br />
                                                    <br />
                                                    
                                                    <%--<asp:Label ID="Label11" runat="server" 
                                                        CssClass="s_label" Text="Groups"></asp:Label>--%>
                                                    
                                                </td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" onselectedindexchanged="ddlstandard_SelectedIndexChanged" 
                                                        AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <br />
                                                    <br />
                                                   <%-- <asp:DropDownList ID="ddlgroup" runat="server" CssClass="s_dropdown" Width="140px">
                                                    </asp:DropDownList>--%>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px"></td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                   <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Section"></asp:Label></td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Panel ID="Panel3" runat="server" CssClass="panel" ScrollBars="Vertical">
                                                         <asp:CheckBoxList ID="chksection" runat="server"></asp:CheckBoxList>
                                                     </asp:Panel>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Subject"></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                     <asp:Panel ID="pan" runat="server" CssClass="panel" ScrollBars="Vertical">
                                                        <asp:CheckBoxList ID="chksubject" runat="server"></asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                        &nbsp;</td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label10" runat="server" 
                                                        CssClass="s_label" Text="Extra-Curricular Activities"></asp:Label></td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                     <asp:Panel ID="Pan1" runat="server" CssClass="panel" ScrollBars="Vertical">
                                                         <asp:CheckBoxList ID="chkextra" runat="server"></asp:CheckBoxList>
                                                     </asp:Panel>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>    
                                             <tr>
                                                 <td colspan="6" align="center" style="width: 710px; height: 40px">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                        Width="60px" onclick="btnSave_Click" />
                                                    
                                                     &nbsp;
                                                    
                                                    <asp:Button ID="btncancel" runat="server" CssClass="s_button" Text="Clear All" 
                                                        Width="60px" onclick="btncancel_Click" CausesValidation="False"/>
                                                        &nbsp;
                                                        <asp:Button ID="btndone" runat="server" CssClass="s_button" Text="Done" 
                                                        Width="60px" onclick="btndone_Click" CausesValidation="False" 
                                                         Visible="False" />
                                                </td>  
                                            </tr>      
                                            <tr>
                                                <td colspan="6" align="left" style="width: 730px; height: 20px">
                                                <table cellpadding="0" cellspacing="0" border="0" width="730">
                                                    <tr>
                                                        <td align="left" style="height: 40px">
                                                            <asp:Panel ID="Panel4" runat="server" Width="730px">
                                                                <asp:DataGrid ID="dgstandard" runat="server" AutoGenerateColumns="False"
                                                                Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                                    oneditcommand="dgstandard_EditCommand">
                                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                                <ItemStyle CssClass="s_datagrid_item" />
                                                                    <Columns>                                                                                                                   
                                                                        <asp:BoundColumn DataField="strstandard" HeaderText="Class" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">                                                                
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strsection" HeaderText="Sec"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="subject" HeaderText="Subject" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">                                                                
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="language" HeaderText="Second Languages" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="thirdlanguage" HeaderText="Third Languages" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="extracurricular" HeaderText="Extra-Curriculars" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                                       <%-- <asp:BoundColumn DataField="groups" HeaderText="Groups" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>--%>
                                                                        <asp:ButtonColumn CommandName="edit" HeaderText="View" Text="&lt;img src=&quot;../media/images/view.png&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">                                                                                                                
                                                                    </asp:ButtonColumn>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                                                    </asp:DataGrid>
                                                            </asp:Panel>
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
            <td style="width: 100%;" align="left" valign="top" >
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
