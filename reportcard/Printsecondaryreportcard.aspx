<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Printsecondaryreportcard.aspx.cs" Inherits="reportcard_Printsecondaryreportcard" %>

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
                          <table cellpadding="0" cellspacing="0" border="0" width="100%" >
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/40.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > &nbsp;Secondary Student Report Card</td>
                                               
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
                                                    <asp:Label ID="lblstandard" runat="server" CssClass="s_label" ></asp:Label>
                                                </td>
                                                 <td align="left" class="style7">
                                                     &nbsp;
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Student Name"></asp:Label>
                                                     &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:Label ID="lblstudent" runat="server" CssClass="s_label" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style7">
                                                    &nbsp;
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Class Teacher"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                   <asp:Label ID="lblteacher" runat="server" CssClass="s_label" ></asp:Label>
                                                 </td>
                                                    <td align="left" class="style7">
                                                        &nbsp;
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Attendance"></asp:Label>
                                                        &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:Label ID="lblattendance" runat="server" CssClass="s_label" ></asp:Label>
                                               </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 30px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Student No"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:Label ID="lbladmission" runat="server" CssClass="s_label" ></asp:Label>
                                               </td>
                                                <td style="width: 150px; height: 30px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Exam Type"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left" class="style2">
                                                    <asp:Label ID="lblexam" runat="server" CssClass="s_label" ></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                
                                                <td align="left" class="style2">
                                                    <asp:Label ID="lblstudentname" runat="server" CssClass="s_label" Visible="false" ></asp:Label>
                                               </td>
                                            </tr>
                                            <tr class="view_detail_title_bg">
                                                <td colspan="6" class="title_label" align="center">&nbsp;PURPOSE OF REPORTING STUDENT 
                                                    PROGRESS</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="This report card is designed to provide you with an accurate interpretation of your child’s achievement on graded curriculum over a period of time. It emphasizes “how” students learn and where they are on the learning continuum, rather than “what” students learn."></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                    <td colspan="6">
                                                        <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="It also reflects the consistency of the skills outcomes across all grade levels Kindergarten through Grade 9. It will assist you and your child in understanding areas of strength, areas for growth and strategies for improvement. The report card is one means of reporting achievement and it should be considered within a comprehensive approach to reporting learning (e.g. student led conferences, celebrations of learning, digital portfolios, emails, blogs, etc.). If you require more information, or have any questions about the information contained in this report please contact the school at your earliest convenience. Meaningful communication is important in order to support student learning."></asp:Label>
                                                    </td>
                                            </tr>
                                           </table>
                                          <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr id="trdatagrid" runat="server" class="view_detail_title_bg" >
                                                   <td class="title_label" align="center" colspan="2">
                                                        <asp:Label CssClass="title_label" ID="Label11" runat="server" Text="INDICATORS OF ACHIEVEMENT" ></asp:Label>
                                                    </td>
                                               </tr>
                                               <tr id="tr5" runat="server" >
                                                   <td style="width: 750px; height:30px" align="left" colspan="4">
                                                        <asp:Label CssClass="s_label" ID="Label26" runat="server" Text="The level at which your child is demonstrating learning in relation to the expectation for this time in the school year is reported by the following indicators: " ></asp:Label>
                                                    </td>
                                               </tr>
                                                <tr class="view_detail_subtitle_bg">
                                                    <td style="width: 30px; height:30px" align="left">
                                                        <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Indicator"></asp:Label>
                                                    </td>
                                                    <td style="width: 150px; height:20px" align="left">
                                                        &nbsp;
                                                        <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Description"></asp:Label>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                     <td style="width: 30px; height:20px" align="left">
                                                         &nbsp;
                                                        <asp:Label ID="Label42" runat="server" CssClass="s_label" Text="A"></asp:Label>
                                                         &nbsp;</td>
                                                    <td style="width: 350px; height:20px" align="left">
                                                        <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Well above the standard expected at this time of year"></asp:Label>
                                                    </td>
                                                 </tr>
                                                 <tr>   
                                                      <td style="width: 30px; height:20px" align="left">
                                                          &nbsp;
                                                        <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="B"></asp:Label>
                                                          &nbsp;</td>
                                                    <td style="width: 350px; height:20px" align="left">
                                                        <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Above the standard expected at this time of year"></asp:Label>
                                                    </td>
                                                  </tr>
                                                  <tr>  
                                                     <td style="width: 30px; height:20px" align="left">
                                                         &nbsp;
                                                        <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="C"></asp:Label>
                                                         &nbsp;</td>
                                                    <td style="width: 350px; height:20px" align="left">
                                                        <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="At the standard expected at this time of year"></asp:Label>
                                                    </td>
                                                  </tr>
                                                  <tr>  
                                                     <td style="width: 30px; height:20px" align="left">
                                                         &nbsp;
                                                        <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="D"></asp:Label>
                                                         &nbsp;</td>
                                                    <td style="width: 350px; height:20px" align="left">
                                                        <asp:Label ID="Label19" runat="server" CssClass="s_label" Text="Below the standard expected at this time of year"></asp:Label>
                                                    </td>
                                                  </tr>
                                                  <tr>  
                                                     <td style="width: 30px; height:20px" align="left">
                                                         &nbsp;
                                                        <asp:Label ID="Label20" runat="server" CssClass="s_label" Text="E"></asp:Label>
                                                         &nbsp;</td>
                                                    <td style="width: 350px; height:20px" align="left">
                                                        <asp:Label ID="Label21" runat="server" CssClass="s_label" Text="Well below the standard expected at this time of year"></asp:Label>
                                                    </td>
                                                </tr>
                                             </table>
                                           
                                              <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                               <tr id="tr1" runat="server" class="view_detail_title_bg" >
                                                   <td class="title_label" align="center" colspan="2">
                                                        <asp:Label CssClass="title_label" ID="Label22" runat="server" Text="CITIZENSHIP AND SOCIAL RESPONSIBILITY" ></asp:Label>
                                                    </td>
                                               </tr>
                                               <tr id="tr4" runat="server" >
                                                   <td style="width: 650px; height:30px" align="left" colspan="4">
                                                        <asp:Label CssClass="s_label" ID="Label25" runat="server" Text="The indicators reflect personal and social development, as well as work habits and study skills." ></asp:Label>
                                                    </td>
                                               </tr>
                                                 <tr id="tr2" runat="server">
                                                    <td style="height: 40px; width:100%" align="center">
                                                        <asp:DataGrid ID="datagrid" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0px" GridLines="None" Width="100%" onitemdatabound="datagrid_ItemDataBound">
                                                            <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                                <Columns>
                                                                       <asp:TemplateColumn HeaderText="Skills,Attitudes And Behaviours" HeaderStyle-HorizontalAlign="Left">
                                                                       <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                        <ItemStyle Width="565px" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                    <tr class="view_detail_subtitle_bg">
                                                                                        <td style="width: 565px; height: 35px; padding-left: 15px" align="left" class="s_label">
                                                                                            <asp:Label ID="lblindicatorsubject" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsecondindicatorsubject")%>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                     <tr>
                                                                                        <td style="width: 565px; height: 35px; padding-left: 15px" align="left">
                                                                                            <asp:DataGrid ID="dgdatagrid" runat="server" AutoGenerateColumns="False" 
                                                                                                BorderStyle="None" BorderWidth="0px" GridLines="None" Width="100%" 
                                                                                                onitemdatabound="dgdatagrid_ItemDataBound">
                                                                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                                                    <Columns>
                                                                                                        <asp:BoundColumn DataField="strexampaper" HeaderText="Exam Paper" HeaderStyle-CssClass="s_label">
                                                                                                        <ItemStyle Width="200px" />
                                                                                                        </asp:BoundColumn>
                                                                                                         <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="A">
                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                          <asp:ImageButton ID="btnRespect" runat="server" ImageUrl="~/media/images/UpdateRad.gif" />
                                                                                                                    </ItemTemplate>
                                                                                                            </asp:TemplateColumn>
                                                                                                             <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="B">
                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                          <asp:ImageButton ID="btnIntegrity" runat="server" ImageUrl="~/media/images/UpdateRad.gif" />
                                                                                                                    </ItemTemplate>
                                                                                                            </asp:TemplateColumn>
                                                                                                             <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="C">
                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                          <asp:ImageButton ID="btnEmpathy" runat="server" ImageUrl="~/media/images/UpdateRad.gif" />
                                                                                                                    </ItemTemplate>
                                                                                                            </asp:TemplateColumn>
                                                                                                            <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="D">
                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                          <asp:ImageButton ID="btnCooperation" runat="server" ImageUrl="~/media/images/UpdateRad.gif" />
                                                                                                                    </ItemTemplate>
                                                                                                            </asp:TemplateColumn>
                                                                                                             <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="E">
                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                          <asp:ImageButton ID="btnSelf" runat="server" ImageUrl="~/media/images/UpdateRad.gif" />
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
                                                 <tr>
                                                   <td colspan="6" align="left">
                                                        <asp:Label ID="Label29" runat="server" CssClass="s_label" Text="Teacher’s Comments : " Width="250px"></asp:Label>
                                                   </td>
                                                </tr>
                                                 <tr>
                                                    <td colspan="6" style="height:50px">
                                                    </td>                                                                      
                                               </tr>                                                                        
                                             </table>
                                             <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr class="view_detail_title_bg">
                                                    <td colspan="6" class="title_label" align="center">&nbsp;SUMMARY OF ACADEMIC PERFORMANCE</td>
                                                </tr>
                                                    <tr id="tr3" runat="server">
                                                    <td style="height: 40px; width:100%" align="center">
                                                        <asp:DataGrid ID="dgreport" runat="server" AutoGenerateColumns="False" 
                                                            BorderStyle="None" BorderWidth="0px" GridLines="None" Width="100%" 
                                                            onitemdatabound="dgreport_ItemDataBound"> 
                                                            <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                                <Columns>
                                                                   <asp:TemplateColumn HeaderText="Subject" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="s_label">
                                                                       <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                        <ItemStyle Width="565px" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                    <tr class="view_detail_subtitle_bg">
                                                                                        <td style="width: 565px; height: 35px; padding-left: 15px" align="left" class="s_label">
                                                                                            <asp:Label ID="lblsubject" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>'></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label30" runat="server" CssClass="s_label" Text="GRADE AWARDED : " Width="250px"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="__________________ " Width="250px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 100%; height: 35px; padding-left: 15px" align="left">
                                                                                            <asp:DataGrid ID="dgexampaper" runat="server" AutoGenerateColumns="False" 
                                                                                                BorderStyle="None" BorderWidth="0px" GridLines="None" Width="170%" 
                                                                                                onitemdatabound="dgexampaper_ItemDataBound">
                                                                                                <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                                                    <Columns>
                                                                                                        <asp:BoundColumn DataField="strexampaper" HeaderText="Exam Paper">
                                                                                                        </asp:BoundColumn>
                                                                                                            <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="A">
                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                          <asp:ImageButton ID="btnSignificant" runat="server" ImageUrl="~/media/images/UpdateRad.gif" />
                                                                                                                    </ItemTemplate>
                                                                                                            </asp:TemplateColumn>
                                                                                                            <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="B">
                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                          <asp:ImageButton ID="btnSome" runat="server" ImageUrl="~/media/images/UpdateRad.gif" />
                                                                                                                    </ItemTemplate>
                                                                                                            </asp:TemplateColumn>
                                                                                                            <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="C">
                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                          <asp:ImageButton ID="btnManaging" runat="server" ImageUrl="~/media/images/UpdateRad.gif" />
                                                                                                                    </ItemTemplate>
                                                                                                            </asp:TemplateColumn>
                                                                                                            <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="D">
                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                          <asp:ImageButton ID="btnCapable" runat="server" ImageUrl="~/media/images/UpdateRad.gif" />
                                                                                                                    </ItemTemplate>
                                                                                                            </asp:TemplateColumn>
                                                                                                            <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="E">
                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                                    <ItemTemplate>
                                                                                                                          <asp:ImageButton ID="btnHighly" runat="server" ImageUrl="~/media/images/UpdateRad.gif" />
                                                                                                                    </ItemTemplate>
                                                                                                            </asp:TemplateColumn>
                                                                                                            
                                                                                                     </Columns>
                                                                                                  <HeaderStyle CssClass="s_datagrid_header"/>
                                                                                            </asp:DataGrid>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left">
                                                                                            <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Teacher’s Comments : " Width="250px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" style="height:50px">
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
                                             </table>
                                             <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label23" runat="server" CssClass="s_label" Text="Class Teacher’s Comments :"></asp:Label>
                                                    </td>
                                                 </tr>
                                                 <tr>
                                                    <td style="height:50px" colspan="6"></td>
                                                 </tr>
                                                <tr>
                                                    <td style="height:50px">
                                                        <asp:Label ID="Label24" runat="server" CssClass="s_label" Text="Signature :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label27" runat="server" CssClass="s_label" Text="_________________________"></asp:Label>
                                                    </td>
                                                     <td>
                                                        <asp:Label ID="Label28" runat="server" CssClass="s_label" Text="Date : "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label31" runat="server" CssClass="s_label" Text="_________________________"></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        <asp:Label ID="Label32" runat="server" CssClass="s_label" Text="Parent’s Comments :"></asp:Label>
                                                    </td>
                                                   
                                                </tr>
                                                 <tr>
                                                    <td style="height:50px" colspan="6"></td>
                                                 </tr>
                                                <tr>
                                                    <td style="height:50px">
                                                        <asp:Label ID="Label34" runat="server" CssClass="s_label" Text="Signature :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label35" runat="server" CssClass="s_label" Text="_________________________"></asp:Label>
                                                    </td>
                                                     <td>
                                                        <asp:Label ID="Label36" runat="server" CssClass="s_label" Text="Date : "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label37" runat="server" CssClass="s_label" Text="_________________________"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height:50px">
                                                        <asp:Label ID="Label38" runat="server" CssClass="s_label" Text="Principal’s Signature : "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label39" runat="server" CssClass="s_label" Text="_________________________"></asp:Label>
                                                    </td>
                                                     <td>
                                                        <asp:Label ID="Label40" runat="server" CssClass="s_label" Text="Date : "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label41" runat="server" CssClass="s_label" Text="_________________________"></asp:Label>
                                                    </td>
                                                </tr>
                                             </table>
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
