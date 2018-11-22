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
    /// Logique d'interaction pour GestionProfessionnel.xaml
    /// </summary>
    public partial class GestionProfessionnel : Window
    {
        List<Professionnel> professionnels = new List<Professionnel>();
        ProfessionnelRepository professionnelRepository = new ProfessionnelRepository();
        public GestionProfessionnel()
        {
            InitializeComponent();

            this.reload();
        }
        public void reload()
        {
            professionnels = professionnelRepository.Select();
            lvUsers.ItemsSource = professionnels;
            lvUsers.Items.Refresh();

        }
        private void lvUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.lvUsers.SelectedIndex != -1 && this.lvUsers.SelectedIndex < professionnels.Count)
            {
                STKPinformationPartenaire.Children.Clear();
                InformationProfessionnel informationPartenaire = new InformationProfessionnel( this, false, professionnels[lvUsers.SelectedIndex]);
                STKPinformationPartenaire.Children.Add(informationPartenaire);
            }





        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            STKPinformationPartenaire.Children.Clear();
            InformationProfessionnel informationPartenaire = new InformationProfessionnel(this, true);
            STKPinformationPartenaire.Children.Add(informationPartenaire);

        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedIndex >= 0 && lvUsers.SelectedIndex < professionnels.Count)
            {
                professionnelRepository.Delete(professionnels[lvUsers.SelectedIndex].Id);
                this.reload();
                STKPinformationPartenaire.Children.Clear();

            }
        }
    }
}
