<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Staff_Leave_Reports.aspx.cs" Inherits="reports_Staff_Leave_Reports" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
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
   <%-- for Cal--%>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>    
     <script type="text/javascript">
         $(function() {
             var dates = $("#txtfrom,#txtTo").daterangepicker({
             constrainDates: true,
                 dateFormat:'dd/mm/yy',
                 datepickerOptions: {
                     changeMonth: true,
                     changeYear: true
                 }
             });
         });
	</script>
	<style type="text/css">        
        #bttnget
        {
        	display:none;
        }
        #txtfrom,#txtTo { float: left; margin-right: 10px; }
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
            <td style="width: 98%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 98%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/48.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Staff Leave Reports</td>
                                                <%--<td><asp:Label ID="lblacademicyear" CssClass="s_label" runat="server" Text="Academic Year : "></asp:Label></td>
                                                <td><asp:DropDownList ID="ddlacademicyear" runat="server" CssClass="s_dropdown" Width="60px"></asp:DropDownList></td>
                                                <td><div class="s_label">
                                                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Date Wise" 
                                                        GroupName="rdreport" Checked="true" AutoPostBack="True" 
                                                        oncheckedchanged="RadioButton1_CheckedChanged" />
                                                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Current Week" 
                                                        GroupName="rdreport" AutoPostBack="True" 
                                                        oncheckedchanged="RadioButton2_CheckedChanged"  />
                                                    <asp:RadioButton ID="RadioButton3" runat="server" Text="Current Month" 
                                                        GroupName="rdreport" AutoPostBack="True" 
                                                        oncheckedchanged="RadioButton3_CheckedChanged"/></div>
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 98%" valign="top" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="905px" >
                                            <tr>
                                                <td style="height: 20px" id="searchtable" class="thick_curve">
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                        <tr class="view_detail_subtitle_bg" align="left">
                                                            <td colspan="6"><asp:Label ID="lblsubtitle" runat="server" CssClass="subtitle_label" Text="Sort Report by"></asp:Label> 
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Staff Type"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlstafftype" runat="server" CssClass="s_dropdown" 
                                                                    Width="145px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlstafftype_SelectedIndexChanged" >
                                                                 </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Department"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddldepartment" runat="server" CssClass="s_dropdown" 
                                                                    Width="145px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddldepartment_SelectedIndexChanged" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Staff Name"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlstaff" runat="server" CssClass="s_dropdown" 
                                                                    Width="145px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlstaff_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                             <td>
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="From Date"></asp:Label>
                                                             </td>
                                                             <td>
                                                                <asp:TextBox ID="txtfrom" runat="server" Width="140px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="To Date"></asp:Label>
                                                             </td>
                                                             <td>
                                                                <asp:TextBox ID="txtTo" runat="server" Width="140px"></asp:TextBox>                                                               
                                                                <span ><asp:Button ID="bttnget" runat="server" Text="Search" Width="50px" CssClass="s_button" /></span>
                                                            </td>
                                                            <td style="height: 30px" align="left">&nbsp;&nbsp;
                                                                </td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:Button ID="btnreset" runat="server" Text="Reset" CssClass="s_button" 
                                                                    onclick="btnreset_Click" />
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
                                                                         <cr:crystalreportviewer ID="CrystalReportViewer1" runat="server"
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
                                <tr>
                                    <td class="break"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
