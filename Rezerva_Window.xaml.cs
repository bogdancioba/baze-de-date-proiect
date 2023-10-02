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
    /// Interaction logic for Rezerva_Window.xaml
    /// </summary>
    public partial class Rezerva_Window : Window
    {
        public Rezerva_Window()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var homeWindow = new MainWindow();
            homeWindow.ShowDialog();
        }

        private void Filme_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var filmeWindow = new Filme_Window();
            filmeWindow.ShowDialog();
        }
    }
}
