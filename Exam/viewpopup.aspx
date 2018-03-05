<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewpopup.aspx.cs" Inherits="Exam_viewpopup" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
     <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />    
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>    
    <script language="javascript" type="text/javascript">
        function openNewWin1(url) {
            var x = window.open(url, 'mynewwin', 'width=800,,toolbar=1,scrollbars=yes');
            x.focus();
        } 
    </script>
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
        td { height: 30px; width: 175px;}
    * {
	color: #666;
}

    </style>
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
                          img.src = "../images/hide.png";
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
                          img.src = "../images/hide.png";
                      }
                      showflag = 1;
                  }
              }
          }
		</script>
   
    
   
</head>
<body >
    <form id="form1" runat="server">
    <div>
       
       <table cellpadding="0" cellspacing="0" style="border:black solid thin;" width="750px">
            <tr>
                <td  style="height:40px">
                    <table cellpadding="0" cellspacing="0" style="border:black solid thin;" width="750px">
                       
                        <tr id="tr3tag" runat="server" visible="false">
                                <td align="center">
                                    <table cellpadding="0" cellspacing="0" border="0" width="750px">
                                        <tr class="view_detail_title_bg">
                                            <td align="left" colspan="6">
                                                <asp:Label ID="lblexamtype" runat="server" CssClass="title_label" Text="lblexamtype"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="Label5" runat="server"  CssClass="s_label" Text="Exam Date :"></asp:Label>
                                            </td>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="lbldate" runat="server" CssClass="s_label" Text="lbldate"></asp:Label>
                                            </td>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="Label7" runat="server"  CssClass="s_label" Text="Subject :"></asp:Label>
                                            </td>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="lblsubject" runat="server"  CssClass="s_label" Text="lblsubject"></asp:Label>
                                            </td>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="Label2" runat="server"  CssClass="s_label" Text="Invigilator :"></asp:Label>
                                            </td>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="lblinvigilator" runat="server"  CssClass="s_label" Text="lblinvigilator"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="Label1" runat="server"  CssClass="s_label" Text="Standard :"></asp:Label>
                                            </td>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="lblstandard" runat="server"  CssClass="s_label" Text="lblstandard"></asp:Label>
                                            </td>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="Label3" runat="server"  CssClass="s_label" Text="Exam Paper :"></asp:Label>
                                            </td>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="lblexampaper" runat="server"  CssClass="s_label" Text="lblexampaper"></asp:Label>
                                            </td>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="Label4" runat="server"  CssClass="s_label" Text="Time :"></asp:Label>
                                            </td>
                                            <td style="width: 90px; height:30px" align="left">
                                                <asp:Label ID="lbltime" runat="server"  CssClass="s_label" Text="lbltime"></asp:Label>
                                            </td>
                                        </tr>
                                        
                                          
                                      </table>
                                      </td>
                                      </tr>    
                                       
                                            <tr id="tr1" runat="server" visible="false">
                                                <td align="center" >
                                                    <table cellpadding="0" cellspacing="0" border="0" width="750px">
                                                        <tr class="view_detail_title_bg">
                                                            <td align="left" colspan="6">
                                                                <asp:Label ID="lblsetportion" runat="server" CssClass="title_label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="6" >
                                                           <asp:Panel ID="Panel1" Width="750px" Height="415px" ScrollBars="Vertical" runat="server" CssClass="curve">
                                                             <asp:datagrid id="dglesson1" runat="server"  AutoGenerateColumns="False" Width="750px">
			                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item"></AlternatingItemStyle>
			                                                    <ItemStyle CssClass="s_datagrid_item"></ItemStyle>
			                                                    <HeaderStyle CssClass="s_datagrid_header"></HeaderStyle>			                                
			                                                    <Columns>
				                                                <asp:TemplateColumn HeaderText="Unit No" HeaderStyle-CssClass="title_label" HeaderStyle-HorizontalAlign="Left">
                    				                            
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
													                                            <td ><img src="../images/hide.png" alt=""></td>
													                                            <td width="10px"><%# DataBinder.Eval(Container, "DataItem.count")%></td>													                    
												                                           </tr>
											                                        </table>
										                                        </ItemTemplate>
									                                            </asp:TemplateColumn>									                        
									                                            <asp:BoundColumn DataField="strlessonName" HeaderStyle-CssClass="title_label" HeaderText="Textbook-Lesson Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ></asp:BoundColumn>
                    									                       
								                                                </Columns>
                    								                           
								                                                </asp:DataGrid>
                    								                            
								                                                <!-- Second DataGrid Ends Here -->
								                                                </div> 
								                                                <!-- Div Ends Here -->
								                                                
						                                                    </ItemTemplate>
                    						                                
					                                                    
					                                                    </asp:TemplateColumn>
                    					                                   
				                                                    </Columns>
				                                                  </asp:datagrid>
				                                                  </asp:Panel>
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
