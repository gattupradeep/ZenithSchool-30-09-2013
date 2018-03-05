<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewadmissionexamattendance.aspx.cs" Inherits="admission_viewadmissionexamattendance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/admission.ascx" tagname="admission" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc6" %>
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
            width: 100%;
            height: 10px;
        }
        .style2
        {
            height: 40px;
            width: 3px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
     <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:toolkitscriptmanager>
    <div>
    
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
                                        <uc1:admission ID="admission1" runat="server" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="width: 230px; height: 20px" align="right">
                                    </td>
                                </tr>
                                  <tr id="trtag" runat="server">
                                    <td style="width: 230px; height: 20px" align="right">
                                        <table cellpadding="0" cellspacing="0" border="0" width="230">
                                           <tr>
                                               <td style="width: 120px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Do you want building details?" 
                                                        Font-Bold="False"></asp:Label>
                                                </td>
                                                <td style="width: 100px; height: 30px" align="left">&nbsp;&nbsp;
                                                   
                                                    <asp:RadioButton ID="RBsY" runat="server" AutoPostBack="True" CssClass="s_label" GroupName="building" oncheckedchanged="RBsY_CheckedChanged" Text="Yes" />
                                                    <asp:RadioButton ID="RBsN" runat="server" AutoPostBack="True" Checked="True" CssClass="s_label" GroupName="building" oncheckedchanged="RBsN_CheckedChanged" Text="No" />
                                                   
                                                </td>
                                            </tr>
                                            <tr id="trrefined" runat="server">
                                                <td colspan="2" style="width: 230px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Refined Search" 
                                                        Font-Bold="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trbuilding" runat="server">
                                                <td style="width: 100px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Building Name"></asp:Label>
                                                </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    <asp:DropDownList ID="ddlbuildname" runat="server" Width="110px" 
                                                        AutoPostBack="True" 
                                                        onselectedindexchanged="ddlbuildname_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="trfloor" runat="server">
                                                <td style="width: 100px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="Floor"></asp:Label>
                                                </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                
                                                    <asp:DropDownList ID="ddlfloor" runat="server" Width="110px" 
                                                        AutoPostBack="True" onselectedindexchanged="ddlfloor_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                
                                                </td>
                                            </tr>
                                            <tr id="trroom" runat="server">
                                                <td style="width: 100px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="Room No"></asp:Label>
                                                </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                
                                                    <asp:DropDownList ID="ddlroom" runat="server" Width="110px" 
                                                        AutoPostBack="True" 
                                                        onselectedindexchanged="ddlroom_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                
                                                </td>
                                            </tr>
                                         </table>
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
                                        <table cellpadding="0" cellspacing="0" border="0" width="950px">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/76.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td style="width: 550px; height: 50px">
                                                    View Admission Exam Attendance Details</td>
                                                    <td style="width: 60px; height: 40px" align="left">
                                                      <asp:Label ID="Label8" runat="server" CssClass="title_label" Text="Select" Width="60px"></asp:Label>
                                                    </td>
                                                    <td style="width: 250px; height: 40px" align="left">
                                                     <asp:Label ID="Label3" runat="server" CssClass="title_label" Text="Approved/Waitlisted Approved"></asp:Label>
                                                        <asp:DropDownList ID="ddllist" runat="server" Width="100px" AutoPostBack="True" onselectedindexchanged="ddllist_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Approved</asp:ListItem>
                                                        <asp:ListItem Value="2">WaitlistApproved</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label20" runat="server" CssClass="title_label" 
                                                        Text="Interview Date"></asp:Label>
                                                        <asp:DropDownList ID="ddldate" runat="server" Width="100px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddldate_SelectedIndexChanged">
                                                       </asp:DropDownList>
                                                        </td>
                                                 </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" class="app_container">
                                           <tr>
                                                <td style="width:120px; height: 30px" align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Interview Time"></asp:Label>
                                                </td>
                                                <td style="width: 50px; height: 30px" align="left">
                                                    <asp:DropDownList ID="ddltime" runat="server" Width="130px" AutoPostBack="True" onselectedindexchanged="ddltime_SelectedIndexChanged"></asp:DropDownList>
                                               </td>
                                               <td style="width:100px; height: 30px" align="left">
                                                    <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                </td>
                                               <td style="width:50px; height: 30px" align="left">
                                                    <asp:DropDownList ID="ddlstandard" runat="server" Width="130px" AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                              </td>
                                              <td style="width: 200px; height: 30px" align="left">
                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Attendance Type" ></asp:Label>
                                                </td>
                                                <td style="width: 500px; height: 30px" align="left">
                                                  <asp:DropDownList ID="ddlattendance" runat="server" Width="130px" AutoPostBack="True" onselectedindexchanged="ddlattendance_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="width: 900px; height: 20px" align="right">&nbsp;</td>
                                            </tr>
                                           <tr>
                                            
                                               <td  style="height: 40px" colspan="6" class="app_container">
                                                   <asp:DataGrid ID ="dgadmissionattendance" runat="server" CellPadding="4" GridLines="None"
                                                        AutoGenerateColumns="False" Width="900px">
                                                         <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                         <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText=" ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intapplication" HeaderText="Application No">
                                                           </asp:BoundColumn>
                                                           <asp:BoundColumn DataField="strstandard" HeaderText="Standard">
                                                           </asp:BoundColumn>
                                                           <asp:BoundColumn DataField="strstudent" HeaderText="Student Name">
                                                           </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strattendance" HeaderText="Attendance">
                                                            </asp:BoundColumn>
                                                            </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr id="trpresent" runat="server">
                                                <td style="width: 150px; height: 40px" align="right">
                                                    
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                   
                                                </td>
                                                <td style="width: 100px; height: 40px" align="right">
                                                    &nbsp;</td>
                                               <td style="width: 10px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                        <td style="width: 100px; height: 40px" align="left">
                                                   <asp:Label ID="Label19" runat="server" CssClass="s_label" 
                                                        Text="Total Present"></asp:Label>
                                                        </td>
                                                         <td style="width: 10px; height: 40px" align="left">
                                                    <asp:Label ID="lblpresent" runat="server" CssClass="s_label" Text="0"></asp:Label>
                                                        </td>
                                            </tr>
                                            <tr id="trabsent" runat="server">
                                             <td style="width: 150px; height: 40px" align="right">
                                                    
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                   
                                                </td>
                                                <td style="width: 100px; height: 40px" align="right">
                                                
                                                 </td>
                                                 <td style="width: 100px; height: 40px" align="right">
                                                
                                                 </td>
                                                  <td style="width: 100px; height: 40px" align="left">
                                                   <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Total Absent"></asp:Label>
                                                   </td>
                                                    <td style="width: 10px; height: 40px" align="left">
                                                       <asp:Label ID="lblabsent" runat="server" CssClass="s_label">0</asp:Label>
                                                        
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
            <td style="width: 100%; height: 50px" align="left" valign="top">
                <uc6:footer ID="footer1" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

