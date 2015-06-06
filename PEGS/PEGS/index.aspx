<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PEGS.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
           
            <p>In this site you can see picture of PEGS</p>
            <div id="pictures">
                <img class="mainpagepic" src="https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRYtI88U5p5z4u8DNulzGPO8IesWnQrBjOPaPrZ12Vg9Qlhl5bC" />
                <img class="mainpagepic" src="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSMQI25hO4rtIKkJEhtq1DEo-SnKYodZ09dHREoyz0X0HTadnZpfA" />
                <img class="mainpagepic" src="https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcR6MVkqN0OUJgM6T-eOfnCM9E5fO7jQoSPjBBasvwICWjLPX7Uh" />
                <img class="mainpagepic" src="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSu0JsZqhbrL7tFYaLv5lV6PheeLsP60AG_rJrZtrxf6f1NJ_nEew" />

                <asp:Repeater ID="RepeaterImages" runat="server">
                    <ItemTemplate>
                        <asp:Image ID="Image" runat="server" ImageUrl='<%# Container.DataItem %>' />
                    </ItemTemplate>
                </asp:Repeater>
              </div>
        </div>
</asp:Content>
