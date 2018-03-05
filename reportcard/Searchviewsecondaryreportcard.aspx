<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Searchviewsecondaryreportcard.aspx.cs" Inherits="reportcard_Searchviewsecondaryreportcard" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/exam_reportcard.ascx" tagname="exam_reportcard" tagprefix="uc1" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" /> 
    
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>    
    <style type="text/css">
        .style2
        {
            height: 30px;
        }
        .style7
        {
            width: 150px;
            height: 30px;
        }
        </style>
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc1:exam_reportcard ID="exam_reportcard1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15PX" align="right">
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/40.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Search View Secondary Student Report Card</td>
                                               
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <table cellpadding="0" cellspacing="0" border="0" width="100%" class="app_container" >
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                      <%-- <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                            <ProgressTemplate>
                                                <div id="progressBackgroundFilter"></div>
                                                    <div id="processMessage">
                                                        <img alt="Loading" src="../media/images/Processing.gif" />
                                                    </div>
                                            </ProgressTemplate>
                                         </asp:UpdateProgress>
                                      <asp:UpdatePanel ID="updatepanal" runat="server" >
                                            <ContentTemplate>--%>
                                           <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                             <tr class="view_detail_title_bg">
                                                <td colspan="6" class="title_label">&nbsp;STUDENT PROGRESS</td>
                                            </tr>
                                              <tr>
                                                <td align="left" class="style7">
                                                    &nbsp;
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                 <td align="left" class="style7">
                                                     &nbsp;
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Class Teacher"></asp:Label>
                                                        &nbsp;</td>
                                                <td align="left" class="style2" style="width:150px">
                                                     <asp:Label ID="lblteacher" runat="server" CssClass="s_label"></asp:Label>
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style7">
                                                    &nbsp;
                                                    <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Exam Type"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:DropDownList ID="ddlexamtype" runat="server" CssClass="s_dropdown" AutoPostBack="true" 
                                                        Width="150px" onselectedindexchanged="ddlexamtype_SelectedIndexChanged"></asp:DropDownList>
                                                        </td>
                                                    <td align="left" class="style7">
                                                        &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:Label ID="lblattendance" runat="server" CssClass="s_label" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 30px" align="left">
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                    &nbsp;</td>
                                                <td style="width: 150px; height: 30px" align="left">
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                    &nbsp;</td>
                                            </tr>
                                          </table>
                                          <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr id="trdatagrid" runat="server" >
                                                   <td class="title_label" align="center">
                                                        
                                                    </td>
                                                </tr>
                                             </table>
                                           <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                             <tr>
                                                <td align="center" style=" height: 40px">
                                                    <asp:DataGrid ID="dgstudent" runat="server" AutoGenerateColumns="False" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        onupdatecommand="dgstudent_UpdateCommand" 
                                                        oneditcommand="dgstudent_EditCommand" >
                                                         
                                                       
                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item"/>
                                                    <ItemStyle CssClass="s_datagrid_item"/>
                                                    <Columns>
                                                       <asp:TemplateColumn>
                                                            <HeaderTemplate><asp:CheckBox ID="chkhead" Text="All" runat="server" oncheckedchanged="chkhead_CheckedChanged" AutoPostBack="true" /></HeaderTemplate>                                                            
                                                                <ItemStyle />
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chk" runat="server"/>
                                                                </ItemTemplate>
                                                       </asp:TemplateColumn>
                                                        <%--<asp:BoundColumn DataField="intreportid" Visible="false"></asp:BoundColumn>--%>
                                                        <asp:BoundColumn DataField="intstudent" Visible="false"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="name" HeaderText="Student Name"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="stradmissionno" HeaderText="Student Number"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="inthometeacher" Visible="false"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="intexamtype" Visible="false"></asp:BoundColumn>
                                                        <asp:ButtonColumn HeaderText="View" Text="&lt;img src=&quot;../media/images/view.png&quot; alt=&quot;&quot; border=&quot;0&quot;/&gt;" CommandName="update">
                                                            <ItemStyle Width="70px" />
                                                        </asp:ButtonColumn>
                                                         <asp:ButtonColumn HeaderText="Printer" Text="&lt;img src=&quot;../media/images/Printer.png&quot; alt=&quot;&quot; border=&quot;0&quot;/&gt;" CommandName="edit">
                                                            <ItemStyle Width="70px" />
                                                        </asp:ButtonColumn>
                                                     <asp:TemplateColumn>
                                                        <HeaderTemplate><asp:Button ID="btnprintall" runat="server" CommandName="button" Text="Print All" Font-Bold="True" onclick="btnprintall_Click"/> </HeaderTemplate>
                                                     </asp:TemplateColumn>
                                                    </Columns>                                                
                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                        </table>
                                   <%-- </td>
                                </tr>
                            </table>
                           </table>     --%> 
                                            <%--</ContentTemplate>
                                       </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                                <tr><td class="break"></td></tr>
                                </table>
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
