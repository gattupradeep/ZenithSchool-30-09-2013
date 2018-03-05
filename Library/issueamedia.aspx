<%@ Page Language="C#" AutoEventWireup="true" CodeFile="issueamedia.aspx.cs" Inherits="Library_issueamedia" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/admin_library.ascx" tagname="admin_library" tagprefix="uc1" %>
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
                $('#Txtdateofissue').datepicker({ dateFormat: 'yy/mm/dd' });
            }
        });
        $(function() {
        var dates = $("#Txtdateofissue").datepicker({
                constrainDates: true,
                dateFormat: 'yy/mm/dd',                
                    changeMonth: true,
                    changeYear: true
            });
        });
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
         </ajaxtoolkit:toolkitscriptmanager>
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
                                        <uc1:admin_library ID="admin_library1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/262.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Issue Media</td>
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
                                                <td colspan="4" class="title_label">&nbsp;Issue Media</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="pat1" runat="server" CssClass="s_label" Text="Patron Type"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlpatron" runat="server" Width="150px" 
                                                                    CssClass="s_dropdown" AutoPostBack="True" onselectedindexchanged="ddlpatron_SelectedIndexChanged" 
                                                                     >
                                                                     <asp:ListItem Value= "Employee" Text="Employee"></asp:ListItem>
                                                                     
                                                                     <asp:ListItem Value="Student" Text="Student"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                 </td>
                                                            <td align="right"></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="reg" runat="server" CssClass="s_label" Text="Registration Code"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;<asp:TextBox ID="Txtregcode" runat="server" Width="180px" 
                                                                    CssClass="s_textbox" ></asp:TextBox></td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Button ID="btnsearch" runat="server" Text="Search" Width="58px" 
                                                                    CssClass="s_button" onclick="btnsearch_Click" />
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trname" runat="server">
                                                            <td align="left">
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Name"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="labname" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trstd" runat="server">
                                                            <td align="left">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="labstd" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trsec" runat="server">
                                                            <td align="left">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Section"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="labsec" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trdept" runat="server">
                                                            <td align="left">
                                                                <asp:Label ID="labdept" runat="server" Text="Department" 
                                                                    CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddldept" runat="server" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trdesig" runat="server">
                                                            <td align="left">
                                                                <asp:Label ID="labdesig" runat="server" Text="Designation" 
                                                                    CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddldesig" runat="server" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label6" runat="server" Text="Barcode" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                              
                                                                <asp:TextBox ID="Txtbarcode" runat="server" Width="180px" CssClass="s_textbox" 
                                                                    ></asp:TextBox>
                                                                 
                                                            </td>
                                                            <td align="left">
                                                                <asp:Button ID="btn1Search" runat="server" Text="Search" Width="70px" 
                                                                    CssClass="s_button" onclick="btn1search_Click" />
                                                            </td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label7" runat="server" Text="Media Type" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlmt" runat="server" Width="150px" 
                                                                    CssClass="s_dropdown"  onselectedindexchanged="ddlmt_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left"></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" Text="Media Category" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlmc" runat="server" Width="150px" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlmc_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right"></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="barcde" runat="server" CssClass="s_label" Text="Book Title"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlbt" runat="server" Width="150px" 
                                                                    CssClass="s_dropdown">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right" ></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="barcde0" runat="server" CssClass="s_label" Text="Date Of Issue"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="Txtdateofissue" runat="server" Width="180px" 
                                                                    CssClass="s_textbox"></asp:TextBox>
                                                            </td>
                                                            <td align="left"></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td  style="height: 40px" align="right">
                                                                &nbsp;</td>
                                                            <td align="left">
                                                                <asp:Button ID="Btnsave" runat="server" CssClass="s_button" 
                                                                    Text="Save" onclick="Btnsave_Click" />
                                                                     &nbsp;
                                                                <asp:Button ID="btnclear" runat="server"  Text="Clear" CssClass="s_button" 
                                                                    onclick="btnclear_Click" />
                                                                <asp:HiddenField ID="hdnid" runat="server" />
                                                            </td>
                                                            <td style="width: 150px; height: 30px" align="left">&nbsp;</td>
                                                            <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  style="height: 40px" colspan="4">
                                                    &nbsp;
                                                     <asp:DataGrid ID ="dgissuemedia" runat="server" CellPadding="4" GridLines="None" Width="100%"
                                                        AutoGenerateColumns="False" 
                                                        oneditcommand="dgissuemedia_EditCommand" >                                                        
                                                         <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                         <ItemStyle CssClass="s_datagrid_item" />
                                                         <Columns>
                                                             <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False">
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strname" HeaderText="Name"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strdepartmentname" HeaderText="Department"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="desig" HeaderText="Designation">
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strstandard" HeaderText="Standard">
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strsection" HeaderText="Section"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strtitle" HeaderText="Book Title"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="issuedate" HeaderText="Date of Issue">
                                                             </asp:BoundColumn>
                                                             <asp:ButtonColumn CommandName="edit" HeaderText="Edit" 
                                                                 Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
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
                                                             </asp:ButtonColumn>--%>
                                                         </Columns>
                                                         <HeaderStyle CssClass="s_datagrid_header" />
                                                     </asp:DataGrid>
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
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>
