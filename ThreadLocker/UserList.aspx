<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="ThreadLocker.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p style="margin-top:10pt;text-align:center;">
        <asp:TextBox ID="txtSearch" runat="server" />
    <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
        </p>
    <p style="text-align:center;">
    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false"  Width="1075px">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
        </Columns>
    </asp:GridView>
        </p>
</asp:Content>
