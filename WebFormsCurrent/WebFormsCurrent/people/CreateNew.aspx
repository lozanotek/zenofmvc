<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateNew.aspx.cs" Inherits="WebFormsCurrent.CreateNew" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="newContent">
 <h3>
        Create New Person</h3>
    <hr />
    <div>
        <a href="/"><< Return to list</a>
    </div>
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
                    <asp:Button runat="server" Text="Create New" ID="CreateButton" OnClick="CreateButton_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>