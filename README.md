# ASP.NET Class Design

## ���������ܽ�
 >> ExecuteNonQuery()����ֵ
 ExecuteNonQuery()������Ҫ�û��������ݣ�ͨ����ʹ��Update,Insert,Delete������������ݿ⣬
 �䷽������ֵ���壺
 ���� Update,Insert,Delete ��� ִ�гɹ��Ƿ���ֵΪ��������Ӱ���������
 ���Ӱ�������Ϊ0ʱ���ص�ֵΪ0��������ݲ����ع��û�����ֵΪ-1��
 >> Ϊ����Դ�ؼ�GridView��ÿһ������Զ��尴ť
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
