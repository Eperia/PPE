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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MegaCasting
{
    /// <summary>
    /// Logique d'interaction pour InformationPack.xaml
    /// </summary>
    public partial class InformationPack : UserControl
    {
        #region Field
        PackRepository packRepository = new PackRepository();
        ListBox listBox;
        Pack pack = new Pack();
        bool ajout = false;
        #endregion

        public InformationPack(ListBox _listBox = null, Pack _pack = null)
        {
            InitializeComponent();

            listBox = _listBox;
            if (_pack != null)
            {
                pack = _pack;

                TxtPackName.Text = pack.Libelle;
                TxtBPackPrix.Text = pack.PrixPack.Prix.ToString();
                TxtBPackNbrPost.Text = pack.NbrPoste.ToString();
            }
            else
            {
                ajout = true;

            }
        }

        private void BtSauv_Click(object sender, RoutedEventArgs e)
        {
            pack.Libelle = TxtPackName.Text;
            pack.PrixPack.Prix = double.Parse(TxtBPackPrix.Text);
            pack.NbrPoste = int.Parse(TxtBPackNbrPost.Text);
            if (ajout)
            {
                pack.ID = packRepository.Insert(pack);

                ajout = false;
                ((StackPanel)this.Parent).Children.Clear();
                listBox.Items.Add(this);
                listBox.Items.Refresh();
            }
            else
            {
                packRepository.Update(pack);
            }



        }
        /*
         * Version actuel utilise pas la suppression du pack
        private void BtSupr_Click(object sender, RoutedEventArgs e)
        {
            packRepository.Delete(pack.ID);
            ((ListBox)this.Parent).Items.Remove(this);
        }
        */
    }
}
