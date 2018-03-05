<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_lesson_plan.aspx.cs" Inherits="student_view_lesson_plan" %>
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
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />   
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
   <%-- for Cal--%>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>    
     <script type="text/javascript">
         $(document).ready(function() {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             function EndRequestHandler(sender, args) {
                 $('#txtfrom').datepicker({ dateFormat: 'yy/mm/dd',
                     changeMonth: true,
                     constrainDates: true,
                     changeYear: true
                 });
             }
         });
         $(document).ready(function() {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             function EndRequestHandler(sender, args) {
                 $('#txtTo').datepicker({ dateFormat: 'yy/mm/dd',
                     changeMonth: true,
                     constrainDates: true,
                     changeYear: true
                 });
             }
         });
         $(function() {
             var dates = $("#txtfrom,#txtTo").daterangepicker({
                 constrainDates: true,
                 dateFormat: 'dd/mm/yy',
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
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="230">
                                <tr>
                                    <td style="width: 230px; margin-left: 80px;" align="right">
                                        <uc1:activities_lessonplan ID="activities_lessonplan1" runat="server" />
                                    </td>
                                </tr>
                                <tr>    
                                    <td class="break"></td>
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/52.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Search | View Lesson Plan</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 98%; padding-left:10px" valign="top" align="left">
                                     
                                         <table cellpadding="0" cellspacing="0" border="0" style="width: 98%;" >
                                            <tr>
                                                <td style="width: 98%; height: 20px" id="searchtable" class="thick_curve">
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                        <tr class="view_detail_subtitle_bg">
                                                            <td colspan="6"><asp:Label ID="lblsubtitle" runat="server" CssClass="subtitle_label" Text="Search"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_dropdown" Width="145px" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged" AutoPostBack="true" >
                                                                 </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Lesson Status"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddllessonstatus" runat="server" CssClass="s_dropdown" Width="145px" OnSelectedIndexChanged="ddllessonstatus_SelectedIndexChanged" AutoPostBack="true" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Teacher"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlteacher" runat="server" CssClass="s_dropdown" 
                                                                Width="145px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlteacher_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Subject"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_dropdown" Width="145px"
                                                                AutoPostBack="True" onselectedindexchanged="ddlsubject_SelectedIndexChanged" ></asp:DropDownList>
                                                            </td>
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
                                                                <span ><asp:Button ID="bttnget" runat="server" Text="Search" Width="50px" CssClass="s_button" OnClick="bttnsearch_click" /></span>
                                                            </td>
                                                        </tr>
                                                        <tr id="trtxtbook" runat="server" visible="false">
                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Textbook"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddltextbook" runat="server" CssClass="s_dropdown" Width="145px"  
                                                                AutoPostBack="True" onselectedindexchanged="ddltextbook_SelectedIndexChanged" 
                                                                ></asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Unit No / Unit Name"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlunitno" runat="server" CssClass="s_dropdown" Width="145px"
                                                                AutoPostBack="True" onselectedindexchanged="ddlunitno_SelectedIndexChanged" ></asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Lesson Name"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddllesson" runat="server" CssClass="s_dropdown" Width="145px" 
                                                                AutoPostBack="True" onselectedindexchanged="ddllesson_SelectedIndexChanged" ></asp:DropDownList> 
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>    
                                                <td class="break"></td>
                                            </tr>
                                            <tr>
                                                <td class="app_container_auto">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
                                                        <tr class="view_detail_title_bg">
                                                            <td><asp:Label ID="lbltitle" runat="server" CssClass="title_label" Text="Lesson Plan List"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="break"></td>
                                                        </tr>
                                                        <tr id="trerrorid" runat="server"><td align="center"><asp:Label ID="lblerror" runat="server" CssClass="nodatatodisplay" Text=""></asp:Label></td></tr>
                                                        <tr>
                                                            <td style="height: 40px" align="center"  width="100%">
                                                                <asp:DataGrid ID="dglessons" runat="server" AutoGenerateColumns="False" 
                                                                Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                                CellPadding="3">
                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="intid" HeaderText="intid" Visible="False">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="dtdate" HeaderText="Date">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strclassperiod" HeaderText="Period and Class"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="teachername" HeaderText="Teacher Name"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strsubject" HeaderText="Subject"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strtextbookname" HeaderText="Text Book"></asp:BoundColumn>
                                                                        <asp:BoundColumn HeaderText="Unit Name" DataField="strunitname"></asp:BoundColumn>
                                                                        <asp:BoundColumn HeaderText="Lesson Name" DataField="strlessonname"></asp:BoundColumn>
                                                                        <asp:BoundColumn HeaderText="Topic" DataField="strtopic"></asp:BoundColumn>
                                                                        <asp:BoundColumn HeaderText="Description" DataField="strdescription"></asp:BoundColumn>                                                                        
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
