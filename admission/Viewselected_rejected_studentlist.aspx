<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Viewselected_rejected_studentlist.aspx.cs" Inherits="admission_viewselected_rejected_studentlist" %>
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
            width: 700px;
            height: 13px;
        }
        .style2
        {
            height: 210px;
        }
        .style3
        {
            width: 100%;
            height: 10px;
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
                                        <uc1:admission ID="admission1" runat="server" />
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
                                        <table cellpadding="0" cellspacing="0" border="0" width="950px">
                                           <tr>
                                            <td class="app_cont_title_img_td"><img src="../images/icons/50X50/76.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td style="width: 750px; height: 50px"> 
                                                  View Selected Rejected Studentlist </td>
                                               <td style="width: 100px; height: 50px">
                                                   <asp:Label ID="Label7" runat="server" CssClass="title_label" Text="Shortlist Type"></asp:Label></td>
                                                   <td style="width: 350px; height: 50px" align="center">
                                                        <asp:Label runat="server" ID="Label2" CssClass="title_label" Text="Approved/Waitlisted Approved"></asp:Label>
                                                        <asp:DropDownList ID="ddllist" runat="server" CssClass="s_dropdown" Width="105px" AutoPostBack="True" onselectedindexchanged="ddllist_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Approved</asp:ListItem>
                                                           <asp:ListItem Value="2">WaitlistApproved</asp:ListItem>
                                                        </asp:DropDownList>
                                                   </td>
                                                 <td style="width: 230px; height: 50px" align="center">
                                                    <asp:Label ID="Label10" runat="server" CssClass="title_label" Text="Approved / Rejected"></asp:Label>
                                                    <asp:DropDownList ID="ddlstatus" runat="server" Width="110px" AutoPostBack="True" onselectedindexchanged="ddlstatus_SelectedIndexChanged">
                                                     <asp:ListItem Value="0">Select</asp:ListItem>
                                                      <asp:ListItem Value="1">Approved</asp:ListItem>
                                                           <asp:ListItem Value="2">Rejected</asp:ListItem>
                                                     </asp:DropDownList>
                                                   </td>
                                                   
                                            </tr>                               
                                        </table>
                                    </td>
                                           
                                </tr>
                                <tr>
                                    <td class="style3"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="700px" class="app_container">
                                         <tr>
                                                <td style="width:100px; height: 30px" align="left">
                                                  <asp:Label ID="Label" runat="server" CssClass="s_label" Text="Interview Date"></asp:Label>
                                                </td>
                                                <td style="width: 50px; height: 30px" align="left">
                                                     <asp:DropDownList ID="ddldate" runat="server" Width="105px" AutoPostBack="True"  onselectedindexchanged="ddldate_SelectedIndexChanged">
                                                     </asp:DropDownList>
                                                  
                                               </td>
                                               <td style="width:150px; height: 30px" align="left">
                                                   <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Standard"></asp:Label> 
                                               </td>
                                               <td style="width:50px; height: 30px" align="left">
                                                   <asp:DropDownList ID="ddlstandard" runat="server" Width="110px" AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged"></asp:DropDownList>
                                               </td>
                                               <td style="width: 100px; height: 30px" align="left">
                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Student Name" Width="100px"></asp:Label>
                                                </td>
                                                <td style="width: 100px; height: 30px" align="left">
                                                  <asp:DropDownList ID="ddlstudent" runat="server" Width="110px" AutoPostBack="True" onselectedindexchanged="ddlstudent_SelectedIndexChanged">
                                                  </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="right" class="style1">&nbsp;</td>
                                            </tr>
                                           <tr>
                                              <td colspan="6" class="style2">
                                                    &nbsp;
                                                     <asp:DataGrid ID ="dgadmissionapproveresult" runat="server" CellPadding="4" 
                                                        GridLines="None" Width="850px"
                                                        AutoGenerateColumns="False" 
                                                        onupdatecommand="dgadmissionresult_UpdateCommand" >
                                                         <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                         <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText=" ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intapplication" HeaderText="Application No">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="name" HeaderText="Student Name">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="str_standard" HeaderText="Standard"></asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="update" HeaderText="View" 
                                                        Text="&lt;img src=&quot;../media/images/view.png&quot; alt=&quot;&quot; border=&quot;0&quot;/&gt;">
                                                      </asp:ButtonColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
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
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top">
                <uc4:footer ID="footer1" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

