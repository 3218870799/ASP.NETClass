<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <div align="center"> 
            学号：<asp:TextBox ID="st_id" runat="server"></asp:TextBox>
            <br />
            姓名：<asp:TextBox ID="st_name" runat="server"></asp:TextBox>
            <br />
            性别：<asp:TextBox ID="st_sex" runat="server"></asp:TextBox>
            <br />
            专业：<asp:TextBox ID="st_dept" runat="server"></asp:TextBox>
            <br />
            班级：<asp:TextBox ID="st_class" runat="server"></asp:TextBox>
            <br />
            信誉：<asp:TextBox ID="st_credit" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="submit" runat="server" Text="确定" OnClick="submit_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click" style="height: 21px" />
        </div>
    </form>
</body>
</html>
