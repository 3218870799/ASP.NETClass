<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        用户名:
        <asp:TextBox ID="tx_username" runat="server"></asp:TextBox>
        <br />
        密 码 :
        <asp:TextBox ID="tx_password" runat="server"  TextMode="Password"></asp:TextBox>
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
            <asp:ListItem>学生</asp:ListItem>
            <asp:ListItem>管理员</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="longin" runat="server" Text="登陆" OnClick="longin_Click" />
    
    </div>
    </form>
</body>
</html>
