using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGridView();
        }
    }

    private string GetConnectionString()
    {
        //Where MyConsString is the connetion string that was set up in the web config file
        //return System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString;
        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        return connstr;
    }
    private void DeleteRecord(string ID)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "DELETE FROM Manager1 WHERE Id = @Id";

        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Deletion Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }

    private void BindGridView()
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(GetConnectionString());
        try
        {
            connection.Open();
            string sqlStatement = "SELECT * FROM Manager1";
            SqlCommand sqlCmd = new SqlCommand(sqlStatement, connection);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridViewEmployee.DataSource = dt;
                GridViewEmployee.DataBind();
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

    private void AddNewRecord(string employee, string position, string team)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "INSERT INTO Manager1" +
                              "(username,password,realname)" +
                               "VALUES (@Employees,@Position,@Team)";
        try
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@Employees", employee);
            cmd.Parameters.AddWithValue("@Position", position);
            cmd.Parameters.AddWithValue("@Team", team);
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Extract the TextBoxes that is located under the footer template
        TextBox tbEmployee = (TextBox)GridViewEmployee.FooterRow.Cells[0].FindControl("TextBoxEmployee");
        TextBox tbPosition = (TextBox)GridViewEmployee.FooterRow.Cells[1].FindControl("TextBoxPosition");
        TextBox tbTeam = (TextBox)GridViewEmployee.FooterRow.Cells[2].FindControl("TextBoxTeam");
        if (tbEmployee.Text.Trim() != "" && tbPosition.Text.Trim() != "" && tbTeam.Text.Trim() != "")
        {
            //call the method for adding new records to database and pass the necessary parameters
            AddNewRecord(tbEmployee.Text, tbPosition.Text, tbTeam.Text);
            //Re-Bind the GridView to reflect the changes made
            BindGridView();
        }
    }


    private void UpdateRecord(string id, string employee, string position, string team)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "UPDATE Manager1 " +
                              "SET username = @Employees, password = @Position, realname = @Team " +
                              "WHERE Id = @Id";
        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@Employees", employee);
            cmd.Parameters.AddWithValue("@Position", position);
            cmd.Parameters.AddWithValue("@Team", team);
            cmd.Parameters.AddWithValue("@Id", id);
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
        GridViewEmployee.EditIndex = e.NewEditIndex; // turn to edit mode
        BindGridView(); // Rebind GridView to show the data in edit mode
    }

    protected void GridViewEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewEmployee.EditIndex = -1; //swicth back to default mode
        BindGridView(); // Rebind GridView to show the data in default mode
    }

    protected void GridViewEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Accessing Edited values from the GridView
        string id = ((Label)GridViewEmployee.Rows[e.RowIndex].Cells[3].FindControl("LabelID")).Text; //ID
        string employee = ((TextBox)GridViewEmployee.Rows[e.RowIndex].Cells[0].FindControl("TextBoxEditEmployee")).Text; //Employee
        string position = ((TextBox)GridViewEmployee.Rows[e.RowIndex].Cells[1].FindControl("TextBoxEditPosition")).Text; //Position
        string team = ((TextBox)GridViewEmployee.Rows[e.RowIndex].Cells[2].FindControl("TextBoxEditTeam")).Text; //Team

        UpdateRecord(id, employee, position, team); // call update method

        GridViewEmployee.EditIndex = -1; //Turn the Grid to read only mode

        BindGridView(); // Rebind GridView to reflect changes made

        Response.Write("Update Seccessful!");

    }

    protected void GridViewEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //get the ID of the selected row
        string id = ((Label)GridViewEmployee.Rows[e.RowIndex].Cells[3].FindControl("LabelID")).Text;
        DeleteRecord(id); //call the method for delete

        BindGridView(); // Rebind GridView to reflect changes made

    }


}