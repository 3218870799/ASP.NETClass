using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class book_delete : System.Web.UI.Page
{
    DataBase db = new DataBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGridView();
        }
    }
    private void BindGridView()
    {
        string sql;
        string id = TextBox1.Text;
        if (id == "")
        {
            sql = "SELECT * FROM Book";
        }
        else
        {
            int id1 = Convert.ToInt32(id);
            sql = "SELECT * FROM Book WHERE b_id=" + id1;
        }
        DataTable dt = new DataTable();  
        try
        {
            dt = db.GetDataSet(sql).Tables[0];
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
    }
    //删除Book
    private void DeleteRecord(string id)
    {
        string sqlStatement = "DELETE FROM Book WHERE b_id = "+id;
        try
        {
            db.ExecuteSQL(sqlStatement);
            Response.Write("<script>alert('删除成功')</script>");
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Deletion Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
    }
    //删除Book_sort
    private void DeleteRecord1(string id)
    {
        string sqlStatement = "DELETE FROM Book_sort WHERE b_id = "+id;

        try
        {
            db.ExecuteSQL(sqlStatement);
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Deletion Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }  
    }
    protected void GridViewEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = ((Label)GridViewEmployee1.Rows[e.RowIndex].Cells[0].FindControl("Labelid")).Text;
        //多对多关系 先删除book_sort表
        DeleteRecord1(id);
        DeleteRecord(id); 
        BindGridView(); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGridView();
    }
}