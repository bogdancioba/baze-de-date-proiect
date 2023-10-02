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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd;
        SqlDataReader reader;
        static String connectionString = "Data Source=(localdb)\\local;Initial Catalog=Northwind;Integrated Security=True";

        public LogIn()
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

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String username, user_password;

            username = txtUsername.Text;
            user_password = txtPassword.Password;

            try
            {
                String querry = "SELECT * FROM Employees WHERE LastName = '" + txtUsername.Text + "' AND FirstName = '" + txtPassword.Password + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txtUsername.Text;
                    user_password = txtPassword.Password;

                    //
                    MessageBox.Show("Utilizator autentificat cu succes!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);

                    // TO DO
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Hide();
                }


                else
                {
                    MessageBox.Show("Nu a putut fi gasit acest utilizator!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();

                    txtUsername.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Catch Error!");
            }
            finally
            {
                //con.Close();
            }
        }

        private void signupBtn_Click(object sender, RoutedEventArgs e)
        {
            Register regWindow = new Register();
            regWindow.Show();
            this.Hide();
        }
    }
}
