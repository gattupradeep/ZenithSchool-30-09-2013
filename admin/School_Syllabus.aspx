<%@ Page Language="C#" AutoEventWireup="true" CodeFile="School_Syllabus.aspx.cs" Inherits="admin_School_Syllabus" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/admin_syllabus.ascx" tagname="admin_syllabus" tagprefix="uc1" %>

<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>


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

            .style11
            {
                height: 30px;
                }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 100%; height: 144px" align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 80px" valign="top">
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
                                        <uc1:admin_syllabus ID="admin_syllabus1" runat="server" />
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
                        <td style="width: 2%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="750">
                                            <tr>
                                                <td style="width: 50px; height: 50px"><img src="../media/images/moduleimg1.jpg" width="50" height="50" /></td>
                                                <td style="width: 685px; height: 50px; font-family: Arial; font-size: 23px; color: #2DA0ED; padding-left: 10px" align="left">
                                                    School Syllabus</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                    <table cellpadding="0" cellspacing="0" border="0" width="700">
                                    <tr>
                                        <td colspan="4" style="width: 700px; height: 20px" align="right">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px; height: 40px" align="left">
                                            <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Class"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                Width="145px" AutoPostBack="True" 
                                                onselectedindexchanged="ddlstandard_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td style="width: 150px; height: 40px" align="right"></td>
                                        <td style="width: 200px; height: 40px" align="left"><asp:Label ID="hiddentxtlessonname" runat="server" Visible="false"></asp:Label></td>
                                    </tr>
                                    <tr>
                                       <td style="width: 150px; height: 40px" align="left">
                                             <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Subject"></asp:Label>
                                       </td>
                                       <td align="left" >
                                           <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_dropdown" 
                                               Width="145px" AutoPostBack="True" 
                                               onselectedindexchanged="ddlsubject_SelectedIndexChanged"></asp:DropDownList>
                                       </td>
                                       <td style="width: 150px; height: 40px" align="right"></td>
                                       <td style="width: 200px; height: 40px" align="left"></td>
                                   </tr>
                                   <tr>
                                       <td style="width: 150px; height: 40px" align="left">
                                           <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="TextBook Name"></asp:Label>
                                       </td>
                                       <td colspan="2" style="width: 350px; height: 30px" align="left" class="style11">
                                            <asp:TextBox ID="txttextbookname" runat="server" CssClass="s_textbox" Width="330px"></asp:TextBox>
                                       </td>
                                       <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td style="width: 150px; height: 40px" align="left">
                                           <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Author"></asp:Label>
                                       </td>
                                       <td colspan="2" style="width: 350px; height: 30px" align="left" class="style11">
                                            <asp:TextBox ID="txtauthor" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                       </td>
                                       <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                   </tr>
                                   <tr>
                                        <td style="width: 150px; height: 40px" align="left">
                                           <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="No Of Units"></asp:Label>
                                        </td>
                                        <td style="width: 200px; height: 30px" align="left" class="style11">
                                           <asp:DropDownList ID="ddlnumberofunits" runat="server" CssClass="s_dropdown" 
                                                Width="145px" AutoPostBack="True" 
                                                onselectedindexchanged="ddlnumberofunits_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--select--</asp:ListItem>
                                               <asp:ListItem Value="1">1</asp:ListItem>
                                               <asp:ListItem Value="2">2</asp:ListItem>
                                               <asp:ListItem Value="3">3</asp:ListItem>
                                               <asp:ListItem Value="4">4</asp:ListItem>
                                               <asp:ListItem Value="5">5</asp:ListItem>
                                               <asp:ListItem Value="6">6</asp:ListItem>
                                               <asp:ListItem Value="7">7</asp:ListItem>
                                               <asp:ListItem Value="8">8</asp:ListItem>
                                               <asp:ListItem Value="9">9</asp:ListItem>
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
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 150px; height: 30px" align="left" class="style11"></td>
                                        <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                   </tr>
                                   <tr>
                                        <td style="width: 150px; height: 40px" align="left">
                                           <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Unit No"></asp:Label>
                                        </td>
                                        <td style="width: 200px; height: 30px" align="left" class="style11">
                                           <asp:DropDownList ID="ddlunitno" runat="server" CssClass="s_dropdown" 
                                                Width="145px" AutoPostBack="True" 
                                                onselectedindexchanged="ddlunitno_SelectedIndexChanged" ></asp:DropDownList>
                                        </td>
                                        <td style="width: 150px; height: 30px" align="left" class="style11">&nbsp;</td>
                                        <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                   </tr>
                                   <tr>
                                        <td style="width: 150px; height: 40px" align="left">
                                           <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Unit Name"></asp:Label>
                                        </td>
                                        <td style="height: 30px" align="left" class="style11" colspan="2">
                                            <asp:TextBox ID="txtunitname" runat="server" CssClass="s_textbox" 
                                                Width="330px"></asp:TextBox>
                                        </td>
                                        <td style="width: 200px; height: 30px" align="left">
                                            <asp:Button ID="btnaddlesson" runat="server" CssClass="s_button" 
                                                onclick="btnaddlesson_Click" Text="Add Lesson" />
                                        </td>
                                   </tr>
                                   <tr id="lessontag" runat="server">
                                        <td style="width: 150px; height: 40px" align="left">
                                           <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Lesson Name"></asp:Label>
                                        </td>
                                        <td style="height: 30px" align="left" class="style11" colspan="2">
                                            <asp:TextBox ID="txtlessonName" runat="server" CssClass="s_textbox" 
                                                Width="330px"></asp:TextBox>
                                        </td>
                                        <td style="width: 200px; height: 30px" align="left">
                                            &nbsp;</td>
                                   </tr>
                                   <tr>
                                        <td style="width: 150px; height: 40px" align="left">
                                            &nbsp;</td>
                                        <td style="width: 200px; height: 30px" align="center" class="style11">
                                            <asp:Button ID="Btnadd" runat="server" CssClass="s_button" Text="Add" onclick="Btnadd_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" Width="60px" onclick="btnClear_Click" />
                                        </td>
                                        <td style="width: 150px; height: 30px" align="left" class="style11">&nbsp;</td>
                                        <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                   </tr>
                                   <tr>
                                        <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                        <td align="right">
                                            &nbsp;</td>
                                        <td style="width: 150px; height: 30px" align="center">
                                            &nbsp;</td>
                                        <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                   </tr>
                                   <tr>
                                        <td colspan="4" style="height: 30px" align="left">
                                            <asp:DataGrid ID="datagrid" runat="server" AutoGenerateColumns="False" 
                                                Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" oneditcommand="datagrid_EditCommand" >
                                            <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="strstandard" HeaderText="Standard"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strsubject" HeaderText="Subject"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strtextbook" HeaderText="TextBook Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strauthor" HeaderText="Author" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="intunits" HeaderText="Number Of Units" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strunitno" HeaderText="Unit No" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strunitname" HeaderText="Unit Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;" ItemStyle-HorizontalAlign="Center"><ItemStyle Width="40px"/></asp:ButtonColumn>
                                                    <asp:TemplateColumn HeaderText="Delete">
                                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btndelete" runat="server" 
                                                                ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                            OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                                onclick="btndelete_Click"  />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;" ItemStyle-HorizontalAlign="Center"><ItemStyle Width="50px" /></asp:ButtonColumn>--%>
                                                </Columns>
                                            <HeaderStyle CssClass="s_datagrid_header"/>
                                            </asp:DataGrid>
                                        </td>
                                  </tr>
                                   <tr>
                                        <td colspan="4" style="height: 30px" align="left">
                                            &nbsp;</td>
                                  </tr>
                                  <tr>
                                  <td colspan="4" style="width: 700px; height: 40px" align="right">
                                            <asp:DataGrid ID="dgsyllabus" runat="server" AutoGenerateColumns="False" 
                                                Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                onitemdatabound="dgsyllabus_ItemDataBound1">
                                            <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                            <Columns>
                                                <asp:BoundColumn DataField="strstandard" HeaderText="Standard" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="strsubject" HeaderText="Subject"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="strtextbook" HeaderText="TextBook Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="strauthor" HeaderText="Author" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="unit" HeaderText="Unit" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Lessons" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>                                                        
                                                    <asp:DataGrid ID="dgsub" runat="server" AutoGenerateColumns="False" 
                                                        GridLines="None" Width="100%" 
                                                        oneditcommand="dgsub_EditCommand" CellPadding="4" ForeColor="#333333">
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <EditItemStyle BackColor="#2461BF" />
                                                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                        <AlternatingItemStyle BackColor="White"  />
                                                        <ItemStyle BackColor="#EFF3FB"  />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" ItemStyle-HorizontalAlign="Center" Visible="false">                                                                    
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strlessonName" ItemStyle-HorizontalAlign="left">                                                                    
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="edit"  Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;" ItemStyle-HorizontalAlign="Center"><ItemStyle Width="40px"/></asp:ButtonColumn>
                                                            <asp:TemplateColumn HeaderText="Delete">
                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btndelete1" runat="server" 
                                                                        ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                                    OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                                        onclick="btndelete1_Click"  />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <%--<asp:ButtonColumn CommandName="delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;" ItemStyle-HorizontalAlign="Center"><ItemStyle Width="50px" /></asp:ButtonColumn>--%>
                                                        </Columns>
                                                        <HeaderStyle/>
                                                    </asp:DataGrid>                                                            
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <HeaderStyle CssClass="s_datagrid_header"/>
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                  <tr>
                                  <td colspan="4" style="width: 700px; height: 40px" align="right">&nbsp;</td>
                                    </tr>
                          </table>
                     </td>
                </tr>
          </table></td></tr></table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
                <uc4:footer ID="footer1" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
