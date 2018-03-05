<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_students_attendance.aspx.cs" Inherits="attendance_edit_students_attendance" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/admin_attendance.ascx" tagname="admin_attendance" tagprefix="uc1" %>
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
    
    <link rel="stylesheet" href="../include/jquery-ui-1.8.14.custom.css" type="text/css" />
    <link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />
    <script type="text/javascript" src="../include/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>    
    <script type="text/javascript">
        $(document).ready(function() {
            $('#txtworkftime').timepicker();
        });
        $(document).ready(function() {
            $('#txtworktotime').timepicker();
        });
        function backgroundhide2() {
            document.getElementById("txtdate").style.background = 'none';
        }  
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
                                        <uc1:admin_attendance ID="admin_attendance1" runat="server" />
                                    </td>
                                </tr>
                                <tr><td style="width: 100%; height: 15px"></td></tr>
                                <tr>
                                    <td style="width: 230px; height: 15px">
                                        <table width="100%">
                                            <tr>
                                                <td style="height: 30px" align="left" colspan="2">
                                                   &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label80" runat="server" 
                                                        CssClass="s_label" Text="Refined search"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 90px; height: 30px" align="left">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label77" runat="server" CssClass="s_label" Text="From"></asp:Label>
                                                </td>
                                                <td style="width: 140px; height: 30px" align="left">
                                                     <ajaxtoolkit:CalendarExtender ID="Calendarextender1" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtfrom" TargetControlID="txtfrom">
                                                    </ajaxtoolkit:CalendarExtender>     
                                                    <asp:TextBox ID="txtfrom" runat="server" CssClass="s_textbox" Width="80px" AutoPostBack="True" ontextchanged="txtfrom_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 90px; height: 30px" align="left">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" CssClass="s_label" Text="To"></asp:Label>
                                                </td>
                                                <td style="width: 140px; height: 30px" align="left">
                                                    <ajaxtoolkit:CalendarExtender ID="Calendarextender2" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtto" TargetControlID="txtto">
                                                    </ajaxtoolkit:CalendarExtender> 
                                                    <asp:TextBox ID="txtto" runat="server" AutoPostBack="True" CssClass="s_textbox" ontextchanged="TextTo_TextChanged" Width="80px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
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
                                <tr><td style="height:40px"></td></tr>
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/48.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Edit Student Attendance</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="750">
                                            <tr>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Label ID="Label78" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:TextBox ID="txtdate" runat="server" Width="160px" CssClass="s_textbox"  
                                                        AutoPostBack="True"  ontextchanged="txtdate_TextChanged" 
                                                        onchange="backgroundhide2();"  />
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 90px; height: 40px">
                                                    <asp:Label ID="Label76" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:250px">
                                                    <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                        Width="160px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlstandard_SelectedIndexChanged">                                                       
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Label ID="Label79" runat="server" CssClass="s_label" Text="Section"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_dropdown" 
                                                        Width="160px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlsection_SelectedIndexChanged">                                                       
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 90px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="height: 40px; width:250px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                            </tr>&&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="center" style="height: 40px">
                                                    <asp:Label ID="lblmsg" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="left" style="width: 750px; height: 40px">
                                                    <asp:DataGrid ID="dgstudentattend" runat="server" AutoGenerateColumns="False" 
                                                         OnEditCommand="dgstudentattend_EditCommand" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                        <ItemStyle CssClass="s_datagrid_item" Font-Size="10px"/>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="date" HeaderText="Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundColumn>                                                          
                                                            <asp:BoundColumn DataField="id" HeaderText="Staff name" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="class" HeaderText="Class" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundColumn>                                                            
                                                            <asp:BoundColumn DataField="studentname" HeaderText="Student" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundColumn>               
                                                            <asp:BoundColumn DataField="strsession" HeaderText="Session" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strreason" HeaderText="Reason" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strclassteacher" HeaderText="Attendance<br />Taken by" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="staffname" HeaderText="Attendance<br />Entered by" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="Edit"
                                                                Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="40px" />
                                                            </asp:ButtonColumn>
                                                            <asp:TemplateColumn HeaderText="Delete">
                                                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btndelete" runat="server" 
                                                                        ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                                    OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                                        onclick="btndelete_Click"  />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete" 
                                                                Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>--%>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px; width: 150px;"></td>
                                                <td align="left" style="height: 40px; width: 175px;"></td>
                                                <td align="left" style="height: 40px; width: 30px;"></td>
                                                <td align="left" style="height: 40px; width: 150px;"></td>
                                                <td align="left" style="height: 40px; width: 175px;"></td>
                                                <td align="left" style="width: 30px; height: 40px"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px; width: 150px;">&nbsp;</td>
                                                <td align="right" style="height: 40px; width: 175px;">
                                                    &nbsp;</td>
                                                <td align="left" style="height: 40px; width: 30px;">&nbsp;</td>
                                                <td align="left" style="height: 40px; width: 150px;">
                                                    &nbsp;</td>
                                                <td align="left" style="height: 40px; width: 175px;">&nbsp;</td>
                                                <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px; width: 150px;">&nbsp;</td>
                                                <td align="left" style="height: 40px; width: 175px;">&nbsp;</td>
                                                <td align="left" style="height: 40px; width: 30px;">&nbsp;</td>
                                                <td align="left" style="height: 40px; width: 150px;">&nbsp;</td>
                                                <td align="left" style="height: 40px; width: 175px;">&nbsp;</td>
                                                <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="5" style="width: 710px; height: 40px"></td>
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
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
            </td>
        </tr>
    </table>
     <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
