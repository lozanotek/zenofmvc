<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsCurrent._Default"
    MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="defaultContent" runat="server">
    <div>
        <h3>
            Person List</h3>
        <hr />
        <div>
            <a href="people/createnew.aspx">Create New</a>
        </div>
        <asp:GridView ID="personGridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="True" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" ReadOnly="True" />
                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" ReadOnly="True" DataFormatString="{0:d}" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/people/edit.aspx?personId={0}"
                    Text="Edit" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/people/delete.aspx?personId={0}"
                    Text="Delete" />
            </Columns>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
</asp:Content>
