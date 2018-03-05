<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Viewapproved_rejected_waitlistapproved.aspx.cs" Inherits="admission_Viewapproved_rejected_waitlistapproved" %>
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
                    
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top">
                                <table cellpadding="0" cellspacing="0" border="0" width="230">
                                <tr>
                                    <td style="width: 230px; margin-left: 120px;" align="right">
                                        <uc1:admission ID="admission1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 20px" align="right">
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
                                <tr><td style="height:50px"></td></tr>
                            </table>
                            </td>
                            <td style="width: 2%" valign="top">
                            </td>
                            <td style="width: 93%" valign="top" align="left">
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr class="app_container_title">
                                        <td style="width: 100%; height: 50px" align="left">
                                            <table cellpadding="0" cellspacing="0" border="0" width="950p">
                                                <tr>
                                                     <td class="app_cont_title_img_td"><img src="../images/icons/50X50/76.png" class="app_cont_title_img" alt="icon" /></td>
                                                     <td style="width: 700px; height: 50px">View Approved / Rejected / Waitlisted Approved</td>
                                                               <td style="width: 120px; height: 30px">
                                                                   <asp:Label ID="Label7" runat="server" CssClass="title_label" Text="Shortlist Type:"></asp:Label></td>
                                                                  <td style="width: 350px" align="right" >
                                                                    <asp:Label ID="Label3" runat="server" CssClass="title_label" Text="Approved/Rejected/Waitlisted Approved"></asp:Label>
                                                                    <asp:DropDownList ID="ddllist" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddllist_SelectedIndexChanged">
                                                                     <asp:ListItem Value="Select">Select</asp:ListItem>
                                                                    <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                                                    <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                                                                    <asp:ListItem Value="Waitlisted Approved">Waitlisted Approved</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                          </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    
                                    <%--<tr>
                                        <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                    </tr>--%>
                                   
                                  <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="710" class="app_container">
                                            <tr>
                                                <td style="width:10px; height: 30px" align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                </td>
                                                <td style="width: 50px; height: 30px" align="left">&nbsp;&nbsp;
                                                   <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" 
                                                        AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged" 
                                                        Width="105px"></asp:DropDownList>
                                               </td>
                                               <td style="width:10px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Student"></asp:Label>
                                                </td>
                                               <td style="width:50px; height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:DropDownList ID="ddlstudent" runat="server" CssClass="s_dropdown" Width="105px" AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged"></asp:DropDownList>
                                              </td>
                                            </tr>
                                            <tr>
                                                <td  colspan="4" align="left" style="width: 850px; height: 20px">
                                                </td>
                                            </tr>
                                              <tr>
                                        <td colspan="4" align="left" >
                                           <asp:DataGrid ID="dgadmission" runat="server" AutoGenerateColumns="False" 
                                                Width="850px" BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="3" 
                                                onupdatecommand="dgadmission_UpdateCommand" onitemdatabound="dgadmission_ItemDataBound">
                                                        <AlternatingItemStyle Font-Size="11px" BackColor="White"/>
                                                        <ItemStyle CssClass="s_datagrid_item"/>
                                                        
                                                        <Columns>
                                                        <asp:BoundColumn DataField="intID" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                        <asp:TemplateColumn>
                                                            <ItemTemplate>                                                              
                                                                <table cellpadding="0" cellspacing="0" border="0" >
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
                                                            <asp:ButtonColumn CommandName="update" HeaderText="View" Text="&lt;img src=&quot;../media/images/view.png&quot; alt=&quot;&quot; border=&quot;0&quot;/&gt;">
                                                            </asp:ButtonColumn>
                                                          </Columns>                                                
                                                        <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="12px" 
                                                                ForeColor="White" Height="30px" CssClass="s_datagrid_header" />
                                                        </asp:DataGrid>
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
