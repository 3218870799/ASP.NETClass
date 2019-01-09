using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class loginnew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void longin_Click(object sender, EventArgs e)
    {
        SqlDataReader dr;
        //获取输入的用户名
        string username = tx_username.Text.Trim();
        string password = tx_password.Text.Trim();

        int type = -1;
            type = RadioButtonList1.SelectedIndex;

        //连接数据库
        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstr);

        //新建command对象

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;


        if (type == 0) //学生登陆
        {
            string sid = tx_username.Text.Trim();

            int id = Convert.ToInt32(sid);

            cmd.CommandText = "select * from [Student] where st_id=@id";
            cmd.CommandType = CommandType.Text;
            //添加查询对象
            SqlParameter para = new SqlParameter("@id", SqlDbType.Int);
            para.Value = id;

            cmd.Parameters.Add(para);
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetString(6) == password)
                    {
                        Session.Add("s_id", id);
                                          
                        tx_username.Text = "";
                        Response.Redirect("StudentIndex.aspx");
                    }
                    else
                    {
                        Response.Write("密码错误");
                    }
                }
                else
                {

                    Response.Write("用户不存在");
                }
                dr.Close();
            }
            catch (SqlException)
            {
                Response.Write("连接异常");
            }
        }
        else if(type==1)//管理员登陆
        {
            cmd.CommandText = "select * from [Manager1] where username=@loginname";
            cmd.CommandType = CommandType.Text;
            //添加查询对象
            SqlParameter para = new SqlParameter("@loginname", SqlDbType.NVarChar, 50);
            para.Value = username;
            cmd.Parameters.Add(para);

            try
            {

                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetString(2) == password)
                    {
                        Session.Add("loginname", username);
                        tx_username.Text = "";
                        Response.Redirect("AdminIndex.aspx");
                    }
                    else
                    {
                        Response.Write("密码错误");
                    }
                }
                else
                {

                    Response.Write("用户不存在");
                }
                dr.Close();
            }
            catch (SqlException)
            {
                Response.Write("连接异常");
            }

        }
        else
        {
            Response.Write("<script>alert('选择登陆类型')</script>");
        }


        conn.Close();

    }
}