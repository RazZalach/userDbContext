using System;
using System.Data.SqlClient;


namespace WebApplication3
{
    public partial class Login : System.Web.UI.Page
    {
        public string st = "";
        public string ConnectionStringDB = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\mekifY.mdf;Integrated Security=True;Connect Timeout=30";
        public SqlConnection connection;
        public SqlCommand command;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["submit"] != null) // Check if the submit button was clicked
            {
                string uName = Request.Form["uName"]; // Get the username from the form
                string email = Request.Form["email"]; // Get the email from the form
                string password = Request.Form["password"]; // Get the password from the form

                string hashedPass = PasswordHasher.HashPassword(password);
                // Authenticate the user
                User authenticatedUser = AuthenticateUser(uName, email, hashedPass);

                if (authenticatedUser != null) // If authentication succeeds
                {
                    // Display user details
                    lblResult.Text = "<table>";
                    lblResult.Text += $"<tr><td>מזהה משתמש:</td><td>{authenticatedUser.UserId}</td></tr>";
                    lblResult.Text += $"<tr><td>שם משתמש:</td><td>{authenticatedUser.uName}</td></tr>";
                    lblResult.Text += $"<tr><td>שם פרטי:</td><td>{authenticatedUser.fName}</td></tr>";
                    lblResult.Text += $"<tr><td>שם משפחה:</td><td>{authenticatedUser.lName}</td></tr>";
                    lblResult.Text += $"<tr><td>כתובת דוא\"ל:</td><td>{authenticatedUser.email}</td></tr>";
                    lblResult.Text += "</table>";

                    lblResult.Text += "<br/> <a style='text-decoration:none; margin-left:10 %; font-size:15px; border-radius:10px; background-color:#007bff; color:#fff;' href='allusers.aspx'> מעבר לכל המשתמשים</a>";

                    Session["uName"] = authenticatedUser.uName;
                    Session["fName"] = authenticatedUser.fName;
                    Session["user"] = authenticatedUser;
                }
                else // If authentication fails
                {
                    lblResult.Text = "הפרטים שהוזנו אינם נכונים";
                }
            }
        }
        public User AuthenticateUser(string uName, string email, string password)
        {
            User authenticatedUser = null;
            connection = new SqlConnection(ConnectionStringDB);

            try
            {
                connection.Open();

                // Query to check if the provided username, email, and password match any records
                string query = $"SELECT * FROM Users WHERE uName = '{uName}' AND email = '{email}' AND password = '{password}' ";
                command = new SqlCommand(query, connection);


                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // If a user is found, create a User object with the retrieved data
                    authenticatedUser = new User(
                        Convert.ToInt32(reader["UserId"]),
                        Convert.ToString(reader["uName"]),
                        Convert.ToString(reader["fName"]),
                        Convert.ToString(reader["lName"]),
                        Convert.ToString(reader["email"]),
                        Convert.ToString(reader["password"])
                    );
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                // You may want to log the exception details or handle them differently
                Console.WriteLine("Error authenticating user: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return authenticatedUser;
        }

    }
}