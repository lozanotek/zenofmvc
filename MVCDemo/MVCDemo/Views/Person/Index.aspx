<%@ page language="C#" masterpagefile="~/Views/Shared/Site.Master" autoeventwireup="true"
    inherits="System.Web.Mvc.ViewPage" %>

<%@ import namespace="MVCDemo.Controllers" %>
<%@ import namespace="Model" %>
<asp:content id="indexContent" 
contentplaceholderid="MainContent" runat="server">
    <h3>
        Person List</h3>
    <hr />
    <%
        personGrid.DataSource = ViewData["people"];
        personGrid.DataBind();    
    %>
    <div id="menu">
        <ul>
            <li><a href='<%=Url.Action("index") %>'>Home</a></li>
            <li><%= Html.ActionLink("Create New", "new") %></li>
            <li><%=Html.ActionLink("Show oh noes!", "causeerror") %></li>
        </ul>
    </div>
    <div>
         <form runat="server">
            <asp:gridview id="personGrid" runat="server" autogeneratecolumns="False" cellpadding="4"
                forecolor="#333333" gridlines="None">
                <footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
                <columns>
                
                    <asp:boundfield datafield="FirstName" headertext="First Name" readonly="True" />
                    <asp:boundfield datafield="LastName" headertext="LastName" readonly="True"/>
                    <asp:boundfield datafield="BirthDate" headertext="BirthDate" readonly="True" 
                        dataformatstring="{0:d}"/>
                    <asp:hyperlinkfield datanavigateurlfields="Id" 
                        datanavigateurlformatstring="/people/edit/{0}" text="Edit" />
                    <asp:hyperlinkfield datanavigateurlfields="Id" 
                        datanavigateurlformatstring="/people/delete/{0}" text="Delete" />
                </columns>
                <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
            </asp:gridview>
        </form>
    </div>
</asp:content>
