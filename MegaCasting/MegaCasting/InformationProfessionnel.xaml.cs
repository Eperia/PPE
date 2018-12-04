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
    /// Logique d'interaction pour InformationProfessionnel.xaml
    /// </summary>
    public partial class InformationProfessionnel : UserControl
    {
        Professionnel professionnel = new Professionnel();
        ProfessionnelRepository professionnelRepository = new ProfessionnelRepository();
        GestionProfessionnel gestionProfessionnel = new GestionProfessionnel();
        bool ajout;



        public InformationProfessionnel(GestionProfessionnel _gestionProfessionnel, bool _ajout, Professionnel _professionnel = null)
        {

            InitializeComponent();



            gestionProfessionnel = _gestionProfessionnel;
            ajout = _ajout;

            if (_professionnel != null)
            {
                professionnel = _professionnel;
            }
            TxtBlibelle.Text = (professionnel.Libelle == null) ? "" : professionnel.Libelle.ToString();
            TxtBRue.Text = (professionnel.Rue == null) ? "" : professionnel.Rue.ToString();
            TxtTel.Text = (professionnel.Telephone == null) ? "" : professionnel.Telephone.ToString();
            TxtBFax.Text = (professionnel.Fax == null) ? "" : professionnel.Fax.ToString();
            TxtBUrl.Text = (professionnel.URL == null) ? "" : professionnel.URL.ToString();
            TxtEmail.Text = (professionnel.Email == null) ? "" : professionnel.Email.ToString();
            TxtBVille.Text = (professionnel.Ville == null) ? "" : professionnel.Ville.ToString();
            TxtBCodePostal.Text = (professionnel.CodePostal == null) ? "" : professionnel.CodePostal.ToString();
            TxtBPays.Text = (professionnel.Pays == null) ? "" : professionnel.Pays.ToString();
            LbValNbrPost.Content = professionnel.NbrPoste.ToString();


        }

        private void button_Save(object sender, RoutedEventArgs e)
        {
            int verifnumber = 0;
            if (TxtBlibelle.Text == "" || TxtEmail.Text == "" || TxtBRue.Text == "" || TxtBVille.Text == "" || TxtBCodePostal.Text == "" || TxtBPays.Text == "" || TxtTel.Text == "" || TxtBUrl.Text == "" || !int.TryParse(TxtTel.Text, out verifnumber) || (!int.TryParse(TxtBFax.Text, out verifnumber) && TxtBFax.Text != "") || (TxtBMdp.Text == "" && ajout))
            {
                ErreurSaisie erreurSaisie = new ErreurSaisie();
                erreurSaisie.ShowDialog();
            }
            else
            {
                professionnel.Libelle = TxtBlibelle.Text;
                professionnel.Rue = TxtBRue.Text;
                professionnel.Ville = TxtBVille.Text;
                professionnel.CodePostal = TxtBCodePostal.Text;
                professionnel.Pays = TxtBPays.Text;
                professionnel.Telephone = TxtTel.Text;
                professionnel.Fax = TxtBFax.Text;
                professionnel.URL = TxtBUrl.Text;
                professionnel.Mdp = TxtBMdp.Text;
                professionnel.Email = TxtEmail.Text;
                professionnel.NbrPoste = Int32.Parse(LbValNbrPost.Content.ToString());
                if (ajout)
                {
                    professionnelRepository.Insert(professionnel);
                }
                else
                {
                    professionnelRepository.Update(professionnel);
                }
                gestionProfessionnel.reload();
                gestionProfessionnel.STKPinformationPartenaire.Children.Clear();

            }
        }

        private void BtAddNbrPost_Click(object sender, RoutedEventArgs e)
        {
            GestionProfessionnelPack gestionProfessionnelPack = new GestionProfessionnelPack(professionnel);
            gestionProfessionnelPack.ShowDialog();
        }
    }
}
