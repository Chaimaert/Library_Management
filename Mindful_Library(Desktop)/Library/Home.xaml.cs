using System.Windows;

namespace Library
{
    public partial class Home : Window
    {
        
        public Home()
        {
            InitializeComponent();
        }

        private void BooksManagement_Click(object sender, RoutedEventArgs e)
        {
            BookManagement bookManagementPage = new BookManagement();

            
            this.Hide();

            
            bookManagementPage.Show();
        }

        private void MemberManagement_Click(object sender, RoutedEventArgs e)
        {
            MemberManagement memberManagementPage = new MemberManagement();
            this.Hide();
            memberManagementPage.Show();
        }

        private void UserManagement_Click(object sender, RoutedEventArgs e)
        {
            UserManagement userManagementPage = new UserManagement();
            this.Hide();
            userManagementPage.Show();
        }

        private void ReservationManagement_Click(object sender, RoutedEventArgs e)
        {
            ReservationManagement reservationManagementPage = new ReservationManagement();
            this.Hide();
            reservationManagementPage.Show();

        }
    }
}
