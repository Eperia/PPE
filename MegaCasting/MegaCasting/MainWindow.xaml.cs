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
using MegaCasting.Class;

namespace MegaCasting
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Partenaire> partenaires;
        public MainWindow()
        {
            InitializeComponent();
            partenaires = new List<Partenaire>();
            Partenaire partenaire2 = new Partenaire();
            partenaire2.Libelle = "test";
            partenaire2.Adresse = "22 rue des maraîchers 35500 Vitre";
            partenaires.Add(partenaire2);
            for (int i = 0; i < 5; i++)
            {

                partenaires.Add(new Partenaire());
            }
            
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
    }
}
