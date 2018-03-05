<%@ Control Language="C#" AutoEventWireup="true" CodeFile="right_resources.ascx.cs" Inherits="usercontro_right_resources" %>
<table border="0" cellspacing="0" cellpadding="0" width="240px" style="margin-left:10px;">
	<tr>
		<td>
			<table style="padding: 0pt;" cellspacing="0">
				<tbody>
					<tr>
						<td>
						    <table style="width: 249px;" cellspacing="0">
							    <tbody>
								    <tr>
									    <td><img alt="" src="Media_front/Images/border.jpg" /></td>
								    </tr>
								    <tr>
									    <td><img alt="redarrow" style="float: right; width: 6px; height: 6px;" src="Media_front/Images/news_events_arrow.jpg" /></td>
								    </tr>
								    <tr>
								        <td>
								            <table cellpadding="0" cellspacing="0" border="0">
								                <tr>
								                    <td valign="top">
								                        <div class="resources_img"><a href="#"><img alt="News and Events" title="News and Events"  src="Media_front/Images/News_and_Events.jpg" /></a></div>
								                    </td>
								                    <td>
								                        <div class="resources_t"><a class="resource2" href="#"><span>News and Events</span></a>
								                        <p class="resources_p" style="font-size:13px;height:70px;"><asp:Panel><marquee height="100%" loop="infinite" scrollamount="2" align="middle" direction="up" onmouseout="this.start();"
onmouseover="this.stop();"> Welcome to theschools.in official website.<br /> Register now and avail fully functional ERP Package free for three months.</marquee></asp:Panel></p></div>
                                                    </td>
								                </tr>
								            </table>
								        </td>
								    </tr>
							    </tbody>
						    </table>
						</td>
					</tr>
					<tr>
						<td>
						    <table style="width: 249px;" cellspacing="0">
							    <tbody>
								    <tr>
									    <td><img alt="" src="Media_front/Images/border.jpg" /></td>
								    </tr>
								    <tr>
									    <td><img alt="redarrow" style="float: right; width: 6px; height: 6px;" src="Media_front/Images/thought_for_day_arrow.jpg" /></td>
								    </tr>
								    <tr>
								        <td>
								            <table cellpadding="0" cellspacing="0" border="0">
								                <tr>
								                    <td valign="top">
								                        <div class="resources_img"><img alt="Thought for the day" title="Thought for the day" src="Media_front/Images/Thought_for_the_day.jpg" title="OnDemand Comparison Chart" /></div>
								                    </td>
								                    <td>
								                        <div class="resources_t"><a class="resource3" href="#"><span>Thought for the day</span></a>
						                                <p class="resources_p">"You may never know what results come of your action"</p></div>
								                    </td>
								                </tr>
								            </table>
								        </td>
								    </tr>
							    </tbody>
						    </table>
						</td>
					</tr>
					<tr>
						<td>
						    <table style="width: 249px;" cellspacing="0">
							    <tbody>
								    <tr>
						                <td>
						                    <table style="width: 249px;" cellspacing="0">
							                    <tbody>
								                    <tr>
									                    <td><img alt="" src="Media_front/Images/border.jpg" /></td>
								                    </tr>
								                    <tr>
									                    <td><img alt="redarrow" style="float: right; width: 6px; height: 6px;" src="Media_front/Images/Registration_arrow.jpg" /></td>
								                    </tr>
								                    <tr>
								                        <td>
								                            <table cellpadding="0" cellspacing="0" border="0">
								                                <tr>
								                                    <td valign="top">
								                                        <div class="resources_img"><img alt="Registred Schools Login" title="Registred Schools Login" src="Media_front/Images/login.jpg" /></div>
								                                    </td>
								                                    <td>
								                                        <table cellpadding="0" cellspacing="0" border="0">
											                            <tr>
											                                <td class="resources_t" valign="top">
											                                    <a class="resource1" href="#"><span >Registred Schools Login</span></a>
											                                </td>
											                            </tr>
											                            <tr style="height:23px">
											                                <td class="s_label">Country</td>
											                            </tr>
											                            <tr style="height:23px">
											                                <td class="s_label">
                                                                                <asp:DropDownList ID="ddlcountry" runat="server" CssClass="s_dropdown" 
                                                                                    Width="160px" onselectedindexchanged="ddlcountry_SelectedIndexChanged" 
                                                                                    AutoPostBack="True">
                                                                                </asp:DropDownList>
                                                                            </td>
											                            </tr>
											                            <tr style="height:23px">
											                                <td class="s_label">State</td>
											                            </tr>
											                            <tr style="height:23px">
											                                <td class="s_label">
                                                                                <asp:DropDownList ID="ddlstate" runat="server" CssClass="s_dropdown" 
                                                                                    Width="160px" onselectedindexchanged="ddlstate_SelectedIndexChanged" 
                                                                                    AutoPostBack="True">
                                                                                </asp:DropDownList>
                                                                            </td>
											                            </tr>
											                            <tr style="height:23px">
											                                <td class="s_label">School Name</td>
											                            </tr>
											                            <tr>
											                                <td class="s_label">
                                                                                <asp:DropDownList ID="ddlschool" runat="server" CssClass="s_dropdown" 
                                                                                    Width="160px">
                                                                                </asp:DropDownList>
                                                                            </td>
											                            </tr>
											                            <tr>
											                                <td class="s_label" style="height:30px;" align="right">
											                                <div style="margin-right:10px;">
                                                                                <asp:ImageButton ID="btngo" runat="server" ImageUrl="../Media_front/Images/Go-button.jpg"
                                                                                    onclick="btngo_Click" />
                                                                                    </div>
                                                                            </td>
											                            </tr>
											                        </table>
								                                    </td>
								                                </tr>
								                            </table>
								                         </td>
								                    </tr>
							                    </tbody>
						                    </table>
						                </td>
					                </tr>
								</tbody>
						    </table>
						</td>
					</tr>
				</tbody>
			</table>
		</td>
	</tr>
</table>
