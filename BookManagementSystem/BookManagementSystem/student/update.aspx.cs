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
    DataBase db = new DataBase();
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

    private void UpdateRecord(string id, string name, string sex,string dept,string class1,string credit,string password)
    {
        string sqlStatement = "UPDATE Student " +
                              "SET st_id = "+id+", st_name = "+name+",st_sex="+sex+",st_dept="+dept+",st_class="+class1+",st_credit="+credit+",st_pw="+password+"" +
                              "WHERE st_id = "+id+"";
        try
        {
            db.ExecuteSQL(sqlStatement);
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert/Update Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
    }
    protected void GridViewEmployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewEmployee1.EditIndex = e.NewEditIndex; // 切换到可编辑模式
        BindGridView(); //重新绑定数据
    }
    protected void GridViewEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewEmployee1.EditIndex = -1; //通过 EditIndex 判断 GridView 中的某一 Row，是否处于编辑状态。
        //编辑状态中的 EditIndex >= 0; EditIndex < 0 或 EditIndex = -1 都表示 GridView 中没有正在编辑的Row。
        BindGridView(); 
    }
    protected void GridViewEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string id = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[0].FindControl("TextBoxEditid")).Text; //Employee
        string name = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[1].FindControl("TextBoxEditname")).Text; //Position
        string sex = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[2].FindControl("TextBoxEditsex")).Text; //Team
        string dept = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[3].FindControl("TextBoxEditdept")).Text;
        string class1 = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[4].FindControl("TextBoxEditclass")).Text;
        string credit= ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[5].FindControl("TextBoxEditcredit")).Text;
        string password = ((TextBox)GridViewEmployee1.Rows[e.RowIndex].Cells[6].FindControl("TextBoxEditpw")).Text;
        UpdateRecord(id, name, sex,dept, class1,  credit, password); // 调用函数
        GridViewEmployee1.EditIndex = -1; 
        BindGridView(); 
        Response.Write("<script>alert('修改成功')</script>");

    }


}