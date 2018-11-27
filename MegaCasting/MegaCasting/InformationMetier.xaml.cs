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
         Metier metier = new Metier();
         bool ajout = false;

        public InformationMetier(Metier _metier = null)
        {
            InitializeComponent();
            

            if (_metier != null)
            {
                metier = _metier;
                CbDomaineMetier.SelectedIndex = (int)metier.Id_DomaineMetier - 1;
                TxtBMetier.Text = metier.Nom;
            }
            else
            {
                ajout = true;
                CbDomaineMetier.SelectedIndex = 0;
                BtSupr.Visibility = Visibility.Hidden;
            }
            this.reload();




        }
        public void reload()
        {
            domaineMetiers = domaineMetierRepository.Select();
            List<string> Names = new List<string>();
            foreach (DomaineMetier domaineMetier in domaineMetiers)
            {
                Names.Add(domaineMetier.Nom);
            }

            CbDomaineMetier.ItemsSource = Names;
            CbDomaineMetier.Items.Refresh();

        }

        private void BtSauv_Click(object sender, RoutedEventArgs e)
        {
            if (ajout)
            {   
                metier.Nom = TxtBMetier.Text;
                metier.Id_DomaineMetier = domaineMetierRepository.SelectId(CbDomaineMetier.Text);
                metierRepository.Insert(metier);
                ((StackPanel)this.Parent).Children.Clear();


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
