﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image:url(../images/st.png);background-repeat:no-repeat; background-attachment: fixed;background-size:100%,100%">
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
            密码：<asp:TextBox ID="st_pw" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="submit" runat="server" Text="确定" OnClick="submit_Click" />
        </div>
    </form>
</body>
</html>
