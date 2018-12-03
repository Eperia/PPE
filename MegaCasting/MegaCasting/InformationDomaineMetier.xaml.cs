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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MegaCasting
{
    /// <summary>
    /// Logique d'interaction pour InformationDomaineMetier.xaml
    /// </summary>
    public partial class InformationDomaineMetier : UserControl
    {
        DomaineMetierRepository domaineMetierRepository = new DomaineMetierRepository();

        ListBox listBox;
        DomaineMetier domaineMetier = new DomaineMetier();
        bool ajout = false;

        /// <summary>
        /// Si il "_domaineMetier" est différent de null on va afficher les infos du domaine metier et stocké dans une variable accéssible dans notre class
        /// Sinon le booléen ajout est à "true" et notre bouton supprimer n'est pas visible 
        /// </summary>
        /// <param name="_listBox"> récupère la listBox où sont répertoriés tout les domaines métier </param>
        /// <param name="_domaineMetier">récupère le domaine domaine métier à afficher</param>
        public InformationDomaineMetier(ListBox _listBox = null, DomaineMetier _domaineMetier = null)
        {
            InitializeComponent();
            listBox = _listBox;
            if (_domaineMetier != null)
            {
                domaineMetier = _domaineMetier;
                TxtDomaineMetier.Text = domaineMetier.Nom;
            }
            else
            {
                ajout = true;
                BtSupr.Visibility = Visibility.Hidden;
            }
        }

        private void BtSauv_Click(object sender, RoutedEventArgs e)
        {
            if (ajout)
            {
                domaineMetier.Nom = TxtDomaineMetier.Text;
                domaineMetier.Id = domaineMetierRepository.Insert(domaineMetier);
                BtSupr.Visibility = Visibility.Visible;
                ajout = false;
                ((StackPanel)this.Parent).Children.Clear(); 
                listBox.Items.Add(this);
                listBox.Items.Refresh();
            }
            else
            {
                domaineMetier.Nom = TxtDomaineMetier.Text;
                domaineMetierRepository.Update(domaineMetier);
            }
        }

        private void BtSupr_Click(object sender, RoutedEventArgs e)
        {
            if (domaineMetierRepository.VerifDomaineMetier_Metier(domaineMetier.Id))
            {
                domaineMetierRepository.Delete(domaineMetier.Id);
                ((ListBox)this.Parent).Items.Remove(this);
            }
            else
            {
                ErreurSuppression erreurSuppression = new ErreurSuppression();
                erreurSuppression.ShowDialog();
            }
        }

    }
}
