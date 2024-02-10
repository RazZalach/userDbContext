using System;
using System.Data.SqlClient;

namespace WebApplication3
{
    public partial class updateUser : System.Web.UI.Page
    {
        public string ConnectionStringDB = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\mekifY.mdf;Integrated Security=True;Connect Timeout=30";
        public SqlConnection connection;
        public SqlCommand command;
        public User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                user = (User)Session["user"];
            }
            else
            {
                UpdateButton.Enabled = false;
                UpdateButton.CssClass = "disabledButton";
                ltlresult.Text = "עליך להתחבר קודם!";
            }
        }
        protected void update_Click(object sender,EventArgs e)
        {
            string updateValue = updateTxt.Text;
            string choosenfield = updateFields.SelectedValue;
            if(choosenfield == "password")
            {
                updateValue = PasswordHasher.HashPassword(updateValue);
            }
            string query = $"Update Users set {choosenfield} = '{updateValue}' where UserId=${user.UserId}";
            connection = new SqlConnection(ConnectionStringDB);
            command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    ltlresult.Text = "עדכון המשתמש צלח";
                }
                else
                {
                    ltlresult.Text = "עדכון המשתמש נכשל";
                }
            }
            catch (Exception ex)
            {
                ltlresult.Text = "Error updating user: " + ex.Message;
            }
        }
   
        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("allusers.aspx");
        }
    }
}