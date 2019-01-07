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

    protected void longin_Click(object sender, EventArgs e)
    {
        SqlDataReader dr;
        //获取输入的用户名
        string username = tx_username.Text.Trim();
        string password = tx_password.Text.Trim();

        int type = RadioButtonList1.SelectedIndex;


        //连接数据库
        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connstr);

        //新建command对象

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;


        if (type == 0) //学生登陆
        {
            cmd.CommandText = "select * from [Student] where st_name=@loginname";
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
                    int pass = dr.GetInt32(0);
                    string sa = Convert.ToString(pass);
                    if (sa == password)
                    {
                        Session.Add("s_id", password);
                        tx_username.Text = "";
                        Response.Redirect("st_index.aspx");
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
        else //管理员登陆
        {
            cmd.CommandText = "select * from [Manager1] where username=@loginname";
            cmd.CommandType = CommandType.Text;
            //添加查询对象
            SqlParameter para = new SqlParameter("@loginname", SqlDbType.NVarChar,50);
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
                        Response.Redirect("m_index.aspx");
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

       
        conn.Close();

    }
}