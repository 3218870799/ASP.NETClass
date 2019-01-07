using System;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// DataBase 的摘要说明
/// </summary>
/// 

public class DataBase
{
    private const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|" +
        "\\MyDb.mdf;Integrated Security=True";

    public DataBase()
    { }
    public static SqlConnection DBCon()
    {
        return new SqlConnection(
            //"server=127.0.0.1;database=SMDB;user=sa;pwd=1234"
            ConnectionString
            );
    }

    public void ExecuteSQL(String SqlString)
    {
        SqlConnection conn = DBCon();
        conn.Open();
        SqlCommand comm = new SqlCommand(SqlString, conn);
        comm.ExecuteNonQuery();
    }
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
    public DataRow GetDataRow(string SqlString)
    {
        DataSet dataset = GetDataSet(SqlString);
        if (dataset.Tables[0].Rows.Count > 0)
            return dataset.Tables[0].Rows[0];
        else
            return null;
    }
    public string GetDataString(string SqlString)
    {
        DataSet dataset = GetDataSet(SqlString);
        string result = dataset.ToString();
        return result;
    }




}