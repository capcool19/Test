using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace Project
{
    public partial class Register : System.Web.UI.Page
    {
        UserLogic logic = new UserLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ShowLabel"] == "1")
            {
                lblDisplay.Visible = true;
                lblDisplay.Text = "Login Sucessfull redirect to the Login Page.";
                lblDisplay.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                
                    Insert();
                Response.Redirect("Register.aspx?ShowLabel=1");
                
            }
            else
            {

            }
        }

        private void Insert()
        {
            try
            {
                var strName = txtUsername.Text.ToString().Trim();
                var strPassword = txtPassword.Text.ToString().Trim();
                var user = new DataAcessLayer.Models.User
                {
                    Username = strName,
                    Password = strPassword
                };
                logic.CreateNewUser(user);
            }
            catch (Exception ex)
            {
                lblDisplay.Visible = true;
                lblDisplay.Text = ex.Message;
            }
        }
    }
}

