# ASP.NET Class Design
## ��Ŀ���
����Ŀ����ASP.NET�γ���ƣ��ܼ򵥣�����ʱ��д�꣬��Ҫ��һ��ͼ�����ϵͳ��Ҳ�ǿ�����������ϵͳ����Ҫ��ѧ��ϵͳ�͹���Աϵͳ������
Ϊ�����ۣ�ѧ��ϵͳ���ð��￪ԴSUIMobile����ǰ����ƣ�����Աϵͳ����EasyUI����ǰ����ơ�
## ���ܼ��
#### ѧ��ϵͳ����
���ղ�ͬҪ����ϲ�ѯ�鼮��Ϣ<br/>
�����鼮<br/>
�鿴�Լ��Ľ�����Ϣ<br/>
�黹�鼮<br/>
�鿴�Լ��Ľ����¼<br/>
�鿴�Լ����˵�<br/>
�鿴������Ϣ<br/>
�޸ĸ�����Ϣ<br/>
#### ����Աϵͳ����
¼��ѧ����Ϣ<br/>
��ѯѧ����Ϣ<br/>
�޸�ѧ����Ϣ<br/>
ɾ��ѧ����Ϣ<br/>
����ѧ���˵���¼<br/>
¼���鼮��Ϣ<br/>
���ͼ�����<br/>
ɾ���鼮��Ϣ<br/>
�����鼮��Ϣ<br/>
## ϵͳ����ͼ
![ϵͳ����ͼ](https://github.com/3218870799/BookManagementSystem/blob/master/BookManagementSystem/READMEIMAGE/%E7%B3%BB%E7%BB%9F%E6%B5%81%E7%A8%8B%E5%9B%BE.png)
## Ч��չʾͼ
>> ѧ��ϵͳЧ��ͼ
![ѧ��ϵͳЧ��ͼ](https://github.com/3218870799/BookManagementSystem/blob/master/BookManagementSystem/READMEIMAGE/%E5%AD%A6%E7%94%9F%E7%B3%BB%E7%BB%9F%E6%95%88%E6%9E%9C%E5%9B%BE.gif)
>> ����ԱϵͳЧ��ͼ
![����ԱϵͳЧ��ͼ](https://github.com/3218870799/BookManagementSystem/blob/master/BookManagementSystem/READMEIMAGE/%E7%AE%A1%E7%90%86%E5%91%98%E7%B3%BB%E7%BB%9F%E6%95%88%E6%9E%9C%E5%9B%BE.gif)

## ���������ܽ�
#### ��ʱִ������
>> ����ѧ�����Ĳ�����������Ҫ��ϵͳ��ҹ0�㶨ʱִ�и�����

#### ExecuteNonQuery()����ֵ<br/>
>> ExecuteNonQuery()������Ҫ�û��������ݣ�ͨ����ʹ��Update,Insert,Delete������������ݿ⣬
 �䷽������ֵ���壺
 ���� Update,Insert,Delete ��� ִ�гɹ��Ƿ���ֵΪ��������Ӱ���������
 ���Ӱ�������Ϊ0ʱ���ص�ֵΪ0��������ݲ����ع��û�����ֵΪ-1��
#### Ϊ����Դ�ؼ�GridView��ÿһ������Զ��尴ť<br/>
 ```ASP
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
	<Columns>
	<!--ʡ�������ؼ�-->
		<asp:TemplateField HeaderText="�黹ͼ��">
			<ItemTemplate>
				<asp:Button ID="Button3" runat="server" Text="����" OnClick="ReturnBook" CommandArgument='<%#Eval("b_id") %>'/>
			</ItemTemplate>
		</asp:TemplateField>
	</Columns>
</asp:GridView>
```
```C#
protected void ReturnBook(object sender, EventArgs e)
{   
    //�������ݿ�
    string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    SqlConnection conn = new SqlConnection(connstr);
    conn.Open();

    Button btn = (Button)sender;//ע��ؼ����͵�ת��
    string BookIdString = btn.CommandArgument;//��ȡ�õ��ؼ��󶨵Ķ�Ӧֵ
    int BookId = Convert.ToInt32(BookIdString);
    //TODO ��Sessin�л�ȡѧ��Id
    string SqlString = "exec  Procedure_return " + 1001 + "," + BookId + ";";
    SqlCommand comm = new SqlCommand(SqlString, conn);
    int result = comm.ExecuteNonQuery();
    if (result == -1 || result == 0)
    {
        Response.Write("<script>alert('����ʧ�ܣ�')</script>");
    }
    else
    {
        Response.Write("<script>alert('����ɹ���')</script>");
    }
}
```
#### ASP.NET�л�ȡdropdownlist��ѡ��ʼ�ղ���<br/>
>> �����������Ϊ�ڵ�����ύ��ť��ҳ���ˢ���ٻ�ȡ�����б�����
��ʱ����ѡ��ʲô��ȡ�Ķ��������б�ĵ�һ��������ֻ��Ҫ�ж��Ƿ���IsPostBack����
�����������б�ķ����ŵ��ж���
```C#
protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        InitDropDownList();
    }
}
```
#### �����б��������<br/>
>> [�����ܽ�](https://www.jb51.net/article/82642.htm)<br/>
#### SQLserver�����޷���ѯ<br/>
```SQL
select * from Roles 
where RoleName like N'%ϵͳ%'
```

