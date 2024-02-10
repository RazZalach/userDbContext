using System;
using System.Data.SqlClient;

namespace WebApplication3
{
    public partial class Register : System.Web.UI.Page
    {
        public string st = "";
        public string ConnectionStringDB = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\mekifY.mdf;Integrated Security=True;Connect Timeout=30";
        public SqlConnection connection;
        public SqlCommand command;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Form["submit"] != null)
            {
               
                string uname = Request.Form["uName"];
                string fname = Request.Form["fName"];
                string lname = Request.Form["lName"];
                string email = Request.Form["email"];
                string password = Request.Form["password"];

                string HashedPassword = PasswordHasher.HashPassword(password);

                User newuser = new User(uname, fname, lname, email, HashedPassword);

                int resultAdd = AddNewUserDb(newuser);

                ltl.Text = $"{resultAdd}";
                if (resultAdd > 0)
                {
                    lblDbResult.Text = "User Added Successfully to DataBase!";
                }
                else if (resultAdd == -1)
                {
                    lblDbResult.Text = "User Already Exists in The DataBase!";
                    return;
                }
                st += "<table dir='ltr' border='1'>";
                st += "<tr> <th colspan='2'> הפרטים שהתקבלו: </th> </tr>";
                st += "<tr><td>user name: </td><td>"+ newuser.uName + "</td></tr>";
                st += "<tr><td>first name: </td><td>" + newuser.fName + "</td></tr>";
                st += "<tr><td>last name: </td><td>" + newuser.lName + "</td></tr>";
                st += "<tr><td>email: </td><td>" + newuser.email + "</td></tr>";
                st += "<tr><td>password: </td><td>" + newuser.password + "</td></tr>";

                st += "</table>";
                lblResult.Text = st;

              
            }
        }
        public int AddNewUserDb(User user)
        {
            int rowsAffected = 0;
            connection = new SqlConnection(ConnectionStringDB);

            try
            {
                connection.Open();

                // Check if the user already exists by email
                string checkQuery = $"SELECT COUNT(*) FROM Users WHERE email = '{user.email}'";
                command = new SqlCommand(checkQuery, connection);
                int existingUsersCount = (int)command.ExecuteScalar();

                if (existingUsersCount == 0) // User does not exist, proceed with insertion
                {
                    string query = $"INSERT INTO Users (uName, fName, lName, email, password)" +
                                   $" VALUES ('{user.uName}','{user.fName}','{user.lName}','{user.email}','{user.password}')";
                    command = new SqlCommand(query, connection);
                    rowsAffected = command.ExecuteNonQuery();
                }
                else
                {
                    // User already exists, handle accordingly
                    rowsAffected = -1;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                // You may want to log the exception details or handle them differently
                Console.WriteLine("Error inserting new user: " + ex.Message);
            }
            finally
            {
              
                    connection.Close();
            }

            return rowsAffected;
        }

    }
}