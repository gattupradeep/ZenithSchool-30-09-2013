<%@ Page Language="C#" AutoEventWireup="true" CodeFile="approvalrequest.aspx.cs" Inherits="admission_approvalrequest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/admission.ascx" tagname="admission" tagprefix="uc1" %>
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
   </head>
<body>
    <form id="form1" runat="server">
    <div>
     <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 100%; height: 144px" align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
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
                                        <uc1:admission ID="admission" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr id="trtag" runat="server">
                                    <td style="width: 230px; height: 20px" align="right">
                                        <table cellpadding="0" cellspacing="0" border="0" width="230">
                                            <tr>
                                                <td colspan="2" style="width: 230px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Refined Search" 
                                                        Font-Bold="False"></asp:Label>
                                                        </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label10" runat="server" CssClass="s_label" 
                                                        Text="Age"></asp:Label>
                                                </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    <asp:DropDownList ID="searchbyage" runat="server" CssClass="s_dropdown" 
                                                        Width="115px" onselectedindexchanged="searchbyage_SelectedIndexChanged" 
                                                        AutoPostBack="True">
                                                     </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" 
                                                        Text="Father Qualification"></asp:Label>
                                                </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    <asp:DropDownList ID="searchbyfatherqualification" runat="server" CssClass="s_dropdown" 
                                                        Width="115px" onselectedindexchanged="searchbyfatherqualification_SelectedIndexChanged" 
                                                        AutoPostBack="True">
                                                     </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Father Occupation"></asp:Label>
                                                </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    <asp:DropDownList ID="searchbyfatheroccupation" runat="server" CssClass="s_dropdown" 
                                                        Width="115px" onselectedindexchanged="searchbyfatheroccupation_SelectedIndexChanged" 
                                                        AutoPostBack="True">
                                                   </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" 
                                                        Text="Mother Qualification"></asp:Label>
                                                </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    <asp:DropDownList ID="searchbymotherqualification" runat="server" CssClass="s_dropdown" 
                                                        Width="115px" onselectedindexchanged="searchbymotherqualification_SelectedIndexChanged" 
                                                        AutoPostBack="True">
                                                     </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label">Mother Occupation</asp:Label>
                                                </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    <asp:DropDownList ID="searchbymotheroccupation" runat="server" CssClass="s_dropdown" 
                                                        Width="115px" onselectedindexchanged="searchbymotheroccupation_SelectedIndexChanged" 
                                                        AutoPostBack="True">
                                                   </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Hostel"></asp:Label>
                                                </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    <asp:DropDownList ID="searchbyhostel" runat="server" CssClass="s_dropdown" 
                                                        Width="115px" onselectedindexchanged="searchbyhostel_SelectedIndexChanged" AutoPostBack="True">                                                         
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                    
                                                    <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Transport"></asp:Label>
                                                    
                                                </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    <asp:DropDownList ID="searchbytransport" runat="server" CssClass="s_dropdown" 
                                                        Width="115px" onselectedindexchanged="searchbytransport_SelectedIndexChanged" AutoPostBack="True">
                                                     </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="trstaff" runat="server">
                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Staff Name"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;</td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    <asp:DropDownList ID="searchbystaffname" runat="server" CssClass="s_dropdown" 
                                                        Width="115px" 
                                                        onselectedindexchanged="searchbystaffname_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="trdepartment" runat="server">
                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Department"></asp:Label>
                                                </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    <asp:DropDownList ID="searchbydepartment" runat="server" CssClass="s_dropdown" 
                                                        Width="115px" 
                                                        onselectedindexchanged="searchbydepartment_SelectedIndexChanged" 
                                                        AutoPostBack="True">                                                                                       
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr id="trdesignation" runat="server">
                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;<asp:Label 
                                                        ID="lbls" runat="server" CssClass="s_label" Text="Designation"></asp:Label></td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    <asp:DropDownList ID="searchbydesignation" runat="server" CssClass="s_dropdown" 
                                                        Width="115px" 
                                                        onselectedindexchanged="searchbydesignation_SelectedIndexChanged" 
                                                        AutoPostBack="True">                                                                                     
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr id="trgroup" runat="server">
                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                    </td>
                                                <td style="width: 115px; height: 30px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                           </table>
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
                                 <tr class="app_container_title">
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="850px">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/76.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td style="width: 330px; height: 50px">
                                                    Shortlist Registrations</td>
                                                   <td style="width:250px; height:50px"; align="left">
                                                        <asp:Label ID="Label3" runat="server" CssClass="title_label" Text="Shortlist Type"></asp:Label>                                                        
                                                   </td>
                                                    <td style="width: 100px" align="center">
                                                       <asp:Label ID="Label7" runat="server" CssClass="title_label" Text="Year"></asp:Label>
                                                       <asp:DropDownList ID="ddlyear" runat="server" Width="105px" AutoPostBack="True" onselectedindexchanged="ddlyear_SelectedIndexChanged">
                                                       </asp:DropDownList>
                                                </td>
                                                    <td style="width: 100px" align="center">
                                                       <asp:Label ID="ddlist" runat="server" CssClass="title_label" Text="Fresh/Waitlisted"></asp:Label>
                                                       <asp:DropDownList ID="ddllist" runat="server" CssClass="s_dropdown" Width="105px" AutoPostBack="True" onselectedindexchanged="ddllist_SelectedIndexChanged">
                                                       <asp:ListItem Value="select">Select</asp:ListItem>
                                                       <asp:ListItem Value="General">Fresh</asp:ListItem>
                                                       <asp:ListItem Value="Waitlisted">Waitlisted</asp:ListItem>
                                                       </asp:DropDownList>
                                                </td>
                                                 <td style="width: 110px" align="center">
                                                    <asp:Label ID="Label" runat="server" CssClass="title_label" Text="Standard"></asp:Label>
                                                    <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" Width="105px" AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 110px" align="center">
                                                    <asp:Label ID="Label9" runat="server" CssClass="title_label" Text="Student"></asp:Label>
                                                    <asp:DropDownList ID="ddlstudent" runat="server" CssClass="s_dropdown" Width="105px" AutoPostBack="True" onselectedindexchanged="ddlstudent_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                               </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>--%>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="900px" >
                                        
                                            <tr id="tredit" runat="server" class="view_detail_title_bg">
                                                <td align="left" style="width:300px; height: 40px">
                                                  </td>
                                                 <td align="left" style="width:50px; height: 40px">
                                               <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="s_button" Width="55px" onclick="btnupdate_Click"  />
                                               </td>
                                                <td align="left" style="width:50px; height: 40px">
                                               <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="s_button" Width="55px" onclick="btncancel_Click"  />
                                               </td>
                                               <td align="left" style="width:50px; height: 40px">
                                               <asp:Button ID="btnedit" runat="server" Text="Edit" CssClass="s_button" Width="41px" onclick="btnedit_Click"  />
                                                  </td>
                                              </tr>
                                             <tr>
                                                 <td colspan="4" align="left" style="width: 850px; height: 5px">
                                                 </td>
                                            </tr>
                                      <tr id="trgrid" runat="server">
                                        <td colspan="4" align="left" class="app_container">
                                           <asp:DataGrid ID="dgadmission" runat="server" AutoGenerateColumns="False" 
                                                Width="900px" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                               CellPadding="3" onupdatecommand="dgadmission_UpdateCommand" 
                                                onitemdatabound="dgadmission_ItemDataBound" >
                                                        <AlternatingItemStyle Font-Size="11px" BackColor="White"/>
                                                        <ItemStyle CssClass="s_datagrid_item"/>
                                                        
                                                        <Columns>
                                                        <asp:BoundColumn DataField="intID" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                       <%-- <asp:TemplateColumn>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkselect" runat="server"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>--%>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>                                                              
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                      <td colspan="8">
                                                                        <table cellpadding="0" cellspacing="0" border="0" >
                                                                          <tr valign="top">                                                                    
                                                                            <td valign="top">                                                                    
                                                                                <table cellpadding="0" cellspacing="0" border="0" width="70">                                                                            
                                                                                    <tr>
                                                                                        <td style=" height: 30px" class="s_gridlabel" align="left">Appl Date</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="font-size:12px; height: 30px" class="s_gridtext" align="left"><%# DataBinder.Eval(Container.DataItem, "date") %></td>
                                                                                    </tr>                                                                                                                                                          
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90px">
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">Appl No</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-size:12px; height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"intid") %></td>
                                                                                </tr>                                                                            
                                                                            </table>
                                                                          </td>
                                                                          <td valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="120px">
                                                                                <tr>
                                                                                    <td style=" height: 30px; font-size" class="s_gridlabel" align="left">Student Name</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-size:12px; height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"name") %></td>
                                                                                </tr>                                                                            
                                                                            </table>
                                                                          </td>
                                                                            <td valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="120px">
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">Father Name</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-size:12px; height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem, "str_fatherorguardianname")%></td>
                                                                                </tr>
                                                                                </tr>                                                                            
                                                                            </table>
                                                                        </td>
                                                                                                                            
                                                                        <td  valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90px">
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">DOB</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-size:12px;height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem, "dateofbirth")%></td>
                                                                                </tr>                                                                            
                                                                             </table>
                                                                        </td>
                                                                        <td  valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90px">
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">Age</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-size:12px; height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"intage") %></td>
                                                                                </tr>                                                                            
                                                                            </table>                                                                        
                                                                        </td>
                                                                         <td  valign="top" >
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90px">
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">Gender</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-size:12px;height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"str_gender") %></td>
                                                                                </tr>                                                                            
                                                                            </table>
                                                                        </td>  
                                                                       
                                                                         <td  valign="top" >
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90px">
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">Applied For</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-size:12px;height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"str_standard") %></td>
                                                                                </tr>                                                                            
                                                                            </table>
                                                                        </td>  
                                                                       </tr>
                                                                    <tr valign="top">
                                                                     <td  valign="top" >
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90px" >
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">Languages</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-size:12px;height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"language") %></td>
                                                                                </tr>                                                                            
                                                                            </table>
                                                                        </td>        
                                                                     <td  valign="top" >
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90px">
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">Qualification</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-size:12px;height:30px" class="s_gridtext" align="left">Father <%#DataBinder.Eval(Container.DataItem,"str_fatherorguardianqualification") %></td>
                                                                                </tr> 
                                                                                <%--<tr>
                                                                                    <td style=" font-size:12px; height: 30px" class="s_gridtext" align="left">Mother <%#DataBinder.Eval(Container.DataItem, "str_motherqualification")%></td>
                                                                                </tr>   --%>                                                                        
                                                                            </table>
                                                                        </td>           
                                                                    <td valign="top">
                                                                    
                                                                        <table cellpadding="0" cellspacing="0" border="0" width="90px">                                                                            
                                                                                    
                                                                                    <tr>
                                                                                        <td style=" height: 30px" class="s_gridlabel" align="left">Occupation</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style=" font-size:12px;height: 30px" class="s_gridtext" align="left">Father <%#DataBinder.Eval(Container.DataItem,"str_fatherorguardianoccupation") %></td>
                                                                                    </tr> 
                                                                                     <%--<td style="font-size:12px; height: 30px" class="s_gridtext" align="left">Mother <%#DataBinder.Eval(Container.DataItem, "str_motheroccupation")%></td>                                                                          --%>
                                                                         </table>
                                                                      </td>
                                                                      <td valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90px">                                                                            
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">Hostel</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="  font-size:12px;height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"str_hostel") %></td>
                                                                                </tr>
                                                                            </table>
                                                                      </td>
                                                                      <td valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90">                                                                           
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">Transport</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-size:12px;height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"str_transport") %></td>
                                                                                </tr>
                                                                             </table>
                                                                      </td>
                                                                      <td style="width:90px; height: 60px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90">                                                                           
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">
                                                                                        <asp:Label ID="lblstaffname" runat="server" Text="Staff Name"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-size:12px;height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"str_staff1") %></td>
                                                                                </tr>
                                                                             </table>
                                                                      </td>
                                                                      <td style="width:90px; height: 60px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90">                                                                           
                                                                                 <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">
                                                                                        <asp:Label ID="lbldepartment" runat="server" Text="Department"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-size:12px;height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"str_department1") %></td>
                                                                                </tr>
                                                                             </table>
                                                                      </td>
                                                                      <td style="width:90px; height: 60px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="90">                                                                           
                                                                                <tr>
                                                                                    <td style=" height: 30px" class="s_gridlabel" align="left">
                                                                                        <asp:Label ID="lbldesignation" runat="server" Text="Designation"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style=" font-size:12px;height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"str_designation1") %></td>
                                                                                </tr>
                                                                             </table>
                                                                      </td>
                                                                     
                                                                    </tr>                                                                                                                                
                                                                 </table>
                                                                </td>                                                                                                                                              
                                                                </tr>                                                                                                                                
                                                                </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                             <asp:TemplateColumn HeaderText="Status">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="status" runat="server" Width="50px" CssClass="s_label"></asp:Label>
                                                                        </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Shortlist" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="shortlist" runat="server" Width="130px" 
                                                                            CssClass="s_dropdown" AutoPostBack="true" >
                                                                              <asp:ListItem Value="Select">-Select-</asp:ListItem>
                                                                              <asp:ListItem Value="Approve">Approve</asp:ListItem>
                                                                              <asp:ListItem Value="Waitlist">Waitlist</asp:ListItem>
                                                                              <asp:ListItem Value="Reject">Reject</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                   </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateColumn>
                                                                 <asp:ButtonColumn CommandName="update" HeaderText="View" Text="&lt;img src=&quot;../media/images/view.png&quot; alt=&quot;&quot; border=&quot;0&quot;/&gt;">
                                                         </asp:ButtonColumn>
                                                      </Columns>                                                
                                                        <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="12px" 
                                                                ForeColor="White" Height="30px" CssClass="s_datagrid_header" />
                                                        </asp:DataGrid>
                                                     </td>
                                                  </tr>
                                      </table>
                                       <tr id="tr1" runat="server">
                                     <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="center">
                                        <asp:Label ID="errormessage" runat="server" CssClass="nodatatodisplay"></asp:Label>
                                    </td>
                                </tr>
                                </td>
                             </tr>
                         </table>
                      </td>
                   </table>
               </td>
            </tr>
            <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top">
                <uc4:footer ID="footer1" runat="server" />
            </td>
        </tr>
     </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
  </div>
 </form>
</body>
</html>



