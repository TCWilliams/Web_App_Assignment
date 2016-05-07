<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="nameTextBox" runat="server">name</asp:TextBox>
    <asp:TextBox ID="passwordTextBox" runat="server">password</asp:TextBox>
    <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="log in" />
</asp:Content>

