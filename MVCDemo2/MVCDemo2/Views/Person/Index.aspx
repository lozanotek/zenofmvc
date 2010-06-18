<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="../../Scripts/grid.js"></script>

    <h3>
        Person List</h3>
    <hr />
    <div>
        <%= Html.ActionLink("Create New", "new") %>
        |
        <%=Html.ActionLink("Show oh noes!", "causeerror") %>
    </div>
    <table id="list1">
    </table>
    <div id="pager1">
    </div>
</asp:Content>
