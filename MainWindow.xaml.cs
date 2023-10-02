using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aplic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Filme_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var filmeWindow = new Filme_Window();
            filmeWindow.ShowDialog();
        }

        private void Rezerva_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var rezervaWindow = new Rezerva_Window();
            rezervaWindow.ShowDialog();
        }
    }
}
