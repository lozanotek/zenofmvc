<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" inherits="System.Web.Mvc.ViewPage"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div>
<p><%=Html.ActionLink("<< Return to list...", "index") %></p>
<img src="../../Content/oh_noes.jpg" border="0" />

<p>See the exception details below </p>

<%
    var errorInfo = ViewData.Model as HandleErrorInfo;
    if (errorInfo != null)
    {
%>
        <p>Controller: <strong><%=errorInfo.ControllerName %></strong><br />
        Action: <strong><%=errorInfo.ActionName%></strong><br />
        Exception Type: <strong><%=errorInfo.Exception.GetType().Name %></strong><br />
        <p>Stack Trace: <strong><%=Html.Encode(errorInfo.Exception.StackTrace) %></strong></p>
<%  } %>
</div>
</asp:Content>
