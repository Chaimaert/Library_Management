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
                string username = TextBox1.Text.Trim();
                string password = TextBox2.Text.Trim();

                // Log the values received from the form
                Response.Write("<script>alert('Username: " + username + " | Password: " + password + "');</script>");

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "SELECT [username], [password] FROM user_login WHERE username = @username AND password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        // Log the SQL query being executed
                        Response.Write("<script>alert('Query: " + cmd.CommandText + "');</script>");

                        SqlDataReader dr = cmd.ExecuteReader();

                        // Log the number of rows retrieved
                        if (dr.HasRows)
                        {
                            int count = 0;
                            while (dr.Read())
                            {
                                count++;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('No rows retrieved');</script>");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Response.Write("<script>alert('SQL Error: " + ex.Message + "');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }





    }
}