using System;
using System.Data.SqlClient;

namespace WebApplication3
{
    public partial class AllUsers : System.Web.UI.Page
    {
        public SqlConnection connection;
        public SqlCommand command;
        SqlDataReader reader;
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\mekifY.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            User authUser = (User)Session["user"];
            if (authUser == null)
            {
                ltluName.Text = "עליך להתחבר קודם!";
                searchQuery.Text = "עליך להתחבר קודם!";
                searchButton.Enabled = false;
                searchButton.CssClass = "disabledButton";

                cancelButton.Enabled = false;
                cancelButton.CssClass = "disabledButton";

                logOutButton.Enabled = false;
                logOutButton.CssClass = "disabledButton";

                update_Button.Enabled = false;
                update_Button.CssClass = "disabledButton";

                return;
            }
            else
            {
                ltluName.Text ="שלום "+ Session["uName"];
                DisplayAllUsers();
            }
            
        }

        protected void DisplayAllUsers()
        {
            
            string query = "SELECT * FROM Users";

            connection = new SqlConnection(connectionString);
            command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    UsersRepeater.DataSource = reader;
                    UsersRepeater.DataBind();
                }
                else
                {
                    Response.Write("No users found.");
                }

              
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        protected void SearchButton_Click(object sender, EventArgs e)
        {

            string field = searchField.SelectedValue;
            string querySearch = searchQuery.Text;
            string query = "SELECT * FROM Users WHERE " + field + " LIKE '%" + querySearch + "%'";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                UsersRepeater.DataSource = reader;
                UsersRepeater.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            DisplayAllUsers();
            searchQuery.Text = ""; // Clear the search query textbox
        }
        protected void logOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        protected void update_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("updateUser.aspx");
        }


    }
}
