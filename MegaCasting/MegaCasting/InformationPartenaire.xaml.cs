﻿using System;
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
        Partenaire partenaire;
        GestionPartenaire gestionPartenaire;
        List<Partenaire> partenaires;
        bool ajout;
        PartenaireRepository partenaireRepository = new PartenaireRepository();

        public InformationPartenaire(List<Partenaire> _partenaires, GestionPartenaire _gestionPartenaire,bool _ajout)
        {
            InitializeComponent();

            ajout = _ajout;
            gestionPartenaire = _gestionPartenaire;
            partenaires = _partenaires;

            if (_ajout)
            {
                partenaire = new Partenaire();
            }
            else
            {
                partenaire = _partenaires[_gestionPartenaire.lvUsers.SelectedIndex];
            }
            TxtBlibelle.Text = (partenaire.Libelle == null) ? "" :  partenaire.Libelle.ToString();
            TxtBAdresse.Text = (partenaire.Adresse == null) ? "" :  partenaire.Adresse.ToString();
            TxtTel.Text   = (partenaire.Telephone == null) ? "" : partenaire.Telephone.ToString();
            TxtBFax.Text = (partenaire.Fax == null) ? "" : partenaire.Fax.ToString();
            TxtBUrl.Text = (partenaire.URL == null) ? "" : partenaire.URL.ToString();           
           
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int verifnumber = 0;
            if (TxtBlibelle.Text =="" || TxtBAdresse.Text =="" || TxtTel.Text =="" || TxtBUrl.Text=="" || !int.TryParse(TxtTel.Text, out verifnumber )|| (!int.TryParse(TxtBFax.Text, out verifnumber) && TxtBFax.Text != ""))
            {
                ErreurSaisie erreurSaisie = new ErreurSaisie();
                erreurSaisie.ShowDialog();
            }
            else
            {
                partenaire.Libelle = TxtBlibelle.Text;
                partenaire.Adresse = TxtBAdresse.Text;
                partenaire.Telephone = TxtTel.Text;
                partenaire.Fax = TxtBFax.Text;
                partenaire.URL = TxtBUrl.Text;
                if (ajout)
                {                   
                    partenaireRepository.Insert(partenaire);
                }
                else
                {

                }
                gestionPartenaire.reload();
                gestionPartenaire.STKPinformationPartenaire.Children.Clear();

            }
            
        }
    }
}
