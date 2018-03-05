<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editlessons.aspx.cs" Inherits="student_Editlessons" %>
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
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />   
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
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
            <td style="width: 100%;" align="left" valign="top">
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
                        <td style="width: 1%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Edit Lesson Details</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="center">
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
                                                         <table cellpadding="3" cellspacing="0" border="0" width="98%">
                                    <tr>
                                        <td colspan="2" style="height: 20px" align="center">
                                            <table border="0" cellpadding="5" cellspacing="0" class="thick_curve">
                                                <tr>
                                                    <td style="width: 120px; height: 40px" align="left">
                                                        <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Class"></asp:Label>
                                                    </td>
                                                    <td align="left" style="height:40px" width="120PX">
                                                        <asp:Label ID="lblstandard" runat="server" CssClass="s_label"></asp:Label><asp:Label ID="hyp" runat="server" Text="&nbsp; - &nbsp;"></asp:Label></label><asp:Label ID="lblsection" runat="server" CssClass="s_label"></asp:Label>
                                                    </td>
                                                    <td style="width: 120px; height: 40px" align="center">
                                                        <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Teacher"></asp:Label>
                                                    </td>
                                                    <td style="width: 120px; height: 40px" align="left">
                                                        <asp:Label ID="lblteacher" runat="server" CssClass="s_label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                   <td style="width: 120px; height: 40px" align="left">
                                                         <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Subject"></asp:Label>
                                                   </td>
                                                   <td align="left" style="height:40px" width="120px">
                                                        <asp:Label ID="lblsubject" runat="server" CssClass="s_label"></asp:Label>
                                                   </td>
                                                   <td style="width: 120px; height: 40px" align="center">
                                                        <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Textbook"></asp:Label></td>
                                                   <td style="width: 120px; height: 40px" align="left">
                                                        <asp:Label ID="lbltextbook" runat="server" CssClass="s_label"></asp:Label>
                                                    </td>
                                               </tr>
                                               <tr>
                                                   <td align="left" style="height:40px;width: 120px;">
                                                        <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="From Date"></asp:Label>
                                                   </td>
                                                   <td align="left" style="height:40px;width:120px;">
                                                        <asp:Label ID="lblfromdate" runat="server" CssClass="s_label"></asp:Label>
                                                   </td>
                                                   <td align="center" style="height:40px; width:120px">
                                                        <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="To Date"></asp:Label>
                                                    </td>
                                                   <td align="left" style="height:40px">
                                                        <asp:Label ID="lbltodate" runat="server" CssClass="s_label"></asp:Label>
                                                   </td>
                                               </tr>                                                                                                                                               
                                            </table>                                        
                                        </td>                                        
                                        <td valign="top" ID="tdchanges" runat="server" visible="false" >
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="curve" >
                                                <tr align="center" style="background-color:#DEE7D1">
                                                    <td>
                                                        <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Changes to be done"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td><asp:Label ID="lblchanges" runat="server" CssClass="s_label" ForeColor="#DB690D" Text=""></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 30px;width:750px" align="center" >
                                            &nbsp;</td>
                                  </tr>
                                  <tr>
                                  <td colspan="3" style="width: 100%; height: 40px" align="center">
                                            <asp:DataGrid ID="dglesson" runat="server" AutoGenerateColumns="False" 
                                                Width="98%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                onitemdatabound="dglesson_ItemDataBound">
                                            <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                            <Columns>
                                                <asp:BoundColumn DataField="intid" Visible="false"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="Date"  HeaderText="Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Unit Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlunitname" runat="server" Width="120px" CssClass="s_dropdown" onselectedindexchanged="ddlunitname_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Lesson Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddllesson" runat="server" Width="120px" CssClass="s_dropdown" ></asp:DropDownList>
                                                    </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Topic" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                            <asp:TextBox runat="server" CssClass="s_textbox" TextMode="MultiLine" ID="txttopic"></asp:TextBox>
                                                    </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Description" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                            <asp:TextBox runat="server" CssClass="s_textbox" TextMode="MultiLine" ID="txtdescription"></asp:TextBox>
                                                    </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateColumn>
                                                
                                                <asp:BoundColumn DataField="strunitname" Visible="false" HeaderText="Unit Name"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="strlessonname" Visible="false" HeaderText="Lesson Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>

                                                <asp:BoundColumn DataField="noofperiods" HeaderText="No of Periods" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                            </Columns>
                                            <HeaderStyle CssClass="s_datagrid_header"/>
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                  <tr>
                                  <td style="width: 100px; height: 40px" align="center">
                                      &nbsp;</td>
                                  <td style="height: 40px" align="center">
                                      <asp:Button ID="btnupdate" runat="server" CssClass="s_button" 
                                          Text="Send for Approval" onclick="btnupdate_Click" /> &nbsp;&nbsp;
                                          <input type ="button" value="Cancel" class="s_button" onclick="javascript:history.go(-1)" />
                                      </td>
                                  <td style="width: 100px; height: 40px" align="center">
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
          </table></td></tr></table>
            </td>
        </tr>
        <tr><td class="break"></td></tr>
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