using System.Collections.Generic;
using System.Windows;
using MegaCasting.Class;
using MegaCasting.repository;

namespace MegaCasting
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Partenaire> partenaires;
        OffreCastingRepository offreCastingRepository = new OffreCastingRepository();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GestionPartenaire gestionPartenaire = new GestionPartenaire();
            gestionPartenaire.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            GestionPartenaire gestionPartenaire = new GestionPartenaire();
            gestionPartenaire.Show();
        }

        private void Click_AfficherProfessionnel(object sender, RoutedEventArgs e)
        {
            GestionProfessionnel gestionProfessionnel = new GestionProfessionnel();
            gestionProfessionnel.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            GestionMetier gestionMetier = new GestionMetier();
            gestionMetier.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            GestionDomaineMetier gestionDomaineMetier = new GestionDomaineMetier();
            gestionDomaineMetier.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            GestionPack gestionPack = new GestionPack();
            gestionPack.Show();
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            List<OffreCasting> offreCastings = new List<OffreCasting>();
            offreCastings = offreCastingRepository.Select();
            LvCasting.ItemsSource = offreCastings;
            LvCasting.Items.Refresh();

        }
    }
}

