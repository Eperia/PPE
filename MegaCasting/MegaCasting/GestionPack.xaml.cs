﻿using MegaCasting.Class;
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
    /// Logique d'interaction pour GestionPack.xaml
    /// </summary>
    public partial class GestionPack : Window
    {
        private PackRepository packRepository = new PackRepository();
        public GestionPack()
        {
            InitializeComponent();
            reload();
        }
        public void reload()
        {
            foreach (Pack pack in packRepository.Select())
            {
                listBox_Pack.Items.Add(new InformationPack(null, pack));
            }
            listBox_Pack.Items.Refresh();

        }

        private void BtAjout_Click(object sender, RoutedEventArgs e)
        {
            InformationPack informationPack= new InformationPack(this.listBox_Pack);
            STKPinformationPack.Children.Add(informationPack);

        }
    }
}
