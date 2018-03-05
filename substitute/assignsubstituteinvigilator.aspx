<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignsubstituteinvigilator.aspx.cs" Inherits="Leave_assignsubstituteinvigilator" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/admin_leave.ascx" tagname="admin_leave" tagprefix="uc1" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/admin_sbstitute.ascx" tagname="admin_sbstitute" tagprefix="uc5" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
        
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                                        <uc5:admin_sbstitute ID="admin_sbstitute1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Assign Substitute Staff</td>
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
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" colspan="6" align="left" >
                                                    <asp:Label ID="lblstaffleavedetail" runat="server" CssClass="s_label" 
                                                        Text="Staff Leave Detail" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    <asp:Label ID="lblstaffname" runat="server" CssClass="s_label" 
                                                        Text="Staff Name:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpstaffname" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" AutoPostBack="true" 
                                                        onselectedindexchanged="drpstaffname_SelectedIndexChanged1">                                                   
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    <asp:Label ID="lblfromdatesubstitute" runat="server" CssClass="s_label" 
                                                        Text="Date:  "></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpdate" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" AutoPostBack="true" 
                                                        onselectedindexchanged="drpdate_SelectedIndexChanged">                                                   
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    <asp:Label ID="lblstandard" runat="server" CssClass="s_label" 
                                                        Text="Standard:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpstandard" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" AutoPostBack="true" 
                                                        onselectedindexchanged="drpstandard_SelectedIndexChanged">                                                   
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">
                                                        &nbsp;</td>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    <asp:Label ID="lblsection" runat="server" CssClass="s_label" 
                                                        Text="Section:"></asp:Label>
                                                        </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:DropDownList ID="drpsection" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" AutoPostBack="true" 
                                                        onselectedindexchanged="drpsection_SelectedIndexChanged">                                                   
                                                    </asp:DropDownList>
                                                        </td>
                                                <td align="left" style="width: 30px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    <asp:Label ID="lblperiod" runat="server" CssClass="s_label" 
                                                        Text="Period:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpperiod" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" AutoPostBack="true" 
                                                        onselectedindexchanged="drpperiod_SelectedIndexChanged">                                                   
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">
                                                        &nbsp;</td>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    <asp:Label ID="lblintid" runat="server" CssClass="s_label" 
                                                        Text="intid"></asp:Label>
                                                        </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 30px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" colspan="6" align="left" >
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" 
                                                        Text="Substitute Teacher" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="sub" runat="server">
                                                <td align="left" style="width: 125px; height: 40px">
                                                    <asp:Label ID="lblsubject" runat="server" CssClass="s_label" 
                                                        Text="Subject"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpsubject" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" AutoPostBack="true" 
                                                        onselectedindexchanged="drpsubject_SelectedIndexChanged">                                                   
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    <asp:Label ID="lblsubstituteteacher" runat="server" CssClass="s_label" 
                                                        Text="Sub Teacher:"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:DropDownList ID="drpsubstitute" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" >                                                   
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">           
                                                    &nbsp;</td>
                                            </tr>
                                            <tr id="trsub" runat="server">
                                                <td align="left" style="width: 125px; height: 40px">
                                                    <asp:Label ID="lblsubject0" runat="server" CssClass="s_label" 
                                                        Text="Subject"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpsubject0" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" AutoPostBack="true" 
                                                        onselectedindexchanged="drpsubject0_SelectedIndexChanged">                                                   
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    <asp:Label ID="lblsubstituteteacher0" runat="server" CssClass="s_label" 
                                                        Text="Sub Teacher:"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:DropDownList ID="drpsubstitute0" runat="server" CssClass="s_dropdown" 
                                                        Width="140px">                                                   
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">           
                                                    &nbsp;</td>
                                            </tr>
                                            <tr id="trmsg" runat="server">
                                                <td align="left" colspan="6" style="width: 710px; height: 40px">
                                                    <asp:Label ID="lblmsg" runat="server" CssClass="s_label" 
                                                        Text="Msg" ForeColor="Red"></asp:Label>
                                                    <asp:Button ID="btnok" runat="server" CssClass="s_button" Text="Yes" 
                                                        Width="60px" onclick="btnok_Click"/>
                                                    </td>
                                                
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="s_button" Text="Save" 
                                                        Width="60px" onclick="btnsave_Click"/>
                                                    <asp:Button ID="btnclear" runat="server" CssClass="s_button" Text="Clear" 
                                                        Width="60px" onclick="btnclear_Click"/>
                                                </td>
                                                <td align="left" style="width: 30px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 125px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 30px; height: 40px">           
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="left" style="width:100%; height: 40px">
                                                    <asp:DataGrid ID="grdsubtitute" runat="server" AutoGenerateColumns="False"                                                         
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="4"  
                                                        oneditcommand="grdsubtitute_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                        <ItemStyle CssClass="s_datagrid_item"/>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strstandard" HeaderText="Standard"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strsection" HeaderText="Section">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strperiod" HeaderText="Period">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strsubject" HeaderText="Subject">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="teacher" HeaderText="Teacher"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="substitute" HeaderText="Substitute">
                                                            </asp:BoundColumn> 
                                                            <asp:BoundColumn DataField="strteacher" HeaderText="Teach" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intstaffid" HeaderText="sub" Visible="false"></asp:BoundColumn> 
                                                            <asp:BoundColumn DataField="dtdate" HeaderText="Date" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="inttimetable" HeaderText="inttimetable" Visible="false"></asp:BoundColumn> 
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
        <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>