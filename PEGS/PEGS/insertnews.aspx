<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="insertnews.aspx.cs" Inherits="PEGS.insertnews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <form action="" method="post">
            <hr />
            Title for the news <input type="text" name="header" placeholder="Header" /> <br /><br /><br />

             Main content : <br /> 
                <textarea cols="50" rows="8" name="content" placeholder="What Should I Write ???"></textarea>
                
            <br />
             <input type="submit" value="Submit" name="submit" class="tfbutton" />
             <input type="reset" value="Reset" class="tfbutton"/>

        </form>
        <%=done %>
    </div>
</asp:Content>
