<%@ page language="C#" autoeventwireup="true" inherits="System.Web.Mvc.ViewPage"
    masterpagefile="~/Views/Shared/Site.Master" %>

<asp:content runat="server" id="content" contentplaceholderid="MainContent">
<h3>
        Create New Person</h3>
    <hr />
    <div>
        <p><%=Html.ActionLink("<< Return to list", "index")%></p>
        <form id="personForm" method="post" action='<%=Url.Action("createnew")%>'>
            <fieldset>
                <p>
                    <label>First Name: <%=Html.TextBox("firstName")%></label>
                </p>
                <p>
                    <label>Last Name: <%=Html.TextBox("lastName")%></label>
                </p>
                <p>
                    <label>Birth Date: <%=Html.TextBox("birthDate", DateTime.Now.ToShortDateString())%></label>
                </p>
                <p>
                    <input type="submit" value="Create New" />
                </p>
            </fieldset>
        </form>
    </div>
</asp:content>
