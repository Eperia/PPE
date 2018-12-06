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
    /// Logique d'interaction pour InformationOffreCasting.xaml
    /// </summary>
    public partial class InformationOffreCasting : Window
    {
        ProfessionnelRepository professionnelRepository = new ProfessionnelRepository();
        EmployerRepository employerRepository = new EmployerRepository();

        List<Employer> employers = new List<Employer>();
        List<Professionnel> professionnels = new List<Professionnel>();



        public InformationOffreCasting()
        {
            InitializeComponent();
            professionnels = professionnelRepository.Select();
            CbProfessionnel.ItemsSource = professionnels;



            employers = employerRepository.Select();
            CbEmploye.ItemsSource = employers;
        }
    }
}
