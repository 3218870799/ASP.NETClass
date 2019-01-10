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
    DataBase db = new DataBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        InitBorrowBook();
        if (!IsPostBack)
        {
            InitDropDownList();
            InitPersonInfo();
        }
        InitFineBook();
        
    }
    //根据sql获取DataSet对象
    /*    
        //TODO提取
         private DataSet GetDataSetBySql(String sql)
        {
            //DataBase db = new DataBase();

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
        public int ExecuteSQL(String SqlString)
        {
            SqlConnection conn = DBCon();
            conn.Open();
            SqlCommand comm = new SqlCommand(SqlString, conn);
            int result = comm.ExecuteNonQuery();
            return result;
        }
    */
    //加载个人信息
    private void InitPersonInfo()
    {
        string idstring = Session["s_id"].ToString();
        int id = Convert.ToInt32(idstring);
        string sql = "Select * from Student where st_id = " + id;
        DataRow dr = null;
        try
        {
             dr= db.GetDataRow(sql);
        }
        catch
        {
            Response.Write("<script>alert('加载个人信息失败！')</script>");
        }
        Label0.Text = dr[0].ToString();
        TextBox6.Text = (string)dr[1];
        Label2.Text = (string)dr[2];
        Label3.Text = (string)dr[3];
        Label4.Text = (string)dr[4];
        Label5.Text = (string)dr[5].ToString();
        TextBox5.Text = (string)dr[6];
    }
    //更新个人信息
    protected void UpdatePersonInfo(object sender, EventArgs e)
    {
        string idstring = Session["s_id"].ToString();
        int id = Convert.ToInt32(idstring);

        string sql = "UPDATE Student SET st_name = N'"+TextBox6.Text+"',st_pw = N'" + TextBox5.Text + "' WHERE st_id = " + id;

        /*        int result = db.ExecuteSQL(sql);
                if (result == 1)
                {
                    Response.Write("<script>alert('更新成功！')</script>");
                }
                else
                {
                    Response.Write("<script>alert('更新失败！')</script>");
                }
        */
        try
        {
            db.ExecuteSQL(sql);
        }
        catch
        {
            Response.Write("<script>alert('更新失败！')</script>");
        }

        Response.Write("<script>alert('更新成功！')</script>");


    }
    //加载罚款账单
    private void InitFineBook()
    {
        string idstring = Session["s_id"].ToString();
        int id = Convert.ToInt32(idstring);
        string sql = "SELECT * FROM Stu_fine where st_id = "+ id;
        DataSet ds = null;
        try
        {
            ds = db.GetDataSet(sql);
        }
        catch
        {
            Response.Write("<script>alert('加载罚单失败！请重新加载')</script>");
        }        
        GridView3.DataSource=ds.Tables[0];
        GridView3.DataBind();       
    }
    //过滤查询书籍
    protected void FilterBooks(object sender, EventArgs e)
    {
        string sql = "SELECT * FROM Book_info";
        int flag = 0;

        if(DropDownList2.SelectedItem.Text == "只显示在馆书籍"|| DropDownList1.SelectedItem.Text != "请选择类别"|| TextBox1.Text != ""|| TextBox2.Text != ""|| TextBox3.Text != "")
        {
            sql = sql + " WHERE ";
            if (DropDownList2.SelectedItem.Text == "只显示在馆书籍")
            {
                    sql = sql + " " + "b_num != 0";
                    flag = 1;
            }
            if (DropDownList1.SelectedItem.Text != "请选择类别")
            {
                if (flag == 1)
                {
                    sql = sql + " AND ";
                }
                sql = sql + "  " + "sort_name =" + " N'" + DropDownList1.SelectedItem.Text + "'";
                flag = 1;
            }
            if (TextBox1.Text != "")
            {
                if (flag == 1)
                {
                    sql = sql + " AND ";
                }
                sql = sql + " " + "b_author like N'%" + TextBox1.Text + "%'";
                flag = 1;
            }
            if (TextBox2.Text != "")
            {
                if (flag == 1)
                {
                    sql = sql + " AND ";
                }
                sql = sql + " " + "b_name like N'%" + TextBox2.Text + "%'";
                flag = 1;
            }
            if (TextBox3.Text != "")
            {
                if (flag == 1)
                {
                    sql = sql + " AND ";
                }
                sql = sql + " " + "b_press like N'%" + TextBox3.Text + "%'";
                flag = 1;
            }
        }
        
        if (TextBox4.Text != "")
        {
            string BookId= TextBox4.Text;
            int id = Convert.ToInt32(BookId);
            sql = "SELECT * FROM Book_info where b_id = " + id;
        }
        DataSet ds = null;
        try
        {
            ds = db.GetDataSet(sql);
        }
        catch
        {
            Response.Write("<script>alert('加载数据失败！')</script>");
        }
        
        GridView2.DataSource = ds.Tables[0];
        GridView2.DataBind();
    }
    //动态加载下拉列表书籍类别
    private void InitDropDownList()
    {
        string sql = "SELECT sort_name FROM Sort";

        DataSet ds = db.GetDataSet(sql);

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
    //加载已经借的书
    private void InitBorrowBook()
    {
        string idstring = Session["s_id"].ToString();
        int id = Convert.ToInt32(idstring);
        string sql = "SELECT * FROM st_borrow where st_id = " + id;

        DataSet ds = db.GetDataSet(sql);

        GridView1.DataSource = ds;
        GridView1.DataBind();

        string recordSql = "SELECT * FROM stu_info where st_id = " + id;

        DataSet recordds = db.GetDataSet(recordSql);

        GridView4.DataSource = recordds;
        GridView4.DataBind();

    }
    //借阅书籍
    protected void BorrowBookClick(object sender, EventArgs e)
    {
        Response.Write("<script>alert('确定要订阅此书？')</script>");
        Button btn = (Button)sender;//注意控件类型的转换
        string BookIdString = btn.CommandArgument;//获取得到控件绑定的对应值
        int BookId = Convert.ToInt32(BookIdString);
        Response.Write("<script>alert('"+BookId+"')</script>");
        //TODO 从Sessin中获取学生Id
        string idstring = Session["s_id"].ToString();
        int id = Convert.ToInt32(idstring);

        string SqlString = "exec  Procedure_st_borrow "+ id +","+ BookId +";";

        int result = db.ExecuteSQL(SqlString);

        if (result == -1||result==0)
        {
            Response.Write("<script>alert('借阅失败，可能是库存不足或者信誉积分不足！')</script>");
        }
        else
        {
            Response.Write("<script>alert('借书成功！')</script>");
            //FilterBooks();
        }
    }
    //还书功能
    protected void ReturnBook(object sender, EventArgs e)
    {
        Response.Write("<script>alert('确定要还此书？')</script>");

        Button btn = (Button)sender;//注意控件类型的转换
        string BookIdString = btn.CommandArgument;//获取得到控件绑定的对应值
        int BookId = Convert.ToInt32(BookIdString);
        Response.Write("<script>alert('" + BookId + "')</script>");
        //TODO 从Sessin中获取学生Id
        string idstring = Session["s_id"].ToString();
        int id = Convert.ToInt32(idstring);

        string SqlString = "exec  Procedure_return " + id + "," + BookId + ";";

        int result = db.ExecuteSQL(SqlString);

        if (result == -1 || result == 0)
        {
            Response.Write("<script>alert('借阅失败，可能是库存不足或者信誉积分不足！')</script>");
        }
        else
        {
            Response.Write("<script>alert('还书成功！')</script>");
        }
    }

}