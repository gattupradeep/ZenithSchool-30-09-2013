<%@ Page Language="C#" AutoEventWireup="true" CodeFile="returndate.aspx.cs" Inherits="Library_Default" %>
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
    <script type ="text/javascript">
        function Addtotaldays() {

            var value1 = document.getElementById("<%=Txtnoofdays.ClientID %>").value;
           
            var value2 = document.getElementById("<%=txtupto1.ClientID %>").value;
            var value3 = document.getElementById("<%=txtupto2.ClientID %>").value;
            var value4 = document.getElementById("<%=txtupto3.ClientID %>").value;
            var value5 = document.getElementById("<%=txtupto4.ClientID %>").value;

            if (value1 == "") {
                document.getElementById("<%=Txtnoofdays.ClientID %>").value = 0;
            }
            if (value2 == "") {
                document.getElementById("<%=txtupto1.ClientID %>").value = 0;
            }
            if (value3 == "") {
                document.getElementById("<%=txtupto2.ClientID %>").value = 0;
            }
            if (value4 == "") {
                document.getElementById("<%=txtupto3.ClientID %>").value = 0;
            }
            if (value5 == "") {
                document.getElementById("<%=txtupto4.ClientID %>").value = 0;
            }
            var value6 = parseInt(value1) + parseInt(value2) + parseInt(value3) + parseInt(value4) + parseInt(value5);
            document.getElementById("Totaldays").value = parseInt(value6);

        }
        window.onload = Addtotaldays;
    </script>
   </head>
<body>
    <form id="form1" runat="server">
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
                         <td style="width: 1%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/262.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Return Date</td>
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
                                                <td class="title_label" colspan="2">&nbsp;Return Date</td>
                                            </tr>
                                            <tr>
                                                <td valign="top" >
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="pat1" runat="server" CssClass="s_label" Text="Patron Type"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlpatron" runat="server" Width="150px" CssClass="s_dropdown" AutoPostBack="True" onselectedindexchanged="ddl3_SelectedIndexChanged">
                                                                    <asp:ListItem Value= "Select">Select</asp:ListItem>
                                                                    <asp:ListItem Value= "Employee">Employee</asp:ListItem>
                                                                    <asp:ListItem Value="Student" Text="Student"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trstd" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Lablstan" runat="server" Text="Standard" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlstd" runat="server" Width="150px"></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trdept" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Lablsec" runat="server" Text="Department" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">                                                                
                                                                <asp:DropDownList ID="ddldept" runat="server" style="height: 22px" Width="150px" Height="16px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trdesig" runat="server">
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Lablsec0" runat="server" Text="Designation" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddldesig" runat="server" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                         </tr>
                                                         <tr >
                                                            <td align="left">
                                                                <asp:Label ID="Label7" runat="server" Text="Media Type" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:DropDownList ID="ddlmt" runat="server" Width="150px" CssClass="s_dropdown">
                                                                </asp:DropDownList>                                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" Text="Media Category" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:DropDownList ID="ddlmc" runat="server" Width="150px" 
                                                                    CssClass="s_dropdown">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr >
                                                            <td align="left">
                                                                <asp:Label ID="noofdays" runat="server" CssClass="s_label" Text="No Of Days"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="Txtnoofdays" runat="server" Width="140px" 
                                                                    CssClass="s_textbox" value="0" onblur="Addtotaldays();"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr >
                                                            <td align="left">
                                                                <asp:Label ID="noofrenewal" runat="server" CssClass="s_label" Text="No Of Renewal"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="Txtnoofrenewal" runat="server" Width="140px" CssClass="s_textbox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="left" valign="top">
                                                    <table cellpadding="0" cellspacing="0" width="300px;" align="left">
                                                        <tr>
                                                            <td style="height: 10px" colspan="2" align="center">
                                                            <asp:Label ID="Label19" runat="server" CssClass="s_label" Text="Fine Details"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr >
                                                            <td style="width:150px;height: 10px" align = "center" >
                                                            <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="Days"></asp:Label>
                                                            </td>
                                                             <td style="width:150px;height: 10px" align ="center">
                                                            <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="Amount"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr >
                                                            <td>
                                                            <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Up To" ></asp:Label>&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtupto1" runat="server" CssClass="s_textbox" Width="50px" value="0" onblur="Addtotaldays();"></asp:TextBox>
                                                                </td>
                                                             <td>
                                                            <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Fine Amout"></asp:Label>&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtfineamount1" runat="server" CssClass="s_textbox" Width="50px" ></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr >
                                                            <td style="width:150px;height: 40px" >
                                                  
                                                            <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Up To" ></asp:Label>&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtupto2" runat="server" CssClass="s_textbox" Width="50px" value="0" onblur="Addtotaldays();"></asp:TextBox>
                                                            </td>
                                                             <td style="width:150px;height: 40px">

                                                            <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Fine Amout"></asp:Label>&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtfineamount2" runat="server" CssClass="s_textbox" Width="50px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr >
                                                             <td style="width:150px;height: 40px" >
                                                            <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Up To"></asp:Label>&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtupto3" runat="server" CssClass="s_textbox" Width="50px" value="0" onblur="Addtotaldays();"></asp:TextBox>
                                                             </td>
                                                             <td style="width:150px;height: 40px">
                                                            <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Fine Amout"></asp:Label>&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtfineamount3" runat="server" CssClass="s_textbox" Width="50px"></asp:TextBox>
                                                             </td>
                                                        </tr>
                                                        <tr >
                                                             <td style="width:150px;height: 40px" >
                                                            <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Up To"></asp:Label>&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtupto4" runat="server" CssClass="s_textbox" Width="50px" value="0" onblur="Addtotaldays();"></asp:TextBox>
                                                             </td>
                                                             <td style="width:150px;height: 40px">
                                                            <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Fine Amout"></asp:Label>&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtfineamount4" runat="server" CssClass="s_textbox" Width="50px" ></asp:TextBox>
                                                             </td>
                                                        </tr>
                                                        <tr >
                                                             <td style="width:150px;height: 40px" >
                                                            <asp:Label ID="Label20" runat="server" CssClass="s_label" Text="After"></asp:Label>
                                                             &nbsp;&nbsp;&nbsp; <asp:TextBox ID="Totaldays" runat="server" Width="30px" ReadOnly="true" style="border:0px;" Onfocus="Addtotaldays();" ></asp:TextBox>
                                                            <asp:Label ID="Label22" runat="server" CssClass="s_label" Text="Days"></asp:Label>
                                                             </td>
                                                             <td style="width:150px;height: 40px">
                                                            <asp:Label ID="Label21" runat="server" CssClass="s_label" Text="Per day"></asp:Label>
                                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:TextBox ID="txtfineperday" runat="server" CssClass="s_textbox" Width="50px" ></asp:TextBox>
                                                             </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <table cellpadding="0" cellspacing="0" width="100%" border="0" align="center">
                                                         <tr align="center">
                                                            <td  style="height: 40px" >
                                                            <asp:Button ID="Btnsave" runat="server" CssClass="s_button" 
                                                            Text="Save" onclick="Btnsave_Click" />&nbsp;&nbsp;
                                                            <asp:Button ID="btnclear" runat="server"  Text="Clear" 
                                                             CssClass="s_button" onclick="btnclear_Click" />
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                            <td  style="height: 40px" >
                                                                <asp:DataGrid ID="dgreturndate" runat="server" CellPadding="4" 
                                                                     GridLines="None" Width="100%" 
                                                                    AutoGenerateColumns="False" 
                                                                    oneditcommand="dgreturndate_EditCommand"  >
                                                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                    <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                                    <AlternatingItemStyle CssClass = "s_datagrid_alt_item" />
                                                                    <ItemStyle CssClass = "s_datagrid_item" />
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strpatron" HeaderText="Patron"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strdesignation" HeaderText="Designation"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strdepartmentname" HeaderText="Department"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strstandard" HeaderText="Standard"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strmediatype" HeaderText="Media Type"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strmediacategory" HeaderText="Media Category"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="intnoofdays" HeaderText="No of Days"></asp:BoundColumn>
                                                                        <asp:ButtonColumn CommandName="edit" HeaderText="Edit" 
                                                                            Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
                                                                            <ItemStyle Width="40px" />
                                                                        </asp:ButtonColumn>
                                                                        <asp:TemplateColumn HeaderText="Delete">
                                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
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
                                                                    <HeaderStyle CssClass = "s_datagrid_header" />
                                                                </asp:DataGrid>
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
    <cc1:MsgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>
