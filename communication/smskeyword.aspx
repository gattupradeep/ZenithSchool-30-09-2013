<%@ Page Language="C#" AutoEventWireup="true" CodeFile="smskeyword.aspx.cs" Inherits="communication_smskeyword" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/admin_attendance.ascx" tagname="admin_attendance" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/communication_admin.ascx" tagname="communication_admin" tagprefix="uc5" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="admin_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Communication</title>
     <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />    
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
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
                                        <uc5:communication_admin ID="communication_admin1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../media/images/smsicon.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > SMS Keyword</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
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
                                                 <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="2"><asp:Label ID="lbltitle" runat="server" CssClass="title_label" Text="SMS Keyword"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 150px; height: 40px">
                                                 <asp:Label ID="Label77" runat="server" CssClass="s_label" 
                                                        Text="Category"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 560px; height: 40px">
                                                    <asp:DropDownList ID="ddlsmscategory" runat="server" CssClass="s_textbox" AutoPostBack="true"
                                                        Width="150px" onselectedindexchanged="ddlsmscategory_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>                                                
                                            </tr>
                                            <tr id="trpatrontype" runat="server" visible="false">
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Label ID="lblpatrontype" runat="server" Text="Patron Type" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 560px; height: 40px">
                                                    <asp:DropDownList ID="ddlpatron" runat="server" Width="150px" 
                                                        CssClass="s_label s_textbox" AutoPostBack="true" 
                                                        onselectedindexchanged="ddlpatron_SelectedIndexChanged">
                                                        <asp:ListItem Value="">-Select-</asp:ListItem>
                                                        <asp:ListItem Value="Student">Student</asp:ListItem>
                                                        <asp:ListItem Value="Staff">Staff</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>                                                
                                            </tr>
                                            <tr id="trleavestatus" runat="server" visible="false">
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Label ID="lblleavestatus" runat="server" Text="Leave Status" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 560px; height: 40px">
                                                    <asp:DropDownList ID="ddlleavestatus" runat="server" CssClass="s_label" AutoPostBack="true" 
                                                        Width="150px" onselectedindexchanged="ddlleavestatus_SelectedIndexChanged">
                                                        <asp:ListItem Value="">-Select-</asp:ListItem>
                                                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                                        <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>                                                
                                            </tr>
                                            <tr id="trfoodmenutype" runat="server" visible="false">
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Label ID="lblmenutype" runat="server" Text="Menu Type" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 560px; height: 40px">
                                                    <asp:DropDownList ID="ddlmenutype" runat="server" CssClass="s_label" AutoPostBack="true" 
                                                        Width="150px" onselectedindexchanged="ddlmenutype_SelectedIndexChanged">
                                                        <asp:ListItem Value="">-Select-</asp:ListItem>
                                                        <asp:ListItem Value="Breakfast">Breakfast</asp:ListItem>
                                                        <asp:ListItem Value="Lunch">Lunch</asp:ListItem>
                                                        <asp:ListItem Value="Dinner">Dinner</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>                                                
                                            </tr>
                                            <tr id="trtcstatus" runat="server" visible="false">
                                                <td align="left" style="width: 150px; height: 40px">    
                                                    <asp:Label ID="lbltcstatus" runat="server" CssClass="s_label" Text="TC Status"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 560px; height: 40px">
                                                    <asp:DropDownList ID="ddltcstatus" runat="server" CssClass="s_label" Width="150px">
                                                        <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                                                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                                        <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Label ID="lbltablename" runat="server" Text="Table Name" CssClass="s_label"></asp:Label>
                                                 </td>
                                                <td align="left" style="width: 560px; height: 40px">
                                                    <asp:TextBox ID="txttablename" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Label ID="lblcoulmnname" runat="server" Text="Column Name" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 560px; height: 40px">
                                                    <asp:TextBox ID="txtcolumnname" runat="server" CssClass="s_textbox" Width="150px"></asp:TextBox>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 150px; height: 40px">
                                                 <asp:Label ID="Label76" runat="server" CssClass="s_label" 
                                                        Text="Keyword Description"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 560px; height: 40px">
                                                    <asp:TextBox ID="txtkeyworddesc" runat="server" CssClass="s_textbox" 
                                                        Width="150px"></asp:TextBox>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 150px; height: 40px">
                                                 <asp:Label ID="Label75" runat="server" CssClass="s_label" Text="Keyword"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 560px; height: 40px">
                                                <asp:TextBox ID="txtkeyword" runat="server" CssClass="s_textbox" Width="150px" ></asp:TextBox>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" style="width: 710px; height: 40px">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="s_button" Text="Save" 
                                                        Width="60px" onclick="btnSave_Click" />
                                                    <asp:Button ID="btnclear" runat="server" CssClass="s_button" Text="Clear" 
                                                        Width="60px" onclick="btnClear_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="left" style="width: 710px">
                                                    <asp:DataGrid ID="dgsmskeywords" runat="server" GridLines="None" AutoGenerateColumns="false" Width="100%">
                                                        <ItemStyle CssClass="s_datagrid_item"/>        
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <Columns>
                                                            <asp:BoundColumn HeaderText="SMS Category Name" DataField="categoryname"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="type" DataField="strpatrontype"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Description" DataField="strdescription"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Keyword" DataField="strkeyword"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Column Name" DataField="strcolumnname"></asp:BoundColumn>
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
            <td style="width: 100%;" align="left" valign="top">
                <uc6:admin_footer ID="admin_footer" runat="server" />
            </td>
        </tr>
    </table>
     <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

