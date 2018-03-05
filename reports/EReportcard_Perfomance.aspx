<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EReportcard_Perfomance.aspx.cs" Inherits="reports_EReportcard_Perfomance" %>
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
                                                    <asp:RadioButton ID="RadioButton1" runat="server" Text="General" AutoPostBack="True"
                                                        GroupName="rdreport" oncheckedchanged="RadioButton1_CheckedChanged" />
                                                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Performance" 
                                                        GroupName="rdreport" Checked="true" />
                                                    <asp:RadioButton ID="RadioButton3" runat="server" Text="Individual" 
                                                        GroupName="rdreport" AutoPostBack="True" 
                                                        oncheckedchanged="RadioButton3_CheckedChanged" /></div>
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
                                                            <td style="height: 30px" align="left">&nbsp;&nbsp;<asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Exam Type :"></asp:Label></td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:DropDownList ID="ddlexamtype" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlexamtype_SelectedIndexChanged" >
                                                                </asp:DropDownList>
                                                            </td> 
                                                            <td style=" height: 30px" align="left">&nbsp;&nbsp;<asp:Label ID="Label17" 
                                                                    runat="server" CssClass="s_label" 
                                                                    Text="Class :"></asp:Label></td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" AutoPostBack="true" 
                                                                    Width="150px" onselectedindexchanged="ddlstandard_SelectedIndexChanged" >
                                                                </asp:DropDownList>
                                                            </td>                                                           
                                                            <td style="height: 30px" align="left" colspan="2">
                                                                <asp:Label ID="Label19" runat="server" CssClass="s_label" 
                                                                    Text="Section :"></asp:Label>
                                                            </td>                                                            
                                                            <td style=" height: 30px" align="left">
                                                                <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_dropdown" 
                                                                    Width="90px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlsection_SelectedIndexChanged" >
                                                                </asp:DropDownList>
                                                            </td>                                                            
                                                        </tr>
                                                        <tr>                                                                                                                        
                                                            <td style="height: 30px" align="left">&nbsp;
                                                                <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="Subject :"></asp:Label>
                                                            </td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_dropdown" 
                                                                    AutoPostBack="True" onselectedindexchanged="ddlsubject_SelectedIndexChanged" >
                                                                </asp:DropDownList>
                                                            </td> 
                                                            <td style=" height: 30px" align="left">
                                                                <asp:Label ID="Label20" runat="server" CssClass="s_label" Text="Average :"></asp:Label>
                                                                    </td>
                                                            <td style="height: 30px" align="left" colspan="2">
                                                                <asp:Label ID="Label21" runat="server" CssClass="s_label" Text="From  :"></asp:Label>
                                                                <asp:TextBox ID="txtavgfrom" runat="server" CssClass="s_textbox" Width="40px"></asp:TextBox>                                                                 
                                                                % &nbsp;&nbsp;<asp:Label ID="Label22" runat="server" CssClass="s_label" Text="To :"></asp:Label><asp:TextBox ID="txtavgto" runat="server" CssClass="s_textbox" Width="40px"></asp:TextBox>%
                                                                 </td>
                                                            <td style="height: 30px" align="left" colspan="2">
                                                                <asp:Label ID="Label23" runat="server" CssClass="s_label" Text="Top"></asp:Label>
                                                                <asp:DropDownList ID="ddltopten" runat="server">
                                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="Label24" runat="server" CssClass="s_label" Text="Rankers"></asp:Label>
                                                                 </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 30px" align="left">&nbsp;&nbsp;
                                                                </td>
                                                            <td style="height: 30px" align="left">
                                                                <asp:Button ID="btnreset" runat="server" Text="Reset" CssClass="s_button" 
                                                                    onclick="btnreset_Click" />
                                                            </td>                                                            
                                                            <td style=" height: 30px" align="left">&nbsp;&nbsp;
                                                                </td>
                                                            <td style=" height: 30px" align="left">
                                                            </td>                                                            
                                                            <td style=" height: 30px" align="left" colspan="2">
                                                                &nbsp;</td>                                                            
                                                            <td style=" height: 30px" align="left">
                                                                &nbsp;</td>                                                            
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