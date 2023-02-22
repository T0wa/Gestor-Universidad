<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestion de Practica Profesional</h1>

    <div class="container">

        <h4><strong>Login</strong></h4>

        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
        <br />
        <asp:TextBox ID="txtbx_user" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
        <br />
        <asp:TextBox ID="txtbx_pass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" OnClick="Button1_Click" Text="Ingresar" />
    </div>
</asp:Content>
