<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="notallowed.aspx.cs" Inherits="PEGS.notallowed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <h1>YOU ARE NOT ALLOWED TO GO IN THERE </h1>
        <%=towrite %>
    </div>
</asp:Content>
