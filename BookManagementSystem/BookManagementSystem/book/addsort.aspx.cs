using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class book_addsort : System.Web.UI.Page
{
    DataBase db = new DataBase();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string sid = id.Text.Trim();
        int id1 = Convert.ToInt32(sid);
        string SortName = name.Text.Trim();
        string sql = "INSERT INTO [Sort] values("+id1+","+SortName+")";
        try
        {
            db.ExecuteSQL(sql);
            Response.Write("<script>alert('添加成功')</script>");
        }
        catch
        {
            Response.Write("发生异常");
        }
    }
}
