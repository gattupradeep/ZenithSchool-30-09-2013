<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studenttutorial.aspx.cs" Inherits="Tutorials_studenttutorial" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/tutorial.ascx" tagname="tutorial" tagprefix="uc5" %>
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
                $('#txtpublishdate').datepicker({ dateFormat: 'yy/mm/dd',
                    constrainDates: true,
                    changeMonth: true,
                    changeYear: true
                });
            }
        });
        $(function() {
            var dates = $("#txtpublishdate").datepicker({
                constrainDates: true,
                dateFormat: 'mm/dd/yy',
                changeMonth: true,
                changeYear: true
            });
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtdate').datepicker({ dateFormat: 'yy/mm/dd',
                    constrainDates: true,
                    changeMonth: true,
                    changeYear: true
                });
            }
        });
        $(function() {
            var dates = $("#txtdate").datepicker({
                constrainDates: true,
                dateFormat: 'mm/dd/yy',
                changeMonth: true,
                changeYear: true
            });
        });       
	</script>
	<link rel="stylesheet" type="text/css" href="../Media_front/Css/abtModal.css" />
	<script type="text/javascript" src="../Media_front/Js/abtModal.js"></script>	
	<script type="text/javascript">
	    function showModal(url, w, h) {
	        showabtModal('viewtutorial', w, h);
	        document.getElementById('trendsFrame').style.height = h + 'px';
	        document.getElementById('trendsFrame').style.width = w + 'px';
	        document.getElementById('trendsFrame').src = url;
	    }
	    function closeModal() {
	        document.getElementById('trendsFrame').src = "";
	        hideabtModal('viewtutorial');
	        //	        window.parent.location = "tutorial.aspx";
	    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="viewtutorial" class="dialog">
        <div style="text-align:center"><span onclick="closeModal();" style="float:right;clear:both;" class="closeModal"></span></div>
        <iframe id="trendsFrame" src="" style="width:750px;height:550px;border:none;" scrolling='yes' marginwidth='0' marginheight='0' frameborder='0'>some problem</iframe>
    </div>
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
                                    <td style="width: 230px" align="right">
                                        <uc5:tutorial ID="tutorial1" runat="server" />
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
                                    <td style="width: 100%;" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                              <tr class="app_container_title">
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/51.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Student View Daily Class Notes</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                       <%-- <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
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
                                                <td colspan="4" class="title_label">&nbsp;&nbsp;Student View Daily Class Notes</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" >
                                                    <table cellpadding="7" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td style="width: 250px; height: 40px" align="left">
                                                              
                                                               <asp:Label ID="Label9" runat="server" CssClass="s_label" 
                                                                    Text="Class &amp; Section"></asp:Label>
                                                              
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                               <asp:Label ID="lblstandard" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                 <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                                &nbsp;</td>
                                                           <td style="width: 200px; height: 40px" align="left">
                                                                 <asp:TextBox ID="txtdate" runat="server" CssClass="s_textbox" 
                                                                    Width="100px" ontextchanged="txtdate_TextChanged"></asp:TextBox>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 250px; height: 40px" align="left">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Teacher"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlteacher" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlteacher_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 250px; height: 40px" align="left">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Subject"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlsubject" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlsubject_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Text Book"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddltextbook" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddltextbook_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Unit"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlunit" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlunit_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                               <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Lesson"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                             
                                                                <asp:DropDownList ID="ddllesson" runat="server" CssClass="s_dropdown">
                                                                </asp:DropDownList>
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr class="view_detail_subtitle_bg">
                                                            <td colspan="4" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" >
                                                                <asp:DataGrid ID="dgtutorial" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                                    Width="100%">
                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                    <ItemStyle CssClass="s_datagrid_item" />
                                                                    <Columns>
                                                                        <asp:BoundColumn HeaderText="ID" DataField="intid" Visible="false"></asp:BoundColumn>
                                                                        <asp:BoundColumn HeaderText="Date" DataField="date"></asp:BoundColumn>
                                                                        <asp:BoundColumn HeaderText="Class" DataField="strclass"></asp:BoundColumn>
                                                                        <asp:BoundColumn HeaderText="Teacher" DataField="teachername"></asp:BoundColumn>
                                                                        <asp:BoundColumn HeaderText="Subject" DataField="strsubject"></asp:BoundColumn>
                                                                        <asp:BoundColumn HeaderText="Textbook" DataField="strtextbookname"></asp:BoundColumn>
                                                                        <asp:BoundColumn HeaderText="Unit" DataField="strunit"></asp:BoundColumn>
                                                                        <asp:BoundColumn HeaderText="Lesson" DataField="strlesson"></asp:BoundColumn>
                                                                        <asp:TemplateColumn>
                                                                            <ItemTemplate>
                                                                                <a href="javascript: void(0)" onclick="showModal('Pop_view_tutorial.aspx?tutorial=<%# DataBinder.Eval(Container.DataItem, "intid")%>','755','500')"><img src="../Media/images/view.png" alt="view" style="border:none" /><%--<input type="button" class="s_grdbutton" value="View" id="reject" />--%></a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr1" runat="server">
                                                             <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="center" colspan="4">
                                                                <asp:Label ID="errormessage" runat="server" CssClass="nodatatodisplay" Text="No search criteria found for selected"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 40px" align="left">
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
            <td style="width: 100%;" align="left" valign="top" >
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>