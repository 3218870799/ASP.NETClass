using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;




public partial class StudentIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InitBook();

    }

    private void InitBook()
    {
        //连接数据库
        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstr);

        DataSet ds = new DataSet();

        //string sql = "SELECT Book.b_id,Book.b_name,borrow_date FROM Student, Book, Borrow where Student.st_id = Borrow.st_id and Book.b_id = Borrow.b_id";

        SqlDataAdapter da = new SqlDataAdapter("SELECT [b_id], [b_name] FROM [st_borrow]", conn);

        conn.Open();
        da.Fill(ds);
        conn.Close();

        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
}