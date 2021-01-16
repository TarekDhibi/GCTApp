using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace GCTApplication
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BConnexion_Click(object sender, RoutedEventArgs e)
        {
            if(TBLogin.Text.Equals("") || TBMdp.Password.Equals(""))
            {
                MessageBox.Show("Champ(s) vide(s)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int a = Requettes.Authentification(TBLogin.Text, TBMdp.Password);
                if(a==-1)
                {
                    MessageBox.Show( "problème de connexion à la base de données","Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (a == 0)
                    {
                        MessageBox.Show("Login et/ou mot de passe incorrecte(s)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    } 
                    else
                    {
                        try
                        {
                            DateTime thisDate = DateTime.Now;
                            CultureInfo culture = new CultureInfo("fr-FR");  
                            Requettes.AjouterJournal(a, "Connexion : "+thisDate.ToString());
                        }
                        catch (Exception ex)
                        {

                        }
                        Principale aa = new Principale(a);
                        aa.Show();
                        this.Close();
                    }
                }
                
            }
        }
    }
}