<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menutimetable.aspx.cs" Inherits="Lunch_menutimetable" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/activities_lunchmenu.ascx" tagname="activities_lunchmenu" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
   <%-- <script type="text/javascript" >
        function Validation() {
            if (document.getElementById("<%=ddlday.ClientID %>").value = "0") {
            alert("Please Select a Day");
            return false
        }
        }
    </script>--%>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
         </ajaxtoolkit:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
           <td align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
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
                                        <uc1:activities_lunchmenu ID="activities_lunchmenu1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/53.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Menu Time Table</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left:10px" valign="top" align="left">
                                        <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                <ProgressTemplate>
                                                    <div id="progressBackgroundFilter"></div>
                                                        <div id="processMessage">
                                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                                        </div>
                                                </ProgressTemplate>
                                        </asp:UpdateProgress>--%>
                                        <%--<asp:UpdatePanel ID="updatepanal" runat="server" >
                                             <ContentTemplate>--%>
                                                         <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td ><asp:Label ID="lbltitle" runat="server" Text="Add Food Menu" CssClass="title_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="7" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text=" Type"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddltype" runat="server" Width="150px" 
                                                                    onselectedindexchanged="ddltype_SelectedIndexChanged" AutoPostBack="True" 
                                                                    style="height: 22px">
                                                                    <asp:ListItem Value= "Breakfast" Text="Breakfast"></asp:ListItem>
                                                                    <asp:ListItem Value= "Lunch" Text="Lunch"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right"></td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="day0" runat="server" Text="Day" 
                                                                    CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlday" runat="server" Width="150px" AutoPostBack="True">
                                                                    <asp:ListItem Value= "0" Text="-Select-"></asp:ListItem>
                                                                    <asp:ListItem Value= "Monday" Text="Monday"></asp:ListItem>
                                                                    <asp:ListItem Value= "Tuesday" Text="Tuesday"></asp:ListItem>
                                                                    <asp:ListItem Value= "Wednesday" Text="Wednesday"></asp:ListItem>
                                                                    <asp:ListItem Value= "Thursday" Text="Thursday"></asp:ListItem>
                                                                    <asp:ListItem Value= "Friday" Text="Friday"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Text=" Menu Type"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButton ID="rbtveg" runat="server" CssClass="s_label" GroupName="meal" 
                                                                    Text="Veg"/>
                                                                &nbsp;
                                                                <asp:RadioButton ID="rbtnonveg" runat="server" CssClass="s_label" 
                                                                    GroupName="meal" Text="Non Veg" />
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trbreakfast" runat="server">
                                                            <td align="left">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Break Fast"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                              <asp:TextBox ID="txtfoodname" runat="server" Width="180px" CssClass="s_textbox"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trdrink" runat="server">
                                                            <td align="left">
                                                                <asp:Label ID="curry" runat="server" Text="Drink" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                              
                                                                <asp:TextBox ID="Txtcurryname" runat="server" Width="180px" CssClass="s_textbox" 
                                                                    ></asp:TextBox>
                                                                 </td>
                                                                 <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                         <tr id="trlunch" runat="server">
                                                            <td align="left">
                                                                <asp:Label ID="Label2" runat="server" Text="Main Dish" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                              
                                                                <asp:TextBox ID="txtmaindish" runat="server" Width="180px" CssClass="s_textbox" 
                                                                    ></asp:TextBox>
                                                                 </td>
                                                                 <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trsidedish" runat="server">
                                                            <td align="left">
                                                                <asp:Label ID="sidedish" runat="server" CssClass="s_label" Text="Side Dish"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                              
                                                                <asp:TextBox ID="Txtsidedish" runat="server" Width="180px" 
                                                                    CssClass="s_textbox"></asp:TextBox>
                                                                </td>
                                                            <td align="left">
                                                                </td>
                                                            <td align="left"></td>
                                                        </tr>
                                                         <tr id="tradditional" runat="server">
                                                            <td align="left">
                                                                <asp:Label ID="additional" runat="server" CssClass="s_label" Text="Additional"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                              
                                                                <asp:TextBox ID="txtadditional" runat="server" Width="180px" 
                                                                    CssClass="s_textbox" ></asp:TextBox>
                                                                </td>
                                                            <td align="left">
                                                                </td>
                                                            <td align="left"></td>
                                                        </tr>
                                                        <tr>
                                                            <td  style="height: 40px" align="right">
                                                                &nbsp;</td>
                                                            <td align="left">
                                                                &nbsp;<asp:Button ID="Btnsave" runat="server" onclick="btnsave_Click" 
                                                                    Text="Save" Width="80px" CssClass="s_button"  />

                                                                &nbsp;

                                                                <asp:Button ID="btnclear" runat="server" onclick="btnclear_Click1" Text="Clear" 
                                                                    Width="80px" CssClass="s_button" />
                                                                    </td>
                                                            <td style="width: 150px; height: 30px" align="left">&nbsp;</td>
                                                            <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:DataGrid ID ="dgmenutimetable" runat="server" CellPadding="4" 
                                                        AutoGenerateColumns="False"  Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                         <ItemStyle CssClass="s_datagrid_item" />
                                                         <Columns>
                                                             <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False">
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strday" HeaderText="Day"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strtype" HeaderText="Type">
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strmealstype" HeaderText="Menu Type">
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strfoodname" HeaderText="Break Fast">
                                                             </asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strcurryname" HeaderText="Drink"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strmaindish" HeaderText="Main Dish"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="strsidedish" HeaderText="Sidedish"></asp:BoundColumn>
                                                             <asp:BoundColumn DataField="stradditional" HeaderText="Additional"></asp:BoundColumn>                                                            
                                                         </Columns>                                                         
                                                         <HeaderStyle CssClass="s_datagrid_header" />                                                         
                                                     </asp:DataGrid>
                                                  </td>                                                    
                                            </tr>
                                        </table>
                                            <%-- </ContentTemplate>
                                        </asp:UpdatePanel>--%>
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
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>
