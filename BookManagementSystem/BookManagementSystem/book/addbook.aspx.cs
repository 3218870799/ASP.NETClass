using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class book_addbook : System.Web.UI.Page
{
    DataBase db = new DataBase();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //book表添加
    private void addbook() {
        string sid = b_id.Text.Trim();
        int id = Convert.ToInt32(sid);
        string name = b_name.Text.Trim();
        string author = b_author.Text.Trim();
        string press = b_press.Text.Trim();
        string num = b_num.Text.Trim();
        int num1 = Convert.ToInt32(num);
        string sql = "INSERT INTO [Book] values("+id+","+name+","+author+","+press+","+num1+")";
        try
        {
            db.ExecuteSQL(sql);
        }
        catch
        {
            Response.Write("发生异常");
        }
    }
    //book_sort表添加
    private void addsort() {
        string name = DropDownList1.SelectedItem.Text;
        int sid = getsortid(name);
        string sid1 = b_id.Text.Trim();
        int id1 = Convert.ToInt32(sid1);
        string sql = "INSERT INTO [Book_sort] values("+sid+","+id1+","+name+")";

        try
        {
            db.ExecuteSQL(sql);
            Response.Write("<script>alert('添加成功')</script>");
            Response.Redirect("select.aspx");

        }
        catch
        {
            Response.Write("发生异常 lei");
        }

    }
    //返回图书类别的id
    private int getsortid(string sort_name)
    {
        int id=0;
        string sql = "SELECT * FROM Sort WHERE sort_name=N'"+sort_name+"'";
        try
        {
            DataRow dr = db.GetDataRow(sql);
            id = (int)dr[0];
            Response.Write(id);
        }
        catch
        {
            Response.Write("发生异常 id");           
        }
        return id;
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        addbook();
        addsort();
    }
}