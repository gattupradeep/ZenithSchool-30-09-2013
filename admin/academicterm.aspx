<%@ Page Language="C#" AutoEventWireup="true" CodeFile="academicterm.aspx.cs" Inherits="admin_academicterm" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {

            $("ul#topnav li").hover(function() { //Hover over event on list item
                $(this).css({ 'background': '#88BB00 url(topnav_active.gif) repeat-x' }); //Add background color + image on hovered list item
                $(this).find("span").show(); //Show the subnav
            }, function() { //on hover out...
                $(this).css({ 'background': 'none' }); //Ditch the background
                $(this).find("span").hide(); //Hide the subnav
            });

        });
    </script>
    <style type="text/css">
        .style1
        {
            width: 150px;
            height: 40px;
        }
        .style2
        {
            width: 200px;
            height: 40px;
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
                                        <uc1:mainmasters ID="mainmasters1" runat="server" />
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
                                                <td align="left">Academic Term</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                      <%--  <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                <ProgressTemplate>
                                                    <div id="progressBackgroundFilter"></div>
                                                        <div id="processMessage">
                                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                                        </div>
                                                </ProgressTemplate>
                                          </asp:UpdateProgress>--%>
                                           <asp:UpdatePanel ID="updatepanal" runat="server" >
                                                <ContentTemplate>
                                                      <table cellpadding="0" cellspacing="0"  class="app_container" width="700">
                                            <tr>
                                                <td colspan="4" class="title_label">&nbsp;Academic Term</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Year"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlyear" runat="server" CssClass="s_dropdown" 
                                                        AutoPostBack="True"> 
                                                                                                       
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Term"></asp:Label>
                                                </td>
                                                 <td align="left" style="width: 150px; height: 40px">
                                                    <asp:DropDownList ID="ddlterm" runat="server" CssClass="s_dropdown"> 
                                                        
                                                    <asp:ListItem Value="Select">Select</asp:ListItem>
                                                    <asp:ListItem Value="Term1">Term1</asp:ListItem>
                                                    <asp:ListItem Value="Break1">Break1</asp:ListItem>
                                                    <asp:ListItem Value="Term2">Term2</asp:ListItem>
                                                    <asp:ListItem Value="Break2">Break2</asp:ListItem>
                                                    <asp:ListItem Value="Term3">Term3</asp:ListItem>
                                                    <asp:ListItem Value="Break3">Break3</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Start Date"></asp:Label>
                                                </td>
                                                <td align="left" class="style2">
                                                     <asp:DropDownList ID="ddlday1" runat="server" CssClass="s_dropdown">
                                                         <asp:ListItem Value="01">01</asp:ListItem>
                                                         <asp:ListItem Value="02">02</asp:ListItem>
                                                         <asp:ListItem Value="03">03</asp:ListItem>
                                                         <asp:ListItem Value="04">04</asp:ListItem>
                                                         <asp:ListItem Value="05">05</asp:ListItem>
                                                         <asp:ListItem Value="06">06</asp:ListItem>
                                                         <asp:ListItem Value="07">07</asp:ListItem>
                                                         <asp:ListItem Value="08">08</asp:ListItem>
                                                         <asp:ListItem Value="09">09</asp:ListItem>
                                                         <asp:ListItem Value="10">10</asp:ListItem>
                                                         <asp:ListItem Value="11">11</asp:ListItem>
                                                         <asp:ListItem Value="12">12</asp:ListItem>
                                                         <asp:ListItem Value="13">13</asp:ListItem>
                                                         <asp:ListItem Value="14">14</asp:ListItem>
                                                         <asp:ListItem Value="15">15</asp:ListItem>
                                                         <asp:ListItem Value="16">16</asp:ListItem>
                                                         <asp:ListItem Value="17">17</asp:ListItem>
                                                         <asp:ListItem Value="18">18</asp:ListItem>
                                                         <asp:ListItem Value="19">19</asp:ListItem>
                                                         <asp:ListItem Value="20">20</asp:ListItem>
                                                         <asp:ListItem Value="21">21</asp:ListItem>
                                                         <asp:ListItem Value="22">22</asp:ListItem>
                                                         <asp:ListItem Value="23">23</asp:ListItem>
                                                         <asp:ListItem Value="24">24</asp:ListItem>
                                                         <asp:ListItem Value="25">25</asp:ListItem>
                                                         <asp:ListItem Value="26">26</asp:ListItem>
                                                         <asp:ListItem Value="27">27</asp:ListItem>
                                                         <asp:ListItem Value="28">28</asp:ListItem>
                                                         <asp:ListItem Value="29">29</asp:ListItem>
                                                         <asp:ListItem Value="30">30</asp:ListItem>
                                                         <asp:ListItem Value="31">31</asp:ListItem>                     
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddlmonth1" runat="server" CssClass="s_dropdown">
                                                            <asp:ListItem Value="01">Jan</asp:ListItem>
                                                            <asp:ListItem Value="02">Feb</asp:ListItem>
                                                            <asp:ListItem Value="03">Mar</asp:ListItem>
                                                            <asp:ListItem Value="04">Apr</asp:ListItem>
                                                            <asp:ListItem Value="05">May</asp:ListItem>
                                                            <asp:ListItem Value="06">Jun</asp:ListItem>
                                                            <asp:ListItem Value="07">Jul</asp:ListItem>
                                                            <asp:ListItem Value="08">Aug</asp:ListItem>
                                                            <asp:ListItem Value="09">Sep</asp:ListItem>
                                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                                            <asp:ListItem Value="12">Nov</asp:ListItem>
                                                            <asp:ListItem Value="13">Dec</asp:ListItem>                        
                                                        </asp:DropDownList> 
                                                        <asp:DropDownList ID="ddlyear1" runat="server" CssClass="s_dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" class="style1"></td>
                                                <td align="left" class="style2"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="End Date"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                  <asp:DropDownList ID="ddlday2" runat="server" CssClass="s_dropdown">
                     <asp:ListItem Value="01">01</asp:ListItem>
                     <asp:ListItem Value="02">02</asp:ListItem>
                     <asp:ListItem Value="03">03</asp:ListItem>
                     <asp:ListItem Value="04">04</asp:ListItem>
                     <asp:ListItem Value="05">05</asp:ListItem>
                     <asp:ListItem Value="06">06</asp:ListItem>
                     <asp:ListItem Value="07">07</asp:ListItem>
                     <asp:ListItem Value="08">08</asp:ListItem>
                     <asp:ListItem Value="09">09</asp:ListItem>
                     <asp:ListItem Value="10">10</asp:ListItem>
                     <asp:ListItem Value="11">11</asp:ListItem>
                     <asp:ListItem Value="12">12</asp:ListItem>
                     <asp:ListItem Value="13">13</asp:ListItem>
                     <asp:ListItem Value="14">14</asp:ListItem>
                     <asp:ListItem Value="15">15</asp:ListItem>
                     <asp:ListItem Value="16">16</asp:ListItem>
                     <asp:ListItem Value="17">17</asp:ListItem>
                     <asp:ListItem Value="18">18</asp:ListItem>
                     <asp:ListItem Value="19">19</asp:ListItem>
                     <asp:ListItem Value="20">20</asp:ListItem>
                     <asp:ListItem Value="21">21</asp:ListItem>
                     <asp:ListItem Value="22">22</asp:ListItem>
                     <asp:ListItem Value="23">23</asp:ListItem>
                     <asp:ListItem Value="24">24</asp:ListItem>
                     <asp:ListItem Value="25">25</asp:ListItem>
                     <asp:ListItem Value="26">26</asp:ListItem>
                     <asp:ListItem Value="27">27</asp:ListItem>
                     <asp:ListItem Value="28">28</asp:ListItem>
                     <asp:ListItem Value="29">29</asp:ListItem>
                     <asp:ListItem Value="30">30</asp:ListItem>
                     <asp:ListItem Value="31">31</asp:ListItem>  
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlmonth2" runat="server" CssClass="s_dropdown">
                        <asp:ListItem Value="01">Jan</asp:ListItem>
                        <asp:ListItem Value="02">Feb</asp:ListItem>
                        <asp:ListItem Value="03">Mar</asp:ListItem>
                        <asp:ListItem Value="04">Apr</asp:ListItem>
                        <asp:ListItem Value="05">May</asp:ListItem>
                        <asp:ListItem Value="06">Jun</asp:ListItem>
                        <asp:ListItem Value="07">Jul</asp:ListItem>
                        <asp:ListItem Value="08">Aug</asp:ListItem>
                        <asp:ListItem Value="09">Sep</asp:ListItem>
                        <asp:ListItem Value="10">Oct</asp:ListItem>
                        <asp:ListItem Value="11">Nov</asp:ListItem>
                        <asp:ListItem Value="12">Dec</asp:ListItem> 
                    </asp:DropDownList>    
                    <asp:DropDownList ID="ddlyear2" runat="server" CssClass="s_dropdown">
                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                        Width="60px" onclick="btnSave_Click"/>
                                                    &nbsp;
                                                    <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" 
                                                        Width="60px" onclick="btnClear_Click"/>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 40px" align="left">
                                                    <asp:DataGrid ID="dgAcademic" runat="server" AutoGenerateColumns="False" 
                                                         OnEditCommand="dgAcademic_EditCommand" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" >
                                                        <AlternatingItemStyle BackColor="White" />
                                                        <ItemStyle BackColor="#DEEDFF" Font-Names="Verdana" Font-Size="11px" 
                                                            Height="25px" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intYear" HeaderText="Year"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strterm" HeaderText="Term"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="ddtstartdate" HeaderText="StartDate" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="ddtenddate" HeaderText="EndDate" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="startdate" HeaderText="Start Date">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="enddate" HeaderText="End Date"></asp:BoundColumn>
                                                            
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
                                                        <HeaderStyle Font-Bold="False" CssClass="s_datagrid_header" />
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
        <tr>
            <td class="break"></td>
        </tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc4:footer ID="footer1" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
