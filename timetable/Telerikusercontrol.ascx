<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Telerikusercontrol.ascx.cs" Inherits="Telerikusercontrol" %>
<table runat="server" style="width: 100%" id="ProductWrapper" border="0" cellpadding="2"
    cellspacing="0">
    <tr>
        <td style="text-align: center;">
<asp:FormView ID="ProductsView" DataSourceID="ProductDataSource" DataKeyNames="intid"
runat="server" OnDataBound="ProductsView_DataBound">
                <ItemTemplate>
                    <asp:Label CssClass="title" ID="Category" runat="server"><%# Eval("strfoodname")%></asp:Label>
                    <hr />
                    <asp:Image ID="image" Width="200" Height="200" runat="server" ImageUrl='<%# Eval("intid", "images/{0}.jpg") %>' />
                    <br />
                    <span class='title'>CurryName:</span>
                    <asp:Label CssClass="info" ID="Label1" runat="server"><%# Eval("strcurryname")%></asp:Label>
                    <br />
                    <span class='title'>Day:</span>
                    <asp:Label CssClass="info" ID="Label2" runat="server"><%# Eval("strday")%></asp:Label>
                    <br />
                   
                </ItemTemplate>
            </asp:FormView>
        </td>
    </tr>
</table>
<asp:SqlDataSource ID="ProductDataSource" runat="server" ConnectionString="<%$ AppSettings:conn %>"
    ProviderName="System.Data.SqlClient" SelectCommand="select * from tblmenutimetable where intid =@intid">
    <SelectParameters>
        <asp:Parameter Name="intid" Type="Int32" />
    </SelectParameters>
    </asp:SqlDataSource>