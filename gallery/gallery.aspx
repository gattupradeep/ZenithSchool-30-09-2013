<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gallery.aspx.cs" Inherits="gallery_gallery" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Assembly="ASPNetFlashVideo.NET3" Namespace="ASPNetFlashVideo" TagPrefix="ASPNetFlashVideo" %>
<%@ Register src="../usercontrol/gallery.ascx" tagname="gallery" tagprefix="uc1" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Media_front/Css/abtModal.css" />
	<script type="text/javascript" src="../Media_front/Js/abtModal.js"></script>
	<link rel="stylesheet" href="../css/mouseoverpopup.css" type="text/css"/>
    <script src="../js/mouseover_popup.js" language="JavaScript" type="text/javascript"></script>
    <%--<link rel="stylesheet" href="../media/css/lightbox.css" type="text/css" media="screen" />--%>
   <%-- <script type="text/javascript" src="../media/js/slidejs/prototype.js"></script>--%>
    <%--<script type="text/javascript" src="../media/js/slidejs/scriptaculous.js?load=effects"></script>
    <script type="text/javascript" src="../media/js/slidejs/lightbox.js"></script>--%>
    <link rel="stylesheet" type="text/css" href="LightBox/css/jquery.lightbox-0.5.css" media="screen" /> 
    <script type="text/javascript" src="LightBox/js/jquery.js"></script> 
    <script type="text/javascript" src="LightBox/js/jquery.lightbox-0.5.js"></script>
    <script type="text/javascript">        $(function() { $('#gallery a').lightBox({ overlayOpacity: 0.6, imageLoading: 'LightBox/images/lightbox-ico-loading.gif', imageBtnClose: 'LightBox/images/lightbox-btn-close.gif', imageBtnPrev: 'LightBox/images/lightbox-btn-prev.gif', imageBtnNext: 'LightBox/images/lightbox-btn-next.gif', fixedNavigation: true, txtImage: 'Image', txtOf: 'of' }); }); </script>
	
   <script type="text/javascript">
        function showModal(url, w, h) {
            showabtModal('mothersMedicals', w, h);
            document.getElementById('trendsFrame').style.height = h + 'px';
            document.getElementById('trendsFrame').style.width = w + 'px';
            document.getElementById('trendsFrame').src = url;
        }
        function closeModal() {
            document.getElementById('trendsFrame').src = "";
            hideabtModal('mothersMedicals')
            window.parent.location = "gallery.aspx";
        }
    </script>
   </head>
 <body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="mothersMedicals" class="dialog">
        <div style="text-align:center"><span onclick="closeModal();" style="float:right;clear:both;" class="closeModal"></span></div>
        <iframe id="trendsFrame" src="" style="width:960px;height:300px;border:none;" scrolling='no' marginwidth='0' marginheight='0' frameborder='0'>some problem</iframe>
    </div>
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
                    <tr>
                        <td style="width: 5%" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="230">
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc1:gallery ID="gallery1" runat="server" />
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
                                <tr class="app_container_title">
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/312.png"class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Add Gallery</td>
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
                                   <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                            <ProgressTemplate>
                                                <div id="progressBackgroundFilter"></div>
                                                    <div id="processMessage">
                                                        <img alt="Loading" src="../media/images/Processing.gif" />
                                                    </div>
                                            </ProgressTemplate>
                                    </asp:UpdateProgress>
                                   <asp:UpdatePanel ID="updatepanal" runat="server" >
                                         <ContentTemplate>  --%>
                                             <table cellpadding="0" cellspacing="0" border="0" width="700px">
                                            <tr>
                                                <td style="width: 100%" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="700px">
                                                        <tr>
                                                            <td style="width:700px" valign="top" align="left">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="700px">
                                                                    <tr>
                                                                        <td colspan="4" style="width: 700px; height: 40px" align="left">
                                                                            <asp:RadioButton ID="radiophoto" runat="server" Text="Photos" 
                                                                                AutoPostBack="true" CssClass="s_button" 
                                                                                oncheckedchanged="radiophoto_CheckedChanged" />
                                                                            <asp:RadioButton ID="Radiovideo" runat="server" Text="Videos" 
                                                                                AutoPostBack="true" CssClass="s_button" 
                                                                                oncheckedchanged="Radiovideo_CheckedChanged" Visible="false" />
                                                                       </td>     
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Label ID="lblyear" runat="server" Text="Academic Year" CssClass="s_label"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:DropDownList ID="drpacademicyear" runat="server" Height="23px" 
                                                                                Width="160px" AutoPostBack="true" 
                                                                                onselectedindexchanged="drpacademicyear_SelectedIndexChanged" >
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="width: 150px; height: 40px" align="left"></td>
                                                                        <td style="width: 200px; height: 40px" align="left"></td>
                                                                    </tr>
                                                                     <tr id="trtitledrp" runat="server">
                                                                        <td align="left">
                                                                            <asp:Label ID="lbltitle" runat="server" Text="Image Title" CssClass="s_label"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="drptitle" runat="server" Height="23px" Width="160px" AutoPostBack="true" 
                                                                                onselectedindexchanged="drptitle_SelectedIndexChanged">
                                                                            </asp:DropDownList> 
                                                                        </td>
                                                                        <td align="left">
                                                                        <asp:Button ID="btnaddnew" runat="server" CssClass="s_button" Text="Add New" Width="65px" 
                                                                          onclick="btnaddnew_Click"/>
                                                                        </td>
                                                                        <td align="left">
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trtitletxt" runat="server">
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Label ID="lbltitle1" runat="server" Text="Image Title" CssClass="s_label"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:TextBox ID="txttitle" runat="server"  Width="160px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Button ID="btnsave" runat="server" CssClass="s_button" Text="Save" 
                                                                                Width="65px"  onclick="btnsave_Click"/>
                                                                            
                                                                            <asp:Button ID="btncanceladd" Text="Cancel" runat="server" CssClass="s_button" 
                                                                                Width="65px" onclick="btncanceladd_Click"/>
                                                                            
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trtitlelbl" runat="server">
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Label ID="lbltitle2" runat="server" Text="Image Title" CssClass="s_label"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:Label ID="lbltitleview" runat="server" CssClass="s_label"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Button ID="btnedit" runat="server" CssClass="s_button" Text="Edit" 
                                                                                Width="65px" onclick="btnedit_Click"/>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr id="trbrowse" runat="server">
                                                                        <td style="width: 150px; height: 40px" align="left" >
                                                                            <asp:Label ID="lblselectimage" runat="server" Text="Select Image" CssClass="s_label"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="150px">
                                                                                <tr>
                                                                                    <td style="width: 150px; height: 40px" align="left">
                                                                                        <asp:FileUpload ID="UpImage" runat="server" Multiple="true" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            &nbsp;</td>
                                                                        <td style="width: 200px; height: 40px" align="left"></td>
                                                                    </tr>
                                                                    
                                                                     <tr>
                                                                        <td style="width: 150px; height: 40px" align="left"></td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            
                                                                            <asp:Button ID="btnAdd" Text="Upload" runat="server" CssClass="s_button" Width="65px" onclick="btnAdd_Click" />
                                                                            
                                                                            <asp:Button ID="btncancel" Text="Clear" runat="server" CssClass="s_button" 
                                                                                Width="65px" onclick="btncancel_Click"/>
                                                                            
                                                                        </td>
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                           
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left"></td>
                                                                    </tr>
                                                                    
                                                                    <tr>
                                                                        <td colspan="4" style="width: 700px; height: 20px" align="left">
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    <tr id="trgrdmenu" runat="server">
                                                                        <td colspan="4" style="width: 700px; height: 40px" align="left">
                                                                            <asp:Button ID="btnselectall" Text="Select all" runat="server" 
                                                                                CssClass="s_button" onclick="btnselectall_Click" />
                                                                                    
                                                                            <asp:Button ID="btndeselectall" Text="Deselect all" runat="server" 
                                                                                CssClass="s_button" onclick="btndeselectall_Click" />
                                                                        
                                                                            <asp:Button ID="btnpublished" runat="server" Text="Publish Selected" 
                                                                                CssClass="s_button" onclick="btnpublished_Click" />
                                                                      
                                                                            <asp:Button ID="btndeleteall" runat="server" Text="Delete Selected" 
                                                                                CssClass="s_button" onclick="btndeleteall_Click" />
                                                                            
                                                                            <asp:Button ID="btnunpublished" runat="server" Text="Unpublish Selected" 
                                                                                CssClass="s_button" onclick="btnunpublished_Click" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" style="width: 700px; height: 1px"></td>
                                                                    </tr>
                                                                </table>
                                                             </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="width: 100%" valign="top" align="left">
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr>
                                                            <td style="width: 100%" align="left" >
                                                            <div id="gallery">
                                                                <asp:DataGrid ID="grdimagegallery" runat="server" AutoGenerateColumns="false" 
                                                                    ShowHeader="false" ShowFooter="false" Width="100%" 
                                                                    onitemdatabound="grdimagegallery_ItemDataBound">
                                                                    <ItemStyle CssClass="s_datagrid_item"/>
                                                                    <Columns>
                                                                    <asp:BoundColumn DataField="intid" Visible="false"></asp:BoundColumn>
                                                                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                    <tr class="s_datagrid_header">
                                                                                        <td style="width: 25%; height:40px" align="center">
                                                                                            <asp:Label ID="lblrename" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "strgroups")%>'>
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:DataList ID="dlimage" runat="server" RepeatColumns="5" 
                                                                                                CellSpacing="2" CellPadding="2" 
                                                                                                AlternatingItemStyle-HorizontalAlign="Left" 
                                                                                                onitemdatabound="dlimage_ItemDataBound">
                                                                                                <AlternatingItemStyle HorizontalAlign="Left" />
                                                                                                <ItemStyle CssClass="s_datagrid_item" />
                                                                                                <ItemTemplate>
                                                                                                   <table cellpadding="0" cellspacing="0" border="1px" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="width: 100%; height:40px" align="center">
                                                                                                                <table  cellpadding="0" cellspacing="0" border="0" style="width: 100%; height:40px">
                                                                                                                    <tr>
                                                                                                                        <td align="left">
                                                                                                                            <asp:Label ID="lblid" runat="server" Width="20px" Visible="false" CssClass="s_label" Text=' <%# DataBinder.Eval(Container.DataItem, "intid")%>' >
                                                                                                                            </asp:Label>     
                                                                                                                        </td>
                                                                                                                         <td align="right">
                                                                                                                            <asp:ImageButton ID="imageedit" Height="20px" runat="server" 
                                                                                                                                ImageUrl="~/media/images/edit.gif" onclick="imageedit_Click" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td style="width: 80%; height:20px" align="right"> 
                                                                                                                            <asp:TextBox ID="txtname" runat="server" Width="85px" CssClass="s_gridtext" ></asp:TextBox>
                                                                                                                            <asp:Label ID="lblname" runat="server" Multiline="True" Width="100px" CssClass="s_gridlabel" Text='<%#DataBinder.Eval(Container.DataItem,"strname") %>'></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td style="width: 20%; height:20px" align="right" valign="top">
                                                                                                                            <asp:CheckBox ID="checkimage" runat="server" Height="20px" AutoPostBack="true"></asp:CheckBox>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 100%; height:100px; background-color:#000" align="center">
                                                                                                             <div style="display: none; position: absolute; z-index: 110; left: 400; top: 10; width: 10px; height: 100px" id="preview_div"></div> 
                                                                                                                <asp:Label ID="id" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strphotoorvideo")%>' Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strthumbnail")%>' Visible="false"></asp:Label>
                                                                                                                <a id="imageLink" href="" rel="lightbox[Brussels]" runat="server" >
                                                                                                                <img id="Image1" alt="" src="" runat="server" style="width:150px"  /></a>
                                                                                                              
                                                                                                           </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 100%; height:20px" align="center">
                                                                                                                <%--<a href="javascript: void(0)" onclick="showModal('imagepopup.aspx?tagid=<%# DataBinder.Eval(Container.DataItem, "intid")%>&page=gallery.aspx',<%# DataBinder.Eval(Container.DataItem, "intwidth")%>+50,<%# DataBinder.Eval(Container.DataItem, "intheight")%>+150)"> 
                                                                                                                <input type="button" id="tag" value="Tag" runat="server" class="s_grdbutton"/></a>--%>
                                                                                                                <div id="crop" runat="server">
                                                                                                                    <input type="button" id="crop1" value="Crop" class="s_grdbutton" onclick="showModal('imagepopup.aspx?cropid=<%# DataBinder.Eval(Container.DataItem, "intid")%>&page=gallery.aspx',1000,600)" />
                                                                                                                </div>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr id="trdescriptiontxt" runat="server">
                                                                                                            <td style="width: 100%; height:40px" align="center">
                                                                                                                <asp:TextBox ID="txtdescription" Width="110px" runat="server" CssClass="s_gridtext"  TextMode="MultiLine" ></asp:TextBox>
                                                                                                                <asp:Label ID="lbldescription" runat="server" CssClass="s_label" Text='<%#DataBinder.Eval(Container.DataItem,"strdescription") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>

                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:TemplateColumn>
                                                                     </Columns> 
                                                                     <PagerStyle HorizontalAlign="Left" Mode="NumericPages" />  
                                                                </asp:DataGrid>
                                                            </div>
                                                             </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%" align="left" >
                                                                <asp:DataGrid ID="grdvideogallery" runat="server" AutoGenerateColumns="false" 
                                                                    ShowHeader="false" ShowFooter="false" Width="100%" 
                                                                    onitemdatabound="grdimagegallery_ItemDataBound">
                                                                    <ItemStyle CssClass="s_datagrid_item"/>
                                                                    <Columns>
                                                                    <asp:BoundColumn DataField="intid" Visible="false"></asp:BoundColumn>
                                                                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                    <tr class="s_datagrid_header">
                                                                                        <td style="width: 25%; height:40px" align="center">
                                                                                            <asp:Label ID="lblrename" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "strgroups")%>'>
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:DataList ID="dlimage" runat="server" RepeatColumns="5" Width="20%"  
                                                                                                CellSpacing="2" CellPadding="2" 
                                                                                                AlternatingItemStyle-HorizontalAlign="Left" 
                                                                                                onitemdatabound="dlimage_ItemDataBound">
                                                                                                <AlternatingItemStyle HorizontalAlign="Left" />
                                                                                                <ItemStyle CssClass="s_datagrid_item" />
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="1px" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="width: 100px" align="left">
                                                                                                                <table  cellpadding="0" cellspacing="0" border="0" style="width: 100%; height:40px">
                                                                                                                    <tr>
                                                                                                                        <td style="width: 70%; height:20px" align="left">
                                                                                                                            <asp:Label ID="lblid" Width="100px" runat="server" Visible="false" CssClass="s_label" Text=' <%# DataBinder.Eval(Container.DataItem, "intid")%>' >
                                                                                                                            </asp:Label>     
                                                                                                                        </td>
                                                                                                                         <td style="width: 30%; height:20px" align="right">
                                                                                                                            <asp:ImageButton ID="imageedit" Height="16px" runat="server" 
                                                                                                                                ImageUrl="~/media/images/edit.gif" onclick="imageedit_Click"  />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td style="width: 80%; height:20px" align="right"> 
                                                                                                                            <asp:TextBox ID="txtname" runat="server" Width="80px" CssClass="s_gridtext"></asp:TextBox>
                                                                                                                            <asp:Label ID="lblname" runat="server" Multiline="True" Width="100px" CssClass="s_gridlabel" Text='<%#DataBinder.Eval(Container.DataItem,"strname") %>'></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td style="width: 20%; height:20px" align="right" valign="top">
                                                                                                                            <asp:CheckBox ID="checkimage" runat="server" AutoPostBack="true"></asp:CheckBox>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 100%; height:100px; background-color:#000" align="center">
                                                                                                                <asp:Label ID="lblvideoname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strphotoorvideo")%>'></asp:Label>
                                                                                                                <ASPNetFlashVideo:FlashVideo ID="FlashVideo1" runat="server" AutoPlay="false" AllowFullScreen="true" Width="250px" Height="200px">
                                                                                                                    <htmlalternativetemplate>
                                                                                                                        <asp:ImageButton ID="ImageButtonGetFlashPlayer" runat="server" PostBackUrl="http://www.adobe.com/go/getflashplayer" ImageUrl="http://www.aspnetflashvideo.com/images/get_flash_player.gif" />
                                                                                                                    </htmlalternativetemplate>
                                                                                                                </ASPNetFlashVideo:FlashVideo>                                                                                                                
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr id="trdescriptiontxt" runat="server">
                                                                                                            <td style="width: 100%; height:40px">
                                                                                                                <asp:TextBox ID="txtdescription" runat="server" CssClass="s_gridtext"  TextMode="MultiLine" ></asp:TextBox>
                                                                                                                <asp:Label ID="lbldescription" runat="server" CssClass="s_label" Text='<%#DataBinder.Eval(Container.DataItem,"strdescription") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:DataList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>   
                                                                </asp:DataGrid>
                                                             </td>
                                                        </tr>
                                                    </table>
                                                 </td>
                                            </tr>
                                       </table>
                                        <%--</ContentTemplate>
                                     </asp:UpdatePanel>--%>
                                    </td>   
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
</form>
</body>
</html>
