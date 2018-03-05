<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_edit_viewattendance.aspx.cs" Inherits="admission_Add_edit_viewattendance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/admission.ascx" tagname="admission" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin - Department</title>
   <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />    
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>    
    <script type="text/javascript">
        $(document).ready(function() {

            $("ul#topnav li").hover(function() { //Hover over event on list item
                $(this).css({ 'background': '#88BB00 url(topnav_active.gif) repeat-x' }); //Add background color + image on hovered list item
                $(this).find("span").show(); //Show the subnav
            }, function() { //on hover out...
                $(this).css({ 'background': 'none' }); //Ditch the background
                $(this).find("span").hide(); //Hide the subnav
            });

        });
    </script>
    <link rel="stylesheet" href="../include/jquery-ui-1.8.14.custom.css" type="text/css" />
    <link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />
    <script type="text/javascript" src="../include/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>    
    <script type="text/javascript">
        $(document).ready(function() {
            $('#txttime').timepicker();
        });
        $(document).ready(function() {
            $('#txtpublishtime').timepicker();
        });
      
    </script>
    <style type="text/css">
        .style1
        {
            width: 150px;
            height: 28px;
        }
        .style2
        {
            width: 200px;
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 100%; height: 144px" align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
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
                                        <uc1:admission ID="admission" runat="server" />
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
                        <td style="width: 2%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                 <tr class="app_container_title">
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="850">
                                            <tr>
                                                 <td class="app_cont_title_img_td"><img src="../images/icons/50X50/76.png" class="app_cont_title_img" alt="icon" /></td>
                                                 <td style="width: 300px; height: 50px">
                                                     Add / Edit Attendance/td>
                                                    <td style="width: 60px; height: 40px" align="left">
                                                      <asp:Label ID="Label1" runat="server" CssClass="title_label" 
                                                        Text="Select" Width="60px"></asp:Label></td>
                                                    <td style="width: 250px; height: 40px" align="left">
                                                     <asp:Label ID="Label3" runat="server" CssClass="title_label" 
                                                        Text="Approved/Waitlisted Approved" ></asp:Label>
                                                        <asp:DropDownList ID="ddllist" runat="server" Width="140px" AutoPostBack="True" onselectedindexchanged="ddllist_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Approved</asp:ListItem>
                                                        <asp:ListItem Value="2">WaitlistApproved</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 130px; height: 40px" align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="title_label" 
                                                        Text="Interview Date"></asp:Label>
                                                        <asp:DropDownList ID="ddldate" runat="server" Width="140px" AutoPostBack="True" onselectedindexchanged="ddldate_SelectedIndexChanged"></asp:DropDownList> 
                                                </td>
                                                  
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>--%>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="700px" class="app_container">
                                            <tr>
                                                <td colspan="4" style="width: 700px; height: 20px" align="right">&nbsp;</td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" 
                                                        Text="Interview Time"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                         <asp:DropDownList ID="ddltime" runat="server" Width="140px" AutoPostBack="True" onselectedindexchanged="ddltime_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                               <td align="left" style="width: 300px; height: 40px">
                                                    <asp:Label ID="Label56" runat="server" CssClass="s_label" Text="Do you to assign the building details ?"></asp:Label>
                                               </td>
                                               <td align="left">
                                                    <asp:RadioButton ID="RBsY" runat="server" AutoPostBack="True" CssClass="s_label" GroupName="building" oncheckedchanged="RBsY_CheckedChanged" Text="Yes" />
                                                    <asp:RadioButton ID="RBsN" runat="server" AutoPostBack="True" Checked="True" CssClass="s_label" GroupName="building" oncheckedchanged="RBsN_CheckedChanged" Text="No" />
                                                </td>
                                            </tr>
                                            <tr id="trbuilding" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Building Name"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:DropDownList ID="ddlbuildname" runat="server" Width="140px" 
                                                        AutoPostBack="True" 
                                                        onselectedindexchanged="ddlbuildname_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                <td align="left" class="style1">
                                                    </td>
                                                <td align="left" class="style2">
                                                    </td>
                                            </tr>
                                            <tr id="trfloor" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Floor"></asp:Label>
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                
                                                    <asp:DropDownList ID="ddlfloor" runat="server" Width="140px" 
                                                        AutoPostBack="True" onselectedindexchanged="ddlfloor_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                
                                                    </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr id="trroom" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Room No"></asp:Label>
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                
                                                    <asp:DropDownList ID="ddlroom" runat="server" Width="140px" 
                                                        AutoPostBack="True" 
                                                        onselectedindexchanged="ddlroom_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                
                                                    </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Invigilator"></asp:Label>
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                
                                                    <asp:Label ID="lblinvigilator" runat="server" CssClass="s_label"></asp:Label>
                                                 </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                
                                                    &nbsp;</td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr id="trstandard" runat="server" class="view_detail_title_bg">
                                                  <td  style="height: 30px" align="left"> 
                                                  <asp:Label ID="Labelname" runat="server" CssClass="s_label" ForeColor="White" Text="Standard"></asp:Label></td>
                                                 <td  style="height: 30px" align="left" colspan="4">
                                                  <asp:DropDownList ID="ddlstandard" runat="server" Width="140px" 
                                                         AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                            
                                               <td  style="height: 40px" colspan="4">
                                                   <asp:DataGrid ID ="dgadmissionattendance" runat="server" CellPadding="4" GridLines="None"
                                                        AutoGenerateColumns="False" Width="800px" 
                                                        onitemdatabound="dgadmissionattendance_ItemDataBound" >
                                                         
                                                         <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                         <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText=" ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intapplication" HeaderText="Application No">
                                                           </asp:BoundColumn>
                                                           <asp:BoundColumn DataField="strstandard" HeaderText="Standard">
                                                           </asp:BoundColumn>
                                                           <asp:BoundColumn DataField="name" HeaderText="Student Name">
                                                           </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strattendance" HeaderText="Attendance" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Present" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                       <asp:CheckBox ID="chklist" runat="server" Width="150px" AutoPostBack="true"></asp:CheckBox>
                                                    </ItemTemplate>
                                                      <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateColumn>
                                                           </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                        Width="60px" onclick="btnSave_Click"/>
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" 
                                                        Width="60px" onclick="btnClear_Click" />
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
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

