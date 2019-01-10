<%@ Page Language="C#" AutoEventWireup="true" CodeFile="select.aspx.cs" Inherits="student_select" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image:url(../images/st.png);background-repeat:no-repeat; background-attachment: fixed;background-size:100%,100%">
    <form id="form1" runat="server">
        <div align="center">
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                <asp:ListItem>学号</asp:ListItem>
                <asp:ListItem>姓名</asp:ListItem>
                <asp:ListItem>专业</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:TextBox ID="input" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" style="height: 21px" />
            <br />
            <br />
            <br />
 <asp:GridView ID="GridViewEmployee1" runat="server" AutoGenerateColumns="False" 
        EnableModelValidation="True" CellPadding="4" ForeColor="#333333" GridLines="None" Height="130px" Width="1340px">
     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
     <RowStyle HorizontalAlign ="Center" />
    <Columns>
        <asp:TemplateField HeaderText="学号">
            <ItemTemplate>
                <asp:Label ID="Labelid" runat="server" Text='<%# Bind("st_id") %>'/>
            </ItemTemplate>

        </asp:TemplateField >

        <asp:TemplateField HeaderText="姓名">
            <ItemTemplate>
                <asp:Label ID="Labelname" runat="server" Text='<%# Bind("st_name") %>'/>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="性别">
            <ItemTemplate>
                <asp:Label ID="Labelsex" runat="server" Text='<%# Bind("st_sex") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="专业">
            <ItemTemplate>
                <asp:Label ID="Labeldept" runat="server" Text='<%# Bind("st_dept") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="班级">
            <ItemTemplate>
                <asp:Label ID="Labelclass" runat="server" Text='<%# Bind("st_class") %>'/>
            </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="信誉">
            <ItemTemplate>
                <asp:Label ID="Labelcredit" runat="server" Text='<%# Bind("st_credit") %>'/>
            </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="密码">
            <ItemTemplate>
                <asp:Label ID="Labelpw" runat="server" Text='<%# Bind("st_pw") %>'/>
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
