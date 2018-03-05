<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignroom_date.aspx.cs" Inherits="admission_assignroom_date" %>

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
    <title>The Schools.in - Admin</title>
     <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" /> 
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>
	<link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />    
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>  
    <script type="text/javascript">
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txttime').timepicker();
               
            }
        });
        $(document).ready(function() {
            $('#txttime').timepicker();
        });
               
    </script> 
     <script type="text/javascript">
         $(document).ready(function() {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             function EndRequestHandler(sender, args) {
                 $('#txtdate').datepicker({ dateFormat: 'yy/mm/dd',
                     changeMonth: true,
                     constrainDates: true,
                     changeYear: true
                 });
             }
         });
         $(function() {
             var dates = $("#txtdate").datepicker({
                 constrainDates: true,
                 dateFormat: 'yy/mm/dd',
                 changeMonth: true,
                 changeYear: true
             });
         }); 
    </script> 
      
   
    <style type="text/css">
        .style1
        {
            width: 150px;
            height: 40px;
        }
        .style2
        {
            width: 200px;
            height: 40px;
        }
        .style3
        {
            width: 350px;
            height: 40px;
        }
        .style4
        {
            width: 700px;
            height: 20px;
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
                                        <table cellpadding="0" cellspacing="0" border="0" width="900px">
                                             <tr>
                                               <td class="app_cont_title_img_td"><img src="../images/icons/50X50/76.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td style="width: 730px; height: 50px">
                                                    Assign Room, Date And Invigilator For Admission Exams</td>
                                                    <td style="width: 100px; height: 50px">
                                                   <asp:Label ID="Label9" runat="server" CssClass="title_label" Text="Select"></asp:Label></td>
                                                    <td style="width: 300px; height: 40px" align="left">
                                                    <asp:Label ID="Label7" runat="server" CssClass="title_label" Text="Appoved/Waitlisted Approved"></asp:Label>
                                                     <asp:DropDownList ID="ddlapproval" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlapproval_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Approved</asp:ListItem>
                                                    <asp:ListItem Value="2">Waitlisted Approved</asp:ListItem>
                                                   </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                              <%--  <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>--%>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" class="app_container">
                                            <tr>
                                                <td colspan="4" align="right" class="style4"></td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Interview Date"></asp:Label>
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txtdate" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                     
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Interview Time"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txttime" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 450px; height: 40px">
                                                    &nbsp;
                                                    <asp:Label ID="Label56" runat="server" CssClass="s_label" Text="Do you to assign the building details ?"></asp:Label>
                                               </td>
                                               <td align="left" style= " height: 40px">
                                                    <asp:RadioButton ID="RBsY" runat="server" AutoPostBack="True" CssClass="s_label" GroupName="building" oncheckedchanged="RBsY_CheckedChanged" Text="Yes" />
                                                    <asp:RadioButton ID="RBsN" runat="server" Checked="True" AutoPostBack="True" CssClass="s_label" GroupName="building" oncheckedchanged="RBsN_CheckedChanged" Text="No" />
                                                </td>
                                            </tr>
                                            <tr id="trbuildingname" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Building Name"></asp:Label>
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                   <asp:DropDownList ID="ddlbuildname" runat="server" CssClass="s_dropdown" Width="173px" AutoPostBack="True" onselectedindexchanged="ddlbuildname_SelectedIndexChanged">
                                                     </asp:DropDownList>
                                                    </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Floors"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                   <asp:DropDownList ID="ddlfloor" runat="server" CssClass="s_dropdown" Width="171px"  AutoPostBack="True" onselectedindexchanged="ddlfloor_SelectedIndexChanged">                                                      
                                                   </asp:DropDownList>
                                                        
                                                </td>
                                            </tr>
                                            <tr id="trroomnumber" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                     &nbsp;
                                                     <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Room Number"></asp:Label>
                                                     &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlroomno" runat="server" CssClass="s_dropdown" 
                                                        Width="171px"  AutoPostBack="True" 
                                                        onselectedindexchanged="ddlroomno_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                   <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Room Name"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                   <asp:Label ID="lblroomname" runat="server" CssClass="s_label"></asp:Label>
                                                        
                                              </td>
                                            </tr>
                                            <tr id="trroomcapacity" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                   <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Room Capacity"></asp:Label>
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                   <asp:Label ID="lblroomcapacity" runat="server" CssClass="s_label"></asp:Label>
                                                 </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Staff Name"></asp:Label>
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                   
                                                    <asp:DropDownList ID="ddlstaff" runat="server" Width="170px" 
                                                        AutoPostBack="True" onselectedindexchanged="ddlstaff_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Contact Person"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txtcontact" runat="server" CssClass="s_textbox" 
                                                        Width="180px"></asp:TextBox>
                                                        
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style1">
                                                    &nbsp;
                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" class="style2" >
                                                     <asp:Panel ID="Panel1" runat="server" BackColor="#F7F7F7" BorderColor="#1874CD" BorderWidth="1px" Height="75px" ScrollBars="Vertical" Width="180px">
                                                        <asp:CheckBoxList ID="chkstandard" runat="server" CssClass="s_label" 
                                                            AutoPostBack="True" onselectedindexchanged="chkstandard_SelectedIndexChanged"></asp:CheckBoxList>
                                                     </asp:Panel>
                                                </td>
                                                <td align="left" colspan="2" class="style3">
                                                <table id="seats" runat="server">
                                                    <tr>
                                                        <td style="width: 250px; height: 40px" align="left">
                                                    <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Available Seats:"></asp:Label>
                                                        </td>
                                                        <td style="width: 50px; height: 40px" align="left">
                                                     <asp:Label ID="labelcount" runat="server" CssClass="s_label" Text="0"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id= "trlabel" runat="server">
                                                    <td colspan="2">
                                                    <tr>
                                                        <td style="width: 250px; height: 40px" align="left">
                                                    <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="Seats to be allocated:"></asp:Label>
                                                        </td>
                                                        <td style="width: 50px; height: 40px" align="left">
                                                    <asp:Label ID="lblallocated" runat="server" CssClass="s_label">0</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td style="width: 300px; height: 40px" align="left" colspan="2">
                                                        &nbsp;
                                                    <asp:Button ID="btnallocate" runat="server" CssClass="s_button" Text="Allocate" 
                                                        Width="60px" onclick="btnallocate_Click" />
                                                        &nbsp;&nbsp;
                                                    <asp:Button ID="btnavailable" runat="server" CssClass="s_button" Text="Only Available Seats" 
                                                        Width="150px" onclick="btnavailable_Click" />
                                                        &nbsp;&nbsp;
                                                    <asp:Button ID="btncancel" runat="server" CssClass="s_button" Text="Cancel" 
                                                        Width="60px" onclick="btncancel_Click" />
                                                        &nbsp;&nbsp;
                                                    </td>
                                                    </tr>
                                                     </td>
                                                    </tr>
                                                </table>
                                              </td>
                                             </tr>
                                            <tr>
                                                <td style="width: 150px; height: 70px" align="left">
                                                    &nbsp;&nbsp;<asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Remarks"></asp:Label></td>
                                                <td style="width: 200px; height: 100px" align="left">
                                                   <asp:TextBox ID="txtremarks" runat="server" CssClass="s_textbox" 
                                                        Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                                                                            
                                                    </td>
                                                <td style="width: 150px; height: 40px" align="right">
                                                   
                                                        </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr id="trsave" runat="server">
                                                <td align="center" colspan="6" style="width: 700px; height: 40px">
                                                     <asp:Button ID="btnsave" runat="server"  CssClass="s_button" Text="Save" 
                                                         Width="60px" onclick="btnsave_Click1"/>
                                                        <asp:Button ID="btnclear" runat="server"  CssClass="s_button" Text="Clear" 
                                                         Width="60px" onclick="btnclear_Click" />
                                                    <asp:Label ID="lblhid" runat="server" Text="0" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                           <%-- <tr id="trsave" runat="server">
                                                <td colspan="4" align="center">
                                                     <asp:Button ID="btnsave" runat="server"  CssClass="s_button" Text="Save" Width="60px" onclick="btnsave_Click" />
                                                </td>
                                            </tr>--%>
                                            <tr>
                                              <td  style="height: 40px" colspan="4">
                                                    &nbsp;
                                                     <asp:DataGrid ID ="dgadmissioninterview" runat="server" CellPadding="4" 
                                                        GridLines="None" Width="850px"
                                                        AutoGenerateColumns="False" 
                                                        oneditcommand="dgadmissioninterview_EditCommand">
                                                         <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                         <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText=" ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dtdate" HeaderText="Interview Date" >
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dttime" HeaderText="Interview Time">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strbuildingname" HeaderText="Building Name">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strfloor" HeaderText="Floors"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strroomname" HeaderText="Room Name">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strstandard" HeaderText="Standard">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intfromappl" HeaderText="From Appl">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="inttoappl" HeaderText="To Appl"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="name" HeaderText="Staff Name"></asp:BoundColumn>
                                                            <asp:ButtonColumn HeaderText="Edit" 
                                                                
                                                                Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;" 
                                                                CommandName="edit">
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

