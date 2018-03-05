<%@ Control Language="C#" AutoEventWireup="true" CodeFile="banner.ascx.cs" Inherits="usercontro_banner" %>
<table border="0" cellspacing="0" cellpadding="0" width="735" >
	<tr>
		<td>
			<%--<div style="background:url('Media_front/Images/school.jpg');width:735px;height:380px;">
				
			</div>--%>
          <div style="width:735px; height:380px;">
              <object id="FlashID" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="735" height="380">
                <param name="movie" value="Media_front/Swf/theschools_banner.swf" />
                <param name="quality" value="high" />
                <param name="wmode" value="opaque" />
                <param name="swfversion" value="6.0.65.0" />
                <!-- This param tag prompts users with Flash Player 6.0 r65 and higher to download the latest version of Flash Player. Delete it if you don’t want users to see the prompt. -->
                <param name="expressinstall" value="Media_front/Swf/expressInstall.swf" />
                <!-- Next object tag is for non-IE browsers. So hide it from IE using IECC. -->
                <!--[if !IE]>-->
                <object type="application/x-shockwave-flash" data="Media_front/Swf/theschools_banner.swf" width="735" height="380">
                  <!--<![endif]-->
                  <param name="quality" value="high" />
                  <param name="wmode" value="opaque" />
                  <param name="swfversion" value="6.0.65.0" />
                  <param name="expressinstall" value="Media_front/Swf/expressInstall.swf" />
                  <!-- The browser displays the following alternative content for users with Flash Player 6.0 and older. -->
                  <div>
                    <h4>Content on this page requires a newer version of Adobe Flash Player.</h4>
                    <p><a href="http://www.adobe.com/go/getflashplayer"><img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="Get Adobe Flash player" width="112" height="33" /></a></p>
                  </div>
                  <!--[if !IE]>-->
                </object>
                <!--<![endif]-->
              </object>
            </div>
            <script type="text/javascript">
            <!--
            swfobject.registerObject("FlashID");
            //-->
            </script>
		</td>
	</tr>
</table>