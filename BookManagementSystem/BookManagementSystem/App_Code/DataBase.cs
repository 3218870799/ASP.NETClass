using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// DataBase 的摘要说明
/// </summary>
/// 

public class DataBase
{
    private const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MyDb.mdf;Integrated Security=True; pooling=false";

    public DataBase()
    { }
    //获取连接
    public static SqlConnection DBCon()
    {
        return new SqlConnection(           
            ConnectionString
            );
    }
    //根据SQL获取DataSet对象
    public DataSet GetDataSet(String SqlString)
    {
        SqlConnection conn = DBCon();
        conn.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(SqlString, conn);
        DataSet dataset = new DataSet();

        adapter.Fill(dataset);
                
        conn.Close();
        return dataset;
    }
    //执行SQL语句
    public int ExecuteSQL(String SqlString)
    {
        SqlConnection conn = DBCon();
        conn.Open();
        SqlCommand comm = new SqlCommand(SqlString, conn);
        int result = comm.ExecuteNonQuery();
        return result;
    }
    //获取一行数据
    public DataRow GetDataRow(string SqlString)
    {
        DataSet dataset = GetDataSet(SqlString);
        if (dataset.Tables[0].Rows.Count > 0)
            return dataset.Tables[0].Rows[0];
        else
            return null;
    }
}