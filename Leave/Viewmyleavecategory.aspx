<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Viewmyleavecategory.aspx.cs" Inherits="Leave_Viewmyleavecategory" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>

<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/admin_leave.ascx" tagname="admin_leave" tagprefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1" runat="server"><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>
    The Schools.in - Admin</title><link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../css/autocomplete.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script><script type="text/javascript">
        $(document).ready(function() {

            $("ul#topnav li").hover(function() { //Hover over event on list item
                $(this).css({ 'background': '#88BB00 url(topnav_active.gif) repeat-x' }); //Add background color + image on hovered list item
                $(this).find("span").show(); //Show the subnav
            }, function() { //on hover out...
                $(this).css({ 'background': 'none' }); //Ditch the background
                $(this).find("span").hide(); //Hide the subnav
            }); 

        });
        </script><script type="text/javascript">
        $(document).ready(function() {
            $('#chkall').click(
             function() {
                 $("INPUT[type='checkbox']").attr('checked', $('#chkall').is(':checked'));
             });
         });
        </script><script type="text/javascript">

     </script>
    </head><body><form id="form1" runat="server">
    <div>
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:toolkitscriptmanager>
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
                                        <uc5:admin_leave ID="admin_leave1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/55.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >View Staff &#39;s Leave Category</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td colspan="8">
                                                    <table cellpadding="3" cellspacing="0" border="0" class="thick_curve" width="98%">
                                                        <tr>
                                                            <td></td>
                                                            <td align="left" style="width:10%">
                                                                <asp:Label ID="lbldept" runat="server" CssClass="s_label" Text="Department"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width:10%">
                                                                <asp:Label ID="lbldesig" runat="server" CssClass="s_label" Text="Designation"></asp:Label>
                                                            </td>                                                            
                                                            <td align="left" style="width:10%">                                                               
                                                                <asp:Label ID="lblstaffname" runat="server" CssClass="s_label" 
                                                                    Text="Staff Name"></asp:Label>                                                               
                                                            </td>
                                                        </tr>
                                                        <tr> <td align="left" style="width:10%" valign="top">
                                                               <asp:DropDownList ID="drpyear" runat="server" Visible="false"
                                                                    CssClass="s_dropdown" Width="80px"></asp:DropDownList>
                                                            </td>                                                            
                                                            <td align="left" style="width:15%" valign="top">
                                                                <asp:DropDownList ID="drp_dept" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" >
                                                                </asp:DropDownList>
                                                            </td>                                                            
                                                            <td align="left" style="width:15%" valign="top">
                                                                <asp:DropDownList ID="drp_desig" runat="server" CssClass="s_dropdown" 
                                                                    Width="150px" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width:20%">
                                                                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                                                                    
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="break" colspan="8"></td>
                                            </tr>                                            
                                            <tr>
                                                <td colspan="8">
                                                    <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto">
                                                        <tr class="view_detail_title_bg" style="height:30px">
                                                            <td align="center" style="width:10%; ">
                                                                <asp:Label ID="lblgrdid" runat="server" CssClass="header_lable" Text="Staff ID" ></asp:Label>
                                                            </td>
                                                            <td  align="center" style="width: 27%;">
                                                                <asp:Label ID="lblgrdname" runat="server" CssClass="header_lable" Text="Staff Name"></asp:Label>
                                                            </td>
                                                            <td  align="center" style="width: 27%;">
                                                                <asp:Label ID="lblgrdleave" runat="server" Text="Leave Type" CssClass="header_lable"></asp:Label>
                                                            </td>
                                                            <td  align="center" style="width: 10%;">
                                                                <asp:Label ID="lblgrddays" runat="server" CssClass="header_lable" Text="Total Days" ></asp:Label>
                                                            </td>
                                                            <td align="center" style="width: 10%;">
                                                                <asp:Label ID="lblgrdused" runat="server" CssClass="header_lable" Text="Used Days"></asp:Label>
                                                            </td>
                                                                 <td align="center" style="width: 10%;">
                                                                <asp:Label ID="lblgrdavail" runat="server" CssClass="header_lable" Text="Available Days"></asp:Label>
                                                            </td>                                                            
                                                                 <td align="center" style="width: 6%;">
                                                                <asp:Label ID="lblview" runat="server" CssClass="header_lable" Text="View"></asp:Label>
                                                            </td>                                                            
                                                        </tr>                                                      
                                                        <tr>        
                                                            <td align="left" colspan="7" style="width: 100%;">
                                                                <asp:DataGrid ID="grdleavecategory" runat="server" AutoGenerateColumns="False" 
                                                                    ShowHeader="false" AllowPaging="true"
                                                                Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                                    onpageindexchanged="grdleavecategory_PageIndexChanged">                                                            
                                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                                    <ItemStyle CssClass="s_datagrid_item" />
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="intstaff" HeaderText="Staff ID" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" >
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="name" HeaderText="Staff Name" ItemStyle-Width="27%" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="Center" Width="27%"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="strleavetype" HeaderText="Leave Category" ItemStyle-Width="27%" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="Center" Width="27%"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="intnoofdays" HeaderText="Total Days" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">                                                                                                                                                                                
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="useddays" HeaderText="Total Days" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">                                                                                                                                                                                
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="availabledays" HeaderText="Total Days" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">                                                                                                                                                                                
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="intleavecategory" HeaderText ="feetype" Visible="false" >
                                                                        </asp:BoundColumn>
                                                                        <asp:TemplateColumn ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnview" runat="server" AlternateText="View" 
                                                                                    ImageUrl="~/media/images/view.png" onclick="btnview_Click" />
                                                                            </ItemTemplate>

                                                                            <ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                    <PagerStyle Mode="NumericPages" Font-Bold="true" Font-Size="13px" />
                                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                                                    </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                     <tr id="tr1" runat="server">
                                                      <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                                         <asp:Label ID="errormessage" runat="server" CssClass="nodatatodisplay"></asp:Label>
                                                      </td>
                                                   </tr>
                                                </td>
                                                </tr>
                                        </table> 
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
              </td>
            </tr>
          </table>
     <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>
