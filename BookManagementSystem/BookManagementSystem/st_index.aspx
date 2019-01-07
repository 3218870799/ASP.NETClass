<%@ Page Language="C#" AutoEventWireup="true" CodeFile="st_index.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <!-- 具有借书，还书，交罚款，查询图书功能--> 
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_SelectedIndexChanged">
                  <Columns>
                    <asp:BoundField DataField="st_id" HeaderText="st_id" ReadOnly="True" SortExpression="st_id" />
                    <asp:BoundField DataField="st_name" HeaderText="st_name" SortExpression="st_name" />
                    <asp:BoundField DataField="st_dept" HeaderText="st_dept" SortExpression="st_dept" />
                    <asp:BoundField DataField="st_class" HeaderText="st_class" SortExpression="st_class" />
                    <asp:BoundField DataField="st_credit" HeaderText="st_credit" SortExpression="st_credit" />
                    <asp:ButtonField CommandName="del" HeaderText="删除" Text="删除" />
                </Columns>
            </asp:GridView>
        </div>
        <a href="add.aspx">添加</a>
    </form>
</body>
</html>
