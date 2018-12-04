using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Class
{
    class OffreCasting
    {
        public Int64 Id { get; set; }
        public Int64 Id_Professionel { get; set; }
        public Int64 Id_Employe { get; set; }
        public string Titre { get; set; }
        public DateTime dt_debut_publi { get; set; }
        public int dure_dif { get; set; }
        public string localisation { get; set; }
        public string desc { get; set; }
        public DateTime dt_debut_contrat { get; set; }

    }
}
