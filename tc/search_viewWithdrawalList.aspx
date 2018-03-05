<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search_viewWithdrawalList.aspx.cs" Inherits="student_search_viewWithdrawalList" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/activities_lessonplan.ascx" tagname="activities_lessonplan" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/admin_tc.ascx" tagname="admin_tc" tagprefix="uc5" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
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
                $('.s_textbox').datepicker({ dateFormat: 'dd/mm/yy' });
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
                                        <uc5:admin_tc ID="admin_tc1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/279.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">View&nbsp;Withdrawal List</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    
                                    <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" class="title_label">&nbsp;&nbsp;&nbsp;View Withdrawal List</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width:200px; height:40px">
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Date :"></asp:Label>
                                                </td>
                                                <td align="left" style="width:200px; height:40px">
                                                    <asp:TextBox ID="txtdate" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox> 
                                                        
                                                </td>
                                                <td align="left" style="width:350px; height:40px">
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" 
                                                        Text="Approved/Rejected list :"></asp:Label>
                                                 </td>
                                                 <td align="left" style="width:350px; height:40px">
                                                   <asp:DropDownList ID="ddlList" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlList_SelectedIndexChanged">
                                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                        <asp:ListItem Value="Approved list" Text="Approved list"></asp:ListItem>
                                                        <asp:ListItem Value="Rejected list" Text="Rejected list"></asp:ListItem>
                                                    </asp:DropDownList>
                                                 </td>
                                            </tr> 
                                            <tr>
                                                <td align="center" style="width:200px; height:40px">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Admission No :"></asp:Label>
                                                    </td>
                                                <td align="left" style="width:200px; height:40px">
                                                    <asp:DropDownList ID="ddladmiss" runat="server" 
                                                        CssClass="s_dropdown" Width="100px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddladmiss_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width:350px; height:40px">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Student Name :"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width:350px; height:40px">
                                                      <asp:DropDownList ID="ddlstudent" runat="server" 
                                                        CssClass="s_dropdown" Width="150px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlstudent_SelectedIndexChanged">                                                   
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height:40px" visible="false">
                                                    <asp:Label ID="lblstatus" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="center" style="width:350px; height:40px" visible="false">
                                                    <asp:Label ID="lblpromotion" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="height:40px" visible="false">
                                                    <asp:Label ID="lblscholarship" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="center" style="width:350px; height:40px" visible="false">
                                                    <asp:Label ID="lblconcession" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td style="height: 40px" align="left" colspan="4">
                                                    <asp:DataGrid ID="dgwithdrawal" runat="server" AutoGenerateColumns="False" 
                                                    Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                    CellPadding="3" onupdatecommand="dgwithdrawal_UpdateCommand" 
                                                        oneditcommand="dgwithdrawal_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="intid" Visible="False" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intadmitno" HeaderText="Admission no" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="name" HeaderText="Student name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Date of request of withdrawal" DataField="dtrequest" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>                                                        
                                                            <asp:BoundColumn HeaderText="Date of Tc issued" DataField="tcissued" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dtleft" HeaderText="Date of leaving school" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="status" HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                            <asp:ButtonColumn HeaderText="View" Text="&lt;img src=&quot;../media/images/view.png&quot; alt=&quot;&quot; border=&quot;0&quot;/&gt;" CommandName="update"></asp:ButtonColumn>
                                                             <asp:ButtonColumn HeaderText="Printer" Text="&lt;img src=&quot;../media/images/Printer.png&quot; alt=&quot;&quot; border=&quot;0&quot;/&gt;" CommandName="edit">
                                                            <ItemStyle Width="70px" />
                                                        </asp:ButtonColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                    </asp:DataGrid>
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
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top" >
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
