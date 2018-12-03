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
using MegaCasting.repository;

namespace MegaCasting
{
    /// <summary>
    /// Logique d'interaction pour InformationPartenaire.xaml
    /// </summary>
    public partial class InformationPartenaire : UserControl
    {
        Partenaire partenaire = new Partenaire();
        GestionPartenaire gestionPartenaire;
        bool ajout;
        PartenaireRepository partenaireRepository = new PartenaireRepository();

        public InformationPartenaire(GestionPartenaire _gestionPartenaire, bool _ajout,Partenaire _partenaires = null)
        {
            InitializeComponent();

            ajout = _ajout;
            gestionPartenaire = _gestionPartenaire;

            if (!_ajout || _partenaires != null )
            {
                partenaire = _partenaires;
            }

            ajout = _ajout;
            gestionPartenaire = _gestionPartenaire;

            TxtBlibelle.Text = (partenaire.Libelle == null) ? "" :  partenaire.Libelle.ToString();
            TxtBRue.Text = (partenaire.Rue == null) ? "" :  partenaire.Rue.ToString();
            TxtTel.Text   = (partenaire.Telephone == null) ? "" : partenaire.Telephone.ToString();
            TxtBFax.Text = (partenaire.Fax == null) ? "" : partenaire.Fax.ToString();
            TxtBUrl.Text = (partenaire.URL == null) ? "" : partenaire.URL.ToString();           
            TxtBVille.Text = (partenaire.Ville == null) ? "" :  partenaire.Ville.ToString();
            TxtBCodePostal.Text = (partenaire.CodePostal == null) ? "" :  partenaire.CodePostal.ToString();
            TxtBPays.Text = (partenaire.Pays == null) ? "" :  partenaire.Pays.ToString();
            TxtBEmail.Text = (partenaire.Email == null) ? "" : partenaire.Email.ToString();
            TxtBMdp.Text = "";

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int verifnumber = 0;
            if (TxtBlibelle.Text =="" || TxtBEmail.Text == "" || TxtBRue.Text =="" || TxtBVille.Text == "" || TxtBCodePostal.Text == "" || TxtBPays.Text == "" || TxtTel.Text =="" || TxtBUrl.Text=="" || !int.TryParse(TxtTel.Text, out verifnumber )|| (!int.TryParse(TxtBFax.Text, out verifnumber) && TxtBFax.Text != "") || (TxtBMdp.Text == "" && ajout))
            {
                ErreurSaisie erreurSaisie = new ErreurSaisie();
                erreurSaisie.ShowDialog();
            }
            else
            {
                partenaire.Libelle = TxtBlibelle.Text;
                partenaire.Rue = TxtBRue.Text;
                partenaire.Ville = TxtBVille.Text;
                partenaire.CodePostal = TxtBCodePostal.Text;
                partenaire.Pays = TxtBPays.Text;
                partenaire.Telephone = TxtTel.Text;
                partenaire.Fax = TxtBFax.Text;
                partenaire.URL = TxtBUrl.Text;
                partenaire.Mdp = TxtBMdp.Text;
                partenaire.Email = TxtBEmail.Text;

                if (ajout)
                {                   
                    partenaireRepository.Insert(partenaire);
                }
                else
                {
                    partenaireRepository.Update(partenaire);
                }
                gestionPartenaire.reload();
                gestionPartenaire.STKPinformationPartenaire.Children.Clear();

            }
            
        }
    }
}
