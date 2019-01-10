using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class book_select : System.Web.UI.Page
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

        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        return connstr;
    }

    private void BindGridView()
    {
        int type = DropDownList1.SelectedIndex;
        string sql;
        string id = input.Text;
        if (id == "")
        {
            sql = "SELECT * FROM Book_info";
        }
        else
        {
            if (type == 0)
            {
                int id1 = Convert.ToInt32(id);
                sql = "SELECT * FROM Book_info WHERE b_id=" + id1;
            }
            else if (type == 1)
            {
                sql = "SELECT * FROM Book_info WHERE b_author=N'" + id + "'";
            }
            else
            {
                sql = "SELECT * FROM Book_info WHERE sort_name=N'" + id + "'";
            }


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

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGridView();
    }
}