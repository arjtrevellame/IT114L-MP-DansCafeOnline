using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Login.App.Users;


namespace DansCafe
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            var userRepo = new RepositoryUsers();

            var currentUser = userRepo.LogIn(userNtxtbox.Text);

            if (currentUser != null && currentUser.Any())
            {
                foreach (var user in currentUser)
                {
                    if (user.Username != null)
                    {
                        if (user.Password == passtxtbox.Text)
                        {
                            Response.Write("<script>window.setTimeout(function(){ window.location.href = 'home.aspx'; }, 1000);</script>");
                        }
                        else
                        {
                            string wrongPass = "Incorrect Password";
                            Response.Write($"<script>alert('{wrongPass}')</script>");
                        }
                    }
                    else
                    {
                        string notUser = "User does not exist.";
                        Response.Write($"<script>alert('{notUser}')</script>");
                    }
                }
            }

            //var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Aaliyah Gutierrez\\source\\repos\\Login\\Login\\App_Data\\Users.mdf\";Integrated Security=True";

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //}
        }
    }
}