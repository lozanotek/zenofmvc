<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebFormsCurrent.Edit"
    MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="defaultContent" runat="server">
    <h3>
        Edit Person Info</h3>
    <hr />
    <div>
        <a href="/"><< Return to list</a>
    </div>
    <p><asp:HiddenField ID="personId" runat="server" /></p>
    <fieldset>
        <table class="center">
            <tr>
                <td>
                    <label>
                        First Name:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="firstName" />
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        Last Name:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="lastName" />
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        Date of Birth:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="birthDate" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" Text="Update" ID="UpdateButton" OnClick="UpdateButton_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
