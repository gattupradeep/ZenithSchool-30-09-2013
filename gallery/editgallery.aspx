﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editgallery.aspx.cs" Inherits="gallery_editgallegy" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Assembly="ASPNetFlashVideo.NET3" Namespace="ASPNetFlashVideo" TagPrefix="ASPNetFlashVideo" %>
<%@ Register src="../usercontrol/gallery.ascx" tagname="gallery" tagprefix="uc1" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Media_front/Css/abtModal.css" />
	<script type="text/javascript" src="../Media_front/Js/abtModal.js"></script>
	<link rel="stylesheet" href="../css/mouseoverpopup.css" type="text/css"/>
    <script src="../js/mouseover_popup.js" language="JavaScript" type="text/javascript"></script>	
    
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
            window.parent.location = "editgallery.aspx";
        }
    </script>
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="mothersMedicals" class="dialog">
        <div style="text-align:center"><span onclick="closeModal();" style="float:right;clear:both;" class="closeModal"></span></div>
        <iframe id="trendsFrame" src="" style="width:960px;height:300px;border:none;" scrolling='yes' marginwidth='0' marginheight='0' frameborder='0'>some problem</iframe>
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
                                               <td class="app_cont_title_img_td"><img src="../images/icons/50X50/312.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">
                                                    Edit | Delete Gallery
                                                </td>
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
                                     <%-- <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                <ProgressTemplate>
                                                    <div id="progressBackgroundFilter"></div>
                                                        <div id="processMessage">
                                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                                        </div>
                                                </ProgressTemplate>
                                         </asp:UpdateProgress>--%>
                                        <asp:UpdatePanel ID="updatepanal" runat="server" >
                                            <ContentTemplate>
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
                                                                                AutoPostBack="true" CssClass="s_button" Visible="false" 
                                                                                oncheckedchanged="Radiovideo_CheckedChanged" />
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
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Label ID="lbltitle" runat="server" Text="Image Title" CssClass="s_label"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:DropDownList ID="drptitle" runat="server" Height="23px" Width="160px" AutoPostBack="true" 
                                                                                onselectedindexchanged="drptitle_SelectedIndexChanged">
                                                                            </asp:DropDownList> 
                                                                        </td>
                                                                    </tr>
                                                                     <tr id="trtitledrp" runat="server">
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Label ID="lblpublishstatus" runat="server" Text="Publish Status" CssClass="s_label"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 550px; height: 40px" align="left">
                                                                            <asp:DropDownList ID="drpstatus" runat="server" Height="23px" Width="160px" 
                                                                                AutoPostBack="true" onselectedindexchanged="drpstatus_SelectedIndexChanged">
                                                                                <asp:ListItem Value="0" Text="">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="1" Text="">Published</asp:ListItem>
                                                                                <asp:ListItem Value="2" Text="">Unpublished</asp:ListItem>
                                                                            </asp:DropDownList> 
                                                                        </td>
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
                                                                    </table>
                                                             </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" valign="top" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
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
                                                                                            <td style="width: 100%" align="left">
                                                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                                    <tr>
                                                                                                        <td style="width: 50%; height:40px" align="right">
                                                                                                            <asp:Label ID="lblrename" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "strgroups")%>'>
                                                                                                            </asp:Label>
                                                                                                            <asp:TextBox ID="txtrename" runat="server" CssClass="s_gridtext" 
                                                                                                             Visible="false"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td colspan="3" style="width: 40%; height:40px" align="right">
                                                                                                            <asp:Button ID="btnrename" runat="server" CssClass="s_grdbutton" Text="Rename" 
                                                                                                            onclick="btnrename_Click" />
                                                                                                            <asp:Button ID="btncancel" runat="server" CssClass="s_grdbutton"
                                                                                                            onclick="btncancel_Click1" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?')"  />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="4">
                                                                                                <asp:DataList ID="dlimage" runat="server" RepeatColumns="5" 
                                                                                                    CellSpacing="2" CellPadding="2" 
                                                                                                    AlternatingItemStyle-HorizontalAlign="Left" 
                                                                                                    onitemdatabound="dlimage_ItemDataBound">
                                                                                                    <AlternatingItemStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle CssClass="s_datagrid_item" />
                                                                                                    <ItemTemplate>
                                                                                                        <table cellpadding="0" cellspacing="0" border="1px" style="width: 100%">
                                                                                                            <tr>
                                                                                                                <td style="width: 100px" align="left">
                                                                                                                    <table  cellpadding="0" cellspacing="0" border="0" style="width: 100px">
                                                                                                                        <tr>
                                                                                                                            <td style="width: 50px; height:20px" align="left">
                                                                                                                                <asp:Label ID="lblid" runat="server" Width="40px" Visible="false" CssClass="s_label" Text=' <%# DataBinder.Eval(Container.DataItem, "intid")%>' >
                                                                                                                                </asp:Label>     
                                                                                                                            </td>
                                                                                                                             <td style="width: 25px; height:20px" align="left">
                                                                                                                                <asp:ImageButton ID="imageedit" Width="15px" Height="16px" runat="server" 
                                                                                                                                    ImageUrl="~/media/images/edit.gif" onclick="imageedit_Click" />
                                                                                                                            </td>
                                                                                                                            <td style="width: 25px; height:20px" align="left">
                                                                                                                                   <asp:ImageButton ID="ImageButton1" Width="15px" Height="16px" runat="server" 
                                                                                                                                    ImageUrl="~/media/images/delete.gif" onclick="ImageButton1_Click" OnClientClick="return confirm('Are you sure you want to delete this record?')"/>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td style="width: 70px; height:40px" align="center"> 
                                                                                                                                <asp:TextBox ID="txtname" runat="server" Width="100px" CssClass="s_gridtext"></asp:TextBox>
                                                                                                                                <asp:Label ID="lblname" runat="server" Multiline="True" Width="100px" CssClass="s_gridlabel" Text='<%#DataBinder.Eval(Container.DataItem,"strname") %>'></asp:Label>
                                                                                                                            </td>
                                                                                                                            <td colspan="2" style="width: 30px" align="left">
                                                                                                                                <asp:CheckBox ID="checkimage" Width="20px"  runat="server" AutoPostBack="true"></asp:CheckBox>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="center" valign="middle" style="width:100px; height:100px; background-color:#000">
                                                                                                                    <div style="display: none; position: absolute; z-index: 110; left: 400; top: 100; width: 15; height: 15" id="preview_div"></div>
                                                                                                                     <asp:Label ID="id" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strphotoorvideo")%>' Visible="false"></asp:Label>
                                                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strthumbnail")%>' Visible="false"></asp:Label>
                                                                                                                    <a id="imageLink" rel="lightbox[Brussels]" runat="server" >
                                                                                                                    <img id="Image1" alt="" src="" runat="server" style="width:150px" /></a>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px; height:20px" align="center">
                                                                                                                    <%--<a href="javascript: void(0)" onclick="showModal('imagepopup.aspx?tagid=<%# DataBinder.Eval(Container.DataItem, "intid")%>&page=editgallery.aspx',<%# DataBinder.Eval(Container.DataItem, "intwidth")%>+50,<%# DataBinder.Eval(Container.DataItem, "intheight")%>+150)"> 
                                                                                                                    <input type="button" id="tag" value="Tag" class="s_grdbutton"  /></a>--%>
                                                                                                                    <%--<a href="javascript: void(0)" > --%>
                                                                                                                    <input type="button" id="crop" value="Crop" class="s_grdbutton" onclick="showModal('imagepopup.aspx?cropid=<%# DataBinder.Eval(Container.DataItem, "intid")%>&page=editgallery.aspx',1000,600)" /><%--</a>--%>
                                                                                                                    <%--<a href="javascript: void(0)" > --%>
                                                                                                                    <input type="button" id="change" value="Change" class="s_grdbutton" onclick="showModal('imagepopup.aspx?changeid=<%# DataBinder.Eval(Container.DataItem, "intid")%>&page=editgallery.aspx',1000,600)" /><%--</a>--%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr id="trdescriptiontxt" runat="server">
                                                                                                                <td style="width: 100px; height:40px">
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
                                                                                        <td style="width: 100%" align="left">
                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                                <tr>
                                                                                                    <td style="width: 60%; height:40px" align="right">
                                                                                                        <asp:Label ID="lblrename" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "strgroups")%>'>
                                                                                                        </asp:Label>
                                                                                                        <asp:TextBox ID="txtrename" runat="server" CssClass="s_gridtext" 
                                                                                                         Visible="false"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td colspan="3" style="width: 40%; height:40px" align="right">
                                                                                                        <asp:Button ID="btnrename" runat="server" CssClass="s_grdbutton" Text="Rename" 
                                                                                                        onclick="btnrename_Click" />
                                                                                                        <asp:Button ID="btncancel" runat="server" CssClass="s_grdbutton"
                                                                                                        onclick="btncancel_Click1" Text="Delete"  />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="4">
                                                                                            <asp:DataList ID="dlimage" runat="server" RepeatColumns="5" 
                                                                                                CellSpacing="2" CellPadding="2" 
                                                                                                AlternatingItemStyle-HorizontalAlign="Left" 
                                                                                                onitemdatabound="dlimage_ItemDataBound">
                                                                                                <AlternatingItemStyle HorizontalAlign="Left" />
                                                                                                <ItemStyle CssClass="s_datagrid_item" />
                                                                                                <ItemTemplate>
                                                                                                    <table cellpadding="0" cellspacing="0" border="1px" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td style="width: 100px" align="left">
                                                                                                                <table  cellpadding="0" cellspacing="0" border="0" style="width: 100px; height:40px">
                                                                                                                    <tr>
                                                                                                                        <td style="width: 50px; height:20px" align="left">
                                                                                                                            <asp:Label ID="lblid" runat="server" Width="40px" Visible="false" CssClass="s_label" Text=' <%# DataBinder.Eval(Container.DataItem, "intid")%>' >
                                                                                                                            </asp:Label>     
                                                                                                                        </td>
                                                                                                                         <td align="right">
                                                                                                                            <asp:ImageButton ID="imageedit" Width="15px" Height="16px" runat="server" 
                                                                                                                                ImageUrl="~/media/images/edit.gif" onclick="imageedit_Click" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td style="width: 80px; height:20px" align="right"> 
                                                                                                                            <asp:TextBox ID="txtname" runat="server" Width="100px" CssClass="s_gridtext"></asp:TextBox>
                                                                                                                            <asp:Label ID="lblname" runat="server" Multiline="True" Width="100px" CssClass="s_gridlabel" Text='<%#DataBinder.Eval(Container.DataItem,"strname") %>'></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td style="width: 20px; height:20px" align="right" valign="top">
                                                                                                                            <asp:CheckBox ID="checkimage" Width="20px"  runat="server" AutoPostBack="true"></asp:CheckBox>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 100px; height:100px; background-color:#000" align="center">
                                                                                                                <asp:Label ID="lblvideoname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "strphotoorvideo")%>' Visible="true"></asp:Label>
                                                                                                                <ASPNetFlashVideo:FlashVideo ID="FlashVideo1" runat="server" AutoPlay="false" Width="250px" Height="200px">
                                                                                                                    <htmlalternativetemplate>
                                                                                                                        <asp:ImageButton ID="ImageButtonGetFlashPlayer" runat="server" PostBackUrl="http://www.adobe.com/go/getflashplayer" ImageUrl="http://www.aspnetflashvideo.com/images/get_flash_player.gif" />
                                                                                                                    </htmlalternativetemplate>
                                                                                                                </ASPNetFlashVideo:FlashVideo>                                                                                                                
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr id="trdescriptiontxt" runat="server">
                                                                                                            <td style="width: 100px; height:40px">
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
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
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
