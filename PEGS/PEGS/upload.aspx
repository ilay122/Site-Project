<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="PEGS.upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <h1>UPLOADING A PICTURE </h1>
        <p>Select which pic you want to upload from your computer (J"PEG" , GIF , JPG,PNG)
             <br /> and click the upload button </p>
        
        <form id="form1" runat="server">
            <asp:FileUpload CssClass="tfbutton" id="fileUpload1" runat="server"/>
            <br />
            <asp:Button id="btnUpload" class="tfbutton" runat="server" Text="Upload" OnClick="btnUpload_Click"/>
        </form>
        <br />
        <%=done %>
        <h2>Uploading with URL (NOT GIFS !)</h2>
        <form action="" method="post">
            <input type="text" name="url" size="45" required/>
            <input type="submit" name="submiturl" value="submit" class="tfbutton"/>
        </form> <br />
        <%=done2 %>
        <br />
    </div>
</asp:Content>
