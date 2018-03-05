<%@ Control Language="C#" AutoEventWireup="true" CodeFile="topmenu.ascx.cs" Inherits="usercontro_topmenu" %>
<link rel="icon" type="image/png" href="Media_front/Images/logo_icon.png">
<table cellpadding="0" cellspacing="0" border="0" align="center" width="1000px">
    <tr>
        <td valign="bottom">
        <object id="FlashID1" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="240" height="24">
		  <param name="movie" value="Media_front/Swf/TS_top_calender.swf" />
		  <param name="quality" value="high" />
		  
		  <param name="type" value="text/html" />
		  <param name="charset" value="iso-8859-1" />
		  <param name="menu" value="false" />  
		  
		  <param name="wmode" value="opaque" />
		  <param name="swfversion" value="6.0.65.0" />
		  <!-- This param tag prompts users with Flash Player 6.0 r65 and higher to download the latest version of Flash Player. Delete it if you don’t want users to see the prompt. -->
		  <!-- Next object tag is for non-IE browsers. So hide it from IE using IECC. -->
		  <!--[if !IE]>-->
		  <object type="application/x-shockwave-flash" data="Media_front/Swf/TS_top_calender.swf" width="240" height="24">
			<!--<![endif]-->
			<param name="quality" value="high" />
			
		  <param name="type" value="text/html" />
		  <param name="charset" value="iso-8859-1" />
		  <param name="menu" value="false" /> 
		  
			
			<param name="wmode" value="opaque" />
			<param name="swfversion" value="6.0.65.0" />
			<!-- The browser displays the following alternative content for users with Flash Player 6.0 and older. -->
			<div>
			  <h4>Content on this page requires a newer version of Adobe Flash Player.</h4>
			  <p><a href="http://www.adobe.com/go/getflashplayer"><img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="Get Adobe Flash player" width="112" height="33" /></a></p>
			</div>
			<!--[if !IE]>-->
		  </object>
		  <!--<![endif]-->
		</object>
        <script type="text/javascript">
            <!--
            swfobject.registerObject("FlashID1");
            //-->
            </script>
        </td>
        <td>
            <table cellpadding="0" cellspacing="0" border="0" align="right">
                <tr>
                    <td>
                        <p align="right" class="menu">
                        <a href="Default.aspx">Home </a> |
                        <a href="aboutus.aspx">About Us </a> |
                        <a href="features.aspx">Features </a> |
                        <a href="Modules.aspx">Modules </a> |
                        <a href="contactus.aspx">Contact Us </a> |
                        <a href="faq.aspx">FAQ </a>
                        </p>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>