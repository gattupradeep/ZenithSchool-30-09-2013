<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_homework.aspx.cs" Inherits="student_edit_homework" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/activities_homework.ascx" tagname="activities_homework" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" media="screen" rel="stylesheet" type="text/css" />
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
	    $(document).ready(function() {
	        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
	        function EndRequestHandler(sender, args) {
	            $('#txtdue').datepicker({ dateFormat: 'yy/mm/dd',
	                changeMonth: true,
	                constrainDates: true,
	                changeYear: true
	            });
	        }
	    });
	    $(function() {
	        var dates = $("#txtdue").datepicker({
	            constrainDates: true,
	            dateFormat: 'mm/dd/yy',
	            changeMonth: true,
	            changeYear: true
	        });
	    });
	    $(document).ready(function() {
	        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
	        function EndRequestHandler(sender, args) {
	            $('#txtpublish').datepicker({ dateFormat: 'mm/dd/yy',
	                changeMonth: true,
	                constrainDates: true,
	                changeYear: true
	            });
	        }
	    });
	    $(function() {
	        var dates = $("#txtpublish").datepicker({
	            constrainDates: true,
	            dateFormat: 'mm/dd/yy',
	            changeMonth: true,
	            changeYear: true
	        });
	    }); 
    </script>
           
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 100%" align="left">
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
                                        <uc1:activities_homework ID="activities_homework1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 20px" align="right">
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
                                     <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr class="app_container_title">
                                                <td style="width: 100%; " align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" >
                                                        <tr>
                                                            <td class="app_cont_title_img_td"><img src="../images/icons/50X50/49.png" class="app_cont_title_img" alt="icon" /></td>
                                                            <td align="left" style="width:200px" >Edit Homework</td>
                                                            <td style="width: 100px; height: 50px">
                                                                <asp:Label ID="lblteacher" runat="server" CssClass="title_label" Text="Teacher"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 50px">
                                                                <asp:DropDownList ID="ddlteacher" runat="server" CssClass="s_dropdown"  AutoPostBack="true"
                                                                    Width="150px" onselectedindexchanged="ddlteacher_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td style="width: 190px; height: 50px">
                                                               <asp:Label ID="Label3" runat="server" CssClass="title_label" Text="Select Standard&Section" ></asp:Label></td>
                                                            <td style="width: 270px; height: 50px">
                                                                <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlstandard_SelectedIndexChanged" >
                                                                     </asp:DropDownList>
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
                                <tr id="trgrid" runat="server"  visible="false">
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" class="app_container">
                                            <tr id="trsearch" runat="server" visible="true">
                                            
                                                <td align="left">
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                        <tr class="view_detail_subtitle_bg">
                                                            <td colspan="3"><asp:Label ID="lblsubtitle" runat="server" 
                                                                    CssClass="subtitle_label" Text="Refined Search"></asp:Label></td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td  align="left">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" 
                                                                    Text="Search By Assign Date"></asp:Label>
                                                            </td>
                                                            <td  align="left">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" 
                                                                    Text="Search By Publish Date"></asp:Label>
                                                            </td>
                                                            <td  align="left">
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" 
                                                                    Text="Search By Due Date"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td  align="left">
                                                                <asp:TextBox ID="txtdate" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_textbox" ontextchanged="txtdate_TextChanged" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtpublish" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_textbox" ontextchanged="txtpublish_TextChanged" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtdue" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_textbox" ontextchanged="txtdue_TextChanged" Width="150px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" 
                                                                    Text="Search By Subject"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <%--<asp:Label ID="Label2" runat="server" CssClass="s_label" 
                                                                    Text="Search By Teacher"></asp:Label>--%>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlsubject" runat="server" AutoPostBack="True" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlsubject_SelectedIndexChanged" 
                                                                    Width="200px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                <%--<asp:DropDownList ID="ddlteacher" runat="server" AutoPostBack="True" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlteacher_SelectedIndexChanged" 
                                                                    Width="200px">
                                                                </asp:DropDownList>--%>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                     </table>
                                                </td>
                                            </tr>
                                            <tr id="trdghomework" runat="server">
                                                <td align="center" style=" height: 40px">
                                                    <asp:DataGrid ID="dghomework" runat="server" AutoGenerateColumns="False" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        onupdatecommand="dghomework_UpdateCommand" 
                                                        oneditcommand="dghomework_EditCommand">
                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                    <ItemStyle CssClass="s_datagrid_item"/>
                                                    <Columns>
                                                        <asp:BoundColumn DataField="intid" Visible="false"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="inthwfrom" Visible="false"></asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderText="Home Work Details">
                                                            <ItemTemplate>                                                            
                                                                <table cellpadding="0" cellspacing="5" border="0" width="640">
                                                                    <tr>
                                                                        <td style="width: 120px; height:30px; font-weight: bold; padding-left:10px" align="left">
                                                                            Teacher</td>
                                                                        <td style="width: 200px; height:30px" align="left"><%# DataBinder.Eval(Container.DataItem, "strstaffname")%></td>
                                                                        <td style="width: 120px; height:30px; font-weight: bold" align="left">Subject</td>
                                                                        <td style="width: 200px; height:30px" align="left"><%# DataBinder.Eval(Container.DataItem, "strsubject")%></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 120px; height:30px; font-weight: bold; padding-left:10px" align="left">
                                                                            Homework Topic</td>
                                                                        <td style="width: 200px; height:30px" align="left"><%# DataBinder.Eval(Container.DataItem, "strtopic")%></td>
                                                                        <td style="width: 120px; height:30px; font-weight: bold" align="left">Description</td>
                                                                        <td style="width: 200px; height:30px" align="left"><%# DataBinder.Eval(Container.DataItem, "strdescription")%></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 120px; height:30px; font-weight: bold; padding-left:10px" align="left">
                                                                            Assigned Date</td>
                                                                        <td style="width: 200px; height:30px" align="left"><%# DataBinder.Eval(Container.DataItem, "strassigndate")%></td>
                                                                        <td style="width: 120px; height:30px; font-weight: bold" align="left">Due Date</td>
                                                                        <td style="width: 200px; height:30px" align="left"><%# DataBinder.Eval(Container.DataItem, "strduedate")%></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 120px; height:30px; font-weight: bold; padding-left:10px" align="left">
                                                                            Published Date</td>
                                                                        <td style="width: 200px; height:30px" align="left"><%# DataBinder.Eval(Container.DataItem, "strpublishdate")%></td>
                                                                        <td style="width: 120px; height:30px; font-weight: bold" align="left"></td>
                                                                        <td style="width: 200px; height:30px" align="left"></td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:ButtonColumn HeaderText="View" 
                                                            Text="&lt;img src=&quot;../media/images/view.png&quot; alt=&quot;&quot; border=&quot;0&quot;/&gt;" 
                                                                CommandName="update">
                                                            <ItemStyle Width="70px" />
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;div style=&quot;width:80px;&quot;&gt;&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;&lt;/div&gt;" ItemStyle-HorizontalAlign="Center" >
                                                            <HeaderStyle HorizontalAlign="Center" />
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
                                                        <%--<asp:TemplateColumn HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="delButton" runat="server"  ImageUrl="~/media/images/delete.gif" AlternateText="delete" CommandName="delete" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>--%>
                                                    </Columns>                                                
                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                </tr>
                                <tr id="tr1" runat="server">
                                     <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <asp:Label ID="errormessage" runat="server" CssClass="nodatatodisplay"></asp:Label>
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
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%; " align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
