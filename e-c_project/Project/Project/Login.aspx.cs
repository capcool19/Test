using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using BusinessLogic;
using System.Data;

namespace Project
{

    public partial class Login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["d2"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ShowLabel"] == "1")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Invalid login. Please try again.";
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from [User] where Username = @user and Password = @pass";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", txtUsername.Text);
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (txtUsername.Text == "admin"&& txtPassword.Text=="admin")
            {
                Response.Redirect("");
            } 
            else if (dr.HasRows)
            {
                Session["user"] = txtUsername.Text;
                Response.Redirect("Default.aspx");
            }
            else
            {
                
                Response.Redirect("Login.aspx?ShowLabel=1");

            }
            con.Close();


            //SqlConnection con = new SqlConnection(cs);
            //string query = "select * from login where username = @user and password = @pass";
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@user", txtUsername.Text);
            //cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
            //con.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    Session["user"] = txtUsername.Text;
            //    Response.Redirect("Default.aspx");
            //}
            //else
            //{

            //    Response.Redirect("Login.aspx");

            //}
            //con.Close();

        }
    }
}
