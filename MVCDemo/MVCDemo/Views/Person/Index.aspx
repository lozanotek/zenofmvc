<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>
        Person List</h3>
    <hr />
    <%
        personGrid.DataSource = ViewData["people"];
        personGrid.DataBind();    
    %>
    <div>
        <%= Html.ActionLink("Create New", "new") %> |
        <%=Html.ActionLink("Show oh noes!", "causeerror") %>
    </div>
    <div>
        <form runat="server">
        <asp:GridView ID="personGrid" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="True" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" ReadOnly="True" />
                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" ReadOnly="True" DataFormatString="{0:d}" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/people/edit/{0}"
                    Text="Edit" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/people/delete/{0}"
                    Text="Delete" />
            </Columns>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        </form>
    </div>
</asp:Content>
