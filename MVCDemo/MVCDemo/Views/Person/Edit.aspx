<%@ page title="" language="C#" masterpagefile="~/Views/Shared/Site.Master" autoeventwireup="true"
    inherits="System.Web.Mvc.ViewPage" %>

<%@ import namespace="Services" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
    <h3>
        Edit Person Info</h3>
    <hr />
    <div id="menu">
        <ul>
            <li>
                <%=Html.ActionLink("<< Return to list", "index") %></li>
        </ul>
    </div>
    <%
        var person = ViewData["person"] as PersonData; %>
    <form action='<%=Url.Action("update")%>' method="post">
    <%= Html.Hidden("id", person.Id) %>
    <p>
        <label>
            First Name:
            <%=Html.TextBox("firstName", person.FirstName) %>
        </label>
    </p>
    <p>
        <label>
            Last Name:
            <%=Html.TextBox("lastName", person.LastName) %></label>
    </p>
    <p>
        <label>
            Date of Birth:
            <%=Html.TextBox("birthDate", person.BirthDate.ToShortDateString()) %></label>
    </p>
    <p>
        <input type="submit" value="Update" />
    </p>
    </form>
</asp:content>
