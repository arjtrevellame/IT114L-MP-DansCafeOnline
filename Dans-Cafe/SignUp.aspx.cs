using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Login.App.Users;
using System.Linq;

namespace DansCafe
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (validSignUp())
            {
                string newEmail = Email.Text;

                if (!ExistUser(newEmail))
                {
                    var userRepo = new RepositoryUsers();

                    userRepo.NewUser(new User()
                    {
                        FirstName = Fname.Text,
                        LastName = Lname.Text,
                        Email = Email.Text,
                        Username = Username.Text,
                        Password = Password.Text,
                    });

                    ClearValues();

                    Response.Write("<script>alert('You are now registered!');</script>");
                    Response.Write("<script>window.setTimeout(function(){ window.location.href = 'login.aspx'; }, 1000);</script>");
                } 
                else
                {
                    string alreadyExist = "Email already used.";
                    Response.Write($"<script>alert('{alreadyExist}')</script>");
                    ClearValues();
                }
            }
                
                
            
        }

        protected bool validSignUp()
        {
            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void ClearValues()
        {
            Fname.Text = "";
            Lname.Text = "";
            Email.Text = "";
            Username.Text = "";
            IniPword.Text = "";
            Password.Text = "";
        }

        protected bool ExistUser(string newUser)
        {
            RepositoryUsers repos = new RepositoryUsers();
            IEnumerable<User> userPeople = repos.GetAllUsers();

            return userPeople.Any(user => user.Email == newUser);
        }
    }
}