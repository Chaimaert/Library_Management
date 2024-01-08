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
        protected void ReserverLivre_Click(object sender, CommandEventArgs e)
        {
            // Obtenir l'ID du livre à partir du bouton cliqué
            int Book_Id = Convert.ToInt32(e.CommandArgument);

            // Obtenir les informations du livre réservé à partir de la base de données
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Mindful_libraryConnectionString"].ConnectionString;
            string selectQuery = "SELECT * FROM Books WHERE Book_Id = @Book_Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Book_Id", Book_Id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Récupérer les informations du livre réservé
                            string Book_Name = reader["Book_Name"].ToString();
                            string Author_Name = reader["Author_Name"].ToString();
                            string Book_Type = reader["Book_Type"].ToString();
                            int Pages_Nbr = Convert.ToInt32(reader["Pages_Nbr"]);
                            decimal Price = Convert.ToDecimal(reader["Price"]);
                            int Disponibility = Convert.ToInt32(reader["Disponibility"]);

                            // Stocker les informations dans la session pour les transmettre à la page de réservation
                            Session["Book_Name"] = Book_Name;
                            Session["Author_Name"] = Author_Name;
                            Session["Book_Type"] = Book_Type;
                            Session["Pages_Nbr"] = Pages_Nbr;
                            Session["Price"] = Price;
                            Session["Disponibility"] = Disponibility;
                        }
                    }
                }
            }

            // Rediriger vers la page de réservation
            Response.Redirect("~/Reservation.aspx");
        }
    }
}


  


