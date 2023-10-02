using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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
using System.Data.SqlClient;
using MaterialDesignThemes.Wpf;

namespace Aplic
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    /// 

    public partial class Register : Window
    {
        SqlConnection con = new SqlConnection(connectionString);
        static String connectionString = "Data Source=(localdb)\\local;Initial Catalog=Northwind;Integrated Security=True";
        string commandText = "INSERT INTO Employees (FirstName, LastNAme, HomePhone) VALUES (@FirstName, @LastName, @HomePhone)";

        public Register()
        {
            InitializeComponent();
        }

        public bool isDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (isDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                isDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                isDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string email = txtEmail.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", username);
                    command.Parameters.AddWithValue("@LastName", password);
                    command.Parameters.AddWithValue("@HomePhone", email);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Utilizator inregistrat cu succes!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);

                connection.Close();
            }

            LogIn logInWindow = new LogIn();
            logInWindow.Show();
            this.Hide();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            LogIn logInWindow = new LogIn();
            logInWindow.Show();
            this.Hide();
        }
    }
}
