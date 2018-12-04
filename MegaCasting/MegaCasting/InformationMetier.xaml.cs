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
using MegaCasting.Class;

namespace MegaCasting
{
    /// <summary>
    /// Logique d'interaction pour InformationMetier.xaml
    /// </summary>
    public partial class InformationMetier : UserControl
    {
        #region field
        DomaineMetierRepository domaineMetierRepository = new DomaineMetierRepository();
        MetierRepository metierRepository = new MetierRepository();
        List<DomaineMetier> domaineMetiers = new List<DomaineMetier>();
        ListBox listBox;
        Metier metier = new Metier();
        bool ajout = false;
        #endregion


        /// Si le "_Metier" est différent de null on va afficher les infos du metier et stocké dans une variable accessible dans notre class
        /// Sinon le booléen ajout est à "true" et le bouton supprimer n'est pas visible 
        /// </summary>
        /// <param name="_listBox">récupère la listBox où sont répertoriés tout les métiers </param>
        /// <param name="_metier">récupère le métier à afficher</param>
        public InformationMetier(ListBox _listBox = null, Metier _metier = null)
        {
            InitializeComponent();

            listBox = _listBox;
            List<string> Names= new List<string>();
            Names = this.reload();

            if (_metier != null)
            {
                metier = _metier;
                CbDomaineMetier.SelectedIndex = Names.IndexOf(domaineMetierRepository.SelectName(metier.Id_DomaineMetier));

                TxtBMetier.Text = metier.Nom;
            }
            else
            {
                ajout = true;
                CbDomaineMetier.SelectedIndex = 0;
                BtSupr.Visibility = Visibility.Hidden;
            }




        }

        /// <summary>
        /// Créer une list de nom des domaines métier
        /// et donne cette list a la comboBox
        /// Puis refresh la listeBox "listBox_Pack"
        /// </summary>
        public List<string> reload()
        {
            domaineMetiers = domaineMetierRepository.Select();
            List<string> Names = new List<string>();
            foreach (DomaineMetier domaineMetier in domaineMetiers)
            {
                Names.Add(domaineMetier.Nom);
            }

            CbDomaineMetier.ItemsSource = Names;
            CbDomaineMetier.Items.Refresh();
            return Names;
        }

        /// <summary>
        /// on récupère les valeurs des texteBox pour la mettre dans notre objet
        /// si c'est un ajout, on va récupérer l'id qui est inséré, le bouton supprimer deviens visible, supprimer notre UC de notre StackPanel,
        /// on ajoute notre UC a notre listBox et on refresh la listBox 
        /// le booléan "ajout" est false
        /// Sinojn on fait update
        /// </summary>
        private void BtSauv_Click(object sender, RoutedEventArgs e)
        {
            if (ajout)
            {   
                metier.Nom = TxtBMetier.Text;
                metier.Id_DomaineMetier = domaineMetierRepository.SelectId(CbDomaineMetier.Text);
                metier.Id = metierRepository.Insert(metier);
                BtSupr.Visibility = Visibility.Visible;
                ajout = false;
                ((StackPanel)this.Parent).Children.Clear();
                listBox.Items.Add(this);
                listBox.Items.Refresh();
            }
            else
            {
                metier.Nom = TxtBMetier.Text;
                metier.Id_DomaineMetier = domaineMetierRepository.SelectId(CbDomaineMetier.Text);
                metierRepository.Update(metier);
            }
            


        }

        /// <summary>
        /// supprime le métier dans la BDD
        /// </summary>
        private void BtSupr_Click(object sender, RoutedEventArgs e)
        {
            metierRepository.Delete(metier.Id);
            ((ListBox)this.Parent).Items.Remove(this);

        }
    }
}
