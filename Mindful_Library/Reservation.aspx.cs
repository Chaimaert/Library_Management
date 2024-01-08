using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mindful_Library
{
    public partial class Reservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Vérifiez si l'ID du livre réservé est présent dans l'URL
                if (Request.QueryString["Book_Id"] != null)
                {
                    // Obtenez l'ID du livre réservé à partir de l'URL
                    int Book_Id = Convert.ToInt32(Request.QueryString["Book_Id"]);

                    // Récupérez les informations du livre réservé à partir de la base de données
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                    string selectQuery = "SELECT * FROM Books WHERE Book_id = @Book_Id";

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
                                    // Affichez les informations du livre réservé
                                    Label2.Text = reader["Book_Name"].ToString();
                                    Label3.Text = reader["Author_Name"].ToString();
                                    Label4.Text = reader["Book_Type"].ToString();
                                    Label8.Text = reader["Pages_Nbr"].ToString();
                                    Label10.Text = reader["Price"].ToString();
                                    Label12.Text = reader["Disponibility"].ToString();
                                    // Ajoutez d'autres labels pour d'autres informations si nécessaire
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
