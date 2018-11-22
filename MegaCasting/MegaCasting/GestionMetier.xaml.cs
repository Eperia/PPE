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
    /// Logique d'interaction pour GestionMetier.xaml
    /// </summary>
    public partial class GestionMetier : Window
    {
        MetierRepository metierRepository = new MetierRepository();

        public GestionMetier()
        {
            InitializeComponent();

            foreach (Metier metier in metierRepository.Select())
            {

            }
            listBox_Metier.Items.Add()
        }
    }
}
