<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="MainContent">
    <h3>Create New Person</h3>
    <hr />
    <div><%=Html.ActionLink("<< Return to list", "index") %></div>
    <form action='<%=Url.Action("createnew")%>' method="post">
    <fieldset>
        <table class="center">
            <tr>
                <td><label>First Name:</label></td>
                <td><%=Html.TextBox("firstName") %></td>
            </tr>
            <tr>
                <td><label>Last Name:</label></td>
                <td><%=Html.TextBox("lastName") %></td>
            </tr>
            <tr>
                <td><label>Date of Birth:</label></td>
                <td><%=Html.TextBox("birthDate") %></td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="submit" value="Create New" />
                </td>
            </tr>
        </table>
    </fieldset>
    </form>
</asp:Content>
