# ASP.NET Class Design
## 项目简介
本项目本人ASP.NET课程设计，很简单，两天时间写完，主要是一个图书管理系统，也是课设做常见的系统，主要有学生系统和管理员系统两部分
为了美观，学生系统采用阿里开源SUIMobile进行前端设计，管理员系统采用EasyUI进行前端设计。
## 功能简介
#### 学生系统部分
按照不同要求组合查询书籍信息<br/>
借阅书籍<br/>
查看自己的借书信息<br/>
归还书籍<br/>
查看自己的借书记录<br/>
查看自己的账单<br/>
查看个人信息<br/>
修改个人信息<br/>
#### 管理员系统部分
录入学生信息<br/>
查询学生信息<br/>
修改学生信息<br/>
删除学生信息<br/>
管理学生账单记录<br/>
录入书籍信息<br/>
添加图书分类<br/>
删除书籍信息<br/>
查找书籍信息<br/>
## 系统流程图
![系统流程图](https://github.com/3218870799/BookManagementSystem/blob/master/BookManagementSystem/READMEIMAGE/%E7%B3%BB%E7%BB%9F%E6%B5%81%E7%A8%8B%E5%9B%BE.png)
## 效果展示图
>> 学生系统效果图
![学生系统效果图](https://github.com/3218870799/BookManagementSystem/blob/master/BookManagementSystem/READMEIMAGE/%E5%AD%A6%E7%94%9F%E7%B3%BB%E7%BB%9F%E6%95%88%E6%9E%9C%E5%9B%BE.gif)
>> 管理员系统效果图
![管理员系统效果图](https://github.com/3218870799/BookManagementSystem/blob/master/BookManagementSystem/READMEIMAGE/%E7%AE%A1%E7%90%86%E5%91%98%E7%B3%BB%E7%BB%9F%E6%95%88%E6%9E%9C%E5%9B%BE.gif)

## 常见问题总结
#### 定时执行任务
>> 对于学生借阅产生罚单，需要在系统午夜0点定时执行该任务

#### ExecuteNonQuery()返回值<br/>
>> ExecuteNonQuery()方法主要用户更新数据，通常它使用Update,Insert,Delete语句来操作数据库，
 其方法返回值意义：
 对于 Update,Insert,Delete 语句 执行成功是返回值为该命令所影响的行数，
 如果影响的行数为0时返回的值为0，如果数据操作回滚得话返回值为-1。
#### 为数据源控件GridView后每一列添加自定义按钮<br/>
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
#### ASP.NET中获取dropdownlist的选择始终不变<br/>
>> 这个问题是因为在点击了提交按钮后，页面会刷新再获取下拉列表内容
此时无论选择什么获取的都是下拉列表的第一个，我们只需要判断是否是IsPostBack即可
将加载下拉列表的方法放到判断里
```C#
protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        InitDropDownList();
    }
}
```
#### 下拉列表加载数据<br/>
>> [方案总结](https://www.jb51.net/article/82642.htm)<br/>
#### SQLserver中文无法查询<br/>
```SQL
select * from Roles 
where RoleName like N'%系统%'
```

