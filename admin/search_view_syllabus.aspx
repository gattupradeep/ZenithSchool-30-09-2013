<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search_view_syllabus.aspx.cs" Inherits="admin_search_view_syllabus" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/admin_syllabus.ascx" tagname="admin_syllabus" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
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

        var showflag = 1;
        // Function to hide and unhide second datagrid.
        function makeVisible(ch, show, img) {
            if (document.getElementById(ch).innerHTML != "") {
                if (show == 1) {
                    if (document.getElementById(ch).style.visibility == "visible") {
                        document.getElementById(ch).style.visibility = "hidden";
                        img.src = "../images/add_new.png";
                        document.getElementById(ch).style.display = 'none';
                    }
                    else {
                        document.getElementById(ch).style.visibility = "visible";
                        document.getElementById(ch).style.display = '';
                        img.src = "../images/details_close.png";
                    }
                    showflag = 0;
                }
                else {
                    if (document.getElementById(ch).style.visibility == "visible") {
                        document.getElementById(ch).style.visibility = "hidden";
                        img.src = "../images/add_new.png";
                        document.getElementById(ch).style.display = 'none';
                    }
                    else {
                        document.getElementById(ch).style.visibility = "visible";
                        document.getElementById(ch).style.display = '';
                        img.src = "../images/details_close.png";
                    }
                    showflag = 1;
                }
            }
        }
		</script>
    </head>
<body>
    <form id="Form1" method="post" runat="server">
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
                        <td style="width: 1%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >View School Syllabus</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                    <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                    <tr>
                                        <td colspan="6" style="width: 750px; height: 20px" align="right">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 60px; height: 30px" align="left">
                                            <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                        </td>
                                        <td align="left" width="148px">
                                            <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" Width="145px" AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td style="width: 80px; height: 30px" align="center">
                                             <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Subject"></asp:Label>
                                        </td>
                                        <td style="width: 148px; height: 30px" align="left">
                                           <asp:DropDownList ID="ddlsubject" runat="server" CssClass="s_dropdown" Width="145px" AutoPostBack="True" onselectedindexchanged="ddlsubject_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td width="100px">                                            
                                            <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Textbook"></asp:Label>
                                        </td>
                                        <td width="148px" align="center">
                                            <asp:DropDownList ID="ddltextbook" runat="server" CssClass="s_dropdown" 
                                                Width="145px" AutoPostBack="True" Height="24px" 
                                                onselectedindexchanged="ddltextbook_SelectedIndexChanged1"></asp:DropDownList>
                                        </td>
                                    </tr>
                                   <tr>
                                        <td style="width: 100%; height: 30px" align="center" colspan="6">
                                            <asp:Label ID="lblmsg" runat="server" CssClass="s_label"></asp:Label>
                                        </td>
                                   </tr>
                                   <tr>
                                        <td style="width: 100%; height: 30px" align="right" colspan="6">
                                            <asp:DataGrid ID="datagrid" runat="server" AutoGenerateColumns="False" 
                                                Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                            <AlternatingItemStyle CssClass="s_datagrid_alt_item" /><ItemStyle CssClass="s_datagrid_item" />
                                                <Columns>                                                    
                                                    <asp:BoundColumn DataField="strstandard" HeaderText="Standard"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">

                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strsubject" HeaderText="Subject"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">

                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strtextbook" HeaderText="TextBook Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">

                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="strauthor" HeaderText="Author" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="intunits" HeaderText="Number Of Units" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="View" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnview" runat="server" ImageUrl="~/media/images/view.png" AlternateText="view" onclick="btnview_Click"/>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:ButtonColumn Visible="false" CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;" ItemStyle-HorizontalAlign="Center"><ItemStyle Width="40px"/></asp:ButtonColumn>
                                                    <asp:ButtonColumn Visible="false" CommandName="delete" HeaderText="Delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;" ItemStyle-HorizontalAlign="Center"><ItemStyle Width="50px" /></asp:ButtonColumn>
                                                </Columns>
                                            <HeaderStyle CssClass="s_datagrid_header"/>
                                            </asp:DataGrid>
                                        </td>
                                   </tr>
                                   <tr>
                                        <td style="width: 150px; height: 30px" align="right" colspan="6">&nbsp;</td>
                                   </tr>
                                   <tr class="view_detail_title_bg" id="trtag" runat="server">
                                        <td style="height: 40px" align="center" colspan="6">
                                            <table>
                                                <tr>
                                                    <td style="width: 90px; height: 40px" align="center">
                                                        <asp:Label ID="Label5" runat="server" Text="Standard :"></asp:Label>
                                                    </td>
                                                    <td style="width: 90px; height: 40px" align="left">
                                                        <asp:Label ID="lblstandard" runat="server" ForeColor="Black"></asp:Label>
                                                    </td>
                                                    <td style="width: 90px; height: 40px" align="center">
                                                        <asp:Label ID="Label7" runat="server" Text="Subject :"></asp:Label>
                                                    </td>
                                                    <td style="width: 90px; height: 40px" align="left">
                                                        <asp:Label ID="lblsubject" runat="server" ForeColor="Black"></asp:Label>
                                                    </td>
                                                    <td style="width: 90px; height: 40px" align="center">                                            
                                                        <asp:Label ID="Label9" runat="server"  Text="Textbook :"></asp:Label>
                                                    </td>
                                                    <td style="width: 90px; height: 40px" align="left">                                            
                                                        <asp:Label ID="lbltextbook" runat="server" ForeColor="Black"></asp:Label>
                                                    </td>
                                                    <td style="width: 90px; height: 40px" align="center">                                            
                                                        <asp:Label ID="Label11" runat="server"  Text="Author :"></asp:Label>
                                                    </td>
                                                    <td style="width: 90px; height: 40px" align="left">                                            
                                                        <asp:Label ID="lblauthor" runat="server" ForeColor="Black"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                   </tr>
                                   <tr>
                                        <td style="height: 10px" align="right" colspan="6">&nbsp;</td>
                                   </tr>
                                   <tr id="trtag2" runat="server">
                                        <td colspan="6" style="height: 30px" align="center">
                                           <asp:datagrid id="DataGrid1" runat="server"  AutoGenerateColumns="False" Width="100%">
			                                <AlternatingItemStyle CssClass="s_datagrid_alt_item"></AlternatingItemStyle>
			                                <ItemStyle CssClass="s_datagrid_item"></ItemStyle>
			                                <HeaderStyle CssClass="s_datagrid_header"></HeaderStyle>			                                
			                                <Columns>
				                            <asp:TemplateColumn HeaderText="Units and Lessons">
				                            <ItemTemplate>
					                            <table>
						                            <tr>
							                            <td><img src="../images/add_new.png" id="imgOpen<%# DataBinder.Eval(Container, "DataItem.ProductID") %>" onclick="javascript:makeVisible('submenu<%# DataBinder.Eval(Container, "DataItem.ProductID") %>',showflag,this);" alt=""></td>
							                            <td><%# DataBinder.Eval(Container, "DataItem.unit")%></td>
						                            </tr>
					                            </table>
					                                <!-- Div Starts Here -->
					                                <div style="visibility:hidden;display:none;" id="submenu<%# DataBinder.Eval(Container, "DataItem.ProductID") %>" >
					                                <!-- Second DataGrid Starts Here -->
						                                <asp:DataGrid id="Datagrid2" runat="server" BorderStyle="Solid" DataSource='<%# DataBinder.Eval(Container, "DataItem.myRelation") %>'
							                                 AutoGenerateColumns="False" Width="100%">
								                            <AlternatingItemStyle CssClass="s_datagrid_alt_item"></AlternatingItemStyle>
								                            <ItemStyle CssClass="s_datagrid_item"></ItemStyle>
								                            <HeaderStyle CssClass="s_datagrid_header"></HeaderStyle>
								                            <Columns>
									                        <asp:TemplateColumn HeaderStyle-Width="100">
										                        <ItemTemplate>
											                        <table>
												                        <tr>
													                    <td width="10px"></td>
													                    <td ><img src="../images/tree.jpg" alt=""></td>
													                    <td width="10px"><%# DataBinder.Eval(Container, "DataItem.count")%></td>													                    
												                    </tr>
											                    </table>
										                    </ItemTemplate>
									                        </asp:TemplateColumn>									                        
									                        <asp:BoundColumn DataField="strlessonName" HeaderText="Lessons" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ></asp:BoundColumn>
								                            </Columns>
								                            </asp:DataGrid>
								                            <!-- Second DataGrid Ends Here -->
								                            </div> 
								                            <!-- Div Ends Here -->
						                                </ItemTemplate>
					                                <HeaderStyle />
					                                </asp:TemplateColumn>
				                                </Columns>
			                                </asp:datagrid>
                                        </td>
                                  </tr>
                          </table>
                     </td>
                </tr>
          </table></td></tr></table>
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
