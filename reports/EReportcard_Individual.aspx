<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EReportcard_Individual.aspx.cs" Inherits="reports_EReportcard_Individual" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
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
	<script type="text/javascript">
	    $(document).ready(function() {
	        $('#chkAll').click(
             function() {
                 $("INPUT[type='checkbox']").attr('checked', $('#chkAll').is(':checked'));
             });
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
            <td style="width: 98%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 98%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                               <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/40.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >E-Report Card</td>  
                                                <td style="width:50px"></td>                                                               
                                                <td><asp:Label ID="lblacademicyear" CssClass="title_label" runat="server" Text="Academic Year : "></asp:Label></td>
                                                <td><asp:DropDownList ID="ddlacademicyear" runat="server" CssClass="s_dropdown" Width="60px"></asp:DropDownList></td>
                                                <td><div class="title_label">
                                                    <asp:RadioButton ID="RadioButton1" runat="server" Text="General" 
                                                        GroupName="rdreport" AutoPostBack="True" 
                                                        oncheckedchanged="RadioButton1_CheckedChanged"  />
                                                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Performance" 
                                                        GroupName="rdreport" AutoPostBack="True" 
                                                        oncheckedchanged="RadioButton2_CheckedChanged" />
                                                    <asp:RadioButton ID="RadioButton3" runat="server" Text="Individual" 
                                                        GroupName="rdreport" Checked="true" /></div>
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
                                    <td align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="905px" class="thick_curve">
                                            <tr class="view_detail_subtitle_bg">
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="subtitle_label" Text="Sort Report by"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 905px; height: 20px" align="center">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>                                                                                                                        
                                                            <td style="height: 30px" align="left">&nbsp;
                                                            <asp:Label ID="Label17" 
                                                                    runat="server" CssClass="s_label" 
                                                                    Text="Standard & Sec :"></asp:Label>
                                                            </td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                                    AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged"  >
                                                                </asp:DropDownList>
                                                            </td> 
                                                            <td style=" height: 30px" align="left">
                                                                <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="Student :"></asp:Label>
                                                            </td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:DropDownList ID="ddlstudent" runat="server" CssClass="s_dropdown" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Exam Type :"></asp:Label></td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:TextBox ID="txtexamtype" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                                 <ajaxtoolkit:PopupControlExtender ID="TextBox1_PopupControlExtender" runat="server"
                                                                    Enabled="True" ExtenderControlID="" TargetControlID="txtexamtype" 
                                                                    PopupControlID="stdandsec" OffsetY="22">
                                                                 </ajaxtoolkit:PopupControlExtender>
                                                                <asp:Panel ID="stdandsec" runat="server" ScrollBars="Vertical" Height="150" BackColor="white" BorderColor="#1874CD" BorderWidth="1px">
                                                                <asp:CheckBox ID="chkAll" runat="server" Text="Select All" CssClass="s_dropdown" style="float:left;margin-left:3px;"  />
                                                                <asp:Button ID="btnsend" runat="server" CssClass="s_button" Text="Apply" 
                                                                        onclick="btnsend_Click" />
                                                                <asp:CheckBoxList ID="ddlexamtype" runat="server" CssClass="s_dropdown" 
                                                                        Width="150px">
                                                                </asp:CheckBoxList>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 30px; text-align: center;" align="left" colspan="6">
                                                                <asp:RadioButton ID="rdReportcard" Text="Reportcard" Checked="true" 
                                                                    runat="server" GroupName="rdreportcard" AutoPostBack="true" 
                                                                    oncheckedchanged="rdReportcard_CheckedChanged" />
                                                                <asp:RadioButton ID="rdPassed" Text="Passed" runat="server" AutoPostBack="true"
                                                                    GroupName="rdreportcard" oncheckedchanged="rdPassed_CheckedChanged" />
                                                                <asp:RadioButton ID="rdFailed" Text="Failed" runat="server" AutoPostBack="true"
                                                                    GroupName="rdreportcard" oncheckedchanged="rdFailed_CheckedChanged" />
                                                                <asp:RadioButton ID="rdCompare" Text="Compare" runat="server" AutoPostBack="true"
                                                                    GroupName="rdreportcard" oncheckedchanged="rdCompare_CheckedChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto" style="width:905px">
                                            <tr class="view_detail_title_bg">
                                                <td align="left"><asp:Label ID="lbltitle" runat="server" Text="Reports" CssClass="title_label"></asp:Label> </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 1px" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="905px">
                                                        <tr>
                                                            <td style="width:905px; height: 600px;z-index:9999" valign="top" align="left">
                                                             <div id="trmsg" runat="server" visible="false"><asp:Label ID="lblmsg" runat="server" CssClass="s_label"></asp:Label></div>
                                                             <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
                                                                AutoDataBind="true" HasZoomFactorList="False" HasCrystalLogo="False" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td style="height:40px"></td></tr>
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
 </body>
</html>
