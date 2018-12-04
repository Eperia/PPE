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
using System.Windows.Shapes;

namespace MegaCasting
{
    /// <summary>
    /// Logique d'interaction pour GestionProfessionnelPack.xaml
    /// </summary>
    public partial class GestionProfessionnelPack : Window
    {
        #region Field
        ProfessinnelPackRepository professinnelPackRepository = new ProfessinnelPackRepository();
        PackRepository packRepository = new PackRepository();

        List<Pack> packs = new List<Pack>();
        Professionnel professionnel = new Professionnel();
        #endregion

        public GestionProfessionnelPack(Professionnel _professionnel)
        {
            InitializeComponent();
            professionnel = _professionnel;
            reload();

        }

        public void reload()
        {
            packs = packRepository.Select();
            lvPacks.ItemsSource = packs;
            lvPacks.Items.Refresh();

        }
        private void BtAjout_Click(object sender, RoutedEventArgs e)
        {
            if (this.lvPacks.SelectedIndex != -1 && this.lvPacks.SelectedIndex < packs.Count)
            {
                professinnelPackRepository.Insert(packs[lvPacks.SelectedIndex].ID, professionnel.Id);
            }


        }
    }
}
