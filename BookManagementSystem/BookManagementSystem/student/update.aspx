<%@ Page Language="C#" AutoEventWireup="true" CodeFile="update.aspx.cs" Inherits="student_update1" %>

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
             输入要修改的学生学号：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
             <br />
             <br />
            <br />
 <asp:GridView ID="GridViewEmployee1" runat="server" AutoGenerateColumns="False" 
       onrowcancelingedit="GridViewEmployee_RowCancelingEdit" 
        onrowediting="GridViewEmployee_RowEditing" 
        onrowupdating="GridViewEmployee_RowUpdating" EnableModelValidation="True" CellPadding="4" ForeColor="#333333" GridLines="None" Height="130px" Width="1340px" >
     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
     <RowStyle HorizontalAlign ="Center" />
    <Columns>
        <asp:TemplateField HeaderText="学号">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditid" runat="server" Text='<%# Bind("st_id") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Labelid" runat="server" Text='<%# Bind("st_id") %>'/>
            </ItemTemplate>

        </asp:TemplateField >

        <asp:TemplateField HeaderText="姓名">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditname" runat="server" Text='<%# Bind("st_name") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Labelname" runat="server" Text='<%# Bind("st_name") %>'/>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="性别">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditsex" runat="server" Text='<%# Bind("st_sex") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Labelsex" runat="server" Text='<%# Bind("st_sex") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="专业">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditdept" runat="server" Text='<%# Bind("st_dept") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Labeldept" runat="server" Text='<%# Bind("st_dept") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="班级">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditclass" runat="server" Text='<%# Bind("st_class") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Labelclass" runat="server" Text='<%# Bind("st_class") %>'/>
            </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="信誉">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditcredit" runat="server" Text='<%# Bind("st_credit") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Labelcredit" runat="server" Text='<%# Bind("st_credit") %>'/>
            </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="密码">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditpw" runat="server" Text='<%# Bind("st_pw") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Labelpw" runat="server" Text='<%# Bind("st_pw") %>'/>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:CommandField ShowEditButton="True" ShowDeleteButton HeaderText="操作" DeleteText="" />
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
