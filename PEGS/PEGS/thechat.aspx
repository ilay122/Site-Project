<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thechat.aspx.cs" Inherits="PEGS.thechat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="refresh" content="1"/>
        <script src="jquery-1.10.2.js"></script>
    <script>
        $(document).ready(function () {
            window.scrollTo(0, document.body.scrollHeight);
        });
    </script>
</head>
<body>
    <%=logged.ToString() %>
   <%=Application[Session["user"].ToString()] %>
</body>
</html>
