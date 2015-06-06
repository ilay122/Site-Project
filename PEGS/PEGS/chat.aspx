<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chat.aspx.cs" Inherits="PEGS.chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />
    <title>Chat</title>
    
</head>
<body>
    <iframe runat="server" id="pls" name="pls" src="thechat.aspx"></iframe>
    <form action="thechat.aspx" method="post" >
        <textarea name="msg"></textarea> <br />
        <input type="submit" name="submit" />
    </form>
    <%=foruser %>
    <div id="down"></div>
</body>
</html>
