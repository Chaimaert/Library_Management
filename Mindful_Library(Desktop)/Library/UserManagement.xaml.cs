
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static Library.LibraryContext;

namespace Library
{
    public partial class UserManagement : Window
    {
        private ObservableCollection<LibraryContext.User> users = new ObservableCollection<LibraryContext.User>();

        public UserManagement()
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
                    SqlCommand cmd = new SqlCommand("select * from Users", con);
                    DataTable dt = new DataTable();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    dgUsers.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public bool isValid()
        {
            if (txtFirstName.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtLastName.Text == string.Empty)
            {
                MessageBox.Show("Last Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Email is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }




        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("INSERT INTO [Users] (First_Name, Last_Name, Email) VALUES (@First_Name, @Last_Name, @Email)", con);

                        cmd.Parameters.AddWithValue("@First_Name", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@Last_Name", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                        cmd.ExecuteNonQuery();
                    }

                    LoadGrid();
                    MessageBox.Show("Successfully registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFormFields();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearFormFields()
        {


        }

        
        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgUsers.SelectedItem != null)
                {
                    DataRowView selectedUser = (DataRowView)dgUsers.SelectedItem;
                    int userId = (int)selectedUser["User_Id"];

                    using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("UPDATE Users SET First_Name = @FirstName, Last_Name = @LastName, Email = @Email WHERE User_Id = @UserId", con);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text); // Assuming txtEmail is the TextBox for Email

                        cmd.ExecuteNonQuery();
                    }

                    LoadGrid();

                    MessageBox.Show("Successfully updated", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please select a user to update", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgUsers.SelectedItem != null)
                {
                    DataRowView selectedUser = (DataRowView)dgUsers.SelectedItem;
                    int userId = (int)selectedUser["User_Id"];

                    using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE User_Id = @UserId", con);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.ExecuteNonQuery();
                    }

                    LoadGrid();

                    MessageBox.Show("Successfully deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please select a user to delete", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgUsers.SelectedItem != null)
            {
                DataRowView selectedUser = (DataRowView)dgUsers.SelectedItem;

                
                txtFirstName.Text = selectedUser["First_Name"].ToString();
                txtLastName.Text = selectedUser["Last_Name"].ToString();
                txtEmail.Text = selectedUser["Email"].ToString();
            }
        }

        private void HomeUser_Click(object sender, RoutedEventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void ClearUser_Click(object sender, RoutedEventArgs e)
        {
            
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
           
            
        }

    }
}
