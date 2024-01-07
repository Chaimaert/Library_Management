using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace Library
{
    public partial class BookManagement : Window
    {
        private ObservableCollection<Book> booksList = new ObservableCollection<Book>();
        
        public BookManagement()
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
                    SqlCommand cmd = new SqlCommand("select * from Books", con);
                    DataTable dt = new DataTable();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    dgBooks.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public bool isValid()
        {
            if (txtBookName.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtAuthorName.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtPrice.Text == string.Empty)
            {
                MessageBox.Show("Price is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtDispo.Text == string.Empty)
            {
                MessageBox.Show("Disponibility is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (txtNbrPages.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }





        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Books Values (@Author_Name,@Book_Name,@Price,@Book_Type,@Disponibility,@Pages_Nbr,@Image)", con);


                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Author_Name", txtAuthorName.Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Book_Name", txtBookName.Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Book_Type", cbType.Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Disponibility", txtDispo.Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Image", txtImage.Text);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Pages_Nbr", txtNbrPages.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

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

        
        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgBooks.SelectedItem != null)
                {
                    
                    DataRowView selectedBook = (DataRowView)dgBooks.SelectedItem;

                   
                    int bookId = (int)selectedBook["Book_Id"]; 

                    
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE Book_Id = @BookId", con);
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    
                    Book bookToRemove = booksList.FirstOrDefault(book => book.Book_Id == bookId);
                    if (bookToRemove != null)
                    {
                        booksList.Remove(bookToRemove);
                    }

                    
                    LoadGrid();

                    MessageBox.Show("Successfully deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please select a book to delete", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HomeBook_Click(object sender, RoutedEventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }


        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgBooks.SelectedItem != null)
                {
                    DataRowView selectedBook = (DataRowView)dgBooks.SelectedItem;
                    int bookId = (int)selectedBook["Book_Id"];

                    SqlCommand cmd = new SqlCommand("UPDATE Books SET  Author_Name = @AuthorName,Book_Name = @BookName, Price = @Price, Book_Type = @BookType, Disponibility = @Disponibility, Pages_Nbr = @PagesNbr, Image = @Image WHERE Book_Id = @BookId", con);

                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.Parameters.AddWithValue("@AuthorName", txtAuthorName.Text);
                    cmd.Parameters.AddWithValue("@BookName", txtBookName.Text);
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@BookType", cbType.Text);
                    cmd.Parameters.AddWithValue("@Disponibility", txtDispo.Text);
                    cmd.Parameters.AddWithValue("@PagesNbr", txtNbrPages.Text);
                    cmd.Parameters.AddWithValue("@Image", txtImage.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    LoadGrid();

                    MessageBox.Show("Successfully updated", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please select a book to update", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBooks.SelectedItem != null)
            {
                DataRowView selectedBook = (DataRowView)dgBooks.SelectedItem;

                
                txtBookName.Text = selectedBook["Book_Name"].ToString();
                txtAuthorName.Text = selectedBook["Author_Name"].ToString();
                cbType.Text = selectedBook["Book_Type"].ToString();
                txtPrice.Text = selectedBook["Price"].ToString();
                txtNbrPages.Text = selectedBook["Pages_Nbr"].ToString();
                txtDispo.Text = selectedBook["Disponibility"].ToString();
                txtImage.Text = selectedBook["Image"].ToString();

            }
        }

        private void ClearBook_Click(object sender, RoutedEventArgs e)
        {
            txtBookName.Text = string.Empty;
            txtAuthorName.Text = string.Empty;
            cbType.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtNbrPages.Text = string.Empty;
            txtDispo.Text = string.Empty;
            txtImage.Text = string.Empty;
        }

    }
}




