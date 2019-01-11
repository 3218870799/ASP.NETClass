using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_money : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGridView();
        }
    }
    private string GetConnectionString()
    {
        //Where MyConsString is the connetion string that was set up in the web config file
        //return System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString;
        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        return connstr;
    }

    private void BindGridView()
    {
        string sql;
        string id = TextBox1.Text;
        if (id == "")
        {
            sql = "SELECT * FROM Delay_money";
        }
        else
        {
            int id1 = Convert.ToInt32(id);
            sql = "SELECT * FROM Delay_money WHERE st_id=" + id1;
        }
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(GetConnectionString());
        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            //添加查询对象
            //SqlParameter para = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            //para.Value = id;
            //cmd.Parameters.Add(para);
            /*string sqlStatement = "SELECT * FROM Manager1 WHERE username=@id";
            SqlParameter para = new SqlParameter("@id",SqlDbType.NVarChar,50);          
            para.Value = id1;
            SqlCommand sqlCmd = new SqlCommand(sqlStatement, connection);*/
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                GridViewEmployee1.DataSource = dt;
                GridViewEmployee1.DataBind();
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }
    private void DeleteRecord(string id)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "DELETE FROM Delay_money WHERE st_id = @id";

        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('删除成功')</script>");
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Deletion Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }
    protected void GridViewEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //返回选中行的ID
        string id = ((Label)GridViewEmployee1.Rows[e.RowIndex].Cells[0].FindControl("Labelid")).Text;
        DeleteRecord(id); //传参，调用删除函数

        BindGridView(); // 重新绑定数据

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGridView();
    }
}