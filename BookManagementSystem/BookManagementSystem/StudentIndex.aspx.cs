using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

public partial class StudentIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InitBorrowBook();
        //InitDropDownList();
        if (!IsPostBack)
        {
            InitDropDownList();
        }
        InitBook();
        InitFineBook();
    }

    private DataSet GetDataSetBySql(String sql)
    {
        //连接数据库
        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstr);

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);

        conn.Open();
        da.Fill(ds);
        conn.Close();
        return ds;
    }

    private void InitFineBook()
    {
        string sql = "SELECT * FROM Stu_fine";
        DataSet ds = GetDataSetBySql(sql);
        Repeater2.DataSource=ds.Tables[0];
        Repeater2.DataBind();       
    }

    private void InitBook()
    {


    }


    protected void FilterBooks(object sender, EventArgs e)
    {
        string sql = "SELECT * FROM Book_info";
        if (DropDownList1.SelectedItem.Text != "请选择类别")
        {
            sql = sql + "  "+ "WHERE sort_name =" + " N'"+ DropDownList1.SelectedItem.Text+"'";           
        }
        if(DropDownList2.SelectedItem.Text== "只显示在馆书籍")
        {
            sql = sql + " " + "And b_num = 0";
        }
        if (TextBox1.Text != "")
        {
            sql = sql + " " + "AND b_author like N'%" + TextBox1.Text + "%'";        
        }
        if (TextBox2.Text != "")
        {
            sql = sql + " " + "and b_name like N'%" + TextBox2.Text + "%'";
        }
        if (TextBox3.Text != "")
        {
            sql = sql = " " + "and b_press like N'%" + TextBox3.Text + "%'";
        }
        if (TextBox4.Text != "")
        {
            string BookId= TextBox4.Text;
            int id = Convert.ToInt32(BookId);
            sql = "SELECT * FROM Book_info where b_id = " + id;
        }
        DataSet ds = GetDataSetBySql(sql);
        Repeater1.DataSource = ds.Tables[0];
        Repeater1.DataBind();
    }
    private void InitDropDownList()
    {
        string sql = "SELECT sort_name FROM Sort";
        DataSet ds = GetDataSetBySql(sql);

        //将查询数据置于数组中
        ArrayList ar = new ArrayList();
        ar.Add("请选择类别");
        DataTable dt = ds.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            ar.Add(dr[0].ToString());
        }
        //绑定到下拉列表
        this.DropDownList1.DataSource = ar;
        this.DropDownList1.DataBind();


    }
    private void InitBorrowBook()
    {
        string sql = "SELECT [b_id], [b_name] FROM [st_borrow]";
        DataSet ds = GetDataSetBySql(sql);
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }




}