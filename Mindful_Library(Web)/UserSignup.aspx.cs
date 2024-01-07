using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mindful_Library
{
    public partial class SignUp : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //SignUp button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMember())
            {
                Response.Write("<script>alert('Member Already Exist, try another username');</script>");
            }
            else
            {
                if (txtPassword.Text.Trim() != TextBox1.Text.Trim())
                {
                    Response.Write("<script>alert('Password do not match, try again');</script>");
                }
                else
                {
                    SignupNewUser();
                }
            }
        }


        // user defined method
        bool checkMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from user_signup where username='" + txtUserID.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void SignupNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO user_signup(name,username,email,password) values(@name,@username,@email,@password)",
                    con);

                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@username", txtUserID.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign up successful');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}