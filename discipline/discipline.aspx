<%@ Page Language="C#" AutoEventWireup="true" CodeFile="discipline.aspx.cs" Inherits="admin_discipline"  ValidateRequest="false" EnableEventValidation="false" %>
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
                $('#txtdate').datepicker({ dateFormat: 'yy/mm/dd',
                changeMonth: true,
                maxDate: new Date,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(function() {
            var dates = $("#txtdate").datepicker({
            constrainDates: true,
            maxDate: new Date,
            dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true
            });
        }); 
    </script> 
    <script type="text/javascript">
        function checkDate(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You cannot select a day greater than today!");
                sender._selectedDate = new Date();
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }
        // Added By Prabaa on 03-10-13
        function Validation() {
            if (document.getElementById('ddlstandard').value == "-Select-") {
                alert("Please select standard to proceed");
                document.getElementById('ddlstandard').focus();
                return false;
            }
            if (document.getElementById('ddlsection').value == "-Select-") {
                alert("Please select section to proceed");
                document.getElementById('ddlsection').focus();
                return false;
            }
            if (document.getElementById('ddlTeacher').value == "-Select-") {
                alert("Please select teacher to proceed");
                document.getElementById('ddlTeacher').focus();
                return false;
            }
            if (document.getElementById('ddlstudent').value == "-Select-") {
                alert("Please select student to proceed");
                document.getElementById('ddlstudent').focus();
                return false;
            }
            if (document.getElementById('txtdate').value == "") {
                alert("Please enter the date to proceed");
                document.getElementById('txtdate').focus();
                return false;
            }
            if (document.getElementById('txtdiscipline').value == "") {
                alert("Please enter the discipline to proceed");
                document.getElementById('txtdiscipline').focus();
                return false;
            }
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
                <uc3:topbanner ID="topbanner" runat="server" />                
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" valign="top">
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
                                        <uc1:discipline ID="discipline" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info" runat="server" />
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
                                                <td align="left" >Enter Discipline</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                         <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                           <ProgressTemplate>
                                             <div id="progressBackgroundFilter"></div>
                                             <div id="processMessage">
                                                <img alt="Loading" src="../media/images/Processing.gif" />
                                             </div>
                                          </ProgressTemplate>
                                       </asp:UpdateProgress>--%>
                                         <asp:UpdatePanel ID="updatepanal" runat="server" >
                                           <ContentTemplate>                                           
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td><asp:Label ID="lbltitle" runat="server" Text="Add Discipline Details" CssClass="title_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="7" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td style="width:150px">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Class"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlstandard" runat="server" AutoPostBack="true" 
                                                                    onselectedindexchanged="ddlstandard_SelectedIndexChanged" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Section"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlsection" runat="server" Width="150px" onselectedindexchanged="ddlsection_SelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                               
                                                            </td>                                               
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Teacher"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlTeacher" runat="server" AutoPostBack="true" 
                                                                    Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Student"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlstudent" runat="server" Width="150px" AutoPostBack="True" >
                                                                </asp:DropDownList>
                                                           </td>                                               
                                                        </tr>
                                                         <tr>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                 <asp:TextBox ID="txtdate" CssClass="s_textbox" runat="server" Width="150px" ></asp:TextBox>
                                                           </td>                                                
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Remarks Discipline"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                 <asp:TextBox ID="txtdiscipline" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>                                               
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">                                                    
                                                                <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                                Width="60px" onclick="btnSave_Click" OnClientClick ="return Validation();"/>
                                                                <asp:Button ID="btnclear" runat="server" CssClass="s_button" Text="Clear" 
                                                                    Width="60px" onclick="btnclear_Click" />
                                                            </td>                                                
                                                        </tr>
                                                        <tr>
                                                            <td  align="center">
                                                                <asp:Label ID="errormessage" runat="server" Visible="false" CssClass="nodatatodisplay"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        </table>
                                                       </td>
                                                    </tr>
                                                 
                                                  <tr id="trdiscipline" runat="server">
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
                                                </ContentTemplate>
                                         </asp:UpdatePanel>
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
