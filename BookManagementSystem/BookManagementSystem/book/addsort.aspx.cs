using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class book_addsort : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstr);

        //新建command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO [Sort] values(@sort_id,@sort_name)";
        cmd.CommandType = CommandType.Text;

        SqlParameter para1 = new SqlParameter("@sort_id", SqlDbType.Int);

        string sid = id.Text.Trim();
        int id1 = Convert.ToInt32(sid);
        para1.Value = id1;
        cmd.Parameters.Add(para1);

        SqlParameter para2 = new SqlParameter("@sort_name", SqlDbType.NVarChar, 50);
        para2.Value = name.Text.Trim();
        cmd.Parameters.Add(para2);


        try
        {

            conn.Open();
            Response.Write("1");
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('添加成功')</script>");
            Response.Write("2");

        }
        catch
        {
            Response.Write("发生异常");
        }
        conn.Close();
    }
}
