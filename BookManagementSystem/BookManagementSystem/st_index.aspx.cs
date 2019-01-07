using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    private bool chenck() {

        if (Session["s_id"]==null) {
            Response.Write("请登录");
            return false;
        }
        return true;
    }

    private void InitData()
    {
        //连接数据库
        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstr);

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [st_id], [st_name], [st_dept], [st_class], [st_credit] FROM [Student]",conn);

        conn.Open();
        da.Fill(ds);
        conn.Close();

        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!chenck()) {
            Response.Redirect("Login.aspx");
        
        }
        if (!this.IsPostBack)
            InitData();
    }



    protected void GridView1_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        int s_id = -1;
        switch (e.CommandName) {
            case "del":
                s_id = Convert.ToInt32(GridView1.Rows[index].Cells[0].Text);

                deleteData(s_id);
                InitData();
                break;
            default:
                break;
        }
    }

    private void deleteData(int s_id) {

        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM [Student] where st_id=@s_id";
        cmd.CommandType = CommandType.Text;

        //添加查询对象，传递参数
        SqlParameter para = new SqlParameter("@s_id",SqlDbType.Int);
        para.Value = s_id;
        cmd.Parameters.Add(para);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("st_index.aspx");

        }
        catch{
            Response.Write("发生异常");
        }
        conn.Close();

    }

    protected void st_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}