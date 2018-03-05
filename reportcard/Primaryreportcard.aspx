<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Primaryreportcard.aspx.cs" Inherits="reportcard_Primaryreportcard" %>
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
                                                <td align="left" > Student Primary Report Card</td>
                                               
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                             
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                     <%-- <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                            <ProgressTemplate>
                                                <div id="progressBackgroundFilter"></div>
                                                    <div id="processMessage">
                                                        <img alt="Loading" src="../media/images/Processing.gif" />
                                                    </div>
                                            </ProgressTemplate>
                                         </asp:UpdateProgress>--%>
                                      <asp:UpdatePanel ID="updatepanal" runat="server" >
                                            <ContentTemplate>
                                          <table cellpadding="0" cellspacing="0" border="0" width="100%" class="app_container" >
                                          <tr>
                                          <td>   
                                           <table id="student" runat="server" cellpadding="0" cellspacing="0" border="0" width="100%">
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
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Student Name"></asp:Label>
                                                        &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:DropDownList ID="ddlstudent" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlstudent_SelectedIndexChanged"></asp:DropDownList>
                                                        </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style7">
                                                    &nbsp;
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Class Teacher"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:DropDownList ID="ddlteacher" runat="server" CssClass="s_dropdown" Width="150px">
                                                        </asp:DropDownList>
                                                        </td>
                                                    <td align="left" class="style7">
                                                        &nbsp;
                                                       <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Exam Type"></asp:Label>
                                                   
                                                        &nbsp;</td>
                                                <td align="left" class="style2">
                                                   <asp:DropDownList ID="ddlexamtype" runat="server" CssClass="s_dropdown" AutoPostBack="true" 
                                                        Width="150px" onselectedindexchanged="ddlexamtype_SelectedIndexChanged"></asp:DropDownList>
                                                    
                                               </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 30px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Student No"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:Label ID="lbladmission" runat="server" CssClass="s_label"></asp:Label>
                                               </td>
                                                <td style="width: 150px; height: 30px" align="left">
                                                    &nbsp;
                                                     <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Attendance"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:Label ID="lblattendance" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                          </table>
                                           <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr id="trdatagrid" runat="server" class="view_detail_title_bg" >
                                                   <td class="title_label" align="center">
                                                        <asp:Label CssClass="title_label" ID="Label8" runat="server" Text="INDICATORS OF ACHIEVEMENT" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="tr1" runat="server">
                                                    <td style="height: 40px; width:100%" align="center">
                                                        <asp:DataGrid ID="datagrid" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0px" GridLines="None" Width="100%" onitemdatabound="datagrid_ItemDataBound">
                                                            <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="intindicatorid" Visible="false"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="strindicatorsubject" HeaderText="Leaner & Social Development">
                                                                    <ItemStyle Width="200px" />
                                                                    </asp:BoundColumn>
                                                                        <asp:TemplateColumn HeaderText="Indicator" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemStyle Width="365px" HorizontalAlign="Left" />
                                                                                <ItemTemplate>
                                                                                     <asp:RadioButtonList runat="server" ID="RBindicatorleaner" Visible="true" RepeatDirection="Horizontal">
                                                                                         <asp:ListItem >
                                                                                         </asp:ListItem>
                                                                                     </asp:RadioButtonList>
                                                                                </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                 </Columns>
                                                              <HeaderStyle CssClass="s_datagrid_header"/>
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                             </table>
                                             <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr id="trdggrid" runat="server" class="view_detail_title_bg" >
                                                         <td class="title_label" align="center">
                                                             <asp:Label CssClass="title_label" ID="Label31" runat="server" Text="YOUR CHILD’S LEARNING DURING THE TERM" ></asp:Label>
                                                        </td>
                                                    </tr>
                                                   <tr id="tr2" runat="server">
                                                    <td style="height: 40px; width:100%" align="center">
                                                        <asp:DataGrid ID="dgreport" runat="server" AutoGenerateColumns="False" 
                                                            BorderStyle="None" BorderWidth="0px" GridLines="None" Width="100%" 
                                                            onitemdatabound="dgreport_ItemDataBound">
                                                            <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                                <Columns>
                                                                   <asp:TemplateColumn HeaderText="Subject" HeaderStyle-HorizontalAlign="Left">
                                                                       <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                        <ItemStyle Width="565px" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                    <tr class="view_detail_subtitle_bg">
                                                                                        <td style="width: 565px; height: 35px; padding-left: 15px" align="left">
                                                                                            <asp:Label ID="lblsubject" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 565px; height: 35px; padding-left: 15px" align="left">
                                                                                            <asp:DataGrid ID="dgexampaper" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0px" GridLines="None" Width="100%" onitemdatabound="dgexampaper_ItemDataBound">
                                                                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                                                    <Columns>
                                                                                                        <asp:BoundColumn DataField="strexampaper" HeaderText="Exam Paper">
                                                                                                        <ItemStyle Width="200px" />
                                                                                                        </asp:BoundColumn>
                                                                                                            <asp:TemplateColumn HeaderText="Indicator" HeaderStyle-HorizontalAlign="Left">
                                                                                                                <ItemStyle Width="700px" HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                         <asp:RadioButtonList runat="server" ID="RBindicatorsubject" Visible="true" RepeatDirection="Horizontal">
                                                                                                                             <asp:ListItem >
                                                                                                                             </asp:ListItem>
                                                                                                                         </asp:RadioButtonList>
                                                                                                                    </ItemTemplate>
                                                                                                            </asp:TemplateColumn>
                                                                                                     </Columns>
                                                                                                  <HeaderStyle CssClass="s_datagrid_header"/>
                                                                                            </asp:DataGrid>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                 </Columns>
                                                            <HeaderStyle CssClass="s_datagrid_header"/>
                                                        </asp:DataGrid>
                                                    </td>
                                                 </tr>
                                                 <tr id="trdone" runat="server">
                                                   <td style="height: 40px; width: 800px" align="center">
                                                  <asp:Button ID="btndone" runat="server" CssClass="s_button" Text="Done" onclick="btndone_Click"/>
                                                   </td>
                                              </tr>
                                          </table>
                                        </td>
                                       </tr>
                                      </table>     
                                   
                                    </ContentTemplate>
                                   </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr><td class="break"></td></tr>
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
