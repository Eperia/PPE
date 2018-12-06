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
    /// Logique d'interaction pour InformationHistoriquePack.xaml
    /// </summary>
    public partial class InformationHistoriquePack : Window
    {
        List<HistoriquePack> historiquePacks = new List<HistoriquePack>();
        Professionnel professionnel = new Professionnel();
        HistoriquePackRepository historiquePackRepository = new HistoriquePackRepository();
        public InformationHistoriquePack(Professionnel _professionnel)
        {
            InitializeComponent();
            professionnel = _professionnel;
            this.reload();
        }
        public void reload()
        {
            historiquePacks = historiquePackRepository.Select(professionnel);
            lvUsers.ItemsSource = historiquePacks;
            lvUsers.Items.Refresh();

        }
    }
}
