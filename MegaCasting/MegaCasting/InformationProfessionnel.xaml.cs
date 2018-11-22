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
        GestionProfessionnel gestionProfessionnel = new  GestionProfessionnel();
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
            TxtBAdresse.Text = (professionnel.Adresse == null) ? "" : professionnel.Adresse.ToString();
            TxtTel.Text = (professionnel.Telephone == null) ? "" : professionnel.Telephone.ToString();
            TxtBFax.Text = (professionnel.Fax == null) ? "" : professionnel.Fax.ToString();
            TxtBUrl.Text = (professionnel.URL == null) ? "" : professionnel.URL.ToString();
            TxtEmail.Text = (professionnel.Email == null) ? "" : professionnel.Email.ToString();
            LbValNbrPost.Content = professionnel.NbrPoste.ToString();


        }

        private void button_Save(object sender, RoutedEventArgs e)
        {
            int verifnumber = 0;
            if (TxtBlibelle.Text == "" || TxtBAdresse.Text == "" || TxtTel.Text == "" || TxtBUrl.Text == "" || TxtEmail.Text == "" || !int.TryParse(TxtTel.Text, out verifnumber) || (!int.TryParse(TxtBFax.Text, out verifnumber) && TxtBFax.Text != ""))
            {
                ErreurSaisie erreurSaisie = new ErreurSaisie();
                erreurSaisie.ShowDialog();
            }
            else
            {
                professionnel.Libelle = TxtBlibelle.Text;
                professionnel.Adresse = TxtBAdresse.Text;
                professionnel.Telephone = TxtTel.Text;
                professionnel.Fax = TxtBFax.Text;
                professionnel.URL = TxtBUrl.Text;
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
    }
}
