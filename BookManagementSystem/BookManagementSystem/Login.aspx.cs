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
    DataBase db = new DataBase();

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void longin_Click(object sender, EventArgs e)
    {
        DataRow dr;
        string username = tx_username.Text.Trim();
        string password = tx_password.Text.Trim();

        int type = -1;
            type = RadioButtonList1.SelectedIndex;

        if (type == 0) //学生登陆
        {
            string sid = tx_username.Text.Trim();
            int id = 0;
            int flag = 0;
            try
            {
                id = Convert.ToInt32(sid);
            }
            catch
            {
                Response.Write("<script>alert('请选择正确的登陆类型')</script>");
                flag = 1;
           
            }
            string sql = "select * from [Student] where st_id=" + id;

            try
            {
                dr = db.GetDataRow(sql);
                if (dr!=null)
                {
                    string dbpw = (string)dr[6];
                    //Response.Write("<script>alert('" + password + "')</script>");
                    if (dbpw == password)
                    {
                        Session.Add("s_id", id);
                                          
                        tx_username.Text = "";
                        Response.Redirect("StudentIndex.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('密码错误')</script>");
                    }
                }
                else
                {
                    if (flag == 0)
                    {
                        Response.Write("<script>alert('用户不存在')</script>");
                    }
                }
            }
            catch (SqlException)
            {
                Response.Write("<script>alert('连接异常')</script>");
            }
        }
        else if(type==1)//管理员登陆
        {
            string sql2 = "select * from [Manager1] where username= N'" + username + "'";

            try
            {
                dr = db.GetDataRow(sql2);
                if (dr!=null)
                {
                    string dbpwadmin = (string)dr[2];
                    if (dbpwadmin == password)
                    {
                        Session.Add("loginname", username);
                        tx_username.Text = "";
                        Response.Redirect("AdminIndex.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('密码错误')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('用户不存在')</script>");
                }
            }
            catch (SqlException)
            {
                Response.Write("<script>alert('连接异常')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('选择登陆类型')</script>");
        }
    }
}