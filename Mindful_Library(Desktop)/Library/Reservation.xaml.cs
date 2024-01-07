using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using static Library.LibraryContext;

namespace Library
{
    public partial class ReservationManagement : Window
    {
        private ObservableCollection<Reservation> reservationList = new ObservableCollection<Reservation>();

        public ReservationManagement()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False");

        public void LoadGrid()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Reservations", con);
                    DataTable dt = new DataTable();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    dgReservations.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public bool isValid()
        {
            if (txtMemberID.Text == string.Empty)
            {
                MessageBox.Show("User Id is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtBookName.Text == string.Empty)
            {
                MessageBox.Show("Book Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (dpReservationDate.Text == string.Empty)
            {
                MessageBox.Show("Date is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void AddReservation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    // Check if the book is available
                    string bookName = txtBookName.Text;
                    if (!IsBookAvailable(bookName))
                    {
                        MessageBox.Show($"The book '{bookName}' is not available for reservation.", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();

                        // Check if the provided Member_Id exists in the Members table
                        int memberId;
                        if (!int.TryParse(txtMemberID.Text, out memberId) || !MemberExists(memberId))
                        {
                            MessageBox.Show("Invalid Member ID. Please enter a valid Member ID.", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        // Insert the reservation into the Reservations table
                        SqlCommand cmd = new SqlCommand("INSERT INTO Reservations (Member_Id, RBook_Name, Reservation_Date) VALUES (@Member_Id, @RBook_Name, @Reservation_Date)", con);

                        cmd.Parameters.AddWithValue("@Member_Id", memberId);
                        cmd.Parameters.AddWithValue("@RBook_Name", bookName);
                        cmd.Parameters.AddWithValue("@Reservation_Date", dpReservationDate.SelectedDate);

                        cmd.ExecuteNonQuery();
                    }

                    LoadGrid();
                    MessageBox.Show("Reservation added successfully", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFormFields();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsBookAvailable(string bookName)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT Disponibility FROM Books WHERE Book_Name = @BookName", con);
                cmd.Parameters.AddWithValue("@BookName", bookName);

                object disponibility = cmd.ExecuteScalar();


                if (disponibility != null && disponibility.ToString().Trim().Equals("No", StringComparison.OrdinalIgnoreCase))
                {
                    // Book is not available
                    return false;
                }

                // Book is available or the Disponibility column is not 'No'
                return true;
            }
        }

        private bool MemberExists(int memberId)
        {
            // Check if the member with the provided Member_Id exists in the Members table
            using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Members WHERE Member_Id = @MemberId", con);
                cmd.Parameters.AddWithValue("@MemberId", memberId);

                return (int)cmd.ExecuteScalar() > 0;
            }
        }


        private bool UserExists(int userId)
        {
            // Check if the user with the provided User_Id exists in the Users table
            using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Id = @UserId", con);
                cmd.Parameters.AddWithValue("@UserId", userId);

                return (int)cmd.ExecuteScalar() > 0;
            }
        }


        private void ClearFormFields()
        {


        }

        private void UpdateReservation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgReservations.SelectedItem != null)
                {
                    DataRowView selectedReservation = (DataRowView)dgReservations.SelectedItem;
                    int reservationId = (int)selectedReservation["Reservation_Id"];

                    using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("UPDATE Reservations SET Member_Id = @MemberId, RBook_Name = @BookName, Reservation_Date = @ReservationDate WHERE Reservation_Id = @ReservationId", con);
                        cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                        cmd.Parameters.AddWithValue("@MemberId", txtMemberID.Text);
                        cmd.Parameters.AddWithValue("@BookName", txtBookName.Text);
                        cmd.Parameters.AddWithValue("@ReservationDate", dpReservationDate.SelectedDate);

                        cmd.ExecuteNonQuery();
                    }

                    LoadGrid();

                    MessageBox.Show("Successfully updated", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please select a reservation to update", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void DeleteReservation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgReservations.SelectedItem != null)
                {
                    DataRowView selectedReservation = (DataRowView)dgReservations.SelectedItem;
                    int reservationId = (int)selectedReservation["Reservation_Id"];

                    using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("DELETE FROM Reservations WHERE Reservation_Id = @ReservationId", con);
                        cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                        cmd.ExecuteNonQuery();
                    }

                    LoadGrid();

                    MessageBox.Show("Successfully deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please select a reservation to delete", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void HomeReservation_Click(object sender, RoutedEventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }
        private void dgReservations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgReservations.SelectedItem != null)
            {
                DataRowView selectedReservation = (DataRowView)dgReservations.SelectedItem;

                
                txtMemberID.Text = selectedReservation["Member_Id"].ToString();
                txtBookName.Text = selectedReservation["RBook_Name"].ToString();
                dpReservationDate.Text = selectedReservation["Reservation_Date"].ToString();
            }
        }

        private void ClearReservation_Click(object sender, RoutedEventArgs e)
        {
            txtMemberID.Text = string.Empty;
            txtBookName.Text = string.Empty;
            dpReservationDate.SelectedDate = null;
            
        }

    }
}
