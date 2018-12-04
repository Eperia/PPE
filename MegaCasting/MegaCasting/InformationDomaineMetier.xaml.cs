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
    public partial class InformationDomaineMetier : UserControl
    {
        #region Field
        DomaineMetierRepository domaineMetierRepository = new DomaineMetierRepository();
        ListBox listBox;
        DomaineMetier domaineMetier = new DomaineMetier();
        bool ajout = false;
        #endregion


        /// <summary>
        /// Si le "_domaineMetier" est différent de null on va afficher les infos du domaine metier et stocké dans une variable accessible dans notre class.
        /// Sinon le booléen ajout est à "true" et le bouton supprimer n'est pas visible 
        /// </summary>
        /// <param name="_listBox"> récupère la listBox où sont répertoriés tout les domaines métier </param>
        /// <param name="_domaineMetier">récupère le domaine métier à afficher</param>
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

        /// <summary>
        /// on récupère la valeur de la texteBox pour la mettre dans notre objet
        /// si c'est un ajout, on va récupérer l'id qui est inséré, le bouton supprimer deviens visible, supprimer notre UC de notre StackPanel,
        /// on ajoute notre UC a notre listBox et on refresh la listBox 
        /// le booléan "ajout" est false
        /// Sinojn on fait update
        /// </summary>
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

        /// <summary>
        /// Vérifie et supprime le domaine métier dans la BDD
        /// Sinon on envoie un message d'erreur
        /// </summary>
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
