using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GCTApplication
{
    /// <summary>
    /// Logique d'interaction pour Principale.xaml
    /// </summary>
    public partial class Principale : Window
    {
        int idGeneral = 0;
        public Principale()
        {
            InitializeComponent();
            importerPersonel();

        }
        public Principale(int id)
        {
            InitializeComponent();
            importerPersonel();
            importerArticle();
            importerJournalPersonel();
            importerJournalArticle();
            this.idGeneral = id;
            LoadBarChartData();
            LoadColumnChartData();
            //MessageBox.Show("" + CBRole.Text);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(AfficherMdp.IsChecked.Value)
            {
                TBAfficherMdp.Text = this.TBMdp.Password;
            }
            else
            {
                TBAfficherMdp.Text = "";
            }
        }

        private void DataGrid1_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void BAjouter_Click(object sender, RoutedEventArgs e)
        {
            if(TBNom.Text.Equals("") || TBLogin.Text.Equals("") || TBMdp.Password.Equals(""))
            {
                MessageBox.Show("Champ(s) vide(s)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Requettes.LoginExiste(TBLogin.Text) != 0)
                {
                    MessageBox.Show("ce login est déjà utilisé", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (Requettes.LoginExiste(TBLogin.Text) != -1)
                    {
                        if (Requettes.AjouterPersonel(TBNom.Text, CBRole.Text, TBLogin.Text, TBMdp.Password)==0)
                        {
                            MessageBox.Show("ce Personnel est ajouté avec succès", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            try
                            {
                                DateTime thisDate = DateTime.Now;
                                CultureInfo culture = new CultureInfo("fr-FR");
                                Requettes.AjouterJournal(idGeneral, "Ajouter un nouveau personel : " + TBLogin.Text + " : " + thisDate.ToString());
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
            }
            importerPersonel();
        }

        private void BAAnnuler_Click(object sender, RoutedEventArgs e)
        {
            TBLogin.Text = "";
            TBNom.Text = "";
            TBMdp.Password = "";
            TBAfficherMdp.Text = "";
        }

        private void BAAnnulerM_Click(object sender, RoutedEventArgs e)
        {
            TBIdM.Background = Brushes.White;
            TBIdM.Text = "";
            TBNomM.Text = "";
            TBLoginM.Text = "";
            TBMdpM.Password = "";
            TBAfficherMdpM.Text = "";
        }

        private void CBAfficherM_Checked(object sender, RoutedEventArgs e)
        {
            if (CBAfficherM.IsChecked.Value)
            {
                TBAfficherMdpM.Text = this.TBMdpM.Password;
            }
            else
            {
                TBAfficherMdpM.Text = "";
            }
        }

        private void TBIdM_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBIdM.Text = saisieFloat(sender);
            if(!TBIdM.Text.Equals(""))
            {
                TBNomM.Text = Requettes.GetNomFromIdAdmin(TBIdM.Text);
                TBLoginM.Text = Requettes.GetLoginFromIdAdmin(TBIdM.Text);
                TBMdpM.Password = Requettes.GetMdpFromIdAdmin(TBIdM.Text);
                String role = Requettes.GetRoleFromIdAdmin(TBIdM.Text);
                if (role.Equals("Administrateur"))
                {
                    CBRoleM.SelectedIndex = 0;
                }
                if (role.Equals("Gestionnaire"))
                {
                    CBRoleM.SelectedIndex = 1;
                }
                if (role.Equals("Utilisateur"))
                {
                    CBRoleM.SelectedIndex = 2;
                }
            }
            if (TBIdM.Text.Equals(""))
            {
                TBIdM.Background = Brushes.White;
                TBIdM.Text = "";
                TBNomM.Text = "";
                TBLoginM.Text = "";
                TBMdpM.Password = "";
                TBAfficherMdpM.Text = "";
            }
            else
            {
                if (Requettes.IdExiste(TBIdM.Text) == 0)
                {
                    TBIdM.Background = Brushes.Bisque;
                }
                else
                {
                    TBIdM.Background = Brushes.GreenYellow;
                }
            }
        }

        private void PreviewTextInput(object sender, KeyEventArgs e)
        {
            
            
        }
        private void importerPersonel()
        {
            DataGridAdmin.ItemsSource = null;
            List<Personel> reader = Requettes.getAllPersonels();
            //MessageBox.Show(reader.Count+"");
            DataGridAdmin.ItemsSource = reader;
        }
        private void importerArticle()
        {
            DataGridArticle.ItemsSource = null;
            List<Article> reader = Requettes.getAllArticle();
            //MessageBox.Show(reader.Count+"");
            DataGridArticle.ItemsSource = reader;
        }
        private void importerJournalPersonel()
        {
            DataGridJournal.ItemsSource = null;
            List<journalP> reader = Requettes.getAllJournals();
            DataGridJournal.ItemsSource = reader;
        }
        private void importerJournalArticle()
        {
            DataGridArticleJ.ItemsSource = null;
            List<journalArticle> reader = Requettes.getAllJournalArticle();
            DataGridArticleJ.ItemsSource = reader;
        }
        private void importerJournalArticle(String champ, String texte)
        {
            DataGridArticleJ.ItemsSource = null;
            List<journalArticle> reader = Requettes.getAllJournalArticle();
            DataGridArticleJ.ItemsSource = reader;
        }
        private void importerJournalPersonel(String champ, String texte)
        {
            DataGridJournal.ItemsSource = null;
            List<journalP> reader = Requettes.getAllJournals(champ, texte);
            DataGridJournal.ItemsSource = reader;
        }
        private void importerPersonel(String champ, String texte)
        {
            DataGridAdmin.ItemsSource = null;
            List<Personel> reader = Requettes.getAllPersonels(champ, texte);
            DataGridAdmin.ItemsSource = reader;
        }
        private void importerArticle(String champ, String texte)
        {
            DataGridArticle.ItemsSource = null;
            List<Article> reader = Requettes.getAllArticle(champ, texte);
            DataGridArticle.ItemsSource = reader;
        }

        private void BAModifierAdmin_Click(object sender, RoutedEventArgs e)
        {
            if(TBIdM.Text.Equals(""))
            {
                MessageBox.Show("Vous devez saisir l'identifiant d'un personel", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Requettes.IdExiste(TBIdM.Text) == 0)
                {
                    MessageBox.Show("Vous devez saisir un identifiant valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if(TBNomM.Text.Equals("") || TBLoginM.Text.Equals("") || TBMdpM.Password.Equals(""))
                    {
                        MessageBox.Show("Champ(s) vide(s)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (Requettes.ModifierPersonel(TBIdM.Text, TBNomM.Text, CBRoleM.Text, TBLoginM.Text, TBMdpM.Password) == 0)
                        {
                            MessageBox.Show("Ce personel a été modifier avec succèes", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            try
                            {
                                DateTime thisDate = DateTime.Now;
                                CultureInfo culture = new CultureInfo("fr-FR");
                                Requettes.AjouterJournal(idGeneral, "Modifier un nouveau personel : " + TBLoginM.Text + " : " + thisDate.ToString());
                            
                            }
                            catch (Exception ex)
                            {

                            }
                            TBIdM.Background = Brushes.White;
                            TBIdM.Text = "";
                            TBNomM.Text = "";
                            TBLoginM.Text = "";
                            TBMdpM.Password = "";
                            TBAfficherMdpM.Text = "";
                            importerPersonel();
                        }
                    }
                }
            }
            importerPersonel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridJournal, "Journal des Personel.");
            try
            {
                DateTime thisDate = DateTime.Now;
                CultureInfo culture = new CultureInfo("fr-FR");
                Requettes.AjouterJournal(idGeneral, "Impression du journal des personels. " + thisDate.ToString());
                            
            }
            catch (Exception ex)
            {

            }
        }

        private void ButtonImpressionListePersonels_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridAdmin, "Journal des Personel.");
            try
            {
                DateTime thisDate = DateTime.Now;
                CultureInfo culture = new CultureInfo("fr-FR");
                Requettes.AjouterJournal(idGeneral, "Impression de la liste des personels " + thisDate.ToString());
                
            }
            catch (Exception ex)
            {

            }
        }

        private void FiltreRechAdmin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(FiltreRechAdmin.Text.Equals(""))
            {
                importerPersonel();
            }
            else
            {
                String value = "";
                if (CRechAdmin.SelectedIndex==0)
                {
                    value = "nom";
                }
                else
                {
                    if(CRechAdmin.SelectedIndex==1)
                    {
                        value = "role";
                    }
                    else
                    {
                        value = "login";
                    }
                }
                importerPersonel(value, FiltreRechAdmin.Text);
            }
        }

        private void FiltreRechAdminJ_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FiltreRechAdminJ.Text.Equals(""))
            {
                importerJournalPersonel();
            }
            else
            {
                
                string value = "";
                if (CRechAdminJ.SelectedIndex==0)
                {
                    value = "idp";
                }
                else
                {
                    value = "tache";
                }
                importerJournalPersonel(value, FiltreRechAdminJ.Text);
            }
        }
        private String saisieFloat(object sender)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            int count = 0;
            foreach (Char c in textBox.Text.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c) || (c == '.' && count == 0))
                {
                    newText += c;
                    if (c == '.')
                        count += 1;
                }
            }
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;
            return newText;
        }

        private void TBIdAdminS_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBIdAdminS.Text = saisieFloat(sender);
            if (!TBIdAdminS.Text.Equals(""))
            {
                TBNomAdminS.Text = Requettes.GetNomFromIdAdmin(TBIdAdminS.Text);
                TBLoginAdminS.Text = Requettes.GetLoginFromIdAdmin(TBIdAdminS.Text);
                TBMdpAdminS.Password = Requettes.GetMdpFromIdAdmin(TBIdAdminS.Text);
                String role = Requettes.GetRoleFromIdAdmin(TBIdAdminS.Text);
                if (role.Equals("Administrateur"))
                {
                    CBRoleAdminS.SelectedIndex = 0;
                }
                if (role.Equals("Gestionnaire"))
                {
                    CBRoleAdminS.SelectedIndex = 1;
                }
                if (role.Equals("Utilisateur"))
                {
                    CBRoleAdminS.SelectedIndex = 2;
                }
            }
            if (TBIdAdminS.Text.Equals(""))
            {
                TBIdAdminS.Background = Brushes.White;
                TBIdAdminS.Text = "";
                TBNomAdminS.Text = "";
                TBLoginAdminS.Text = "";
                TBMdpAdminS.Password = "";
                TBAfficherMdpAdminS.Text = "";
            }
            else
            {
                if (Requettes.IdExiste(TBIdAdminS.Text) == 0)
                {
                    TBIdAdminS.Background = Brushes.Bisque;
                }
                else
                {
                    TBIdAdminS.Background = Brushes.GreenYellow;
                }
            }
        }

        private void AfficherMdpS_Checked(object sender, RoutedEventArgs e)
        {
            if (AfficherMdpS.IsChecked.Value)
            {
                TBAfficherMdpAdminS.Text = this.TBMdpAdminS.Password;
            }
            else
            {
                TBAfficherMdpAdminS.Text = "";
            }
        }

        private void BAjouterArticle_Click(object sender, RoutedEventArgs e)
        {
            if (TBSymbole.Text.Equals("") || TBDesc.Text.Equals(""))
            {
                MessageBox.Show("Champ(s) vide(s)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Requettes.SymboleExiste(TBSymbole.Text) != 0)
                {
                    MessageBox.Show("Ce symbole est déjà utilisé", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (Requettes.SymboleExiste(TBSymbole.Text) != -1)
                    {
                        if (Requettes.AjouterArticle(Int16.Parse(TBSymbole.Text),TBDesc.Text, float.Parse(TBBesoin.Text),float.Parse(TBStock.Text),float.Parse(TBRatio.Text), float.Parse(TBSA.Text),float.Parse(TBSMdhilla.Text),float.Parse(TBSSkhira.Text),TBDesignation.Text,TBFormat.Text,TBEpisseur.Text) == 0)
                        {
                            MessageBox.Show("Cet article est ajouté avec succès", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            try
                            {
                                DateTime thisDate = DateTime.Now;
                                CultureInfo culture = new CultureInfo("fr-FR");
                                Requettes.AjouterJournal(idGeneral, "Ajouter un nouveau article : " + TBSymbole.Text+ " : " + thisDate.ToString());
                
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
            }
            importerArticle();
        }

        private void BAAnnulerArticle_Click(object sender, RoutedEventArgs e)
        {
            TBSymbole.Text="";
            TBDesc.Text="";
            TBBesoin.Text="";
            TBStock.Text="";
            TBRatio.Text="";
            TBSA.Text="";
            TBSMdhilla.Text="";
            TBSSkhira.Text="";
            TBDesignation.Text="";
            TBFormat.Text="";
            TBEpisseur.Text = "";
        }

        private void TBBesoin_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBBesoin.Text = saisieFloat(sender);
        }

        private void TBStock_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBStock.Text = saisieFloat(sender);
            if(!TBStock.Text.Equals("") && !TBBesoin.Text.Equals(""))
            {
                try
                {
                    float res = float.Parse(TBStock.Text) / float.Parse(TBBesoin.Text) * 100;
                    TBRatio.Text = res + "";
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void TBRatio_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBRatio.Text = saisieFloat(sender);
        }

        private void TBSA_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBSA.Text = saisieFloat(sender);
        }

        private void TBSMdhilla_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBSMdhilla.Text = saisieFloat(sender);
        }

        private void TBSSkhira_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBSSkhira.Text = saisieFloat(sender);
        }

        private void FiltreRechArticle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FiltreRechArticle.Text.Equals(""))
            {
                importerArticle();
            }
            else
            {
                String value = "";
                if (CRechArticle.SelectedIndex == 0)
                {
                    value = "symbole";
                }
                else
                {
                    if (CRechArticle.SelectedIndex == 1)
                    {
                        value = "description";
                    }
                    else
                    {
                        value = "besoin";
                    }
                }
                importerArticle(value, FiltreRechArticle.Text);
            }
        }

        private void BAModifierArticle_Click(object sender, RoutedEventArgs e)
        {
            if (TBSymboleM.Text.Equals(""))
            {
                MessageBox.Show("Vous devez saisir le symbole d'article", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Requettes.IdArticleExiste(TBSymboleM.Text) == 0)
                {
                    MessageBox.Show("Vous devez saisir un symbole valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (TBSymboleM.Text.Equals("") || TBDescM.Text.Equals("") || TBBesoinM.Text.Equals(""))
                    {
                        MessageBox.Show("Champ(s) vide(s)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (Requettes.ModifierArticle(Int16.Parse(TBSymboleM.Text), TBDescM.Text, float.Parse(TBBesoinM.Text), float.Parse(TBStockM.Text), float.Parse(TBRatioM.Text), float.Parse(TBSAM.Text), float.Parse(TBSMdhillaM.Text), float.Parse(TBSSkhiraM.Text), TBDesignationM.Text, TBFormatM.Text, TBEpisseurM.Text) == 0)
                        {
                            MessageBox.Show("Cet article a été modifier avec succèes", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            try
                            {
                                DateTime thisDate = DateTime.Now;
                                CultureInfo culture = new CultureInfo("fr-FR");
                                Requettes.AjouterJournal(idGeneral, "Modifier l'article : " + TBSymboleM.Text + " : " + thisDate.ToString());
                
                            }
                            catch (Exception ex)
                            {

                            }
                            TBIdM.Background = Brushes.White;
                            TBSymboleM.Text = "";
                            TBDescM.Text = "";
                            TBBesoinM.Text = "";
                            TBStockM.Text = "";
                            TBRatioM.Text = "";
                            TBSAM.Text = "";
                            TBSMdhillaM.Text = "";
                            TBSSkhiraM.Text = "";
                            TBDesignationM.Text = "";
                            TBFormatM.Text = "";
                            TBEpisseurM.Text = "";
                            importerArticle();
                        }
                    }
                }
            } 
        }

        private void BAAnnulerArticleM_Click(object sender, RoutedEventArgs e)
        {
            viderChampsArtileM();
        }
        private void viderChampsArtileM()
        {
            TBSymboleM.Text = "";
            TBDescM.Text = "";
            TBBesoinM.Text = "";
            TBStockM.Text = "";
            TBRatioM.Text = "";
            TBSAM.Text = "";
            TBSMdhillaM.Text = "";
            TBSSkhiraM.Text = "";
            TBDesignationM.Text = "";
            TBFormatM.Text = "";
            TBEpisseurM.Text = "";
        }
        private void viderChampsArtileas()
        {
            TBSymboleas.Text = "";
            TBDescas.Text = "";
            TBBesoinas.Text = "";
            TBStockas.Text = "";
            TBRatioas.Text = "";
            TBSAas.Text = "";
            TBSMdhillaas.Text = "";
            TBSSkhiraas.Text = "";
            TBDesignationas.Text = "";
            TBFormatas.Text = "";
            TBEpisseuras.Text = "";
            TBNouvelleQuantiteras.Text = "";
        }
        private void viderChampsArtilere()
        {
            TBSymbolere.Text = "";
            TBDescre.Text = "";
            TBBesoinre.Text = "";
            TBStockre.Text = "";
            TBRatiore.Text = "";
            TBSAre.Text = "";
            TBSMdhillare.Text = "";
            TBSSkhirare.Text = "";
            TBDesignationre.Text = "";
            TBFormatre.Text = "";
            TBEpisseurre.Text = "";
            TBNouvelleQuantiterre.Text = "";
            TBUsagere.Text = "";
        }
        private void viderChampsArtileS()
        {
            TBSymboleS.Text = "";
            TBDescS.Text = "";
            TBBesoinS.Text = "";
            TBStockS.Text = "";
            TBRatioS.Text = "";
            TBSAS.Text = "";
            TBSMdhillaS.Text = "";
            TBSSkhiraS.Text = "";
            TBDesignationS.Text = "";
            TBFormatS.Text = "";
            TBEpisseurS.Text = "";
        }

        private void TBSymboleM_KeyUp(object sender, KeyEventArgs e)
        {
            TBSymboleM.Text = saisieFloat(sender);
            if (!TBSymboleM.Text.Equals(""))
            {
                List<Article> art = Requettes.getAllArticle("symbole", TBSymboleM.Text);
                if (art.Count > 0)
                {
                    TBDescM.Text = art.ElementAt(0).description;
                    TBBesoinM.Text = art.ElementAt(0).besoin + "";
                    TBStockM.Text = art.ElementAt(0).stock + "";
                    TBRatioM.Text = art.ElementAt(0).ratio + "";
                    TBSAM.Text = art.ElementAt(0).sa + "";
                    TBSMdhillaM.Text = art.ElementAt(0).smdhilla + "";
                    TBSSkhiraM.Text = art.ElementAt(0).sskhira + "";
                    TBDesignationM.Text = art.ElementAt(0).designation;
                    TBFormatM.Text = art.ElementAt(0).format;
                    TBEpisseurM.Text = art.ElementAt(0).episseur;
                    TBSymboleM.Background = Brushes.GreenYellow;
                }
                else
                {
                    TBSymboleM.Background = Brushes.Bisque;
                    MessageBox.Show("Ce symbole n'existe pas dans la base de données courante", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                TBSymboleM.Background = Brushes.White;
                viderChampsArtileM();
                importerArticle();
            }
        }

        private void TBSymboleM_KeyUp(object sender, TextChangedEventArgs e)
        {

        }

        private void BASupprimerArticleS_Click(object sender, RoutedEventArgs e)
        {
            if (TBSymboleS.Text.Equals(""))
            {
                MessageBox.Show("Vous devez saisir le symbole d'un article", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Requettes.SymboleExiste(TBSymboleS.Text) == 0)
                {
                    MessageBox.Show("Vous devez saisir un symbole valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (Requettes.SupprimerArticle(Int16.Parse(TBSymboleS.Text)) == 0)
                        {
                            MessageBox.Show("Cet article a été Supprimer avec succèes", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            try
                            {
                                DateTime thisDate = DateTime.Now;
                                CultureInfo culture = new CultureInfo("fr-FR");
                                Requettes.AjouterJournal(idGeneral, "Supprimer un  article : " + TBSymboleS.Text + " : " + thisDate.ToString());
                            }
                            catch (Exception ex)
                            {
                            }
                            TBIdAdminS.Background = Brushes.White;
                            viderChampsArtileS();
                            importerArticle();
                        }
                }
            }
        }

        private void BAAnnulerArticleS_Click(object sender, RoutedEventArgs e)
        {
            viderChampsArtileS();
        }

        private void TBSymboleS_KeyUp(object sender, KeyEventArgs e)
        {
            TBSymboleS.Text = saisieFloat(sender);
            if (!TBSymboleS.Text.Equals(""))
            {
                List<Article> art = Requettes.getAllArticle("symbole", TBSymboleS.Text);
                if (art.Count > 0)
                {
                    TBDescS.Text = art.ElementAt(0).description;
                    TBBesoinS.Text = art.ElementAt(0).besoin + "";
                    TBStockS.Text = art.ElementAt(0).stock + "";
                    TBRatioS.Text = art.ElementAt(0).ratio + "";
                    TBSAS.Text = art.ElementAt(0).sa + "";
                    TBSMdhillaS.Text = art.ElementAt(0).smdhilla + "";
                    TBSSkhiraS.Text = art.ElementAt(0).sskhira + "";
                    TBDesignationS.Text = art.ElementAt(0).designation;
                    TBFormatS.Text = art.ElementAt(0).format;
                    TBEpisseurS.Text = art.ElementAt(0).episseur;
                    TBSymboleS.Background = Brushes.GreenYellow;
                }
                else
                {
                    TBSymboleS.Background = Brushes.Bisque;
                    MessageBox.Show("Ce symbole n'existe pas dans la base de données courante", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                TBSymboleS.Background = Brushes.White;
                viderChampsArtileS();
            }
        }

        private void BASupprimerAdminS_Click(object sender, RoutedEventArgs e)
        {
            if (TBIdAdminS.Text.Equals(""))
            {
                MessageBox.Show("Vous devez saisir l'identifiant d'un personel", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Requettes.IdExiste(TBIdAdminS.Text) == 0)
                {
                    MessageBox.Show("Vous devez saisir un identifiant valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (TBNomAdminS.Text.Equals("") || TBLoginAdminS.Text.Equals("") || TBMdpAdminS.Password.Equals(""))
                    {
                        MessageBox.Show("Champ(s) vide(s)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (Requettes.SupprimerPersonel(Int16.Parse(TBIdAdminS.Text)) == 0)
                        {
                            MessageBox.Show("Ce personel a été Supprimer avec succèes", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            try
                            {
                                DateTime thisDate = DateTime.Now;
                                CultureInfo culture = new CultureInfo("fr-FR");
                                Requettes.AjouterJournal(idGeneral, "Supprimer un  personel : " + TBLoginAdminS.Text + " : " + thisDate.ToString());
                             }
                            catch (Exception ex)
                            {
                            }
                            TBIdAdminS.Background = Brushes.White;
                            TBIdAdminS.Text = "";
                            TBNomAdminS.Text = "";
                            TBLoginAdminS.Text = "";
                            TBMdpAdminS.Password = "";
                            TBAfficherMdpAdminS.Text = "";
                            importerPersonel();
                        }
                    }
                }
            }
            importerPersonel();
        }

        private void BAAnnulerAdminS_Click(object sender, RoutedEventArgs e)
        {

        }
        private void FormatBarChart()
        {
            BarSeries bs = (BarSeries)mcChart.Series[0];
            bs.BorderThickness = new Thickness(3);
            bs.BorderBrush = new SolidColorBrush(Colors.Orange);
            ActionPersonel a = new ActionPersonel();
        }

        private void LoadBarChartData()
        {
            List<PersonelStat> v = new List<PersonelStat>();
            List<Personel> ls = Requettes.getAllPersonels();
            for(int i = 0; i <ls.Count; i++)
            {
                v.Add(new PersonelStat(ls.ElementAt(i).nom, Requettes.nbApparenceJournal(ls.ElementAt(i).id)));
            }

            ((BarSeries)mcChart.Series[0]).ItemsSource = v;
        }
        private void LoadColumnChartData()
        {
            List<PersonelStat> v = new List<PersonelStat>();
            List<Article> ls = Requettes.getAllArticle();
            for (int i = 0; i < ls.Count; i++)
            {
                v.Add(new PersonelStat(ls.ElementAt(i).symbole+"", Int16.Parse(ls.ElementAt(i).stock+"")));
            }

            ((ColumnSeries)mcChartS.Series[0]).ItemsSource = v;
        }

        private void TBNouvelleQuantiteras_KeyUp(object sender, KeyEventArgs e)
        {
            TBNouvelleQuantiteras.Text = saisieFloat(sender);
            if (!(TBNouvelleQuantiteras.Text.Equals("") && TBBesoinas.Text.Equals("") && TBNouvelleQuantiteras.Text.Equals("")))
            {
                float res = ((float.Parse(TBStockas.Text) + float.Parse(TBNouvelleQuantiteras.Text)) / float.Parse(TBBesoinas.Text)) * 100;
                TBRatioas.Text = res+"";
            }
        }

        private void TBSymbole_KeyUp(object sender, KeyEventArgs e)
        {
            TBSymbole.Text = saisieFloat(sender);
        }

        private void TBStockM_KeyUp(object sender, KeyEventArgs e)
        {
            TBStockM.Text = saisieFloat(sender);
            if (!TBStockM.Text.Equals("") && !TBBesoinM.Text.Equals(""))
            {
                try
                {
                    float res = float.Parse(TBStockM.Text) / float.Parse(TBBesoinM.Text) * 100;
                    TBRatioM.Text = res + "";
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void TBRatioas_KeyUp(object sender, KeyEventArgs e)
        {
            TBRatioas.Text = saisieFloat(sender);
            if (!TBStockas.Text.Equals("") && !TBBesoinas.Text.Equals(""))
            {
                try
                {
                    float res = float.Parse(TBStockas.Text) / float.Parse(TBBesoinas.Text) * 100;
                    TBRatioas.Text = res + "";
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void TBStockre_KeyUp(object sender, KeyEventArgs e)
        {
            TBRatiore.Text = saisieFloat(sender);
            if (!TBStockre.Text.Equals("") && !TBBesoinre.Text.Equals(""))
            {
                try
                {
                    float res = float.Parse(TBStockre.Text) / float.Parse(TBBesoinre.Text) * 100;
                    TBRatiore.Text = res + "";
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void TBSymboleas_KeyUp(object sender, KeyEventArgs e)
        {
            TBSymboleas.Text = saisieFloat(sender);
            if (!TBSymboleas.Text.Equals(""))
            {
                List<Article> art = Requettes.getAllArticle("symbole", TBSymboleas.Text);
                if (art.Count > 0)
                {
                    TBDescas.Text = art.ElementAt(0).description;
                    TBBesoinas.Text = art.ElementAt(0).besoin + "";
                    TBStockas.Text = art.ElementAt(0).stock + "";
                    TBRatioas.Text = art.ElementAt(0).ratio + "";
                    TBSAas.Text = art.ElementAt(0).sa + "";
                    TBSMdhillaas.Text = art.ElementAt(0).smdhilla + "";
                    TBSSkhiraas.Text = art.ElementAt(0).sskhira + "";
                    TBDesignationas.Text = art.ElementAt(0).designation;
                    TBFormatas.Text = art.ElementAt(0).format;
                    TBEpisseuras.Text = art.ElementAt(0).episseur;
                    TBSymboleas.Background = Brushes.GreenYellow;
                }
                else
                {
                    TBSymboleas.Background = Brushes.Bisque;
                    MessageBox.Show("Ce symbole n'existe pas dans la base de données courante", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                TBSymboleas.Background = Brushes.White;
                viderChampsArtileas();
            }
        }

        private void BAConfirmerArticleas_Click(object sender, RoutedEventArgs e)
        {
 
            if (TBSymboleas.Text.Equals(""))
            {
                MessageBox.Show("Vous devez saisir le symbole d'article", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Requettes.IdArticleExiste(TBSymboleas.Text) == 0)
                {
                    MessageBox.Show("Vous devez saisir un symbole valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (TBSymboleas.Text.Equals("") || TBDescas.Text.Equals("") || TBBesoinas.Text.Equals("") || TBStockas.Text.Equals("") || TBNouvelleQuantiteras.Text.Equals(""))
                    {
                        MessageBox.Show("Champ(s) vide(s)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (Requettes.ModifierArticle(Int16.Parse(TBSymboleas.Text), TBDescas.Text, float.Parse(TBBesoinas.Text), float.Parse(TBNouvelleQuantiteras.Text) + float.Parse(TBStockas.Text), float.Parse(TBRatioas.Text), float.Parse(TBSAas.Text), float.Parse(TBSMdhillaas.Text), float.Parse(TBSSkhiraas.Text), TBDesignationas.Text, TBFormatas.Text, TBEpisseuras.Text) == 0)
                        {
                            MessageBox.Show("Cet article a été modifier avec succèes", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            DateTime localDate = DateTime.Now;
                            int anne = localDate.Year;
                            int moi = localDate.Month;
                            int jour = localDate.Day;
                            Requettes.AjouterJournalArticle(idGeneral, Int16.Parse(TBSymboleas.Text), anne + "", moi + "", jour + "", "Ajout", float.Parse(TBNouvelleQuantiteras.Text) + float.Parse(TBStockas.Text) + "");
                            try
                            {
                                DateTime thisDate = DateTime.Now;
                                CultureInfo culture = new CultureInfo("fr-FR");
                                Requettes.AjouterJournal(idGeneral, "Modifier l'article : " + TBSymboleas.Text + " : " + thisDate.ToString());
                
                            }
                            catch (Exception ex)
                            {

                            }
                            TBSymboleas.Background = Brushes.White;
                            viderChampsArtileas();
                            importerArticle();
                            importerJournalArticle();
                        }
                    }
                }
            }
        }

        private void TBNouvelleQuantiterre_KeyUp(object sender, KeyEventArgs e)
        {
            TBNouvelleQuantiterre.Text = saisieFloat(sender);
            if (!TBNouvelleQuantiterre.Text.Equals("") && !TBBesoinre.Text.Equals(""))
            {
                float res = ((float.Parse(TBStockre.Text) - float.Parse(TBNouvelleQuantiterre.Text)) / float.Parse(TBBesoinre.Text)) * 100;
                TBRatiore.Text = res + "";
            }
        }

        private void TBSymbolere_KeyUp(object sender, KeyEventArgs e)
        {
            TBSymbolere.Text = saisieFloat(sender);
            if (!TBSymbolere.Text.Equals(""))
            {
                List<Article> art = Requettes.getAllArticle("symbole", TBSymbolere.Text);
                if (art.Count > 0)
                {
                    TBDescre.Text = art.ElementAt(0).description;
                    TBBesoinre.Text = art.ElementAt(0).besoin + "";
                    TBStockre.Text = art.ElementAt(0).stock + "";
                    TBRatiore.Text = art.ElementAt(0).ratio + "";
                    TBSAre.Text = art.ElementAt(0).sa + "";
                    TBSMdhillare.Text = art.ElementAt(0).smdhilla + "";
                    TBSSkhirare.Text = art.ElementAt(0).sskhira + "";
                    TBDesignationre.Text = art.ElementAt(0).designation;
                    TBFormatre.Text = art.ElementAt(0).format;
                    TBEpisseurre.Text = art.ElementAt(0).episseur;
                    TBSymbolere.Background = Brushes.GreenYellow;
                }
                else
                {
                    TBSymbolere.Background = Brushes.Bisque;
                    MessageBox.Show("Ce symbole n'existe pas dans la base de données courante", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                TBSymbolere.Background = Brushes.White;
                viderChampsArtilere();
            }
        }

        private void BAConfirmerArticlere_Click(object sender, RoutedEventArgs e)
        {
            if (TBSymbolere.Text.Equals(""))
            {
                MessageBox.Show("Vous devez saisir le symbole d'article", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Requettes.IdExiste(TBSymbolere.Text) == 0)
                {
                    MessageBox.Show("Vous devez saisir un symbole valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (TBSymbolere.Text.Equals("") || TBDescre.Text.Equals("") || TBBesoinre.Text.Equals("") || TBStockre.Text.Equals("") || TBNouvelleQuantiterre.Text.Equals("") || TBUsagere.Text.Equals(""))
                    {
                        MessageBox.Show("Champ(s) vide(s)", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (float.Parse(TBNouvelleQuantiterre.Text) > float.Parse(TBStockre.Text))
                        {
                            MessageBox.Show("Stock insuffisant", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            if (Requettes.ModifierArticle(Int16.Parse(TBSymbolere.Text), TBDescre.Text, Int16.Parse(TBBesoinre.Text), float.Parse(TBStockre.Text) - float.Parse(TBNouvelleQuantiterre.Text), float.Parse(TBRatiore.Text), float.Parse(TBSAre.Text), float.Parse(TBSMdhillare.Text), float.Parse(TBSSkhirare.Text), TBDesignationre.Text, TBFormatre.Text, TBEpisseurre.Text) == 0)
                            {
                                MessageBox.Show("Cet article a été modifier avec succèes", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                                DateTime localDate = DateTime.Now;
                                int anne = localDate.Year;
                                int moi = localDate.Month;
                                int jour = localDate.Day;
                                Requettes.AjouterJournalArticle(idGeneral, Int16.Parse(TBSymbolere.Text), anne + "", moi + "", jour + "", "retirer", (float.Parse(TBStockre.Text) - float.Parse(TBNouvelleQuantiterre.Text)) + "");
                            
                                try
                                {
                                    DateTime thisDate = DateTime.Now;
                                    CultureInfo culture = new CultureInfo("fr-FR");
                                    Requettes.AjouterJournal(idGeneral, "Modifier l'article : " + TBSymbolere.Text + " : " + thisDate.ToString());
                
                                }
                                catch (Exception ex)
                                {

                                }
                                TBSymbolere.Background = Brushes.White;
                                viderChampsArtilere();
                                importerArticle();
                                importerJournalArticle();
                            }
                        }
                    }
                }
            }
        }

        private void FiltreRechArticleJ_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FiltreRechArticleJ.Text.Equals(""))
            {
                importerJournalArticle();
            }
            else
            {

                string value = "";
                if (CRechArticle.SelectedIndex == 0)
                {
                    value = "idp";
                }
                else
                {
                    value = "tache";
                }
                importerJournalPersonel(value, FiltreRechAdminJ.Text);
            }
        }

        private void ImprimerJournal_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridJournal, "Journal des Personel.");
            try
            {
                DateTime thisDate = DateTime.Now;
                CultureInfo culture = new CultureInfo("fr-FR");
                Requettes.AjouterJournal(idGeneral, "Impression de le journal des personels " + thisDate.ToString());

            }
            catch (Exception ex)
            {

            }
        }

        private void BtImprimerListeArticle_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridArticle, "Liste des articles.");
            try
            {
                DateTime thisDate = DateTime.Now;
                CultureInfo culture = new CultureInfo("fr-FR");
                Requettes.AjouterJournal(idGeneral, "Impression de le liste des articles " + thisDate.ToString());

            }
            catch (Exception ex)
            {

            }
        }

        private void ImprimerArticle_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridArticleJ, "Journal des articles.");
            try
            {
                DateTime thisDate = DateTime.Now;
                CultureInfo culture = new CultureInfo("fr-FR");
                Requettes.AjouterJournal(idGeneral, "Impression de journal des articles " + thisDate.ToString());

            }
            catch (Exception ex)
            {

            }
        }

        private void ImprimerStatI_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(gridStatI, "Statistique : Activité des personels");
            try
            {
                DateTime thisDate = DateTime.Now;
                CultureInfo culture = new CultureInfo("fr-FR");
                Requettes.AjouterJournal(idGeneral, "Impression d'activité des personels " + thisDate.ToString());

            }
            catch (Exception ex)
            {

            }
        }

        private void ImprimerStatII_Click(object sender, RoutedEventArgs e)
        {

            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(gridStatII, "Statistique : Stock disponible");
            try
            {
                DateTime thisDate = DateTime.Now;
                CultureInfo culture = new CultureInfo("fr-FR");
                Requettes.AjouterJournal(idGeneral, "Impression Stock disponible " + thisDate.ToString());

            }
            catch (Exception ex)
            {

            }
        }

        private void ImprimerStatITI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void symboleArticleStat_KeyUp(object sender, KeyEventArgs e)
        {
            symboleArticleStat.Text = saisieFloat(sender);
            if(symboleArticleStat.Text.Equals(""))
            {
                ((LineSeries)mcChartSS.Series[0]).ItemsSource = null;
                symboleArticleStat.Background = Brushes.Bisque;
            }
            else
            {
                
                if (Requettes.SymboleExisteJournalArticle(symboleArticleStat.Text)==0)
                    {
                        symboleArticleStat.Background = Brushes.Bisque;
                    }
                    else
                    {
                        List<journalArticle> art = Requettes.getAllJournalArticleBySymbole(symboleArticleStat.Text);
                        List<PersonelStat> v = new List<PersonelStat>();
                        //List<Article> ls = Requettes.getAllArticle();
                        for (int i = 0; i < art.Count; i++)
                        {
                            v.Add(new PersonelStat(new DateTime(Int16.Parse(art.ElementAt(i).anne), Int16.Parse(art.ElementAt(i).moi), Int16.Parse(art.ElementAt(i).jour)).ToShortDateString(), Int16.Parse(art.ElementAt(i).remarque + "")));
                        }

                        ((LineSeries)mcChartSS.Series[0]).ItemsSource = v;
                        symboleArticleStat.Background = Brushes.GreenYellow;
                    }
            }
        }
    }
}
