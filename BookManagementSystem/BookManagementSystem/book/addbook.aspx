<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addbook.aspx.cs" Inherits="book_addbook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image:url(../images/book.png);background-repeat:no-repeat; background-attachment: fixed;background-size:100%,100%">
<form id="form1" runat="server" >
        <div align="center"> 
            书 号：<asp:TextBox ID="b_id" runat="server"></asp:TextBox>
            <br />
            书 名：<asp:TextBox ID="b_name" runat="server"></asp:TextBox>
            <br />
            作 者：<asp:TextBox ID="b_author" runat="server"></asp:TextBox>
            <br />
            出版社：<asp:TextBox ID="b_press" runat="server"></asp:TextBox>
            <br />
            数 量：<asp:TextBox ID="b_num" runat="server"></asp:TextBox>
            <br />
            <br />
            类别名：<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="sort_name" DataValueField="sort_name">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [sort_name] FROM [Sort]"></asp:SqlDataSource>
            <br />
            <br />
            <asp:Button ID="submit" runat="server" Text="确定" OnClick="submit_Click" />
        </div>
    </form>
</body>
</html>
