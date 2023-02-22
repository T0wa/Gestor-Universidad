<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Vistas.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Session["error"] != null) { %>
        <h2 style="text-align:center;color:black">Ocurrio un Error</h2>
        <%string s =  Session["error"].ToString();%>
        <h4 style="text-align:center;color:indianred"><%=s%></h4>
    <%} %>

</asp:Content>
