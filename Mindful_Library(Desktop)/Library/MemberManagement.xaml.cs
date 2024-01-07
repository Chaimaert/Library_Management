using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using static Library.LibraryContext;
using System.Data;
using System.IO;
using System.Windows;
using ExcelDataReader;



namespace Library
{
    public partial class MemberManagement : Window
    {
        private ObservableCollection<Member> membersList = new ObservableCollection<Member>();

        public MemberManagement()
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
                    SqlCommand cmd = new SqlCommand("select * from Members", con);
                    DataTable dt = new DataTable();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    dgMembers.ItemsSource = dt.DefaultView;
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
            if (dpRegistrationDate.Text == string.Empty)
            {
                MessageBox.Show("Date is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        private void AddMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("INSERT INTO [Members] (MFirst_Name, MLast_Name, Registration_Date) VALUES (@First_Name, @Last_Name, @Registration_Date)", con);

                        cmd.Parameters.AddWithValue("@First_Name", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@Last_Name", txtLastName.Text);
                        cmd.Parameters.AddWithValue("Registration_Date", dpRegistrationDate.Text);

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

        private void UpdateMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgMembers.SelectedItem != null)
                {
                    DataRowView selectedMember = (DataRowView)dgMembers.SelectedItem;
                    int memberId = (int)selectedMember["Member_Id"];

                    using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("UPDATE Members SET MFirst_Name = @FirstName, MLast_Name = @LastName, Registration_Date = @RegistrationDate WHERE Member_Id = @MemberId", con);
                        cmd.Parameters.AddWithValue("@MemberId", memberId);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@RegistrationDate", dpRegistrationDate.SelectedDate);

                        cmd.ExecuteNonQuery();
                    }

                    LoadGrid();

                    MessageBox.Show("Successfully updated", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please select a member to update", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgMembers.SelectedItem != null)
                {
                    DataRowView selectedMember = (DataRowView)dgMembers.SelectedItem;
                    int memberId = (int)selectedMember["Member_Id"];

                    // Check if there are reservations for the member
                    if (HasReservations(memberId))
                    {
                        MessageBox.Show("Cannot delete member with reservations. Delete reservations first.", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
                        {
                            con.Open();

                            SqlCommand cmd = new SqlCommand("DELETE FROM Members WHERE Member_Id = @MemberId", con);
                            cmd.Parameters.AddWithValue("@MemberId", memberId);
                            cmd.ExecuteNonQuery();
                        }

                        LoadGrid();

                        MessageBox.Show("Successfully deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a member to delete", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool HasReservations(int memberId)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=HP\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True;Encrypt=False"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Reservations WHERE Member_Id = @MemberId", con);
                cmd.Parameters.AddWithValue("@MemberId", memberId);

                int reservationCount = (int)cmd.ExecuteScalar();

                return reservationCount > 0;
            }
        }





        private void HomeMember_Click(object sender, RoutedEventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void dgMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMembers.SelectedItem != null)
            {
                DataRowView selectedMember = (DataRowView)dgMembers.SelectedItem;

                
                txtFirstName.Text = selectedMember["MFirst_Name"].ToString();
                txtLastName.Text = selectedMember["MLast_Name"].ToString();
                dpRegistrationDate.Text = selectedMember["Registration_Date"].ToString();
               
            }
        }

        private void ClearMember_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            dpRegistrationDate.SelectedDate = null;
            
        }

        private void ExportMembers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Fichiers Excel|*.xlsx",
                    Title = "Export des membres vers Excel"
                };

                var result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    
                    string filePath = saveFileDialog.FileName;

                    
                    var workbook = new ClosedXML.Excel.XLWorkbook();

                    
                    var worksheet = workbook.Worksheets.Add("Members");

                    
                    DataTable dt = (dgMembers.ItemsSource as DataView).ToTable();

                    
                    worksheet.Cell(1, 1).InsertTable(dt);

                    
                    workbook.SaveAs(filePath);

                    MessageBox.Show("Exportation réussie vers : " + filePath, "Exportation terminée", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'exportation vers Excel : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ImportMembers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "Fichiers Excel|*.xls;*.xlsx",
                    Title = "Importation des membres depuis Excel"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    
                    string filePath = openFileDialog.FileName;

                    
                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                        {
                            
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration
                                {
                                    UseHeaderRow = true,
                                }
                            });

                            
                            DataTable dt = result.Tables[0];

                           
                            dgMembers.ItemsSource = dt.DefaultView;
                        }
                    }

                    MessageBox.Show("Importation réussie depuis : " + filePath, "Importation terminée", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'importation depuis Excel : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
