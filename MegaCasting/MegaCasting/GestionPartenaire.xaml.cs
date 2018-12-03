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
using MegaCasting.Class;
using MegaCasting.repository;

namespace MegaCasting
{
    /// <summary>
    /// Logique d'interaction pour GestionPartenaire.xaml
    /// </summary>
    public partial class GestionPartenaire : Window
    {
        List<Partenaire> partenaires;
        PartenaireRepository partenaireRepository = new PartenaireRepository();
        public GestionPartenaire()
        {
            InitializeComponent();

            this.reload();


        }
        /// <summary>
        /// récupère la valeur de partenaireRepository.Select() et la stock dans la variable partenaires (List<Partenaire>)
        /// ajoute la variable dans la ListView "lvUsers" et ensuite la refresh
        /// </summary>
        public void reload() {
            partenaires = partenaireRepository.Select();
            lvUsers.ItemsSource = partenaires;
            lvUsers.Items.Refresh();

        }

        /// <summary>
        /// Vérifie que l'item sélectionner n'est pas faux
        /// puis créer un UC InformationPartenaire et l'ajouté à un StackPanel
        /// </summary>
        private void lvUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.lvUsers.SelectedIndex  != -1 && this.lvUsers.SelectedIndex < partenaires.Count)
            {
                STKPinformationPartenaire.Children.Clear();
                InformationPartenaire informationPartenaire = new InformationPartenaire( this, false, partenaires[lvUsers.SelectedIndex]);
                STKPinformationPartenaire.Children.Add(informationPartenaire);

            }
            
            
            


        }

        /// <summary>
        /// puis créer un UC InformationPartenaire et l'ajouté à un StackPanel
        /// </summary>
        private void button_Ajouter(object sender, RoutedEventArgs e)
        {
            STKPinformationPartenaire.Children.Clear();
            InformationPartenaire informationPartenaire = new InformationPartenaire(this, true);
            STKPinformationPartenaire.Children.Add(informationPartenaire);
            

        }

        /// <summary>
        /// Vérifie que l'item sélectionner n'est pas faux
        /// supprime dans la BDD le partenaire sélectionner
        /// et clear le StackPanel
        /// </summary>
        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedIndex >=0 && lvUsers.SelectedIndex < partenaires.Count)
            {
                partenaireRepository.Delete(partenaires[lvUsers.SelectedIndex].Id);
                this.reload();
                STKPinformationPartenaire.Children.Clear();
            }

        }
    }
}
