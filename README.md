# ASP.NET Class Design

## ���������ܽ�
 >> ExecuteNonQuery()����ֵ<br/>
 ExecuteNonQuery()������Ҫ�û��������ݣ�ͨ����ʹ��Update,Insert,Delete������������ݿ⣬
 �䷽������ֵ���壺
 ���� Update,Insert,Delete ��� ִ�гɹ��Ƿ���ֵΪ��������Ӱ���������
 ���Ӱ�������Ϊ0ʱ���ص�ֵΪ0��������ݲ����ع��û�����ֵΪ-1��
 >> Ϊ����Դ�ؼ�GridView��ÿһ������Զ��尴ť<br/>
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
>> ASP.NET�л�ȡdropdownlist��ѡ��ʼ�ղ���<br/>
�����������Ϊ�ڵ�����ύ��ť��ҳ���ˢ���ٻ�ȡ�����б�����
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
>> �����б��������<br/>
[�����ܽ�](https://www.jb51.net/article/82642.htm)<br/>
>> SQLserver�����޷���ѯ<br/>
```SQL
select * from Roles 
where RoleName like N'%ϵͳ%'
```

