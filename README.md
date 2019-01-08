# ASP.NET Class Design

## 常见问题总结
 >> ExecuteNonQuery()返回值
 ExecuteNonQuery()方法主要用户更新数据，通常它使用Update,Insert,Delete语句来操作数据库，
 其方法返回值意义：
 对于 Update,Insert,Delete 语句 执行成功是返回值为该命令所影响的行数，
 如果影响的行数为0时返回的值为0，如果数据操作回滚得话返回值为-1。
 >> 为数据源控件GridView后每一列添加自定义按钮
 ```ASP
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
	<Columns>
	<!--省略其他控件-->
		<asp:TemplateField HeaderText="归还图书">
			<ItemTemplate>
				<asp:Button ID="Button3" runat="server" Text="还书" OnClick="ReturnBook" CommandArgument='<%#Eval("b_id") %>'/>
			</ItemTemplate>
		</asp:TemplateField>
	</Columns>
</asp:GridView>
```
```C#
protected void ReturnBook(object sender, EventArgs e)
{   
    //连接数据库
    string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    SqlConnection conn = new SqlConnection(connstr);
    conn.Open();

    Button btn = (Button)sender;//注意控件类型的转换
    string BookIdString = btn.CommandArgument;//获取得到控件绑定的对应值
    int BookId = Convert.ToInt32(BookIdString);
    //TODO 从Sessin中获取学生Id
    string SqlString = "exec  Procedure_return " + 1001 + "," + BookId + ";";
    SqlCommand comm = new SqlCommand(SqlString, conn);
    int result = comm.ExecuteNonQuery();
    if (result == -1 || result == 0)
    {
        Response.Write("<script>alert('还书失败！')</script>");
    }
    else
    {
        Response.Write("<script>alert('还书成功！')</script>");
    }
}
```
