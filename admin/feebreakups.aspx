<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feebreakups.aspx.cs" Inherits="feemanagement_feebreakups" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../usercontrol/feemanagement.ascx" tagname="feemanagement" tagprefix="uc5" %>
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
    </script>
</head>
<body>
    <form id="form1" runat="server">    
    <div id="mothersMedicals" class="dialog">
        <div style="text-align:center"><span onclick="closeModal();" style="float:right;clear:both;"></span></div>
        <iframe id="trendsFrame" src="" style="width:960px;height:300px;border:none;" scrolling='no' marginwidth='0' marginheight='0' frameborder='0' vspace='0' hspace='0' >some problem</iframe>
    </div>    
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
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
                                        <uc5:feemanagement ID="feemanagement1" runat="server" />
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
                                                <td align="left"> Fee Breakups</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                       <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="5" align="left" class="title_label">Set Fee Breakups</td>
                                            </tr>
                                              <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="lblfeemode" runat="server" CssClass="s_label" Text="Fee Mode"></asp:Label>
                                                </td>
                                                <td style="width: 185px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlfeemode" runat="server" Width="170px" Height="19px" AutoPostBack="true" 
                                                        onselectedindexchanged="ddlfeemode_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width:150px">
                                                    <asp:Label ID="lblsmode" runat="server" CssClass="s_label" Visible="false"></asp:Label>
                                                  </td>
                                                <td align="left"></td>
                                                <td align="left"></td>
                                            </tr>
                                              <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="lblfeetitle" runat="server" CssClass="s_label" Text="Fee Title"></asp:Label>
                                                </td>
                                                <td style="width: 185px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlfeetitle" runat="server" Width="170px" Height="19px" 
                                                        onselectedindexchanged="ddlfeetitle_SelectedIndexChanged" 
                                                        AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width:150px">
                                                    <asp:Label ID="lblstype" runat="server" CssClass="s_label" Visible="false"></asp:Label>
                                                  </td>
                                                <td align="left">&nbsp;</td>
                                                <td align="left"></td>
                                             </tr>
                                             <tr>
                                                <td style="width: 185px; height: 40px" align="left">
                                                    <asp:Label ID="lblstd" runat="server" CssClass="s_label" Text="Class"></asp:Label>
                                                  </td>
                                                <td style="width: 185px; height: 40px" align="left">
                                                <asp:TextBox ID="txtstd" runat="server" CssClass="s_textbox" Width="170px" AutoPostBack="true" 
                                                        ontextchanged="txtstd_TextChanged"></asp:TextBox>
                                                    <asp:PopupControlExtender ID="txtstd_PopupControlExtender" runat="server" 
                                                        TargetControlID="txtstd" Enabled="true" PopupControlID="panalstd" OffsetY="22">
                                                    </asp:PopupControlExtender>
                                                    <asp:Panel ID="panalstd" runat="server" ScrollBars="Vertical" Height="150px" BackColor="white" BorderColor="#1874CD" BorderWidth="1px" Width="170px">
                                                        <table border="0" cellpadding="0" cellspacing="0" >
                                                            <tr>
                                                                <td style="width: 120px" align="left" valign="top">
                                                                    <table>
                                                                        <tr>
                                                                            <td style="width: 120px" align="left">
                                                                                <asp:CheckBox ID="chkall" runat="server" Text="Select All" 
                                                                                CssClass="s_dropdown" style="float:left;margin-left:3px;"  oncheckedchanged="chkall_CheckedChanged" AutoPostBack="true"/>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 120px"  align="left">
                                                                                <asp:CheckBoxList ID="ddlstandard" runat="server"></asp:CheckBoxList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td  style="width: 50px" align="left" valign="top">
                                                                    <asp:Button ID="btnapply" runat="server" CssClass="s_button"  
                                                                                onclick="btnapply_Click" Text="Apply"/>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                   </asp:Panel>
                                                    &nbsp;</td>
                                                <td style="width: 185px; height: 40px" align="left">
                                                    <asp:Label ID="lblsclass" runat="server" CssClass="s_label" Visible="false"></asp:Label>
                                                 </td>
                                                <td align="left">
                                                    <asp:Label ID="lblgrdfeemode" runat="server" CssClass="s_label" Visible="false"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblgrdfeetype" runat="server" CssClass="s_label" Visible="false"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblgrdstd" runat="server" CssClass="s_label" Visible="false"></asp:Label>
                                                        </td>
                                                <td align="left">&nbsp;</td>
                                            </tr>
                                            <tr id="trbreakups" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="lblbreak" runat="server" CssClass="s_label" Text="Fee Breakups"></asp:Label>
                                                </td>
                                                <td style="width: 185px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlfeebreakups" runat="server" Width="170px" Height="19px" 
                                                        AutoPostBack="true" 
                                                        onselectedindexchanged="ddlfeebreakups_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">New</asp:ListItem>
                                                        <asp:ListItem Value="2">Already assigned</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td colspan="3" align="left">
                                                    <asp:Label ID="lbleditid" runat="server" CssClass="s_label" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trgrd" runat="server">
                                            <td colspan="5">
                                                <asp:DataGrid ID="grid" AutoGenerateColumns="False"
                                                    runat="server" Width="100%" CellSpacing="1" CellPadding="4" 
                                                    onitemdatabound="grid_ItemDataBound">
                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                    <ItemStyle CssClass="s_datagrid_item" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="intfeetype" HeaderText="ID" Visible="False">
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="strfeebreakups" HeaderText="Fee Type" Visible="False">
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="intamount" HeaderText="Amount" Visible="False">
                                                        </asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderText="FeeType" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtfeetype" runat="server"></asp:TextBox>
                                                            </ItemTemplate>

                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Amount" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtamount" runat="server"></asp:TextBox>
                                                            </ItemTemplate>

                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Add" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imageadd" runat="server" ImageUrl="~/media/images/add.gif" 
                                                                    onclick="imageadd_Click" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imagedelete" runat="server" ImageUrl="~/media/images/delete.gif" onclick="imagedelete_Click" OnClientClick="return confirm('Aru you sure you want to delete?')" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Update" HeaderStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imageupdate" runat="server" 
                                                                    ImageUrl="~/media/images/update.gif" onclick="imageupdate_Click" />
                                                            </ItemTemplate>

                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                              </asp:DataGrid>
                                            </td>
                                          </tr>
                                           <tr id="trgrdview" runat="server">
                                                <td colspan="5" align="left">
                                                    <asp:DataGrid ID="dgsetfee" runat="server" AutoGenerateColumns="False"
                                                    Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        CellPadding="4" CellSpacing="1" 
                                                        onpageindexchanged="dgsetfee_PageIndexChanged" 
                                                        ondeletecommand="dgsetfee_DeleteCommand" oneditcommand="dgsetfee_EditCommand">                                                            
                                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="strstandard" HeaderText="Class" >                                                                                                                                                                                
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strfeemode" HeaderText="Fee Mode">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strfeetype" HeaderText="Fee Title">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intamount" HeaderText="Fee Amount" >                                                                                                                                                                                
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intfeemode" HeaderText="Fee Mode" Visible="false">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intfeetype" HeaderText="Fee Title" Visible="false">
                                                            </asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Inactivate" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="checkdeactivate" runat="server" AutoPostBack="true" 
                                                                        oncheckedchanged="checkdeactivate_CheckedChanged" />
                                                                </ItemTemplate>

                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateColumn>
                                                            <asp:ButtonColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CommandName="edit" 
                                                                HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">                                                                                            
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:ButtonColumn>
                                                            <asp:ButtonColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" CommandName="delete" HeaderText="Delete"
                                                                Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;" >                                                                                                                
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:ButtonColumn>
                                                            <asp:TemplateColumn HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <a href="javascript: void(0)" onclick="showModal('viewbreakupspopup.aspx?class=<%# DataBinder.Eval(Container.DataItem, "strstandard")%>&feetype=<%# DataBinder.Eval(Container.DataItem, "intfeetype")%>&feemode=<%# DataBinder.Eval(Container.DataItem, "intfeemode")%>','420','300')">
                                                                    <input type="button" style="background-image:url( ../media/images/View.gif); Border:none; width:31px; height:31px"  id="imageviewpop" onclick="return imageviewpop_onclick()" /></a>
                                                                </ItemTemplate>

                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateColumn>
                                                            
                                                           <asp:TemplateColumn HeaderText="Select" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imageselect" runat="server" 
                                                                        ImageUrl="~/media/images/update.gif" onclick="imageselect_Click" />
                                                                </ItemTemplate>

                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="View" HeaderStyle-HorizontalAlign="Center" >
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imageview" runat="server" 
                                                                        ImageUrl="~/media/images/view.gif" onclick="imageview_Click" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateColumn>
                                                            </Columns>
                                                        <PagerStyle Mode="NumericPages" Font-Bold="true"  Font-Underline="true" NextPageText="Next" PrevPageText="Prev" />
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                        </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr id="trbutton" runat="server">
                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                            <td style="width: 185px; height: 40px" align="left">
                                                <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Done" 
                                                    Width="60px" onclick="btnSave_Click"/>
                                                &nbsp;
                                                <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" 
                                                    Width="60px" onclick="btnClear_Click"/>
                                                </td>
                                            <td align="left" style="width:150px">
                                                    <asp:Label ID="lblstdsec" runat="server" CssClass="s_label" 
                                                    Visible="false"></asp:Label>
                                                        </td>
                                            <td align="left">&nbsp;</td>
                                            <td align="left"></td>
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
                </table>
            </td> 
        </tr>           
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
