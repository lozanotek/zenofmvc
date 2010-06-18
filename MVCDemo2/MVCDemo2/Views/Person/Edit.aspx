<%@ page title="" language="C#" masterpagefile="~/Views/Shared/Site.Master" autoeventwireup="true"
    inherits="System.Web.Mvc.ViewPage" %>

<%@ import namespace="Services" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
    <h3>Edit Person Info</h3>
    <hr />
    <%var person = ViewData["person"] as PersonData; %>
    <div>
        <%=Html.ActionLink("<< Return to list", "index") %>
    </div>
    <form action='<%=Url.Action("update")%>' method="post">
     <%= Html.Hidden("id", person.Id) %>
        <fieldset>
            <table class="center">
                <tr>
                    <td><label>First Name:</label></td>
                    <td><%=Html.TextBox("firstName", person.FirstName) %></td>
                </tr>
                <tr>
                    <td><label>Last Name:</label></td>
                    <td><%=Html.TextBox("lastName", person.LastName) %></td>
                </tr>
                <tr>
                    <td><label>Date of Birth:</label></td>
                    <td>
                        <%=Html.TextBox("birthDate", person.BirthDate.ToShortDateString()) %>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="submit" value="Update" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </form>
</asp:content>
