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
    DataBase db = new DataBase();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {

        string sid = st_id.Text.Trim();
        int id = Convert.ToInt32(sid);
        string  Name = st_name.Text.Trim();

        string Sex = st_sex.Text.Trim();
        string dept = st_dept.Text.Trim();
        string StudentClass = st_class.Text.Trim();
        string s_credit= st_credit.Text.Trim();
        int credit = Convert.ToInt32(s_credit);
        string pw = st_pw.Text.Trim();
       string sql  = "INSERT INTO [Student] values("+id+",'"+Name+"','"+Sex+"','"+dept+"','"+StudentClass+"',"+credit+",'"+pw+"')";
        try
        {
            db.ExecuteSQL(sql);            
            Response.Redirect("select.aspx");
            Response.Write("<script>alert('添加成功')</script>");

        }
        catch {
            Response.Write("发生异常");
        }
    }

}