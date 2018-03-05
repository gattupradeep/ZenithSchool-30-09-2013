<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_student_discipline.aspx.cs" Inherits="discipline_viewstudentsdiscipline" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/discipline.ascx" tagname="discipline" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
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
                $('#txtfrom').daterangepicker({ dateFormat: 'dd/mm/yy',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtTo').daterangepicker({ dateFormat: 'dd/mm/yy',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(function() {
            var dates = $("#txtfrom, #txtTo").daterangepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy',
                numberOfMonths: 1,
                onSelect: function(selectedDate) {
                    var option = this.id == "txtfrom" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker"),
					date = $.daterangepicker.parseDate(
						instance.settings.dateFormat ||
						$.daterangepicker._defaults.dateFormat,
						selectedDate, instance.settings);
                    dates.not(this).daterangepicker("option", option, date);
                }
            });
        });          
    </script> 
   <style type="text/css">
		        #txtfrom,#txtTo { float: left; margin-right: 10px; }
		        
		.style1
       {
           height: 40px;
       }
		        
		</style>
    <script type="text/C#">
        public void Page_Load(Object o, EventArgs E)
        {
            
                txtfrom.Text = "";
                txtTo.Text = "";
           
        }
   </script>
    </head>
<body>
    <form id="form1" runat="server">
       <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></ajaxtoolkit:toolkitscriptmanager>
           
    <div>    
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
                                        <uc1:discipline ID="discipline1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/50.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >View Discipline</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                         <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                       <ProgressTemplate>
                                         <div id="progressBackgroundFilter"></div>
                                         <div id="processMessage">
                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                         </div>
                                      </ProgressTemplate>
                                   </asp:UpdateProgress>
                                     <asp:UpdatePanel ID="updatepanal" runat="server" >
                                       <ContentTemplate>  
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td ><asp:Label ID="lbltitle" runat="server" Text="View Discipline" CssClass="title_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table cellpadding="7" cellspacing="0" border="0" width="100%">
                                                    
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="center" >
                                                            <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="From Date"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                           <asp:TextBox id="txtfrom"   runat="server" ></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="center" >
                                                            <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="To Date"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                            <asp:TextBox id="txtTo"   runat="server"  ></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center" style=" height: 40px; margin-left:30px;">
                                                            <asp:Button ID="bttnget" runat="server" Text="Get" Width="60px" CssClass="s_button"  onclick="bttnget_Click" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td  align="center">
                                                                <asp:Label ID="errormessage" runat="server" Visible="false" CssClass="nodatatodisplay"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:DataGrid ID="dgdiscipline" runat="server" AutoGenerateColumns="False" 
                                                                Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                                    style="margin-right: 0px">
                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                                    <ItemStyle CssClass="s_datagrid_item"/>
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="intID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strstandard" HeaderText="Standard" ></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strsection" HeaderText="Section"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="name" HeaderText="Student"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="dtdate" HeaderText="Date">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strdiscipline" HeaderText="Remarks Discipline">
                                                                        </asp:BoundColumn>
                                                                        </Columns>
                                                                    <HeaderStyle CssClass="s_datagrid_header"/>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Label ID="lblhidden" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>                                             
                                        </table>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
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
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
