using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mindful_Library
{
    public partial class UserLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Login
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from user_login where username='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Response.Write("<script>alert('Login Successful');</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["role"] = "user";
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid properties');</script>");
                }

            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

           // Response.Write("<script>alert('Button clicked');</script>");
        }
    }
}