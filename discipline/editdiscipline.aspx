<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editdiscipline.aspx.cs" Inherits="admin_editdiscipline" ValidateRequest="false" EnableEventValidation="false"  %>
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
	    $(function() {
	        var dates = $("#txtfrom,#txtTo").daterangepicker({
	            dateFormat: "dd/mm/yy",
	            constrainDates: true,
	            datepickerOptions: {
	                changeMonth: true,
	                changeYear: true
	            }
	        });
	    });
	    $(function() {
	        var dates = $("#labdate").datepicker({
	            constrainDates: true,
	            dateFormat: 'dd/mm/yy',
	            changeMonth: true,
	            changeYear: true
	        });
	    }); 
	</script>
	
	<style type="text/css">        
       #txtfrom,#txtTo { float: left; margin-right: 10px; }
    </style>
	
	<style type="text/css">        
        #bttnget
        {
        	display:none;
        }
        #txtfromdate,#txttodate { float: left; margin-right: 10px; }
    </style>
	
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
                                                <td align="left" > Edit | Delete Discipline</td>
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
                                         <%--<asp:UpdatePanel ID="updatepanal" runat="server" >
                                           <ContentTemplate>--%>                                       
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td ><asp:Label ID="lbltitle" runat="server" Text="Edit | Delete Discipline" CssClass="title_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="7" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 150px;" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Class"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlstandard" runat="server" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                             </td>                                                           
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px;" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Section"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlsection" runat="server" Width="150px" 
                                                                    AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlsection_SelectedIndexChanged">
                                                                </asp:DropDownList>                                                                
                                                            </td>                                                           
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px;" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Student"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlstudent" runat="server" Width="150px" AutoPostBack="true" onselectedindexchanged="ddlstudent_SelectedIndexChanged1">  
                                                                  </asp:DropDownList>
                                                            </td>                                                            
                                                        </tr>                                                        
                                                        <tr>
                                                            <td style="width: 150px;" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="lblfrom" runat="server" CssClass="s_label" Text="From Date" ></asp:Label>
                                                            </td>
                                                            <td>
                                                                <%--<asp:Label ID="labdate" runat="server" CssClass="s_label"></asp:Label>
                                                                 <%--<ajaxtoolkit:CalendarExtender ID="Calendarextender1" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="labdate" TargetControlID="labdate"></ajaxtoolkit:CalendarExtender >--%>
                                                                 <asp:TextBox ID="labdate" runat="server" CssClass="s_textbox" Width="150px" Visible="false" ></asp:TextBox>
                                                                     <asp:TextBox id="txtfrom" runat="server" ></asp:TextBox>
                                                            </td>                                                           
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px;" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="lblto" runat="server" CssClass="s_label" Text="To Date" ></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox id="txtTo"   runat="server" ></asp:TextBox>
                                                            </td>                                                           
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px;" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label"  Visible="false"
                                                                    Text="Remarks Discipline"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtdiscipline" runat="server" CssClass="s_textbox" Visible="false"
                                                                    Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>                                                            
                                                        </tr>
                                                        <tr>
                                                             <td colspan="2" align="center" style=" height: 40px; margin-left:30px;">
                                                                <asp:Button ID="bttnget" runat="server" Text="Get" Width="60px" 
                                                                     CssClass="s_button" onclick="bttnget_Click" OnClientClick="javascript:showWait();" />
                                                                 <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear"  
                                                                    Width="60px" onclick="btnClear_Click" OnClientClick="javascript:showWait();" />
                                                                       <asp:Button ID="editclear" runat="server"  CssClass="s_button" Text="Clear" 
                                                                    Width="60px" onclick="editclear_Click" OnClientClick="javascript:showWait();" />
                                                                    <%--<asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                                    Width="60px" onclick="btnSave_Click" OnClientClick="javascript:showWait();" />--%>
                                                                     </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:Label ID="errormessage" runat="server" Visible="false" CssClass="nodatatodisplay"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="left">
                                                                <asp:DataGrid ID="dgdiscipline" runat="server" AutoGenerateColumns="False" 
                                                                Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                                    style="margin-right: 0px" 
                                                                    oneditcommand="editcommand_dgdiscipline">
                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                                    <ItemStyle CssClass="s_datagrid_item"/>
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="intID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strstandard" HeaderText="Standard" ItemStyle-CssClass="item" >
                                                                            <ItemStyle CssClass="item" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strsection" HeaderText="Section"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="name" HeaderText="Student"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="dtdate" HeaderText="Date">
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strdiscipline" HeaderText="Remarks    Discipline">
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
                                                    </table>
                                                </td>
                                            </tr>
                                        </table> 
                                        <%--</ContentTemplate>
                                        </asp:UpdatePanel> --%>                                          
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