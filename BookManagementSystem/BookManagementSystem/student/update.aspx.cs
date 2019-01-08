using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_update1 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGridView();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGridView();
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
            sql = "SELECT * FROM Student";
        }
        else {
            int id1 = Convert.ToInt32(id);
            sql = "SELECT * FROM Student WHERE st_id=" + id1;
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

    private void UpdateRecord(string id, string name, string sex,string dept,string class1,string credit,string password)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "UPDATE Student " +
                              "SET st_id = @id, st_name = @name,st_sex=@sex,st_dept=@dept,st_class=@class1,st_credit=@credit,st_pw=@password " +
                              "WHERE st_id = @id";
        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name",name);
            cmd.Parameters.AddWithValue("@sex", sex);
            cmd.Parameters.AddWithValue("@dept", dept);
            cmd.Parameters.AddWithValue("@class1",class1);
            cmd.Parameters.AddWithValue("@credit",credit);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert/Update Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }


    protected void GridViewEmployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewEmployee1.EditIndex = e.NewEditIndex; // turn to edit mode
        BindGridView(); // Rebind GridView to show the data in edit mode
    }

    protected void GridViewEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewEmployee1.EditIndex = -1; //swicth back to default mode
        BindGridView(); // Rebind GridView to show the data in default mode
    }

    protected void GridViewEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Accessing Edited values from the GridView
        //string id = ((Label)GridViewEmployee.Rows[e.RowIndex].Cells[3].FindControl("LabelID")).Text; //ID
        string id = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[0].FindControl("TextBoxEditid")).Text; //Employee
        string name = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[1].FindControl("TextBoxEditname")).Text; //Position
        string sex = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[2].FindControl("TextBoxEditsex")).Text; //Team
        string dept = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[3].FindControl("TextBoxEditdept")).Text;
        string class1 = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[4].FindControl("TextBoxEditclass")).Text;
        string credit= ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[5].FindControl("TextBoxEditcredit")).Text;
        string password = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[6].FindControl("TextBoxEditpw")).Text;
        UpdateRecord(id, name, sex,dept, class1,  credit, password); // call update method

        GridViewEmployee1.EditIndex = -1; //Turn the Grid to read only mode

        BindGridView(); // Rebind GridView to reflect changes made

        Response.Write("<script>alert('修改成功')</script>");

    }


}