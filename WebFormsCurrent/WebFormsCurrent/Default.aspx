<%@ page language="C#" autoeventwireup="true" codebehind="Default.aspx.cs" inherits="WebFormsCurrent._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Forms - Current Methods</title>
</head>
<body>
    <form id="form1" runat="server">
    <!-- This technically should be the "view" -->
    <div>
        <h3>
            Person List</h3>
        <asp:gridview runat="server" id="personGridView" />
    </div>
    </form>
</body>
</html>
