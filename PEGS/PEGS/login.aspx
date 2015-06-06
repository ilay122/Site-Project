<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PEGS.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <form action="" id="login" method="post">
            ID number <input type="text" name="idNum" id="idNum" autocomplete="off" /><br />
            Password &nbsp <input type="password" name="password" id="password"  autocomplete="off" /> <br />
            <input type="submit" value="Submit" name="submit"class="tfbutton" />

        </form>
        <%=errors %>

    </div>
</asp:Content>
