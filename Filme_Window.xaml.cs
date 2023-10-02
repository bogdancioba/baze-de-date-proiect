using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aplic
{
    /// <summary>
    /// Interaction logic for Filme_Window.xaml
    /// </summary>
    public partial class Filme_Window : Window
    {
        public Filme_Window()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var homeWindow = new MainWindow();
            homeWindow.ShowDialog();
        }

        private void Rezerva_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var rezervaWindow = new Rezerva_Window();
            rezervaWindow.ShowDialog();

        }
    }
}
