<%@ Page Language="C#" AutoEventWireup="true" CodeFile="setlesson.aspx.cs" Inherits="school_setlesson" %>
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
                $('#txtfrom').datepicker({ dateFormat: 'mm/dd/yy',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtTo').datepicker({ dateFormat: 'mm/dd/yy',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(function() {
            var dates = $("#txtfrom").datepicker({
                constrainDates: true,
                dateFormat: 'mm/dd/yy',
                changeMonth: true,
                changeYear: true
            });
        });       
           
        $(function() {
            var dates = $("#txtTo").datepicker({
                constrainDates: true,
                dateFormat: 'mm/dd/yy',
                changeMonth: true,
                changeYear: true
            });
        });          
           
	</script>
	<script type="text/javascript">
	    function show() {
	        if (confirm('Text Book Not Assigned this Subject, Do you want assign Now?')) {
	            window.location.replace('../syllabus/addtextbooks.aspx');
	        }
	    }
    </script>
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
                                    <td style="width: 230px" align="right">
                                        <uc1:activities_lessonplan ID="activities_lessonplan1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:1%" valign="top">
                        </td>
                        <td style="width: 93%;" valign="top" align="left" >
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/52.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Assign New Lesson Plan</td>
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
                                                      <table cellpadding="0" cellspacing="0" border="0" width="98%">
                                            <tr>
                                                <td colspan="3" valign="top" align="center">
                                                    <table cellpadding="5" cellspacing="0" border="0" class="thick_curve">
                                                        <tr id="lessontag" runat="server">
                                                            <td align="left">
                                                                &nbsp;</td>
                                                            <td align="left"  colspan="2">
                                                                &nbsp;</td>
                                                            <td align="left">
                                                                
                                                            </td>
                                                       </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Teacher"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlteacher" runat="server" CssClass="s_dropdown" 
                                                                    Width="145px"></asp:DropDownList>
                                                            </td>
                                                           <td align="left" style="height:40px;width: 150px;">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="From Date"></asp:Label>
                                                                <span class="smalllabel">(MM/DD/YYYY)</span>
                                                           </td>
                                                           <td align="left" style="height:40px" width="150PX">
                                                                <asp:TextBox ID="txtfrom" runat="server" CssClass="s_textbox" AutoComplete="off"></asp:TextBox>   
                                                           </td>
                                                           <td align="center" style="height:40px; width:150px">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="To Date"></asp:Label>
                                                                <span class="smalllabel">(MM/DD/YYYY)</span>
                                                            </td>
                                                           <td align="left" style="height:40px">
                                                                <asp:TextBox ID="txtTo" runat="server" CssClass="s_textbox" AutoComplete="off"></asp:TextBox> 
                                                                
                                                           </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><asp:Label ID="Label14" runat="server" Text="Label" Visible="false"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 40px" align="center" colspan="3" width="98%">
                                                        <asp:Button ID="Btnadd" runat="server" CssClass="s_button"
                                                            Text="Set Lesson plan for the above selected date" OnClick="Btnadd_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="break"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="width: 98%; height: 40px" align="right">
                                                    <asp:DataGrid ID="dglesson" runat="server" AutoGenerateColumns="False" CssClass="app_container" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        onitemdatabound="dglesson_ItemDataBound">
                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                    <Columns>
                                                    <asp:BoundColumn DataField="intid" Visible="false"></asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderText="Dates" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddldate" runat="server" Width="100px" CssClass="s_dropdown" OnSelectedIndexChanged="ddldate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                <asp:Label ID="lbldate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dtdate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Standard & Period" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlclassperiod" runat="server" Width="130px" CssClass="s_dropdown" OnSelectedIndexChanged="ddlclassperiod_SelectedIndexchanged" AutoPostBack="true"></asp:DropDownList>
                                                                <asp:Label ID="lblclasspreiod" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strclassperiod")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Subject" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_dropdown" Width="100px" OnSelectedIndexChanged="ddlsubject_SelectedIndexchanged" AutoPostBack="true" ></asp:DropDownList>
                                                                <asp:Label ID="lblsubject" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Text Book" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddltextbook" runat="server" CssClass="s_dropdown" Width="100px" OnSelectedIndexChanged="ddltextbook_SelectedIndexchanged" AutoPostBack="true" ></asp:DropDownList>
                                                                <asp:Label ID="lbltextbook" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strtextbookname")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Unit Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlunitname" runat="server" Width="90px" CssClass="s_dropdown" OnSelectedIndexChanged="ddlunit_SelectedIndexchanged" AutoPostBack="true"></asp:DropDownList>
                                                                <asp:Label ID="lblunitname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strunitname")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Lesson Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddllesson" runat="server" Width="90px" 
                                                                    CssClass="s_dropdown"></asp:DropDownList>
                                                                <asp:Label ID="lbllesson" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strlessonname")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Topic" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                    <asp:TextBox runat="server" CssClass="s_textbox" TextMode="MultiLine" height="50px" ID="txttopic"></asp:TextBox>
                                                                    <asp:Label ID="lbltopic" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strtopic")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Description" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                    <asp:TextBox runat="server" CssClass="s_textbox" TextMode="MultiLine" height="50px" ID="txtdescription"></asp:TextBox>
                                                                    <asp:Label ID="lbldescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strdescription")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Add">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnaddlesson" runat="server" 
                                                                    ImageUrl="../media/images/add.gif" onclick="btnaddlesson_Click" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btndeletelesson" runat="server" 
                                                                    ImageUrl="../media/images/delete.gif" OnClientClick="return confirm('Are you sure you want to delete this record?');" OnClick="btndeletelesson_Click" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                    <HeaderStyle CssClass="s_datagrid_header"/>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px" align="center">
                                                    &nbsp;</td>
                                                <td style="height: 40px" align="center">
                                                  <asp:Button ID="btndone" runat="server" CssClass="s_button" Visible="false"
                                                      Text="Done" />
                                                  </td>
                                                <td style="width: 200px; height: 40px" align="center">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="height: 40px" align="center" colspan="3">&nbsp;</td>
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
