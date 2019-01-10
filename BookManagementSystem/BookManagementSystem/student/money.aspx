<%@ Page Language="C#" AutoEventWireup="true" CodeFile="money.aspx.cs" Inherits="student_money" %>

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
            输入要删除的学生学号：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
            <br />
            <br />
            <br />
         <asp:GridView ID="GridViewEmployee1" runat="server" AutoGenerateColumns="False"       
             onrowdeleting="GridViewEmployee_RowDeleting"
             EnableModelValidation="True" CellPadding="4" ForeColor="#333333" GridLines="None" Height="130px" Width="1340px" >
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <RowStyle HorizontalAlign ="Center" />
             <Columns>
                <asp:TemplateField HeaderText="学号">
                    <ItemTemplate>
                        <asp:Label ID="Labelid" runat="server" Text='<%# Bind("st_id") %>'/>
                    </ItemTemplate>
                </asp:TemplateField >

                <asp:TemplateField HeaderText="书号">
                    <ItemTemplate>
                        <asp:Label ID="Labelbid" runat="server" Text='<%# Bind("b_id") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="欠费时间">
                    <ItemTemplate>
                        <asp:Label ID="Labeltime" runat="server" Text='<%# Bind("over_date") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="欠费金额">
                    <ItemTemplate>
                        <asp:Label ID="Labelfine" runat="server" Text='<%# Bind("fine") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>     

                <asp:CommandField ShowEditButton="True" ShowDeleteButton HeaderText="操作" EditText="" />
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
