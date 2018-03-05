<%@ Page Language="C#" AutoEventWireup="true" CodeFile="buildingreports.aspx.cs" Inherits="school_buildingreports" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/admin_building.ascx" tagname="admin_building" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
                                <tr id="trsidemenu" runat="server">
                                    <td style="width: 230px" align="right">
                                        <uc1:admin_building ID="admin_building1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/78.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left"> View Building &amp; Rooms</td>
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
                                                     <table cellpadding="1" cellspacing="0" border="0" class="app_container">
                                            <tr>
                                                <td colspan="4" style=" height: 20px">
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                        <tr class="view_detail_title_bg">
                                                            <td  style="height: 30px" align="left" colspan="4"><asp:Label ID="Labelname" runat="server" CssClass="title_label">Search by Building and Floor Name</asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Building Name :  "></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlbuildname" runat="server" CssClass="s_dropdown" 
                                                                    Width="173px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlbuildname_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" 
                                                                    Text="Total No. of Rooms"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="txttotroomsinbuild" runat="server" CssClass="s_label" 
                                                                    Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Floors :  "></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlfloor" runat="server" CssClass="s_dropdown" 
                                                                    Width="171px" Height="24px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlfloor_SelectedIndexChanged">                                                      
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label8" runat="server" CssClass="s_label" 
                                                                    Text="Total No. of Rooms"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="txttotroomsinfloor" runat="server" CssClass="s_label" 
                                                                    Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr class="view_detail_title_bg">
                                                            <td  style="height: 30px" align="left" colspan="4"><asp:Label ID="Label2" runat="server" CssClass="title_label">Search by Room Type</asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" 
                                                                    Text="Room Type"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlroomtype" runat="server" CssClass="s_dropdown" 
                                                                    Width="171px" Height="24px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlroomtype_SelectedIndexChanged">
                                                                    <asp:ListItem Value="Classes">Classes</asp:ListItem>
                                                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="height: 40px" align="left" colspan="2">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trclasses" runat="server" visible="false">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" 
                                                                    Text="Class &amp; Section"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlclass" runat="server" CssClass="s_dropdown" 
                                                                    Height="25px" Width="120px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlclass_SelectedIndexChanged1">
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_dropdown" 
                                                                    Height="25px" Width="48px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlsection_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="height: 40px" align="left" colspan="2"></td>
                                                        </tr>
                                                        <tr id="trothers" runat="server" visible="false">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" 
                                                                    Text="Room Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlotherroom" runat="server" CssClass="s_dropdown" 
                                                                    Width="171px" Height="24px" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlotherroom_SelectedIndexChanged">                                                      
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="height: 40px" align="left" colspan="2">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr class="view_detail_title_bg">
                                                            <td  style="height: 30px" align="left" colspan="4"><asp:Label ID="Label4" runat="server" CssClass="title_label">Search by Room Number</asp:Label></td>
                                                        </tr>
                                                         <tr>
                                                            <td><asp:Label ID="Label10" runat="server" CssClass="s_label" 
                                                                    Text="Room Number"></asp:Label></td>
                                                            <td style="height: 40px" align="left" colspan="3">
                                                                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                                                    </asp:ToolkitScriptManager>
                                                                    <asp:AutoCompleteExtender ID="txtroomno_AutoCompleteExtender"
                                                                    EnableCaching="true"
                                                                      BehaviorID="AutoCompleteEx"
                                                                      MinimumPrefixLength="1"
                                                                      TargetControlID="txtroomno"
                                                                      ServicePath="AutoComplete.asmx"
                                                                      ServiceMethod="GetCompletionList" 
                                                                      CompletionInterval="1000"  
                                                                      CompletionSetCount="20"
                                                                      CompletionListCssClass="autocomplete_completionListElement"
                                                                      CompletionListItemCssClass="autocomplete_listItem"
                                                                      CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                      DelimiterCharacters=";, :"
                                                                      ShowOnlyCurrentWordInCompletionListItem="true" 
                                                                    runat="server" >
                                                                    <Animations>
                                                                      <OnShow>
                                                                      <Sequence>
                                                                      <%-- Make the completion list transparent and then show it --%>
                                                                      <OpacityAction Opacity="0" />
                                                                      <HideAction Visible="true" />
                                                                      <%--Cache the original size of the completion list the first time
                                                                        the animation is played and then set it to zero --%>
                                                                      <ScriptAction Script="// Cache the size and setup the initial size
                                                                                                    var behavior = $find('AutoCompleteEx');
                                                                                                    if (!behavior._height) {
                                                                                                        var target = behavior.get_completionList();
                                                                                                        behavior._height = target.offsetHeight - 2;
                                                                                                        target.style.height = '0px';
                                                                                                    }" />
                                                                      <%-- Expand from 0px to the appropriate size while fading in --%>
                                                                      <Parallel Duration=".4">
                                                                      <FadeIn />
                                                                      <Length PropertyKey="height" StartValue="0" 
	                                                                    EndValueScript="$find('AutoCompleteEx')._height" />
                                                                      </Parallel>
                                                                      </Sequence>
                                                                      </OnShow>
                                                                      <OnHide>
                                                                      <%-- Collapse down to 0px and fade out --%>
                                                                      <Parallel Duration=".4">
                                                                      <FadeOut />
                                                                      <Length PropertyKey="height" StartValueScript=
	                                                                    "$find('AutoCompleteEx')._height" EndValue="0" />
                                                                      </Parallel>
                                                                      </OnHide>
                                                                      </Animations>
                                                                </asp:AutoCompleteExtender>
                                                                    <asp:TextBox ID="txtroomno" runat="server" CssClass="s_text" autocomplete ="off"
                                                                    ontextchanged="txtroomno_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="left">
                                                    <asp:DataGrid ID="dgreports" runat="server" AutoGenerateColumns="False"                                                          
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="Board ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="buildingname" HeaderText="Building Name"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strfloor" HeaderText="Floor">
                                                            </asp:BoundColumn>                                        
                                                            <asp:BoundColumn DataField="roomname" HeaderText="Room Name"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strroomno" HeaderText="Room No"></asp:BoundColumn>                                                           
                                                            <asp:BoundColumn DataField="strcapacity" HeaderText="Room Capacity">
                                                            </asp:BoundColumn>                                                           
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
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
