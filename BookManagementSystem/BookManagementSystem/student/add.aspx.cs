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
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        // 连接数据库
        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstr);

        //新建command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO [Student] values(@st_id,@st_name,@st_sex,@st_dept,@st_class,@st_credit,@st_pw)";
        cmd.CommandType = CommandType.Text;

        SqlParameter para1 = new SqlParameter("@st_id",SqlDbType.Int);
        
        string sid= st_id.Text.Trim();
        int id = Convert.ToInt32(sid);

        para1.Value = id;
        cmd.Parameters.Add(para1);

        SqlParameter para2 = new SqlParameter("@st_name", SqlDbType.NVarChar,50);
        para2.Value = st_name.Text.Trim();
        cmd.Parameters.Add(para2);

        SqlParameter para3 = new SqlParameter("@st_sex", SqlDbType.NVarChar, 50);
        para3.Value = st_sex.Text.Trim();
        cmd.Parameters.Add(para3);

        SqlParameter para4 = new SqlParameter("@st_dept", SqlDbType.NVarChar, 50);
        para4.Value = st_dept.Text.Trim();
        cmd.Parameters.Add(para4);

        SqlParameter para5 = new SqlParameter("@st_class", SqlDbType.NVarChar, 50);
        para5.Value = st_class.Text.Trim();
        cmd.Parameters.Add(para5);

        SqlParameter para6 = new SqlParameter("@st_credit", SqlDbType.Int);
         
        string s_credit= st_credit.Text.Trim();
        int credit = Convert.ToInt32(s_credit);
        para6.Value = credit;
        cmd.Parameters.Add(para6);

        SqlParameter para7 = new SqlParameter("@st_pw", SqlDbType.NVarChar, 50);
        para7.Value = st_pw.Text.Trim();
        cmd.Parameters.Add(para7);

        try
        {

            conn.Open();
            Response.Write("1");
            cmd.ExecuteNonQuery();
            Response.Write("2");
            
            Response.Redirect("select.aspx");
            Response.Write("<script>alert('添加成功')</script>");

        }
        catch {
            Response.Write("发生异常");
        }
        conn.Close();
    }

}