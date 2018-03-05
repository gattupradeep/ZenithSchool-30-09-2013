<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Promote.aspx.cs" Inherits="admin_Promote" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/admin_promote.ascx" tagname="admin_promote" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" /> 
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>
	
    <script type="text/javascript">
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtdate').datepicker({ dateFormat: 'dd/mm/yy',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(function() {
            var dates = $("#txtdate").datepicker({
                constrainDates: true,
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
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
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="230">
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc1:admin_promote ID="admin_promote1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/361.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Students Promote To Next Year</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="promote" DisplayMode="BulletList" 
                                        HeaderText="Please fill the following errors" EnableClientScript="true" ShowMessageBox="true" 
                                        CssClass="s_label" Height="100%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" class="app_container_auto" >
                                            <tr>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="950px">
                                                        <tr id="trdegree" runat="server">
                                                            <td align="left" style="width: 150px; height: 40px">
                                                                &nbsp;
                                                               <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                             </td>
                                                            <td align="left" style="width: 175px; height: 40px">
                                                                <asp:TextBox ID="txtdate" runat="server" CssClass="s_textbox" Width="120px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;
                                                               <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Current Year"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 150px; height: 40px">
                                                                <asp:DropDownList ID="ddlyear" runat="server" CssClass="s_textbox" Width="160px" AutoPostBack="True" onselectedindexchanged="ddlyear_SelectedIndexChanged">                                                        
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;
                                                               <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Current Standard"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 150px; height: 40px">
                                                                <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_textbox" Width="160px" AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged">                                                        
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                &nbsp;
                                                               <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Promote Standard"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 150px; height: 40px">
                                                                <asp:DropDownList ID="ddlpromotestand" runat="server" CssClass="s_textbox" AutoPostBack="true"
                                                                    Width="160px" onselectedindexchanged="ddlpromotestand_SelectedIndexChanged">                                                        
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlpromotestand" 
                                                                InitialValue="0" ValidationGroup="promote" ErrorMessage="Please select the promote standard" >*
                                                                </asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" style="width: 150px; height: 40px">
                                                                &nbsp;
                                                               <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Section"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 150px; height: 40px">
                                                                <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_textbox" 
                                                                    Width="160px" onselectedindexchanged="ddlsection_SelectedIndexChanged">                                                        
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="height:30px"></td>
                                                        </tr>
                                                       
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trgrid" runat="server" visible="false">
                                                <td align="center">
                                                    <asp:DataGrid ID="dgpromote" Width="100%" runat="server" AutoGenerateColumns="False" 
                                                        BorderStyle="None" BorderWidth="0px" GridLines="None"> 
                                                       <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                        <ItemStyle CssClass="s_datagrid_item"/>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="false"></asp:BoundColumn>                                                            
                                                            <asp:BoundColumn DataField="studentname" HeaderText="Student Name">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intadmitno" HeaderText="Admission No">
                                                            </asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Promotion Status">
                                                               <ItemTemplate>
                                                                    <asp:RadioButton ID="rbtnpromote" runat="server" Text="Promotion" GroupName="promote" Checked="true" CssClass="s_label" /> <asp:RadioButton ID="rbtndepromote" runat="server" Text="De-Promotion" GroupName="promote" CssClass="s_label"/>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                         </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height:30px"></td>
                                            </tr>
                                            <tr id="trbutton" runat="server" visible="false">
                                                <td align="center" style="width: 950px; height: 40px; margin-left: 40px;">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="s_button" Text="Save" ValidationGroup="promote" 
                                                        Width="60px" onclick="btnSave_Click" Height="27px" />
                                                   
                                                   <%-- <asp:Button ID="btncancel" runat="server" CssClass="s_button" Text="Cancel" 
                                                        Width="60px" Height="27px" onclick="btncancel_Click" />--%>
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
            </td>
        </tr>
    </table>
     <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

