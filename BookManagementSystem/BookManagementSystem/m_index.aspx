<%@ Page Language="C#" AutoEventWireup="true" CodeFile="m_index.aspx.cs" Inherits="Manager_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
  <!-- 具有添加图书，图书分类，添加学生，删除学生，修改图书信息，删除图书信息-->         
     <asp:GridView ID="GridViewEmployee" runat="server" AutoGenerateColumns="False" 
        ShowFooter="True" onrowcancelingedit="GridViewEmployee_RowCancelingEdit" 
        onrowediting="GridViewEmployee_RowEditing" 
        onrowupdating="GridViewEmployee_RowUpdating" 
        onrowdeleting="GridViewEmployee_RowDeleting">
    <Columns>
        <asp:TemplateField HeaderText="用户名">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditEmployee" runat="server" Text='<%# Bind("username") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LabelEmployee" runat="server" Text='<%# Bind("username") %>'/>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="TextBoxEmployee" runat="server"/>
            </FooterTemplate>
        </asp:TemplateField >

        <asp:TemplateField HeaderText="密码">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditPosition" runat="server" Text='<%# Bind("password") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LabelPosition" runat="server" Text='<%# Bind("password") %>'/>
            </ItemTemplate>
            <FooterTemplate>
                    <asp:TextBox ID="TextBoxPosition" runat="server"/>
            </FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="姓名">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditTeam" runat="server" Text='<%# Bind("realname") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LabelTeam" runat="server" Text='<%# Bind("realname") %>'/>
            </ItemTemplate>
            <FooterTemplate>
                    <asp:TextBox ID="TextBoxTeam" runat="server"/>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="管理员ID">
            <ItemTemplate>
                <asp:Label ID="LabelID" runat="server" Text='<%# Bind("Id") %>'/>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Button ID="Button1" runat="server" Text="增  加" OnClick="Button1_Click" />
            </FooterTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ShowDeleteButton HeaderText="操作" />
    </Columns>
    </asp:GridView>
        </div>
    </form>
</body>
</html>
