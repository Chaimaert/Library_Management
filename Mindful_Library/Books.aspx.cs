using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Mindful_Library
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ReserveButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Get the Book_id from the CommandArgument
            string bookId = btn.CommandArgument;

            // Redirect to reservation page with the selected book_id in query string
            Response.Redirect("Reservation.aspx?Book_id=" + bookId);
        }


    }
}


  


