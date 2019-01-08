<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addsort.aspx.cs" Inherits="book_addsort" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server" >
        <div align="center"> 
            <br />
            类别号：<asp:TextBox ID="id" runat="server"></asp:TextBox>
            <br />
            <br />
            类别名：<asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="submit" runat="server" Text="确定" OnClick="submit_Click" />
        </div>
    </form>
</body>
</html>
