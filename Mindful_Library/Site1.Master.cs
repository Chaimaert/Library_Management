using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mindful_Library
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; //login
                    LinkButton2.Visible = true; //signup

                    LinkButton3.Visible = false; //logout
                    LinkButton7.Visible = false; //hello_user
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //login
                    LinkButton2.Visible = false; //signup

                    LinkButton3.Visible = true; //logout
                    LinkButton7.Visible = true; //hello_user
                    LinkButton7.Text = "Hello" + Session["username"].ToString();
                }

            }
            catch 
            {

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

        }
    }
}