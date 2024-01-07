using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Library
{
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            bool isAuthenticated = AuthenticateUser();

            if (isAuthenticated)
            {
                
                Home homePage = new Home();
                this.Hide(); 
                homePage.Show();
            }
            else
            {
                
                MessageBox.Show("Invalid username or password. Please try again.", "Authentication Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            
        }
        private bool AuthenticateUser()
        {
            string expectedUsername = "Admin";
            string expectedPassword = "123";

            // Get the entered username and password
            string enteredUsername = txtUsername.Text.Trim();
            string enteredPassword = txtPassword.Password.Trim();

            // Check if the entered credentials match the expected values
            return (enteredUsername == expectedUsername && enteredPassword == expectedPassword);
            return true;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
