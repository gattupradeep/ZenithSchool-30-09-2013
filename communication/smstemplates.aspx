<%@ Page Language="C#" AutoEventWireup="true" CodeFile="smstemplates.aspx.cs" Inherits="communication_smstemplates" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/communication_admin.ascx" tagname="communication_admin" tagprefix="uc5" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="admin_footer" TagPrefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
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
                                                <td align="left" >SMS Templates</td>
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
                                                <td colspan="2"><asp:Label ID="lbltitle" runat="server" Text="SMS Templates" CssClass="title_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left">
                                                             <asp:Label ID="Label77" runat="server" CssClass="s_label" 
                                                                    Text="Category"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlsmscategory" runat="server" CssClass="s_textbox" AutoPostBack="true"
                                                                    Width="150px" onselectedindexchanged="ddlsmscategory_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>                                                
                                                        </tr>
                                                        <tr id="trpatrontype" runat="server" visible="false">
                                                            <td align="left" >
                                                                <asp:Label ID="lblpatrontype" runat="server" Text="Patron Type" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlpatron" runat="server" Width="150px" 
                                                                    CssClass="s_label s_textbox" AutoPostBack="true" 
                                                                    onselectedindexchanged="ddlpatron_SelectedIndexChanged">
                                                                    <asp:ListItem Value="">-Select-</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>                                                
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                             <asp:Label ID="Label76" runat="server" CssClass="s_label" 
                                                                    Text="Template Name"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:TextBox ID="txttemplatename" runat="server" CssClass="s_textbox" 
                                                                    Width="150px"></asp:TextBox>
                                                            </td>                                                
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                             <asp:Label ID="Label75" runat="server" CssClass="s_label" Text="Message"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                            <asp:TextBox ID="txtmessage" runat="server" CssClass="s_textbox" 
                                                                    Width="400px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>                                                
                                                        </tr>
                                                        <tr id="trkeywords" runat="server" visible="false">
                                                            <td align="left" style="width: 150px;" valign="top">
                                                             <asp:Label ID="Label78" runat="server" CssClass="s_label" Text="Keywords"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lblkeywords" runat="server" CssClass="sms_keyword_label" Width="450px" Height="100%" 
                                                                    Text=""></asp:Label>
                                                            </td>                                                
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center" >
                                                                <asp:Button ID="btnsave" runat="server" CssClass="s_button" Text="Save" 
                                                                    Width="60px" onclick="btnSave_Click" />
                                                                <asp:Button ID="btnclear" runat="server" CssClass="s_button" Text="Clear" 
                                                                    Width="60px" onclick="btnClear_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr >
                                                <td colspan="2" align="left" >
                                                    <asp:DataGrid ID="dgtemplate" runat="server" AutoGenerateColumns="false" CellPadding="5" 
                                                        Width="100%" GridLines="None" ondeletecommand="dgtemplate_DeleteCommand" 
                                                        oneditcommand="dgtemplate_EditCommand">
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <Columns>
                                                            <asp:BoundColumn HeaderText="ID" DataField="intid" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Template Name" DataField="strtemplatename"><ItemStyle Width="150px" /></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Message" DataField="strmessage"></asp:BoundColumn>
                                                            <asp:ButtonColumn HeaderText="Edit" CommandName="edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;"><ItemStyle Width="50px" /></asp:ButtonColumn>
                                                            <asp:ButtonColumn CommandName="delete" HeaderText="Delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>
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
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="break"></td>
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
