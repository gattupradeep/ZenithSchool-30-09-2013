<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignstudentmarks.aspx.cs" Inherits="admission_assignstudentmarks" %>
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
            height: 40px;
            width: 153px;
        }
        .style2
        {
            width: 700px;
            height: 18px;
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
                <uc3:topbanner ID="topbanner" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
                <uc2:topmenu ID="topmenu" runat="server" />
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
                                        <table cellpadding="0" cellspacing="0" border="0" width="900px">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/76.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td style="width: 350px; height: 50px">
                                                    Assign Admission Exam Marks</td>
                                                    <td style="width: 60px; height: 50px">
                                                   <asp:Label ID="Label7" runat="server" CssClass="title_label" Text="Select" Width="46px"></asp:Label></td>
                                                    <td style="width: 300px; height: 50px" align="center">
                                                    <asp:Label ID="Label2" runat="server" CssClass="title_label" Text="Approved/Waitlisted Approved"></asp:Label>
                                                     <asp:DropDownList ID="ddllist" runat="server" CssClass="s_dropdown" Width="105px" AutoPostBack="True" onselectedindexchanged="ddllist_SelectedIndexChanged">
                                                     <asp:ListItem Value="0">Select</asp:ListItem>
                                                     <asp:ListItem Value="1">Approved</asp:ListItem>
                                                           <asp:ListItem Value="2">WaitlistApproved</asp:ListItem>
                                                      </asp:DropDownList>
                                                   </td>
                                                   <td style="width: 150px; height: 50px" align="center">
                                                    <asp:Label ID="Label3" runat="server" CssClass="title_label" Text="Interview Date"></asp:Label>
                                                     <asp:DropDownList ID="ddldate" runat="server" Width="105px" AutoPostBack="True" onselectedindexchanged="ddldate_SelectedIndexChanged">
                                                     </asp:DropDownList>
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
                                                <td colspan="4" align="right" class="style2"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                </td>
                                                <td align="left" class="style1">
                                                   
                                                    <asp:DropDownList ID="ddlstandard" runat="server" Width="170px" 
                                                        AutoPostBack="True" 
                                                        onselectedindexchanged="ddlstandard_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                
                                                    </td>
                                                <%--<td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label26" runat="server" CssClass="s_label" Text="Attendance"></asp:Label>
                                                </td>--%>
                                                <%--<td style="width: 150px; height: 40px" align="left">
                                                   
                                                   <asp:Label ID="lblattendance" runat="server" CssClass="s_label"></asp:Label>
                                                
                                                </td>--%>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label22" runat="server" CssClass="s_label" Text="Maximum Marks"></asp:Label>
                                                </td>
                                                <td align="left" class="style1">
                                                   
                                                   <asp:Label ID="lblmarks" runat="server" CssClass="s_label"></asp:Label>
                                                
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label23" runat="server" CssClass="s_label" Text="Pass Mark"></asp:Label>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                   
                                                   <asp:Label ID="lblpassmark" runat="server" CssClass="s_label"></asp:Label>
                                                
                                                </td>
                                            </tr>
                                            <tr>
                                               <td  style="height: 40px" colspan="4">
                                                    &nbsp;
                                                     <asp:DataGrid ID ="dgadmissionresult" runat="server" CellPadding="4" 
                                                        GridLines="None" Width="850px"
                                                        AutoGenerateColumns="False" 
                                                        onitemdatabound="dgadmissionresult_ItemDataBound">
                                                         <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                         <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText=" ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intapplication" HeaderText="Application No">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strstudent" HeaderText="Student Name">
                                                            </asp:BoundColumn>
                                                           <%-- <asp:BoundColumn DataField="strattendance" HeaderText="Attendance">
                                                            </asp:BoundColumn>--%>
                                                              <asp:BoundColumn DataField="intmarksscored" HeaderText="Marks Scored" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Marks Scored" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                       <asp:TextBox ID="txtresult" runat="server" Width="150px" AutoPostBack="true" 
                                                            ontextchanged="txtresult_TextChanged" ></asp:TextBox> 
                                                    </ItemTemplate>
                                                      <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="strresult" HeaderText="Result"></asp:BoundColumn>
                                                            </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  style="height: 40px" colspan="4">
                                                    
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnupdate" runat="server" CssClass="s_button" 
                                                        onclick="btnupdate_Click" Text="Update" Width="70px" />
                                                    &nbsp;</td>
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

