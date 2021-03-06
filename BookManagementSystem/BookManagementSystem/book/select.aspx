﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="select.aspx.cs" Inherits="book_select" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image:url(../images/book.png);background-repeat:no-repeat; background-attachment: fixed;background-size:100%,100%">
    <form id="form1" runat="server">
        <div align="center">
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem>书号</asp:ListItem>
                <asp:ListItem>作者</asp:ListItem>
                <asp:ListItem>类别</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:TextBox ID="input" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" style="height: 21px" />
            <br />
            <br />
            <br />
    <asp:GridView ID="GridViewEmployee1" runat="server" AutoGenerateColumns="False"       
     EnableModelValidation="True" CellPadding="4" ForeColor="#333333" GridLines="None" Height="130px" Width="1340px" >
     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <RowStyle HorizontalAlign ="Center" />
    <Columns>
        <asp:TemplateField HeaderText="书号">
            <ItemTemplate>
                <asp:Label ID="Labelid" runat="server" Text='<%# Bind("b_id") %>'/>
            </ItemTemplate>
        </asp:TemplateField >

        <asp:TemplateField HeaderText="书名">
            <ItemTemplate>
                <asp:Label ID="Labelname" runat="server" Text='<%# Bind("b_name") %>'/>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="作者">
            <ItemTemplate>
                <asp:Label ID="Labelauthor" runat="server" Text='<%# Bind("b_author") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="出版社">
            <ItemTemplate>
                <asp:Label ID="Labelpress" runat="server" Text='<%# Bind("b_press") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="数量">
            <ItemTemplate>
                <asp:Label ID="Labelnum" runat="server" Text='<%# Bind("b_num") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
                 <asp:TemplateField HeaderText="类别">
            <ItemTemplate>
                <asp:Label ID="Labelsortname" runat="server" Text='<%# Bind("sort_name") %>'/>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
     <EditRowStyle BackColor="#999999" />   
     <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
     <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
     <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView> 
        </div>
    </form>
</body>
</html>
