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
         DomaineMetierRepository domaineMetierRepository = new DomaineMetierRepository();
         MetierRepository metierRepository = new MetierRepository();
         List<DomaineMetier> domaineMetiers = new List<DomaineMetier>();
        ListBox listBox;
         Metier metier = new Metier();
         bool ajout = false;

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

        private void BtSupr_Click(object sender, RoutedEventArgs e)
        {
            metierRepository.Delete(metier.Id);
            ((ListBox)this.Parent).Items.Remove(this);

        }
    }
}
