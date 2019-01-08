using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class book_addbook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
//book表添加
    private void addbook() {
        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstr);

        //新建command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO [Book] values(@b_id,@b_name,@b_author,@b_press,@b_num)";
        cmd.CommandType = CommandType.Text;

        SqlParameter para1 = new SqlParameter("@b_id", SqlDbType.Int);

        string sid = b_id.Text.Trim();
        int id = Convert.ToInt32(sid);
        para1.Value = id;
        cmd.Parameters.Add(para1);

        SqlParameter para2 = new SqlParameter("@b_name", SqlDbType.NVarChar, 50);
        para2.Value = b_name.Text.Trim();
        cmd.Parameters.Add(para2);

        SqlParameter para3 = new SqlParameter("@b_author", SqlDbType.NVarChar, 50);
        para3.Value = b_author.Text.Trim();
        cmd.Parameters.Add(para3);

        SqlParameter para4 = new SqlParameter("@b_press", SqlDbType.NVarChar, 50);
        para4.Value = b_press.Text.Trim();
        cmd.Parameters.Add(para4);

        SqlParameter para5 = new SqlParameter("@b_num", SqlDbType.NVarChar, 50);

        string num = b_num.Text.Trim();
        int num1 = Convert.ToInt32(num);
        para5.Value = num1;
        cmd.Parameters.Add(para5);



        try
        {

            conn.Open();
            //Response.Write("1");
            cmd.ExecuteNonQuery();
           // Response.Write("2");

        }
        catch
        {
            Response.Write("发生异常");
        }
        conn.Close();
    }
    //book_sort表添加
    private void addsort() {
        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstr);

        //新建command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO [Book_sort] values(@sort_id,@b_id,@sort_name)";
        cmd.CommandType = CommandType.Text;



        SqlParameter para1 = new SqlParameter("@sort_id", SqlDbType.Int);

        string id = sort_id.Text.Trim();
        int sid = Convert.ToInt32(id);
        para1.Value = sid;
        cmd.Parameters.Add(para1);


        SqlParameter para3 = new SqlParameter("@b_id", SqlDbType.Int);

        string sid1 = b_id.Text.Trim();
        int id1 = Convert.ToInt32(sid1);
        para3.Value = id1;
        cmd.Parameters.Add(para3);

        SqlParameter para2 = new SqlParameter("@sort_name", SqlDbType.NVarChar, 50);
        para2.Value = sort_name.Text.Trim();
        cmd.Parameters.Add(para2);

        try
        {

            conn.Open();
           // Response.Write("1");
            cmd.ExecuteNonQuery();
            //  Response.Write("2");
            Response.Write("<script>alert('添加成功')</script>");
            Response.Redirect("select.aspx");

        }
        catch
        {
            Response.Write("发生异常");
        }
        conn.Close();

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        addbook();
        addsort();
    }
}