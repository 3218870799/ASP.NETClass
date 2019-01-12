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
            sql = "SELECT * FROM Delay_money";
        }
        else
        {
            int id1 = Convert.ToInt32(id);
            sql = "SELECT * FROM Delay_money WHERE st_id=" + id1;
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
    private void DeleteRecord(string id)
    {
        string sqlStatement = "DELETE FROM Delay_money WHERE st_id = "+id;

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