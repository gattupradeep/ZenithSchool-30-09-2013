<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addmedia.aspx.cs" Inherits="Library_addmedia" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register src="../usercontrol/admin_library.ascx" tagname="admin_library" tagprefix="uc1" %>
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
           <td style="width: 100%" align="left">
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
                                        <uc1:admin_library ID="admin_library1" runat="server" />
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
                        <td style="width: 1%" valign="top"></td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/262.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left"> Add / Edit media type</td>
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
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" class="title_label"> Add / Edit media type</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table cellpadding="7" cellspacing="0" border="0" >
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Media Type"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddl1" runat="server" Width="150px" 
                                                                    CssClass="s_dropdown" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddl1_SelectedIndexChanged" >
                                                                </asp:DropDownList>
                                                               
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl1" 
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                              </td>
                                                            <td align="right"></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Media Category"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddl2" runat="server" Width="150px" 
                                                                    CssClass="s_dropdown">
                                                                </asp:DropDownList>
                                                               
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddl1" 
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>                                                   
                                                            </td>
                                                            <td align="right"></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="code"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="Txtcode" runat="server" Width="180px" 
                                                                    CssClass="s_textbox" ></asp:TextBox><asp:RequiredFieldValidator 
                                                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txtcode"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                            <td style="width: 150px; height: 40px" align="left">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label3" runat="server" Text="Name/Title" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left" >                                                                
                                                                <asp:TextBox ID="Txtname" runat="server" Width="180px" CssClass="s_textbox"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="Validator1_name" runat="server" ControlToValidate="Txtname"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label4" runat="server" Text="Author Name" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:TextBox ID="Txtauthor" runat="server" Width="180px" CssClass="s_textbox"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txtauthor"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label5" runat="server" Text="Publisher/Vendor Name" 
                                                                    CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                
                                                                <asp:TextBox ID="Txtvendor" runat="server" Width="180px" CssClass="s_textbox"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txtvendor"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label6" runat="server" Text="Edition" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">                                                              
                                                                <asp:TextBox ID="Txtedition" runat="server" Width="180px" CssClass="s_textbox"></asp:TextBox>
                                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Txtedition"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="right" ></td>
                                                            <td align="left" ></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label7" runat="server" Text="Price" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">                                                               
                                                                <asp:TextBox ID="Txtprice" runat="server" Width="180px" CssClass="s_textbox"></asp:TextBox>
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Txtprice" 
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                
                                                            </td>
                                                            <td align="left" ><asp:RegularExpressionValidator ID="REV2" runat="server" ValidationExpression="^(\d)*\.?\d*$" ControlToValidate="Txtprice" ErrorMessage="Numbers only"></asp:RegularExpressionValidator></td></td>
                                                            <td align="left" ></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" Text="No. Of Copies" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">                                                               
                                                                <asp:TextBox ID="Txtcopies" runat="server" MaxLength="10" Width="180px" 
                                                                    CssClass="s_textbox" ></asp:TextBox>
                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Txtcopies"
                                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:RegularExpressionValidator ID="REV1" runat="server" ValidationExpression="^(\d)*\.?\d*$" ControlToValidate="Txtcopies" ErrorMessage="Numbers only"></asp:RegularExpressionValidator></td>
                                                            <td align="left" ></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" >
                                                                <asp:Label ID="barcde" runat="server" CssClass="s_label" Text="Barcode"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:TextBox ID="Txtbarcde" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td align="right" ></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="height:30px" colspan="4"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="height:30px">&nbsp;</td>
                                                            <td align="center" >
                                                                <asp:Button ID="btnsave" runat="server" Text="Save" Width="58px" 
                                                                    CssClass="s_button" onclick="btnsave_Click" />
                                                                </td>
                                                            <td align="left" >
                                                                <asp:Button ID="btnclear" runat="server" Text="Clear" Width="70px" 
                                                                    CssClass="s_button" onclick="btnclear_Click" CausesValidation="False" />
                                                                </td>
                                                            <td align="left" >&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="height:30px" colspan="4">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  style="height: 40px" align="left" colspan="4">
                                                    <asp:DataGrid ID="dgaddmedia" runat="server" AutoGenerateColumns="False"                                                         
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        oneditcommand="dgaddmedia_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                             <asp:BoundColumn DataField="intid" HeaderText="Int ID" Visible="False"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strmediatype" HeaderText="Media type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strmediacategory" HeaderText="Category" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                             </asp:BoundColumn>                                                            
                                                             <asp:BoundColumn DataField="strtitle" HeaderText="Title" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strauthorname" HeaderText="Author" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="stredition" HeaderText="Edition" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="intprice" HeaderText="Price" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                             </asp:BoundColumn>                                                             
                                                             <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
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
                                                            <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>--%>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
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
    <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>
