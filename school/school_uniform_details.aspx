<%@ Page Language="C#" AutoEventWireup="true" CodeFile="school_uniform_details.aspx.cs" Inherits="school_school_uniform_details" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc4" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
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
            <td align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
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
                                        <uc4:school_profile ID="school_profile1" runat="server" />
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
                        <td style="width: 94%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >School Uniform Details</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
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
                                                         <table cellpadding="5" cellspacing="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="6">
                                                    <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="School Uniform Details" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 200px; height: 40px" valign="top">
                                                    <asp:Label ID="Label28" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 190px; height: 40px" valign="top">
                                                    <asp:Panel ID="Panel1" runat="server" BackColor="#F7F7F7" BorderColor="#1874CD" BorderWidth="1px" Height="75px" ScrollBars="Vertical" Width="180px" CssClass="s_label">
                                                    <asp:CheckBoxList ID="chkstandard" runat="server">                                                   
                                                    </asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                                <td align="left" style="width: 40px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 150px; height: 40px" valign="top">
                                                    <asp:Label ID="Label29" runat="server" CssClass="s_label" Text="Weekdays"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:270px" valign="top">
                                                    <asp:Panel ID="Panel" runat="server" BackColor="#F7F7F7" BorderColor="#1874CD" BorderWidth="1px" Height="75px" ScrollBars="Vertical" Width="180px" CssClass="s_label">
                                                    <asp:CheckBoxList ID="chkweeks" runat="server">
                                                    </asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                                <td style="width:20px"></td>
                                            </tr>
                                            <tr class="s_datagrid_header" >
                                                <td style="height: 25px" align="left" colspan="6" >
                                                    <asp:Label ID="Label21" runat="server" CssClass="title_label" Text="Boys Dress Code"></asp:Label>
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label35" runat="server" CssClass="s_label" Text="Type of dress"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 380px; height: 40px">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300" />
                                                </td>
                                                <td align="left" style="height: 40px; width:270px">
                                                     <asp:Literal ID="lit_Status" runat="server" />
                                                </td>
                                                <td style="width:20px">&nbsp;</td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="6" >
                                                    <asp:Label ID="Label2" runat="server" CssClass="subtitle_label" Text="color code"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label41" runat="server" CssClass="s_label" Text="Shirt"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 190px; height: 40px">
                                                <asp:TextBox ID="txtshirt" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 40px; height: 40px">
                                                </td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Label ID="Label85" runat="server" CssClass="s_label" Text="Trouser/Pant"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:270px">
                                                <asp:TextBox ID="txttrouser" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:20px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label42" runat="server" CssClass="s_label" Text="Shoes"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 190px; height: 40px">
                                                <asp:TextBox ID="txtBshoes" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 40px; height: 40px">
                                                </td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Label ID="Label43" runat="server" CssClass="s_label" Text="Socks"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:270px">
                                                <asp:TextBox ID="txtBsocks" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:20px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label44" runat="server" CssClass="s_label" Text="Other"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 190px; height: 40px">
                                                <asp:TextBox ID="txtBother" runat="server" CssClass="s_textbox" Width="180px" 
                                                        TextMode="MultiLine"></asp:TextBox></td>
                                                <td align="left" style="width: 40px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 150px; height: 40px">&nbsp;</td>
                                                <td align="left" style="height: 40px; width:270px">&nbsp;</td>
                                                <td style="width:20px">&nbsp;</td>
                                            </tr>
                                            <tr><td colspan="6" class="break"></td></tr>
                                            <tr class="s_datagrid_header" >
                                                <td style="height: 25px" align="left" colspan="6" >
                                                    <asp:Label ID="Label1" runat="server" CssClass="title_label" Text="Girls Dress Code"></asp:Label>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label58" runat="server" CssClass="s_label" Text="Type of dress"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 390px; height: 40px">
                                                    <asp:FileUpload ID="FileUpload2" runat="server" />
                                                </td>
                                                <td align="left" style="height: 40px; width:220px">
                                                     <asp:Literal ID="lit_Status2" runat="server" />
                                                </td>
                                                <td style="width:20px"></td>
                                            </tr>                                            
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="6" >
                                                    <asp:Label ID="Label3" runat="server" CssClass="subtitle_label" Text="color code"></asp:Label>
                                                </td>
                                            </tr>                                          
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label61" runat="server" CssClass="s_label" Text="Top"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:TextBox ID="txttop" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    &nbsp;</td>
                                                <td align="left" style="width: 40px; height: 40px">
                                                </td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Label ID="Label66" runat="server" CssClass="s_label" Text="Bottom"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:270px">
                                                     <asp:TextBox ID="txtbottom" runat="server" CssClass="s_textbox"  Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width:20px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label59" runat="server" CssClass="s_label" Text="Shoes"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="txtGshoes" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                    &nbsp;</td>
                                                <td align="left" style="width: 40px; height: 40px">
                                                </td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                    <asp:Label ID="Label62" runat="server" CssClass="s_label" Text="Socks"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px; width:270px">
                                                     <asp:TextBox ID="txtGsocks" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox></td>
                                                <td style="width:20px">
                                                </td>
                                            </tr>                            
                                            
                                            <tr>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="Label86" runat="server" CssClass="s_label" Text="Other"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                <asp:TextBox ID="txtGother" runat="server" CssClass="s_textbox" Width="180px" TextMode="MultiLine"></asp:TextBox></td>
                                                <td align="left" style="width: 40px; height: 40px">&nbsp;</td>
                                                <td align="left" style="width: 150px; height: 40px">&nbsp;</td>
                                                <td align="left" style="height: 40px; width:220px">&nbsp;</td>
                                                <td style="width:20px">&nbsp;</td>
                                            </tr>                            
                                            <tr>
                                                <td align="center" colspan="6">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" Width="60px" onclick="btnSave_Click" />
                                                    <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" Width="60px" onclick="btnClear_Click" />
                                                    <asp:Button ID="btncancel" runat="server" CssClass="s_button" Text="Cancel" 
                                                        Width="60px" onclick="btncancel_Click" />
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td align="center" colspan="6" style="width:100%; height: 40px">
                                                    <asp:DataGrid ID="dgschool" runat="server" AutoGenerateColumns="False" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                         oneditcommand="dgschool_EditCommand" >
                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                    <ItemStyle CssClass="s_datagrid_item" />
                                                    <Columns>
                                                    <asp:BoundColumn DataField="intschooluniformid" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strstandard" HeaderText="Standard" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strweekdays" HeaderText="weekdays" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strshirt" HeaderText="Shirt" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strtrouserOrpant" HeaderText="Pant" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strBshoes" HeaderText="Shoes" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="False">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strBsocks" HeaderText="Socks" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="False">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strtop" HeaderText="Top" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strbottom" HeaderText="Bottom" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strGshoe" HeaderText="Shoes" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="False">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strGsocks" HeaderText="Socks" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="False">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="other" HeaderText="Other details" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="False">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:ButtonColumn>
                                                    <asp:TemplateColumn HeaderText="Delete">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btndelete" runat="server" 
                                                                ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                            OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                                onclick="btndelete_Click"  />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:ButtonColumn>--%>
                                                    </Columns>
                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                         </table>
                                                    </ContentTemplate>
                                           </asp:UpdatePanel>
                                         <tr>
                                                <td align="center" style=" height: 40px">&nbsp;</td>
                                         </tr>
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
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

