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
    /// Logique d'interaction pour GestionDomaineMetier.xaml
    /// </summary>
    public partial class GestionDomaineMetier : Window
    {
        private DomaineMetierRepository domaineMetierRepository = new DomaineMetierRepository();

        public GestionDomaineMetier()
        {
            InitializeComponent();
            reload();
        }

        /// <summary>
        /// Créer pour chaque domaine métier un UC qui donne en paramètre: null et le domaine métier
        /// Puis refresh la listeBox "listBox_DomaineMetier"
        /// </summary>
        public void reload()
        {
            foreach (DomaineMetier domaineMetier in domaineMetierRepository.Select())
            {
                listBox_DomaineMetier.Items.Add(new InformationDomaineMetier(null, domaineMetier));
            }
            listBox_DomaineMetier.Items.Refresh();

        }

        /// <summary>
        /// instancie l'UC et fournis la listeBox "listBox_DomaineMetier"
        /// ajoute l'UC au StackPanel "STKPinformationDomaineMetier"
        /// </summary>
        private void BtAjout_Click(object sender, RoutedEventArgs e)
        {
            InformationDomaineMetier informationDomaineMetier = new InformationDomaineMetier(this.listBox_DomaineMetier);
            STKPinformationDomaineMetier.Children.Add(informationDomaineMetier);

        }
    }
}
