<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_examschedule.aspx.cs" Inherits="exam_edit_examschedule" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/admin_exam.ascx" tagname="admin_exam" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
	<link rel="stylesheet" type="text/css" href="../Media_front/Css/abtModal.css" />
	<script type="text/javascript" src="../Media_front/Js/abtModal.js"></script>
	<script type="text/javascript">
	    function showModal(url, w, h) {
	        showabtModal('mothersMedicals', w, h);
	        document.getElementById('trendsFrame').style.height = h + 'px';
	        document.getElementById('trendsFrame').style.width = w + 'px';
	        document.getElementById('trendsFrame').src = url;
	    }
	    function closeModal() {
	        document.getElementById('trendsFrame').src = "";
	        hideabtModal('mothersMedicals');
//	        window.parent.location = "edit_examschedule.aspx";
	    }
    </script>
    
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
    
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div id="mothersMedicals" class="dialog">
        <div style="text-align:center"><span onclick="closeModal();" style="float:right;clear:both;" class="closeModal"></span></div>
        <iframe id="trendsFrame" src="" style="width:960px;height:300px;border:none;" scrolling='no' marginwidth='0' marginheight='0' frameborder='0' vspace='0' hspace='0' >some problem</iframe>
    </div>
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
                                        <uc1:admin_exam ID="admin_exam1" runat="server" />
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
                      <%-- <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="UpdatePanel" DisplayAfter="1" >
                           <ProgressTemplate>
                             <div id="progressBackgroundFilter"></div>
                             <div id="processMessage">
                                <img alt="Loading" src="../media/images/Processing.gif" />
                             </div>
                          </ProgressTemplate>
                          </asp:UpdateProgress>                                          
                            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                            <ContentTemplate>     --%> 
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/36.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left"> Edit | Del Exam Schedule</td>
                                                <td style="width: 85px" align="center">
                                                    <asp:Label ID="Label6" runat="server" CssClass="title_label" Text="Class"></asp:Label>
                                                </td>
                                                <td style="width: 110px" align="left">
                                                    <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                        Width="105px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlstandard_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px" align="center">
                                                    <asp:Label ID="Label7" runat="server" CssClass="title_label" Text="Exam type"></asp:Label>
                                                </td>
                                                <td style="width: 110px" align="center">
                                                    <asp:DropDownList ID="ddlexamtype" runat="server" CssClass="s_dropdown" 
                                                        Width="105px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlexamtype_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr id="trerror" runat="server">
                                    <td style="width: 100%; height: 10px" align="center">
                                        <asp:Label ID="lblmsg" runat="server" CssClass="nodatatodisplay"></asp:Label>
                                    </td>
                                </tr>
                               <tr id="trsearch" runat="server" visible="false">
                                    <td style="width:98%; height: 20px;padding-left:20px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" class="thick_curve" width="98%" >
                                            <tr class="view_detail_subtitle_bg">
                                                <td colspan="6" style=" height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label1" runat="server" CssClass="subtitle_label" Text="Refined Search"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Subject"></asp:Label>
                                                </td>
                                                <td style="width: 100px; height: 30px" align="left">
                                                    <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_dropdown" 
                                                        Width="100px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlsubject_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                </td>
                                                <td style="width: 100px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Month"></asp:Label>
                                                </td>
                                                <td style="width: 100px; height: 30px" align="left">
                                                    <asp:DropDownList ID="ddlmonth" runat="server" CssClass="s_dropdown" 
                                                        Width="100px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlmonth_SelectedIndexChanged" >
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 100px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                </td>
                                                <td style="width: 100px; height: 30px" align="left">
                                                    <asp:DropDownList ID="ddldate" runat="server" CssClass="s_dropdown" 
                                                        Width="100px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddldate_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr id="tr1tag" runat="server">
                                    <td style=" padding-left:20px; height:20px;" align="left">
                                        <table cellpadding="0" cellspacing="0" class="app_container_auto">
                                            <tr id="trexamtype" runat="server" class="view_detail_title_bg" >
                                                <td style="width:400px; height: 30px; padding-left: 10px">
                                                    <asp:Label ID="lblexamtype" runat="server" CssClass="title_label" 
                                                        Font-Size="12px"></asp:Label>
                                                </td>
                                            </tr>
                                           <tr id="trexamgrid" runat="server">
                                                <td style="width: 98%; height:20px;" align="left">
                                                    <asp:DataGrid ID="dgexam" runat="server" AutoGenerateColumns="False" 
                                                    Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        onupdatecommand="dgexam_UpdateCommand"  oneditcommand="dgexam_EditCommand">
                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                    <ItemStyle CssClass="s_datagrid_item"/>
                                                    <Columns>
                                                    <asp:BoundColumn DataField="intid" Visible="false"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="date" HeaderText="Date">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strclass" HeaderText="Class">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strsubjectname" HeaderText="Subject">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="staffname" HeaderText="Invigilator">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strexampaper" HeaderText="Paper"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="time" HeaderText="Time">
                                                    </asp:BoundColumn>
                                                    <%--<asp:BoundColumn DataField="intmaxmark" HeaderText="Max Marks">
                                                    </asp:BoundColumn>--%>
                                                    
                                                 <asp:TemplateColumn HeaderText="View Portion">
                                                    <ItemTemplate>
                                                        <a href="javascript: void(0)" onclick="showModal('viewpopup.aspx?hid=<%# DataBinder.Eval(Container.DataItem, "intid")%>','755','500')"><img src="../Media/images/view.png" alt="view" style="border:none" /></a> 
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Delete">
                                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btndelete" runat="server" 
                                                                ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                            OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                            onclick="btndelete_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                   <%-- <asp:ButtonColumn CommandName="delete" HeaderText="Delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;View&quot; border=&quot;0&quot; /&gt;" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Center" >                                                            
                                                    </asp:ButtonColumn>--%>
                                                    <asp:ButtonColumn CommandName="update" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;View&quot; border=&quot;0&quot; /&gt;" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Center" >                                                            
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:ButtonColumn>
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
                </table>
                         <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
            </td>
        </tr>
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
