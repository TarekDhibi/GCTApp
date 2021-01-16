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
using System.Windows.Shapes;

namespace GCTApplication
{
    /// <summary>
    /// Logique d'interaction pour Gestion.xaml
    /// </summary>
    public partial class Gestion : Window
    {
        public Gestion()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Gestion a = new Gestion();
            a.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
