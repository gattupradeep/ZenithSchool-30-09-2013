<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Class_Section_Subject_Details.aspx.cs" Inherits="school_Class_Section_Subject_Details" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc4" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

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
            $('#txtstarttime').timepicker();
        });
        $(document).ready(function() {
            $('#txtendtime').timepicker();
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
                                        <table cellpadding="0" cellspacing="0" border="0" width="750">
                                            <tr>
                                                <td class="app_cont_title_img_td" ><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >
                                                    Add | Edit Class, Section, Subject &amp; Activities</td>
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
                                        <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td colspan="6"  align="left">
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Add | Edit Class, Section, Subject & Activities" ></asp:Label>
                                                </td>
                                            </tr>    
                                            <tr>
                                                <td colspan="6" align="left" style="width: 750px; height: 20px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" 
                                                        Text="Class"></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" CssClass="panel">
                                                    <asp:CheckBoxList ID="chkstandard" runat="server"></asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                        &nbsp;</td>
                                                <td align="left" style="width: 100px; height: 40px">
                                                    <asp:Label ID="Label19" runat="server" CssClass="s_label" 
                                                        Text="Add new"></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 225px; height: 40px">
                                                    <asp:TextBox ID="txtstandard" 
                                                        runat="server" CssClass="s_textbox" Width="120px"></asp:TextBox>
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="addstandard" runat="server" Text="Save" 
                                                        onclick="addstandard_Click" CssClass="s_button"/></td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="6" style="height : 20px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label10" runat="server" CssClass="s_label" 
                                                        Text="Section"></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Panel ID="pan1" runat="server" CssClass="panel" ScrollBars="Vertical">
                                                    <asp:CheckBoxList ID="chksection" runat="server"></asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                        &nbsp;</td>
                                                <td align="left" style="width: 100px; height: 40px">
                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" 
                                                        Text="Add new"></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 225px; height: 40px"><asp:TextBox ID="txtsection" runat="server" CssClass="s_textbox" Width="120px"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="addsection" runat="server" Text="Save" 
                                                        onclick="addsection_Click" CssClass="s_button"/></td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="6" style="height : 20px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label17" runat="server" CssClass="s_label" 
                                                        Text="Subject"></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Panel ID="pan2" runat="server" CssClass="panel" ScrollBars="Vertical">
                                                        <asp:CheckBoxList ID="chksubject" runat="server">
                                                        </asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 100px; height: 40px">
                                                    <asp:Label ID="Label18" runat="server" CssClass="s_label" 
                                                        Text="Add new"></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 225px; height: 40px">
                                                    <asp:TextBox ID="txtsubject" runat="server" CssClass="s_textbox" Width="120px"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="addsubject" runat="server" Text="Save" 
                                                        onclick="addsubject_Click" CssClass="s_button"/>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="6" style="height : 20px">
                                                </td>
                                            </tr>
                                             <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" 
                                                        Text="Languages"></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Panel ID="Panel3" runat="server" ScrollBars="Vertical" CssClass="panel">
                                                        <asp:CheckBoxList ID="chklang" runat="server"></asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px"> 
                                                    &nbsp;</td>
                                                <td align="left" style="width: 100px; height: 40px">
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" 
                                                        Text="Add new"></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 225px; height: 40px">
                                                    <asp:TextBox ID="txtlang" runat="server" CssClass="s_textbox" Width="120px"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnaddlang" runat="server" Text="Save" 
                                                        Height="26px" CssClass="s_button" onclick="btnaddlang_Click"/>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>                                          
                                            <tr>
                                                <td align="left" colspan="6" style="height : 20px">
                                                </td>
                                            </tr>
                                             <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" 
                                                        Text="Extra-Curricular Activities "></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Panel ID="Panel2" runat="server" CssClass="panel" ScrollBars="Vertical">
                                                        <asp:CheckBoxList ID="chkextra" runat="server"></asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px"> 
                                                    &nbsp;</td>
                                                <td align="left" style="width: 100px; height: 40px">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" 
                                                        Text="Add new"></asp:Label>
                                                    </td>
                                                <td align="left" style="width: 225px; height: 40px">
                                                    <asp:TextBox ID="txtextra" runat="server" CssClass="s_textbox" Width="120px"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="addextra" runat="server" Text="Save" 
                                                        Height="26px" onclick="addextra_Click" CssClass="s_button"/>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="6" style="height : 20px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" style="height : 20px">
                                                    <asp:Button ID="btnsave" runat="server" Text="Next.." 
                                                        CssClass="s_button" onclick="btnsave_Click" />
                                                    &nbsp;<asp:Button ID="btncancel" runat="server" Text="Cancel" 
                                                        style="height: 26px" CssClass="s_button" onclick="btncancel_Click" 
                                                        Visible="False" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="6">
                                                </td>
                                            </tr>
                                        </table>
                                                </ContentTemplate>
                                         </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:10px;"></td>
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
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>