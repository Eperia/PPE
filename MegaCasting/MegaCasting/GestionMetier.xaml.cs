using MegaCasting.Class;
using MegaCasting.repository;
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

namespace MegaCasting
{
    /// <summary>
    /// Logique d'interaction pour GestionMetier.xaml
    /// </summary>
    public partial class GestionMetier : Window
    {
        private MetierRepository metierRepository = new MetierRepository();

        public GestionMetier()
        {
            InitializeComponent();
            reload();
        }

        /// <summary>
        /// Créer pour chaque métier un UC qui donne en paramètre: null et le métier
        /// Puis refresh la listeBox "listBox_Metier"
        /// </summary>
        public void reload()
        {
            foreach (Metier metier in metierRepository.Select())
            {
                listBox_Metier.Items.Add(new InformationMetier(null, metier));
            }
            listBox_Metier.Items.Refresh();

        }

        /// <summary>
        /// instancie l'UC et fournis la listeBox "listBox_Metier"
        /// ajoute l'UC au StackPanel "STKPinformationMetier"
        /// </summary>
        private void BtAjout_Click(object sender, RoutedEventArgs e)
        {
            InformationMetier informationMetier = new InformationMetier(this.listBox_Metier);
            STKPinformationMetier.Children.Add(informationMetier);

        }
    }
}
