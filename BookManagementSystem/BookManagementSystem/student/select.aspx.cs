using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_select : System.Web.UI.Page
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
        int type = DropDownList1.SelectedIndex;
        string sql;
        string id = input.Text;
        if (id == "")
        {
            sql = "SELECT * FROM Student";
        }
        else
        {
            if (type == 0)
            {
                int id1 = Convert.ToInt32(id);
                sql = "SELECT * FROM Student WHERE st_id=" + id1;
            }
            else if (type == 1)
            {
                sql = "SELECT * FROM Student WHERE st_name=N'" + id +"'";
            }
            else {
                sql = "SELECT * FROM Student WHERE st_dept=N'" + id+"'";
            }


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

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGridView();
    }
}